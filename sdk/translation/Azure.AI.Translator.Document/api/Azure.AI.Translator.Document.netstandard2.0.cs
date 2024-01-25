namespace Azure.AI.Translator.Document
{
    public partial class DocumentContent
    {
        public DocumentContent(Azure.AI.Translator.Document.MultipartFormFileData document) { }
        public Azure.AI.Translator.Document.MultipartFormFileData Document { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Translator.Document.MultipartFormFileData> Glossary { get { throw null; } }
        public Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class DocumentTranslationClient
    {
        protected DocumentTranslationClient() { }
        public DocumentTranslationClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public DocumentTranslationClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Translator.Document.DocumentTranslationClientOptions options) { }
        public DocumentTranslationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DocumentTranslationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Translator.Document.DocumentTranslationClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<System.BinaryData> DocumentTranslate(string targetLanguage, Azure.AI.Translator.Document.DocumentContent sourceDocument, string sourceLanguage = null, string category = null, bool? allowFallback = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> DocumentTranslateAsync(string targetLanguage, Azure.AI.Translator.Document.DocumentContent sourceDocument, string sourceLanguage = null, string category = null, bool? allowFallback = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DocumentTranslationClientOptions : Azure.Core.ClientOptions
    {
        public DocumentTranslationClientOptions(Azure.AI.Translator.Document.DocumentTranslationClientOptions.ServiceVersion version = Azure.AI.Translator.Document.DocumentTranslationClientOptions.ServiceVersion.V2023_11_01_Preview) { }
        public enum ServiceVersion
        {
            V2023_11_01_Preview = 1,
        }
    }
    public partial class MultipartFormFileData
    {
        public MultipartFormFileData(string name, System.BinaryData content, string contentType) { }
        public MultipartFormFileData(string name, System.BinaryData content, string contentType, System.Collections.Generic.IDictionary<string, string> headers) { }
        public System.BinaryData Content { get { throw null; } }
        public string ContentType { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Headers { get { throw null; } }
        public string Name { get { throw null; } }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AITranslatorDocumentClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translator.Document.DocumentTranslationClient, Azure.AI.Translator.Document.DocumentTranslationClientOptions> AddDocumentTranslationClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translator.Document.DocumentTranslationClient, Azure.AI.Translator.Document.DocumentTranslationClientOptions> AddDocumentTranslationClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translator.Document.DocumentTranslationClient, Azure.AI.Translator.Document.DocumentTranslationClientOptions> AddDocumentTranslationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
