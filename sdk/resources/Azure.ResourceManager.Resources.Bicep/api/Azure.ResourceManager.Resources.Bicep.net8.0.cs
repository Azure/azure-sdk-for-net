namespace Azure.ResourceManager.Resources.Bicep
{
    public partial class AzureResourceManagerResourcesBicepContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerResourcesBicepContext() { }
        public static Azure.ResourceManager.Resources.Bicep.AzureResourceManagerResourcesBicepContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ResourcesBicepExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationSuccessResponse> BicepDecompileOperationGroup(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationSuccessResponse>> BicepDecompileOperationGroupAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.Bicep.Mocking
{
    public partial class MockableResourcesBicepSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesBicepSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationSuccessResponse> BicepDecompileOperationGroup(Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationSuccessResponse>> BicepDecompileOperationGroupAsync(Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.Bicep.Models
{
    public static partial class ArmResourcesBicepModelFactory
    {
        public static Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationSuccessResponse DecompileOperationSuccessResponse(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Bicep.Models.FileDefinition> files = null, string entryPoint = null) { throw null; }
        public static Azure.ResourceManager.Resources.Bicep.Models.FileDefinition FileDefinition(string path = null, string contents = null) { throw null; }
    }
    public partial class DecompileOperationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationContent>
    {
        public DecompileOperationContent(string template) { }
        public string Template { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DecompileOperationSuccessResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationSuccessResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationSuccessResponse>
    {
        internal DecompileOperationSuccessResponse() { }
        public string EntryPoint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Bicep.Models.FileDefinition> Files { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationSuccessResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationSuccessResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationSuccessResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationSuccessResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationSuccessResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationSuccessResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Bicep.Models.DecompileOperationSuccessResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Bicep.Models.FileDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Bicep.Models.FileDefinition>
    {
        internal FileDefinition() { }
        public string Contents { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Bicep.Models.FileDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Bicep.Models.FileDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Bicep.Models.FileDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Bicep.Models.FileDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Bicep.Models.FileDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Bicep.Models.FileDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Bicep.Models.FileDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
