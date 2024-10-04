namespace Azure.Provisioning
{
    public partial class BicepDictionary<T> : Azure.Provisioning.BicepValue, System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue<T>>>, System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue>>, System.Collections.Generic.IDictionary<string, Azure.Provisioning.BicepValue<T>>, System.Collections.Generic.IDictionary<string, Azure.Provisioning.BicepValue>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue<T>>>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue>>, System.Collections.IEnumerable
    {
        public BicepDictionary() { }
        public BicepDictionary(System.Collections.Generic.IDictionary<string, Azure.Provisioning.BicepValue<T>>? values) { }
        public int Count { get { throw null; } }
        public bool IsReadOnly { get { throw null; } }
        public Azure.Provisioning.BicepValue<T> this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        Azure.Provisioning.BicepValue System.Collections.Generic.IDictionary<string, Azure.Provisioning.BicepValue>.this[string key] { get { throw null; } set { } }
        System.Collections.Generic.ICollection<Azure.Provisioning.BicepValue> System.Collections.Generic.IDictionary<string, Azure.Provisioning.BicepValue>.Values { get { throw null; } }
        public System.Collections.Generic.ICollection<Azure.Provisioning.BicepValue<T>> Values { get { throw null; } }
        public void Add(System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue<T>> item) { }
        public void Add(string key, Azure.Provisioning.BicepValue<T> value) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void Assign(Azure.Provisioning.BicepDictionary<T> source) { }
        public void Clear() { }
        public bool Contains(System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue<T>> item) { throw null; }
        public bool ContainsKey(string key) { throw null; }
        public void CopyTo(System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue<T>>[] array, int arrayIndex) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Provisioning.BicepDictionary<T> DefineProperty(Azure.Provisioning.Primitives.ProvisioningConstruct construct, string propertyName, string[]? bicepPath, bool isOutput = false, bool isRequired = false) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue<T>>> GetEnumerator() { throw null; }
        public static implicit operator Azure.Provisioning.BicepDictionary<T> (Azure.Provisioning.ProvisioningVariable reference) { throw null; }
        public bool Remove(System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue<T>> item) { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue>>.Add(System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue> item) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue>>.Contains(System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue> item) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue>>.CopyTo(System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue>[] array, int arrayIndex) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue>>.Remove(System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue> item) { throw null; }
        void System.Collections.Generic.IDictionary<string, Azure.Provisioning.BicepValue>.Add(string key, Azure.Provisioning.BicepValue value) { }
        bool System.Collections.Generic.IDictionary<string, Azure.Provisioning.BicepValue>.TryGetValue(string key, out Azure.Provisioning.BicepValue value) { throw null; }
        System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue>> System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue>>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out Azure.Provisioning.BicepValue<T> value) { throw null; }
    }
    public partial class BicepList<T> : Azure.Provisioning.BicepValue, System.Collections.Generic.ICollection<Azure.Provisioning.BicepValue<T>>, System.Collections.Generic.IEnumerable<Azure.Provisioning.BicepValue<T>>, System.Collections.Generic.IList<Azure.Provisioning.BicepValue<T>>, System.Collections.IEnumerable
    {
        public BicepList() { }
        public BicepList(System.Collections.Generic.IList<Azure.Provisioning.BicepValue<T>>? values) { }
        public int Count { get { throw null; } }
        public bool IsReadOnly { get { throw null; } }
        public Azure.Provisioning.BicepValue<T> this[int index] { get { throw null; } set { } }
        public void Add(Azure.Provisioning.BicepValue<T> item) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void Assign(Azure.Provisioning.BicepList<T> source) { }
        public void Clear() { }
        public bool Contains(Azure.Provisioning.BicepValue<T> item) { throw null; }
        public void CopyTo(Azure.Provisioning.BicepValue<T>[] array, int arrayIndex) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Provisioning.BicepList<T> DefineProperty(Azure.Provisioning.Primitives.ProvisioningConstruct construct, string propertyName, string[]? bicepPath, bool isOutput = false, bool isRequired = false) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Provisioning.BicepList<T> FromExpression(System.Func<Azure.Provisioning.Expressions.Expression, T> referenceFactory, Azure.Provisioning.Expressions.Expression expression) { throw null; }
        public System.Collections.Generic.IEnumerator<Azure.Provisioning.BicepValue<T>> GetEnumerator() { throw null; }
        public int IndexOf(Azure.Provisioning.BicepValue<T> item) { throw null; }
        public void Insert(int index, Azure.Provisioning.BicepValue<T> item) { }
        public static implicit operator Azure.Provisioning.BicepList<T> (Azure.Provisioning.ProvisioningVariable reference) { throw null; }
        public bool Remove(Azure.Provisioning.BicepValue<T> item) { throw null; }
        public void RemoveAt(int index) { }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public abstract partial class BicepValue
    {
        internal BicepValue() { }
        public Azure.Provisioning.Expressions.Expression? Expression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValueKind Kind { get { throw null; } set { } }
        public Azure.Provisioning.Expressions.Expression Compile() { throw null; }
        public override string ToString() { throw null; }
    }
    public enum BicepValueKind
    {
        Unset = 0,
        Literal = 1,
        Expression = 2,
    }
    public partial class BicepValue<T> : Azure.Provisioning.BicepValue
    {
        public BicepValue(Azure.Provisioning.Expressions.Expression expression) { }
        public BicepValue(T literal) { }
        public T? Value { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void Assign(Azure.Provisioning.BicepValue<T> source) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Provisioning.BicepValue<T> DefineProperty(Azure.Provisioning.Primitives.ProvisioningConstruct construct, string propertyName, string[]? bicepPath, bool isOutput = false, bool isRequired = false, bool isSecure = false, Azure.Provisioning.BicepValue<T>? defaultValue = null) { throw null; }
        public static implicit operator Azure.Provisioning.BicepValue<System.String> (Azure.Provisioning.BicepValue<T> value) { throw null; }
        public static implicit operator Azure.Provisioning.BicepValue<T> (Azure.Provisioning.Expressions.Expression expression) { throw null; }
        public static implicit operator Azure.Provisioning.BicepValue<T> (Azure.Provisioning.ProvisioningVariable reference) { throw null; }
        public static implicit operator Azure.Provisioning.BicepValue<T> (T value) { throw null; }
    }
    public partial class Infrastructure : Azure.Provisioning.Primitives.Provisionable
    {
        public Infrastructure(string name = "main") { }
        public string Name { get { throw null; } }
        public string? TargetScope { get { throw null; } set { } }
        public virtual void Add(Azure.Provisioning.Primitives.Provisionable resource) { }
        public virtual Azure.Provisioning.ProvisioningPlan Build(Azure.Provisioning.ProvisioningContext? context = null) { throw null; }
        protected internal override System.Collections.Generic.IEnumerable<Azure.Provisioning.Expressions.Statement> Compile() { throw null; }
        protected internal System.Collections.Generic.IDictionary<string, System.Collections.Generic.IEnumerable<Azure.Provisioning.Expressions.Statement>> CompileModules(Azure.Provisioning.ProvisioningContext? context = null) { throw null; }
        public override System.Collections.Generic.IEnumerable<Azure.Provisioning.Primitives.Provisionable> GetResources() { throw null; }
        public static bool IsValidIdentifierName(string? identifierName) { throw null; }
        public static string NormalizeIdentifierName(string? identifierName) { throw null; }
        public virtual void Remove(Azure.Provisioning.Primitives.Provisionable resource) { }
        protected internal override void Resolve(Azure.Provisioning.ProvisioningContext? context = null) { }
        protected internal override void Validate(Azure.Provisioning.ProvisioningContext? context = null) { }
        public static void ValidateIdentifierName(string? identifierName) { }
    }
    public partial class ProvisioningContext
    {
        public ProvisioningContext() { }
        public System.Collections.Generic.IList<Azure.Provisioning.Primitives.InfrastructureResolver> InfrastructureResolvers { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Provisioning.Primitives.PropertyResolver> PropertyResolvers { get { throw null; } set { } }
        public System.Random Random { get { throw null; } set { } }
    }
    public partial class ProvisioningOutput : Azure.Provisioning.ProvisioningVariable
    {
        public ProvisioningOutput(string name, Azure.Provisioning.Expressions.Expression type) : base (default(string), default(Azure.Provisioning.Expressions.Expression), default(Azure.Provisioning.BicepValue<object>)) { }
        public ProvisioningOutput(string name, System.Type type) : base (default(string), default(Azure.Provisioning.Expressions.Expression), default(Azure.Provisioning.BicepValue<object>)) { }
        protected internal override System.Collections.Generic.IEnumerable<Azure.Provisioning.Expressions.Statement> Compile() { throw null; }
    }
    public partial class ProvisioningParameter : Azure.Provisioning.ProvisioningVariable
    {
        public ProvisioningParameter(string name, Azure.Provisioning.Expressions.Expression type) : base (default(string), default(Azure.Provisioning.Expressions.Expression), default(Azure.Provisioning.BicepValue<object>)) { }
        public ProvisioningParameter(string name, System.Type type) : base (default(string), default(Azure.Provisioning.Expressions.Expression), default(Azure.Provisioning.BicepValue<object>)) { }
        public bool IsSecure { get { throw null; } set { } }
        protected internal override System.Collections.Generic.IEnumerable<Azure.Provisioning.Expressions.Statement> Compile() { throw null; }
    }
    public partial class ProvisioningPlan
    {
        internal ProvisioningPlan() { }
        public Azure.Provisioning.Infrastructure Infrastructure { get { throw null; } }
        public Azure.Provisioning.ProvisioningContext ProvisioningContext { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Compile() { throw null; }
        public System.Collections.Generic.IEnumerable<string> Save(string directoryPath) { throw null; }
    }
    public partial class ProvisioningVariable : Azure.Provisioning.Primitives.NamedProvisioningConstruct
    {
        protected ProvisioningVariable(string name, Azure.Provisioning.Expressions.Expression type, Azure.Provisioning.BicepValue<object>? value) : base (default(string)) { }
        public ProvisioningVariable(string name, System.Type type) : base (default(string)) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.Expressions.Expression BicepType { get { throw null; } }
        public string? Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<object> Value { get { throw null; } set { } }
        protected internal override System.Collections.Generic.IEnumerable<Azure.Provisioning.Expressions.Statement> Compile() { throw null; }
    }
}
namespace Azure.Provisioning.Authorization
{
    public partial class AuthorizationRoleDefinition : Azure.Provisioning.Primitives.Resource
    {
        public AuthorizationRoleDefinition(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AssignableScopes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Authorization.RoleDefinitionPermission> Permissions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RoleName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.AuthorizationRoleType> RoleType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.Authorization.AuthorizationRoleDefinition FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2016_07_01;
            public static readonly string V2017_05_01;
            public static readonly string V2017_09_01;
            public static readonly string V2018_07_01;
            public static readonly string V2022_04_01;
            public static readonly string V2023_07_01_preview;
        }
    }
    public enum AuthorizationRoleType
    {
        BuiltInRole = 0,
        CustomRole = 1,
    }
    public enum NotificationDeliveryType
    {
        Email = 0,
    }
    public partial class PolicyAssignmentProperties : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public PolicyAssignmentProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipal> LastModifiedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PolicyId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RoleDefinitionDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RoleDefinitionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.AuthorizationRoleType> RoleType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ScopeDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ScopeId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementScopeType> ScopeType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
    }
    public partial class RoleAssignment : Azure.Provisioning.Primitives.Resource
    {
        public RoleAssignment(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Condition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConditionVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CreatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DelegatedManagedIdentityResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> PrincipalType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RoleDefinitionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UpdatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleAssignment FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2016_07_01;
            public static readonly string V2017_05_01;
            public static readonly string V2017_09_01;
            public static readonly string V2018_07_01;
            public static readonly string V2022_04_01;
        }
    }
    public enum RoleAssignmentEnablementRuleType
    {
        MultiFactorAuthentication = 0,
        Justification = 1,
        Ticketing = 2,
    }
    public partial class RoleAssignmentScheduleRequest : Azure.Provisioning.Primitives.Resource
    {
        public RoleAssignmentScheduleRequest(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ApprovalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Condition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConditionVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementExpandedProperties> ExpandedProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementScheduleExpirationType> ExpirationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Justification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> LinkedRoleEligibilityScheduleId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> PrincipalType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> RequestorId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementScheduleRequestType> RequestType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RoleDefinitionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementScheduleStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetRoleAssignmentScheduleId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetRoleAssignmentScheduleInstanceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleAssignmentScheduleTicketInfo> TicketInfo { get { throw null; } set { } }
        public static Azure.Provisioning.Authorization.RoleAssignmentScheduleRequest FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_10_01;
            public static readonly string V2022_04_01_preview;
        }
    }
    public partial class RoleAssignmentScheduleTicketInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public RoleAssignmentScheduleTicketInfo() { }
        public Azure.Provisioning.BicepValue<string> TicketNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TicketSystem { get { throw null; } set { } }
    }
    public partial class RoleDefinitionPermission : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public RoleDefinitionPermission() { }
        public Azure.Provisioning.BicepList<string> Actions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DataActions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NotActions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NotDataActions { get { throw null; } set { } }
    }
    public partial class RoleEligibilityScheduleRequest : Azure.Provisioning.Primitives.Resource
    {
        public RoleEligibilityScheduleRequest(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ApprovalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Condition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConditionVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementExpandedProperties> ExpandedProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementScheduleExpirationType> ExpirationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Justification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> PrincipalType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> RequestorId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementScheduleRequestType> RequestType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RoleDefinitionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementScheduleStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetRoleEligibilityScheduleId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetRoleEligibilityScheduleInstanceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleEligibilityScheduleRequestPropertiesTicketInfo> TicketInfo { get { throw null; } set { } }
        public static Azure.Provisioning.Authorization.RoleEligibilityScheduleRequest FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_10_01;
            public static readonly string V2022_04_01_preview;
        }
    }
    public partial class RoleEligibilityScheduleRequestPropertiesTicketInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public RoleEligibilityScheduleRequestPropertiesTicketInfo() { }
        public Azure.Provisioning.BicepValue<string> TicketNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TicketSystem { get { throw null; } set { } }
    }
    public enum RoleManagementApprovalMode
    {
        SingleStage = 0,
        Serial = 1,
        Parallel = 2,
        NoApproval = 3,
    }
    public partial class RoleManagementApprovalSettings : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public RoleManagementApprovalSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementApprovalMode> ApprovalMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Authorization.RoleManagementApprovalStage> ApprovalStages { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsApprovalRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsApprovalRequiredForExtension { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRequestorJustificationRequired { get { throw null; } set { } }
    }
    public partial class RoleManagementApprovalStage : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public RoleManagementApprovalStage() { }
        public Azure.Provisioning.BicepValue<int> ApprovalStageTimeOutInDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Authorization.RoleManagementUserInfo> EscalationApprovers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> EscalationTimeInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsApproverJustificationRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEscalationEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Authorization.RoleManagementUserInfo> PrimaryApprovers { get { throw null; } set { } }
    }
    public enum RoleManagementAssignmentLevel
    {
        Assignment = 0,
        Eligibility = 1,
    }
    public partial class RoleManagementExpandedProperties : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public RoleManagementExpandedProperties() { }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrincipalDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> PrincipalType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RoleDefinitionDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RoleDefinitionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.AuthorizationRoleType> RoleType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ScopeDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ScopeId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementScopeType> ScopeType { get { throw null; } }
    }
    public partial class RoleManagementPolicyApprovalRule : Azure.Provisioning.Authorization.RoleManagementPolicyRule
    {
        public RoleManagementPolicyApprovalRule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementApprovalSettings> Settings { get { throw null; } set { } }
    }
    public partial class RoleManagementPolicyAssignment : Azure.Provisioning.Primitives.Resource
    {
        public RoleManagementPolicyAssignment(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Authorization.RoleManagementPolicyRule> EffectiveRules { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.PolicyAssignmentProperties> PolicyAssignmentProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PolicyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RoleDefinitionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.Authorization.RoleManagementPolicyAssignment FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_10_01;
            public static readonly string V2020_10_01_preview;
        }
    }
    public partial class RoleManagementPolicyAuthenticationContextRule : Azure.Provisioning.Authorization.RoleManagementPolicyRule
    {
        public RoleManagementPolicyAuthenticationContextRule() { }
        public Azure.Provisioning.BicepValue<string> ClaimValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
    }
    public partial class RoleManagementPolicyEnablementRule : Azure.Provisioning.Authorization.RoleManagementPolicyRule
    {
        public RoleManagementPolicyEnablementRule() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Authorization.RoleAssignmentEnablementRuleType> EnablementRules { get { throw null; } set { } }
    }
    public partial class RoleManagementPolicyExpirationRule : Azure.Provisioning.Authorization.RoleManagementPolicyRule
    {
        public RoleManagementPolicyExpirationRule() { }
        public Azure.Provisioning.BicepValue<bool> IsExpirationRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> MaximumDuration { get { throw null; } set { } }
    }
    public enum RoleManagementPolicyNotificationLevel
    {
        None = 0,
        Critical = 1,
        All = 2,
    }
    public partial class RoleManagementPolicyNotificationRule : Azure.Provisioning.Authorization.RoleManagementPolicyRule
    {
        public RoleManagementPolicyNotificationRule() { }
        public Azure.Provisioning.BicepValue<bool> AreDefaultRecipientsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.NotificationDeliveryType> NotificationDeliveryType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPolicyNotificationLevel> NotificationLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NotificationRecipients { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPolicyRecipientType> RecipientType { get { throw null; } set { } }
    }
    public enum RoleManagementPolicyRecipientType
    {
        Requestor = 0,
        Approver = 1,
        Admin = 2,
    }
    public partial class RoleManagementPolicyRule : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public RoleManagementPolicyRule() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPolicyRuleTarget> Target { get { throw null; } set { } }
    }
    public partial class RoleManagementPolicyRuleTarget : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public RoleManagementPolicyRuleTarget() { }
        public Azure.Provisioning.BicepValue<string> Caller { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EnforcedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> InheritableSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementAssignmentLevel> Level { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Operations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> TargetObjects { get { throw null; } set { } }
    }
    public partial class RoleManagementPrincipal : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public RoleManagementPrincipal() { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> PrincipalType { get { throw null; } }
    }
    public enum RoleManagementPrincipalType
    {
        User = 0,
        Group = 1,
        ServicePrincipal = 2,
        ForeignGroup = 3,
        Device = 4,
    }
    public enum RoleManagementScheduleExpirationType
    {
        AfterDuration = 0,
        AfterDateTime = 1,
        NoExpiration = 2,
    }
    public enum RoleManagementScheduleRequestType
    {
        AdminAssign = 0,
        AdminRemove = 1,
        AdminUpdate = 2,
        AdminExtend = 3,
        AdminRenew = 4,
        SelfActivate = 5,
        SelfDeactivate = 6,
        SelfExtend = 7,
        SelfRenew = 8,
    }
    public enum RoleManagementScheduleStatus
    {
        Accepted = 0,
        PendingEvaluation = 1,
        Granted = 2,
        Denied = 3,
        PendingProvisioning = 4,
        Provisioned = 5,
        PendingRevocation = 6,
        Revoked = 7,
        Canceled = 8,
        Failed = 9,
        PendingApprovalProvisioning = 10,
        PendingApproval = 11,
        FailedAsResourceIsLocked = 12,
        PendingAdminDecision = 13,
        AdminApproved = 14,
        AdminDenied = 15,
        TimedOut = 16,
        ProvisioningStarted = 17,
        Invalid = 18,
        PendingScheduleCreation = 19,
        ScheduleCreated = 20,
        PendingExternalProvisioning = 21,
    }
    public enum RoleManagementScopeType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="subscription")]
        Subscription = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="managementgroup")]
        ManagementGroup = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="resourcegroup")]
        ResourceGroup = 2,
    }
    public partial class RoleManagementUserInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public RoleManagementUserInfo() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsBackup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementUserType> UserType { get { throw null; } set { } }
    }
    public enum RoleManagementUserType
    {
        User = 0,
        Group = 1,
    }
}
namespace Azure.Provisioning.Expressions
{
    public partial class ArrayExpression : Azure.Provisioning.Expressions.Expression
    {
        public ArrayExpression(params Azure.Provisioning.Expressions.Expression[] values) { }
        public Azure.Provisioning.Expressions.Expression[] Values { get { throw null; } }
    }
    public static partial class BicepFunction
    {
        public static Azure.Provisioning.BicepValue<string> AsString(Azure.Provisioning.BicepValue<object> value) { throw null; }
        public static Azure.Provisioning.BicepValue<string> Concat(params Azure.Provisioning.BicepValue<string>[] values) { throw null; }
        public static Azure.Provisioning.BicepValue<string> CreateGuid(params Azure.Provisioning.BicepValue<string>[] values) { throw null; }
        public static Azure.Provisioning.Resources.ArmDeployment GetDeployment() { throw null; }
        public static Azure.Provisioning.Resources.ResourceGroup GetResourceGroup() { throw null; }
        public static Azure.Provisioning.Resources.Subscription GetSubscription() { throw null; }
        public static Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> GetSubscriptionResourceId(params Azure.Provisioning.BicepValue<string>[] values) { throw null; }
        public static Azure.Provisioning.Resources.Tenant GetTenant() { throw null; }
        public static Azure.Provisioning.BicepValue<string> GetUniqueString(params Azure.Provisioning.BicepValue<string>[] values) { throw null; }
        public static Azure.Provisioning.BicepValue<string> Interpolate(System.FormattableString text) { throw null; }
        public static Azure.Provisioning.BicepValue<object> ParseJson(Azure.Provisioning.BicepValue<object> value) { throw null; }
        public static Azure.Provisioning.BicepValue<string> Take(Azure.Provisioning.BicepValue<string> text, Azure.Provisioning.BicepValue<int> size) { throw null; }
        public static Azure.Provisioning.BicepValue<string> ToLower(Azure.Provisioning.BicepValue<object> value) { throw null; }
        public static Azure.Provisioning.BicepValue<string> ToUpper(Azure.Provisioning.BicepValue<object> value) { throw null; }
    }
    public partial class BicepProgram
    {
        public BicepProgram(params Azure.Provisioning.Expressions.Statement[] body) { }
        public Azure.Provisioning.Expressions.Statement[] Body { get { throw null; } }
        public string? ModuleName { get { throw null; } set { } }
        public override string ToString() { throw null; }
    }
    public partial class BinaryExpression : Azure.Provisioning.Expressions.Expression
    {
        public BinaryExpression(Azure.Provisioning.Expressions.Expression left, Azure.Provisioning.Expressions.BinaryOperator op, Azure.Provisioning.Expressions.Expression right) { }
        public Azure.Provisioning.Expressions.Expression Left { get { throw null; } }
        public Azure.Provisioning.Expressions.BinaryOperator Operator { get { throw null; } }
        public Azure.Provisioning.Expressions.Expression Right { get { throw null; } }
    }
    public enum BinaryOperator
    {
        And = 0,
        Or = 1,
        Coalesce = 2,
        Equal = 3,
        EqualIgnoreCase = 4,
        NotEqual = 5,
        NotEqualIgnoreCase = 6,
        Greater = 7,
        GreaterOrEqual = 8,
        Less = 9,
        LessOrEqual = 10,
        Add = 11,
        Subtract = 12,
        Multiply = 13,
        Divide = 14,
        Modulo = 15,
    }
    public partial class BoolLiteral : Azure.Provisioning.Expressions.Literal
    {
        public BoolLiteral(bool value) : base (default(object)) { }
        public bool Value { get { throw null; } }
    }
    public partial class CommentStatement : Azure.Provisioning.Expressions.Statement
    {
        public CommentStatement(string comment) { }
        public string Comment { get { throw null; } }
    }
    public partial class ConditionalExpression : Azure.Provisioning.Expressions.Expression
    {
        public ConditionalExpression(Azure.Provisioning.Expressions.Expression condition, Azure.Provisioning.Expressions.Expression consequent, Azure.Provisioning.Expressions.Expression alternate) { }
        public Azure.Provisioning.Expressions.Expression Alternate { get { throw null; } }
        public Azure.Provisioning.Expressions.Expression Condition { get { throw null; } }
        public Azure.Provisioning.Expressions.Expression Consequent { get { throw null; } }
    }
    public partial class DecoratorExpression : Azure.Provisioning.Expressions.Expression
    {
        public DecoratorExpression(Azure.Provisioning.Expressions.Expression expr) { }
        public Azure.Provisioning.Expressions.Expression Expr { get { throw null; } }
    }
    public abstract partial class Expression
    {
        protected Expression() { }
        public static implicit operator Azure.Provisioning.Expressions.Expression (bool value) { throw null; }
        public static implicit operator Azure.Provisioning.Expressions.Expression (int value) { throw null; }
        public static implicit operator Azure.Provisioning.Expressions.Expression (string value) { throw null; }
        public override string ToString() { throw null; }
        internal abstract Azure.Provisioning.Expressions.BicepWriter Write(Azure.Provisioning.Expressions.BicepWriter writer);
    }
    public partial class ExprStatement : Azure.Provisioning.Expressions.Statement
    {
        public ExprStatement(Azure.Provisioning.Expressions.Expression expr) { }
        public Azure.Provisioning.Expressions.Expression Expression { get { throw null; } }
    }
    public partial class FunctionCallExpression : Azure.Provisioning.Expressions.Expression
    {
        public FunctionCallExpression(Azure.Provisioning.Expressions.Expression function, params Azure.Provisioning.Expressions.Expression[] arguments) { }
        public Azure.Provisioning.Expressions.Expression[] Arguments { get { throw null; } }
        public Azure.Provisioning.Expressions.Expression Function { get { throw null; } }
    }
    public partial class IdentifierExpression : Azure.Provisioning.Expressions.Expression
    {
        public IdentifierExpression(string name) { }
        public string Name { get { throw null; } }
    }
    public partial class IndexExpression : Azure.Provisioning.Expressions.Expression
    {
        public IndexExpression(Azure.Provisioning.Expressions.Expression value, Azure.Provisioning.Expressions.Expression index) { }
        public Azure.Provisioning.Expressions.Expression Index { get { throw null; } }
        public Azure.Provisioning.Expressions.Expression Value { get { throw null; } }
    }
    public partial class InterpolatedString : Azure.Provisioning.Expressions.Expression
    {
        public InterpolatedString(string format, Azure.Provisioning.Expressions.Expression[] values) { }
        public string Format { get { throw null; } }
        public Azure.Provisioning.Expressions.Expression[] Values { get { throw null; } }
    }
    public partial class IntLiteral : Azure.Provisioning.Expressions.Literal
    {
        public IntLiteral(int value) : base (default(object)) { }
        public int Value { get { throw null; } }
    }
    public abstract partial class Literal : Azure.Provisioning.Expressions.Expression
    {
        protected Literal(object? literalValue = null) { }
        public object? LiteralValue { get { throw null; } }
    }
    public partial class MemberExpression : Azure.Provisioning.Expressions.Expression
    {
        public MemberExpression(Azure.Provisioning.Expressions.Expression value, string member) { }
        public string Member { get { throw null; } }
        public Azure.Provisioning.Expressions.Expression Value { get { throw null; } }
    }
    public partial class ModuleStatement : Azure.Provisioning.Expressions.Statement
    {
        public ModuleStatement(string name, Azure.Provisioning.Expressions.Expression type, Azure.Provisioning.Expressions.Expression body) { }
        public Azure.Provisioning.Expressions.Expression Body { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Provisioning.Expressions.DecoratorExpression> Decorators { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Provisioning.Expressions.Expression Type { get { throw null; } }
    }
    public partial class NestedExpression : Azure.Provisioning.Expressions.Expression
    {
        public NestedExpression(Azure.Provisioning.Expressions.Expression value, string nestedMember) { }
        public string NestedMember { get { throw null; } }
        public Azure.Provisioning.Expressions.Expression Value { get { throw null; } }
    }
    public partial class NullLiteral : Azure.Provisioning.Expressions.Literal
    {
        public NullLiteral() : base (default(object)) { }
    }
    public partial class ObjectExpression : Azure.Provisioning.Expressions.Expression
    {
        public ObjectExpression(params Azure.Provisioning.Expressions.PropertyExpression[] properties) { }
        public Azure.Provisioning.Expressions.PropertyExpression[] Properties { get { throw null; } }
    }
    public partial class OutputStatement : Azure.Provisioning.Expressions.Statement
    {
        public OutputStatement(string name, Azure.Provisioning.Expressions.Expression type, Azure.Provisioning.Expressions.Expression value) { }
        public System.Collections.Generic.IList<Azure.Provisioning.Expressions.DecoratorExpression> Decorators { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Provisioning.Expressions.Expression Type { get { throw null; } }
        public Azure.Provisioning.Expressions.Expression Value { get { throw null; } }
    }
    public partial class ParameterStatement : Azure.Provisioning.Expressions.Statement
    {
        public ParameterStatement(string name, Azure.Provisioning.Expressions.Expression type, Azure.Provisioning.Expressions.Expression? defaultValue) { }
        public System.Collections.Generic.IList<Azure.Provisioning.Expressions.DecoratorExpression> Decorators { get { throw null; } }
        public Azure.Provisioning.Expressions.Expression? DefaultValue { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Provisioning.Expressions.Expression Type { get { throw null; } }
    }
    public partial class PropertyExpression : Azure.Provisioning.Expressions.Expression
    {
        public PropertyExpression(string name, Azure.Provisioning.Expressions.Expression value) { }
        public string Name { get { throw null; } }
        public Azure.Provisioning.Expressions.Expression Value { get { throw null; } }
    }
    public partial class ResourceStatement : Azure.Provisioning.Expressions.Statement
    {
        public ResourceStatement(string name, Azure.Provisioning.Expressions.Expression type, Azure.Provisioning.Expressions.Expression body) { }
        public Azure.Provisioning.Expressions.Expression Body { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Provisioning.Expressions.DecoratorExpression> Decorators { get { throw null; } }
        public bool Existing { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.Provisioning.Expressions.Expression Type { get { throw null; } }
    }
    public partial class SafeIndexExpression : Azure.Provisioning.Expressions.Expression
    {
        public SafeIndexExpression(Azure.Provisioning.Expressions.Expression value, Azure.Provisioning.Expressions.Expression index) { }
        public Azure.Provisioning.Expressions.Expression Index { get { throw null; } }
        public Azure.Provisioning.Expressions.Expression Value { get { throw null; } }
    }
    public partial class SafeMemberExpression : Azure.Provisioning.Expressions.Expression
    {
        public SafeMemberExpression(Azure.Provisioning.Expressions.Expression value, string member) { }
        public string Member { get { throw null; } }
        public Azure.Provisioning.Expressions.Expression Value { get { throw null; } }
    }
    public abstract partial class Statement
    {
        protected Statement() { }
        public override string ToString() { throw null; }
        internal abstract Azure.Provisioning.Expressions.BicepWriter Write(Azure.Provisioning.Expressions.BicepWriter writer);
    }
    public partial class StringLiteral : Azure.Provisioning.Expressions.Literal
    {
        public StringLiteral(string value) : base (default(object)) { }
        public string Value { get { throw null; } }
    }
    public partial class TargetScopeStatement : Azure.Provisioning.Expressions.Statement
    {
        public TargetScopeStatement(Azure.Provisioning.Expressions.Expression scope) { }
        public Azure.Provisioning.Expressions.Expression Scope { get { throw null; } }
    }
    public partial class TypeExpression : Azure.Provisioning.Expressions.Expression
    {
        public TypeExpression(System.Type type) { }
        public System.Type Type { get { throw null; } }
    }
    public partial class UnaryExpression : Azure.Provisioning.Expressions.Expression
    {
        public UnaryExpression(Azure.Provisioning.Expressions.UnaryOperator op, Azure.Provisioning.Expressions.Expression value) { }
        public Azure.Provisioning.Expressions.UnaryOperator Operator { get { throw null; } }
        public Azure.Provisioning.Expressions.Expression Value { get { throw null; } }
    }
    public enum UnaryOperator
    {
        Not = 0,
        Negate = 1,
        SuppressNull = 2,
    }
    public partial class VariableStatement : Azure.Provisioning.Expressions.Statement
    {
        public VariableStatement(string name, Azure.Provisioning.Expressions.Expression value) { }
        public System.Collections.Generic.IList<Azure.Provisioning.Expressions.DecoratorExpression> Decorators { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Provisioning.Expressions.Expression Value { get { throw null; } }
    }
}
namespace Azure.Provisioning.Primitives
{
    public partial class BicepLiteral : Azure.Provisioning.Primitives.NamedProvisioningConstruct
    {
        public BicepLiteral(string resourceName, params Azure.Provisioning.Expressions.Statement[] statements) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.Provisioning.Expressions.Statement> Statements { get { throw null; } }
        protected internal override System.Collections.Generic.IEnumerable<Azure.Provisioning.Expressions.Statement> Compile() { throw null; }
    }
    public partial class BicepValueReference
    {
        public BicepValueReference(Azure.Provisioning.Primitives.ProvisioningConstruct construct, string propertyName, params string[]? path) { }
        public System.Collections.Generic.IReadOnlyList<string>? BicepPath { get { throw null; } }
        public Azure.Provisioning.Primitives.ProvisioningConstruct Construct { get { throw null; } }
        public string PropertyName { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public partial class ClientCreatorOutputResolver : Azure.Provisioning.Primitives.InfrastructureResolver
    {
        public ClientCreatorOutputResolver() { }
        public override System.Collections.Generic.IEnumerable<Azure.Provisioning.Primitives.Provisionable> ResolveResources(Azure.Provisioning.ProvisioningContext context, System.Collections.Generic.IEnumerable<Azure.Provisioning.Primitives.Provisionable> resources) { throw null; }
    }
    public partial class DynamicResourceNamePropertyResolver : Azure.Provisioning.Primitives.ResourceNamePropertyResolver
    {
        public DynamicResourceNamePropertyResolver() { }
        protected virtual Azure.Provisioning.BicepValue<string> GetUniqueSuffix(Azure.Provisioning.ProvisioningContext context, Azure.Provisioning.Primitives.Resource resource) { throw null; }
        public override Azure.Provisioning.BicepValue<string>? ResolveName(Azure.Provisioning.ProvisioningContext context, Azure.Provisioning.Primitives.Resource resource, Azure.Provisioning.Primitives.ResourceNameRequirements requirements) { throw null; }
    }
    public partial interface IClientCreator
    {
        System.Collections.Generic.IEnumerable<Azure.Provisioning.ProvisioningOutput> GetOutputs();
    }
    public partial interface IClientCreator<TClient, TOptions> : Azure.Provisioning.Primitives.IClientCreator where TOptions : Azure.Core.ClientOptions
    {
        TClient CreateClient(System.Collections.Generic.IReadOnlyDictionary<string, object?> deploymentOutputs, Azure.Core.TokenCredential credential, TOptions? options = null);
    }
    public abstract partial class InfrastructureResolver
    {
        protected InfrastructureResolver() { }
        public System.Collections.Generic.IEnumerable<Azure.Provisioning.Infrastructure> GetNestedInfrastructure(Azure.Provisioning.ProvisioningContext context, Azure.Provisioning.Infrastructure infrastructure) { throw null; }
        public virtual void ResolveInfrastructure(Azure.Provisioning.ProvisioningContext context, Azure.Provisioning.Infrastructure infrastructure) { }
        public virtual System.Collections.Generic.IEnumerable<Azure.Provisioning.Primitives.Provisionable> ResolveResources(Azure.Provisioning.ProvisioningContext context, System.Collections.Generic.IEnumerable<Azure.Provisioning.Primitives.Provisionable> resources) { throw null; }
    }
    public partial class LocationPropertyResolver : Azure.Provisioning.Primitives.PropertyResolver
    {
        public LocationPropertyResolver() { }
        protected virtual Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> GetDefaultLocation(Azure.Provisioning.ProvisioningContext context, Azure.Provisioning.Primitives.ProvisioningConstruct construct) { throw null; }
        public override void ResolveProperties(Azure.Provisioning.ProvisioningContext context, Azure.Provisioning.Primitives.ProvisioningConstruct construct) { }
    }
    public partial class ModuleImport : Azure.Provisioning.Primitives.NamedProvisioningConstruct
    {
        public ModuleImport(string identifierName, Azure.Provisioning.BicepValue<string> path) : base (default(string)) { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<object> Parameters { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        protected internal override System.Collections.Generic.IEnumerable<Azure.Provisioning.Expressions.Statement> Compile() { throw null; }
        protected internal override void Validate(Azure.Provisioning.ProvisioningContext? context = null) { }
    }
    public abstract partial class NamedProvisioningConstruct : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        protected NamedProvisioningConstruct(string identifierName) { }
        public string IdentifierName { get { throw null; } set { } }
    }
    public partial class OrderingInfrastructureResolver : Azure.Provisioning.Primitives.InfrastructureResolver
    {
        public OrderingInfrastructureResolver() { }
        public override System.Collections.Generic.IEnumerable<Azure.Provisioning.Primitives.Provisionable> ResolveResources(Azure.Provisioning.ProvisioningContext context, System.Collections.Generic.IEnumerable<Azure.Provisioning.Primitives.Provisionable> resources) { throw null; }
    }
    public abstract partial class PropertyResolver
    {
        protected PropertyResolver() { }
        public abstract void ResolveProperties(Azure.Provisioning.ProvisioningContext context, Azure.Provisioning.Primitives.ProvisioningConstruct construct);
    }
    public abstract partial class Provisionable
    {
        internal Provisionable() { }
        protected internal abstract System.Collections.Generic.IEnumerable<Azure.Provisioning.Expressions.Statement> Compile();
        public virtual System.Collections.Generic.IEnumerable<Azure.Provisioning.Primitives.Provisionable> GetResources() { throw null; }
        protected internal virtual void Resolve(Azure.Provisioning.ProvisioningContext? context = null) { }
        protected internal virtual void Validate(Azure.Provisioning.ProvisioningContext? context = null) { }
    }
    public abstract partial class ProvisioningConstruct : Azure.Provisioning.Primitives.Provisionable
    {
        protected ProvisioningConstruct() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.Infrastructure? ParentInfrastructure { get { throw null; } }
        protected internal override System.Collections.Generic.IEnumerable<Azure.Provisioning.Expressions.Statement> Compile() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override System.Collections.Generic.IEnumerable<Azure.Provisioning.Primitives.Provisionable> GetResources() { throw null; }
        protected internal void OverrideWithExpression(Azure.Provisioning.Expressions.Expression reference) { }
        protected internal override void Resolve(Azure.Provisioning.ProvisioningContext? context = null) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void SetProvisioningProperty(Azure.Provisioning.BicepValue property, Azure.Provisioning.BicepValue value) { }
        protected internal override void Validate(Azure.Provisioning.ProvisioningContext? context = null) { }
    }
    public abstract partial class Resource : Azure.Provisioning.Primitives.NamedProvisioningConstruct
    {
        protected Resource(string resourceName, Azure.Core.ResourceType resourceType, string? resourceVersion = null) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.Provisioning.Primitives.Resource> DependsOn { get { throw null; } }
        public bool IsExistingResource { get { throw null; } protected set { } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
        public string? ResourceVersion { get { throw null; } set { } }
        public virtual Azure.Provisioning.ProvisioningPlan Build(Azure.Provisioning.ProvisioningContext? context = null) { throw null; }
        protected internal override System.Collections.Generic.IEnumerable<Azure.Provisioning.Expressions.Statement> Compile() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        protected internal override void Validate(Azure.Provisioning.ProvisioningContext? context = null) { }
    }
    [System.FlagsAttribute]
    public enum ResourceNameCharacters
    {
        LowercaseLetters = 1,
        UppercaseLetters = 2,
        Letters = 3,
        Numbers = 4,
        Alphanumeric = 7,
        Hyphen = 8,
        Underscore = 16,
        Period = 32,
        Parentheses = 64,
    }
    public abstract partial class ResourceNamePropertyResolver : Azure.Provisioning.Primitives.PropertyResolver
    {
        protected ResourceNamePropertyResolver() { }
        public abstract Azure.Provisioning.BicepValue<string>? ResolveName(Azure.Provisioning.ProvisioningContext context, Azure.Provisioning.Primitives.Resource resource, Azure.Provisioning.Primitives.ResourceNameRequirements requirements);
        public override void ResolveProperties(Azure.Provisioning.ProvisioningContext context, Azure.Provisioning.Primitives.ProvisioningConstruct construct) { }
        protected static string SanitizeText(string text, Azure.Provisioning.Primitives.ResourceNameCharacters validCharacters) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceNameRequirements
    {
        private readonly int _dummyPrimitive;
        public ResourceNameRequirements(int minLength, int maxLength, Azure.Provisioning.Primitives.ResourceNameCharacters validCharacters) { throw null; }
        public int MaxLength { get { throw null; } }
        public int MinLength { get { throw null; } }
        public Azure.Provisioning.Primitives.ResourceNameCharacters ValidCharacters { get { throw null; } }
    }
    public partial class ResourceReference<T> where T : Azure.Provisioning.Primitives.Resource
    {
        public ResourceReference(Azure.Provisioning.BicepValue<string> reference) { }
        public T? Value { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Provisioning.Primitives.ResourceReference<T> DefineResource(Azure.Provisioning.Primitives.Resource construct, string propertyName, string[]? bicepPath, bool isOutput = false, bool isRequired = false, T? defaultValue = null) { throw null; }
    }
    public partial class StaticResourceNamePropertyResolver : Azure.Provisioning.Primitives.ResourceNamePropertyResolver
    {
        public StaticResourceNamePropertyResolver() { }
        public override Azure.Provisioning.BicepValue<string>? ResolveName(Azure.Provisioning.ProvisioningContext context, Azure.Provisioning.Primitives.Resource resource, Azure.Provisioning.Primitives.ResourceNameRequirements requirements) { throw null; }
    }
}
namespace Azure.Provisioning.Resources
{
    public partial class ApiProfile : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ApiProfile() { }
        public Azure.Provisioning.BicepValue<string> ApiVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProfileVersion { get { throw null; } }
    }
    public partial class ArmApplication : Azure.Provisioning.Primitives.Resource
    {
        public ArmApplication(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ApplicationDefinitionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ArmApplicationArtifact> Artifacts { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ArmApplicationAuthorization> Authorizations { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingDetailsResourceUsageId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationDetails> CreatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationPackageContact> CustomerSupport { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationManagedIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationJitAccessPolicy> JitAccessPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedResourceGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationManagementMode> ManagementMode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Outputs { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmPlan> Plan { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourcesProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> PublisherTenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationSku> Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationPackageSupportUris> SupportUris { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationDetails> UpdatedBy { get { throw null; } }
        public static Azure.Provisioning.Resources.ArmApplication FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_09_01;
            public static readonly string V2017_12_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2021_07_01;
        }
    }
    public partial class ArmApplicationArtifact : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmApplicationArtifact() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationArtifactType> ArtifactType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationArtifactName> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } }
    }
    public enum ArmApplicationArtifactName
    {
        NotSpecified = 0,
        ViewDefinition = 1,
        Authorizations = 2,
        CustomRoleDefinition = 3,
    }
    public enum ArmApplicationArtifactType
    {
        NotSpecified = 0,
        Template = 1,
        Custom = 2,
    }
    public partial class ArmApplicationAuthorization : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmApplicationAuthorization() { }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RoleDefinitionId { get { throw null; } set { } }
    }
    public partial class ArmApplicationDefinition : Azure.Provisioning.Primitives.Resource
    {
        public ArmApplicationDefinition(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ArmApplicationDefinitionArtifact> Artifacts { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ArmApplicationAuthorization> Authorizations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> CreateUiDefinition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationPackageLockingPolicy> LockingPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationLockLevel> LockLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> MainTemplate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationManagementMode> ManagementMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ArmApplicationNotificationEndpoint> NotificationEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> PackageFileUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ArmApplicationPolicy> Policies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationSku> Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.Resources.ArmApplicationDefinition FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_09_01;
            public static readonly string V2017_12_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2021_07_01;
        }
    }
    public partial class ArmApplicationDefinitionArtifact : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmApplicationDefinitionArtifact() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationArtifactType> ArtifactType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationDefinitionArtifactName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
    }
    public enum ArmApplicationDefinitionArtifactName
    {
        NotSpecified = 0,
        ApplicationResourceTemplate = 1,
        CreateUiDefinition = 2,
        MainTemplateParameters = 3,
    }
    public enum ArmApplicationDeploymentMode
    {
        NotSpecified = 0,
        Incremental = 1,
        Complete = 2,
    }
    public partial class ArmApplicationDetails : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmApplicationDetails() { }
        public Azure.Provisioning.BicepValue<System.Guid> ApplicationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ObjectId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Puid { get { throw null; } }
    }
    public partial class ArmApplicationJitAccessPolicy : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmApplicationJitAccessPolicy() { }
        public Azure.Provisioning.BicepValue<bool> JitAccessEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.JitApprovalMode> JitApprovalMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.JitApprover> JitApprovers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> MaximumJitAccessDuration { get { throw null; } set { } }
    }
    public enum ArmApplicationLockLevel
    {
        None = 0,
        CanNotDelete = 1,
        ReadOnly = 2,
    }
    public partial class ArmApplicationManagedIdentity : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmApplicationManagedIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationManagedIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.ArmApplicationUserAssignedIdentity> UserAssignedIdentities { get { throw null; } set { } }
    }
    public enum ArmApplicationManagedIdentityType
    {
        None = 0,
        SystemAssigned = 1,
        UserAssigned = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SystemAssigned, UserAssigned")]
        SystemAssignedUserAssigned = 3,
    }
    public enum ArmApplicationManagementMode
    {
        NotSpecified = 0,
        Unmanaged = 1,
        Managed = 2,
    }
    public partial class ArmApplicationNotificationEndpoint : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmApplicationNotificationEndpoint() { }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
    }
    public partial class ArmApplicationPackageContact : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmApplicationPackageContact() { }
        public Azure.Provisioning.BicepValue<string> ContactName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Phone { get { throw null; } }
    }
    public partial class ArmApplicationPackageLockingPolicy : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmApplicationPackageLockingPolicy() { }
        public Azure.Provisioning.BicepList<string> AllowedActions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AllowedDataActions { get { throw null; } set { } }
    }
    public partial class ArmApplicationPackageSupportUris : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmApplicationPackageSupportUris() { }
        public Azure.Provisioning.BicepValue<System.Uri> AzureGovernmentUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> AzurePublicCloudUri { get { throw null; } }
    }
    public partial class ArmApplicationPolicy : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmApplicationPolicy() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicyDefinitionId { get { throw null; } set { } }
    }
    public partial class ArmApplicationSku : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmApplicationSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Model { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tier { get { throw null; } set { } }
    }
    public partial class ArmApplicationUserAssignedIdentity : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmApplicationUserAssignedIdentity() { }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArmBuiltInRole : System.IEquatable<Azure.Provisioning.Resources.ArmBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArmBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.Resources.ArmBuiltInRole Contributor { get { throw null; } }
        public static Azure.Provisioning.Resources.ArmBuiltInRole ManagedIdentityContributor { get { throw null; } }
        public static Azure.Provisioning.Resources.ArmBuiltInRole ManagedIdentityOperator { get { throw null; } }
        public static Azure.Provisioning.Resources.ArmBuiltInRole Owner { get { throw null; } }
        public static Azure.Provisioning.Resources.ArmBuiltInRole Reader { get { throw null; } }
        public static Azure.Provisioning.Resources.ArmBuiltInRole RoleBasedAccessControlAdministrator { get { throw null; } }
        public static Azure.Provisioning.Resources.ArmBuiltInRole UserAccessAdministrator { get { throw null; } }
        public bool Equals(Azure.Provisioning.Resources.ArmBuiltInRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string GetBuiltInRoleName(Azure.Provisioning.Resources.ArmBuiltInRole value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.Resources.ArmBuiltInRole left, Azure.Provisioning.Resources.ArmBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.Resources.ArmBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.Resources.ArmBuiltInRole left, Azure.Provisioning.Resources.ArmBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArmDependency : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmDependency() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.BasicArmDependency> DependsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResourceName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
    }
    public partial class ArmDeployment : Azure.Provisioning.Primitives.Resource
    {
        public ArmDeployment(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmDeploymentPropertiesExtended> Properties { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        public static Azure.Provisioning.Resources.ArmDeployment FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Provisioning.Resources.ArmDeployment FromExpression(Azure.Provisioning.Expressions.Expression expression) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_01_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_02_01;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_05_01;
            public static readonly string V2017_05_10;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_09_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_03_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_05_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_10_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_04_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_07_01;
        }
    }
    public partial class ArmDeploymentContent : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmDeploymentContent() { }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmDeploymentProperties> Properties { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
    }
    public enum ArmDeploymentMode
    {
        Incremental = 0,
        Complete = 1,
    }
    public partial class ArmDeploymentParametersLink : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmDeploymentParametersLink() { }
        public Azure.Provisioning.BicepValue<string> ContentVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
    }
    public partial class ArmDeploymentProperties : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmDeploymentProperties() { }
        public Azure.Provisioning.BicepValue<string> DebugSettingDetailLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ErrorDeployment> ErrorDeployment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ExpressionEvaluationScope> ExpressionEvaluationScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmDeploymentMode> Mode { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmDeploymentParametersLink> ParametersLink { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Template { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmDeploymentTemplateLink> TemplateLink { get { throw null; } set { } }
    }
    public partial class ArmDeploymentPropertiesExtended : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmDeploymentPropertiesExtended() { }
        public Azure.Provisioning.BicepValue<string> CorrelationId { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ArmDependency> Dependencies { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ResponseError> Error { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ErrorDeploymentExtended> ErrorDeployment { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmDeploymentMode> Mode { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> OutputResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Outputs { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Parameters { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmDeploymentParametersLink> ParametersLink { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ResourceProviderData> Providers { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourcesProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TemplateHash { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmDeploymentTemplateLink> TemplateLink { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Timestamp { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> ValidatedResources { get { throw null; } }
    }
    public partial class ArmDeploymentScript : Azure.Provisioning.Primitives.Resource
    {
        public ArmDeploymentScript(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmDeploymentScriptManagedIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.Resources.ArmDeploymentScript FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_10_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class ArmDeploymentScriptManagedIdentity : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmDeploymentScriptManagedIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmDeploymentScriptManagedIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.UserAssignedIdentityDetails> UserAssignedIdentities { get { throw null; } set { } }
    }
    public enum ArmDeploymentScriptManagedIdentityType
    {
        UserAssigned = 0,
    }
    public partial class ArmDeploymentTemplateLink : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmDeploymentTemplateLink() { }
        public Azure.Provisioning.BicepValue<string> ContentVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QueryString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RelativePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
    }
    public partial class ArmDeploymentWhatIfProperties : Azure.Provisioning.Resources.ArmDeploymentProperties
    {
        public ArmDeploymentWhatIfProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.WhatIfResultFormat> WhatIfResultFormat { get { throw null; } set { } }
    }
    public partial class ArmPlan : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmPlan() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Product { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PromotionCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
    }
    public partial class ArmPolicyParameter : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmPolicyParameter() { }
        public Azure.Provisioning.BicepList<System.BinaryData> AllowedValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> DefaultValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ParameterDefinitionsValueMetadata> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmPolicyParameterType> ParameterType { get { throw null; } set { } }
    }
    public enum ArmPolicyParameterType
    {
        String = 0,
        Array = 1,
        Object = 2,
        Boolean = 3,
        Integer = 4,
        Float = 5,
        DateTime = 6,
    }
    public partial class ArmPolicyParameterValue : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ArmPolicyParameterValue() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Value { get { throw null; } set { } }
    }
    public partial class BasicArmDependency : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public BasicArmDependency() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResourceName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
    }
    public enum CreatedByType
    {
        User = 0,
        Application = 1,
        ManagedIdentity = 2,
        Key = 3,
    }
    public partial class CreateManagementGroupDetails : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CreateManagementGroupDetails() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagementGroupParentCreateOptions> Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UpdatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Version { get { throw null; } }
    }
    public enum EnforcementMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Default")]
        Enforced = 0,
        Default = 1,
        DoNotEnforce = 2,
    }
    public partial class ErrorDeployment : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ErrorDeployment() { }
        public Azure.Provisioning.BicepValue<string> DeploymentName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ErrorDeploymentType> DeploymentType { get { throw null; } set { } }
    }
    public partial class ErrorDeploymentExtended : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ErrorDeploymentExtended() { }
        public Azure.Provisioning.BicepValue<string> DeploymentName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ErrorDeploymentType> DeploymentType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
    }
    public enum ErrorDeploymentType
    {
        LastSuccessful = 0,
        SpecificDeployment = 1,
    }
    public enum ExpressionEvaluationScope
    {
        NotSpecified = 0,
        Outer = 1,
        Inner = 2,
    }
    public partial class ExtendedAzureLocation : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ExtendedAzureLocation() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ExtendedLocationType> ExtendedLocationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
    }
    public enum ExtendedLocationType
    {
        EdgeZone = 0,
    }
    public partial class GenericResource : Azure.Provisioning.Primitives.Resource
    {
        public GenericResource(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ChangedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ExtendedAzureLocation> ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmPlan> Plan { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourcesSku> Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.Resources.GenericResource FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
    }
    public enum JitApprovalMode
    {
        NotSpecified = 0,
        AutoApprove = 1,
        ManualApprove = 2,
    }
    public partial class JitApprover : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public JitApprover() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.JitApproverType> ApproverType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
    }
    public enum JitApproverType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="user")]
        User = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="group")]
        Group = 1,
    }
    public partial class JitAuthorizationPolicies : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public JitAuthorizationPolicies() { }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RoleDefinitionId { get { throw null; } set { } }
    }
    public partial class JitRequest : Azure.Provisioning.Primitives.Resource
    {
        public JitRequest(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ApplicationResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationDetails> CreatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.JitAuthorizationPolicies> JitAuthorizationPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.JitRequestState> JitRequestState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.JitSchedulingPolicy> JitSchedulingPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourcesProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> PublisherTenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationDetails> UpdatedBy { get { throw null; } }
        public static Azure.Provisioning.Resources.JitRequest FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_07_01;
            public static readonly string V2021_07_01;
        }
    }
    public enum JitRequestState
    {
        NotSpecified = 0,
        Pending = 1,
        Approved = 2,
        Denied = 3,
        Failed = 4,
        Canceled = 5,
        Expired = 6,
        Timeout = 7,
    }
    public partial class JitSchedulingPolicy : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public JitSchedulingPolicy() { }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.JitSchedulingType> SchedulingType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
    }
    public enum JitSchedulingType
    {
        NotSpecified = 0,
        Once = 1,
        Recurring = 2,
    }
    public partial class LinkedTemplateArtifact : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public LinkedTemplateArtifact() { }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Template { get { throw null; } set { } }
    }
    public partial class ManagedByTenant : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ManagedByTenant() { }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
    }
    public partial class ManagedServiceIdentity : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ManagedServiceIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentityType> ManagedServiceIdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.UserAssignedIdentityDetails> UserAssignedIdentities { get { throw null; } set { } }
    }
    public enum ManagedServiceIdentityType
    {
        None = 0,
        SystemAssigned = 1,
        UserAssigned = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SystemAssigned, UserAssigned")]
        SystemAssignedUserAssigned = 3,
    }
    public partial class ManagementGroup : Azure.Provisioning.Primitives.Resource
    {
        public ManagementGroup(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ManagementGroupChildOptions> Children { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.CreateManagementGroupDetails> Details { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        public static Azure.Provisioning.Resources.ManagementGroup FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_03_01_beta;
            public static readonly string V2019_11_01;
            public static readonly string V2020_02_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_10_01;
            public static readonly string V2021_04_01;
            public static readonly string V2023_04_01;
        }
    }
    public partial class ManagementGroupChildInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ManagementGroupChildInfo() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ManagementGroupChildInfo> Children { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagementGroupChildType> ChildType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
    }
    public partial class ManagementGroupChildOptions : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ManagementGroupChildOptions() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ManagementGroupChildOptions> Children { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagementGroupChildType> ChildType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
    }
    public enum ManagementGroupChildType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.Management/managementGroups")]
        MicrosoftManagementManagementGroups = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="/subscriptions")]
        Subscriptions = 1,
    }
    public partial class ManagementGroupInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ManagementGroupInfo() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ManagementGroupPathElement> ManagementGroupAncestorChain { get { throw null; } }
        public Azure.Provisioning.BicepList<string> ManagementGroupAncestors { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ParentManagementGroupInfo> Parent { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ManagementGroupPathElement> Path { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UpdatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Version { get { throw null; } }
    }
    public partial class ManagementGroupParentCreateOptions : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ManagementGroupParentCreateOptions() { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
    }
    public partial class ManagementGroupPathElement : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ManagementGroupPathElement() { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
    }
    public partial class ManagementGroupPolicyDefinition : Azure.Provisioning.Primitives.Resource
    {
        public ManagementGroupPolicyDefinition(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.ArmPolicyParameter> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> PolicyRule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.PolicyType> PolicyType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.Resources.ManagementGroupPolicyDefinition FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_04_01;
            public static readonly string V2016_12_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_05_01;
            public static readonly string V2019_01_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_09_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_09_01;
            public static readonly string V2021_06_01;
            public static readonly string V2023_04_01;
        }
    }
    public partial class ManagementGroupPolicySetDefinition : Azure.Provisioning.Primitives.Resource
    {
        public ManagementGroupPolicySetDefinition(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.ArmPolicyParameter> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.PolicyDefinitionGroup> PolicyDefinitionGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.PolicyDefinitionReference> PolicyDefinitions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.PolicyType> PolicyType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.Resources.ManagementGroupPolicySetDefinition FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_03_01;
            public static readonly string V2018_05_01;
            public static readonly string V2019_01_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_09_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_09_01;
            public static readonly string V2021_06_01;
            public static readonly string V2023_04_01;
        }
    }
    public partial class ManagementGroupSubscription : Azure.Provisioning.Primitives.Resource
    {
        public ManagementGroupSubscription(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Resources.ManagementGroup? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ParentId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> State { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } }
        public static Azure.Provisioning.Resources.ManagementGroupSubscription FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_03_01_beta;
            public static readonly string V2019_11_01;
            public static readonly string V2020_02_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_10_01;
            public static readonly string V2021_04_01;
            public static readonly string V2023_04_01;
        }
    }
    public partial class ManagementLock : Azure.Provisioning.Primitives.Resource
    {
        public ManagementLock(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagementLockLevel> Level { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Notes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ManagementLockOwner> Owners { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.Resources.ManagementLock FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_01_01;
            public static readonly string V2015_06_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_04_01;
            public static readonly string V2020_05_01;
        }
    }
    public enum ManagementLockLevel
    {
        NotSpecified = 0,
        CanNotDelete = 1,
        ReadOnly = 2,
    }
    public partial class ManagementLockOwner : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ManagementLockOwner() { }
        public Azure.Provisioning.BicepValue<string> ApplicationId { get { throw null; } set { } }
    }
    public partial class NonComplianceMessage : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public NonComplianceMessage() { }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicyDefinitionReferenceId { get { throw null; } set { } }
    }
    public partial class ParameterDefinitionsValueMetadata : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ParameterDefinitionsValueMetadata() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AssignPermissions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StrongType { get { throw null; } set { } }
    }
    public partial class ParentManagementGroupInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ParentManagementGroupInfo() { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
    }
    public partial class PolicyAssignment : Azure.Provisioning.Primitives.Resource
    {
        public PolicyAssignment(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.EnforcementMode> EnforcementMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ExcludedScopes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> ManagedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.NonComplianceMessage> NonComplianceMessages { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.PolicyOverride> Overrides { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.ArmPolicyParameterValue> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicyDefinitionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ResourceSelector> ResourceSelectors { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.Resources.PolicyAssignment FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_04_01;
            public static readonly string V2016_12_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_05_01;
            public static readonly string V2019_01_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_09_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_09_01;
            public static readonly string V2021_06_01;
            public static readonly string V2022_06_01;
            public static readonly string V2023_04_01;
            public static readonly string V2024_04_01;
        }
    }
    public partial class PolicyDefinitionGroup : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public PolicyDefinitionGroup() { }
        public Azure.Provisioning.BicepValue<string> AdditionalMetadataId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Category { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
    }
    public partial class PolicyDefinitionReference : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public PolicyDefinitionReference() { }
        public Azure.Provisioning.BicepList<string> GroupNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.ArmPolicyParameterValue> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicyDefinitionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicyDefinitionReferenceId { get { throw null; } set { } }
    }
    public partial class PolicyOverride : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public PolicyOverride() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.PolicyOverrideKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ResourceSelectorExpression> Selectors { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
    }
    public enum PolicyOverrideKind
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="policyEffect")]
        PolicyEffect = 0,
    }
    public enum PolicyType
    {
        NotSpecified = 0,
        BuiltIn = 1,
        Custom = 2,
        Static = 3,
    }
    public enum ProviderAuthorizationConsentState
    {
        NotSpecified = 0,
        Required = 1,
        NotRequired = 2,
        Consented = 3,
    }
    public partial class ProviderExtendedLocation : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ProviderExtendedLocation() { }
        public Azure.Provisioning.BicepList<string> ExtendedLocations { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProviderExtendedLocationType { get { throw null; } }
    }
    public partial class ProviderResourceType : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ProviderResourceType() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ResourceTypeAlias> Aliases { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ApiProfile> ApiProfiles { get { throw null; } }
        public Azure.Provisioning.BicepList<string> ApiVersions { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Capabilities { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DefaultApiVersion { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ProviderExtendedLocation> LocationMappings { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Locations { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ZoneMapping> ZoneMappings { get { throw null; } }
    }
    public partial class ResourceGroup : Azure.Provisioning.Primitives.Resource
    {
        public ResourceGroup(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroupProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.Resources.ResourceGroup FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Provisioning.Resources.ResourceGroup FromExpression(Azure.Provisioning.Expressions.Expression expression) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_01_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_02_01;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_05_01;
            public static readonly string V2017_05_10;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_09_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_03_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_05_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_10_01;
            public static readonly string V2019_11_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_04_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_06_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_07_01;
            public static readonly string V2023_07_01_preview;
        }
    }
    public partial class ResourceProviderData : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ResourceProviderData() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Namespace { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ProviderAuthorizationConsentState> ProviderAuthorizationConsentState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RegistrationPolicy { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RegistrationState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ProviderResourceType> ResourceTypes { get { throw null; } }
    }
    public partial class ResourceSelector : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ResourceSelector() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ResourceSelectorExpression> Selectors { get { throw null; } set { } }
    }
    public partial class ResourceSelectorExpression : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ResourceSelectorExpression() { }
        public Azure.Provisioning.BicepList<string> In { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourceSelectorKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NotIn { get { throw null; } set { } }
    }
    public enum ResourceSelectorKind
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="resourceLocation")]
        ResourceLocation = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="resourceType")]
        ResourceType = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="resourceWithoutLocation")]
        ResourceWithoutLocation = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="policyDefinitionReferenceId")]
        PolicyDefinitionReferenceId = 3,
    }
    public enum ResourcesProvisioningState
    {
        NotSpecified = 0,
        Accepted = 1,
        Running = 2,
        Ready = 3,
        Creating = 4,
        Created = 5,
        Deleting = 6,
        Deleted = 7,
        Canceled = 8,
        Failed = 9,
        Succeeded = 10,
        Updating = 11,
    }
    public partial class ResourcesSku : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ResourcesSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Model { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tier { get { throw null; } set { } }
    }
    public partial class ResourceTypeAlias : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ResourceTypeAlias() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourceTypeAliasType> AliasType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourceTypeAliasPathMetadata> DefaultMetadata { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DefaultPath { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourceTypeAliasPattern> DefaultPattern { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ResourceTypeAliasPath> Paths { get { throw null; } }
    }
    public partial class ResourceTypeAliasPath : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ResourceTypeAliasPath() { }
        public Azure.Provisioning.BicepList<string> ApiVersions { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourceTypeAliasPathMetadata> Metadata { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourceTypeAliasPattern> Pattern { get { throw null; } }
    }
    public enum ResourceTypeAliasPathAttributes
    {
        None = 0,
        Modifiable = 1,
    }
    public partial class ResourceTypeAliasPathMetadata : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ResourceTypeAliasPathMetadata() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourceTypeAliasPathAttributes> Attributes { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourceTypeAliasPathTokenType> TokenType { get { throw null; } }
    }
    public enum ResourceTypeAliasPathTokenType
    {
        NotSpecified = 0,
        Any = 1,
        String = 2,
        Object = 3,
        Array = 4,
        Integer = 5,
        Number = 6,
        Boolean = 7,
    }
    public partial class ResourceTypeAliasPattern : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ResourceTypeAliasPattern() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourceTypeAliasPatternType> PatternType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Phrase { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Variable { get { throw null; } }
    }
    public enum ResourceTypeAliasPatternType
    {
        NotSpecified = 0,
        Extract = 1,
    }
    public enum ResourceTypeAliasType
    {
        NotSpecified = 0,
        PlainText = 1,
        Mask = 2,
    }
    public enum SpendingLimit
    {
        On = 0,
        Off = 1,
        CurrentPeriodOff = 2,
    }
    public partial class SubResource : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public SubResource() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
    }
    public partial class Subscription : Azure.Provisioning.Primitives.Resource
    {
        public Subscription(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AuthorizationSource { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ManagedByTenant> ManagedByTenants { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SubscriptionState> State { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SubscriptionPolicies> SubscriptionPolicies { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Provisioning.Resources.Subscription FromExpression(Azure.Provisioning.Expressions.Expression expression) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_01_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_02_01;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_05_01;
            public static readonly string V2017_05_10;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_09_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_03_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_05_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_10_01;
        }
    }
    public partial class SubscriptionPolicies : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public SubscriptionPolicies() { }
        public Azure.Provisioning.BicepValue<string> LocationPlacementId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> QuotaId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SpendingLimit> SpendingLimit { get { throw null; } }
    }
    public partial class SubscriptionPolicyDefinition : Azure.Provisioning.Primitives.Resource
    {
        public SubscriptionPolicyDefinition(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.ArmPolicyParameter> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> PolicyRule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.PolicyType> PolicyType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.Resources.SubscriptionPolicyDefinition FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
    }
    public partial class SubscriptionPolicySetDefinition : Azure.Provisioning.Primitives.Resource
    {
        public SubscriptionPolicySetDefinition(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.ArmPolicyParameter> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.PolicyDefinitionGroup> PolicyDefinitionGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.PolicyDefinitionReference> PolicyDefinitions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.PolicyType> PolicyType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.Resources.SubscriptionPolicySetDefinition FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
    }
    public enum SubscriptionState
    {
        Enabled = 0,
        Warned = 1,
        PastDue = 2,
        Disabled = 3,
        Deleted = 4,
    }
    public partial class SystemAssignedServiceIdentity : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public SystemAssignedServiceIdentity() { }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemAssignedServiceIdentityType> SystemAssignedServiceIdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
    }
    public enum SystemAssignedServiceIdentityType
    {
        None = 0,
        SystemAssigned = 1,
    }
    public partial class SystemData : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public SystemData() { }
        public Azure.Provisioning.BicepValue<string> CreatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.CreatedByType> CreatedByType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastModifiedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.CreatedByType> LastModifiedByType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
    }
    public partial class TagResource : Azure.Provisioning.Primitives.Resource
    {
        public TagResource(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> TagValues { get { throw null; } set { } }
        public static Azure.Provisioning.Resources.TagResource FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_11_01;
            public static readonly string V2019_03_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_05_01;
            public static readonly string V2019_10_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_07_01;
        }
    }
    public partial class TemplateSpec : Azure.Provisioning.Primitives.Resource
    {
        public TemplateSpec(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.TemplateSpecVersionInfo> Versions { get { throw null; } }
        public static Azure.Provisioning.Resources.TemplateSpec FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_05_01;
            public static readonly string V2022_02_01;
        }
    }
    public partial class TemplateSpecVersion : Azure.Provisioning.Primitives.Resource
    {
        public TemplateSpecVersion(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.LinkedTemplateArtifact> LinkedTemplates { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> MainTemplate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Resources.TemplateSpec? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> UiFormDefinition { get { throw null; } set { } }
        public static Azure.Provisioning.Resources.TemplateSpecVersion FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_05_01;
            public static readonly string V2022_02_01;
        }
    }
    public partial class TemplateSpecVersionInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public TemplateSpecVersionInfo() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TimeCreated { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TimeModified { get { throw null; } }
    }
    public partial class Tenant : Azure.Provisioning.Primitives.Resource
    {
        public Tenant(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Country { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CountryCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DefaultDomain { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Domains { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> TenantBrandingLogoUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.TenantCategory> TenantCategory { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TenantType { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Provisioning.Resources.Tenant FromExpression(Azure.Provisioning.Expressions.Expression expression) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_01_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_02_01;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_05_01;
            public static readonly string V2017_05_10;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_09_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_03_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_05_01;
            public static readonly string V2019_09_01;
            public static readonly string V2020_01_01;
        }
    }
    public enum TenantCategory
    {
        Home = 0,
        ProjectedBy = 1,
        ManagedBy = 2,
    }
    public partial class UserAssignedIdentityDetails : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public UserAssignedIdentityDetails() { }
        public Azure.Provisioning.BicepValue<System.Guid> ClientId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } }
    }
    public enum WhatIfResultFormat
    {
        ResourceIdOnly = 0,
        FullResourcePayloads = 1,
    }
    public partial class WritableSubResource : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public WritableSubResource() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
    }
    public partial class ZoneMapping : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ZoneMapping() { }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } }
    }
}
namespace Azure.Provisioning.Roles
{
    public partial class FederatedIdentityCredential : Azure.Provisioning.Primitives.Resource
    {
        public FederatedIdentityCredential(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> Audiences { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> IssuerUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Roles.UserAssignedIdentity? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Subject { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.Roles.FederatedIdentityCredential FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_01_31_PREVIEW;
            public static readonly string V2023_01_31;
            public static readonly string V2023_07_31_PREVIEW;
        }
    }
    public partial class UserAssignedIdentity : Azure.Provisioning.Primitives.Resource
    {
        public UserAssignedIdentity(string identifierName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Guid> ClientId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        public static Azure.Provisioning.Roles.UserAssignedIdentity FromExisting(string identifierName, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_08_31_PREVIEW;
            public static readonly string V2018_11_30;
            public static readonly string V2021_09_30_PREVIEW;
            public static readonly string V2022_01_31_PREVIEW;
            public static readonly string V2023_01_31;
            public static readonly string V2023_07_31_PREVIEW;
        }
    }
}
