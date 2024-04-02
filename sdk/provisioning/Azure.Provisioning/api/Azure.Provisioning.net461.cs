namespace Azure.Provisioning
{
    public partial class Configuration
    {
        public Configuration() { }
        public bool UseInteractiveMode { get { throw null; } set { } }
    }
    public abstract partial class ConnectionString
    {
        protected ConnectionString(string value) { }
        public string Value { get { throw null; } }
    }
    public abstract partial class Construct : Azure.Provisioning.IConstruct
    {
        protected Construct(Azure.Provisioning.IConstruct? scope, string name, Azure.Provisioning.ConstructScope constructScope = Azure.Provisioning.ConstructScope.ResourceGroup, System.Guid? tenantId = default(System.Guid?), System.Guid? subscriptionId = default(System.Guid?), string? envName = null, Azure.Provisioning.ResourceManager.ResourceGroup? resourceGroup = null) { }
        public Azure.Provisioning.Configuration? Configuration { get { throw null; } }
        public Azure.Provisioning.ConstructScope ConstructScope { get { throw null; } }
        public string EnvironmentName { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Provisioning.ResourceManager.ResourceGroup? ResourceGroup { get { throw null; } protected set { } }
        public Azure.Provisioning.ResourceManager.Tenant Root { get { throw null; } }
        public Azure.Provisioning.IConstruct? Scope { get { throw null; } }
        public Azure.Provisioning.ResourceManager.Subscription? Subscription { get { throw null; } }
        public void AddConstruct(Azure.Provisioning.IConstruct construct) { }
        public void AddOutput(Azure.Provisioning.Output output) { }
        public void AddParameter(Azure.Provisioning.Parameter parameter) { }
        public void AddResource(Azure.Provisioning.Resource resource) { }
        public System.Collections.Generic.IEnumerable<Azure.Provisioning.IConstruct> GetConstructs(bool recursive = true) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.Provisioning.Output> GetOutputs(bool recursive = true) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.Provisioning.Parameter> GetParameters(bool recursive = true) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.Provisioning.Resource> GetResources(bool recursive = true) { throw null; }
        protected T UseExistingResource<T>(T? resource, System.Func<T> create) where T : Azure.Provisioning.Resource { throw null; }
    }
    public enum ConstructScope
    {
        ResourceGroup = 0,
        Subscription = 1,
        ManagementGroup = 2,
        Tenant = 3,
    }
    public partial interface IConstruct
    {
        Azure.Provisioning.Configuration? Configuration { get; }
        Azure.Provisioning.ConstructScope ConstructScope { get; }
        string EnvironmentName { get; }
        string Name { get; }
        Azure.Provisioning.ResourceManager.ResourceGroup? ResourceGroup { get; }
        Azure.Provisioning.ResourceManager.Tenant Root { get; }
        Azure.Provisioning.IConstruct? Scope { get; }
        Azure.Provisioning.ResourceManager.Subscription? Subscription { get; }
        void AddConstruct(Azure.Provisioning.IConstruct construct);
        void AddOutput(Azure.Provisioning.Output output);
        void AddParameter(Azure.Provisioning.Parameter parameter);
        void AddResource(Azure.Provisioning.Resource resource);
        System.Collections.Generic.IEnumerable<Azure.Provisioning.IConstruct> GetConstructs(bool recursive = true);
        System.Collections.Generic.IEnumerable<Azure.Provisioning.Output> GetOutputs(bool recursive = true);
        System.Collections.Generic.IEnumerable<Azure.Provisioning.Parameter> GetParameters(bool recursive = true);
        System.Collections.Generic.IEnumerable<Azure.Provisioning.Resource> GetResources(bool recursive = true);
    }
    public abstract partial class Infrastructure : Azure.Provisioning.Construct
    {
        public Infrastructure(Azure.Provisioning.ConstructScope constructScope = Azure.Provisioning.ConstructScope.Subscription, System.Guid? tenantId = default(System.Guid?), System.Guid? subscriptionId = default(System.Guid?), string? envName = null, Azure.Provisioning.Configuration? configuration = null) : base (default(Azure.Provisioning.IConstruct), default(string), default(Azure.Provisioning.ConstructScope), default(System.Guid?), default(System.Guid?), default(string), default(Azure.Provisioning.ResourceManager.ResourceGroup)) { }
        public void Build(string? outputPath = null) { }
    }
    public partial class Output
    {
        internal Output() { }
        public bool IsLiteral { get { throw null; } }
        public bool IsSecure { get { throw null; } }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Parameter
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Parameter(Azure.Provisioning.Output output) { throw null; }
        public Parameter(string name, string? description = null, object? defaultValue = null, bool isSecure = false) { throw null; }
        public object? DefaultValue { get { throw null; } }
        public string? Description { get { throw null; } }
        public bool IsFromOutput { get { throw null; } }
        public bool IsSecure { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Provisioning.IConstruct? Source { get { throw null; } }
        public string? Value { get { throw null; } }
    }
    public static partial class ProvisioningExtensions
    {
        public static T? GetSingleResourceInScope<T>(this Azure.Provisioning.IConstruct construct) where T : Azure.Provisioning.Resource { throw null; }
        public static T? GetSingleResource<T>(this Azure.Provisioning.IConstruct construct) where T : Azure.Provisioning.Resource { throw null; }
    }
    public abstract partial class Resource : System.ClientModel.Primitives.IPersistableModel<Azure.Provisioning.Resource>
    {
        protected Resource(Azure.Provisioning.IConstruct scope, Azure.Provisioning.Resource? parent, string resourceName, Azure.Core.ResourceType resourceType, string version, System.Func<string, object> createProperties) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public bool IsExisting { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Provisioning.Resource? Parent { get { throw null; } }
        protected object ResourceData { get { throw null; } }
        public Azure.Provisioning.IConstruct Scope { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        protected virtual string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
        protected virtual string GetBicepName(Azure.Provisioning.Resource resource) { throw null; }
        protected string GetGloballyUniqueName(string resourceName) { throw null; }
        protected virtual bool NeedsParent() { throw null; }
        protected virtual bool NeedsScope() { throw null; }
        Azure.Provisioning.Resource System.ClientModel.Primitives.IPersistableModel<Azure.Provisioning.Resource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Provisioning.Resource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Provisioning.Resource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class Resource<T> : Azure.Provisioning.Resource where T : notnull
    {
        protected Resource(Azure.Provisioning.IConstruct scope, Azure.Provisioning.Resource? parent, string resourceName, Azure.Core.ResourceType resourceType, string version, System.Func<string, T> createProperties, bool isExisting = false) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, object>)) { }
        public T Properties { get { throw null; } }
        public Azure.Provisioning.Output AddOutput(string outputName, System.Linq.Expressions.Expression<System.Func<T, object?>> propertySelector, bool isLiteral = false, bool isSecure = false) { throw null; }
        public Azure.Provisioning.Output AddOutput(string outputName, string formattedString, System.Linq.Expressions.Expression<System.Func<T, object?>> propertySelector, bool isLiteral = false, bool isSecure = false) { throw null; }
        public void AssignProperty(System.Linq.Expressions.Expression<System.Func<T, object?>> propertySelector, Azure.Provisioning.Parameter parameter) { }
        public void AssignProperty(System.Linq.Expressions.Expression<System.Func<T, object?>> propertySelector, string propertyValue) { }
    }
}
namespace Azure.Provisioning.ResourceManager
{
    public partial class ResourceGroup : Azure.Provisioning.Resource<Azure.ResourceManager.Resources.ResourceGroupData>
    {
        public ResourceGroup(Azure.Provisioning.IConstruct scope, string? name = "rg", string version = "2023-07-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Provisioning.ResourceManager.Subscription? parent = null) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Resources.ResourceGroupData>), default(bool)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
    public static partial class ResourceManagerExtensions
    {
        public static Azure.Provisioning.ResourceManager.ResourceGroup AddResourceGroup(this Azure.Provisioning.IConstruct construct) { throw null; }
        public static Azure.Provisioning.ResourceManager.ResourceGroup GetOrAddResourceGroup(this Azure.Provisioning.IConstruct construct) { throw null; }
        public static Azure.Provisioning.ResourceManager.Subscription GetOrCreateSubscription(this Azure.Provisioning.IConstruct construct, System.Guid? subscriptionId = default(System.Guid?)) { throw null; }
    }
    public partial class Subscription : Azure.Provisioning.Resource<Azure.ResourceManager.Resources.SubscriptionData>
    {
        public Subscription(Azure.Provisioning.IConstruct scope, System.Guid? guid = default(System.Guid?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Resources.SubscriptionData>), default(bool)) { }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string? resourceName) { throw null; }
    }
    public partial class Tenant : Azure.Provisioning.Resource<Azure.ResourceManager.Resources.TenantData>
    {
        public const string TenantIdExpression = "tenant().tenantId";
        public Tenant(Azure.Provisioning.IConstruct scope, System.Guid? tenantId = default(System.Guid?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Resources.TenantData>), default(bool)) { }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string? resourceName) { throw null; }
    }
}
