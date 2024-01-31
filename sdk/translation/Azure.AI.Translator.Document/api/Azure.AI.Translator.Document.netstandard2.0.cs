namespace Azure.AI.Translator.Document
{
    public static partial class AITranslatorDocumentModelFactory
    {
        public static Azure.AI.Translator.Document.DocumentTranslateContent DocumentTranslateContent(System.BinaryData document = null, System.Collections.Generic.IEnumerable<System.BinaryData> glossary = null) { throw null; }
    }
    public partial class DocumentTranslateContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translator.Document.DocumentTranslateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translator.Document.DocumentTranslateContent>
    {
        internal DocumentTranslateContent() { }
        public System.BinaryData Document { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Glossary { get { throw null; } }
        Azure.AI.Translator.Document.DocumentTranslateContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Translator.Document.DocumentTranslateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translator.Document.DocumentTranslateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translator.Document.DocumentTranslateContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translator.Document.DocumentTranslateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translator.Document.DocumentTranslateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translator.Document.DocumentTranslateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SingleDocumentTranslationClient
    {
        protected SingleDocumentTranslationClient() { }
        public SingleDocumentTranslationClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public SingleDocumentTranslationClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Translator.Document.SingleDocumentTranslationClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<System.BinaryData> DocumentTranslate(string targetLanguage, Azure.AI.Translator.Document.MultipartFormFileData sourceDocument, System.Collections.Generic.IEnumerable<Azure.AI.Translator.Document.MultipartFormFileData> sourceGlossaries = null, string sourceLanguage = null, string category = null, bool? allowFallback = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> DocumentTranslateAsync(string targetLanguage, Azure.AI.Translator.Document.MultipartFormFileData sourceDocument, System.Collections.Generic.IEnumerable<Azure.AI.Translator.Document.MultipartFormFileData> sourceGlossaries = null, string sourceLanguage = null, string category = null, bool? allowFallback = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SingleDocumentTranslationClientOptions : Azure.Core.ClientOptions
    {
        public SingleDocumentTranslationClientOptions(Azure.AI.Translator.Document.SingleDocumentTranslationClientOptions.ServiceVersion version = Azure.AI.Translator.Document.SingleDocumentTranslationClientOptions.ServiceVersion.V2023_11_01_Preview) { }
        public enum ServiceVersion
        {
            V2023_11_01_Preview = 1,
        }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AITranslatorDocumentClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translator.Document.SingleDocumentTranslationClient, Azure.AI.Translator.Document.SingleDocumentTranslationClientOptions> AddSingleDocumentTranslationClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translator.Document.SingleDocumentTranslationClient, Azure.AI.Translator.Document.SingleDocumentTranslationClientOptions> AddSingleDocumentTranslationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
