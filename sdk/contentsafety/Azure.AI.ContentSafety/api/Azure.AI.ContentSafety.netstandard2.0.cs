namespace Azure.AI.ContentSafety
{
    public partial class AddBlockItemsOptions : System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.AddBlockItemsOptions>, System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AddBlockItemsOptions>
    {
        public AddBlockItemsOptions(System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextBlockItemInfo> blockItems) { }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.TextBlockItemInfo> BlockItems { get { throw null; } }
        Azure.AI.ContentSafety.AddBlockItemsOptions System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.AddBlockItemsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.AddBlockItemsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AddBlockItemsOptions System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AddBlockItemsOptions>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AddBlockItemsOptions>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AddBlockItemsOptions>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AddBlockItemsResult : System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.AddBlockItemsResult>, System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AddBlockItemsResult>
    {
        internal AddBlockItemsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.ContentSafety.TextBlockItem> Value { get { throw null; } }
        Azure.AI.ContentSafety.AddBlockItemsResult System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.AddBlockItemsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.AddBlockItemsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AddBlockItemsResult System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AddBlockItemsResult>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AddBlockItemsResult>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AddBlockItemsResult>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class AIContentSafetyModelFactory
    {
        public static Azure.AI.ContentSafety.AddBlockItemsResult AddBlockItemsResult(System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextBlockItem> value = null) { throw null; }
        public static Azure.AI.ContentSafety.AnalyzeImageOptions AnalyzeImageOptions(Azure.AI.ContentSafety.ContentSafetyImageData image = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.ImageCategory> categories = null) { throw null; }
        public static Azure.AI.ContentSafety.AnalyzeImageResult AnalyzeImageResult(Azure.AI.ContentSafety.ImageAnalyzeSeverityResult hateResult = null, Azure.AI.ContentSafety.ImageAnalyzeSeverityResult selfHarmResult = null, Azure.AI.ContentSafety.ImageAnalyzeSeverityResult sexualResult = null, Azure.AI.ContentSafety.ImageAnalyzeSeverityResult violenceResult = null) { throw null; }
        public static Azure.AI.ContentSafety.AnalyzeTextOptions AnalyzeTextOptions(string text = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextCategory> categories = null, System.Collections.Generic.IEnumerable<string> blocklistNames = null, bool? breakByBlocklists = default(bool?)) { throw null; }
        public static Azure.AI.ContentSafety.AnalyzeTextResult AnalyzeTextResult(System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextBlocklistMatchResult> blocklistsMatchResults = null, Azure.AI.ContentSafety.TextAnalyzeSeverityResult hateResult = null, Azure.AI.ContentSafety.TextAnalyzeSeverityResult selfHarmResult = null, Azure.AI.ContentSafety.TextAnalyzeSeverityResult sexualResult = null, Azure.AI.ContentSafety.TextAnalyzeSeverityResult violenceResult = null) { throw null; }
        public static Azure.AI.ContentSafety.ImageAnalyzeSeverityResult ImageAnalyzeSeverityResult(Azure.AI.ContentSafety.ImageCategory category = default(Azure.AI.ContentSafety.ImageCategory), int severity = 0) { throw null; }
        public static Azure.AI.ContentSafety.TextAnalyzeSeverityResult TextAnalyzeSeverityResult(Azure.AI.ContentSafety.TextCategory category = default(Azure.AI.ContentSafety.TextCategory), int severity = 0) { throw null; }
        public static Azure.AI.ContentSafety.TextBlockItem TextBlockItem(string blockItemId = null, string description = null, string text = null) { throw null; }
        public static Azure.AI.ContentSafety.TextBlockItemInfo TextBlockItemInfo(string description = null, string text = null) { throw null; }
        public static Azure.AI.ContentSafety.TextBlocklist TextBlocklist(string blocklistName = null, string description = null) { throw null; }
        public static Azure.AI.ContentSafety.TextBlocklistMatchResult TextBlocklistMatchResult(string blocklistName = null, string blockItemId = null, string blockItemText = null, int offset = 0, int length = 0) { throw null; }
    }
    public partial class AnalyzeImageOptions : System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.AnalyzeImageOptions>, System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageOptions>
    {
        public AnalyzeImageOptions(Azure.AI.ContentSafety.ContentSafetyImageData image) { }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.ImageCategory> Categories { get { throw null; } }
        public Azure.AI.ContentSafety.ContentSafetyImageData Image { get { throw null; } }
        Azure.AI.ContentSafety.AnalyzeImageOptions System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.AnalyzeImageOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.AnalyzeImageOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AnalyzeImageOptions System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageOptions>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageOptions>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageOptions>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeImageResult : System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.AnalyzeImageResult>, System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageResult>
    {
        internal AnalyzeImageResult() { }
        public Azure.AI.ContentSafety.ImageAnalyzeSeverityResult HateResult { get { throw null; } }
        public Azure.AI.ContentSafety.ImageAnalyzeSeverityResult SelfHarmResult { get { throw null; } }
        public Azure.AI.ContentSafety.ImageAnalyzeSeverityResult SexualResult { get { throw null; } }
        public Azure.AI.ContentSafety.ImageAnalyzeSeverityResult ViolenceResult { get { throw null; } }
        Azure.AI.ContentSafety.AnalyzeImageResult System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.AnalyzeImageResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.AnalyzeImageResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AnalyzeImageResult System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageResult>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageResult>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageResult>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextOptions : System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.AnalyzeTextOptions>, System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextOptions>
    {
        public AnalyzeTextOptions(string text) { }
        public System.Collections.Generic.IList<string> BlocklistNames { get { throw null; } }
        public bool? BreakByBlocklists { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.TextCategory> Categories { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.ContentSafety.AnalyzeTextOptions System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.AnalyzeTextOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.AnalyzeTextOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AnalyzeTextOptions System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextOptions>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextOptions>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextOptions>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextResult : System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.AnalyzeTextResult>, System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextResult>
    {
        internal AnalyzeTextResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.ContentSafety.TextBlocklistMatchResult> BlocklistsMatchResults { get { throw null; } }
        public Azure.AI.ContentSafety.TextAnalyzeSeverityResult HateResult { get { throw null; } }
        public Azure.AI.ContentSafety.TextAnalyzeSeverityResult SelfHarmResult { get { throw null; } }
        public Azure.AI.ContentSafety.TextAnalyzeSeverityResult SexualResult { get { throw null; } }
        public Azure.AI.ContentSafety.TextAnalyzeSeverityResult ViolenceResult { get { throw null; } }
        Azure.AI.ContentSafety.AnalyzeTextResult System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.AnalyzeTextResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.AnalyzeTextResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AnalyzeTextResult System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextResult>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextResult>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextResult>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentSafetyClient
    {
        protected ContentSafetyClient() { }
        public ContentSafetyClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ContentSafetyClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.ContentSafety.ContentSafetyClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.ContentSafety.AddBlockItemsResult> AddBlockItems(string blocklistName, Azure.AI.ContentSafety.AddBlockItemsOptions addBlockItemsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddBlockItems(string blocklistName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.AddBlockItemsResult>> AddBlockItemsAsync(string blocklistName, Azure.AI.ContentSafety.AddBlockItemsOptions addBlockItemsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddBlockItemsAsync(string blocklistName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.AnalyzeImageResult> AnalyzeImage(Azure.AI.ContentSafety.AnalyzeImageOptions body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AnalyzeImage(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.AnalyzeImageResult>> AnalyzeImageAsync(Azure.AI.ContentSafety.AnalyzeImageOptions body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AnalyzeImageAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.AnalyzeTextResult> AnalyzeText(Azure.AI.ContentSafety.AnalyzeTextOptions body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AnalyzeText(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.AnalyzeTextResult>> AnalyzeTextAsync(Azure.AI.ContentSafety.AnalyzeTextOptions body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AnalyzeTextAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateTextBlocklist(string blocklistName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateTextBlocklistAsync(string blocklistName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTextBlocklist(string blocklistName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTextBlocklistAsync(string blocklistName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTextBlocklist(string blocklistName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.TextBlocklist> GetTextBlocklist(string blocklistName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTextBlocklistAsync(string blocklistName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.TextBlocklist>> GetTextBlocklistAsync(string blocklistName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTextBlocklistItem(string blocklistName, string blockItemId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.TextBlockItem> GetTextBlocklistItem(string blocklistName, string blockItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTextBlocklistItemAsync(string blocklistName, string blockItemId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.TextBlockItem>> GetTextBlocklistItemAsync(string blocklistName, string blockItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTextBlocklistItems(string blocklistName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.ContentSafety.TextBlockItem> GetTextBlocklistItems(string blocklistName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTextBlocklistItemsAsync(string blocklistName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.ContentSafety.TextBlockItem> GetTextBlocklistItemsAsync(string blocklistName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTextBlocklists(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.ContentSafety.TextBlocklist> GetTextBlocklists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTextBlocklistsAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.ContentSafety.TextBlocklist> GetTextBlocklistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveBlockItems(string blocklistName, Azure.AI.ContentSafety.RemoveBlockItemsOptions removeBlockItemsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveBlockItems(string blocklistName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveBlockItemsAsync(string blocklistName, Azure.AI.ContentSafety.RemoveBlockItemsOptions removeBlockItemsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveBlockItemsAsync(string blocklistName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ContentSafetyClientOptions : Azure.Core.ClientOptions
    {
        public ContentSafetyClientOptions(Azure.AI.ContentSafety.ContentSafetyClientOptions.ServiceVersion version = Azure.AI.ContentSafety.ContentSafetyClientOptions.ServiceVersion.V2023_04_30_Preview) { }
        public enum ServiceVersion
        {
            V2023_04_30_Preview = 1,
        }
    }
    public partial class ContentSafetyImageData : System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.ContentSafetyImageData>, System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.ContentSafetyImageData>
    {
        public ContentSafetyImageData() { }
        public System.Uri BlobUrl { get { throw null; } set { } }
        public System.BinaryData Content { get { throw null; } set { } }
        Azure.AI.ContentSafety.ContentSafetyImageData System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.ContentSafetyImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.ContentSafetyImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.ContentSafetyImageData System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.ContentSafetyImageData>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.ContentSafetyImageData>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.ContentSafetyImageData>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageAnalyzeSeverityResult : System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.ImageAnalyzeSeverityResult>, System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.ImageAnalyzeSeverityResult>
    {
        internal ImageAnalyzeSeverityResult() { }
        public Azure.AI.ContentSafety.ImageCategory Category { get { throw null; } }
        public int Severity { get { throw null; } }
        Azure.AI.ContentSafety.ImageAnalyzeSeverityResult System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.ImageAnalyzeSeverityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.ImageAnalyzeSeverityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.ImageAnalyzeSeverityResult System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.ImageAnalyzeSeverityResult>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.ImageAnalyzeSeverityResult>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.ImageAnalyzeSeverityResult>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
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
    public partial class RemoveBlockItemsOptions : System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.RemoveBlockItemsOptions>, System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.RemoveBlockItemsOptions>
    {
        public RemoveBlockItemsOptions(System.Collections.Generic.IEnumerable<string> blockItemIds) { }
        public System.Collections.Generic.IList<string> BlockItemIds { get { throw null; } }
        Azure.AI.ContentSafety.RemoveBlockItemsOptions System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.RemoveBlockItemsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.RemoveBlockItemsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.RemoveBlockItemsOptions System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.RemoveBlockItemsOptions>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.RemoveBlockItemsOptions>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.RemoveBlockItemsOptions>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAnalyzeSeverityResult : System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.TextAnalyzeSeverityResult>, System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.TextAnalyzeSeverityResult>
    {
        internal TextAnalyzeSeverityResult() { }
        public Azure.AI.ContentSafety.TextCategory Category { get { throw null; } }
        public int Severity { get { throw null; } }
        Azure.AI.ContentSafety.TextAnalyzeSeverityResult System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.TextAnalyzeSeverityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.TextAnalyzeSeverityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.TextAnalyzeSeverityResult System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.TextAnalyzeSeverityResult>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.TextAnalyzeSeverityResult>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.TextAnalyzeSeverityResult>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextBlockItem : System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.TextBlockItem>, System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.TextBlockItem>
    {
        internal TextBlockItem() { }
        public string BlockItemId { get { throw null; } }
        public string Description { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.ContentSafety.TextBlockItem System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.TextBlockItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.TextBlockItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.TextBlockItem System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.TextBlockItem>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.TextBlockItem>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.TextBlockItem>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextBlockItemInfo : System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.TextBlockItemInfo>, System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.TextBlockItemInfo>
    {
        public TextBlockItemInfo(string text) { }
        public string Description { get { throw null; } set { } }
        public string Text { get { throw null; } }
        Azure.AI.ContentSafety.TextBlockItemInfo System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.TextBlockItemInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.TextBlockItemInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.TextBlockItemInfo System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.TextBlockItemInfo>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.TextBlockItemInfo>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.TextBlockItemInfo>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextBlocklist : System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.TextBlocklist>, System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.TextBlocklist>
    {
        internal TextBlocklist() { }
        public string BlocklistName { get { throw null; } }
        public string Description { get { throw null; } }
        Azure.AI.ContentSafety.TextBlocklist System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.TextBlocklist>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.TextBlocklist>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.TextBlocklist System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.TextBlocklist>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.TextBlocklist>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.TextBlocklist>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextBlocklistMatchResult : System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.TextBlocklistMatchResult>, System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.TextBlocklistMatchResult>
    {
        internal TextBlocklistMatchResult() { }
        public string BlockItemId { get { throw null; } }
        public string BlockItemText { get { throw null; } }
        public string BlocklistName { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        Azure.AI.ContentSafety.TextBlocklistMatchResult System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.TextBlocklistMatchResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.AI.ContentSafety.TextBlocklistMatchResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.TextBlocklistMatchResult System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.TextBlocklistMatchResult>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.TextBlocklistMatchResult>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.AI.ContentSafety.TextBlocklistMatchResult>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
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
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AIContentSafetyClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.ContentSafetyClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddContentSafetyClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.ContentSafetyClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddContentSafetyClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
