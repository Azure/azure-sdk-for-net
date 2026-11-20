namespace Azure.Provisioning.StorageActions
{
    public enum OnFailureAction
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="break")]
        Break = 0,
    }
    public enum OnSuccessAction
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="continue")]
        Continue = 0,
    }
    public partial class StorageTask : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StorageTask(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.StorageActions.StorageTaskProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.StorageActions.StorageTask FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_01_01;
            public static readonly string V2026_03_01;
        }
    }
    public partial class StorageTaskAction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageTaskAction() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.StorageActions.StorageTaskOperationInfo> ElseOperations { get { throw null; } set { } }
        public Azure.Provisioning.StorageActions.StorageTaskIfCondition If { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageTaskIfCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageTaskIfCondition() { }
        public Azure.Provisioning.BicepValue<string> Condition { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.StorageActions.StorageTaskOperationInfo> Operations { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageTaskOperationInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageTaskOperationInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.StorageActions.StorageTaskOperationName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.StorageActions.OnFailureAction> OnFailure { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.StorageActions.OnSuccessAction> OnSuccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Parameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StorageTaskOperationName
    {
        SetBlobTier = 0,
        SetBlobTags = 1,
        SetBlobImmutabilityPolicy = 2,
        SetBlobLegalHold = 3,
        SetBlobExpiry = 4,
        DeleteBlob = 5,
        UndeleteBlob = 6,
    }
    public partial class StorageTaskProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageTaskProperties() { }
        public Azure.Provisioning.StorageActions.StorageTaskAction Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreationTimeInUtc { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.StorageActions.StorageTaskProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> TaskVersion { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StorageTaskProvisioningState
    {
        ValidateSubscriptionQuotaBegin = 0,
        ValidateSubscriptionQuotaEnd = 1,
        Accepted = 2,
        Creating = 3,
        Succeeded = 4,
        Deleting = 5,
        Canceled = 6,
        Failed = 7,
    }
}
