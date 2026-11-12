namespace Azure.Provisioning.SiteManager
{
    public partial class EdgeSite : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EdgeSite(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SiteManager.EdgeSiteProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SiteManager.EdgeSite FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
        }
    }
    public partial class EdgeSiteAddressProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EdgeSiteAddressProperties() { }
        public Azure.Provisioning.BicepValue<string> City { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Country { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PostalCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StateOrProvince { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StreetAddress1 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StreetAddress2 { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EdgeSiteProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EdgeSiteProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Labels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SiteManager.EdgeSiteProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.SiteManager.EdgeSiteAddressProperties SiteAddress { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EdgeSiteProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
    }
}
