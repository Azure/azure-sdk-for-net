namespace Azure.Provisioning.CognitiveServices
{
    public partial class CognitiveServicesAccount : Azure.Provisioning.Resource<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>
    {
        public CognitiveServicesAccount(Azure.Provisioning.IConstruct scope, string? kind = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku? sku = null, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "cs", string version = "2023-05-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>), default(bool)) { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesAccount FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
    public partial class CognitiveServicesAccountDeployment : Azure.Provisioning.Resource<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData>
    {
        public CognitiveServicesAccountDeployment(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel model, Azure.Provisioning.CognitiveServices.CognitiveServicesAccount? parent = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku? sku = null, string name = "cs", string version = "2023-05-01") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData>), default(bool)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeployment FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.CognitiveServices.CognitiveServicesAccount parent) { throw null; }
    }
}
