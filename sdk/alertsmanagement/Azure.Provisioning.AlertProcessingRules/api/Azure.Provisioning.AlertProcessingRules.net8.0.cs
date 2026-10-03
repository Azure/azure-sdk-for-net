namespace Azure.Provisioning.AlertProcessingRules
{
    public partial class AlertProcessingRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AlertProcessingRule(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AlertProcessingRules.AlertProcessingRuleProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AlertProcessingRules.AlertProcessingRule FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_08_08;
        }
    }
    public partial class AlertProcessingRuleAction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AlertProcessingRuleAction() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AlertProcessingRuleAddGroupsAction : Azure.Provisioning.AlertProcessingRules.AlertProcessingRuleAction
    {
        public AlertProcessingRuleAddGroupsAction() { }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> ActionGroupIds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AlertProcessingRuleCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AlertProcessingRuleCondition() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AlertProcessingRules.AlertProcessingRuleField> Field { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AlertProcessingRules.AlertProcessingRuleOperator> Operator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AlertProcessingRuleField
    {
        Severity = 0,
        MonitorService = 1,
        MonitorCondition = 2,
        SignalType = 3,
        TargetResourceType = 4,
        TargetResource = 5,
        TargetResourceGroup = 6,
        AlertRuleId = 7,
        AlertRuleName = 8,
        Description = 9,
        AlertContext = 10,
    }
    public partial class AlertProcessingRuleMonthlyRecurrence : Azure.Provisioning.AlertProcessingRules.AlertProcessingRuleRecurrence
    {
        public AlertProcessingRuleMonthlyRecurrence() { }
        public Azure.Provisioning.BicepList<int> DaysOfMonth { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AlertProcessingRuleOperator
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Equals")]
        EqualsValue = 0,
        NotEquals = 1,
        Contains = 2,
        DoesNotContain = 3,
    }
    public partial class AlertProcessingRuleProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AlertProcessingRuleProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AlertProcessingRules.AlertProcessingRuleAction> Actions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AlertProcessingRules.AlertProcessingRuleCondition> Conditions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.AlertProcessingRules.AlertProcessingRuleSchedule Schedule { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Scopes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AlertProcessingRuleRecurrence : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AlertProcessingRuleRecurrence() { }
        public Azure.Provisioning.BicepValue<System.TimeSpan> EndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> StartOn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AlertProcessingRuleRemoveAllGroupsAction : Azure.Provisioning.AlertProcessingRules.AlertProcessingRuleAction
    {
        public AlertProcessingRuleRemoveAllGroupsAction() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AlertProcessingRuleSchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AlertProcessingRuleSchedule() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EffectiveFrom { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EffectiveUntil { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AlertProcessingRules.AlertProcessingRuleRecurrence> Recurrences { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeZone { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AlertProcessingRuleWeeklyRecurrence : Azure.Provisioning.AlertProcessingRules.AlertProcessingRuleRecurrence
    {
        public AlertProcessingRuleWeeklyRecurrence() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AlertProcessingRules.AlertsManagementDayOfWeek> DaysOfWeek { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AlertsManagementDayOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }
    public partial class DailyRecurrence : Azure.Provisioning.AlertProcessingRules.AlertProcessingRuleRecurrence
    {
        public DailyRecurrence() { }
        protected override void DefineProvisionableProperties() { }
    }
}
