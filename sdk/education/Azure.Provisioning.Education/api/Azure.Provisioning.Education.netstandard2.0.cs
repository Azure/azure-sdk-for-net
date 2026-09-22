namespace Azure.Provisioning.Education
{
    public partial class EducationAmount : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EducationAmount() { }
        public Azure.Provisioning.BicepValue<string> Currency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EducationGrantStatus
    {
        Active = 0,
        Inactive = 1,
    }
    public enum EducationGrantType
    {
        Student = 0,
        Academic = 1,
    }
    public partial class EducationJoinRequest : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal EducationJoinRequest() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FirstName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Education.EducationLab Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Education.JoinRequestStatus> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Education.EducationJoinRequest FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_12_01_PREVIEW;
        }
    }
    public partial class EducationLab : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EducationLab(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Education.EducationAmount BudgetPerStudent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EffectiveOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiresOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InvitationCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> MaxStudentCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Education.LabStatus> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.Education.EducationAmount TotalAllocatedBudget { get { throw null; } }
        public Azure.Provisioning.Education.EducationAmount TotalBudget { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Education.EducationLab FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_12_01_PREVIEW;
        }
    }
    public partial class EducationStudent : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EducationStudent(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Education.EducationAmount Budget { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EffectiveOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiresOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FirstName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Education.StudentRole> Role { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Education.StudentLabStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionAlias { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> SubscriptionInviteLastSentOn { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Education.EducationStudent FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_12_01_PREVIEW;
        }
    }
    public partial class GrantDetails : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal GrantDetails() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Education.EducationAmount AllocatedBudget { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EffectiveOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiresOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Education.EducationAmount OfferCap { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Education.EducationGrantType> OfferType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Education.EducationGrantStatus> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Education.GrantDetails FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_12_01_PREVIEW;
        }
    }
    public enum JoinRequestStatus
    {
        Pending = 0,
        Denied = 1,
    }
    public enum LabStatus
    {
        Active = 0,
        Deleted = 1,
        Pending = 2,
    }
    public partial class StudentLabDetails : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal StudentLabDetails() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Education.EducationAmount Budget { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EffectiveOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiresOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LabScope { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Education.StudentRole> Role { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Education.StudentLabStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Education.StudentLabDetails FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_12_01_PREVIEW;
        }
    }
    public enum StudentLabStatus
    {
        Active = 0,
        Disabled = 1,
        Expired = 2,
        Pending = 3,
        Deleted = 4,
    }
    public enum StudentRole
    {
        Student = 0,
        Admin = 1,
    }
}
