namespace Azure.AI.ContentSafety
{
    public partial class AddBlockItemsOptions
    {
        public AddBlockItemsOptions(System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextBlockItemInfo> blockItems) { }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.TextBlockItemInfo> BlockItems { get { throw null; } }
    }
    public partial class AddBlockItemsResult
    {
        internal AddBlockItemsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.ContentSafety.TextBlockItem> Value { get { throw null; } }
    }
    public static partial class AIContentSafetyModelFactory
    {
        public static Azure.AI.ContentSafety.AddBlockItemsResult AddBlockItemsResult(System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextBlockItem> value = null) { throw null; }
        public static Azure.AI.ContentSafety.AnalyzeImageResult AnalyzeImageResult(Azure.AI.ContentSafety.ImageAnalyzeSeverityResult hateResult = null, Azure.AI.ContentSafety.ImageAnalyzeSeverityResult selfHarmResult = null, Azure.AI.ContentSafety.ImageAnalyzeSeverityResult sexualResult = null, Azure.AI.ContentSafety.ImageAnalyzeSeverityResult violenceResult = null) { throw null; }
        public static Azure.AI.ContentSafety.AnalyzeTextResult AnalyzeTextResult(System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextBlocklistMatchResult> blocklistsMatchResults = null, Azure.AI.ContentSafety.TextAnalyzeSeverityResult hateResult = null, Azure.AI.ContentSafety.TextAnalyzeSeverityResult selfHarmResult = null, Azure.AI.ContentSafety.TextAnalyzeSeverityResult sexualResult = null, Azure.AI.ContentSafety.TextAnalyzeSeverityResult violenceResult = null) { throw null; }
        public static Azure.AI.ContentSafety.ImageAnalyzeSeverityResult ImageAnalyzeSeverityResult(Azure.AI.ContentSafety.ImageCategory category = default(Azure.AI.ContentSafety.ImageCategory), int severity = 0) { throw null; }
        public static Azure.AI.ContentSafety.TextAnalyzeSeverityResult TextAnalyzeSeverityResult(Azure.AI.ContentSafety.TextCategory category = default(Azure.AI.ContentSafety.TextCategory), int severity = 0) { throw null; }
        public static Azure.AI.ContentSafety.TextBlockItem TextBlockItem(string blockItemId = null, string description = null, string text = null) { throw null; }
        public static Azure.AI.ContentSafety.TextBlocklist TextBlocklist(string blocklistName = null, string description = null) { throw null; }
        public static Azure.AI.ContentSafety.TextBlocklistMatchResult TextBlocklistMatchResult(string blocklistName = null, string blockItemId = null, string blockItemText = null, int offset = 0, int length = 0) { throw null; }
    }
    public partial class AnalyzeImageOptions
    {
        public AnalyzeImageOptions(Azure.AI.ContentSafety.ContentSafetyImageData image) { }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.ImageCategory> Categories { get { throw null; } }
        public Azure.AI.ContentSafety.ContentSafetyImageData Image { get { throw null; } }
    }
    public partial class AnalyzeImageResult
    {
        internal AnalyzeImageResult() { }
        public Azure.AI.ContentSafety.ImageAnalyzeSeverityResult HateResult { get { throw null; } }
        public Azure.AI.ContentSafety.ImageAnalyzeSeverityResult SelfHarmResult { get { throw null; } }
        public Azure.AI.ContentSafety.ImageAnalyzeSeverityResult SexualResult { get { throw null; } }
        public Azure.AI.ContentSafety.ImageAnalyzeSeverityResult ViolenceResult { get { throw null; } }
    }
    public partial class AnalyzeTextOptions
    {
        public AnalyzeTextOptions(string text) { }
        public System.Collections.Generic.IList<string> BlocklistNames { get { throw null; } }
        public bool? BreakByBlocklists { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.TextCategory> Categories { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class AnalyzeTextResult
    {
        internal AnalyzeTextResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.ContentSafety.TextBlocklistMatchResult> BlocklistsMatchResults { get { throw null; } }
        public Azure.AI.ContentSafety.TextAnalyzeSeverityResult HateResult { get { throw null; } }
        public Azure.AI.ContentSafety.TextAnalyzeSeverityResult SelfHarmResult { get { throw null; } }
        public Azure.AI.ContentSafety.TextAnalyzeSeverityResult SexualResult { get { throw null; } }
        public Azure.AI.ContentSafety.TextAnalyzeSeverityResult ViolenceResult { get { throw null; } }
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
    public partial class ContentSafetyImageData
    {
        public ContentSafetyImageData() { }
        public System.Uri BlobUrl { get { throw null; } set { } }
        public System.BinaryData Content { get { throw null; } set { } }
    }
    public partial class ImageAnalyzeSeverityResult
    {
        internal ImageAnalyzeSeverityResult() { }
        public Azure.AI.ContentSafety.ImageCategory Category { get { throw null; } }
        public int Severity { get { throw null; } }
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
    public partial class RemoveBlockItemsOptions
    {
        public RemoveBlockItemsOptions(System.Collections.Generic.IEnumerable<string> blockItemIds) { }
        public System.Collections.Generic.IList<string> BlockItemIds { get { throw null; } }
    }
    public partial class TextAnalyzeSeverityResult
    {
        internal TextAnalyzeSeverityResult() { }
        public Azure.AI.ContentSafety.TextCategory Category { get { throw null; } }
        public int Severity { get { throw null; } }
    }
    public partial class TextBlockItem
    {
        internal TextBlockItem() { }
        public string BlockItemId { get { throw null; } }
        public string Description { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class TextBlockItemInfo
    {
        public TextBlockItemInfo(string text) { }
        public string Description { get { throw null; } set { } }
        public string Text { get { throw null; } }
    }
    public partial class TextBlocklist
    {
        internal TextBlocklist() { }
        public string BlocklistName { get { throw null; } }
        public string Description { get { throw null; } }
    }
    public partial class TextBlocklistMatchResult
    {
        internal TextBlocklistMatchResult() { }
        public string BlockItemId { get { throw null; } }
        public string BlockItemText { get { throw null; } }
        public string BlocklistName { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
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
