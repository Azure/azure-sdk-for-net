namespace Azure.AI.ContentSafety
{
    public partial class AddOrUpdateTextBlocklistItemsOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions>
    {
        public AddOrUpdateTextBlocklistItemsOptions(System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextBlocklistItem> blocklistItems) { }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.TextBlocklistItem> BlocklistItems { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AddOrUpdateTextBlocklistItemsResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult>
    {
        internal AddOrUpdateTextBlocklistItemsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.ContentSafety.TextBlocklistItem> BlocklistItems { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeImageOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeImageOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageOptions>
    {
        public AnalyzeImageOptions(Azure.AI.ContentSafety.ContentSafetyImageData image) { }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.ImageCategory> Categories { get { throw null; } }
        public Azure.AI.ContentSafety.ContentSafetyImageData Image { get { throw null; } }
        public Azure.AI.ContentSafety.AnalyzeImageOutputType? OutputType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AnalyzeImageOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeImageOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeImageOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AnalyzeImageOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalyzeImageOutputType : System.IEquatable<Azure.AI.ContentSafety.AnalyzeImageOutputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalyzeImageOutputType(string value) { throw null; }
        public static Azure.AI.ContentSafety.AnalyzeImageOutputType FourSeverityLevels { get { throw null; } }
        public bool Equals(Azure.AI.ContentSafety.AnalyzeImageOutputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentSafety.AnalyzeImageOutputType left, Azure.AI.ContentSafety.AnalyzeImageOutputType right) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.AnalyzeImageOutputType (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentSafety.AnalyzeImageOutputType left, Azure.AI.ContentSafety.AnalyzeImageOutputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AnalyzeImageResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeImageResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageResult>
    {
        internal AnalyzeImageResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.ContentSafety.ImageCategoriesAnalysis> CategoriesAnalysis { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AnalyzeImageResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeImageResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeImageResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AnalyzeImageResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeTextOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextOptions>
    {
        public AnalyzeTextOptions(string text) { }
        public System.Collections.Generic.IList<string> BlocklistNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.TextCategory> Categories { get { throw null; } }
        public bool? HaltOnBlocklistHit { get { throw null; } set { } }
        public Azure.AI.ContentSafety.AnalyzeTextOutputType? OutputType { get { throw null; } set { } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AnalyzeTextOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeTextOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeTextOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AnalyzeTextOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalyzeTextOutputType : System.IEquatable<Azure.AI.ContentSafety.AnalyzeTextOutputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalyzeTextOutputType(string value) { throw null; }
        public static Azure.AI.ContentSafety.AnalyzeTextOutputType EightSeverityLevels { get { throw null; } }
        public static Azure.AI.ContentSafety.AnalyzeTextOutputType FourSeverityLevels { get { throw null; } }
        public bool Equals(Azure.AI.ContentSafety.AnalyzeTextOutputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentSafety.AnalyzeTextOutputType left, Azure.AI.ContentSafety.AnalyzeTextOutputType right) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.AnalyzeTextOutputType (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentSafety.AnalyzeTextOutputType left, Azure.AI.ContentSafety.AnalyzeTextOutputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AnalyzeTextResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeTextResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextResult>
    {
        internal AnalyzeTextResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.ContentSafety.TextBlocklistMatch> BlocklistsMatch { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.ContentSafety.TextCategoriesAnalysis> CategoriesAnalysis { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AnalyzeTextResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeTextResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeTextResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AnalyzeTextResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAIContentSafetyContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIContentSafetyContext() { }
        public static Azure.AI.ContentSafety.AzureAIContentSafetyContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BlocklistClient
    {
        protected BlocklistClient() { }
        public BlocklistClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public BlocklistClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.ContentSafety.ContentSafetyClientOptions options) { }
        public BlocklistClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public BlocklistClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.ContentSafety.ContentSafetyClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult> AddOrUpdateBlocklistItems(string name, Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddOrUpdateBlocklistItems(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult>> AddOrUpdateBlocklistItemsAsync(string name, Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddOrUpdateBlocklistItemsAsync(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateTextBlocklist(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateTextBlocklistAsync(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTextBlocklist(string name, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTextBlocklistAsync(string name, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTextBlocklist(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.TextBlocklist> GetTextBlocklist(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTextBlocklistAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.TextBlocklist>> GetTextBlocklistAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTextBlocklistItem(string name, string blocklistItemId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.TextBlocklistItem> GetTextBlocklistItem(string name, string blocklistItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTextBlocklistItemAsync(string name, string blocklistItemId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.TextBlocklistItem>> GetTextBlocklistItemAsync(string name, string blocklistItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTextBlocklistItems(string name, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.ContentSafety.TextBlocklistItem> GetTextBlocklistItems(string name, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTextBlocklistItemsAsync(string name, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.ContentSafety.TextBlocklistItem> GetTextBlocklistItemsAsync(string name, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTextBlocklists(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.ContentSafety.TextBlocklist> GetTextBlocklists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTextBlocklistsAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.ContentSafety.TextBlocklist> GetTextBlocklistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveBlocklistItems(string name, Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveBlocklistItems(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveBlocklistItemsAsync(string name, Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveBlocklistItemsAsync(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ContentSafetyClient
    {
        protected ContentSafetyClient() { }
        public ContentSafetyClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ContentSafetyClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.ContentSafety.ContentSafetyClientOptions options) { }
        public ContentSafetyClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ContentSafetyClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.ContentSafety.ContentSafetyClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.ContentSafety.AnalyzeImageResult> AnalyzeImage(Azure.AI.ContentSafety.AnalyzeImageOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AnalyzeImage(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.AnalyzeImageResult> AnalyzeImage(System.BinaryData content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.AnalyzeImageResult> AnalyzeImage(System.Uri blobUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.AnalyzeImageResult>> AnalyzeImageAsync(Azure.AI.ContentSafety.AnalyzeImageOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AnalyzeImageAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.AnalyzeImageResult>> AnalyzeImageAsync(System.BinaryData content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.AnalyzeImageResult>> AnalyzeImageAsync(System.Uri blobUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.AnalyzeTextResult> AnalyzeText(Azure.AI.ContentSafety.AnalyzeTextOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AnalyzeText(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.AnalyzeTextResult> AnalyzeText(string text, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.AnalyzeTextResult>> AnalyzeTextAsync(Azure.AI.ContentSafety.AnalyzeTextOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AnalyzeTextAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.AnalyzeTextResult>> AnalyzeTextAsync(string text, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.DetectTextProtectedMaterialResult> DetectTextProtectedMaterial(Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DetectTextProtectedMaterial(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.DetectTextProtectedMaterialResult>> DetectTextProtectedMaterialAsync(Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DetectTextProtectedMaterialAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.ShieldPromptResult> ShieldPrompt(Azure.AI.ContentSafety.ShieldPromptOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ShieldPrompt(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.ShieldPromptResult>> ShieldPromptAsync(Azure.AI.ContentSafety.ShieldPromptOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ShieldPromptAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ContentSafetyClientOptions : Azure.Core.ClientOptions
    {
        public ContentSafetyClientOptions(Azure.AI.ContentSafety.ContentSafetyClientOptions.ServiceVersion version = Azure.AI.ContentSafety.ContentSafetyClientOptions.ServiceVersion.V2024_09_01) { }
        public enum ServiceVersion
        {
            V2023_10_01 = 1,
            V2024_09_01 = 2,
        }
    }
    public partial class ContentSafetyImageData : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ContentSafetyImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ContentSafetyImageData>
    {
        public ContentSafetyImageData() { }
        public ContentSafetyImageData(System.BinaryData content) { }
        public ContentSafetyImageData(System.Uri blobUri) { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.ContentSafetyImageData System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ContentSafetyImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ContentSafetyImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.ContentSafetyImageData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ContentSafetyImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ContentSafetyImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ContentSafetyImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ContentSafetyModelFactory
    {
        public static Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult AddOrUpdateTextBlocklistItemsResult(System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextBlocklistItem> blocklistItems = null) { throw null; }
        public static Azure.AI.ContentSafety.AnalyzeImageOptions AnalyzeImageOptions(Azure.AI.ContentSafety.ContentSafetyImageData image = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.ImageCategory> categories = null, Azure.AI.ContentSafety.AnalyzeImageOutputType? outputType = default(Azure.AI.ContentSafety.AnalyzeImageOutputType?)) { throw null; }
        public static Azure.AI.ContentSafety.AnalyzeImageResult AnalyzeImageResult(System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.ImageCategoriesAnalysis> categoriesAnalysis = null) { throw null; }
        public static Azure.AI.ContentSafety.AnalyzeTextOptions AnalyzeTextOptions(string text = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextCategory> categories = null, System.Collections.Generic.IEnumerable<string> blocklistNames = null, bool? haltOnBlocklistHit = default(bool?), Azure.AI.ContentSafety.AnalyzeTextOutputType? outputType = default(Azure.AI.ContentSafety.AnalyzeTextOutputType?)) { throw null; }
        public static Azure.AI.ContentSafety.AnalyzeTextResult AnalyzeTextResult(System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextBlocklistMatch> blocklistsMatch = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextCategoriesAnalysis> categoriesAnalysis = null) { throw null; }
        public static Azure.AI.ContentSafety.DetectTextProtectedMaterialResult DetectTextProtectedMaterialResult(Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult protectedMaterialAnalysis = null) { throw null; }
        public static Azure.AI.ContentSafety.DocumentInjectionAnalysisResult DocumentInjectionAnalysisResult(bool attackDetected = false) { throw null; }
        public static Azure.AI.ContentSafety.ImageCategoriesAnalysis ImageCategoriesAnalysis(Azure.AI.ContentSafety.ImageCategory category = default(Azure.AI.ContentSafety.ImageCategory), int? severity = default(int?)) { throw null; }
        public static Azure.AI.ContentSafety.ShieldPromptResult ShieldPromptResult(Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult userPromptAnalysis = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.DocumentInjectionAnalysisResult> documentsAnalysis = null) { throw null; }
        public static Azure.AI.ContentSafety.TextBlocklist TextBlocklist(string name = null, string description = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.ContentSafety.TextBlocklistItem TextBlocklistItem(string blocklistItemId, string description, string text) { throw null; }
        public static Azure.AI.ContentSafety.TextBlocklistItem TextBlocklistItem(string blocklistItemId = null, string description = null, string text = null, bool? isRegex = default(bool?)) { throw null; }
        public static Azure.AI.ContentSafety.TextBlocklistMatch TextBlocklistMatch(string blocklistName = null, string blocklistItemId = null, string blocklistItemText = null) { throw null; }
        public static Azure.AI.ContentSafety.TextCategoriesAnalysis TextCategoriesAnalysis(Azure.AI.ContentSafety.TextCategory category = default(Azure.AI.ContentSafety.TextCategory), int? severity = default(int?)) { throw null; }
        public static Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult TextProtectedMaterialAnalysisResult(bool detected = false) { throw null; }
        public static Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult UserPromptInjectionAnalysisResult(bool attackDetected = false) { throw null; }
    }
    public partial class DetectTextProtectedMaterialOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions>
    {
        public DetectTextProtectedMaterialOptions(string text) { }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DetectTextProtectedMaterialResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialResult>
    {
        internal DetectTextProtectedMaterialResult() { }
        public Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult ProtectedMaterialAnalysis { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.DetectTextProtectedMaterialResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.DetectTextProtectedMaterialResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentInjectionAnalysisResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DocumentInjectionAnalysisResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DocumentInjectionAnalysisResult>
    {
        internal DocumentInjectionAnalysisResult() { }
        public bool AttackDetected { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.DocumentInjectionAnalysisResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DocumentInjectionAnalysisResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DocumentInjectionAnalysisResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.DocumentInjectionAnalysisResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DocumentInjectionAnalysisResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DocumentInjectionAnalysisResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DocumentInjectionAnalysisResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageCategoriesAnalysis : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ImageCategoriesAnalysis>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ImageCategoriesAnalysis>
    {
        internal ImageCategoriesAnalysis() { }
        public Azure.AI.ContentSafety.ImageCategory Category { get { throw null; } }
        public int? Severity { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.ImageCategoriesAnalysis System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ImageCategoriesAnalysis>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ImageCategoriesAnalysis>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.ImageCategoriesAnalysis System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ImageCategoriesAnalysis>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ImageCategoriesAnalysis>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ImageCategoriesAnalysis>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageCategory : System.IEquatable<Azure.AI.ContentSafety.ImageCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageCategory(string value) { throw null; }
        public static Azure.AI.ContentSafety.ImageCategory Hate { get { throw null; } }
        public static Azure.AI.ContentSafety.ImageCategory SelfHarm { get { throw null; } }
        public static Azure.AI.ContentSafety.ImageCategory Sexual { get { throw null; } }
        public static Azure.AI.ContentSafety.ImageCategory Violence { get { throw null; } }
        public bool Equals(Azure.AI.ContentSafety.ImageCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentSafety.ImageCategory left, Azure.AI.ContentSafety.ImageCategory right) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.ImageCategory (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentSafety.ImageCategory left, Azure.AI.ContentSafety.ImageCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RemoveTextBlocklistItemsOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions>
    {
        public RemoveTextBlocklistItemsOptions(System.Collections.Generic.IEnumerable<string> blocklistItemIds) { }
        public System.Collections.Generic.IList<string> BlocklistItemIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShieldPromptOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ShieldPromptOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ShieldPromptOptions>
    {
        public ShieldPromptOptions() { }
        public System.Collections.Generic.IList<string> Documents { get { throw null; } }
        public string UserPrompt { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.ShieldPromptOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ShieldPromptOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ShieldPromptOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.ShieldPromptOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ShieldPromptOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ShieldPromptOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ShieldPromptOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShieldPromptResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ShieldPromptResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ShieldPromptResult>
    {
        internal ShieldPromptResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.ContentSafety.DocumentInjectionAnalysisResult> DocumentsAnalysis { get { throw null; } }
        public Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult UserPromptAnalysis { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.ShieldPromptResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ShieldPromptResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ShieldPromptResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.ShieldPromptResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ShieldPromptResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ShieldPromptResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ShieldPromptResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextBlocklist : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextBlocklist>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklist>
    {
        internal TextBlocklist() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.TextBlocklist System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextBlocklist>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextBlocklist>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.TextBlocklist System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklist>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklist>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklist>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextBlocklistItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextBlocklistItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklistItem>
    {
        public TextBlocklistItem(string text) { }
        public string BlocklistItemId { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsRegex { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.TextBlocklistItem System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextBlocklistItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextBlocklistItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.TextBlocklistItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklistItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklistItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklistItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextBlocklistMatch : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextBlocklistMatch>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklistMatch>
    {
        internal TextBlocklistMatch() { }
        public string BlocklistItemId { get { throw null; } }
        public string BlocklistItemText { get { throw null; } }
        public string BlocklistName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.TextBlocklistMatch System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextBlocklistMatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextBlocklistMatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.TextBlocklistMatch System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklistMatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklistMatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklistMatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextCategoriesAnalysis : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextCategoriesAnalysis>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextCategoriesAnalysis>
    {
        internal TextCategoriesAnalysis() { }
        public Azure.AI.ContentSafety.TextCategory Category { get { throw null; } }
        public int? Severity { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.TextCategoriesAnalysis System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextCategoriesAnalysis>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextCategoriesAnalysis>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.TextCategoriesAnalysis System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextCategoriesAnalysis>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextCategoriesAnalysis>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextCategoriesAnalysis>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextCategory : System.IEquatable<Azure.AI.ContentSafety.TextCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TextCategory(string value) { throw null; }
        public static Azure.AI.ContentSafety.TextCategory Hate { get { throw null; } }
        public static Azure.AI.ContentSafety.TextCategory SelfHarm { get { throw null; } }
        public static Azure.AI.ContentSafety.TextCategory Sexual { get { throw null; } }
        public static Azure.AI.ContentSafety.TextCategory Violence { get { throw null; } }
        public bool Equals(Azure.AI.ContentSafety.TextCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentSafety.TextCategory left, Azure.AI.ContentSafety.TextCategory right) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.TextCategory (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentSafety.TextCategory left, Azure.AI.ContentSafety.TextCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextProtectedMaterialAnalysisResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult>
    {
        internal TextProtectedMaterialAnalysisResult() { }
        public bool Detected { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserPromptInjectionAnalysisResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult>
    {
        internal UserPromptInjectionAnalysisResult() { }
        public bool AttackDetected { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class ContentSafetyClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.BlocklistClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddBlocklistClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.BlocklistClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddBlocklistClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.BlocklistClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddBlocklistClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.ContentSafetyClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddContentSafetyClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.ContentSafetyClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddContentSafetyClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.ContentSafetyClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddContentSafetyClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
