namespace Azure.Provisioning
{
    public partial class BicepDictionary<T> : Azure.Provisioning.BicepValue, System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue<T>>>, System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.IBicepValue>>, System.Collections.Generic.IDictionary<string, Azure.Provisioning.BicepValue<T>>, System.Collections.Generic.IDictionary<string, Azure.Provisioning.IBicepValue>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue<T>>>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.IBicepValue>>, System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue<T>>>, System.Collections.Generic.IReadOnlyDictionary<string, Azure.Provisioning.BicepValue<T>>, System.Collections.IEnumerable
    {
        public BicepDictionary() { }
        public BicepDictionary(System.Collections.Generic.IDictionary<string, Azure.Provisioning.BicepValue<T>>? values) { }
        public int Count { get { throw null; } }
        public override bool IsEmpty { get { throw null; } }
        public bool IsReadOnly { get { throw null; } }
        public Azure.Provisioning.BicepValue<T> this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        Azure.Provisioning.IBicepValue System.Collections.Generic.IDictionary<string, Azure.Provisioning.IBicepValue>.this[string key] { get { throw null; } set { } }
        System.Collections.Generic.ICollection<Azure.Provisioning.IBicepValue> System.Collections.Generic.IDictionary<string, Azure.Provisioning.IBicepValue>.Values { get { throw null; } }
        System.Collections.Generic.IEnumerable<string> System.Collections.Generic.IReadOnlyDictionary<string, Azure.Provisioning.BicepValue<T>>.Keys { get { throw null; } }
        System.Collections.Generic.IEnumerable<Azure.Provisioning.BicepValue<T>> System.Collections.Generic.IReadOnlyDictionary<string, Azure.Provisioning.BicepValue<T>>.Values { get { throw null; } }
        public System.Collections.Generic.ICollection<Azure.Provisioning.BicepValue<T>> Values { get { throw null; } }
        public void Add(System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue<T>> item) { }
        public void Add(string key, Azure.Provisioning.BicepValue<T> value) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void Assign(Azure.Provisioning.BicepDictionary<T> source) { }
        public void Clear() { }
        public bool Contains(System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue<T>> item) { throw null; }
        public bool ContainsKey(string key) { throw null; }
        public void CopyTo(System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue<T>>[] array, int arrayIndex) { }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue<T>>> GetEnumerator() { throw null; }
        public static implicit operator Azure.Provisioning.BicepDictionary<T> (Azure.Provisioning.ProvisioningVariable reference) { throw null; }
        public bool Remove(System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.BicepValue<T>> item) { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.IBicepValue>>.Add(System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.IBicepValue> item) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.IBicepValue>>.Contains(System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.IBicepValue> item) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.IBicepValue>>.CopyTo(System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.IBicepValue>[] array, int arrayIndex) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.IBicepValue>>.Remove(System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.IBicepValue> item) { throw null; }
        void System.Collections.Generic.IDictionary<string, Azure.Provisioning.IBicepValue>.Add(string key, Azure.Provisioning.IBicepValue value) { }
        bool System.Collections.Generic.IDictionary<string, Azure.Provisioning.IBicepValue>.TryGetValue(string key, out Azure.Provisioning.IBicepValue value) { throw null; }
        System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.IBicepValue>> System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, Azure.Provisioning.IBicepValue>>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out Azure.Provisioning.BicepValue<T> value) { throw null; }
    }
    public partial class BicepList<T> : Azure.Provisioning.BicepValue, System.Collections.Generic.ICollection<Azure.Provisioning.BicepValue<T>>, System.Collections.Generic.IEnumerable<Azure.Provisioning.BicepValue<T>>, System.Collections.Generic.IList<Azure.Provisioning.BicepValue<T>>, System.Collections.Generic.IReadOnlyCollection<Azure.Provisioning.BicepValue<T>>, System.Collections.Generic.IReadOnlyList<Azure.Provisioning.BicepValue<T>>, System.Collections.IEnumerable
    {
        public BicepList() { }
        public BicepList(System.Collections.Generic.IList<Azure.Provisioning.BicepValue<T>>? values) { }
        public int Count { get { throw null; } }
        public override bool IsEmpty { get { throw null; } }
        public bool IsReadOnly { get { throw null; } }
        public Azure.Provisioning.BicepValue<T> this[int index] { get { throw null; } set { } }
        public void Add(Azure.Provisioning.BicepValue<T> item) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void Assign(Azure.Provisioning.BicepList<T> source) { }
        public void Clear() { }
        public bool Contains(Azure.Provisioning.BicepValue<T> item) { throw null; }
        public void CopyTo(Azure.Provisioning.BicepValue<T>[] array, int arrayIndex) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Provisioning.BicepList<T> FromExpression(System.Func<Azure.Provisioning.Expressions.BicepExpression, T> referenceFactory, Azure.Provisioning.Expressions.BicepExpression expression) { throw null; }
        public System.Collections.Generic.IEnumerator<Azure.Provisioning.BicepValue<T>> GetEnumerator() { throw null; }
        public int IndexOf(Azure.Provisioning.BicepValue<T> item) { throw null; }
        public void Insert(int index, Azure.Provisioning.BicepValue<T> item) { }
        public static implicit operator Azure.Provisioning.BicepList<T> (Azure.Provisioning.ProvisioningVariable reference) { throw null; }
        public bool Remove(Azure.Provisioning.BicepValue<T> item) { throw null; }
        public void RemoveAt(int index) { }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public abstract partial class BicepValue : Azure.Provisioning.IBicepValue
    {
        internal BicepValue() { }
        Azure.Provisioning.Expressions.BicepExpression? Azure.Provisioning.IBicepValue.Expression { get { throw null; } set { } }
        bool Azure.Provisioning.IBicepValue.IsOutput { get { throw null; } }
        bool Azure.Provisioning.IBicepValue.IsRequired { get { throw null; } }
        bool Azure.Provisioning.IBicepValue.IsSecure { get { throw null; } }
        Azure.Provisioning.BicepValueKind Azure.Provisioning.IBicepValue.Kind { get { throw null; } }
        object? Azure.Provisioning.IBicepValue.LiteralValue { get { throw null; } }
        Azure.Provisioning.Primitives.BicepValueReference? Azure.Provisioning.IBicepValue.Self { get { throw null; } set { } }
        Azure.Provisioning.Primitives.BicepValueReference? Azure.Provisioning.IBicepValue.Source { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual bool IsEmpty { get { throw null; } }
        void Azure.Provisioning.IBicepValue.Assign(Azure.Provisioning.IBicepValue source) { }
        void Azure.Provisioning.IBicepValue.SetReadOnly() { }
        public Azure.Provisioning.Expressions.BicepExpression Compile() { throw null; }
        public static explicit operator Azure.Provisioning.Expressions.BicepExpression (Azure.Provisioning.BicepValue value) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class BicepValueExtensions
    {
        public static T Unwrap<T>(this Azure.Provisioning.BicepValue<T> value) where T : Azure.Provisioning.Primitives.ProvisionableConstruct, new() { throw null; }
    }
    public enum BicepValueKind
    {
        Unset = 0,
        Literal = 1,
        Expression = 2,
    }
    public partial class BicepValue<T> : Azure.Provisioning.BicepValue
    {
        public BicepValue(Azure.Provisioning.Expressions.BicepExpression expression) { }
        public BicepValue(T literal) { }
        public T? Value { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void Assign(Azure.Provisioning.BicepValue<T> source) { }
        public void ClearValue() { }
        public static implicit operator Azure.Provisioning.BicepValue<System.String> (Azure.Provisioning.BicepValue<T> value) { throw null; }
        public static implicit operator Azure.Provisioning.BicepValue<T> (Azure.Provisioning.Expressions.BicepExpression? expression) { throw null; }
        public static implicit operator Azure.Provisioning.BicepValue<T> (Azure.Provisioning.ProvisioningVariable reference) { throw null; }
        public static implicit operator Azure.Provisioning.BicepValue<T> (T value) { throw null; }
    }
    public partial interface IBicepValue
    {
        Azure.Provisioning.Expressions.BicepExpression? Expression { get; set; }
        bool IsEmpty { get; }
        bool IsOutput { get; }
        bool IsRequired { get; }
        bool IsSecure { get; }
        Azure.Provisioning.BicepValueKind Kind { get; }
        object? LiteralValue { get; }
        Azure.Provisioning.Primitives.BicepValueReference? Self { get; set; }
        Azure.Provisioning.Primitives.BicepValueReference? Source { get; }
        void Assign(Azure.Provisioning.IBicepValue source);
        Azure.Provisioning.Expressions.BicepExpression Compile();
        void SetReadOnly();
    }
    public partial class Infrastructure : Azure.Provisioning.Primitives.Provisionable
    {
        public Infrastructure(string bicepName = "main") { }
        public string BicepName { get { throw null; } }
        public Azure.Provisioning.Primitives.DeploymentScope? TargetScope { get { throw null; } set { } }
        public virtual void Add(Azure.Provisioning.Primitives.Provisionable resource) { }
        public virtual Azure.Provisioning.ProvisioningPlan Build(Azure.Provisioning.ProvisioningBuildOptions? options = null) { throw null; }
        protected internal override System.Collections.Generic.IEnumerable<Azure.Provisioning.Expressions.BicepStatement> Compile() { throw null; }
        protected internal System.Collections.Generic.IDictionary<string, System.Collections.Generic.IEnumerable<Azure.Provisioning.Expressions.BicepStatement>> CompileModules(Azure.Provisioning.ProvisioningBuildOptions? options = null) { throw null; }
        public override System.Collections.Generic.IEnumerable<Azure.Provisioning.Primitives.Provisionable> GetProvisionableResources() { throw null; }
        public static bool IsValidBicepIdentifier(string? bicepIdentifier) { throw null; }
        public static string NormalizeBicepIdentifier(string? bicepIdentifier) { throw null; }
        public virtual void Remove(Azure.Provisioning.Primitives.Provisionable resource) { }
        protected internal override void Resolve(Azure.Provisioning.ProvisioningBuildOptions? options = null) { }
        protected internal override void Validate(Azure.Provisioning.ProvisioningBuildOptions? options = null) { }
        public static void ValidateBicepIdentifier(string? bicepIdentifier, string? paramName = null) { }
    }
    public partial class ProvisioningBuildOptions
    {
        public ProvisioningBuildOptions() { }
        public System.Collections.Generic.IList<Azure.Provisioning.Primitives.InfrastructureResolver> InfrastructureResolvers { get { throw null; } }
        public System.Random Random { get { throw null; } set { } }
    }
    public partial class ProvisioningOutput : Azure.Provisioning.ProvisioningVariable
    {
        public ProvisioningOutput(string bicepIdentifier, Azure.Provisioning.Expressions.BicepExpression type) : base (default(string), default(Azure.Provisioning.Expressions.BicepExpression), default(Azure.Provisioning.BicepValue<object>)) { }
        public ProvisioningOutput(string bicepIdentifier, System.Type type) : base (default(string), default(Azure.Provisioning.Expressions.BicepExpression), default(Azure.Provisioning.BicepValue<object>)) { }
        protected internal override System.Collections.Generic.IEnumerable<Azure.Provisioning.Expressions.BicepStatement> Compile() { throw null; }
    }
    public partial class ProvisioningParameter : Azure.Provisioning.ProvisioningVariable
    {
        public ProvisioningParameter(string bicepIdentifier, Azure.Provisioning.Expressions.BicepExpression type) : base (default(string), default(Azure.Provisioning.Expressions.BicepExpression), default(Azure.Provisioning.BicepValue<object>)) { }
        public ProvisioningParameter(string bicepIdentifier, System.Type type) : base (default(string), default(Azure.Provisioning.Expressions.BicepExpression), default(Azure.Provisioning.BicepValue<object>)) { }
        public bool IsSecure { get { throw null; } set { } }
        protected internal override System.Collections.Generic.IEnumerable<Azure.Provisioning.Expressions.BicepStatement> Compile() { throw null; }
    }
    public partial class ProvisioningPlan
    {
        internal ProvisioningPlan() { }
        public Azure.Provisioning.ProvisioningBuildOptions BuildOptions { get { throw null; } }
        public Azure.Provisioning.Infrastructure Infrastructure { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Compile() { throw null; }
        public System.Collections.Generic.IEnumerable<string> Save(string directoryPath) { throw null; }
    }
    public partial class ProvisioningVariable : Azure.Provisioning.Primitives.NamedProvisionableConstruct
    {
        protected ProvisioningVariable(string bicepIdentifier, Azure.Provisioning.Expressions.BicepExpression type, Azure.Provisioning.BicepValue<object>? value) : base (default(string)) { }
        public ProvisioningVariable(string bicepIdentifier, System.Type type) : base (default(string)) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.Expressions.BicepExpression BicepType { get { throw null; } }
        public string? Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<object> Value { get { throw null; } set { } }
        protected internal override System.Collections.Generic.IEnumerable<Azure.Provisioning.Expressions.BicepStatement> Compile() { throw null; }
    }
}
namespace Azure.Provisioning.Authorization
{
    public partial class AuthorizationRoleDefinition : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AuthorizationRoleDefinition(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AssignableScopes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Authorization.RoleDefinitionPermission> Permissions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RoleName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.AuthorizationRoleType> RoleType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Authorization.AuthorizationRoleDefinition FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
    public enum AuthorizationRoleType
    {
        BuiltInRole = 0,
        CustomRole = 1,
    }
    public enum NotificationDeliveryType
    {
        Email = 0,
    }
    public partial class PolicyAssignmentProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PolicyAssignmentProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Authorization.RoleManagementPrincipal LastModifiedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PolicyId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RoleDefinitionDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RoleDefinitionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.AuthorizationRoleType> RoleType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ScopeDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ScopeId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementScopeType> ScopeType { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoleAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RoleAssignment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
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
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UpdatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Authorization.RoleAssignment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
    public partial class RoleAssignmentScheduleRequest : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RoleAssignmentScheduleRequest(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ApprovalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Condition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConditionVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleManagementExpandedProperties ExpandedProperties { get { throw null; } }
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
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetRoleAssignmentScheduleId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetRoleAssignmentScheduleInstanceId { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleAssignmentScheduleTicketInfo TicketInfo { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Authorization.RoleAssignmentScheduleRequest FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_10_01;
        }
    }
    public partial class RoleAssignmentScheduleTicketInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoleAssignmentScheduleTicketInfo() { }
        public Azure.Provisioning.BicepValue<string> TicketNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TicketSystem { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoleDefinitionPermission : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoleDefinitionPermission() { }
        public Azure.Provisioning.BicepList<string> Actions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DataActions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NotActions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NotDataActions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoleEligibilityScheduleRequest : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RoleEligibilityScheduleRequest(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ApprovalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Condition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConditionVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleManagementExpandedProperties ExpandedProperties { get { throw null; } }
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
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetRoleEligibilityScheduleId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetRoleEligibilityScheduleInstanceId { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleEligibilityScheduleRequestPropertiesTicketInfo TicketInfo { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Authorization.RoleEligibilityScheduleRequest FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_10_01;
        }
    }
    public partial class RoleEligibilityScheduleRequestPropertiesTicketInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoleEligibilityScheduleRequestPropertiesTicketInfo() { }
        public Azure.Provisioning.BicepValue<string> TicketNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TicketSystem { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RoleManagementApprovalMode
    {
        SingleStage = 0,
        Serial = 1,
        Parallel = 2,
        NoApproval = 3,
    }
    public partial class RoleManagementApprovalSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoleManagementApprovalSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementApprovalMode> ApprovalMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Authorization.RoleManagementApprovalStage> ApprovalStages { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsApprovalRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsApprovalRequiredForExtension { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRequestorJustificationRequired { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoleManagementApprovalStage : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoleManagementApprovalStage() { }
        public Azure.Provisioning.BicepValue<int> ApprovalStageTimeOutInDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Authorization.RoleManagementUserInfo> EscalationApprovers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> EscalationTimeInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsApproverJustificationRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEscalationEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Authorization.RoleManagementUserInfo> PrimaryApprovers { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RoleManagementAssignmentLevel
    {
        Assignment = 0,
        Eligibility = 1,
    }
    public partial class RoleManagementExpandedProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoleManagementPolicyApprovalRule : Azure.Provisioning.Authorization.RoleManagementPolicyRule
    {
        public RoleManagementPolicyApprovalRule() { }
        public Azure.Provisioning.Authorization.RoleManagementApprovalSettings Settings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoleManagementPolicyAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RoleManagementPolicyAssignment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Authorization.RoleManagementPolicyRule> EffectiveRules { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.PolicyAssignmentProperties PolicyAssignmentProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PolicyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RoleDefinitionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Authorization.RoleManagementPolicyAssignment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_10_01;
        }
    }
    public partial class RoleManagementPolicyAuthenticationContextRule : Azure.Provisioning.Authorization.RoleManagementPolicyRule
    {
        public RoleManagementPolicyAuthenticationContextRule() { }
        public Azure.Provisioning.BicepValue<string> ClaimValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoleManagementPolicyEnablementRule : Azure.Provisioning.Authorization.RoleManagementPolicyRule
    {
        public RoleManagementPolicyEnablementRule() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Authorization.RoleAssignmentEnablementRuleType> EnablementRules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoleManagementPolicyExpirationRule : Azure.Provisioning.Authorization.RoleManagementPolicyRule
    {
        public RoleManagementPolicyExpirationRule() { }
        public Azure.Provisioning.BicepValue<bool> IsExpirationRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> MaximumDuration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
        protected override void DefineProvisionableProperties() { }
    }
    public enum RoleManagementPolicyRecipientType
    {
        Requestor = 0,
        Approver = 1,
        Admin = 2,
    }
    public partial class RoleManagementPolicyRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoleManagementPolicyRule() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleManagementPolicyRuleTarget Target { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoleManagementPolicyRuleTarget : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoleManagementPolicyRuleTarget() { }
        public Azure.Provisioning.BicepValue<string> Caller { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EnforcedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> InheritableSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementAssignmentLevel> Level { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Operations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> TargetObjects { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoleManagementPrincipal : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoleManagementPrincipal() { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> PrincipalType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class RoleManagementUserInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoleManagementUserInfo() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsBackup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementUserType> UserType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RoleManagementUserType
    {
        User = 0,
        Group = 1,
    }
}
namespace Azure.Provisioning.Expressions
{
    public partial class ArrayExpression : Azure.Provisioning.Expressions.BicepExpression
    {
        public ArrayExpression(params Azure.Provisioning.Expressions.BicepExpression[] values) { }
        public Azure.Provisioning.Expressions.BicepExpression[] Values { get { throw null; } }
    }
    public abstract partial class BicepExpression
    {
        protected BicepExpression() { }
        public static implicit operator Azure.Provisioning.Expressions.BicepExpression (bool value) { throw null; }
        public static implicit operator Azure.Provisioning.Expressions.BicepExpression (int value) { throw null; }
        public static implicit operator Azure.Provisioning.Expressions.BicepExpression (string value) { throw null; }
        public override string ToString() { throw null; }
        internal abstract Azure.Provisioning.Expressions.BicepWriter Write(Azure.Provisioning.Expressions.BicepWriter writer);
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
        public static Azure.Provisioning.BicepValue<string> Interpolate(Azure.Provisioning.Expressions.BicepInterpolatedStringHandler handler) { throw null; }
        public static Azure.Provisioning.BicepValue<object> ParseJson(Azure.Provisioning.BicepValue<object> value) { throw null; }
        public static Azure.Provisioning.BicepValue<string> Take(Azure.Provisioning.BicepValue<string> text, Azure.Provisioning.BicepValue<int> size) { throw null; }
        public static Azure.Provisioning.BicepValue<string> ToLower(Azure.Provisioning.BicepValue<object> value) { throw null; }
        public static Azure.Provisioning.BicepValue<string> ToUpper(Azure.Provisioning.BicepValue<object> value) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public ref partial struct BicepInterpolatedStringHandler
    {
        private object _dummy;
        private int _dummyPrimitive;
        public BicepInterpolatedStringHandler(int literalLength, int formattedCount) { throw null; }
        public void AppendFormatted<T>(T t) { }
        public void AppendLiteral(string text) { }
        public static implicit operator Azure.Provisioning.Expressions.BicepInterpolatedStringHandler (System.FormattableString formattable) { throw null; }
    }
    public partial class BicepProgram
    {
        public BicepProgram(params Azure.Provisioning.Expressions.BicepStatement[] body) { }
        public Azure.Provisioning.Expressions.BicepStatement[] Body { get { throw null; } }
        public string? ModuleName { get { throw null; } set { } }
        public override string ToString() { throw null; }
    }
    public abstract partial class BicepStatement
    {
        protected BicepStatement() { }
        public override string ToString() { throw null; }
        internal abstract Azure.Provisioning.Expressions.BicepWriter Write(Azure.Provisioning.Expressions.BicepWriter writer);
    }
    public partial class BicepStringBuilder
    {
        public BicepStringBuilder() { }
        public Azure.Provisioning.Expressions.BicepStringBuilder Append(Azure.Provisioning.Expressions.BicepExpression expression) { throw null; }
        public Azure.Provisioning.Expressions.BicepStringBuilder Append(Azure.Provisioning.Expressions.BicepInterpolatedStringHandler handler) { throw null; }
        public Azure.Provisioning.Expressions.BicepStringBuilder Append(string text) { throw null; }
        public Azure.Provisioning.BicepValue<string> Build() { throw null; }
        public static implicit operator Azure.Provisioning.BicepValue<string> (Azure.Provisioning.Expressions.BicepStringBuilder value) { throw null; }
    }
    public enum BinaryBicepOperator
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
    public partial class BinaryExpression : Azure.Provisioning.Expressions.BicepExpression
    {
        public BinaryExpression(Azure.Provisioning.Expressions.BicepExpression left, Azure.Provisioning.Expressions.BinaryBicepOperator op, Azure.Provisioning.Expressions.BicepExpression right) { }
        public Azure.Provisioning.Expressions.BicepExpression Left { get { throw null; } }
        public Azure.Provisioning.Expressions.BinaryBicepOperator Operator { get { throw null; } }
        public Azure.Provisioning.Expressions.BicepExpression Right { get { throw null; } }
    }
    public partial class BoolLiteralExpression : Azure.Provisioning.Expressions.LiteralExpression
    {
        public BoolLiteralExpression(bool value) : base (default(object)) { }
        public new bool Value { get { throw null; } }
    }
    public partial class CommentStatement : Azure.Provisioning.Expressions.BicepStatement
    {
        public CommentStatement(string comment) { }
        public string Comment { get { throw null; } }
    }
    public partial class ConditionalExpression : Azure.Provisioning.Expressions.BicepExpression
    {
        public ConditionalExpression(Azure.Provisioning.Expressions.BicepExpression condition, Azure.Provisioning.Expressions.BicepExpression consequent, Azure.Provisioning.Expressions.BicepExpression alternate) { }
        public Azure.Provisioning.Expressions.BicepExpression Alternate { get { throw null; } }
        public Azure.Provisioning.Expressions.BicepExpression Condition { get { throw null; } }
        public Azure.Provisioning.Expressions.BicepExpression Consequent { get { throw null; } }
    }
    public partial class DecoratorExpression : Azure.Provisioning.Expressions.BicepExpression
    {
        public DecoratorExpression(Azure.Provisioning.Expressions.BicepExpression value) { }
        public Azure.Provisioning.Expressions.BicepExpression Value { get { throw null; } }
    }
    public partial class ExpressionStatement : Azure.Provisioning.Expressions.BicepStatement
    {
        public ExpressionStatement(Azure.Provisioning.Expressions.BicepExpression expression) { }
        public Azure.Provisioning.Expressions.BicepExpression Expression { get { throw null; } }
    }
    public partial class FunctionCallExpression : Azure.Provisioning.Expressions.BicepExpression
    {
        public FunctionCallExpression(Azure.Provisioning.Expressions.BicepExpression function, params Azure.Provisioning.Expressions.BicepExpression[] arguments) { }
        public Azure.Provisioning.Expressions.BicepExpression[] Arguments { get { throw null; } }
        public Azure.Provisioning.Expressions.BicepExpression Function { get { throw null; } }
    }
    public partial class IdentifierExpression : Azure.Provisioning.Expressions.BicepExpression
    {
        public IdentifierExpression(string name) { }
        public string Name { get { throw null; } }
    }
    public partial class IndexExpression : Azure.Provisioning.Expressions.BicepExpression
    {
        public IndexExpression(Azure.Provisioning.Expressions.BicepExpression value, Azure.Provisioning.Expressions.BicepExpression index) { }
        public Azure.Provisioning.Expressions.BicepExpression Index { get { throw null; } }
        public Azure.Provisioning.Expressions.BicepExpression Value { get { throw null; } }
    }
    public partial class InterpolatedStringExpression : Azure.Provisioning.Expressions.BicepExpression
    {
        public InterpolatedStringExpression(Azure.Provisioning.Expressions.BicepExpression[] values) { }
        public Azure.Provisioning.Expressions.BicepExpression[] Values { get { throw null; } }
    }
    public partial class IntLiteralExpression : Azure.Provisioning.Expressions.LiteralExpression
    {
        public IntLiteralExpression(int value) : base (default(object)) { }
        public new int Value { get { throw null; } }
    }
    public abstract partial class LiteralExpression : Azure.Provisioning.Expressions.BicepExpression
    {
        protected LiteralExpression(object? value = null) { }
        public object? Value { get { throw null; } }
    }
    public partial class MemberExpression : Azure.Provisioning.Expressions.BicepExpression
    {
        public MemberExpression(Azure.Provisioning.Expressions.BicepExpression value, string member) { }
        public string Member { get { throw null; } }
        public Azure.Provisioning.Expressions.BicepExpression Value { get { throw null; } }
    }
    public partial class ModuleStatement : Azure.Provisioning.Expressions.BicepStatement
    {
        public ModuleStatement(string name, Azure.Provisioning.Expressions.BicepExpression type, Azure.Provisioning.Expressions.BicepExpression body) { }
        public Azure.Provisioning.Expressions.BicepExpression Body { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Provisioning.Expressions.DecoratorExpression> Decorators { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Provisioning.Expressions.BicepExpression Type { get { throw null; } }
    }
    public partial class NestedExpression : Azure.Provisioning.Expressions.BicepExpression
    {
        public NestedExpression(Azure.Provisioning.Expressions.BicepExpression value, string nestedMember) { }
        public string NestedMember { get { throw null; } }
        public Azure.Provisioning.Expressions.BicepExpression Value { get { throw null; } }
    }
    public partial class NullLiteralExpression : Azure.Provisioning.Expressions.LiteralExpression
    {
        public NullLiteralExpression() : base (default(object)) { }
    }
    public partial class ObjectExpression : Azure.Provisioning.Expressions.BicepExpression
    {
        public ObjectExpression(params Azure.Provisioning.Expressions.PropertyExpression[] properties) { }
        public Azure.Provisioning.Expressions.PropertyExpression[] Properties { get { throw null; } }
    }
    public partial class OutputStatement : Azure.Provisioning.Expressions.BicepStatement
    {
        public OutputStatement(string name, Azure.Provisioning.Expressions.BicepExpression type, Azure.Provisioning.Expressions.BicepExpression value) { }
        public System.Collections.Generic.IList<Azure.Provisioning.Expressions.DecoratorExpression> Decorators { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Provisioning.Expressions.BicepExpression Type { get { throw null; } }
        public Azure.Provisioning.Expressions.BicepExpression Value { get { throw null; } }
    }
    public partial class ParameterStatement : Azure.Provisioning.Expressions.BicepStatement
    {
        public ParameterStatement(string name, Azure.Provisioning.Expressions.BicepExpression type, Azure.Provisioning.Expressions.BicepExpression? defaultValue) { }
        public System.Collections.Generic.IList<Azure.Provisioning.Expressions.DecoratorExpression> Decorators { get { throw null; } }
        public Azure.Provisioning.Expressions.BicepExpression? DefaultValue { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Provisioning.Expressions.BicepExpression Type { get { throw null; } }
    }
    public partial class PropertyExpression : Azure.Provisioning.Expressions.BicepExpression
    {
        public PropertyExpression(string name, Azure.Provisioning.Expressions.BicepExpression value) { }
        public string Name { get { throw null; } }
        public Azure.Provisioning.Expressions.BicepExpression Value { get { throw null; } }
    }
    public partial class ResourceStatement : Azure.Provisioning.Expressions.BicepStatement
    {
        public ResourceStatement(string name, Azure.Provisioning.Expressions.BicepExpression type, Azure.Provisioning.Expressions.BicepExpression body) { }
        public Azure.Provisioning.Expressions.BicepExpression Body { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Provisioning.Expressions.DecoratorExpression> Decorators { get { throw null; } }
        public bool Existing { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.Provisioning.Expressions.BicepExpression Type { get { throw null; } }
    }
    public partial class SafeIndexExpression : Azure.Provisioning.Expressions.BicepExpression
    {
        public SafeIndexExpression(Azure.Provisioning.Expressions.BicepExpression value, Azure.Provisioning.Expressions.BicepExpression index) { }
        public Azure.Provisioning.Expressions.BicepExpression Index { get { throw null; } }
        public Azure.Provisioning.Expressions.BicepExpression Value { get { throw null; } }
    }
    public partial class SafeMemberExpression : Azure.Provisioning.Expressions.BicepExpression
    {
        public SafeMemberExpression(Azure.Provisioning.Expressions.BicepExpression value, string member) { }
        public string Member { get { throw null; } }
        public Azure.Provisioning.Expressions.BicepExpression Value { get { throw null; } }
    }
    public partial class StringLiteralExpression : Azure.Provisioning.Expressions.LiteralExpression
    {
        public StringLiteralExpression(string value) : base (default(object)) { }
        public new string Value { get { throw null; } }
    }
    public partial class TargetScopeStatement : Azure.Provisioning.Expressions.BicepStatement
    {
        public TargetScopeStatement(Azure.Provisioning.Expressions.BicepExpression scope) { }
        public Azure.Provisioning.Expressions.BicepExpression Scope { get { throw null; } }
    }
    public partial class TypeExpression : Azure.Provisioning.Expressions.BicepExpression
    {
        public TypeExpression(System.Type type) { }
        public System.Type Type { get { throw null; } }
    }
    public enum UnaryBicepOperator
    {
        Not = 0,
        Negate = 1,
        SuppressNull = 2,
    }
    public partial class UnaryExpression : Azure.Provisioning.Expressions.BicepExpression
    {
        public UnaryExpression(Azure.Provisioning.Expressions.UnaryBicepOperator op, Azure.Provisioning.Expressions.BicepExpression value) { }
        public Azure.Provisioning.Expressions.UnaryBicepOperator Operator { get { throw null; } }
        public Azure.Provisioning.Expressions.BicepExpression Value { get { throw null; } }
    }
    public partial class VariableStatement : Azure.Provisioning.Expressions.BicepStatement
    {
        public VariableStatement(string name, Azure.Provisioning.Expressions.BicepExpression value) { }
        public System.Collections.Generic.IList<Azure.Provisioning.Expressions.DecoratorExpression> Decorators { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Provisioning.Expressions.BicepExpression Value { get { throw null; } }
    }
}
namespace Azure.Provisioning.Primitives
{
    public partial class BicepLiteral : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BicepLiteral(params Azure.Provisioning.Expressions.BicepStatement[] statements) { }
        public System.Collections.Generic.IList<Azure.Provisioning.Expressions.BicepStatement> Statements { get { throw null; } }
        protected internal override System.Collections.Generic.IEnumerable<Azure.Provisioning.Expressions.BicepStatement> Compile() { throw null; }
    }
    public partial class BicepValueReference
    {
        public BicepValueReference(Azure.Provisioning.Primitives.ProvisionableConstruct construct, string propertyName, params string[]? path) { }
        public System.Collections.Generic.IReadOnlyList<string>? BicepPath { get { throw null; } }
        public Azure.Provisioning.Primitives.ProvisionableConstruct Construct { get { throw null; } }
        public string PropertyName { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public enum DeploymentScope
    {
        ResourceGroup = 0,
        Subscription = 1,
        ManagementGroup = 2,
        Tenant = 3,
    }
    public partial class DynamicResourceNamePropertyResolver : Azure.Provisioning.Primitives.ResourceNamePropertyResolver
    {
        public DynamicResourceNamePropertyResolver() { }
        protected virtual Azure.Provisioning.BicepValue<string> GetUniqueSuffix(Azure.Provisioning.ProvisioningBuildOptions options, Azure.Provisioning.Primitives.ProvisionableResource resource) { throw null; }
        public override Azure.Provisioning.BicepValue<string>? ResolveName(Azure.Provisioning.ProvisioningBuildOptions options, Azure.Provisioning.Primitives.ProvisionableResource resource, Azure.Provisioning.Primitives.ResourceNameRequirements requirements) { throw null; }
    }
    public abstract partial class InfrastructureResolver
    {
        protected InfrastructureResolver() { }
        public virtual System.Collections.Generic.IEnumerable<Azure.Provisioning.Infrastructure> GetNestedInfrastructure(Azure.Provisioning.Infrastructure infrastructure, Azure.Provisioning.ProvisioningBuildOptions options) { throw null; }
        public virtual void ResolveInfrastructure(Azure.Provisioning.Infrastructure infrastructure, Azure.Provisioning.ProvisioningBuildOptions options) { }
        public virtual void ResolveProperties(Azure.Provisioning.Primitives.ProvisionableConstruct construct, Azure.Provisioning.ProvisioningBuildOptions options) { }
        public virtual System.Collections.Generic.IEnumerable<Azure.Provisioning.Primitives.Provisionable> ResolveResources(System.Collections.Generic.IEnumerable<Azure.Provisioning.Primitives.Provisionable> resources, Azure.Provisioning.ProvisioningBuildOptions options) { throw null; }
    }
    public partial class LocationPropertyResolver : Azure.Provisioning.Primitives.InfrastructureResolver
    {
        public LocationPropertyResolver() { }
        protected virtual Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> GetDefaultLocation(Azure.Provisioning.ProvisioningBuildOptions options, Azure.Provisioning.Primitives.ProvisionableConstruct construct) { throw null; }
        public override void ResolveProperties(Azure.Provisioning.Primitives.ProvisionableConstruct construct, Azure.Provisioning.ProvisioningBuildOptions options) { }
    }
    public partial class ModuleImport : Azure.Provisioning.Primitives.NamedProvisionableConstruct
    {
        public ModuleImport(string bicepIdentifier, Azure.Provisioning.BicepValue<string> path) : base (default(string)) { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<object> Parameters { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        protected internal override System.Collections.Generic.IEnumerable<Azure.Provisioning.Expressions.BicepStatement> Compile() { throw null; }
        protected internal override void Validate(Azure.Provisioning.ProvisioningBuildOptions? options = null) { }
    }
    public abstract partial class NamedProvisionableConstruct : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        protected NamedProvisionableConstruct(string bicepIdentifier) { }
        public string BicepIdentifier { get { throw null; } set { } }
    }
    public partial class OrderingInfrastructureResolver : Azure.Provisioning.Primitives.InfrastructureResolver
    {
        public OrderingInfrastructureResolver() { }
        public override System.Collections.Generic.IEnumerable<Azure.Provisioning.Primitives.Provisionable> ResolveResources(System.Collections.Generic.IEnumerable<Azure.Provisioning.Primitives.Provisionable> resources, Azure.Provisioning.ProvisioningBuildOptions options) { throw null; }
    }
    public abstract partial class Provisionable
    {
        internal Provisionable() { }
        protected internal abstract System.Collections.Generic.IEnumerable<Azure.Provisioning.Expressions.BicepStatement> Compile();
        public virtual System.Collections.Generic.IEnumerable<Azure.Provisioning.Primitives.Provisionable> GetProvisionableResources() { throw null; }
        protected internal virtual void Resolve(Azure.Provisioning.ProvisioningBuildOptions? options = null) { }
        protected internal virtual void Validate(Azure.Provisioning.ProvisioningBuildOptions? options = null) { }
    }
    public abstract partial class ProvisionableConstruct : Azure.Provisioning.Primitives.Provisionable, Azure.Provisioning.IBicepValue
    {
        protected ProvisionableConstruct() { }
        Azure.Provisioning.Expressions.BicepExpression? Azure.Provisioning.IBicepValue.Expression { get { throw null; } set { } }
        bool Azure.Provisioning.IBicepValue.IsEmpty { get { throw null; } }
        bool Azure.Provisioning.IBicepValue.IsOutput { get { throw null; } }
        bool Azure.Provisioning.IBicepValue.IsRequired { get { throw null; } }
        bool Azure.Provisioning.IBicepValue.IsSecure { get { throw null; } }
        Azure.Provisioning.BicepValueKind Azure.Provisioning.IBicepValue.Kind { get { throw null; } }
        object? Azure.Provisioning.IBicepValue.LiteralValue { get { throw null; } }
        Azure.Provisioning.Primitives.BicepValueReference? Azure.Provisioning.IBicepValue.Self { get { throw null; } set { } }
        Azure.Provisioning.Primitives.BicepValueReference? Azure.Provisioning.IBicepValue.Source { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.Infrastructure? ParentInfrastructure { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IDictionary<string, Azure.Provisioning.IBicepValue> ProvisionableProperties { get { throw null; } }
        protected virtual void AssignOrReplace<T>(ref T? property, T value) where T : Azure.Provisioning.IBicepValue { }
        void Azure.Provisioning.IBicepValue.Assign(Azure.Provisioning.IBicepValue source) { }
        Azure.Provisioning.Expressions.BicepExpression Azure.Provisioning.IBicepValue.Compile() { throw null; }
        void Azure.Provisioning.IBicepValue.SetReadOnly() { }
        protected internal override System.Collections.Generic.IEnumerable<Azure.Provisioning.Expressions.BicepStatement> Compile() { throw null; }
        protected Azure.Provisioning.BicepDictionary<T> DefineDictionaryProperty<T>(string propertyName, string[]? bicepPath, bool isOutput = false, bool isRequired = false) { throw null; }
        protected Azure.Provisioning.BicepList<T> DefineListProperty<T>(string propertyName, string[]? bicepPath, bool isOutput = false, bool isRequired = false) { throw null; }
        protected T DefineModelProperty<T>(string propertyName, string[]? bicepPath, bool isOutput = false, bool isRequired = false, bool isSecure = false, string? format = null) where T : Azure.Provisioning.Primitives.ProvisionableConstruct, new() { throw null; }
        protected T DefineModelProperty<T>(string propertyName, string[]? bicepPath, T value, bool isOutput = false, bool isRequired = false, bool isSecure = false, string? format = null) where T : Azure.Provisioning.Primitives.ProvisionableConstruct { throw null; }
        protected Azure.Provisioning.BicepValue<T> DefineProperty<T>(string propertyName, string[]? bicepPath, bool isOutput = false, bool isRequired = false, bool isSecure = false, Azure.Provisioning.BicepValue<T>? defaultValue = null, string? format = null) { throw null; }
        protected virtual void DefineProvisionableProperties() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override System.Collections.Generic.IEnumerable<Azure.Provisioning.Primitives.Provisionable> GetProvisionableResources() { throw null; }
        protected void Initialize() { }
        protected internal void OverrideWithExpression(Azure.Provisioning.Expressions.BicepExpression reference) { }
        protected internal override void Resolve(Azure.Provisioning.ProvisioningBuildOptions? options = null) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void SetProvisioningProperty(Azure.Provisioning.IBicepValue property, Azure.Provisioning.BicepValue value) { }
        protected internal override void Validate(Azure.Provisioning.ProvisioningBuildOptions? options = null) { }
    }
    public abstract partial class ProvisionableResource : Azure.Provisioning.Primitives.NamedProvisionableConstruct
    {
        protected ProvisionableResource(string bicepIdentifier, Azure.Core.ResourceType resourceType, string? resourceVersion = null) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.Provisioning.Primitives.ProvisionableResource> DependsOn { get { throw null; } }
        public bool IsExistingResource { get { throw null; } protected set { } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
        public string? ResourceVersion { get { throw null; } set { } }
        public virtual Azure.Provisioning.ProvisioningPlan Build(Azure.Provisioning.ProvisioningBuildOptions? options = null) { throw null; }
        protected internal override System.Collections.Generic.IEnumerable<Azure.Provisioning.Expressions.BicepStatement> Compile() { throw null; }
        protected Azure.Provisioning.Primitives.ResourceReference<T> DefineResource<T>(string propertyName, string[]? bicepPath, bool isOutput = false, bool isRequired = false, T? defaultValue = null) where T : Azure.Provisioning.Primitives.ProvisionableResource { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        protected internal override void Validate(Azure.Provisioning.ProvisioningBuildOptions? options = null) { }
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
    public abstract partial class ResourceNamePropertyResolver : Azure.Provisioning.Primitives.InfrastructureResolver
    {
        protected ResourceNamePropertyResolver() { }
        public abstract Azure.Provisioning.BicepValue<string>? ResolveName(Azure.Provisioning.ProvisioningBuildOptions options, Azure.Provisioning.Primitives.ProvisionableResource resource, Azure.Provisioning.Primitives.ResourceNameRequirements requirements);
        public override void ResolveProperties(Azure.Provisioning.Primitives.ProvisionableConstruct construct, Azure.Provisioning.ProvisioningBuildOptions options) { }
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
    public partial class ResourceReference<T> where T : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ResourceReference(Azure.Provisioning.BicepValue<string> reference) { }
        public T? Value { get { throw null; } set { } }
    }
    public partial class StaticResourceNamePropertyResolver : Azure.Provisioning.Primitives.ResourceNamePropertyResolver
    {
        public StaticResourceNamePropertyResolver() { }
        public override Azure.Provisioning.BicepValue<string>? ResolveName(Azure.Provisioning.ProvisioningBuildOptions options, Azure.Provisioning.Primitives.ProvisionableResource resource, Azure.Provisioning.Primitives.ResourceNameRequirements requirements) { throw null; }
    }
}
namespace Azure.Provisioning.Resources
{
    public partial class ActionOnUnmanage : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ActionOnUnmanage() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.DeploymentStacksDeleteDetachEnum> ManagementGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.DeploymentStacksDeleteDetachEnum> ResourceGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.DeploymentStacksDeleteDetachEnum> Resources { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApiProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiProfile() { }
        public Azure.Provisioning.BicepValue<string> ApiVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProfileVersion { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmApplication : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ArmApplication(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ApplicationDefinitionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ArmApplicationArtifact> Artifacts { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ArmApplicationAuthorization> Authorizations { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BillingDetailsResourceUsageId { get { throw null; } }
        public Azure.Provisioning.Resources.ArmApplicationDetails CreatedBy { get { throw null; } }
        public Azure.Provisioning.Resources.ArmApplicationPackageContact CustomerSupport { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ArmApplicationManagedIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ArmApplicationJitAccessPolicy JitAccessPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedResourceGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationManagementMode> ManagementMode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Outputs { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ArmPlan Plan { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourcesProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> PublisherTenantId { get { throw null; } }
        public Azure.Provisioning.Resources.ArmApplicationSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ArmApplicationPackageSupportUris SupportUris { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ArmApplicationDetails UpdatedBy { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Resources.ArmApplication FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
    public partial class ArmApplicationArtifact : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmApplicationArtifact() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationArtifactType> ArtifactType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationArtifactName> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class ArmApplicationAuthorization : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmApplicationAuthorization() { }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RoleDefinitionId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmApplicationDefinition : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ArmApplicationDefinition(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ArmApplicationDefinitionArtifact> Artifacts { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ArmApplicationAuthorization> Authorizations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> CreateUiDefinition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ArmApplicationPackageLockingPolicy LockingPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationLockLevel> LockLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> MainTemplate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationManagementMode> ManagementMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ArmApplicationNotificationEndpoint> NotificationEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> PackageFileUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ArmApplicationPolicy> Policies { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ArmApplicationSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Resources.ArmApplicationDefinition FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
    public partial class ArmApplicationDefinitionArtifact : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmApplicationDefinitionArtifact() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationArtifactType> ArtifactType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationDefinitionArtifactName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class ArmApplicationDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmApplicationDetails() { }
        public Azure.Provisioning.BicepValue<System.Guid> ApplicationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ObjectId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Puid { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmApplicationJitAccessPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmApplicationJitAccessPolicy() { }
        public Azure.Provisioning.BicepValue<bool> JitAccessEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.JitApprovalMode> JitApprovalMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.JitApprover> JitApprovers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> MaximumJitAccessDuration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ArmApplicationLockLevel
    {
        None = 0,
        CanNotDelete = 1,
        ReadOnly = 2,
    }
    public partial class ArmApplicationManagedIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmApplicationManagedIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmApplicationManagedIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.ArmApplicationUserAssignedIdentity> UserAssignedIdentities { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class ArmApplicationNotificationEndpoint : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmApplicationNotificationEndpoint() { }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmApplicationPackageContact : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmApplicationPackageContact() { }
        public Azure.Provisioning.BicepValue<string> ContactName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Phone { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmApplicationPackageLockingPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmApplicationPackageLockingPolicy() { }
        public Azure.Provisioning.BicepList<string> AllowedActions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AllowedDataActions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmApplicationPackageSupportUris : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmApplicationPackageSupportUris() { }
        public Azure.Provisioning.BicepValue<System.Uri> AzureGovernmentUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> AzurePublicCloudUri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmApplicationPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmApplicationPolicy() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicyDefinitionId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmApplicationSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmApplicationSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Model { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmApplicationUserAssignedIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmApplicationUserAssignedIdentity() { }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class ArmDependency : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmDependency() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.BasicArmDependency> DependsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResourceName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmDeployment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ArmDeployment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ArmDeploymentPropertiesExtended Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Resources.ArmDeployment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
    public partial class ArmDeploymentContent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmDeploymentContent() { }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ArmDeploymentProperties Properties { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmDeploymentExtensionConfigItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmDeploymentExtensionConfigItem() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ExtensionConfigPropertyType> ExtensionConfigPropertyType { get { throw null; } }
        public Azure.Provisioning.Resources.KeyVaultParameterReference KeyVaultReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmDeploymentExtensionDefinition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmDeploymentExtensionDefinition() { }
        public Azure.Provisioning.BicepValue<string> Alias { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.ArmDeploymentExtensionConfigItem> Config { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ConfigId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmDeploymentExternalInput : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmDeploymentExternalInput() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmDeploymentExternalInputDefinition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmDeploymentExternalInputDefinition() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Config { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ArmDeploymentMode
    {
        Incremental = 0,
        Complete = 1,
    }
    public partial class ArmDeploymentParametersLink : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmDeploymentParametersLink() { }
        public Azure.Provisioning.BicepValue<string> ContentVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmDeploymentProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmDeploymentProperties() { }
        public Azure.Provisioning.BicepValue<string> DebugSettingDetailLevel { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ErrorDeployment ErrorDeployment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ExpressionEvaluationScope> ExpressionEvaluationScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.ArmDeploymentExtensionConfigItem>> ExtensionConfigs { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.ArmDeploymentExternalInputDefinition> ExternalInputDefinitions { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.ArmDeploymentExternalInput> ExternalInputs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmDeploymentMode> Mode { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ArmDeploymentParametersLink ParametersLink { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Template { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ArmDeploymentTemplateLink TemplateLink { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ValidationLevel> ValidationLevel { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmDeploymentPropertiesExtended : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmDeploymentPropertiesExtended() { }
        public Azure.Provisioning.BicepValue<string> CorrelationId { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ArmDependency> Dependencies { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.DeploymentDiagnosticsDefinition> Diagnostics { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ResponseError> Error { get { throw null; } }
        public Azure.Provisioning.Resources.ErrorDeploymentExtended ErrorDeployment { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ArmDeploymentExtensionDefinition> Extensions { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmDeploymentMode> Mode { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ArmResourceReference> OutputResourceDetails { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> OutputResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Outputs { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Parameters { get { throw null; } }
        public Azure.Provisioning.Resources.ArmDeploymentParametersLink ParametersLink { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ResourceProviderData> Providers { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourcesProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TemplateHash { get { throw null; } }
        public Azure.Provisioning.Resources.ArmDeploymentTemplateLink TemplateLink { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Timestamp { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ArmResourceReference> ValidatedResourceDetails { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> ValidatedResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ValidationLevel> ValidationLevel { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmDeploymentScript : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ArmDeploymentScript(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ArmDeploymentScriptManagedIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Resources.ArmDeploymentScript FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_10_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class ArmDeploymentScriptManagedIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmDeploymentScriptManagedIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmDeploymentScriptManagedIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.UserAssignedIdentityDetails> UserAssignedIdentities { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ArmDeploymentScriptManagedIdentityType
    {
        UserAssigned = 0,
    }
    public partial class ArmDeploymentTemplateLink : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmDeploymentTemplateLink() { }
        public Azure.Provisioning.BicepValue<string> ContentVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QueryString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RelativePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmDeploymentWhatIfProperties : Azure.Provisioning.Resources.ArmDeploymentProperties
    {
        public ArmDeploymentWhatIfProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.WhatIfResultFormat> WhatIfResultFormat { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmPlan : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmPlan() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Product { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PromotionCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmPolicyParameter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmPolicyParameter() { }
        public Azure.Provisioning.BicepList<System.BinaryData> AllowedValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> DefaultValue { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ParameterDefinitionsValueMetadata Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ArmPolicyParameterType> ParameterType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class ArmPolicyParameterValue : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmPolicyParameterValue() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmResourceReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmResourceReference() { }
        public Azure.Provisioning.BicepValue<string> ApiVersion { get { throw null; } }
        public Azure.Provisioning.Resources.ArmDeploymentExtensionDefinition Extension { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Identifiers { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureCliScript : Azure.Provisioning.Resources.ArmDeploymentScript
    {
        public AzureCliScript(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Arguments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzCliVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ScriptCleanupOptions> CleanupPreference { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContainerGroupName { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ScriptContainerConfiguration ContainerSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ScriptEnvironmentVariable> EnvironmentVariables { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ForceUpdateTag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Outputs { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> PrimaryScriptUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ScriptProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> RetentionInterval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptContent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ScriptStatus Status { get { throw null; } }
        public Azure.Provisioning.Resources.ScriptStorageConfiguration StorageAccountSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.Uri> SupportingScriptUris { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Timeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzurePowerShellScript : Azure.Provisioning.Resources.ArmDeploymentScript
    {
        public AzurePowerShellScript(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Arguments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzPowerShellVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ScriptCleanupOptions> CleanupPreference { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContainerGroupName { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ScriptContainerConfiguration ContainerSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ScriptEnvironmentVariable> EnvironmentVariables { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ForceUpdateTag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Outputs { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> PrimaryScriptUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ScriptProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> RetentionInterval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptContent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ScriptStatus Status { get { throw null; } }
        public Azure.Provisioning.Resources.ScriptStorageConfiguration StorageAccountSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.Uri> SupportingScriptUris { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Timeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BasicArmDependency : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BasicArmDependency() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResourceName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CreatedByType
    {
        User = 0,
        Application = 1,
        ManagedIdentity = 2,
        Key = 3,
    }
    public partial class CreateManagementGroupDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CreateManagementGroupDetails() { }
        public Azure.Provisioning.Resources.ManagementGroupParentCreateOptions Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UpdatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataBoundaryName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="default")]
        Default = 0,
    }
    public partial class DataBoundaryProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataBoundaryProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.DataBoundaryRegion> DataBoundary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.DataBoundaryProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataBoundaryProvisioningState
    {
        Accepted = 0,
        Running = 1,
        Creating = 2,
        Canceled = 3,
        Failed = 4,
        Succeeded = 5,
        Updating = 6,
    }
    public enum DataBoundaryRegion
    {
        NotDefined = 0,
        Global = 1,
        EU = 2,
    }
    public partial class DenySettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DenySettings() { }
        public Azure.Provisioning.BicepValue<bool> ApplyToChildScopes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ExcludedActions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ExcludedPrincipals { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.DenySettingsMode> Mode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DenySettingsMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="denyDelete")]
        DenyDelete = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="denyWriteAndDelete")]
        DenyWriteAndDelete = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="none")]
        None = 2,
    }
    public enum DenyStatusMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="denyDelete")]
        DenyDelete = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="notSupported")]
        NotSupported = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="inapplicable")]
        Inapplicable = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="denyWriteAndDelete")]
        DenyWriteAndDelete = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="removedBySystem")]
        RemovedBySystem = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="none")]
        None = 5,
    }
    public partial class DeploymentDiagnosticsDefinition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeploymentDiagnosticsDefinition() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.Level> Level { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Target { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeploymentParameter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeploymentParameter() { }
        public Azure.Provisioning.BicepValue<string> DeploymentParameterType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.KeyVaultParameterReference Reference { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeploymentStack : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DeploymentStack(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Resources.ActionOnUnmanage ActionOnUnmanage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> BypassStackOutOfSyncError { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CorrelationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DebugSettingDetailLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> DeletedResources { get { throw null; } }
        public Azure.Provisioning.Resources.DenySettings DenySettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DeploymentId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DeploymentScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> DetachedResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ResponseError> Error { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ResourceReferenceExtended> FailedResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Outputs { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.DeploymentParameter> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.Resources.DeploymentStacksParametersLink ParametersLink { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.DeploymentStackProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ManagedResourceReference> Resources { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Template { get { throw null; } set { } }
        public Azure.Provisioning.Resources.DeploymentStacksTemplateLink TemplateLink { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Resources.DeploymentStack FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_01;
        }
    }
    public enum DeploymentStackProvisioningState
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="creating")]
        Creating = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="validating")]
        Validating = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="waiting")]
        Waiting = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="deploying")]
        Deploying = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="canceling")]
        Canceling = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="updatingDenyAssignments")]
        UpdatingDenyAssignments = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="deletingResources")]
        DeletingResources = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="succeeded")]
        Succeeded = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="failed")]
        Failed = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="canceled")]
        Canceled = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="deleting")]
        Deleting = 10,
    }
    public enum DeploymentStacksDeleteDetachEnum
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="delete")]
        Delete = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="detach")]
        Detach = 1,
    }
    public partial class DeploymentStacksParametersLink : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeploymentStacksParametersLink() { }
        public Azure.Provisioning.BicepValue<string> ContentVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeploymentStacksTemplateLink : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeploymentStacksTemplateLink() { }
        public Azure.Provisioning.BicepValue<string> ContentVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QueryString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RelativePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EnforcementMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Default")]
        Enforced = 0,
        Default = 1,
        DoNotEnforce = 2,
    }
    public partial class ErrorAdditionalInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ErrorAdditionalInfo() { }
        public Azure.Provisioning.BicepValue<string> ErrorAdditionalInfoType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Info { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ErrorDeployment : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ErrorDeployment() { }
        public Azure.Provisioning.BicepValue<string> DeploymentName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ErrorDeploymentType> DeploymentType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ErrorDeploymentExtended : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ErrorDeploymentExtended() { }
        public Azure.Provisioning.BicepValue<string> DeploymentName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ErrorDeploymentType> DeploymentType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class ExtendedAzureLocation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExtendedAzureLocation() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ExtendedLocationType> ExtendedLocationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ExtendedLocationType
    {
        EdgeZone = 0,
    }
    public enum ExtensionConfigPropertyType
    {
        String = 0,
        Int = 1,
        Bool = 2,
        Array = 3,
        Object = 4,
        SecureString = 5,
        SecureObject = 6,
    }
    public partial class GenericResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public GenericResource(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ChangedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Resources.ArmPlan Plan { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.ResourcesSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Resources.GenericResource FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public enum JitApprovalMode
    {
        NotSpecified = 0,
        AutoApprove = 1,
        ManualApprove = 2,
    }
    public partial class JitApprover : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JitApprover() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.JitApproverType> ApproverType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum JitApproverType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="user")]
        User = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="group")]
        Group = 1,
    }
    public partial class JitAuthorizationPolicies : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JitAuthorizationPolicies() { }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RoleDefinitionId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JitRequest : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public JitRequest(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ApplicationResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ArmApplicationDetails CreatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.JitAuthorizationPolicies> JitAuthorizationPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.JitRequestState> JitRequestState { get { throw null; } }
        public Azure.Provisioning.Resources.JitSchedulingPolicy JitSchedulingPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourcesProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> PublisherTenantId { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ArmApplicationDetails UpdatedBy { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Resources.JitRequest FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
    public partial class JitSchedulingPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JitSchedulingPolicy() { }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.JitSchedulingType> SchedulingType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum JitSchedulingType
    {
        NotSpecified = 0,
        Once = 1,
        Recurring = 2,
    }
    public partial class KeyVaultParameterReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyVaultParameterReference() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> KeyVaultId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum Level
    {
        Warning = 0,
        Info = 1,
        Error = 2,
    }
    public partial class LinkedTemplateArtifact : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LinkedTemplateArtifact() { }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Template { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedByTenant : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedByTenant() { }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedResourceReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedResourceReference() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.DenyStatusMode> DenyStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourceStatusMode> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedServiceIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedServiceIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentityType> ManagedServiceIdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.UserAssignedIdentityDetails> UserAssignedIdentities { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedServiceIdentityType
    {
        None = 0,
        SystemAssigned = 1,
        UserAssigned = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SystemAssigned, UserAssigned")]
        SystemAssignedUserAssigned = 3,
    }
    public partial class ManagementGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagementGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ManagementGroupChildOptions> Children { get { throw null; } }
        public Azure.Provisioning.Resources.CreateManagementGroupDetails Details { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Resources.ManagementGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
    public partial class ManagementGroupChildInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagementGroupChildInfo() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ManagementGroupChildInfo> Children { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagementGroupChildType> ChildType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagementGroupChildOptions : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagementGroupChildOptions() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ManagementGroupChildOptions> Children { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagementGroupChildType> ChildType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagementGroupChildType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.Management/managementGroups")]
        MicrosoftManagementManagementGroups = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="/subscriptions")]
        Subscriptions = 1,
    }
    public partial class ManagementGroupInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagementGroupInfo() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ManagementGroupPathElement> ManagementGroupAncestorChain { get { throw null; } }
        public Azure.Provisioning.BicepList<string> ManagementGroupAncestors { get { throw null; } }
        public Azure.Provisioning.Resources.ParentManagementGroupInfo Parent { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ManagementGroupPathElement> Path { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UpdatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagementGroupParentCreateOptions : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagementGroupParentCreateOptions() { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagementGroupPathElement : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagementGroupPathElement() { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagementGroupPolicyDefinition : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagementGroupPolicyDefinition(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.ArmPolicyParameter> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> PolicyRule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.PolicyType> PolicyType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Resources.ManagementGroupPolicyDefinition FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
            public static readonly string V2024_05_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class ManagementGroupPolicySetDefinition : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagementGroupPolicySetDefinition(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.ArmPolicyParameter> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.PolicyDefinitionGroup> PolicyDefinitionGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.PolicyDefinitionReference> PolicyDefinitions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.PolicyType> PolicyType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Resources.ManagementGroupPolicySetDefinition FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
            public static readonly string V2024_05_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class ManagementGroupSubscription : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagementGroupSubscription(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Resources.ManagementGroup? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ParentId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> State { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Resources.ManagementGroupSubscription FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
    public partial class ManagementLock : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagementLock(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagementLockLevel> Level { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Notes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ManagementLockOwner> Owners { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Resources.ManagementLock FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
    public partial class ManagementLockOwner : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagementLockOwner() { }
        public Azure.Provisioning.BicepValue<string> ApplicationId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NonComplianceMessage : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NonComplianceMessage() { }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicyDefinitionReferenceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ParameterDefinitionsValueMetadata : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ParameterDefinitionsValueMetadata() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AssignPermissions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StrongType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ParentManagementGroupInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ParentManagementGroupInfo() { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PolicyAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PolicyAssignment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.EnforcementMode> EnforcementMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ExcludedScopes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity ManagedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.NonComplianceMessage> NonComplianceMessages { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.PolicyOverride> Overrides { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.ArmPolicyParameterValue> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicyDefinitionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ResourceSelector> ResourceSelectors { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Resources.PolicyAssignment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
            public static readonly string V2024_05_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class PolicyDefinitionGroup : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PolicyDefinitionGroup() { }
        public Azure.Provisioning.BicepValue<string> AdditionalMetadataId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Category { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PolicyDefinitionReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PolicyDefinitionReference() { }
        public Azure.Provisioning.BicepList<string> GroupNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.ArmPolicyParameterValue> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicyDefinitionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicyDefinitionReferenceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PolicyOverride : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PolicyOverride() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.PolicyOverrideKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ResourceSelectorExpression> Selectors { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class ProviderExtendedLocation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ProviderExtendedLocation() { }
        public Azure.Provisioning.BicepList<string> ExtendedLocations { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProviderExtendedLocationType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ProviderResourceType : Azure.Provisioning.Primitives.ProvisionableConstruct
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResourceGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ResourceGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroupProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Resources.ResourceGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
        }
    }
    public partial class ResourceProviderData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceProviderData() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Namespace { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ProviderAuthorizationConsentState> ProviderAuthorizationConsentState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RegistrationPolicy { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RegistrationState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ProviderResourceType> ResourceTypes { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResourceReferenceExtended : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceReferenceExtended() { }
        public Azure.Provisioning.BicepValue<Azure.ResponseError> Error { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResourceSelector : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceSelector() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ResourceSelectorExpression> Selectors { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResourceSelectorExpression : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceSelectorExpression() { }
        public Azure.Provisioning.BicepList<string> In { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourceSelectorKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NotIn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class ResourcesSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourcesSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Model { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ResourceStatusMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="managed")]
        Managed = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="removeDenyFailed")]
        RemoveDenyFailed = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="deleteFailed")]
        DeleteFailed = 2,
    }
    public partial class ResourceTypeAlias : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceTypeAlias() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourceTypeAliasType> AliasType { get { throw null; } }
        public Azure.Provisioning.Resources.ResourceTypeAliasPathMetadata DefaultMetadata { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DefaultPath { get { throw null; } }
        public Azure.Provisioning.Resources.ResourceTypeAliasPattern DefaultPattern { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ResourceTypeAliasPath> Paths { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResourceTypeAliasPath : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceTypeAliasPath() { }
        public Azure.Provisioning.BicepList<string> ApiVersions { get { throw null; } }
        public Azure.Provisioning.Resources.ResourceTypeAliasPathMetadata Metadata { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } }
        public Azure.Provisioning.Resources.ResourceTypeAliasPattern Pattern { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ResourceTypeAliasPathAttributes
    {
        None = 0,
        Modifiable = 1,
    }
    public partial class ResourceTypeAliasPathMetadata : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceTypeAliasPathMetadata() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourceTypeAliasPathAttributes> Attributes { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourceTypeAliasPathTokenType> TokenType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class ResourceTypeAliasPattern : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceTypeAliasPattern() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ResourceTypeAliasPatternType> PatternType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Phrase { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Variable { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
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
    public enum ScriptCleanupOptions
    {
        Always = 0,
        OnSuccess = 1,
        OnExpiration = 2,
    }
    public partial class ScriptContainerConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScriptContainerConfiguration() { }
        public Azure.Provisioning.BicepValue<string> ContainerGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ScriptContainerGroupSubnet> SubnetIds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ScriptContainerGroupSubnet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScriptContainerGroupSubnet() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ScriptEnvironmentVariable : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScriptEnvironmentVariable() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecureValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ScriptProvisioningState
    {
        Creating = 0,
        ProvisioningResources = 1,
        Running = 2,
        Succeeded = 3,
        Failed = 4,
        Canceled = 5,
    }
    public partial class ScriptStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScriptStatus() { }
        public Azure.Provisioning.BicepValue<string> ContainerInstanceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ResponseError> Error { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> StorageAccountId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ScriptStorageConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScriptStorageConfiguration() { }
        public Azure.Provisioning.BicepValue<string> StorageAccountKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SpendingLimit
    {
        On = 0,
        Off = 1,
        CurrentPeriodOff = 2,
    }
    public partial class SubResource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SubResource() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class Subscription : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public Subscription(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AuthorizationSource { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.ManagedByTenant> ManagedByTenants { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SubscriptionState> State { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } }
        public Azure.Provisioning.Resources.SubscriptionPolicies SubscriptionPolicies { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class SubscriptionPolicies : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SubscriptionPolicies() { }
        public Azure.Provisioning.BicepValue<string> LocationPlacementId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> QuotaId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SpendingLimit> SpendingLimit { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SubscriptionPolicyDefinition : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SubscriptionPolicyDefinition(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.ArmPolicyParameter> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> PolicyRule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.PolicyType> PolicyType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Resources.SubscriptionPolicyDefinition FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
    }
    public partial class SubscriptionPolicySetDefinition : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SubscriptionPolicySetDefinition(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.ArmPolicyParameter> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.PolicyDefinitionGroup> PolicyDefinitionGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.PolicyDefinitionReference> PolicyDefinitions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.PolicyType> PolicyType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Resources.SubscriptionPolicySetDefinition FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
    public partial class SystemAssignedServiceIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SystemAssignedServiceIdentity() { }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemAssignedServiceIdentityType> SystemAssignedServiceIdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SystemAssignedServiceIdentityType
    {
        None = 0,
        SystemAssigned = 1,
    }
    public partial class SystemData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SystemData() { }
        public Azure.Provisioning.BicepValue<string> CreatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.CreatedByType> CreatedByType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastModifiedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.CreatedByType> LastModifiedByType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TagResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TagResource(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> TagValues { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Resources.TagResource FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
    public partial class TemplateSpec : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TemplateSpec(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.TemplateSpecVersionInfo> Versions { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Resources.TemplateSpec FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_05_01;
            public static readonly string V2022_02_01;
        }
    }
    public partial class TemplateSpecVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TemplateSpecVersion(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.LinkedTemplateArtifact> LinkedTemplates { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> MainTemplate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Resources.TemplateSpec? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> UiFormDefinition { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Resources.TemplateSpecVersion FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_05_01;
            public static readonly string V2022_02_01;
        }
    }
    public partial class TemplateSpecVersionInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TemplateSpecVersionInfo() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TimeCreated { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TimeModified { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class Tenant : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public Tenant(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
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
        protected override void DefineProvisionableProperties() { }
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
    public partial class TenantDataBoundary : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TenantDataBoundary(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.DataBoundaryName> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.DataBoundaryProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_08_01;
        }
    }
    public partial class UserAssignedIdentityDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UserAssignedIdentityDetails() { }
        public Azure.Provisioning.BicepValue<System.Guid> ClientId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ValidationLevel
    {
        Template = 0,
        Provider = 1,
        ProviderNoRbac = 2,
    }
    public enum WhatIfResultFormat
    {
        ResourceIdOnly = 0,
        FullResourcePayloads = 1,
    }
    public partial class WritableSubResource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WritableSubResource() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ZoneMapping : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ZoneMapping() { }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
}
namespace Azure.Provisioning.Roles
{
    public partial class FederatedIdentityCredential : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FederatedIdentityCredential(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> Audiences { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> IssuerUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Roles.UserAssignedIdentity? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Subject { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Roles.FederatedIdentityCredential FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2022_01_31_PREVIEW;
            public static readonly string V2023_01_31;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2023_07_31_PREVIEW;
            public static readonly string V2024_11_30;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2025_01_31_PREVIEW;
        }
    }
    public partial class UserAssignedIdentity : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public UserAssignedIdentity(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Guid> ClientId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Roles.UserAssignedIdentity FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2015_08_31_PREVIEW;
            public static readonly string V2018_11_30;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2021_09_30_PREVIEW;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2022_01_31_PREVIEW;
            public static readonly string V2023_01_31;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2023_07_31_PREVIEW;
            public static readonly string V2024_11_30;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2025_01_31_PREVIEW;
        }
    }
}
