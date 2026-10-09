namespace Azure.Provisioning.Subscription
{
    public enum AcceptOwnershipState
    {
        Pending = 0,
        Completed = 1,
        Expired = 2,
    }
    public partial class BillingAccountPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BillingAccountPolicy() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Subscription.BillingAccountPolicyProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Subscription.BillingAccountPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_11_01_PREVIEW;
        }
    }
    public partial class BillingAccountPolicyProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BillingAccountPolicyProperties() { }
        public Azure.Provisioning.BicepValue<bool> AllowTransfers { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Subscription.ServiceTenant> ServiceTenants { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ChangeDirectoryOperationStatus
    {
        Initialized = 0,
        InProgress = 1,
        Completed = 2,
    }
    public partial class ServiceTenant : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceTenant() { }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TenantName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SubscriptionAlias : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SubscriptionAlias(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Subscription.SubscriptionAliasProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Subscription.SubscriptionAlias FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_11_01_PREVIEW;
        }
    }
    public partial class SubscriptionAliasProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SubscriptionAliasProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Subscription.AcceptOwnershipState> AcceptOwnershipState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> AcceptOwnershipUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagementGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Subscription.SubscriptionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResellerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionOwnerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Subscription.SubscriptionWorkload> Workload { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SubscriptionProvisioningState
    {
        Accepted = 0,
        Succeeded = 1,
        Failed = 2,
    }
    public enum SubscriptionWorkload
    {
        Production = 0,
        DevTest = 1,
    }
    public partial class TargetDirectoryResult : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TargetDirectoryResult(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Subscription.TargetDirectoryResultProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Subscription.TargetDirectoryResult FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_11_01_PREVIEW;
        }
    }
    public partial class TargetDirectoryResultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TargetDirectoryResultProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> AcceptedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> DestinationOwnerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> DestinationTenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiresOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SourceOwnerEmail { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> SourceOwnerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> SourceTenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Subscription.ChangeDirectoryOperationStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TenantPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TenantPolicy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Subscription.TenantPolicyProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Subscription.TenantPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_11_01_PREVIEW;
        }
    }
    public partial class TenantPolicyProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TenantPolicyProperties() { }
        public Azure.Provisioning.BicepValue<bool> BlockSubscriptionsIntoTenant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> BlockSubscriptionsLeavingTenant { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.Guid> ExemptedPrincipals { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicyId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
}
