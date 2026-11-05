namespace Azure.Provisioning.HealthBot
{
    public partial class HealthBot : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public HealthBot(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.HealthBot.HealthBotProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.HealthBot.HealthBotSkuName> SkuName { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.HealthBot.HealthBot FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_25;
            public static readonly string V2025_11_01;
        }
    }
    public partial class HealthBotKeyVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HealthBotKeyVaultProperties() { }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyVaultUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HealthBotProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HealthBotProperties() { }
        public Azure.Provisioning.BicepValue<string> AccessControlMethod { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> BotManagementPortalLink { get { throw null; } }
        public Azure.Provisioning.HealthBot.HealthBotKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HealthBotSkuName
    {
        F0 = 0,
        C0 = 1,
        PES = 2,
        C1 = 3,
    }
}
