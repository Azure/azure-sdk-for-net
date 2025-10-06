namespace Azure.ResourceManager.Terraform
{
    public partial class AzureResourceManagerTerraformContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerTerraformContext() { }
        public static Azure.ResourceManager.Terraform.AzureResourceManagerTerraformContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class TerraformExtensions
    {
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Terraform.Models.TerraformOperationStatus> ExportTerraform(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Terraform.Models.CommonExportProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Terraform.Models.TerraformOperationStatus>> ExportTerraformAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Terraform.Models.CommonExportProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Terraform.Mocking
{
    public partial class MockableTerraformSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableTerraformSubscriptionResource() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Terraform.Models.TerraformOperationStatus> ExportTerraform(Azure.WaitUntil waitUntil, Azure.ResourceManager.Terraform.Models.CommonExportProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Terraform.Models.TerraformOperationStatus>> ExportTerraformAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Terraform.Models.CommonExportProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Terraform.Models
{
    public static partial class ArmTerraformModelFactory
    {
        public static Azure.ResourceManager.Terraform.Models.ExportQueryTerraform ExportQueryTerraform(Azure.ResourceManager.Terraform.Models.TargetTerraformProvider? targetProvider = default(Azure.ResourceManager.Terraform.Models.TargetTerraformProvider?), bool? isOutputFullPropertiesEnabled = default(bool?), bool? isMaskSensitiveEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> azureResourcesToExclude = null, System.Collections.Generic.IEnumerable<string> terraformResourcesToExclude = null, string query = null, string namePattern = null, bool? isRecursive = default(bool?), string table = null, Azure.ResourceManager.Terraform.Models.TerraformAuthorizationScopeFilter? authorizationScopeFilter = default(Azure.ResourceManager.Terraform.Models.TerraformAuthorizationScopeFilter?)) { throw null; }
        public static Azure.ResourceManager.Terraform.Models.ExportResourceGroupTerraform ExportResourceGroupTerraform(Azure.ResourceManager.Terraform.Models.TargetTerraformProvider? targetProvider = default(Azure.ResourceManager.Terraform.Models.TargetTerraformProvider?), bool? isOutputFullPropertiesEnabled = default(bool?), bool? isMaskSensitiveEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> azureResourcesToExclude = null, System.Collections.Generic.IEnumerable<string> terraformResourcesToExclude = null, string resourceGroupName = null, string namePattern = null) { throw null; }
        public static Azure.ResourceManager.Terraform.Models.TerraformExportResult TerraformExportResult(string configuration = null, string import = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> skippedResourceIds = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.ResourceManager.Terraform.Models.TerraformOperationStatus TerraformOperationStatus(Azure.ResourceManager.Terraform.Models.TerraformExportResult properties = null, Azure.ResourceManager.Terraform.Models.TerraformResourceProvisioningState status = default(Azure.ResourceManager.Terraform.Models.TerraformResourceProvisioningState), string name = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), double? percentComplete = default(double?), Azure.ResponseError error = null) { throw null; }
    }
    public abstract partial class CommonExportProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.CommonExportProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.CommonExportProperties>
    {
        protected CommonExportProperties() { }
        public System.Collections.Generic.IList<string> AzureResourcesToExclude { get { throw null; } }
        public bool? IsMaskSensitiveEnabled { get { throw null; } set { } }
        public bool? IsOutputFullPropertiesEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Terraform.Models.TargetTerraformProvider? TargetProvider { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TerraformResourcesToExclude { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.CommonExportProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.CommonExportProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.CommonExportProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.CommonExportProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.CommonExportProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.CommonExportProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.CommonExportProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportQueryTerraform : Azure.ResourceManager.Terraform.Models.CommonExportProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportQueryTerraform>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportQueryTerraform>
    {
        public ExportQueryTerraform(string query) { }
        public Azure.ResourceManager.Terraform.Models.TerraformAuthorizationScopeFilter? AuthorizationScopeFilter { get { throw null; } set { } }
        public bool? IsRecursive { get { throw null; } set { } }
        public string NamePattern { get { throw null; } set { } }
        public string Query { get { throw null; } }
        public string Table { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.ExportQueryTerraform System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportQueryTerraform>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportQueryTerraform>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.ExportQueryTerraform System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportQueryTerraform>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportQueryTerraform>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportQueryTerraform>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportResourceGroupTerraform : Azure.ResourceManager.Terraform.Models.CommonExportProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroupTerraform>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroupTerraform>
    {
        public ExportResourceGroupTerraform(string resourceGroupName) { }
        public string NamePattern { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.ExportResourceGroupTerraform System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroupTerraform>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroupTerraform>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.ExportResourceGroupTerraform System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroupTerraform>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroupTerraform>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroupTerraform>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportResourceTerraform : Azure.ResourceManager.Terraform.Models.CommonExportProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResourceTerraform>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResourceTerraform>
    {
        public ExportResourceTerraform(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceIds) { }
        public string NamePattern { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourceIds { get { throw null; } }
        public string ResourceName { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.ExportResourceTerraform System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResourceTerraform>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResourceTerraform>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.ExportResourceTerraform System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResourceTerraform>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResourceTerraform>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResourceTerraform>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TargetTerraformProvider : System.IEquatable<Azure.ResourceManager.Terraform.Models.TargetTerraformProvider>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TargetTerraformProvider(string value) { throw null; }
        public static Azure.ResourceManager.Terraform.Models.TargetTerraformProvider AzApi { get { throw null; } }
        public static Azure.ResourceManager.Terraform.Models.TargetTerraformProvider AzureRM { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Terraform.Models.TargetTerraformProvider other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Terraform.Models.TargetTerraformProvider left, Azure.ResourceManager.Terraform.Models.TargetTerraformProvider right) { throw null; }
        public static implicit operator Azure.ResourceManager.Terraform.Models.TargetTerraformProvider (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Terraform.Models.TargetTerraformProvider left, Azure.ResourceManager.Terraform.Models.TargetTerraformProvider right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TerraformAuthorizationScopeFilter : System.IEquatable<Azure.ResourceManager.Terraform.Models.TerraformAuthorizationScopeFilter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TerraformAuthorizationScopeFilter(string value) { throw null; }
        public static Azure.ResourceManager.Terraform.Models.TerraformAuthorizationScopeFilter AtScopeAboveAndBelow { get { throw null; } }
        public static Azure.ResourceManager.Terraform.Models.TerraformAuthorizationScopeFilter AtScopeAndAbove { get { throw null; } }
        public static Azure.ResourceManager.Terraform.Models.TerraformAuthorizationScopeFilter AtScopeAndBelow { get { throw null; } }
        public static Azure.ResourceManager.Terraform.Models.TerraformAuthorizationScopeFilter AtScopeExact { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Terraform.Models.TerraformAuthorizationScopeFilter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Terraform.Models.TerraformAuthorizationScopeFilter left, Azure.ResourceManager.Terraform.Models.TerraformAuthorizationScopeFilter right) { throw null; }
        public static implicit operator Azure.ResourceManager.Terraform.Models.TerraformAuthorizationScopeFilter (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Terraform.Models.TerraformAuthorizationScopeFilter left, Azure.ResourceManager.Terraform.Models.TerraformAuthorizationScopeFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TerraformExportResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.TerraformExportResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.TerraformExportResult>
    {
        internal TerraformExportResult() { }
        public string Configuration { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public string Import { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> SkippedResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.TerraformExportResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.TerraformExportResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.TerraformExportResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.TerraformExportResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.TerraformExportResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.TerraformExportResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.TerraformExportResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TerraformOperationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.TerraformOperationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.TerraformOperationStatus>
    {
        internal TerraformOperationStatus() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Name { get { throw null; } }
        public double? PercentComplete { get { throw null; } }
        public Azure.ResourceManager.Terraform.Models.TerraformExportResult Properties { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Terraform.Models.TerraformResourceProvisioningState Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.TerraformOperationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.TerraformOperationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.TerraformOperationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.TerraformOperationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.TerraformOperationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.TerraformOperationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.TerraformOperationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TerraformResourceProvisioningState : System.IEquatable<Azure.ResourceManager.Terraform.Models.TerraformResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TerraformResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Terraform.Models.TerraformResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Terraform.Models.TerraformResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Terraform.Models.TerraformResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Terraform.Models.TerraformResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Terraform.Models.TerraformResourceProvisioningState left, Azure.ResourceManager.Terraform.Models.TerraformResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Terraform.Models.TerraformResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Terraform.Models.TerraformResourceProvisioningState left, Azure.ResourceManager.Terraform.Models.TerraformResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
