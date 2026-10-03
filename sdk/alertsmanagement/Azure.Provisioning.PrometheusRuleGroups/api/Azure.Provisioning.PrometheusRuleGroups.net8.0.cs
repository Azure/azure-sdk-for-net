namespace Azure.Provisioning.PrometheusRuleGroups
{
    public partial class PrometheusRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrometheusRule() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.PrometheusRuleGroups.PrometheusRuleGroupAction> Actions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Alert { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Annotations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Expression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Labels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> MinActiveDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Record { get { throw null; } set { } }
        public Azure.Provisioning.PrometheusRuleGroups.PrometheusRuleResolveConfiguration ResolveConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Severity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrometheusRuleGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PrometheusRuleGroup(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ClusterName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Interval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.PrometheusRuleGroups.PrometheusRule> Rules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> Scopes { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PrometheusRuleGroups.PrometheusRuleGroup FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_03_01;
        }
    }
    public partial class PrometheusRuleGroupAction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrometheusRuleGroupAction() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ActionGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ActionProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrometheusRuleResolveConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrometheusRuleResolveConfiguration() { }
        public Azure.Provisioning.BicepValue<bool> IsAutoResolved { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> TimeToResolve { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
