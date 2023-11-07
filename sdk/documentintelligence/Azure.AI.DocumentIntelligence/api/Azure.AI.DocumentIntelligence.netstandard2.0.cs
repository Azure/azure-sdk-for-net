namespace Azure.AI.DocumentIntelligence
{
    public partial class AddressValue
    {
        internal AddressValue() { }
        public string City { get { throw null; } }
        public string CityDistrict { get { throw null; } }
        public string CountryRegion { get { throw null; } }
        public string House { get { throw null; } }
        public string HouseNumber { get { throw null; } }
        public string Level { get { throw null; } }
        public string PoBox { get { throw null; } }
        public string PostalCode { get { throw null; } }
        public string Road { get { throw null; } }
        public string State { get { throw null; } }
        public string StateDistrict { get { throw null; } }
        public string StreetAddress { get { throw null; } }
        public string Suburb { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public static partial class AIDocumentIntelligenceModelFactory
    {
        public static Azure.AI.DocumentIntelligence.ChatIndexBuildOperationDetails ChatIndexBuildOperationDetails(System.Guid operationId = default(System.Guid), Azure.AI.DocumentIntelligence.OperationStatus status = default(Azure.AI.DocumentIntelligence.OperationStatus), int? percentCompleted = default(int?), System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.Uri resourceLocation = null, string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceError error = null, Azure.AI.DocumentIntelligence.ChatIndexDetails result = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.ChatIndexDetails ChatIndexDetails(string chatId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset expirationDateTime = default(System.DateTimeOffset), string apiVersion = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.CustomDocumentModelsDetails CustomDocumentModelsDetails(int count = 0, int limit = 0) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails DocumentClassifierBuildOperationDetails(System.Guid operationId = default(System.Guid), Azure.AI.DocumentIntelligence.OperationStatus status = default(Azure.AI.DocumentIntelligence.OperationStatus), int? percentCompleted = default(int?), System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.Uri resourceLocation = null, string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceError error = null, Azure.AI.DocumentIntelligence.DocumentClassifierDetails result = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentClassifierDetails DocumentClassifierDetails(string classifierId = null, string description = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails> docTypes = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentFieldSchema DocumentFieldSchema(Azure.AI.DocumentIntelligence.DocumentFieldType type = default(Azure.AI.DocumentIntelligence.DocumentFieldType), string description = null, string example = null, Azure.AI.DocumentIntelligence.DocumentFieldSchema items = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentFieldSchema> properties = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentIntelligenceError DocumentIntelligenceError(string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentIntelligenceError> details = null, Azure.AI.DocumentIntelligence.InnerError innererror = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails DocumentModelBuildOperationDetails(System.Guid operationId = default(System.Guid), Azure.AI.DocumentIntelligence.OperationStatus status = default(Azure.AI.DocumentIntelligence.OperationStatus), int? percentCompleted = default(int?), System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.Uri resourceLocation = null, string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceError error = null, Azure.AI.DocumentIntelligence.DocumentModelDetails result = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails DocumentModelComposeOperationDetails(System.Guid operationId = default(System.Guid), Azure.AI.DocumentIntelligence.OperationStatus status = default(Azure.AI.DocumentIntelligence.OperationStatus), int? percentCompleted = default(int?), System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.Uri resourceLocation = null, string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceError error = null, Azure.AI.DocumentIntelligence.DocumentModelDetails result = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentModelCopyToOperationDetails DocumentModelCopyToOperationDetails(System.Guid operationId = default(System.Guid), Azure.AI.DocumentIntelligence.OperationStatus status = default(Azure.AI.DocumentIntelligence.OperationStatus), int? percentCompleted = default(int?), System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.Uri resourceLocation = null, string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceError error = null, Azure.AI.DocumentIntelligence.DocumentModelDetails result = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentModelDetails DocumentModelDetails(string modelId = null, string description = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.AI.DocumentIntelligence.DocumentBuildMode buildMode = default(Azure.AI.DocumentIntelligence.DocumentBuildMode), Azure.AI.DocumentIntelligence.AzureBlobContentSource azureBlobSource = null, Azure.AI.DocumentIntelligence.AzureBlobFileListContentSource azureBlobFileListSource = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentTypeDetails> docTypes = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentModelSummary DocumentModelSummary(string modelId = null, string description = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentTypeDetails DocumentTypeDetails(string description = null, Azure.AI.DocumentIntelligence.DocumentBuildMode? buildMode = default(Azure.AI.DocumentIntelligence.DocumentBuildMode?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentFieldSchema> fieldSchema = null, System.Collections.Generic.IReadOnlyDictionary<string, float> fieldConfidence = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.InnerError InnerError(string code = null, string message = null, Azure.AI.DocumentIntelligence.InnerError innererror = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.OperationDetails OperationDetails(System.Guid operationId = default(System.Guid), Azure.AI.DocumentIntelligence.OperationStatus status = default(Azure.AI.DocumentIntelligence.OperationStatus), int? percentCompleted = default(int?), System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), string kind = "Unknown", System.Uri resourceLocation = null, string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceError error = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.OperationSummary OperationSummary(System.Guid operationId = default(System.Guid), Azure.AI.DocumentIntelligence.OperationStatus status = default(Azure.AI.DocumentIntelligence.OperationStatus), int? percentCompleted = default(int?), System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), Azure.AI.DocumentIntelligence.OperationKind kind = default(Azure.AI.DocumentIntelligence.OperationKind), System.Uri resourceLocation = null, string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.QuotaDetails QuotaDetails(int used = 0, int quota = 0, System.DateTimeOffset quotaResetDateTime = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.DocumentIntelligence.ResourceDetails ResourceDetails(Azure.AI.DocumentIntelligence.CustomDocumentModelsDetails customDocumentModels = null, Azure.AI.DocumentIntelligence.QuotaDetails customNeuralDocumentModelBuilds = null) { throw null; }
    }
    public partial class AnalyzedDocument
    {
        internal AnalyzedDocument() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public float Confidence { get { throw null; } }
        public string DocType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentField> Fields { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class AnalyzeDocumentRequest
    {
        public AnalyzeDocumentRequest() { }
        public System.BinaryData Base64Source { get { throw null; } set { } }
        public System.Uri UrlSource { get { throw null; } set { } }
    }
    public partial class AnalyzeResult
    {
        internal AnalyzeResult() { }
        public string ApiVersion { get { throw null; } }
        public string Content { get { throw null; } }
        public Azure.AI.DocumentIntelligence.ContentFormat? ContentFormat { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.AnalyzedDocument> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentFigure> Figures { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentKeyValuePair> KeyValuePairs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentLanguage> Languages { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentList> Lists { get { throw null; } }
        public string ModelId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentPage> Pages { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentParagraph> Paragraphs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSection> Sections { get { throw null; } }
        public Azure.AI.DocumentIntelligence.StringIndexType StringIndexType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentStyle> Styles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentTable> Tables { get { throw null; } }
    }
    public partial class AuthorizeCopyRequest
    {
        public AuthorizeCopyRequest(string modelId) { }
        public string Description { get { throw null; } set { } }
        public string ModelId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AzureAIDocumentIntelligenceClientOptions : Azure.Core.ClientOptions
    {
        public AzureAIDocumentIntelligenceClientOptions(Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceClientOptions.ServiceVersion version = Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceClientOptions.ServiceVersion.V2023_10_31_Preview) { }
        public enum ServiceVersion
        {
            V2022_08_31 = 1,
            V2023_07_31 = 2,
            V2023_10_31_Preview = 3,
        }
    }
    public partial class AzureBlobContentSource
    {
        public AzureBlobContentSource(System.Uri containerUrl) { }
        public System.Uri ContainerUrl { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
    }
    public partial class AzureBlobFileListContentSource
    {
        public AzureBlobFileListContentSource(System.Uri containerUrl, string fileList) { }
        public System.Uri ContainerUrl { get { throw null; } set { } }
        public string FileList { get { throw null; } set { } }
    }
    public partial class BoundingRegion
    {
        internal BoundingRegion() { }
        public int PageNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> Polygon { get { throw null; } }
    }
    public partial class BuildDocumentClassifierRequest
    {
        public BuildDocumentClassifierRequest(string classifierId, System.Collections.Generic.IDictionary<string, Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails> docTypes) { }
        public string ClassifierId { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails> DocTypes { get { throw null; } }
    }
    public partial class BuildDocumentModelRequest
    {
        public BuildDocumentModelRequest(string modelId, Azure.AI.DocumentIntelligence.DocumentBuildMode buildMode) { }
        public Azure.AI.DocumentIntelligence.AzureBlobFileListContentSource AzureBlobFileListSource { get { throw null; } set { } }
        public Azure.AI.DocumentIntelligence.AzureBlobContentSource AzureBlobSource { get { throw null; } set { } }
        public Azure.AI.DocumentIntelligence.DocumentBuildMode BuildMode { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string ModelId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ChatIndexBuildOperationDetails : Azure.AI.DocumentIntelligence.OperationDetails
    {
        internal ChatIndexBuildOperationDetails() : base (default(Azure.AI.DocumentIntelligence.OperationStatus), default(System.DateTimeOffset), default(System.DateTimeOffset), default(System.Uri)) { }
        public Azure.AI.DocumentIntelligence.ChatIndexDetails Result { get { throw null; } }
    }
    public partial class ChatIndexDetails : Azure.AI.DocumentIntelligence.ChatIndexSummary
    {
        internal ChatIndexDetails() { }
    }
    public partial class ChatIndexSummary
    {
        internal ChatIndexSummary() { }
        public string ApiVersion { get { throw null; } }
        public string ChatId { get { throw null; } }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.DateTimeOffset ExpirationDateTime { get { throw null; } }
    }
    public partial class ClassifierDocumentTypeDetails
    {
        public ClassifierDocumentTypeDetails() { }
        public Azure.AI.DocumentIntelligence.AzureBlobFileListContentSource AzureBlobFileListSource { get { throw null; } set { } }
        public Azure.AI.DocumentIntelligence.AzureBlobContentSource AzureBlobSource { get { throw null; } set { } }
        public Azure.AI.DocumentIntelligence.ContentSourceKind? SourceKind { get { throw null; } set { } }
    }
    public partial class ClassifyDocumentRequest
    {
        public ClassifyDocumentRequest() { }
        public System.BinaryData Base64Source { get { throw null; } set { } }
        public System.Uri UrlSource { get { throw null; } set { } }
    }
    public partial class ComponentDocumentModelDetails
    {
        public ComponentDocumentModelDetails(string modelId) { }
        public string ModelId { get { throw null; } }
    }
    public partial class ComposeDocumentModelRequest
    {
        public ComposeDocumentModelRequest(string modelId, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.ComponentDocumentModelDetails> componentModels) { }
        public System.Collections.Generic.IList<Azure.AI.DocumentIntelligence.ComponentDocumentModelDetails> ComponentModels { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string ModelId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentFormat : System.IEquatable<Azure.AI.DocumentIntelligence.ContentFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentFormat(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.ContentFormat Markdown { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.ContentFormat Text { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.ContentFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.ContentFormat left, Azure.AI.DocumentIntelligence.ContentFormat right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.ContentFormat (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.ContentFormat left, Azure.AI.DocumentIntelligence.ContentFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentSourceKind : System.IEquatable<Azure.AI.DocumentIntelligence.ContentSourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentSourceKind(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.ContentSourceKind AzureBlob { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.ContentSourceKind AzureBlobFileList { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.ContentSourceKind Base64 { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.ContentSourceKind Url { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.ContentSourceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.ContentSourceKind left, Azure.AI.DocumentIntelligence.ContentSourceKind right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.ContentSourceKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.ContentSourceKind left, Azure.AI.DocumentIntelligence.ContentSourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CopyAuthorization
    {
        public CopyAuthorization(string targetResourceId, string targetResourceRegion, string targetModelId, System.Uri targetModelLocation, string accessToken, System.DateTimeOffset expirationDateTime) { }
        public string AccessToken { get { throw null; } set { } }
        public System.DateTimeOffset ExpirationDateTime { get { throw null; } set { } }
        public string TargetModelId { get { throw null; } set { } }
        public System.Uri TargetModelLocation { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } set { } }
        public string TargetResourceRegion { get { throw null; } set { } }
    }
    public partial class CurrencyValue
    {
        internal CurrencyValue() { }
        public double Amount { get { throw null; } }
        public string CurrencyCode { get { throw null; } }
        public string CurrencySymbol { get { throw null; } }
    }
    public partial class CustomDocumentModelsDetails
    {
        internal CustomDocumentModelsDetails() { }
        public int Count { get { throw null; } }
        public int Limit { get { throw null; } }
    }
    public partial class DocumentAnalysisClient
    {
        protected DocumentAnalysisClient() { }
        public DocumentAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public DocumentAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.AnalyzeResult> AnalyzeDocument(Azure.WaitUntil waitUntil, string modelId, Azure.AI.DocumentIntelligence.AnalyzeDocumentRequest analyzeRequest = null, string pages = null, string locale = null, Azure.AI.DocumentIntelligence.StringIndexType? stringIndexType = default(Azure.AI.DocumentIntelligence.StringIndexType?), System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentAnalysisFeature> features = null, System.Collections.Generic.IEnumerable<string> queryFields = null, Azure.AI.DocumentIntelligence.ContentFormat? outputContentFormat = default(Azure.AI.DocumentIntelligence.ContentFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> AnalyzeDocument(Azure.WaitUntil waitUntil, string modelId, Azure.Core.RequestContent content, string pages = null, string locale = null, string stringIndexType = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentAnalysisFeature> features = null, System.Collections.Generic.IEnumerable<string> queryFields = null, string outputContentFormat = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.AnalyzeResult>> AnalyzeDocumentAsync(Azure.WaitUntil waitUntil, string modelId, Azure.AI.DocumentIntelligence.AnalyzeDocumentRequest analyzeRequest = null, string pages = null, string locale = null, Azure.AI.DocumentIntelligence.StringIndexType? stringIndexType = default(Azure.AI.DocumentIntelligence.StringIndexType?), System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentAnalysisFeature> features = null, System.Collections.Generic.IEnumerable<string> queryFields = null, Azure.AI.DocumentIntelligence.ContentFormat? outputContentFormat = default(Azure.AI.DocumentIntelligence.ContentFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> AnalyzeDocumentAsync(Azure.WaitUntil waitUntil, string modelId, Azure.Core.RequestContent content, string pages = null, string locale = null, string stringIndexType = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentAnalysisFeature> features = null, System.Collections.Generic.IEnumerable<string> queryFields = null, string outputContentFormat = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.AnalyzeResult> ClassifyDocument(Azure.WaitUntil waitUntil, string classifierId, Azure.AI.DocumentIntelligence.ClassifyDocumentRequest classifyRequest, Azure.AI.DocumentIntelligence.StringIndexType? stringIndexType = default(Azure.AI.DocumentIntelligence.StringIndexType?), Azure.AI.DocumentIntelligence.SplitMode? split = default(Azure.AI.DocumentIntelligence.SplitMode?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> ClassifyDocument(Azure.WaitUntil waitUntil, string classifierId, Azure.Core.RequestContent content, string stringIndexType = null, string split = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.AnalyzeResult>> ClassifyDocumentAsync(Azure.WaitUntil waitUntil, string classifierId, Azure.AI.DocumentIntelligence.ClassifyDocumentRequest classifyRequest, Azure.AI.DocumentIntelligence.StringIndexType? stringIndexType = default(Azure.AI.DocumentIntelligence.StringIndexType?), Azure.AI.DocumentIntelligence.SplitMode? split = default(Azure.AI.DocumentIntelligence.SplitMode?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ClassifyDocumentAsync(Azure.WaitUntil waitUntil, string classifierId, Azure.Core.RequestContent content, string stringIndexType = null, string split = null, Azure.RequestContext context = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentAnalysisFeature : System.IEquatable<Azure.AI.DocumentIntelligence.DocumentAnalysisFeature>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentAnalysisFeature(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentAnalysisFeature Barcodes { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentAnalysisFeature Formulas { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentAnalysisFeature KeyValuePairs { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentAnalysisFeature Languages { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentAnalysisFeature OcrHighResolution { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentAnalysisFeature QueryFields { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentAnalysisFeature StyleFont { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.DocumentAnalysisFeature other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.DocumentAnalysisFeature left, Azure.AI.DocumentIntelligence.DocumentAnalysisFeature right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentAnalysisFeature (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.DocumentAnalysisFeature left, Azure.AI.DocumentIntelligence.DocumentAnalysisFeature right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentBarcode
    {
        internal DocumentBarcode() { }
        public float Confidence { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> Polygon { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentSpan Span { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentBuildMode : System.IEquatable<Azure.AI.DocumentIntelligence.DocumentBuildMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentBuildMode(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentBuildMode Neural { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBuildMode Template { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.DocumentBuildMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.DocumentBuildMode left, Azure.AI.DocumentIntelligence.DocumentBuildMode right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentBuildMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.DocumentBuildMode left, Azure.AI.DocumentIntelligence.DocumentBuildMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentCaption
    {
        internal DocumentCaption() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<object> Elements { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class DocumentClassifierBuildOperationDetails : Azure.AI.DocumentIntelligence.OperationDetails
    {
        internal DocumentClassifierBuildOperationDetails() : base (default(Azure.AI.DocumentIntelligence.OperationStatus), default(System.DateTimeOffset), default(System.DateTimeOffset), default(System.Uri)) { }
        public Azure.AI.DocumentIntelligence.DocumentClassifierDetails Result { get { throw null; } }
    }
    public partial class DocumentClassifierDetails
    {
        internal DocumentClassifierDetails() { }
        public string ApiVersion { get { throw null; } }
        public string ClassifierId { get { throw null; } }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails> DocTypes { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
    }
    public partial class DocumentField
    {
        internal DocumentField() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public float? Confidence { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentFieldType Type { get { throw null; } }
        public Azure.AI.DocumentIntelligence.AddressValue ValueAddress { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentField> ValueArray { get { throw null; } }
        public bool? ValueBoolean { get { throw null; } }
        public string ValueCountryRegion { get { throw null; } }
        public Azure.AI.DocumentIntelligence.CurrencyValue ValueCurrency { get { throw null; } }
        public System.DateTimeOffset? ValueDate { get { throw null; } }
        public long? ValueInteger { get { throw null; } }
        public double? ValueNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentField> ValueObject { get { throw null; } }
        public string ValuePhoneNumber { get { throw null; } }
        public string ValueSelectionMark { get { throw null; } }
        public string ValueSignature { get { throw null; } }
        public string ValueString { get { throw null; } }
        public System.TimeSpan? ValueTime { get { throw null; } }
    }
    public partial class DocumentFieldSchema
    {
        internal DocumentFieldSchema() { }
        public string Description { get { throw null; } }
        public string Example { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentFieldSchema Items { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentFieldSchema> Properties { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentFieldType Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentFieldType : System.IEquatable<Azure.AI.DocumentIntelligence.DocumentFieldType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentFieldType(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType Address { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType Array { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType Boolean { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType CountryRegion { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType Currency { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType Date { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType Integer { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType Number { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType Object { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType PhoneNumber { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType SelectionMark { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType Signature { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType String { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType Time { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.DocumentFieldType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.DocumentFieldType left, Azure.AI.DocumentIntelligence.DocumentFieldType right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentFieldType (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.DocumentFieldType left, Azure.AI.DocumentIntelligence.DocumentFieldType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentFigure
    {
        internal DocumentFigure() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentCaption Caption { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<object> Elements { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentFootnote> Footnotes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class DocumentFootnote
    {
        internal DocumentFootnote() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<object> Elements { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class DocumentFormula
    {
        internal DocumentFormula() { }
        public float Confidence { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> Polygon { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentSpan Span { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class DocumentIntelligenceError
    {
        internal DocumentIntelligenceError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentIntelligenceError> Details { get { throw null; } }
        public Azure.AI.DocumentIntelligence.InnerError Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class DocumentKeyValueElement
    {
        internal DocumentKeyValueElement() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class DocumentKeyValuePair
    {
        internal DocumentKeyValuePair() { }
        public float Confidence { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentKeyValueElement Key { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentKeyValueElement Value { get { throw null; } }
    }
    public partial class DocumentLanguage
    {
        internal DocumentLanguage() { }
        public float Confidence { get { throw null; } }
        public string Locale { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class DocumentLine
    {
        internal DocumentLine() { }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> Polygon { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class DocumentList
    {
        internal DocumentList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentListItem> Items { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class DocumentListItem
    {
        internal DocumentListItem() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<object> Elements { get { throw null; } }
        public int Level { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class DocumentModelAdministrationClient
    {
        protected DocumentModelAdministrationClient() { }
        public DocumentModelAdministrationClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public DocumentModelAdministrationClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.DocumentIntelligence.CopyAuthorization> AuthorizeModelCopy(Azure.AI.DocumentIntelligence.AuthorizeCopyRequest authorizeCopyRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AuthorizeModelCopy(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.DocumentIntelligence.CopyAuthorization>> AuthorizeModelCopyAsync(Azure.AI.DocumentIntelligence.AuthorizeCopyRequest authorizeCopyRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AuthorizeModelCopyAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.DocumentClassifierDetails> BuildClassifier(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.BuildDocumentClassifierRequest buildRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> BuildClassifier(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.DocumentClassifierDetails>> BuildClassifierAsync(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.BuildDocumentClassifierRequest buildRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> BuildClassifierAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.DocumentModelDetails> BuildDocument(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.BuildDocumentModelRequest buildRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> BuildDocument(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.DocumentModelDetails>> BuildDocumentAsync(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.BuildDocumentModelRequest buildRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> BuildDocumentAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.DocumentModelDetails> ComposeModel(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.ComposeDocumentModelRequest composeRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> ComposeModel(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.DocumentModelDetails>> ComposeModelAsync(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.ComposeDocumentModelRequest composeRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ComposeModelAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.DocumentModelDetails> CopyModelTo(Azure.WaitUntil waitUntil, string modelId, Azure.AI.DocumentIntelligence.CopyAuthorization copyToRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> CopyModelTo(Azure.WaitUntil waitUntil, string modelId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.DocumentModelDetails>> CopyModelToAsync(Azure.WaitUntil waitUntil, string modelId, Azure.AI.DocumentIntelligence.CopyAuthorization copyToRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CopyModelToAsync(Azure.WaitUntil waitUntil, string modelId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteClassifier(string classifierId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteClassifierAsync(string classifierId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteModel(string modelId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteModelAsync(string modelId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetClassifier(string classifierId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.DocumentIntelligence.DocumentClassifierDetails> GetClassifier(string classifierId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetClassifierAsync(string classifierId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.DocumentIntelligence.DocumentClassifierDetails>> GetClassifierAsync(string classifierId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetClassifiers(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.DocumentIntelligence.DocumentClassifierDetails> GetClassifiers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetClassifiersAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.DocumentIntelligence.DocumentClassifierDetails> GetClassifiersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetModel(string modelId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.DocumentIntelligence.DocumentModelDetails> GetModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetModelAsync(string modelId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.DocumentIntelligence.DocumentModelDetails>> GetModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetModels(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.DocumentIntelligence.DocumentModelSummary> GetModels(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetModelsAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.DocumentIntelligence.DocumentModelSummary> GetModelsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetOperation(System.Guid operationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.DocumentIntelligence.OperationDetails> GetOperation(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetOperationAsync(System.Guid operationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.DocumentIntelligence.OperationDetails>> GetOperationAsync(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetOperations(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.DocumentIntelligence.OperationSummary> GetOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetOperationsAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.DocumentIntelligence.OperationSummary> GetOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetResourceInfo(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.DocumentIntelligence.ResourceDetails> GetResourceInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetResourceInfoAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.DocumentIntelligence.ResourceDetails>> GetResourceInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DocumentModelBuildOperationDetails : Azure.AI.DocumentIntelligence.OperationDetails
    {
        internal DocumentModelBuildOperationDetails() : base (default(Azure.AI.DocumentIntelligence.OperationStatus), default(System.DateTimeOffset), default(System.DateTimeOffset), default(System.Uri)) { }
        public Azure.AI.DocumentIntelligence.DocumentModelDetails Result { get { throw null; } }
    }
    public partial class DocumentModelComposeOperationDetails : Azure.AI.DocumentIntelligence.OperationDetails
    {
        internal DocumentModelComposeOperationDetails() : base (default(Azure.AI.DocumentIntelligence.OperationStatus), default(System.DateTimeOffset), default(System.DateTimeOffset), default(System.Uri)) { }
        public Azure.AI.DocumentIntelligence.DocumentModelDetails Result { get { throw null; } }
    }
    public partial class DocumentModelCopyToOperationDetails : Azure.AI.DocumentIntelligence.OperationDetails
    {
        internal DocumentModelCopyToOperationDetails() : base (default(Azure.AI.DocumentIntelligence.OperationStatus), default(System.DateTimeOffset), default(System.DateTimeOffset), default(System.Uri)) { }
        public Azure.AI.DocumentIntelligence.DocumentModelDetails Result { get { throw null; } }
    }
    public partial class DocumentModelDetails : Azure.AI.DocumentIntelligence.DocumentModelSummary
    {
        internal DocumentModelDetails() { }
        public Azure.AI.DocumentIntelligence.AzureBlobFileListContentSource AzureBlobFileListSource { get { throw null; } }
        public Azure.AI.DocumentIntelligence.AzureBlobContentSource AzureBlobSource { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentBuildMode BuildMode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentTypeDetails> DocTypes { get { throw null; } }
    }
    public partial class DocumentModelSummary
    {
        internal DocumentModelSummary() { }
        public string ApiVersion { get { throw null; } }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string ModelId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DocumentPage
    {
        internal DocumentPage() { }
        public float? Angle { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentBarcode> Barcodes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentFormula> Formulas { get { throw null; } }
        public float? Height { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentLine> Lines { get { throw null; } }
        public int PageNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSelectionMark> SelectionMarks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
        public string Unit { get { throw null; } }
        public float? Width { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentWord> Words { get { throw null; } }
    }
    public partial class DocumentParagraph
    {
        internal DocumentParagraph() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public string Content { get { throw null; } }
        public string Role { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class DocumentSection
    {
        internal DocumentSection() { }
        public System.Collections.Generic.IReadOnlyList<object> Elements { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class DocumentSelectionMark
    {
        internal DocumentSelectionMark() { }
        public float Confidence { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> Polygon { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentSpan Span { get { throw null; } }
        public string State { get { throw null; } }
    }
    public partial class DocumentSpan
    {
        internal DocumentSpan() { }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
    }
    public partial class DocumentStyle
    {
        internal DocumentStyle() { }
        public string BackgroundColor { get { throw null; } }
        public string Color { get { throw null; } }
        public float Confidence { get { throw null; } }
        public string FontStyle { get { throw null; } }
        public string FontWeight { get { throw null; } }
        public bool? IsHandwritten { get { throw null; } }
        public string SimilarFontFamily { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class DocumentTable
    {
        internal DocumentTable() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentCaption Caption { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentTableCell> Cells { get { throw null; } }
        public int ColumnCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentFootnote> Footnotes { get { throw null; } }
        public int RowCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class DocumentTableCell
    {
        internal DocumentTableCell() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public int ColumnIndex { get { throw null; } }
        public int? ColumnSpan { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<object> Elements { get { throw null; } }
        public string Kind { get { throw null; } }
        public int RowIndex { get { throw null; } }
        public int? RowSpan { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class DocumentTypeDetails
    {
        internal DocumentTypeDetails() { }
        public Azure.AI.DocumentIntelligence.DocumentBuildMode? BuildMode { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, float> FieldConfidence { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentFieldSchema> FieldSchema { get { throw null; } }
    }
    public partial class DocumentWord
    {
        internal DocumentWord() { }
        public float Confidence { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> Polygon { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentSpan Span { get { throw null; } }
    }
    public partial class InnerError
    {
        internal InnerError() { }
        public string Code { get { throw null; } }
        public Azure.AI.DocumentIntelligence.InnerError Innererror { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public abstract partial class OperationDetails
    {
        protected OperationDetails(Azure.AI.DocumentIntelligence.OperationStatus status, System.DateTimeOffset createdDateTime, System.DateTimeOffset lastUpdatedDateTime, System.Uri resourceLocation) { }
        public string ApiVersion { get { throw null; } }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentIntelligenceError Error { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public System.Guid OperationId { get { throw null; } }
        public int? PercentCompleted { get { throw null; } }
        public System.Uri ResourceLocation { get { throw null; } }
        public Azure.AI.DocumentIntelligence.OperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationKind : System.IEquatable<Azure.AI.DocumentIntelligence.OperationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationKind(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.OperationKind ChatBuild { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.OperationKind DocumentClassifierBuild { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.OperationKind DocumentModelBuild { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.OperationKind DocumentModelCompose { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.OperationKind DocumentModelCopyTo { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.OperationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.OperationKind left, Azure.AI.DocumentIntelligence.OperationKind right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.OperationKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.OperationKind left, Azure.AI.DocumentIntelligence.OperationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationStatus : System.IEquatable<Azure.AI.DocumentIntelligence.OperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationStatus(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.OperationStatus Canceled { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.OperationStatus Failed { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.OperationStatus NotStarted { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.OperationStatus Running { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.OperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.OperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.OperationStatus left, Azure.AI.DocumentIntelligence.OperationStatus right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.OperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.OperationStatus left, Azure.AI.DocumentIntelligence.OperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationSummary
    {
        internal OperationSummary() { }
        public string ApiVersion { get { throw null; } }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public Azure.AI.DocumentIntelligence.OperationKind Kind { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public System.Guid OperationId { get { throw null; } }
        public int? PercentCompleted { get { throw null; } }
        public System.Uri ResourceLocation { get { throw null; } }
        public Azure.AI.DocumentIntelligence.OperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class QuotaDetails
    {
        internal QuotaDetails() { }
        public int Quota { get { throw null; } }
        public System.DateTimeOffset QuotaResetDateTime { get { throw null; } }
        public int Used { get { throw null; } }
    }
    public partial class ResourceDetails
    {
        internal ResourceDetails() { }
        public Azure.AI.DocumentIntelligence.CustomDocumentModelsDetails CustomDocumentModels { get { throw null; } }
        public Azure.AI.DocumentIntelligence.QuotaDetails CustomNeuralDocumentModelBuilds { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SplitMode : System.IEquatable<Azure.AI.DocumentIntelligence.SplitMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SplitMode(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.SplitMode Auto { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.SplitMode None { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.SplitMode PerPage { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.SplitMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.SplitMode left, Azure.AI.DocumentIntelligence.SplitMode right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.SplitMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.SplitMode left, Azure.AI.DocumentIntelligence.SplitMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StringIndexType : System.IEquatable<Azure.AI.DocumentIntelligence.StringIndexType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StringIndexType(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.StringIndexType TextElements { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.StringIndexType UnicodeCodePoint { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.StringIndexType Utf16CodeUnit { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.StringIndexType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.StringIndexType left, Azure.AI.DocumentIntelligence.StringIndexType right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.StringIndexType (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.StringIndexType left, Azure.AI.DocumentIntelligence.StringIndexType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AIDocumentIntelligenceClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.DocumentIntelligence.DocumentAnalysisClient, Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceClientOptions> AddDocumentAnalysisClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.DocumentIntelligence.DocumentAnalysisClient, Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceClientOptions> AddDocumentAnalysisClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.DocumentIntelligence.DocumentModelAdministrationClient, Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceClientOptions> AddDocumentModelAdministrationClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.DocumentIntelligence.DocumentModelAdministrationClient, Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceClientOptions> AddDocumentModelAdministrationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
