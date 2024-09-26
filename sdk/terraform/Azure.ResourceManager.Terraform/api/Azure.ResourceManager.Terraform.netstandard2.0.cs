namespace Azure.ResourceManager.Terraform
{
    public static partial class TerraformExtensions
    {
        public static Azure.ResourceManager.ArmOperation ExportTerraformAzureTerraformClient(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Terraform.Models.BaseExportModel exportParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExportTerraformAzureTerraformClientAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Terraform.Models.BaseExportModel exportParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation GetOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> GetOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Terraform.Mocking
{
    public partial class MockableTerraformSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableTerraformSubscriptionResource() { }
        public virtual Azure.ResourceManager.ArmOperation ExportTerraformAzureTerraformClient(Azure.WaitUntil waitUntil, Azure.ResourceManager.Terraform.Models.BaseExportModel exportParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExportTerraformAzureTerraformClientAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Terraform.Models.BaseExportModel exportParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation GetOperationStatus(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> GetOperationStatusAsync(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Terraform.Models
{
    public static partial class ArmTerraformModelFactory
    {
        public static Azure.ResourceManager.Terraform.Models.ExportQuery ExportQuery(Azure.ResourceManager.Terraform.Models.TargetProvider? targetProvider = default(Azure.ResourceManager.Terraform.Models.TargetProvider?), bool? fullProperties = default(bool?), bool? maskSensitive = default(bool?), string query = null, string namePattern = null, bool? recursive = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Terraform.Models.ExportResourceGroup ExportResourceGroup(Azure.ResourceManager.Terraform.Models.TargetProvider? targetProvider = default(Azure.ResourceManager.Terraform.Models.TargetProvider?), bool? fullProperties = default(bool?), bool? maskSensitive = default(bool?), string resourceGroupName = null, string namePattern = null) { throw null; }
    }
    public abstract partial class BaseExportModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.BaseExportModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.BaseExportModel>
    {
        protected BaseExportModel() { }
        public bool? FullProperties { get { throw null; } set { } }
        public bool? MaskSensitive { get { throw null; } set { } }
        public Azure.ResourceManager.Terraform.Models.TargetProvider? TargetProvider { get { throw null; } set { } }
        Azure.ResourceManager.Terraform.Models.BaseExportModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.BaseExportModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.BaseExportModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.BaseExportModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.BaseExportModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.BaseExportModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.BaseExportModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportQuery : Azure.ResourceManager.Terraform.Models.BaseExportModel, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportQuery>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportQuery>
    {
        public ExportQuery(string query) { }
        public string NamePattern { get { throw null; } set { } }
        public string Query { get { throw null; } }
        public bool? Recursive { get { throw null; } set { } }
        Azure.ResourceManager.Terraform.Models.ExportQuery System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportQuery>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportQuery>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.ExportQuery System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportQuery>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportQuery>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportQuery>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportResource : Azure.ResourceManager.Terraform.Models.BaseExportModel, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResource>
    {
        public ExportResource(System.Collections.Generic.IEnumerable<string> resourceIds) { }
        public string NamePattern { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ResourceIds { get { throw null; } }
        public string ResourceName { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        Azure.ResourceManager.Terraform.Models.ExportResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.ExportResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportResourceGroup : Azure.ResourceManager.Terraform.Models.BaseExportModel, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroup>
    {
        public ExportResourceGroup(string resourceGroupName) { }
        public string NamePattern { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } }
        Azure.ResourceManager.Terraform.Models.ExportResourceGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Terraform.Models.ExportResourceGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Terraform.Models.ExportResourceGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
}
