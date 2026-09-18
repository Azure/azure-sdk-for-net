namespace Azure.Provisioning.Quota
{
    public partial class CurrentQuotaLimitBase : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CurrentQuotaLimitBase(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Quota.QuotaProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Quota.CurrentQuotaLimitBase FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_09_01;
        }
    }
    public partial class CurrentUsagesBase : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal CurrentUsagesBase() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Quota.QuotaUsagesProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Quota.CurrentUsagesBase FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_09_01;
        }
    }
    public enum EnforcementState
    {
        Enabled = 0,
        Disabled = 1,
        NotAvailable = 2,
    }
    public partial class GroupQuotaDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GroupQuotaDetails() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Quota.SubscriptionAllocatedQuota> AllocatedToSubscriptionsValue { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> AvailableLimit { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Comment { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> Limit { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LocalizedValue { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResourceName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Unit { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GroupQuotaEntity : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public GroupQuotaEntity(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Quota.GroupQuotasEntityProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Quota.GroupQuotaEntity FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_09_01;
        }
    }
    public partial class GroupQuotaEntityBase : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GroupQuotaEntityBase() { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Quota.GroupType> GroupType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Quota.QuotaRequestStatus> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GroupQuotaLimit : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GroupQuotaLimit() { }
        public Azure.Provisioning.Quota.GroupQuotaLimitProperties Properties { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GroupQuotaLimitList : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal GroupQuotaLimitList() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Quota.GroupQuotaLimitListProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Quota.GroupQuotaLimitList FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_09_01;
        }
    }
    public partial class GroupQuotaLimitListProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GroupQuotaLimitListProperties() { }
        public Azure.Provisioning.BicepValue<string> NextLink { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Quota.QuotaRequestStatus> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Quota.GroupQuotaLimit> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GroupQuotaLimitProperties : Azure.Provisioning.Quota.GroupQuotaDetails
    {
        public GroupQuotaLimitProperties() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GroupQuotaRequestBase : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GroupQuotaRequestBase() { }
        public Azure.Provisioning.BicepValue<string> Comments { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> Limit { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LocalizedValue { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Region { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GroupQuotaRequestStatus : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal GroupQuotaRequestStatus() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Quota.GroupQuotaEntity Parent { get { throw null; } set { } }
        public Azure.Provisioning.Quota.GroupQuotaRequestStatusProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Quota.GroupQuotaRequestStatus FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_09_01;
        }
    }
    public partial class GroupQuotaRequestStatusProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GroupQuotaRequestStatusProperties() { }
        public Azure.Provisioning.BicepValue<string> FaultCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Quota.QuotaRequestStatus> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Quota.GroupQuotaRequestBase RequestedResource { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RequestSubmittedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GroupQuotasEnforcementStatus : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public GroupQuotasEnforcementStatus(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Quota.GroupQuotasEnforcementStatusProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Quota.GroupQuotasEnforcementStatus FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_09_01;
        }
    }
    public partial class GroupQuotasEnforcementStatusProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GroupQuotasEnforcementStatusProperties() { }
        public Azure.Provisioning.BicepValue<string> EnforcedGroupName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Quota.EnforcementState> EnforcementEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FaultCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Quota.QuotaRequestStatus> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GroupQuotasEntityProperties : Azure.Provisioning.Quota.GroupQuotaEntityBase
    {
        public GroupQuotasEntityProperties() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GroupQuotaSubscription : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public GroupQuotaSubscription(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Quota.GroupQuotaEntity Parent { get { throw null; } set { } }
        public Azure.Provisioning.Quota.GroupQuotaSubscriptionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Quota.GroupQuotaSubscription FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_09_01;
        }
    }
    public partial class GroupQuotaSubscriptionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GroupQuotaSubscriptionProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Quota.QuotaRequestStatus> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GroupQuotaSubscriptionRequestStatus : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal GroupQuotaSubscriptionRequestStatus() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Quota.GroupQuotaEntity Parent { get { throw null; } set { } }
        public Azure.Provisioning.Quota.GroupQuotaSubscriptionRequestStatusProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Quota.GroupQuotaSubscriptionRequestStatus FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_09_01;
        }
    }
    public partial class GroupQuotaSubscriptionRequestStatusProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GroupQuotaSubscriptionRequestStatusProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Quota.QuotaRequestStatus> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RequestSubmitOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GroupType
    {
        AllocationGroup = 0,
        EnforcedGroup = 1,
    }
    public partial class QuotaAllocationRequestBase : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public QuotaAllocationRequestBase() { }
        public Azure.Provisioning.BicepValue<long> Limit { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LocalizedValue { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Region { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class QuotaAllocationRequestStatus : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal QuotaAllocationRequestStatus() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> FaultCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Quota.QuotaRequestStatus> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Quota.QuotaAllocationRequestBase RequestedResource { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RequestSubmittedOn { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Quota.QuotaAllocationRequestStatus FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_09_01;
        }
    }
    public partial class QuotaLimitJsonObject : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public QuotaLimitJsonObject() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class QuotaLimitObject : Azure.Provisioning.Quota.QuotaLimitJsonObject
    {
        public QuotaLimitObject() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Quota.QuotaLimitType> LimitType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum QuotaLimitType
    {
        Independent = 0,
        Shared = 1,
    }
    public partial class QuotaProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public QuotaProperties() { }
        public Azure.Provisioning.BicepValue<bool> IsQuotaApplicable { get { throw null; } }
        public Azure.Provisioning.Quota.QuotaLimitJsonObject Limit { get { throw null; } set { } }
        public Azure.Provisioning.Quota.QuotaRequestResourceName Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> QuotaPeriod { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResourceTypeName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Unit { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class QuotaRequestDetail : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal QuotaRequestDetail() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Quota.ServiceErrorDetail Error { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Quota.QuotaRequestState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RequestSubmitOn { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Quota.QuotaSubRequestDetail> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Quota.QuotaRequestDetail FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_09_01;
        }
    }
    public partial class QuotaRequestResourceName : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public QuotaRequestResourceName() { }
        public Azure.Provisioning.BicepValue<string> LocalizedValue { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum QuotaRequestState
    {
        Accepted = 0,
        Invalid = 1,
        Succeeded = 2,
        Failed = 3,
        InProgress = 4,
    }
    public enum QuotaRequestStatus
    {
        Accepted = 0,
        Created = 1,
        Invalid = 2,
        Succeeded = 3,
        Escalated = 4,
        Failed = 5,
        InProgress = 6,
        Canceled = 7,
    }
    public partial class QuotaSubRequestDetail : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public QuotaSubRequestDetail() { }
        public Azure.Provisioning.Quota.QuotaLimitJsonObject Limit { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.Quota.QuotaRequestResourceName Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Quota.QuotaRequestState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResourceTypeName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> SubRequestId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Unit { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class QuotaUsagesObject : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public QuotaUsagesObject() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Quota.QuotaUsagesType> UsagesType { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class QuotaUsagesProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public QuotaUsagesProperties() { }
        public Azure.Provisioning.BicepValue<bool> IsQuotaApplicable { get { throw null; } }
        public Azure.Provisioning.Quota.QuotaRequestResourceName Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Properties { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> QuotaPeriod { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResourceTypeName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Unit { get { throw null; } }
        public Azure.Provisioning.Quota.QuotaUsagesObject Usages { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum QuotaUsagesType
    {
        Individual = 0,
        Combined = 1,
    }
    public partial class ServiceErrorDetail : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceErrorDetail() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SubscriptionAllocatedQuota : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SubscriptionAllocatedQuota() { }
        public Azure.Provisioning.BicepValue<long> QuotaAllocated { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SubscriptionQuotaAllocations : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SubscriptionQuotaAllocations() { }
        public Azure.Provisioning.Quota.SubscriptionQuotaAllocationsProperties Properties { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SubscriptionQuotaAllocationsList : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SubscriptionQuotaAllocationsList() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Quota.SubscriptionQuotaAllocationsListProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Quota.SubscriptionQuotaAllocationsList FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_09_01;
        }
    }
    public partial class SubscriptionQuotaAllocationsListProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SubscriptionQuotaAllocationsListProperties() { }
        public Azure.Provisioning.BicepValue<string> NextLink { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Quota.QuotaRequestStatus> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Quota.SubscriptionQuotaAllocations> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SubscriptionQuotaAllocationsProperties : Azure.Provisioning.Quota.SubscriptionQuotaDetails
    {
        public SubscriptionQuotaAllocationsProperties() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SubscriptionQuotaDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SubscriptionQuotaDetails() { }
        public Azure.Provisioning.BicepValue<long> Limit { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LocalizedValue { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResourceName { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> ShareableQuota { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
}
