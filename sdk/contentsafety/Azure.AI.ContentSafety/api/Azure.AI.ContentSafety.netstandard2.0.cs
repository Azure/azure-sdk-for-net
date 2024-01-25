namespace Azure.AI.ContentSafety
{
    public partial class AddOrUpdateTextBlocklistItemsOptions
    {
        public AddOrUpdateTextBlocklistItemsOptions(System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextBlocklistItem> blocklistItems) { }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.TextBlocklistItem> BlocklistItems { get { throw null; } }
    }
    public partial class AddOrUpdateTextBlocklistItemsResult
    {
        internal AddOrUpdateTextBlocklistItemsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.ContentSafety.TextBlocklistItem> BlocklistItems { get { throw null; } }
    }
    public partial class AnalyzeImageOptions
    {
        public AnalyzeImageOptions(Azure.AI.ContentSafety.ContentSafetyImageData image) { }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.ImageCategory> Categories { get { throw null; } }
        public Azure.AI.ContentSafety.ContentSafetyImageData Image { get { throw null; } }
        public Azure.AI.ContentSafety.AnalyzeImageOutputType? OutputType { get { throw null; } set { } }
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
    public partial class AnalyzeImageResult
    {
        internal AnalyzeImageResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.ContentSafety.ImageCategoriesAnalysis> CategoriesAnalysis { get { throw null; } }
    }
    public partial class AnalyzeTextOptions
    {
        public AnalyzeTextOptions(string text) { }
        public System.Collections.Generic.IList<string> BlocklistNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.TextCategory> Categories { get { throw null; } }
        public bool? HaltOnBlocklistHit { get { throw null; } set { } }
        public Azure.AI.ContentSafety.AnalyzeTextOutputType? OutputType { get { throw null; } set { } }
        public string Text { get { throw null; } }
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
    public partial class AnalyzeTextResult
    {
        internal AnalyzeTextResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.ContentSafety.TextBlocklistMatch> BlocklistsMatch { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.ContentSafety.TextCategoriesAnalysis> CategoriesAnalysis { get { throw null; } }
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
    }
    public partial class ContentSafetyClientOptions : Azure.Core.ClientOptions
    {
        public ContentSafetyClientOptions(Azure.AI.ContentSafety.ContentSafetyClientOptions.ServiceVersion version = Azure.AI.ContentSafety.ContentSafetyClientOptions.ServiceVersion.V2023_10_01) { }
        public enum ServiceVersion
        {
            V2023_10_01 = 1,
        }
    }
    public partial class ContentSafetyImageData
    {
        public ContentSafetyImageData() { }
        public ContentSafetyImageData(System.BinaryData content) { }
        public ContentSafetyImageData(System.Uri blobUri) { }
    }
    public static partial class ContentSafetyModelFactory
    {
        public static Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult AddOrUpdateTextBlocklistItemsResult(System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextBlocklistItem> blocklistItems = null) { throw null; }
        public static Azure.AI.ContentSafety.AnalyzeImageResult AnalyzeImageResult(System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.ImageCategoriesAnalysis> categoriesAnalysis = null) { throw null; }
        public static Azure.AI.ContentSafety.AnalyzeTextResult AnalyzeTextResult(System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextBlocklistMatch> blocklistsMatch = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextCategoriesAnalysis> categoriesAnalysis = null) { throw null; }
        public static Azure.AI.ContentSafety.ImageCategoriesAnalysis ImageCategoriesAnalysis(Azure.AI.ContentSafety.ImageCategory category = default(Azure.AI.ContentSafety.ImageCategory), int? severity = default(int?)) { throw null; }
        public static Azure.AI.ContentSafety.TextBlocklist TextBlocklist(string name = null, string description = null) { throw null; }
        public static Azure.AI.ContentSafety.TextBlocklistItem TextBlocklistItem(string blocklistItemId = null, string description = null, string text = null) { throw null; }
        public static Azure.AI.ContentSafety.TextBlocklistMatch TextBlocklistMatch(string blocklistName = null, string blocklistItemId = null, string blocklistItemText = null) { throw null; }
        public static Azure.AI.ContentSafety.TextCategoriesAnalysis TextCategoriesAnalysis(Azure.AI.ContentSafety.TextCategory category = default(Azure.AI.ContentSafety.TextCategory), int? severity = default(int?)) { throw null; }
    }
    public partial class ImageCategoriesAnalysis
    {
        internal ImageCategoriesAnalysis() { }
        public Azure.AI.ContentSafety.ImageCategory Category { get { throw null; } }
        public int? Severity { get { throw null; } }
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
    public partial class RemoveTextBlocklistItemsOptions
    {
        public RemoveTextBlocklistItemsOptions(System.Collections.Generic.IEnumerable<string> blocklistItemIds) { }
        public System.Collections.Generic.IList<string> BlocklistItemIds { get { throw null; } }
    }
    public partial class TextBlocklist
    {
        internal TextBlocklist() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class TextBlocklistItem
    {
        public TextBlocklistItem(string text) { }
        public string BlocklistItemId { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
    }
    public partial class TextBlocklistMatch
    {
        internal TextBlocklistMatch() { }
        public string BlocklistItemId { get { throw null; } }
        public string BlocklistItemText { get { throw null; } }
        public string BlocklistName { get { throw null; } }
    }
    public partial class TextCategoriesAnalysis
    {
        internal TextCategoriesAnalysis() { }
        public Azure.AI.ContentSafety.TextCategory Category { get { throw null; } }
        public int? Severity { get { throw null; } }
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
    public static partial class ContentSafetyClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.BlocklistClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddBlocklistClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.BlocklistClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddBlocklistClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.BlocklistClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddBlocklistClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.ContentSafetyClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddContentSafetyClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.ContentSafetyClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddContentSafetyClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.ContentSafetyClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddContentSafetyClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
