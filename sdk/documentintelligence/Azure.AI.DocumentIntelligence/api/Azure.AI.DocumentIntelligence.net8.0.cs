namespace Azure.AI.DocumentIntelligence
{
    public partial class AddressValue : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AddressValue>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AddressValue>
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
        protected virtual Azure.AI.DocumentIntelligence.AddressValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.AddressValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.AddressValue System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AddressValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AddressValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.AddressValue System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AddressValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AddressValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AddressValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeBatchDocumentsOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeBatchDocumentsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeBatchDocumentsOptions>
    {
        public AnalyzeBatchDocumentsOptions(string modelId, Azure.AI.DocumentIntelligence.BlobContentSource blobSource, System.Uri resultContainerUri) { }
        public AnalyzeBatchDocumentsOptions(string modelId, Azure.AI.DocumentIntelligence.BlobFileListContentSource blobFileListSource, System.Uri resultContainerUri) { }
        public Azure.AI.DocumentIntelligence.BlobFileListContentSource BlobFileListSource { get { throw null; } }
        public Azure.AI.DocumentIntelligence.BlobContentSource BlobSource { get { throw null; } }
        public System.Collections.Generic.ICollection<Azure.AI.DocumentIntelligence.DocumentAnalysisFeature> Features { get { throw null; } }
        public string Locale { get { throw null; } set { } }
        public string ModelId { get { throw null; } }
        public System.Collections.Generic.ICollection<Azure.AI.DocumentIntelligence.AnalyzeOutputOption> Output { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentContentFormat? OutputContentFormat { get { throw null; } set { } }
        public bool? OverwriteExisting { get { throw null; } set { } }
        public string Pages { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> QueryFields { get { throw null; } }
        public System.Uri ResultContainerUri { get { throw null; } }
        public string ResultPrefix { get { throw null; } set { } }
        protected virtual Azure.AI.DocumentIntelligence.AnalyzeBatchDocumentsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.DocumentIntelligence.AnalyzeBatchDocumentsOptions analyzeBatchDocumentsOptions) { throw null; }
        protected virtual Azure.AI.DocumentIntelligence.AnalyzeBatchDocumentsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.AnalyzeBatchDocumentsOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeBatchDocumentsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeBatchDocumentsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.AnalyzeBatchDocumentsOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeBatchDocumentsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeBatchDocumentsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeBatchDocumentsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeBatchOperationDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeBatchOperationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeBatchOperationDetails>
    {
        internal AnalyzeBatchOperationDetails() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentIntelligenceError Error { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public int? PercentCompleted { get { throw null; } }
        public Azure.AI.DocumentIntelligence.AnalyzeBatchResult Result { get { throw null; } }
        public string ResultId { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus Status { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.AnalyzeBatchOperationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.DocumentIntelligence.AnalyzeBatchOperationDetails (Azure.Response response) { throw null; }
        protected virtual Azure.AI.DocumentIntelligence.AnalyzeBatchOperationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.AnalyzeBatchOperationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeBatchOperationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeBatchOperationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.AnalyzeBatchOperationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeBatchOperationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeBatchOperationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeBatchOperationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeBatchResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeBatchResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeBatchResult>
    {
        internal AnalyzeBatchResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.AnalyzeBatchResultDetails> Details { get { throw null; } }
        public int FailedCount { get { throw null; } }
        public int SkippedCount { get { throw null; } }
        public int SucceededCount { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.AnalyzeBatchResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.AnalyzeBatchResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.AnalyzeBatchResult System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeBatchResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeBatchResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.AnalyzeBatchResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeBatchResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeBatchResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeBatchResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeBatchResultDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeBatchResultDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeBatchResultDetails>
    {
        internal AnalyzeBatchResultDetails() { }
        public Azure.AI.DocumentIntelligence.DocumentIntelligenceError Error { get { throw null; } }
        public System.Uri ResultUri { get { throw null; } }
        public System.Uri SourceUri { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus Status { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.AnalyzeBatchResultDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.AnalyzeBatchResultDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.AnalyzeBatchResultDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeBatchResultDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeBatchResultDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.AnalyzeBatchResultDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeBatchResultDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeBatchResultDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeBatchResultDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzedDocument : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzedDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzedDocument>
    {
        internal AnalyzedDocument() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public float Confidence { get { throw null; } }
        public string DocumentType { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentFieldDictionary Fields { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.AnalyzedDocument JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.AnalyzedDocument PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.AnalyzedDocument System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzedDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzedDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.AnalyzedDocument System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzedDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzedDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzedDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeDocumentOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeDocumentOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeDocumentOptions>
    {
        public AnalyzeDocumentOptions(string modelId, System.BinaryData bytesSource) { }
        public AnalyzeDocumentOptions(string modelId, System.Uri uriSource) { }
        public System.BinaryData BytesSource { get { throw null; } }
        public System.Collections.Generic.ICollection<Azure.AI.DocumentIntelligence.DocumentAnalysisFeature> Features { get { throw null; } }
        public string Locale { get { throw null; } set { } }
        public string ModelId { get { throw null; } }
        public System.Collections.Generic.ICollection<Azure.AI.DocumentIntelligence.AnalyzeOutputOption> Output { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentContentFormat? OutputContentFormat { get { throw null; } set { } }
        public string Pages { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> QueryFields { get { throw null; } }
        public System.Uri UriSource { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.AnalyzeDocumentOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.DocumentIntelligence.AnalyzeDocumentOptions analyzeDocumentOptions) { throw null; }
        protected virtual Azure.AI.DocumentIntelligence.AnalyzeDocumentOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.AnalyzeDocumentOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeDocumentOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeDocumentOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.AnalyzeDocumentOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeDocumentOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeDocumentOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeDocumentOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalyzeOutputOption : System.IEquatable<Azure.AI.DocumentIntelligence.AnalyzeOutputOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalyzeOutputOption(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.AnalyzeOutputOption Figures { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.AnalyzeOutputOption Pdf { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.AnalyzeOutputOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.AnalyzeOutputOption left, Azure.AI.DocumentIntelligence.AnalyzeOutputOption right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.AnalyzeOutputOption (string value) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.AnalyzeOutputOption? (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.AnalyzeOutputOption left, Azure.AI.DocumentIntelligence.AnalyzeOutputOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AnalyzeResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeResult>
    {
        internal AnalyzeResult() { }
        public string ApiVersion { get { throw null; } }
        public string Content { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentContentFormat? ContentFormat { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.AnalyzedDocument> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentFigure> Figures { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentKeyValuePair> KeyValuePairs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentLanguage> Languages { get { throw null; } }
        public string ModelId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentPage> Pages { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentParagraph> Paragraphs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSection> Sections { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentStyle> Styles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentTable> Tables { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentIntelligenceWarning> Warnings { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.AnalyzeResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.AnalyzeResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.AnalyzeResult System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.AnalyzeResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthorizeClassifierCopyOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AuthorizeClassifierCopyOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AuthorizeClassifierCopyOptions>
    {
        public AuthorizeClassifierCopyOptions(string classifierId) { }
        public string ClassifierId { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.AuthorizeClassifierCopyOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.DocumentIntelligence.AuthorizeClassifierCopyOptions authorizeClassifierCopyOptions) { throw null; }
        protected virtual Azure.AI.DocumentIntelligence.AuthorizeClassifierCopyOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.AuthorizeClassifierCopyOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AuthorizeClassifierCopyOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AuthorizeClassifierCopyOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.AuthorizeClassifierCopyOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AuthorizeClassifierCopyOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AuthorizeClassifierCopyOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AuthorizeClassifierCopyOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthorizeModelCopyOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AuthorizeModelCopyOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AuthorizeModelCopyOptions>
    {
        public AuthorizeModelCopyOptions(string modelId) { }
        public string Description { get { throw null; } set { } }
        public string ModelId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.AuthorizeModelCopyOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.DocumentIntelligence.AuthorizeModelCopyOptions authorizeModelCopyOptions) { throw null; }
        protected virtual Azure.AI.DocumentIntelligence.AuthorizeModelCopyOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.AuthorizeModelCopyOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AuthorizeModelCopyOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AuthorizeModelCopyOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.AuthorizeModelCopyOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AuthorizeModelCopyOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AuthorizeModelCopyOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AuthorizeModelCopyOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAIDocumentIntelligenceContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIDocumentIntelligenceContext() { }
        public static Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BlobContentSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BlobContentSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BlobContentSource>
    {
        public BlobContentSource(System.Uri containerUri) { }
        public System.Uri ContainerUri { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
        protected virtual Azure.AI.DocumentIntelligence.BlobContentSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.BlobContentSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.BlobContentSource System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BlobContentSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BlobContentSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.BlobContentSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BlobContentSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BlobContentSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BlobContentSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobFileListContentSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BlobFileListContentSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BlobFileListContentSource>
    {
        public BlobFileListContentSource(System.Uri containerUri, string fileList) { }
        public System.Uri ContainerUri { get { throw null; } set { } }
        public string FileList { get { throw null; } set { } }
        protected virtual Azure.AI.DocumentIntelligence.BlobFileListContentSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.BlobFileListContentSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.BlobFileListContentSource System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BlobFileListContentSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BlobFileListContentSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.BlobFileListContentSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BlobFileListContentSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BlobFileListContentSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BlobFileListContentSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BoundingRegion : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BoundingRegion>, System.ClientModel.Primitives.IJsonModel<object>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BoundingRegion>, System.ClientModel.Primitives.IPersistableModel<object>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BoundingRegion() { throw null; }
        public int PageNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> Polygon { get { throw null; } }
        Azure.AI.DocumentIntelligence.BoundingRegion System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BoundingRegion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BoundingRegion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        object System.ClientModel.Primitives.IJsonModel<System.Object>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<System.Object>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.BoundingRegion System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BoundingRegion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BoundingRegion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BoundingRegion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        object System.ClientModel.Primitives.IPersistableModel<System.Object>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<System.Object>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<System.Object>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BuildClassifierOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BuildClassifierOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BuildClassifierOptions>
    {
        public BuildClassifierOptions(string classifierId, System.Collections.Generic.IDictionary<string, Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails> documentTypes) { }
        public bool? AllowOverwrite { get { throw null; } set { } }
        public string BaseClassifierId { get { throw null; } set { } }
        public string ClassifierId { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails> DocumentTypes { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.BuildClassifierOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.DocumentIntelligence.BuildClassifierOptions buildClassifierOptions) { throw null; }
        protected virtual Azure.AI.DocumentIntelligence.BuildClassifierOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.BuildClassifierOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BuildClassifierOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BuildClassifierOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.BuildClassifierOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BuildClassifierOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BuildClassifierOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BuildClassifierOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BuildDocumentModelOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BuildDocumentModelOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BuildDocumentModelOptions>
    {
        public BuildDocumentModelOptions(string modelId, Azure.AI.DocumentIntelligence.DocumentBuildMode buildMode, Azure.AI.DocumentIntelligence.BlobContentSource blobSource) { }
        public BuildDocumentModelOptions(string modelId, Azure.AI.DocumentIntelligence.DocumentBuildMode buildMode, Azure.AI.DocumentIntelligence.BlobFileListContentSource blobFileListSource) { }
        public bool? AllowOverwrite { get { throw null; } set { } }
        public Azure.AI.DocumentIntelligence.BlobFileListContentSource BlobFileListSource { get { throw null; } }
        public Azure.AI.DocumentIntelligence.BlobContentSource BlobSource { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentBuildMode BuildMode { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public float? MaxTrainingHours { get { throw null; } set { } }
        public string ModelId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.BuildDocumentModelOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.DocumentIntelligence.BuildDocumentModelOptions buildDocumentModelOptions) { throw null; }
        protected virtual Azure.AI.DocumentIntelligence.BuildDocumentModelOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.BuildDocumentModelOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BuildDocumentModelOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BuildDocumentModelOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.BuildDocumentModelOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BuildDocumentModelOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BuildDocumentModelOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BuildDocumentModelOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClassifierCopyAuthorization : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ClassifierCopyAuthorization>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ClassifierCopyAuthorization>
    {
        public ClassifierCopyAuthorization(string targetResourceId, string targetResourceRegion, string targetClassifierId, System.Uri targetClassifierLocation, string accessToken, System.DateTimeOffset expiresOn) { }
        public string AccessToken { get { throw null; } set { } }
        public System.DateTimeOffset ExpiresOn { get { throw null; } set { } }
        public string TargetClassifierId { get { throw null; } set { } }
        public System.Uri TargetClassifierLocation { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } set { } }
        public string TargetResourceRegion { get { throw null; } set { } }
        protected virtual Azure.AI.DocumentIntelligence.ClassifierCopyAuthorization JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.DocumentIntelligence.ClassifierCopyAuthorization (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.DocumentIntelligence.ClassifierCopyAuthorization classifierCopyAuthorization) { throw null; }
        protected virtual Azure.AI.DocumentIntelligence.ClassifierCopyAuthorization PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.ClassifierCopyAuthorization System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ClassifierCopyAuthorization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ClassifierCopyAuthorization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.ClassifierCopyAuthorization System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ClassifierCopyAuthorization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ClassifierCopyAuthorization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ClassifierCopyAuthorization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClassifierDocumentTypeDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails>
    {
        public ClassifierDocumentTypeDetails(Azure.AI.DocumentIntelligence.BlobContentSource blobSource) { }
        public ClassifierDocumentTypeDetails(Azure.AI.DocumentIntelligence.BlobFileListContentSource blobFileListSource) { }
        public Azure.AI.DocumentIntelligence.BlobFileListContentSource BlobFileListSource { get { throw null; } }
        public Azure.AI.DocumentIntelligence.BlobContentSource BlobSource { get { throw null; } }
        public Azure.AI.DocumentIntelligence.ContentSourceKind? SourceKind { get { throw null; } set { } }
        protected virtual Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClassifyDocumentOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ClassifyDocumentOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ClassifyDocumentOptions>
    {
        public ClassifyDocumentOptions(string classifierId, System.BinaryData bytesSource) { }
        public ClassifyDocumentOptions(string classifierId, System.Uri uriSource) { }
        public System.BinaryData BytesSource { get { throw null; } }
        public string ClassifierId { get { throw null; } }
        public string Pages { get { throw null; } set { } }
        public Azure.AI.DocumentIntelligence.SplitMode? Split { get { throw null; } set { } }
        public System.Uri UriSource { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.ClassifyDocumentOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.DocumentIntelligence.ClassifyDocumentOptions classifyDocumentOptions) { throw null; }
        protected virtual Azure.AI.DocumentIntelligence.ClassifyDocumentOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.ClassifyDocumentOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ClassifyDocumentOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ClassifyDocumentOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.ClassifyDocumentOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ClassifyDocumentOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ClassifyDocumentOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ClassifyDocumentOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComposeModelOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ComposeModelOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ComposeModelOptions>
    {
        public ComposeModelOptions(string modelId, string classifierId, System.Collections.Generic.IDictionary<string, Azure.AI.DocumentIntelligence.DocumentTypeDetails> documentTypes) { }
        public string ClassifierId { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.DocumentIntelligence.DocumentTypeDetails> DocumentTypes { get { throw null; } }
        public string ModelId { get { throw null; } }
        public Azure.AI.DocumentIntelligence.SplitMode? Split { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.ComposeModelOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.DocumentIntelligence.ComposeModelOptions composeModelOptions) { throw null; }
        protected virtual Azure.AI.DocumentIntelligence.ComposeModelOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.ComposeModelOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ComposeModelOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ComposeModelOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.ComposeModelOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ComposeModelOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ComposeModelOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ComposeModelOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentSourceKind : System.IEquatable<Azure.AI.DocumentIntelligence.ContentSourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentSourceKind(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.ContentSourceKind Blob { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.ContentSourceKind BlobFileList { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.ContentSourceKind Bytes { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.ContentSourceKind Uri { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.ContentSourceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.ContentSourceKind left, Azure.AI.DocumentIntelligence.ContentSourceKind right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.ContentSourceKind (string value) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.ContentSourceKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.ContentSourceKind left, Azure.AI.DocumentIntelligence.ContentSourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CurrencyValue : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.CurrencyValue>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.CurrencyValue>
    {
        internal CurrencyValue() { }
        public double Amount { get { throw null; } }
        public string CurrencyCode { get { throw null; } }
        public string CurrencySymbol { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.CurrencyValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.CurrencyValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.CurrencyValue System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.CurrencyValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.CurrencyValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.CurrencyValue System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.CurrencyValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.CurrencyValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.CurrencyValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomDocumentModelsDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.CustomDocumentModelsDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.CustomDocumentModelsDetails>
    {
        internal CustomDocumentModelsDetails() { }
        public int Count { get { throw null; } }
        public int Limit { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.CustomDocumentModelsDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.CustomDocumentModelsDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.CustomDocumentModelsDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.CustomDocumentModelsDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.CustomDocumentModelsDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.CustomDocumentModelsDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.CustomDocumentModelsDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.CustomDocumentModelsDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.CustomDocumentModelsDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentAnalysisFeature : System.IEquatable<Azure.AI.DocumentIntelligence.DocumentAnalysisFeature>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentAnalysisFeature(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentAnalysisFeature Barcodes { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentAnalysisFeature FontStyling { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentAnalysisFeature Formulas { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentAnalysisFeature KeyValuePairs { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentAnalysisFeature Languages { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentAnalysisFeature OcrHighResolution { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentAnalysisFeature QueryFields { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.DocumentAnalysisFeature other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.DocumentAnalysisFeature left, Azure.AI.DocumentIntelligence.DocumentAnalysisFeature right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentAnalysisFeature (string value) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentAnalysisFeature? (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.DocumentAnalysisFeature left, Azure.AI.DocumentIntelligence.DocumentAnalysisFeature right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentBarcode : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentBarcode>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentBarcode>
    {
        internal DocumentBarcode() { }
        public float Confidence { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentBarcodeKind Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> Polygon { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentSpan Span { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentBarcode JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentBarcode PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentBarcode System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentBarcode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentBarcode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentBarcode System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentBarcode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentBarcode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentBarcode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentBarcodeKind : System.IEquatable<Azure.AI.DocumentIntelligence.DocumentBarcodeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentBarcodeKind(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind Aztec { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind Codabar { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind Code128 { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind Code39 { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind Code93 { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind DataBar { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind DataBarExpanded { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind DataMatrix { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind Ean13 { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind Ean8 { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind Itf { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind MaxiCode { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind MicroQrCode { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind Pdf417 { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind QrCode { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind Upca { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind Upce { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.DocumentBarcodeKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.DocumentBarcodeKind left, Azure.AI.DocumentIntelligence.DocumentBarcodeKind right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentBarcodeKind (string value) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentBarcodeKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.DocumentBarcodeKind left, Azure.AI.DocumentIntelligence.DocumentBarcodeKind right) { throw null; }
        public override string ToString() { throw null; }
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
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentBuildMode? (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.DocumentBuildMode left, Azure.AI.DocumentIntelligence.DocumentBuildMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentCaption : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentCaption>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentCaption>
    {
        internal DocumentCaption() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Elements { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentCaption JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentCaption PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentCaption System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentCaption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentCaption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentCaption System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentCaption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentCaption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentCaption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentClassifierBuildOperationDetails : Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails>
    {
        internal DocumentClassifierBuildOperationDetails() : base (default(string), default(Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus), default(System.DateTimeOffset), default(System.DateTimeOffset), default(System.Uri)) { }
        public Azure.AI.DocumentIntelligence.DocumentClassifierDetails Result { get { throw null; } }
        protected override Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentClassifierCopyToOperationDetails : Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentClassifierCopyToOperationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentClassifierCopyToOperationDetails>
    {
        internal DocumentClassifierCopyToOperationDetails() : base (default(string), default(Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus), default(System.DateTimeOffset), default(System.DateTimeOffset), default(System.Uri)) { }
        public Azure.AI.DocumentIntelligence.DocumentClassifierDetails Result { get { throw null; } }
        protected override Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentClassifierCopyToOperationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentClassifierCopyToOperationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentClassifierCopyToOperationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentClassifierCopyToOperationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentClassifierCopyToOperationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentClassifierCopyToOperationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentClassifierCopyToOperationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentClassifierDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentClassifierDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentClassifierDetails>
    {
        internal DocumentClassifierDetails() { }
        public string ApiVersion { get { throw null; } }
        public string BaseClassifierId { get { throw null; } }
        public string ClassifierId { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails> DocumentTypes { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentIntelligenceWarning> Warnings { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentClassifierDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.DocumentIntelligence.DocumentClassifierDetails (Azure.Response response) { throw null; }
        protected virtual Azure.AI.DocumentIntelligence.DocumentClassifierDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentClassifierDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentClassifierDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentClassifierDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentClassifierDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentClassifierDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentClassifierDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentClassifierDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentContentFormat : System.IEquatable<Azure.AI.DocumentIntelligence.DocumentContentFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentContentFormat(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentContentFormat Markdown { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentContentFormat Text { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.DocumentContentFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.DocumentContentFormat left, Azure.AI.DocumentIntelligence.DocumentContentFormat right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentContentFormat (string value) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentContentFormat? (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.DocumentContentFormat left, Azure.AI.DocumentIntelligence.DocumentContentFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentField : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentField>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentField>
    {
        internal DocumentField() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public float? Confidence { get { throw null; } }
        public string Content { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentFieldType FieldType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
        public Azure.AI.DocumentIntelligence.AddressValue ValueAddress { get { throw null; } }
        public bool? ValueBoolean { get { throw null; } }
        public string ValueCountryRegion { get { throw null; } }
        public Azure.AI.DocumentIntelligence.CurrencyValue ValueCurrency { get { throw null; } }
        public System.DateTimeOffset? ValueDate { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentFieldDictionary ValueDictionary { get { throw null; } }
        public double? ValueDouble { get { throw null; } }
        public long? ValueInt64 { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentField> ValueList { get { throw null; } }
        public string ValuePhoneNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ValueSelectionGroup { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentSelectionMarkState? ValueSelectionMark { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentSignatureType? ValueSignature { get { throw null; } }
        public string ValueString { get { throw null; } }
        public System.TimeSpan? ValueTime { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentField System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentField System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentFieldDictionary : System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, Azure.AI.DocumentIntelligence.DocumentField>>, System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<string, Azure.AI.DocumentIntelligence.DocumentField>>, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentField>, System.Collections.IEnumerable
    {
        internal DocumentFieldDictionary() { }
        public int Count { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentField this[string key] { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> Keys { get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentField> Values { get { throw null; } }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, Azure.AI.DocumentIntelligence.DocumentField>> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out Azure.AI.DocumentIntelligence.DocumentField value) { throw null; }
    }
    public partial class DocumentFieldSchema : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentFieldSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFieldSchema>
    {
        public DocumentFieldSchema(Azure.AI.DocumentIntelligence.DocumentFieldType fieldType) { }
        public string Description { get { throw null; } set { } }
        public string Example { get { throw null; } set { } }
        public Azure.AI.DocumentIntelligence.DocumentFieldType FieldType { get { throw null; } set { } }
        public Azure.AI.DocumentIntelligence.DocumentFieldSchema Items { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.DocumentIntelligence.DocumentFieldSchema> Properties { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentFieldSchema JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentFieldSchema PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentFieldSchema System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentFieldSchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentFieldSchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentFieldSchema System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFieldSchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFieldSchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFieldSchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentFieldType : System.IEquatable<Azure.AI.DocumentIntelligence.DocumentFieldType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentFieldType(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType Address { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType Boolean { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType CountryRegion { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType Currency { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType Date { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType Dictionary { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType Double { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType Int64 { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType List { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType PhoneNumber { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFieldType SelectionGroup { get { throw null; } }
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
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentFieldType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.DocumentFieldType left, Azure.AI.DocumentIntelligence.DocumentFieldType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentFigure : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentFigure>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFigure>
    {
        internal DocumentFigure() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentCaption Caption { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Elements { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentFootnote> Footnotes { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentFigure JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentFigure PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentFigure System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentFigure>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentFigure>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentFigure System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFigure>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFigure>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFigure>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentFontStyle : System.IEquatable<Azure.AI.DocumentIntelligence.DocumentFontStyle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentFontStyle(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentFontStyle Italic { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFontStyle Normal { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.DocumentFontStyle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.DocumentFontStyle left, Azure.AI.DocumentIntelligence.DocumentFontStyle right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentFontStyle (string value) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentFontStyle? (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.DocumentFontStyle left, Azure.AI.DocumentIntelligence.DocumentFontStyle right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentFontWeight : System.IEquatable<Azure.AI.DocumentIntelligence.DocumentFontWeight>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentFontWeight(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentFontWeight Bold { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFontWeight Normal { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.DocumentFontWeight other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.DocumentFontWeight left, Azure.AI.DocumentIntelligence.DocumentFontWeight right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentFontWeight (string value) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentFontWeight? (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.DocumentFontWeight left, Azure.AI.DocumentIntelligence.DocumentFontWeight right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentFootnote : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentFootnote>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFootnote>
    {
        internal DocumentFootnote() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Elements { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentFootnote JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentFootnote PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentFootnote System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentFootnote>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentFootnote>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentFootnote System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFootnote>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFootnote>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFootnote>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentFormula : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentFormula>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFormula>
    {
        internal DocumentFormula() { }
        public float Confidence { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentFormulaKind Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> Polygon { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentSpan Span { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentFormula JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentFormula PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentFormula System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentFormula>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentFormula>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentFormula System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFormula>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFormula>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFormula>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentFormulaKind : System.IEquatable<Azure.AI.DocumentIntelligence.DocumentFormulaKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentFormulaKind(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentFormulaKind Display { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentFormulaKind Inline { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.DocumentFormulaKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.DocumentFormulaKind left, Azure.AI.DocumentIntelligence.DocumentFormulaKind right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentFormulaKind (string value) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentFormulaKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.DocumentFormulaKind left, Azure.AI.DocumentIntelligence.DocumentFormulaKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentIntelligenceAdministrationClient
    {
        protected DocumentIntelligenceAdministrationClient() { }
        public DocumentIntelligenceAdministrationClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public DocumentIntelligenceAdministrationClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.DocumentIntelligence.DocumentIntelligenceClientOptions options) { }
        public DocumentIntelligenceAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DocumentIntelligenceAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.DocumentIntelligence.DocumentIntelligenceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.DocumentIntelligence.ClassifierCopyAuthorization> AuthorizeClassifierCopy(Azure.AI.DocumentIntelligence.AuthorizeClassifierCopyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AuthorizeClassifierCopy(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.DocumentIntelligence.ClassifierCopyAuthorization>> AuthorizeClassifierCopyAsync(Azure.AI.DocumentIntelligence.AuthorizeClassifierCopyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AuthorizeClassifierCopyAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.DocumentIntelligence.ModelCopyAuthorization> AuthorizeModelCopy(Azure.AI.DocumentIntelligence.AuthorizeModelCopyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AuthorizeModelCopy(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.DocumentIntelligence.ModelCopyAuthorization>> AuthorizeModelCopyAsync(Azure.AI.DocumentIntelligence.AuthorizeModelCopyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AuthorizeModelCopyAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.DocumentClassifierDetails> BuildClassifier(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.BuildClassifierOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> BuildClassifier(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.DocumentClassifierDetails>> BuildClassifierAsync(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.BuildClassifierOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> BuildClassifierAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.DocumentModelDetails> BuildDocumentModel(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.BuildDocumentModelOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> BuildDocumentModel(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.DocumentModelDetails>> BuildDocumentModelAsync(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.BuildDocumentModelOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> BuildDocumentModelAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.DocumentModelDetails> ComposeModel(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.ComposeModelOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> ComposeModel(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.DocumentModelDetails>> ComposeModelAsync(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.ComposeModelOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ComposeModelAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.DocumentClassifierDetails> CopyClassifierTo(Azure.WaitUntil waitUntil, string classifierId, Azure.AI.DocumentIntelligence.ClassifierCopyAuthorization authorization, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> CopyClassifierTo(Azure.WaitUntil waitUntil, string classifierId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.DocumentClassifierDetails>> CopyClassifierToAsync(Azure.WaitUntil waitUntil, string classifierId, Azure.AI.DocumentIntelligence.ClassifierCopyAuthorization authorization, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CopyClassifierToAsync(Azure.WaitUntil waitUntil, string classifierId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.DocumentModelDetails> CopyModelTo(Azure.WaitUntil waitUntil, string modelId, Azure.AI.DocumentIntelligence.ModelCopyAuthorization authorization, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> CopyModelTo(Azure.WaitUntil waitUntil, string modelId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.DocumentModelDetails>> CopyModelToAsync(Azure.WaitUntil waitUntil, string modelId, Azure.AI.DocumentIntelligence.ModelCopyAuthorization authorization, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CopyModelToAsync(Azure.WaitUntil waitUntil, string modelId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteClassifier(string classifierId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteClassifier(string classifierId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteClassifierAsync(string classifierId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteClassifierAsync(string classifierId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteModel(string modelId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteModelAsync(string modelId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.AI.DocumentIntelligence.DocumentModelDetails> GetModels(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetModelsAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.DocumentIntelligence.DocumentModelDetails> GetModelsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetOperation(string operationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails> GetOperation(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetOperationAsync(string operationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails>> GetOperationAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetOperations(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails> GetOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetOperationsAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails> GetOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetResourceDetails(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.DocumentIntelligence.DocumentIntelligenceResourceDetails> GetResourceDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetResourceDetailsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.DocumentIntelligence.DocumentIntelligenceResourceDetails>> GetResourceDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DocumentIntelligenceClient
    {
        protected DocumentIntelligenceClient() { }
        public DocumentIntelligenceClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public DocumentIntelligenceClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.DocumentIntelligence.DocumentIntelligenceClientOptions options) { }
        public DocumentIntelligenceClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DocumentIntelligenceClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.DocumentIntelligence.DocumentIntelligenceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.AnalyzeBatchResult> AnalyzeBatchDocuments(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.AnalyzeBatchDocumentsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> AnalyzeBatchDocuments(Azure.WaitUntil waitUntil, string modelId, Azure.Core.RequestContent content, string pages = null, string locale = null, string stringIndexType = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentAnalysisFeature> features = null, System.Collections.Generic.IEnumerable<string> queryFields = null, string outputContentFormat = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.AnalyzeOutputOption> output = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.AnalyzeBatchResult>> AnalyzeBatchDocumentsAsync(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.AnalyzeBatchDocumentsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> AnalyzeBatchDocumentsAsync(Azure.WaitUntil waitUntil, string modelId, Azure.Core.RequestContent content, string pages = null, string locale = null, string stringIndexType = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentAnalysisFeature> features = null, System.Collections.Generic.IEnumerable<string> queryFields = null, string outputContentFormat = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.AnalyzeOutputOption> output = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.AnalyzeResult> AnalyzeDocument(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.AnalyzeDocumentOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> AnalyzeDocument(Azure.WaitUntil waitUntil, string modelId, Azure.Core.RequestContent content, string pages = null, string locale = null, string stringIndexType = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentAnalysisFeature> features = null, System.Collections.Generic.IEnumerable<string> queryFields = null, string outputContentFormat = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.AnalyzeOutputOption> output = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.AnalyzeResult> AnalyzeDocument(Azure.WaitUntil waitUntil, string modelId, System.BinaryData bytesSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.AnalyzeResult> AnalyzeDocument(Azure.WaitUntil waitUntil, string modelId, System.Uri uriSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.AnalyzeResult>> AnalyzeDocumentAsync(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.AnalyzeDocumentOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> AnalyzeDocumentAsync(Azure.WaitUntil waitUntil, string modelId, Azure.Core.RequestContent content, string pages = null, string locale = null, string stringIndexType = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentAnalysisFeature> features = null, System.Collections.Generic.IEnumerable<string> queryFields = null, string outputContentFormat = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.AnalyzeOutputOption> output = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.AnalyzeResult>> AnalyzeDocumentAsync(Azure.WaitUntil waitUntil, string modelId, System.BinaryData bytesSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.AnalyzeResult>> AnalyzeDocumentAsync(Azure.WaitUntil waitUntil, string modelId, System.Uri uriSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.AnalyzeResult> ClassifyDocument(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.ClassifyDocumentOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> ClassifyDocument(Azure.WaitUntil waitUntil, string classifierId, Azure.Core.RequestContent content, string stringIndexType = null, string split = null, string pages = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.AnalyzeResult>> ClassifyDocumentAsync(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.ClassifyDocumentOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ClassifyDocumentAsync(Azure.WaitUntil waitUntil, string classifierId, Azure.Core.RequestContent content, string stringIndexType = null, string split = null, string pages = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteAnalyzeBatchResult(string modelId, string resultId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAnalyzeBatchResultAsync(string modelId, string resultId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteAnalyzeResult(string modelId, string resultId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAnalyzeResultAsync(string modelId, string resultId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAnalyzeBatchResult(string modelId, string resultId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.DocumentIntelligence.AnalyzeBatchOperationDetails> GetAnalyzeBatchResult(string modelId, string resultId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAnalyzeBatchResultAsync(string modelId, string resultId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.DocumentIntelligence.AnalyzeBatchOperationDetails>> GetAnalyzeBatchResultAsync(string modelId, string resultId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAnalyzeBatchResults(string modelId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.DocumentIntelligence.AnalyzeBatchOperationDetails> GetAnalyzeBatchResults(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAnalyzeBatchResultsAsync(string modelId, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.DocumentIntelligence.AnalyzeBatchOperationDetails> GetAnalyzeBatchResultsAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetAnalyzeResultFigure(string modelId, string resultId, string figureId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetAnalyzeResultFigure(string modelId, string resultId, string figureId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAnalyzeResultFigureAsync(string modelId, string resultId, string figureId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetAnalyzeResultFigureAsync(string modelId, string resultId, string figureId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetAnalyzeResultPdf(string modelId, string resultId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetAnalyzeResultPdf(string modelId, string resultId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAnalyzeResultPdfAsync(string modelId, string resultId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetAnalyzeResultPdfAsync(string modelId, string resultId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DocumentIntelligenceClientOptions : Azure.Core.ClientOptions
    {
        public DocumentIntelligenceClientOptions(Azure.AI.DocumentIntelligence.DocumentIntelligenceClientOptions.ServiceVersion version = Azure.AI.DocumentIntelligence.DocumentIntelligenceClientOptions.ServiceVersion.V2024_11_30) { }
        public enum ServiceVersion
        {
            V2024_11_30 = 1,
        }
    }
    public partial class DocumentIntelligenceError : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceError>
    {
        internal DocumentIntelligenceError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentIntelligenceError> Details { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentIntelligenceInnerError InnerError { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentIntelligenceError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentIntelligenceError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentIntelligenceError System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentIntelligenceError System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentIntelligenceInnerError : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceInnerError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceInnerError>
    {
        internal DocumentIntelligenceInnerError() { }
        public string Code { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentIntelligenceInnerError InnerError { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentIntelligenceInnerError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentIntelligenceInnerError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentIntelligenceInnerError System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceInnerError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceInnerError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentIntelligenceInnerError System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceInnerError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceInnerError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceInnerError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class DocumentIntelligenceModelFactory
    {
        public static Azure.AI.DocumentIntelligence.AddressValue AddressValue(string houseNumber = null, string poBox = null, string road = null, string city = null, string state = null, string postalCode = null, string countryRegion = null, string streetAddress = null, string unit = null, string cityDistrict = null, string stateDistrict = null, string suburb = null, string house = null, string level = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.AnalyzeBatchDocumentsOptions AnalyzeBatchDocumentsOptions(Azure.AI.DocumentIntelligence.BlobContentSource blobSource = null, Azure.AI.DocumentIntelligence.BlobFileListContentSource blobFileListSource = null, System.Uri resultContainerUri = null, string resultPrefix = null, bool? overwriteExisting = default(bool?)) { throw null; }
        public static Azure.AI.DocumentIntelligence.AnalyzeBatchOperationDetails AnalyzeBatchOperationDetails(string resultId = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus status = default(Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus), System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), int? percentCompleted = default(int?), Azure.AI.DocumentIntelligence.DocumentIntelligenceError error = null, Azure.AI.DocumentIntelligence.AnalyzeBatchResult result = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.AnalyzeBatchResult AnalyzeBatchResult(int succeededCount = 0, int failedCount = 0, int skippedCount = 0, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.AnalyzeBatchResultDetails> details = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.AnalyzeBatchResultDetails AnalyzeBatchResultDetails(Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus status = default(Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus), System.Uri sourceUri = null, System.Uri resultUri = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceError error = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.AnalyzedDocument AnalyzedDocument(string documentType = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, Azure.AI.DocumentIntelligence.DocumentFieldDictionary fields = null, float confidence = 0f) { throw null; }
        public static Azure.AI.DocumentIntelligence.AnalyzedDocument AnalyzedDocument(string documentType = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentField> fieldsPrivate = null, float confidence = 0f) { throw null; }
        public static Azure.AI.DocumentIntelligence.AnalyzeResult AnalyzeResult(string apiVersion = null, string modelId = null, Azure.AI.DocumentIntelligence.DocumentContentFormat? contentFormat = default(Azure.AI.DocumentIntelligence.DocumentContentFormat?), string content = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentPage> pages = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentParagraph> paragraphs = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentTable> tables = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentFigure> figures = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSection> sections = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentKeyValuePair> keyValuePairs = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentStyle> styles = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentLanguage> languages = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.AnalyzedDocument> documents = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentIntelligenceWarning> warnings = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.AuthorizeClassifierCopyOptions AuthorizeClassifierCopyOptions(string classifierId = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.AuthorizeModelCopyOptions AuthorizeModelCopyOptions(string modelId = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.BlobContentSource BlobContentSource(System.Uri containerUri = null, string prefix = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.BlobFileListContentSource BlobFileListContentSource(System.Uri containerUri = null, string fileList = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.BoundingRegion BoundingRegion(int pageNumber = 0, System.Collections.Generic.IEnumerable<float> polygon = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.BuildClassifierOptions BuildClassifierOptions(string classifierId = null, string description = null, string baseClassifierId = null, System.Collections.Generic.IDictionary<string, Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails> documentTypes = null, bool? allowOverwrite = default(bool?)) { throw null; }
        public static Azure.AI.DocumentIntelligence.BuildDocumentModelOptions BuildDocumentModelOptions(string modelId = null, string description = null, Azure.AI.DocumentIntelligence.DocumentBuildMode buildMode = default(Azure.AI.DocumentIntelligence.DocumentBuildMode), Azure.AI.DocumentIntelligence.BlobContentSource blobSource = null, Azure.AI.DocumentIntelligence.BlobFileListContentSource blobFileListSource = null, System.Collections.Generic.IDictionary<string, string> tags = null, float? maxTrainingHours = default(float?), bool? allowOverwrite = default(bool?)) { throw null; }
        public static Azure.AI.DocumentIntelligence.ClassifierCopyAuthorization ClassifierCopyAuthorization(string targetResourceId = null, string targetResourceRegion = null, string targetClassifierId = null, System.Uri targetClassifierLocation = null, string accessToken = null, System.DateTimeOffset expiresOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.DocumentIntelligence.ComposeModelOptions ComposeModelOptions(string modelId = null, string description = null, string classifierId = null, Azure.AI.DocumentIntelligence.SplitMode? split = default(Azure.AI.DocumentIntelligence.SplitMode?), System.Collections.Generic.IDictionary<string, Azure.AI.DocumentIntelligence.DocumentTypeDetails> documentTypes = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.CurrencyValue CurrencyValue(double amount = 0, string currencySymbol = null, string currencyCode = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.CustomDocumentModelsDetails CustomDocumentModelsDetails(int count = 0, int limit = 0) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentBarcode DocumentBarcode(Azure.AI.DocumentIntelligence.DocumentBarcodeKind kind = default(Azure.AI.DocumentIntelligence.DocumentBarcodeKind), string value = null, System.Collections.Generic.IEnumerable<float> polygon = null, Azure.AI.DocumentIntelligence.DocumentSpan span = default(Azure.AI.DocumentIntelligence.DocumentSpan), float confidence = 0f) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentCaption DocumentCaption(string content = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, System.Collections.Generic.IEnumerable<string> elements = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails DocumentClassifierBuildOperationDetails(string operationId = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus status = default(Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus), int? percentCompleted = default(int?), System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.Uri resourceLocation = null, string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceError error = null, Azure.AI.DocumentIntelligence.DocumentClassifierDetails result = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentClassifierCopyToOperationDetails DocumentClassifierCopyToOperationDetails(string operationId = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus status = default(Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus), int? percentCompleted = default(int?), System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.Uri resourceLocation = null, string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceError error = null, Azure.AI.DocumentIntelligence.DocumentClassifierDetails result = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentClassifierDetails DocumentClassifierDetails(string classifierId = null, string description = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), string apiVersion = null, string baseClassifierId = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails> documentTypes = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentIntelligenceWarning> warnings = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentField DocumentField(Azure.AI.DocumentIntelligence.DocumentFieldType fieldType = default(Azure.AI.DocumentIntelligence.DocumentFieldType), string valueString = null, System.DateTimeOffset? valueDate = default(System.DateTimeOffset?), System.TimeSpan? valueTime = default(System.TimeSpan?), string valuePhoneNumber = null, double? valueDouble = default(double?), long? valueInt64 = default(long?), Azure.AI.DocumentIntelligence.DocumentSelectionMarkState? valueSelectionMark = default(Azure.AI.DocumentIntelligence.DocumentSelectionMarkState?), Azure.AI.DocumentIntelligence.DocumentSignatureType? valueSignature = default(Azure.AI.DocumentIntelligence.DocumentSignatureType?), string valueCountryRegion = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentField> valueList = null, Azure.AI.DocumentIntelligence.DocumentFieldDictionary valueDictionary = null, Azure.AI.DocumentIntelligence.CurrencyValue valueCurrency = null, Azure.AI.DocumentIntelligence.AddressValue valueAddress = null, bool? valueBoolean = default(bool?), System.Collections.Generic.IEnumerable<string> valueSelectionGroup = null, string content = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, float? confidence = default(float?)) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentField DocumentField(Azure.AI.DocumentIntelligence.DocumentFieldType fieldType = default(Azure.AI.DocumentIntelligence.DocumentFieldType), string valueString = null, System.DateTimeOffset? valueDate = default(System.DateTimeOffset?), System.TimeSpan? valueTime = default(System.TimeSpan?), string valuePhoneNumber = null, double? valueDouble = default(double?), long? valueInt64 = default(long?), Azure.AI.DocumentIntelligence.DocumentSelectionMarkState? valueSelectionMark = default(Azure.AI.DocumentIntelligence.DocumentSelectionMarkState?), Azure.AI.DocumentIntelligence.DocumentSignatureType? valueSignature = default(Azure.AI.DocumentIntelligence.DocumentSignatureType?), string valueCountryRegion = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentField> valueList = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentField> valueObject = null, Azure.AI.DocumentIntelligence.CurrencyValue valueCurrency = null, Azure.AI.DocumentIntelligence.AddressValue valueAddress = null, bool? valueBoolean = default(bool?), System.Collections.Generic.IEnumerable<string> valueSelectionGroup = null, string content = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, float? confidence = default(float?)) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentFieldDictionary DocumentFieldDictionary(System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentField> items) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentFieldSchema DocumentFieldSchema(Azure.AI.DocumentIntelligence.DocumentFieldType fieldType = default(Azure.AI.DocumentIntelligence.DocumentFieldType), string description = null, string example = null, Azure.AI.DocumentIntelligence.DocumentFieldSchema items = null, System.Collections.Generic.IDictionary<string, Azure.AI.DocumentIntelligence.DocumentFieldSchema> properties = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentFigure DocumentFigure(System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, System.Collections.Generic.IEnumerable<string> elements = null, Azure.AI.DocumentIntelligence.DocumentCaption caption = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentFootnote> footnotes = null, string id = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentFootnote DocumentFootnote(string content = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, System.Collections.Generic.IEnumerable<string> elements = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentFormula DocumentFormula(Azure.AI.DocumentIntelligence.DocumentFormulaKind kind = default(Azure.AI.DocumentIntelligence.DocumentFormulaKind), string value = null, System.Collections.Generic.IEnumerable<float> polygon = null, Azure.AI.DocumentIntelligence.DocumentSpan span = default(Azure.AI.DocumentIntelligence.DocumentSpan), float confidence = 0f) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentIntelligenceError DocumentIntelligenceError(string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentIntelligenceError> details = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceInnerError innerError = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentIntelligenceInnerError DocumentIntelligenceInnerError(string code = null, string message = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceInnerError innerError = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails DocumentIntelligenceOperationDetails(string operationId = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus status = default(Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus), int? percentCompleted = default(int?), System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), string kind = null, System.Uri resourceLocation = null, string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceError error = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentIntelligenceResourceDetails DocumentIntelligenceResourceDetails(Azure.AI.DocumentIntelligence.CustomDocumentModelsDetails customDocumentModels = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentIntelligenceWarning DocumentIntelligenceWarning(string code = null, string message = null, string target = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentKeyValueElement DocumentKeyValueElement(string content = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentKeyValuePair DocumentKeyValuePair(Azure.AI.DocumentIntelligence.DocumentKeyValueElement key = null, Azure.AI.DocumentIntelligence.DocumentKeyValueElement value = null, float confidence = 0f) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentLanguage DocumentLanguage(string locale = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, float confidence = 0f) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentLine DocumentLine(string content = null, System.Collections.Generic.IEnumerable<float> polygon = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails DocumentModelBuildOperationDetails(string operationId = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus status = default(Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus), int? percentCompleted = default(int?), System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.Uri resourceLocation = null, string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceError error = null, Azure.AI.DocumentIntelligence.DocumentModelDetails result = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails DocumentModelComposeOperationDetails(string operationId = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus status = default(Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus), int? percentCompleted = default(int?), System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.Uri resourceLocation = null, string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceError error = null, Azure.AI.DocumentIntelligence.DocumentModelDetails result = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentModelCopyToOperationDetails DocumentModelCopyToOperationDetails(string operationId = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus status = default(Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus), int? percentCompleted = default(int?), System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.Uri resourceLocation = null, string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceError error = null, Azure.AI.DocumentIntelligence.DocumentModelDetails result = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentModelDetails DocumentModelDetails(string modelId = null, string description = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.AI.DocumentIntelligence.DocumentBuildMode? buildMode = default(Azure.AI.DocumentIntelligence.DocumentBuildMode?), Azure.AI.DocumentIntelligence.BlobContentSource blobSource = null, Azure.AI.DocumentIntelligence.BlobFileListContentSource blobFileListSource = null, string classifierId = null, Azure.AI.DocumentIntelligence.SplitMode? split = default(Azure.AI.DocumentIntelligence.SplitMode?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentTypeDetails> documentTypes = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentIntelligenceWarning> warnings = null, float? trainingHours = default(float?)) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentPage DocumentPage(int pageNumber = 0, float? angle = default(float?), float? width = default(float?), float? height = default(float?), Azure.AI.DocumentIntelligence.LengthUnit? unit = default(Azure.AI.DocumentIntelligence.LengthUnit?), System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentWord> words = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSelectionMark> selectionMarks = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentLine> lines = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentBarcode> barcodes = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentFormula> formulas = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentParagraph DocumentParagraph(Azure.AI.DocumentIntelligence.ParagraphRole? role = default(Azure.AI.DocumentIntelligence.ParagraphRole?), string content = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentSection DocumentSection(System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, System.Collections.Generic.IEnumerable<string> elements = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentSelectionMark DocumentSelectionMark(Azure.AI.DocumentIntelligence.DocumentSelectionMarkState state = default(Azure.AI.DocumentIntelligence.DocumentSelectionMarkState), System.Collections.Generic.IEnumerable<float> polygon = null, Azure.AI.DocumentIntelligence.DocumentSpan span = default(Azure.AI.DocumentIntelligence.DocumentSpan), float confidence = 0f) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentSpan DocumentSpan(int offset = 0, int length = 0) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentStyle DocumentStyle(bool? isHandwritten = default(bool?), string similarFontFamily = null, Azure.AI.DocumentIntelligence.DocumentFontStyle? fontStyle = default(Azure.AI.DocumentIntelligence.DocumentFontStyle?), Azure.AI.DocumentIntelligence.DocumentFontWeight? fontWeight = default(Azure.AI.DocumentIntelligence.DocumentFontWeight?), string color = null, string backgroundColor = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, float confidence = 0f) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentTable DocumentTable(int rowCount = 0, int columnCount = 0, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentTableCell> cells = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, Azure.AI.DocumentIntelligence.DocumentCaption caption = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentFootnote> footnotes = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentTableCell DocumentTableCell(Azure.AI.DocumentIntelligence.DocumentTableCellKind? kind = default(Azure.AI.DocumentIntelligence.DocumentTableCellKind?), int rowIndex = 0, int columnIndex = 0, int? rowSpan = default(int?), int? columnSpan = default(int?), string content = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, System.Collections.Generic.IEnumerable<string> elements = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentTypeDetails DocumentTypeDetails(string description = null, Azure.AI.DocumentIntelligence.DocumentBuildMode? buildMode = default(Azure.AI.DocumentIntelligence.DocumentBuildMode?), System.Collections.Generic.IDictionary<string, Azure.AI.DocumentIntelligence.DocumentFieldSchema> fieldSchema = null, System.Collections.Generic.IDictionary<string, float> fieldConfidence = null, string modelId = null, float? confidenceThreshold = default(float?), System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentAnalysisFeature> features = null, System.Collections.Generic.IEnumerable<string> queryFields = null, int? maxDocumentsToAnalyze = default(int?)) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentWord DocumentWord(string content = null, System.Collections.Generic.IEnumerable<float> polygon = null, Azure.AI.DocumentIntelligence.DocumentSpan span = default(Azure.AI.DocumentIntelligence.DocumentSpan), float confidence = 0f) { throw null; }
        public static Azure.AI.DocumentIntelligence.ModelCopyAuthorization ModelCopyAuthorization(string targetResourceId = null, string targetResourceRegion = null, string targetModelId = null, System.Uri targetModelLocation = null, string accessToken = null, System.DateTimeOffset expiresOn = default(System.DateTimeOffset)) { throw null; }
    }
    public abstract partial class DocumentIntelligenceOperationDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails>
    {
        protected DocumentIntelligenceOperationDetails(string operationId, Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus status, System.DateTimeOffset createdOn, System.DateTimeOffset lastUpdatedOn, System.Uri resourceLocation) { }
        public string ApiVersion { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentIntelligenceError Error { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public string OperationId { get { throw null; } }
        public int? PercentCompleted { get { throw null; } }
        public System.Uri ResourceLocation { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails (Azure.Response response) { throw null; }
        protected virtual Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentIntelligenceOperationStatus : System.IEquatable<Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentIntelligenceOperationStatus(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus Canceled { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus Failed { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus NotStarted { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus Running { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus Skipped { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus left, Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus (string value) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus left, Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentIntelligenceResourceDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceResourceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceResourceDetails>
    {
        internal DocumentIntelligenceResourceDetails() { }
        public Azure.AI.DocumentIntelligence.CustomDocumentModelsDetails CustomDocumentModels { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentIntelligenceResourceDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.DocumentIntelligence.DocumentIntelligenceResourceDetails (Azure.Response response) { throw null; }
        protected virtual Azure.AI.DocumentIntelligence.DocumentIntelligenceResourceDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentIntelligenceResourceDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceResourceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceResourceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentIntelligenceResourceDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceResourceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceResourceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceResourceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentIntelligenceWarning : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceWarning>
    {
        internal DocumentIntelligenceWarning() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentIntelligenceWarning JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentIntelligenceWarning PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentIntelligenceWarning System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentIntelligenceWarning System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentKeyValueElement : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentKeyValueElement>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentKeyValueElement>
    {
        internal DocumentKeyValueElement() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentKeyValueElement JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentKeyValueElement PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentKeyValueElement System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentKeyValueElement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentKeyValueElement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentKeyValueElement System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentKeyValueElement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentKeyValueElement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentKeyValueElement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentKeyValuePair : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentKeyValuePair>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentKeyValuePair>
    {
        internal DocumentKeyValuePair() { }
        public float Confidence { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentKeyValueElement Key { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentKeyValueElement Value { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentKeyValuePair JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentKeyValuePair PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentKeyValuePair System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentKeyValuePair>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentKeyValuePair>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentKeyValuePair System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentKeyValuePair>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentKeyValuePair>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentKeyValuePair>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentLanguage>
    {
        internal DocumentLanguage() { }
        public float Confidence { get { throw null; } }
        public string Locale { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentLanguage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentLanguage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentLine : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentLine>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentLine>
    {
        internal DocumentLine() { }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> Polygon { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentLine JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentLine PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentLine System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentLine>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentLine>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentLine System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentLine>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentLine>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentLine>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentModelBuildOperationDetails : Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails>
    {
        internal DocumentModelBuildOperationDetails() : base (default(string), default(Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus), default(System.DateTimeOffset), default(System.DateTimeOffset), default(System.Uri)) { }
        public Azure.AI.DocumentIntelligence.DocumentModelDetails Result { get { throw null; } }
        protected override Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentModelComposeOperationDetails : Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails>
    {
        internal DocumentModelComposeOperationDetails() : base (default(string), default(Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus), default(System.DateTimeOffset), default(System.DateTimeOffset), default(System.Uri)) { }
        public Azure.AI.DocumentIntelligence.DocumentModelDetails Result { get { throw null; } }
        protected override Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentModelCopyToOperationDetails : Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentModelCopyToOperationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelCopyToOperationDetails>
    {
        internal DocumentModelCopyToOperationDetails() : base (default(string), default(Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationStatus), default(System.DateTimeOffset), default(System.DateTimeOffset), default(System.Uri)) { }
        public Azure.AI.DocumentIntelligence.DocumentModelDetails Result { get { throw null; } }
        protected override Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.DocumentIntelligence.DocumentIntelligenceOperationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentModelCopyToOperationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentModelCopyToOperationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentModelCopyToOperationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentModelCopyToOperationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelCopyToOperationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelCopyToOperationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelCopyToOperationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentModelDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentModelDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelDetails>
    {
        internal DocumentModelDetails() { }
        public string ApiVersion { get { throw null; } }
        public Azure.AI.DocumentIntelligence.BlobFileListContentSource BlobFileListSource { get { throw null; } }
        public Azure.AI.DocumentIntelligence.BlobContentSource BlobSource { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentBuildMode? BuildMode { get { throw null; } }
        public string ClassifierId { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentTypeDetails> DocumentTypes { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string ModelId { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public Azure.AI.DocumentIntelligence.SplitMode? Split { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public float? TrainingHours { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentIntelligenceWarning> Warnings { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentModelDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.DocumentIntelligence.DocumentModelDetails (Azure.Response response) { throw null; }
        protected virtual Azure.AI.DocumentIntelligence.DocumentModelDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentModelDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentModelDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentModelDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentModelDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentPage : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentPage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentPage>
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
        public Azure.AI.DocumentIntelligence.LengthUnit? Unit { get { throw null; } }
        public float? Width { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentWord> Words { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentPage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentPage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentPage System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentPage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentPage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentPage System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentPage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentPage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentPage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentParagraph : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentParagraph>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentParagraph>
    {
        internal DocumentParagraph() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public string Content { get { throw null; } }
        public Azure.AI.DocumentIntelligence.ParagraphRole? Role { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentParagraph JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentParagraph PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentParagraph System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentParagraph>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentParagraph>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentParagraph System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentParagraph>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentParagraph>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentParagraph>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentSection : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentSection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentSection>
    {
        internal DocumentSection() { }
        public System.Collections.Generic.IReadOnlyList<string> Elements { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentSection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentSection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentSection System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentSection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentSection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentSection System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentSection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentSection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentSection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentSelectionMark : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentSelectionMark>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentSelectionMark>
    {
        internal DocumentSelectionMark() { }
        public float Confidence { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> Polygon { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentSpan Span { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentSelectionMarkState State { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentSelectionMark JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentSelectionMark PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentSelectionMark System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentSelectionMark>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentSelectionMark>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentSelectionMark System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentSelectionMark>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentSelectionMark>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentSelectionMark>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentSelectionMarkState : System.IEquatable<Azure.AI.DocumentIntelligence.DocumentSelectionMarkState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentSelectionMarkState(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentSelectionMarkState Selected { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentSelectionMarkState Unselected { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.DocumentSelectionMarkState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.DocumentSelectionMarkState left, Azure.AI.DocumentIntelligence.DocumentSelectionMarkState right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentSelectionMarkState (string value) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentSelectionMarkState? (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.DocumentSelectionMarkState left, Azure.AI.DocumentIntelligence.DocumentSelectionMarkState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentSignatureType : System.IEquatable<Azure.AI.DocumentIntelligence.DocumentSignatureType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentSignatureType(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentSignatureType Signed { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentSignatureType Unsigned { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.DocumentSignatureType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.DocumentSignatureType left, Azure.AI.DocumentIntelligence.DocumentSignatureType right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentSignatureType (string value) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentSignatureType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.DocumentSignatureType left, Azure.AI.DocumentIntelligence.DocumentSignatureType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentSpan : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentSpan>, System.ClientModel.Primitives.IJsonModel<object>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentSpan>, System.ClientModel.Primitives.IPersistableModel<object>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentSpan() { throw null; }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        Azure.AI.DocumentIntelligence.DocumentSpan System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentSpan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentSpan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        object System.ClientModel.Primitives.IJsonModel<System.Object>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<System.Object>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentSpan System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentSpan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentSpan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentSpan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        object System.ClientModel.Primitives.IPersistableModel<System.Object>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<System.Object>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<System.Object>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentStyle : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentStyle>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentStyle>
    {
        internal DocumentStyle() { }
        public string BackgroundColor { get { throw null; } }
        public string Color { get { throw null; } }
        public float Confidence { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentFontStyle? FontStyle { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentFontWeight? FontWeight { get { throw null; } }
        public bool? IsHandwritten { get { throw null; } }
        public string SimilarFontFamily { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentStyle JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentStyle PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentStyle System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentStyle>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentStyle>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentStyle System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentStyle>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentStyle>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentStyle>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentTable : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentTable>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentTable>
    {
        internal DocumentTable() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentCaption Caption { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentTableCell> Cells { get { throw null; } }
        public int ColumnCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentFootnote> Footnotes { get { throw null; } }
        public int RowCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentTable JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentTable PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentTable System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentTable>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentTable>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentTable System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentTable>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentTable>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentTable>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentTableCell : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentTableCell>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentTableCell>
    {
        internal DocumentTableCell() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public int ColumnIndex { get { throw null; } }
        public int? ColumnSpan { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Elements { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentTableCellKind? Kind { get { throw null; } }
        public int RowIndex { get { throw null; } }
        public int? RowSpan { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentTableCell JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentTableCell PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentTableCell System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentTableCell>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentTableCell>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentTableCell System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentTableCell>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentTableCell>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentTableCell>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentTableCellKind : System.IEquatable<Azure.AI.DocumentIntelligence.DocumentTableCellKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentTableCellKind(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentTableCellKind ColumnHeader { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentTableCellKind Content { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentTableCellKind Description { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentTableCellKind RowHeader { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentTableCellKind StubHead { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.DocumentTableCellKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.DocumentTableCellKind left, Azure.AI.DocumentIntelligence.DocumentTableCellKind right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentTableCellKind (string value) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentTableCellKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.DocumentTableCellKind left, Azure.AI.DocumentIntelligence.DocumentTableCellKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentTypeDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentTypeDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentTypeDetails>
    {
        public DocumentTypeDetails() { }
        public Azure.AI.DocumentIntelligence.DocumentBuildMode? BuildMode { get { throw null; } set { } }
        public float? ConfidenceThreshold { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.DocumentIntelligence.DocumentAnalysisFeature> Features { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, float> FieldConfidence { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.DocumentIntelligence.DocumentFieldSchema> FieldSchema { get { throw null; } }
        public int? MaxDocumentsToAnalyze { get { throw null; } set { } }
        public string ModelId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> QueryFields { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentTypeDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentTypeDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentTypeDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentTypeDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentTypeDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentTypeDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentTypeDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentTypeDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentTypeDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentWord : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentWord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentWord>
    {
        internal DocumentWord() { }
        public float Confidence { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> Polygon { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentSpan Span { get { throw null; } }
        protected virtual Azure.AI.DocumentIntelligence.DocumentWord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.DocumentIntelligence.DocumentWord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.DocumentWord System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentWord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentWord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentWord System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentWord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentWord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentWord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LengthUnit : System.IEquatable<Azure.AI.DocumentIntelligence.LengthUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LengthUnit(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.LengthUnit Inch { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.LengthUnit Pixel { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.LengthUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.LengthUnit left, Azure.AI.DocumentIntelligence.LengthUnit right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.LengthUnit (string value) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.LengthUnit? (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.LengthUnit left, Azure.AI.DocumentIntelligence.LengthUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ModelCopyAuthorization : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ModelCopyAuthorization>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ModelCopyAuthorization>
    {
        public ModelCopyAuthorization(string targetResourceId, string targetResourceRegion, string targetModelId, System.Uri targetModelLocation, string accessToken, System.DateTimeOffset expiresOn) { }
        public string AccessToken { get { throw null; } set { } }
        public System.DateTimeOffset ExpiresOn { get { throw null; } set { } }
        public string TargetModelId { get { throw null; } set { } }
        public System.Uri TargetModelLocation { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } set { } }
        public string TargetResourceRegion { get { throw null; } set { } }
        protected virtual Azure.AI.DocumentIntelligence.ModelCopyAuthorization JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.DocumentIntelligence.ModelCopyAuthorization (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.DocumentIntelligence.ModelCopyAuthorization modelCopyAuthorization) { throw null; }
        protected virtual Azure.AI.DocumentIntelligence.ModelCopyAuthorization PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.DocumentIntelligence.ModelCopyAuthorization System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ModelCopyAuthorization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ModelCopyAuthorization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.ModelCopyAuthorization System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ModelCopyAuthorization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ModelCopyAuthorization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ModelCopyAuthorization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParagraphRole : System.IEquatable<Azure.AI.DocumentIntelligence.ParagraphRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParagraphRole(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.ParagraphRole Footnote { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.ParagraphRole FormulaBlock { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.ParagraphRole PageFooter { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.ParagraphRole PageHeader { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.ParagraphRole PageNumber { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.ParagraphRole SectionHeading { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.ParagraphRole Title { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.ParagraphRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.ParagraphRole left, Azure.AI.DocumentIntelligence.ParagraphRole right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.ParagraphRole (string value) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.ParagraphRole? (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.ParagraphRole left, Azure.AI.DocumentIntelligence.ParagraphRole right) { throw null; }
        public override string ToString() { throw null; }
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
        public static implicit operator Azure.AI.DocumentIntelligence.SplitMode? (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.SplitMode left, Azure.AI.DocumentIntelligence.SplitMode right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class DocumentIntelligenceClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.DocumentIntelligence.DocumentIntelligenceAdministrationClient, Azure.AI.DocumentIntelligence.DocumentIntelligenceClientOptions> AddDocumentIntelligenceAdministrationClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.DocumentIntelligence.DocumentIntelligenceAdministrationClient, Azure.AI.DocumentIntelligence.DocumentIntelligenceClientOptions> AddDocumentIntelligenceAdministrationClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.DocumentIntelligence.DocumentIntelligenceAdministrationClient, Azure.AI.DocumentIntelligence.DocumentIntelligenceClientOptions> AddDocumentIntelligenceAdministrationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.DocumentIntelligence.DocumentIntelligenceClient, Azure.AI.DocumentIntelligence.DocumentIntelligenceClientOptions> AddDocumentIntelligenceClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.DocumentIntelligence.DocumentIntelligenceClient, Azure.AI.DocumentIntelligence.DocumentIntelligenceClientOptions> AddDocumentIntelligenceClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.DocumentIntelligence.DocumentIntelligenceClient, Azure.AI.DocumentIntelligence.DocumentIntelligenceClientOptions> AddDocumentIntelligenceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
