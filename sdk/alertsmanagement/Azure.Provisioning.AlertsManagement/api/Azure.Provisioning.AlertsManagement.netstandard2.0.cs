namespace Azure.Provisioning.AlertsManagement
{
    public enum MonitorCondition
    {
        Fired = 0,
        Resolved = 1,
    }
    public enum MonitorServiceSourceForAlert
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Application Insights")]
        ApplicationInsights = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ActivityLog Administrative")]
        ActivityLogAdministrative = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ActivityLog Security")]
        ActivityLogSecurity = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ActivityLog Recommendation")]
        ActivityLogRecommendation = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ActivityLog Policy")]
        ActivityLogPolicy = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ActivityLog Autoscale")]
        ActivityLogAutoscale = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Log Analytics")]
        LogAnalytics = 6,
        Nagios = 7,
        Platform = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SCOM")]
        Scom = 9,
        ServiceHealth = 10,
        SmartDetector = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="VM Insights")]
        VmInsights = 12,
        Zabbix = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Resource Health")]
        ResourceHealth = 14,
    }
    public partial class ServiceAlert : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal ServiceAlert() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AlertsManagement.ServiceAlertProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AlertsManagement.ServiceAlert FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_25_PREVIEW;
        }
    }
    public partial class ServiceAlertEssentials : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAlertEssentials() { }
        public Azure.Provisioning.BicepValue<bool> ActionStatusIsSuppressed { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> AlertRule { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AlertsManagement.ServiceAlertState> AlertState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastModifiedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AlertsManagement.MonitorCondition> MonitorCondition { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> MonitorConditionResolvedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AlertsManagement.MonitorServiceSourceForAlert> MonitorService { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AlertsManagement.ServiceAlertSeverity> Severity { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AlertsManagement.ServiceAlertSignalType> SignalType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> SmartGroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SmartGroupingReason { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SourceCreatedId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TargetResource { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TargetResourceGroup { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TargetResourceName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TargetResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceAlertProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAlertProperties() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Context { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> CustomProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> EgressConfig { get { throw null; } }
        public Azure.Provisioning.AlertsManagement.ServiceAlertEssentials Essentials { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceAlertSeverity
    {
        Sev0 = 0,
        Sev1 = 1,
        Sev2 = 2,
        Sev3 = 3,
        Sev4 = 4,
    }
    public enum ServiceAlertSignalType
    {
        Metric = 0,
        Log = 1,
        Unknown = 2,
    }
    public enum ServiceAlertState
    {
        New = 0,
        Acknowledged = 1,
        Closed = 2,
    }
}
