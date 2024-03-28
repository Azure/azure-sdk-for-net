namespace Azure.Provisioning.ManagedServiceIdentities
{
    public partial class UserAssignedIdentity : Azure.Provisioning.Resource<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData>
    {
        public UserAssignedIdentity(Azure.Provisioning.IConstruct scope, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "useridentity", string version = "2023-01-31", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData>), default(bool)) { }
        public static Azure.Provisioning.ManagedServiceIdentities.UserAssignedIdentity FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
}
