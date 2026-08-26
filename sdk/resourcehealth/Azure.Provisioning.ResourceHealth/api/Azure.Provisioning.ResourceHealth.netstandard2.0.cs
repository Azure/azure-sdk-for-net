namespace Azure.Provisioning.ResourceHealth
{
    public partial class EmergingIssueActiveEventType : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EmergingIssueActiveEventType() { }
        public Azure.Provisioning.BicepValue<string> Cloud { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ResourceHealth.EmergingIssueImpact> Impacts { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsPublished { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ResourceHealth.ResourceHealthEventSeverityLevel> Severity { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ResourceHealth.ResourceHealthEventStageValue> Stage { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TrackingId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EmergingIssueBannerType : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EmergingIssueBannerType() { }
        public Azure.Provisioning.BicepValue<string> Cloud { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EmergingIssueImpact : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EmergingIssueImpact() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ResourceHealth.EmergingIssueImpactedRegion> Regions { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EmergingIssueImpactedRegion : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EmergingIssueImpactedRegion() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EventSubTypeValue
    {
        Retirement = 0,
        ForeignExchangeRateChange = 1,
        Underbilling = 2,
        Overbilling = 3,
        PriceChanges = 4,
        TaxChanges = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MeterIDChanges")]
        MeterIdChanges = 6,
        UnauthorizedPartyAbuse = 7,
    }
    public enum MetadataEntityScenario
    {
        Alerts = 0,
    }
    public partial class MetadataSupportedValueDetail : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MetadataSupportedValueDetail() { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PreviousId { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceType> ResourceTypes { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ServiceGuid { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResourceHealthEvent : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal ResourceHealthEvent() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AdditionalInformationMessage { get { throw null; } }
        public Azure.Provisioning.ResourceHealth.ResourceHealthEventArticle Article { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CurrencyType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Duration { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ResourceHealth.ResourceHealthEventLevelValue> EventLevel { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ResourceHealth.ResourceHealthEventSourceValue> EventSource { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ResourceHealth.EventSubTypeValue> EventSubType { get { throw null; } }
        public Azure.Provisioning.BicepList<string> EventTags { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ResourceHealth.ResourceHealthEventTypeValue> EventType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ExternalIncidentId { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ResourceHealth.ResourceHealthEventFaq> Faqs { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Header { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> HirStage { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ResourceHealth.ResourceHealthEventImpact> Impact { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ImpactMitigationOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ImpactStartOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ImpactType { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsChatWithUsEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEventSensitive { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsHirEvent { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsMicrosoftSupportEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsPlatformInitiated { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdateOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ResourceHealth.ResourceHealthEventInsightLevelValue> Level { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ResourceHealth.ResourceHealthEventLink> Links { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> NewRate { get { throw null; } }
        public Azure.Provisioning.BicepValue<double> OldRate { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Reason { get { throw null; } }
        public Azure.Provisioning.ResourceHealth.ResourceHealthEventRecommendedActions RecommendedActions { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ResourceHealth.ResourceHealthEventStatusValue> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Summary { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ResourceHealth.ResourceHealthEvent FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class ResourceHealthEventArticle : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceHealthEventArticle() { }
        public Azure.Provisioning.BicepValue<string> ArticleContent { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ArticleId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Parameters { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResourceHealthEventFaq : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceHealthEventFaq() { }
        public Azure.Provisioning.BicepValue<string> Answer { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LocaleCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Question { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResourceHealthEventImpact : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceHealthEventImpact() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ResourceHealth.ResourceHealthEventImpactedServiceRegion> ImpactedRegions { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ImpactedService { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ImpactedServiceGuid { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResourceHealthEventImpactedResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal ResourceHealthEventImpactedResource() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ResourceHealth.ResourceHealthKeyValueItem> Info { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ResourceHealth.ResourceHealthEvent Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TargetRegion { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> TargetResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ResourceHealth.ResourceHealthEventImpactedResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class ResourceHealthEventImpactedServiceRegion : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceHealthEventImpactedServiceRegion() { }
        public Azure.Provisioning.BicepValue<string> ImpactedRegion { get { throw null; } }
        public Azure.Provisioning.BicepList<string> ImpactedSubscriptions { get { throw null; } }
        public Azure.Provisioning.BicepList<string> ImpactedTenants { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdateOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ResourceHealth.ResourceHealthEventStatusValue> Status { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ResourceHealth.ResourceHealthEventUpdate> Updates { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ResourceHealthEventInsightLevelValue
    {
        Critical = 0,
        Warning = 1,
    }
    public enum ResourceHealthEventLevelValue
    {
        Critical = 0,
        Error = 1,
        Warning = 2,
        Informational = 3,
    }
    public partial class ResourceHealthEventLink : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceHealthEventLink() { }
        public Azure.Provisioning.BicepValue<string> BladeName { get { throw null; } }
        public Azure.Provisioning.ResourceHealth.ResourceHealthEventLinkDisplayText DisplayText { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ExtensionName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ResourceHealth.ResourceHealthEventLinkTypeValue> LinkType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Parameters { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResourceHealthEventLinkDisplayText : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceHealthEventLinkDisplayText() { }
        public Azure.Provisioning.BicepValue<string> LocalizedValue { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ResourceHealthEventLinkTypeValue
    {
        Button = 0,
        Hyperlink = 1,
    }
    public partial class ResourceHealthEventRecommendedActions : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceHealthEventRecommendedActions() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ResourceHealth.ResourceHealthEventRecommendedActionsItem> Actions { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LocaleCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResourceHealthEventRecommendedActionsItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceHealthEventRecommendedActionsItem() { }
        public Azure.Provisioning.BicepValue<string> ActionText { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> GroupId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ResourceHealthEventSeverityLevel
    {
        Information = 0,
        Warning = 1,
        Error = 2,
    }
    public enum ResourceHealthEventSourceValue
    {
        ResourceHealth = 0,
        ServiceHealth = 1,
    }
    public enum ResourceHealthEventStageValue
    {
        Active = 0,
        Resolve = 1,
        Archived = 2,
    }
    public enum ResourceHealthEventStatusValue
    {
        Active = 0,
        Resolved = 1,
    }
    public enum ResourceHealthEventTypeValue
    {
        ServiceIssue = 0,
        PlannedMaintenance = 1,
        HealthAdvisory = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="RCA")]
        Rca = 3,
        EmergingIssues = 4,
        SecurityAdvisory = 5,
        Billing = 6,
    }
    public partial class ResourceHealthEventUpdate : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceHealthEventUpdate() { }
        public Azure.Provisioning.BicepList<string> EventTags { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Summary { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResourceHealthKeyValueItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceHealthKeyValueItem() { }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResourceHealthMetadataEntity : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal ResourceHealthMetadataEntity() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ResourceHealth.MetadataEntityScenario> ApplicableScenarios { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> MetadataDependencies { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ResourceHealth.MetadataSupportedValueDetail> SupportedValues { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ResourceHealth.ResourceHealthMetadataEntity FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class ServiceEmergingIssue : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal ServiceEmergingIssue() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RefreshedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ResourceHealth.EmergingIssueActiveEventType> StatusActiveEvents { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ResourceHealth.EmergingIssueBannerType> StatusBanners { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ResourceHealth.ServiceEmergingIssue FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
}
