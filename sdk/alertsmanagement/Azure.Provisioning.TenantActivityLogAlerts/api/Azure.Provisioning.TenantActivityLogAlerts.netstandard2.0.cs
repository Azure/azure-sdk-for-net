namespace Azure.Provisioning.TenantActivityLogAlerts
{
    public partial class TenantActivityLogAlert : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TenantActivityLogAlert(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.TenantActivityLogAlerts.TenantActivityLogAlertActionGroup> ActionsActionGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.TenantActivityLogAlerts.TenantActivityLogAlertAnyOfOrLeafCondition> ConditionAllOf { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Scopes { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TenantScope { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.TenantActivityLogAlerts.TenantActivityLogAlert FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_04_01_PREVIEW;
        }
    }
    public partial class TenantActivityLogAlertActionGroup : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TenantActivityLogAlertActionGroup() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ActionGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ActionProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> WebhookProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TenantActivityLogAlertAnyOfOrLeafCondition : Azure.Provisioning.TenantActivityLogAlerts.TenantActivityLogAlertLeafCondition
    {
        public TenantActivityLogAlertAnyOfOrLeafCondition() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.TenantActivityLogAlerts.TenantActivityLogAlertLeafCondition> AnyOf { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TenantActivityLogAlertLeafCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TenantActivityLogAlertLeafCondition() { }
        public Azure.Provisioning.BicepList<string> ContainsAny { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EqualTo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Field { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
