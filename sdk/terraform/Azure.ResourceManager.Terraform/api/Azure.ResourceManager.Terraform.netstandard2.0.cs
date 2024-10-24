namespace Azure.ResourceManager.Terraform
{
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
        public static Azure.ResourceManager.Terraform.Models.ExportQuery ExportQuery(Azure.ResourceManager.Terraform.Models.TargetProvider? targetProvider = default(Azure.ResourceManager.Terraform.Models.TargetProvider?), bool? fullProperties = default(bool?), bool? maskSensitive = default(bool?), string query = null, string namePattern = null, bool? recursive = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Terraform.Models.ExportResourceGroup ExportResourceGroup(Azure.ResourceManager.Terraform.Models.TargetProvider? targetProvider = default(Azure.ResourceManager.Terraform.Models.TargetProvider?), bool? fullProperties = default(bool?), bool? maskSensitive = default(bool?), string resourceGroupName = null, string namePattern = null) { throw null; }
        public static Azure.ResourceManager.Terraform.Models.ExportResult ExportResult(string configuration = null, System.Collections.Generic.IEnumerable<string> skippedResources = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.ResourceManager.Terraform.Models.TerraformOperationStatus TerraformOperationStatus(Azure.ResourceManager.Terraform.Models.ExportResult properties = null, Azure.ResourceManager.Terraform.Models.ResourceProvisioningState status = default(Azure.ResourceManager.Terraform.Models.ResourceProvisioningState), string name = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), double? percentComplete = default(double?), Azure.ResponseError error = null) { throw null; }
    }
    public abstract partial class CommonExportProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.CommonExportProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.CommonExportProperties>
    {
        protected CommonExportProperties() { }
        public bool? FullProperties { get { throw null; } set { } }
        public bool? MaskSensitive { get { throw null; } set { } }
        public Azure.ResourceManager.Terraform.Models.TargetProvider? TargetProvider { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.CommonExportProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.CommonExportProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.CommonExportProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.CommonExportProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.CommonExportProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.CommonExportProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.CommonExportProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportQuery : Azure.ResourceManager.Terraform.Models.CommonExportProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportQuery>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportQuery>
    {
        public ExportQuery(string query) { }
        public string NamePattern { get { throw null; } set { } }
        public string Query { get { throw null; } }
        public bool? Recursive { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.ExportQuery System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportQuery>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportQuery>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.ExportQuery System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportQuery>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportQuery>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportQuery>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportResource : Azure.ResourceManager.Terraform.Models.CommonExportProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResource>
    {
        public ExportResource(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceIds) { }
        public string NamePattern { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourceIds { get { throw null; } }
        public string ResourceName { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.ExportResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.ExportResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportResourceGroup : Azure.ResourceManager.Terraform.Models.CommonExportProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroup>
    {
        public ExportResourceGroup(string resourceGroupName) { }
        public string NamePattern { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.ExportResourceGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.ExportResourceGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResult>
    {
        internal ExportResult() { }
        public string Configuration { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SkippedResources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.ExportResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.ExportResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.Terraform.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Terraform.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Terraform.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Terraform.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Terraform.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Terraform.Models.ResourceProvisioningState left, Azure.ResourceManager.Terraform.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Terraform.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Terraform.Models.ResourceProvisioningState left, Azure.ResourceManager.Terraform.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TargetProvider : System.IEquatable<Azure.ResourceManager.Terraform.Models.TargetProvider>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TargetProvider(string value) { throw null; }
        public static Azure.ResourceManager.Terraform.Models.TargetProvider Azapi { get { throw null; } }
        public static Azure.ResourceManager.Terraform.Models.TargetProvider Azurerm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Terraform.Models.TargetProvider other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Terraform.Models.TargetProvider left, Azure.ResourceManager.Terraform.Models.TargetProvider right) { throw null; }
        public static implicit operator Azure.ResourceManager.Terraform.Models.TargetProvider (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Terraform.Models.TargetProvider left, Azure.ResourceManager.Terraform.Models.TargetProvider right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TerraformOperationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.TerraformOperationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.TerraformOperationStatus>
    {
        internal TerraformOperationStatus() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Name { get { throw null; } }
        public double? PercentComplete { get { throw null; } }
        public Azure.ResourceManager.Terraform.Models.ExportResult Properties { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Terraform.Models.ResourceProvisioningState Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.TerraformOperationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.TerraformOperationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.TerraformOperationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.TerraformOperationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.TerraformOperationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.TerraformOperationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.TerraformOperationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
