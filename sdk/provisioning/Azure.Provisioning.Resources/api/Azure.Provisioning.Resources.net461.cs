namespace Azure.Provisioning.Resources
{
    public partial class DeploymentScript : Azure.Provisioning.Resource<Azure.ResourceManager.Resources.Models.AzureCliScript>
    {
        public DeploymentScript(Azure.Provisioning.IConstruct scope, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ScriptEnvironmentVariable> scriptEnvironmentVariables, string scriptContent, string name = "script", string version = "2020-10-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Resources.Models.AzureCliScript>), default(bool)) { }
        public DeploymentScript(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.Resource database, Azure.Provisioning.Parameter databaseServerName, Azure.Provisioning.Parameter appUserPasswordSecret, Azure.Provisioning.Parameter sqlAdminPasswordSecret, string version = "2020-10-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Resources.Models.AzureCliScript>), default(bool)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.Resources.DeploymentScript FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
    }
}
