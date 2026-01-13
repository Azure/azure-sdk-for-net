namespace Azure.Template
{
    public partial class AzureTemplateContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureTemplateContext() { }
        public static Azure.Template.AzureTemplateContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class AzureWidgets
    {
        protected AzureWidgets() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> CreateOrUpdateWidget(Azure.WaitUntil waitUntil, string widgetName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateOrUpdateWidgetAsync(Azure.WaitUntil waitUntil, string widgetName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeleteWidget(Azure.WaitUntil waitUntil, string widgetName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation<Azure.Template.WidgetSuite> DeleteWidget(Azure.WaitUntil waitUntil, string widgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteWidgetAsync(Azure.WaitUntil waitUntil, string widgetName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.Template.WidgetSuite>> DeleteWidgetAsync(Azure.WaitUntil waitUntil, string widgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetWidget(string widgetName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Template.WidgetSuite> GetWidget(string widgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWidgetAsync(string widgetName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Template.WidgetSuite>> GetWidgetAsync(string widgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetWidgetOperationStatus(string widgetName, string operationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Template.ResourceOperationStatusWidgetSuiteWidgetSuiteError> GetWidgetOperationStatus(string widgetName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWidgetOperationStatusAsync(string widgetName, string operationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Template.ResourceOperationStatusWidgetSuiteWidgetSuiteError>> GetWidgetOperationStatusAsync(string widgetName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetWidgets(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Template.WidgetSuite> GetWidgets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetWidgetsAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Template.WidgetSuite> GetWidgetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FakedSharedModel : System.ClientModel.Primitives.IJsonModel<Azure.Template.FakedSharedModel>, System.ClientModel.Primitives.IPersistableModel<Azure.Template.FakedSharedModel>
    {
        public FakedSharedModel(string tag, System.DateTimeOffset createdAt) { }
        public System.DateTimeOffset CreatedAt { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        protected virtual Azure.Template.FakedSharedModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Template.FakedSharedModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Template.FakedSharedModel System.ClientModel.Primitives.IJsonModel<Azure.Template.FakedSharedModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Template.FakedSharedModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Template.FakedSharedModel System.ClientModel.Primitives.IPersistableModel<Azure.Template.FakedSharedModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Template.FakedSharedModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Template.FakedSharedModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationState : System.IEquatable<Azure.Template.OperationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationState(string value) { throw null; }
        public static Azure.Template.OperationState Canceled { get { throw null; } }
        public static Azure.Template.OperationState Failed { get { throw null; } }
        public static Azure.Template.OperationState NotStarted { get { throw null; } }
        public static Azure.Template.OperationState Running { get { throw null; } }
        public static Azure.Template.OperationState Succeeded { get { throw null; } }
        public bool Equals(Azure.Template.OperationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Template.OperationState left, Azure.Template.OperationState right) { throw null; }
        public static implicit operator Azure.Template.OperationState (string value) { throw null; }
        public static implicit operator Azure.Template.OperationState? (string value) { throw null; }
        public static bool operator !=(Azure.Template.OperationState left, Azure.Template.OperationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceOperationStatusWidgetSuiteWidgetSuiteError : System.ClientModel.Primitives.IJsonModel<Azure.Template.ResourceOperationStatusWidgetSuiteWidgetSuiteError>, System.ClientModel.Primitives.IPersistableModel<Azure.Template.ResourceOperationStatusWidgetSuiteWidgetSuiteError>
    {
        internal ResourceOperationStatusWidgetSuiteWidgetSuiteError() { }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Template.WidgetSuite Result { get { throw null; } }
        public Azure.Template.OperationState Status { get { throw null; } }
        protected virtual Azure.Template.ResourceOperationStatusWidgetSuiteWidgetSuiteError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Template.ResourceOperationStatusWidgetSuiteWidgetSuiteError (Azure.Response response) { throw null; }
        protected virtual Azure.Template.ResourceOperationStatusWidgetSuiteWidgetSuiteError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Template.ResourceOperationStatusWidgetSuiteWidgetSuiteError System.ClientModel.Primitives.IJsonModel<Azure.Template.ResourceOperationStatusWidgetSuiteWidgetSuiteError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Template.ResourceOperationStatusWidgetSuiteWidgetSuiteError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Template.ResourceOperationStatusWidgetSuiteWidgetSuiteError System.ClientModel.Primitives.IPersistableModel<Azure.Template.ResourceOperationStatusWidgetSuiteWidgetSuiteError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Template.ResourceOperationStatusWidgetSuiteWidgetSuiteError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Template.ResourceOperationStatusWidgetSuiteWidgetSuiteError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class TemplateModelFactory
    {
        public static Azure.Template.FakedSharedModel FakedSharedModel(string tag = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Template.ResourceOperationStatusWidgetSuiteWidgetSuiteError ResourceOperationStatusWidgetSuiteWidgetSuiteError(string id = null, Azure.Template.OperationState status = default(Azure.Template.OperationState), Azure.ResponseError error = null, Azure.Template.WidgetSuite result = null) { throw null; }
        public static Azure.Template.WidgetSuite WidgetSuite(string name = null, string manufacturerId = null, Azure.Template.FakedSharedModel sharedModel = null) { throw null; }
    }
    public partial class WidgetAnalyticsClient
    {
        protected WidgetAnalyticsClient() { }
        public WidgetAnalyticsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public WidgetAnalyticsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Template.WidgetAnalyticsClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Template.AzureWidgets GetAzureWidgetsClient() { throw null; }
    }
    public partial class WidgetAnalyticsClientOptions : Azure.Core.ClientOptions
    {
        public WidgetAnalyticsClientOptions(Azure.Template.WidgetAnalyticsClientOptions.ServiceVersion version = Azure.Template.WidgetAnalyticsClientOptions.ServiceVersion.V2022_12_01) { }
        public enum ServiceVersion
        {
            V2022_12_01 = 1,
        }
    }
    public partial class WidgetSuite : System.ClientModel.Primitives.IJsonModel<Azure.Template.WidgetSuite>, System.ClientModel.Primitives.IPersistableModel<Azure.Template.WidgetSuite>
    {
        public WidgetSuite(string manufacturerId) { }
        public string ManufacturerId { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.Template.FakedSharedModel SharedModel { get { throw null; } set { } }
        protected virtual Azure.Template.WidgetSuite JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Template.WidgetSuite (Azure.Response response) { throw null; }
        protected virtual Azure.Template.WidgetSuite PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Template.WidgetSuite System.ClientModel.Primitives.IJsonModel<Azure.Template.WidgetSuite>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Template.WidgetSuite>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Template.WidgetSuite System.ClientModel.Primitives.IPersistableModel<Azure.Template.WidgetSuite>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Template.WidgetSuite>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Template.WidgetSuite>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class TemplateClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Template.WidgetAnalyticsClient, Azure.Template.WidgetAnalyticsClientOptions> AddWidgetAnalyticsClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Template.WidgetAnalyticsClient, Azure.Template.WidgetAnalyticsClientOptions> AddWidgetAnalyticsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
