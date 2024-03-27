namespace Azure.Provisioning.Authorization
{
    public static partial class AuthorizationExtensions
    {
        public static Azure.Provisioning.Authorization.RoleAssignment AssignRole(this Azure.Provisioning.Resource resource, Azure.Provisioning.Authorization.RoleDefinition roleDefinition, System.Guid? principalId = default(System.Guid?), Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?)) { throw null; }
    }
    public partial class RoleAssignment : Azure.Provisioning.Resource<Azure.ResourceManager.Authorization.RoleAssignmentData>
    {
        internal RoleAssignment() : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Authorization.RoleAssignmentData>), default(bool)) { }
        protected override string GetBicepName(Azure.Provisioning.Resource resource) { throw null; }
        protected override bool NeedsParent() { throw null; }
        protected override bool NeedsScope() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleDefinition : System.IEquatable<Azure.Provisioning.Authorization.RoleDefinition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleDefinition(string value) { throw null; }
        public static Azure.Provisioning.Authorization.RoleDefinition AppConfigurationDataOwner { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleDefinition CognitiveServicesOpenAIContributor { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleDefinition EventHubsDataOwner { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleDefinition KeyVaultAdministrator { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleDefinition SearchIndexDataContributor { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleDefinition SearchServiceContributor { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleDefinition ServiceBusDataOwner { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleDefinition SignalRAppServer { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleDefinition StorageBlobDataContributor { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleDefinition StorageQueueDataContributor { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleDefinition StorageTableDataContributor { get { throw null; } }
        public bool Equals(Azure.Provisioning.Authorization.RoleDefinition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static implicit operator Azure.Provisioning.Authorization.RoleDefinition (string value) { throw null; }
        public override string ToString() { throw null; }
    }
}
