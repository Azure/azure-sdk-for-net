namespace Azure.Template.Contoso
{
    public partial class AzureTemplateContosoContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureTemplateContosoContext() { }
        public static Azure.Template.Contoso.AzureTemplateContosoContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ContosoWidgets
    {
        protected ContosoWidgets() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> CreateOrUpdateWidget(Azure.WaitUntil waitUntil, string widgetName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateOrUpdateWidgetAsync(Azure.WaitUntil waitUntil, string widgetName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeleteWidget(Azure.WaitUntil waitUntil, string widgetName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation<Azure.Template.Contoso.WidgetSuite> DeleteWidget(Azure.WaitUntil waitUntil, string widgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteWidgetAsync(Azure.WaitUntil waitUntil, string widgetName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.Template.Contoso.WidgetSuite>> DeleteWidgetAsync(Azure.WaitUntil waitUntil, string widgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetWidget(string widgetName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Template.Contoso.WidgetSuite> GetWidget(string widgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWidgetAsync(string widgetName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Template.Contoso.WidgetSuite>> GetWidgetAsync(string widgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetWidgetOperationStatus(string widgetName, string operationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Template.Contoso.ResourceOperationStatusWidgetSuiteWidgetSuiteError> GetWidgetOperationStatus(string widgetName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWidgetOperationStatusAsync(string widgetName, string operationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Template.Contoso.ResourceOperationStatusWidgetSuiteWidgetSuiteError>> GetWidgetOperationStatusAsync(string widgetName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetWidgets(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Template.Contoso.WidgetSuite> GetWidgets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetWidgetsAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Template.Contoso.WidgetSuite> GetWidgetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FakedSharedModel : System.ClientModel.Primitives.IJsonModel<Azure.Template.Contoso.FakedSharedModel>, System.ClientModel.Primitives.IPersistableModel<Azure.Template.Contoso.FakedSharedModel>
    {
        public FakedSharedModel(string tag, System.DateTimeOffset createdAt) { }
        public System.DateTimeOffset CreatedAt { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Template.Contoso.FakedSharedModel System.ClientModel.Primitives.IJsonModel<Azure.Template.Contoso.FakedSharedModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Template.Contoso.FakedSharedModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Template.Contoso.FakedSharedModel System.ClientModel.Primitives.IPersistableModel<Azure.Template.Contoso.FakedSharedModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Template.Contoso.FakedSharedModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Template.Contoso.FakedSharedModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationState : System.IEquatable<Azure.Template.Contoso.OperationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationState(string value) { throw null; }
        public static Azure.Template.Contoso.OperationState Canceled { get { throw null; } }
        public static Azure.Template.Contoso.OperationState Failed { get { throw null; } }
        public static Azure.Template.Contoso.OperationState NotStarted { get { throw null; } }
        public static Azure.Template.Contoso.OperationState Running { get { throw null; } }
        public static Azure.Template.Contoso.OperationState Succeeded { get { throw null; } }
        public bool Equals(Azure.Template.Contoso.OperationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Template.Contoso.OperationState left, Azure.Template.Contoso.OperationState right) { throw null; }
        public static implicit operator Azure.Template.Contoso.OperationState (string value) { throw null; }
        public static bool operator !=(Azure.Template.Contoso.OperationState left, Azure.Template.Contoso.OperationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceOperationStatusWidgetSuiteWidgetSuiteError : System.ClientModel.Primitives.IJsonModel<Azure.Template.Contoso.ResourceOperationStatusWidgetSuiteWidgetSuiteError>, System.ClientModel.Primitives.IPersistableModel<Azure.Template.Contoso.ResourceOperationStatusWidgetSuiteWidgetSuiteError>
    {
        internal ResourceOperationStatusWidgetSuiteWidgetSuiteError() { }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Template.Contoso.WidgetSuite Result { get { throw null; } }
        public Azure.Template.Contoso.OperationState Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Template.Contoso.ResourceOperationStatusWidgetSuiteWidgetSuiteError System.ClientModel.Primitives.IJsonModel<Azure.Template.Contoso.ResourceOperationStatusWidgetSuiteWidgetSuiteError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Template.Contoso.ResourceOperationStatusWidgetSuiteWidgetSuiteError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Template.Contoso.ResourceOperationStatusWidgetSuiteWidgetSuiteError System.ClientModel.Primitives.IPersistableModel<Azure.Template.Contoso.ResourceOperationStatusWidgetSuiteWidgetSuiteError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Template.Contoso.ResourceOperationStatusWidgetSuiteWidgetSuiteError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Template.Contoso.ResourceOperationStatusWidgetSuiteWidgetSuiteError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class TemplateContosoModelFactory
    {
        public static Azure.Template.Contoso.ResourceOperationStatusWidgetSuiteWidgetSuiteError ResourceOperationStatusWidgetSuiteWidgetSuiteError(string id = null, Azure.Template.Contoso.OperationState status = default(Azure.Template.Contoso.OperationState), Azure.ResponseError error = null, Azure.Template.Contoso.WidgetSuite result = null) { throw null; }
        public static Azure.Template.Contoso.WidgetSuite WidgetSuite(string name = null, string manufacturerId = null, Azure.Template.Contoso.FakedSharedModel sharedModel = null) { throw null; }
    }
    public partial class WidgetManagerClient
    {
        protected WidgetManagerClient() { }
        public WidgetManagerClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public WidgetManagerClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Template.Contoso.WidgetManagerClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Template.Contoso.ContosoWidgets GetContosoWidgetsClient(string apiVersion = "2022-12-01") { throw null; }
    }
    public partial class WidgetManagerClientOptions : Azure.Core.ClientOptions
    {
        public WidgetManagerClientOptions(Azure.Template.Contoso.WidgetManagerClientOptions.ServiceVersion version = Azure.Template.Contoso.WidgetManagerClientOptions.ServiceVersion.V2022_12_01) { }
        public enum ServiceVersion
        {
            V2022_12_01 = 1,
        }
    }
    public partial class WidgetSuite : System.ClientModel.Primitives.IJsonModel<Azure.Template.Contoso.WidgetSuite>, System.ClientModel.Primitives.IPersistableModel<Azure.Template.Contoso.WidgetSuite>
    {
        public WidgetSuite(string manufacturerId) { }
        public string ManufacturerId { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.Template.Contoso.FakedSharedModel SharedModel { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Template.Contoso.WidgetSuite System.ClientModel.Primitives.IJsonModel<Azure.Template.Contoso.WidgetSuite>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Template.Contoso.WidgetSuite>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Template.Contoso.WidgetSuite System.ClientModel.Primitives.IPersistableModel<Azure.Template.Contoso.WidgetSuite>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Template.Contoso.WidgetSuite>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Template.Contoso.WidgetSuite>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class TemplateContosoClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Template.Contoso.WidgetManagerClient, Azure.Template.Contoso.WidgetManagerClientOptions> AddWidgetManagerClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Template.Contoso.WidgetManagerClient, Azure.Template.Contoso.WidgetManagerClientOptions> AddWidgetManagerClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
