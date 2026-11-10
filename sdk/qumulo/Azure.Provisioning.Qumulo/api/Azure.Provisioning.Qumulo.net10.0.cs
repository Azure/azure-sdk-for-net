namespace Azure.Provisioning.Qumulo
{
    public partial class MarketplaceDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MarketplaceDetails() { }
        public Azure.Provisioning.BicepValue<string> MarketplaceSubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OfferId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PlanId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublisherId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Qumulo.QumuloMarketplaceSubscriptionStatus> QumuloMarketplaceSubscriptionStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TermUnit { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum QumuloArmProvisioningState
    {
        Accepted = 0,
        Creating = 1,
        Updating = 2,
        Deleting = 3,
        Succeeded = 4,
        Failed = 5,
        Canceled = 6,
        Deleted = 7,
    }
    public partial class QumuloFileSystemResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public QumuloFileSystemResource(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AdminPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Qumulo.QumuloArmProvisioningState> ArmProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> AvailabilityZone { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ClusterLoginUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DelegatedSubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.Qumulo.MarketplaceDetails MarketplaceDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PerformanceTier { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.Net.IPAddress> PrivateIPs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageSkuName { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserDetailsEmail { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Qumulo.QumuloFileSystemResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_06_19;
            public static readonly string V2026_04_16;
        }
    }
    public enum QumuloMarketplaceSubscriptionStatus
    {
        PendingFulfillmentStart = 0,
        Subscribed = 1,
        Suspended = 2,
        Unsubscribed = 3,
    }
}
