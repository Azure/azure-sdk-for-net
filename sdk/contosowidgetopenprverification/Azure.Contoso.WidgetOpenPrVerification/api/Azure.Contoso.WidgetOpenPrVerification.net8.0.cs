namespace Azure.Contoso.WidgetOpenPrVerification
{
    public partial class AzureContosoWidgetOpenPrVerificationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureContosoWidgetOpenPrVerificationContext() { }
        public static Azure.Contoso.WidgetOpenPrVerification.AzureContosoWidgetOpenPrVerificationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ContosoWidgets
    {
        protected ContosoWidgets() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> CreateOrUpdateWidget(Azure.WaitUntil waitUntil, string widgetName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateOrUpdateWidgetAsync(Azure.WaitUntil waitUntil, string widgetName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeleteWidget(Azure.WaitUntil waitUntil, string widgetName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation<Azure.Contoso.WidgetOpenPrVerification.WidgetSuite> DeleteWidget(Azure.WaitUntil waitUntil, string widgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteWidgetAsync(Azure.WaitUntil waitUntil, string widgetName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.Contoso.WidgetOpenPrVerification.WidgetSuite>> DeleteWidgetAsync(Azure.WaitUntil waitUntil, string widgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetWidget(string widgetName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Contoso.WidgetOpenPrVerification.WidgetSuite> GetWidget(string widgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWidgetAsync(string widgetName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Contoso.WidgetOpenPrVerification.WidgetSuite>> GetWidgetAsync(string widgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetWidgetOperationStatus(string widgetName, string operationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Contoso.WidgetOpenPrVerification.ResourceOperationStatusWidgetSuiteWidgetSuiteError> GetWidgetOperationStatus(string widgetName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWidgetOperationStatusAsync(string widgetName, string operationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Contoso.WidgetOpenPrVerification.ResourceOperationStatusWidgetSuiteWidgetSuiteError>> GetWidgetOperationStatusAsync(string widgetName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetWidgets(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Contoso.WidgetOpenPrVerification.WidgetSuite> GetWidgets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetWidgetsAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Contoso.WidgetOpenPrVerification.WidgetSuite> GetWidgetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FakedSharedModel : System.ClientModel.Primitives.IJsonModel<Azure.Contoso.WidgetOpenPrVerification.FakedSharedModel>, System.ClientModel.Primitives.IPersistableModel<Azure.Contoso.WidgetOpenPrVerification.FakedSharedModel>
    {
        public FakedSharedModel(string tag, System.DateTimeOffset createdOn) { }
        public System.DateTimeOffset CreatedOn { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        protected virtual Azure.Contoso.WidgetOpenPrVerification.FakedSharedModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Contoso.WidgetOpenPrVerification.FakedSharedModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Contoso.WidgetOpenPrVerification.FakedSharedModel System.ClientModel.Primitives.IJsonModel<Azure.Contoso.WidgetOpenPrVerification.FakedSharedModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Contoso.WidgetOpenPrVerification.FakedSharedModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Contoso.WidgetOpenPrVerification.FakedSharedModel System.ClientModel.Primitives.IPersistableModel<Azure.Contoso.WidgetOpenPrVerification.FakedSharedModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Contoso.WidgetOpenPrVerification.FakedSharedModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Contoso.WidgetOpenPrVerification.FakedSharedModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationState : System.IEquatable<Azure.Contoso.WidgetOpenPrVerification.OperationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationState(string value) { throw null; }
        public static Azure.Contoso.WidgetOpenPrVerification.OperationState Canceled { get { throw null; } }
        public static Azure.Contoso.WidgetOpenPrVerification.OperationState Failed { get { throw null; } }
        public static Azure.Contoso.WidgetOpenPrVerification.OperationState NotStarted { get { throw null; } }
        public static Azure.Contoso.WidgetOpenPrVerification.OperationState Running { get { throw null; } }
        public static Azure.Contoso.WidgetOpenPrVerification.OperationState Succeeded { get { throw null; } }
        public bool Equals(Azure.Contoso.WidgetOpenPrVerification.OperationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Contoso.WidgetOpenPrVerification.OperationState left, Azure.Contoso.WidgetOpenPrVerification.OperationState right) { throw null; }
        public static implicit operator Azure.Contoso.WidgetOpenPrVerification.OperationState (string value) { throw null; }
        public static implicit operator Azure.Contoso.WidgetOpenPrVerification.OperationState? (string value) { throw null; }
        public static bool operator !=(Azure.Contoso.WidgetOpenPrVerification.OperationState left, Azure.Contoso.WidgetOpenPrVerification.OperationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceOperationStatusWidgetSuiteWidgetSuiteError : System.ClientModel.Primitives.IJsonModel<Azure.Contoso.WidgetOpenPrVerification.ResourceOperationStatusWidgetSuiteWidgetSuiteError>, System.ClientModel.Primitives.IPersistableModel<Azure.Contoso.WidgetOpenPrVerification.ResourceOperationStatusWidgetSuiteWidgetSuiteError>
    {
        internal ResourceOperationStatusWidgetSuiteWidgetSuiteError() { }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Contoso.WidgetOpenPrVerification.WidgetSuite Result { get { throw null; } }
        public Azure.Contoso.WidgetOpenPrVerification.OperationState Status { get { throw null; } }
        protected virtual Azure.Contoso.WidgetOpenPrVerification.ResourceOperationStatusWidgetSuiteWidgetSuiteError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Contoso.WidgetOpenPrVerification.ResourceOperationStatusWidgetSuiteWidgetSuiteError (Azure.Response response) { throw null; }
        protected virtual Azure.Contoso.WidgetOpenPrVerification.ResourceOperationStatusWidgetSuiteWidgetSuiteError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Contoso.WidgetOpenPrVerification.ResourceOperationStatusWidgetSuiteWidgetSuiteError System.ClientModel.Primitives.IJsonModel<Azure.Contoso.WidgetOpenPrVerification.ResourceOperationStatusWidgetSuiteWidgetSuiteError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Contoso.WidgetOpenPrVerification.ResourceOperationStatusWidgetSuiteWidgetSuiteError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Contoso.WidgetOpenPrVerification.ResourceOperationStatusWidgetSuiteWidgetSuiteError System.ClientModel.Primitives.IPersistableModel<Azure.Contoso.WidgetOpenPrVerification.ResourceOperationStatusWidgetSuiteWidgetSuiteError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Contoso.WidgetOpenPrVerification.ResourceOperationStatusWidgetSuiteWidgetSuiteError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Contoso.WidgetOpenPrVerification.ResourceOperationStatusWidgetSuiteWidgetSuiteError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WidgetOpenPrVerificationClient
    {
        protected WidgetOpenPrVerificationClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public WidgetOpenPrVerificationClient(Azure.Contoso.WidgetOpenPrVerification.WidgetOpenPrVerificationClientSettings settings) { }
        public WidgetOpenPrVerificationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public WidgetOpenPrVerificationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Contoso.WidgetOpenPrVerification.WidgetOpenPrVerificationClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Contoso.WidgetOpenPrVerification.ContosoWidgets GetContosoWidgetsClient() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public static partial class WidgetOpenPrVerificationClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedWidgetOpenPrVerificationClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedWidgetOpenPrVerificationClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.Contoso.WidgetOpenPrVerification.WidgetOpenPrVerificationClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddWidgetOpenPrVerificationClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddWidgetOpenPrVerificationClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.Contoso.WidgetOpenPrVerification.WidgetOpenPrVerificationClientSettings> configureSettings) { throw null; }
    }
    public partial class WidgetOpenPrVerificationClientOptions : Azure.Core.ClientOptions
    {
        public WidgetOpenPrVerificationClientOptions(Azure.Contoso.WidgetOpenPrVerification.WidgetOpenPrVerificationClientOptions.ServiceVersion version = Azure.Contoso.WidgetOpenPrVerification.WidgetOpenPrVerificationClientOptions.ServiceVersion.V2022_12_01) { }
        public enum ServiceVersion
        {
            V2022_12_01 = 1,
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class WidgetOpenPrVerificationClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public WidgetOpenPrVerificationClientSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.Contoso.WidgetOpenPrVerification.WidgetOpenPrVerificationClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public static partial class WidgetOpenPrVerificationModelFactory
    {
        public static Azure.Contoso.WidgetOpenPrVerification.FakedSharedModel FakedSharedModel(string tag = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Contoso.WidgetOpenPrVerification.ResourceOperationStatusWidgetSuiteWidgetSuiteError ResourceOperationStatusWidgetSuiteWidgetSuiteError(string id = null, Azure.Contoso.WidgetOpenPrVerification.OperationState status = default(Azure.Contoso.WidgetOpenPrVerification.OperationState), Azure.ResponseError error = null, Azure.Contoso.WidgetOpenPrVerification.WidgetSuite result = null) { throw null; }
        public static Azure.Contoso.WidgetOpenPrVerification.WidgetSuite WidgetSuite(string name = null, string manufacturerId = null, Azure.Contoso.WidgetOpenPrVerification.FakedSharedModel sharedModel = null) { throw null; }
    }
    public partial class WidgetSuite : System.ClientModel.Primitives.IJsonModel<Azure.Contoso.WidgetOpenPrVerification.WidgetSuite>, System.ClientModel.Primitives.IPersistableModel<Azure.Contoso.WidgetOpenPrVerification.WidgetSuite>
    {
        public WidgetSuite(string manufacturerId) { }
        public string ManufacturerId { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.Contoso.WidgetOpenPrVerification.FakedSharedModel SharedModel { get { throw null; } set { } }
        protected virtual Azure.Contoso.WidgetOpenPrVerification.WidgetSuite JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Contoso.WidgetOpenPrVerification.WidgetSuite (Azure.Response response) { throw null; }
        protected virtual Azure.Contoso.WidgetOpenPrVerification.WidgetSuite PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Contoso.WidgetOpenPrVerification.WidgetSuite System.ClientModel.Primitives.IJsonModel<Azure.Contoso.WidgetOpenPrVerification.WidgetSuite>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Contoso.WidgetOpenPrVerification.WidgetSuite>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Contoso.WidgetOpenPrVerification.WidgetSuite System.ClientModel.Primitives.IPersistableModel<Azure.Contoso.WidgetOpenPrVerification.WidgetSuite>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Contoso.WidgetOpenPrVerification.WidgetSuite>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Contoso.WidgetOpenPrVerification.WidgetSuite>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
