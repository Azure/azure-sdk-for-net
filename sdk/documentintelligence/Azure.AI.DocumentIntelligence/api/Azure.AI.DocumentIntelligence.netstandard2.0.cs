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
        Azure.AI.DocumentIntelligence.AddressValue System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AddressValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AddressValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.AddressValue System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AddressValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AddressValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AddressValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class AIDocumentIntelligenceModelFactory
    {
        public static Azure.AI.DocumentIntelligence.AddressValue AddressValue(string houseNumber = null, string poBox = null, string road = null, string city = null, string state = null, string postalCode = null, string countryRegion = null, string streetAddress = null, string unit = null, string cityDistrict = null, string stateDistrict = null, string suburb = null, string house = null, string level = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.AnalyzedDocument AnalyzedDocument(string docType = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentField> fields = null, float confidence = 0f) { throw null; }
        public static Azure.AI.DocumentIntelligence.AnalyzeResult AnalyzeResult(string apiVersion = null, string modelId = null, Azure.AI.DocumentIntelligence.StringIndexType stringIndexType = default(Azure.AI.DocumentIntelligence.StringIndexType), Azure.AI.DocumentIntelligence.ContentFormat? contentFormat = default(Azure.AI.DocumentIntelligence.ContentFormat?), string content = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentPage> pages = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentParagraph> paragraphs = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentTable> tables = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentFigure> figures = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentList> lists = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSection> sections = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentKeyValuePair> keyValuePairs = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentStyle> styles = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentLanguage> languages = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.AnalyzedDocument> documents = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.AuthorizeCopyContent AuthorizeCopyContent(string modelId = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.BoundingRegion BoundingRegion(int pageNumber = 0, System.Collections.Generic.IEnumerable<float> polygon = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.BuildDocumentClassifierContent BuildDocumentClassifierContent(string classifierId = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails> docTypes = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.BuildDocumentModelContent BuildDocumentModelContent(string modelId = null, string description = null, Azure.AI.DocumentIntelligence.DocumentBuildMode buildMode = default(Azure.AI.DocumentIntelligence.DocumentBuildMode), Azure.AI.DocumentIntelligence.AzureBlobContentSource azureBlobSource = null, Azure.AI.DocumentIntelligence.AzureBlobFileListContentSource azureBlobFileListSource = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.ComposeDocumentModelContent ComposeDocumentModelContent(string modelId = null, string description = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.ComponentDocumentModelDetails> componentModels = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.CurrencyValue CurrencyValue(double amount = 0, string currencySymbol = null, string currencyCode = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.CustomDocumentModelsDetails CustomDocumentModelsDetails(int count = 0, int limit = 0) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentBarcode DocumentBarcode(Azure.AI.DocumentIntelligence.DocumentBarcodeKind kind = default(Azure.AI.DocumentIntelligence.DocumentBarcodeKind), string value = null, System.Collections.Generic.IEnumerable<float> polygon = null, Azure.AI.DocumentIntelligence.DocumentSpan span = null, float confidence = 0f) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentCaption DocumentCaption(string content = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, System.Collections.Generic.IEnumerable<string> elements = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails DocumentClassifierBuildOperationDetails(string operationId = null, Azure.AI.DocumentIntelligence.OperationStatus status = default(Azure.AI.DocumentIntelligence.OperationStatus), int? percentCompleted = default(int?), System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.Uri resourceLocation = null, string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceError error = null, Azure.AI.DocumentIntelligence.DocumentClassifierDetails result = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentClassifierDetails DocumentClassifierDetails(string classifierId = null, string description = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails> docTypes = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentField DocumentField(Azure.AI.DocumentIntelligence.DocumentFieldType type = default(Azure.AI.DocumentIntelligence.DocumentFieldType), string valueString = null, System.DateTimeOffset? valueDate = default(System.DateTimeOffset?), System.TimeSpan? valueTime = default(System.TimeSpan?), string valuePhoneNumber = null, double? valueNumber = default(double?), long? valueInteger = default(long?), Azure.AI.DocumentIntelligence.DocumentSelectionMarkState? valueSelectionMark = default(Azure.AI.DocumentIntelligence.DocumentSelectionMarkState?), Azure.AI.DocumentIntelligence.DocumentSignatureType? valueSignature = default(Azure.AI.DocumentIntelligence.DocumentSignatureType?), string valueCountryRegion = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentField> valueArray = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentField> valueObject = null, Azure.AI.DocumentIntelligence.CurrencyValue valueCurrency = null, Azure.AI.DocumentIntelligence.AddressValue valueAddress = null, bool? valueBoolean = default(bool?), string content = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, float? confidence = default(float?)) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentFieldSchema DocumentFieldSchema(Azure.AI.DocumentIntelligence.DocumentFieldType type = default(Azure.AI.DocumentIntelligence.DocumentFieldType), string description = null, string example = null, Azure.AI.DocumentIntelligence.DocumentFieldSchema items = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentFieldSchema> properties = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentFigure DocumentFigure(System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, System.Collections.Generic.IEnumerable<string> elements = null, Azure.AI.DocumentIntelligence.DocumentCaption caption = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentFootnote> footnotes = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentFootnote DocumentFootnote(string content = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, System.Collections.Generic.IEnumerable<string> elements = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentFormula DocumentFormula(Azure.AI.DocumentIntelligence.DocumentFormulaKind kind = default(Azure.AI.DocumentIntelligence.DocumentFormulaKind), string value = null, System.Collections.Generic.IEnumerable<float> polygon = null, Azure.AI.DocumentIntelligence.DocumentSpan span = null, float confidence = 0f) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentIntelligenceError DocumentIntelligenceError(string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentIntelligenceError> details = null, Azure.AI.DocumentIntelligence.InnerError innererror = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentKeyValueElement DocumentKeyValueElement(string content = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentKeyValuePair DocumentKeyValuePair(Azure.AI.DocumentIntelligence.DocumentKeyValueElement key = null, Azure.AI.DocumentIntelligence.DocumentKeyValueElement value = null, float confidence = 0f) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentLanguage DocumentLanguage(string locale = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, float confidence = 0f) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentLine DocumentLine(string content = null, System.Collections.Generic.IEnumerable<float> polygon = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentList DocumentList(System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentListItem> items = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentListItem DocumentListItem(int level = 0, string content = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, System.Collections.Generic.IEnumerable<string> elements = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails DocumentModelBuildOperationDetails(string operationId = null, Azure.AI.DocumentIntelligence.OperationStatus status = default(Azure.AI.DocumentIntelligence.OperationStatus), int? percentCompleted = default(int?), System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.Uri resourceLocation = null, string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceError error = null, Azure.AI.DocumentIntelligence.DocumentModelDetails result = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails DocumentModelComposeOperationDetails(string operationId = null, Azure.AI.DocumentIntelligence.OperationStatus status = default(Azure.AI.DocumentIntelligence.OperationStatus), int? percentCompleted = default(int?), System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.Uri resourceLocation = null, string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceError error = null, Azure.AI.DocumentIntelligence.DocumentModelDetails result = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentModelCopyToOperationDetails DocumentModelCopyToOperationDetails(string operationId = null, Azure.AI.DocumentIntelligence.OperationStatus status = default(Azure.AI.DocumentIntelligence.OperationStatus), int? percentCompleted = default(int?), System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.Uri resourceLocation = null, string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceError error = null, Azure.AI.DocumentIntelligence.DocumentModelDetails result = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentModelDetails DocumentModelDetails(string modelId = null, string description = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.AI.DocumentIntelligence.DocumentBuildMode? buildMode = default(Azure.AI.DocumentIntelligence.DocumentBuildMode?), Azure.AI.DocumentIntelligence.AzureBlobContentSource azureBlobSource = null, Azure.AI.DocumentIntelligence.AzureBlobFileListContentSource azureBlobFileListSource = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentTypeDetails> docTypes = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentPage DocumentPage(int pageNumber = 0, float? angle = default(float?), float? width = default(float?), float? height = default(float?), Azure.AI.DocumentIntelligence.LengthUnit? unit = default(Azure.AI.DocumentIntelligence.LengthUnit?), System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentWord> words = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSelectionMark> selectionMarks = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentLine> lines = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentBarcode> barcodes = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentFormula> formulas = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentParagraph DocumentParagraph(Azure.AI.DocumentIntelligence.ParagraphRole? role = default(Azure.AI.DocumentIntelligence.ParagraphRole?), string content = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentSection DocumentSection(System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, System.Collections.Generic.IEnumerable<string> elements = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentSelectionMark DocumentSelectionMark(Azure.AI.DocumentIntelligence.DocumentSelectionMarkState state = default(Azure.AI.DocumentIntelligence.DocumentSelectionMarkState), System.Collections.Generic.IEnumerable<float> polygon = null, Azure.AI.DocumentIntelligence.DocumentSpan span = null, float confidence = 0f) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentSpan DocumentSpan(int offset = 0, int length = 0) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentStyle DocumentStyle(bool? isHandwritten = default(bool?), string similarFontFamily = null, Azure.AI.DocumentIntelligence.FontStyle? fontStyle = default(Azure.AI.DocumentIntelligence.FontStyle?), Azure.AI.DocumentIntelligence.FontWeight? fontWeight = default(Azure.AI.DocumentIntelligence.FontWeight?), string color = null, string backgroundColor = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, float confidence = 0f) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentTable DocumentTable(int rowCount = 0, int columnCount = 0, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentTableCell> cells = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, Azure.AI.DocumentIntelligence.DocumentCaption caption = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentFootnote> footnotes = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentTableCell DocumentTableCell(Azure.AI.DocumentIntelligence.DocumentTableCellKind? kind = default(Azure.AI.DocumentIntelligence.DocumentTableCellKind?), int rowIndex = 0, int columnIndex = 0, int? rowSpan = default(int?), int? columnSpan = default(int?), string content = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentSpan> spans = null, System.Collections.Generic.IEnumerable<string> elements = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentTypeDetails DocumentTypeDetails(string description = null, Azure.AI.DocumentIntelligence.DocumentBuildMode? buildMode = default(Azure.AI.DocumentIntelligence.DocumentBuildMode?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentFieldSchema> fieldSchema = null, System.Collections.Generic.IReadOnlyDictionary<string, float> fieldConfidence = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.DocumentWord DocumentWord(string content = null, System.Collections.Generic.IEnumerable<float> polygon = null, Azure.AI.DocumentIntelligence.DocumentSpan span = null, float confidence = 0f) { throw null; }
        public static Azure.AI.DocumentIntelligence.InnerError InnerError(string code = null, string message = null, Azure.AI.DocumentIntelligence.InnerError innerErrorObject = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.OperationDetails OperationDetails(string operationId = null, Azure.AI.DocumentIntelligence.OperationStatus status = default(Azure.AI.DocumentIntelligence.OperationStatus), int? percentCompleted = default(int?), System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), string kind = "Unknown", System.Uri resourceLocation = null, string apiVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.AI.DocumentIntelligence.DocumentIntelligenceError error = null) { throw null; }
        public static Azure.AI.DocumentIntelligence.QuotaDetails QuotaDetails(int used = 0, int quota = 0, System.DateTimeOffset quotaResetDateTime = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.DocumentIntelligence.ResourceDetails ResourceDetails(Azure.AI.DocumentIntelligence.CustomDocumentModelsDetails customDocumentModels = null, Azure.AI.DocumentIntelligence.QuotaDetails customNeuralDocumentModelBuilds = null) { throw null; }
    }
    public partial class AnalyzedDocument : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzedDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzedDocument>
    {
        internal AnalyzedDocument() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public float Confidence { get { throw null; } }
        public string DocType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentField> Fields { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
        Azure.AI.DocumentIntelligence.AnalyzedDocument System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzedDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzedDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.AnalyzedDocument System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzedDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzedDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzedDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeDocumentContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeDocumentContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeDocumentContent>
    {
        public AnalyzeDocumentContent() { }
        public System.BinaryData Base64Source { get { throw null; } set { } }
        public System.Uri UrlSource { get { throw null; } set { } }
        Azure.AI.DocumentIntelligence.AnalyzeDocumentContent System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeDocumentContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeDocumentContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.AnalyzeDocumentContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeDocumentContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeDocumentContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeDocumentContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeResult>
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
        Azure.AI.DocumentIntelligence.AnalyzeResult System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AnalyzeResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.AnalyzeResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AnalyzeResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthorizeCopyContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AuthorizeCopyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AuthorizeCopyContent>
    {
        public AuthorizeCopyContent(string modelId) { }
        public string Description { get { throw null; } set { } }
        public string ModelId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.AI.DocumentIntelligence.AuthorizeCopyContent System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AuthorizeCopyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AuthorizeCopyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.AuthorizeCopyContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AuthorizeCopyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AuthorizeCopyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AuthorizeCopyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAIDocumentIntelligenceClientOptions : Azure.Core.ClientOptions
    {
        public AzureAIDocumentIntelligenceClientOptions(Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceClientOptions.ServiceVersion version = Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceClientOptions.ServiceVersion.V2023_10_31_Preview) { }
        public enum ServiceVersion
        {
            V2023_10_31_Preview = 1,
        }
    }
    public partial class AzureBlobContentSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AzureBlobContentSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AzureBlobContentSource>
    {
        public AzureBlobContentSource(System.Uri containerUrl) { }
        public System.Uri ContainerUrl { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
        Azure.AI.DocumentIntelligence.AzureBlobContentSource System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AzureBlobContentSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AzureBlobContentSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.AzureBlobContentSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AzureBlobContentSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AzureBlobContentSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AzureBlobContentSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureBlobFileListContentSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AzureBlobFileListContentSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AzureBlobFileListContentSource>
    {
        public AzureBlobFileListContentSource(System.Uri containerUrl, string fileList) { }
        public System.Uri ContainerUrl { get { throw null; } set { } }
        public string FileList { get { throw null; } set { } }
        Azure.AI.DocumentIntelligence.AzureBlobFileListContentSource System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AzureBlobFileListContentSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.AzureBlobFileListContentSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.AzureBlobFileListContentSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AzureBlobFileListContentSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AzureBlobFileListContentSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.AzureBlobFileListContentSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BoundingRegion : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BoundingRegion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BoundingRegion>
    {
        internal BoundingRegion() { }
        public int PageNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> Polygon { get { throw null; } }
        Azure.AI.DocumentIntelligence.BoundingRegion System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BoundingRegion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BoundingRegion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.BoundingRegion System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BoundingRegion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BoundingRegion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BoundingRegion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BuildDocumentClassifierContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BuildDocumentClassifierContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BuildDocumentClassifierContent>
    {
        public BuildDocumentClassifierContent(string classifierId, System.Collections.Generic.IDictionary<string, Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails> docTypes) { }
        public string ClassifierId { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails> DocTypes { get { throw null; } }
        Azure.AI.DocumentIntelligence.BuildDocumentClassifierContent System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BuildDocumentClassifierContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BuildDocumentClassifierContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.BuildDocumentClassifierContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BuildDocumentClassifierContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BuildDocumentClassifierContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BuildDocumentClassifierContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BuildDocumentModelContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BuildDocumentModelContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BuildDocumentModelContent>
    {
        public BuildDocumentModelContent(string modelId, Azure.AI.DocumentIntelligence.DocumentBuildMode buildMode) { }
        public Azure.AI.DocumentIntelligence.AzureBlobFileListContentSource AzureBlobFileListSource { get { throw null; } set { } }
        public Azure.AI.DocumentIntelligence.AzureBlobContentSource AzureBlobSource { get { throw null; } set { } }
        public Azure.AI.DocumentIntelligence.DocumentBuildMode BuildMode { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string ModelId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.AI.DocumentIntelligence.BuildDocumentModelContent System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BuildDocumentModelContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.BuildDocumentModelContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.BuildDocumentModelContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BuildDocumentModelContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BuildDocumentModelContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.BuildDocumentModelContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClassifierDocumentTypeDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails>
    {
        public ClassifierDocumentTypeDetails() { }
        public Azure.AI.DocumentIntelligence.AzureBlobFileListContentSource AzureBlobFileListSource { get { throw null; } set { } }
        public Azure.AI.DocumentIntelligence.AzureBlobContentSource AzureBlobSource { get { throw null; } set { } }
        public Azure.AI.DocumentIntelligence.ContentSourceKind? SourceKind { get { throw null; } set { } }
        Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClassifyDocumentContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ClassifyDocumentContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ClassifyDocumentContent>
    {
        public ClassifyDocumentContent() { }
        public System.BinaryData Base64Source { get { throw null; } set { } }
        public System.Uri UrlSource { get { throw null; } set { } }
        Azure.AI.DocumentIntelligence.ClassifyDocumentContent System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ClassifyDocumentContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ClassifyDocumentContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.ClassifyDocumentContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ClassifyDocumentContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ClassifyDocumentContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ClassifyDocumentContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentDocumentModelDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ComponentDocumentModelDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ComponentDocumentModelDetails>
    {
        public ComponentDocumentModelDetails(string modelId) { }
        public string ModelId { get { throw null; } }
        Azure.AI.DocumentIntelligence.ComponentDocumentModelDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ComponentDocumentModelDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ComponentDocumentModelDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.ComponentDocumentModelDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ComponentDocumentModelDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ComponentDocumentModelDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ComponentDocumentModelDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComposeDocumentModelContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ComposeDocumentModelContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ComposeDocumentModelContent>
    {
        public ComposeDocumentModelContent(string modelId, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.ComponentDocumentModelDetails> componentModels) { }
        public System.Collections.Generic.IList<Azure.AI.DocumentIntelligence.ComponentDocumentModelDetails> ComponentModels { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string ModelId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.AI.DocumentIntelligence.ComposeDocumentModelContent System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ComposeDocumentModelContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ComposeDocumentModelContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.ComposeDocumentModelContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ComposeDocumentModelContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ComposeDocumentModelContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ComposeDocumentModelContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class CopyAuthorization : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.CopyAuthorization>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.CopyAuthorization>
    {
        public CopyAuthorization(string targetResourceId, string targetResourceRegion, string targetModelId, System.Uri targetModelLocation, string accessToken, System.DateTimeOffset expirationDateTime) { }
        public string AccessToken { get { throw null; } set { } }
        public System.DateTimeOffset ExpirationDateTime { get { throw null; } set { } }
        public string TargetModelId { get { throw null; } set { } }
        public System.Uri TargetModelLocation { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } set { } }
        public string TargetResourceRegion { get { throw null; } set { } }
        Azure.AI.DocumentIntelligence.CopyAuthorization System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.CopyAuthorization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.CopyAuthorization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.CopyAuthorization System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.CopyAuthorization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.CopyAuthorization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.CopyAuthorization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CurrencyValue : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.CurrencyValue>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.CurrencyValue>
    {
        internal CurrencyValue() { }
        public double Amount { get { throw null; } }
        public string CurrencyCode { get { throw null; } }
        public string CurrencySymbol { get { throw null; } }
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
    public partial class DocumentBarcode : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentBarcode>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentBarcode>
    {
        internal DocumentBarcode() { }
        public float Confidence { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentBarcodeKind Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> Polygon { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentSpan Span { get { throw null; } }
        public string Value { get { throw null; } }
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
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind EAN13 { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind EAN8 { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind ITF { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind MaxiCode { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind MicroQRCode { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind PDF417 { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind QRCode { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind UPCA { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.DocumentBarcodeKind UPCE { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.DocumentBarcodeKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.DocumentBarcodeKind left, Azure.AI.DocumentIntelligence.DocumentBarcodeKind right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.DocumentBarcodeKind (string value) { throw null; }
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
        Azure.AI.DocumentIntelligence.DocumentCaption System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentCaption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentCaption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentCaption System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentCaption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentCaption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentCaption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentClassifierBuildOperationDetails : Azure.AI.DocumentIntelligence.OperationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails>
    {
        internal DocumentClassifierBuildOperationDetails() : base (default(string), default(Azure.AI.DocumentIntelligence.OperationStatus), default(System.DateTimeOffset), default(System.DateTimeOffset), default(System.Uri)) { }
        public Azure.AI.DocumentIntelligence.DocumentClassifierDetails Result { get { throw null; } }
        Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentClassifierBuildOperationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentClassifierDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentClassifierDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentClassifierDetails>
    {
        internal DocumentClassifierDetails() { }
        public string ApiVersion { get { throw null; } }
        public string ClassifierId { get { throw null; } }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.ClassifierDocumentTypeDetails> DocTypes { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        Azure.AI.DocumentIntelligence.DocumentClassifierDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentClassifierDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentClassifierDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentClassifierDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentClassifierDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentClassifierDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentClassifierDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentField : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentField>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentField>
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
        public Azure.AI.DocumentIntelligence.DocumentSelectionMarkState? ValueSelectionMark { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentSignatureType? ValueSignature { get { throw null; } }
        public string ValueString { get { throw null; } }
        public System.TimeSpan? ValueTime { get { throw null; } }
        Azure.AI.DocumentIntelligence.DocumentField System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentField System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentFieldSchema : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentFieldSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFieldSchema>
    {
        internal DocumentFieldSchema() { }
        public string Description { get { throw null; } }
        public string Example { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentFieldSchema Items { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentFieldSchema> Properties { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentFieldType Type { get { throw null; } }
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
    public partial class DocumentFigure : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentFigure>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFigure>
    {
        internal DocumentFigure() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentCaption Caption { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Elements { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentFootnote> Footnotes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
        Azure.AI.DocumentIntelligence.DocumentFigure System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentFigure>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentFigure>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentFigure System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFigure>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFigure>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFigure>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentFootnote : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentFootnote>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentFootnote>
    {
        internal DocumentFootnote() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Elements { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
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
        public static bool operator !=(Azure.AI.DocumentIntelligence.DocumentFormulaKind left, Azure.AI.DocumentIntelligence.DocumentFormulaKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentIntelligenceAdministrationClient
    {
        protected DocumentIntelligenceAdministrationClient() { }
        public DocumentIntelligenceAdministrationClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public DocumentIntelligenceAdministrationClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceClientOptions options) { }
        public DocumentIntelligenceAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DocumentIntelligenceAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.DocumentIntelligence.CopyAuthorization> AuthorizeModelCopy(Azure.AI.DocumentIntelligence.AuthorizeCopyContent authorizeCopyRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AuthorizeModelCopy(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.DocumentIntelligence.CopyAuthorization>> AuthorizeModelCopyAsync(Azure.AI.DocumentIntelligence.AuthorizeCopyContent authorizeCopyRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AuthorizeModelCopyAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.DocumentClassifierDetails> BuildClassifier(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.BuildDocumentClassifierContent buildRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> BuildClassifier(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.DocumentClassifierDetails>> BuildClassifierAsync(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.BuildDocumentClassifierContent buildRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> BuildClassifierAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.DocumentModelDetails> BuildDocumentModel(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.BuildDocumentModelContent buildRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> BuildDocumentModel(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.DocumentModelDetails>> BuildDocumentModelAsync(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.BuildDocumentModelContent buildRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> BuildDocumentModelAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.DocumentModelDetails> ComposeModel(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.ComposeDocumentModelContent composeRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> ComposeModel(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.DocumentModelDetails>> ComposeModelAsync(Azure.WaitUntil waitUntil, Azure.AI.DocumentIntelligence.ComposeDocumentModelContent composeRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.AI.DocumentIntelligence.DocumentModelDetails> GetModels(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetModelsAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.DocumentIntelligence.DocumentModelDetails> GetModelsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetOperation(string operationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.DocumentIntelligence.OperationDetails> GetOperation(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetOperationAsync(string operationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.DocumentIntelligence.OperationDetails>> GetOperationAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetOperations(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.DocumentIntelligence.OperationDetails> GetOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetOperationsAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.DocumentIntelligence.OperationDetails> GetOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetResourceInfo(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.DocumentIntelligence.ResourceDetails> GetResourceInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetResourceInfoAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.DocumentIntelligence.ResourceDetails>> GetResourceInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DocumentIntelligenceClient
    {
        protected DocumentIntelligenceClient() { }
        public DocumentIntelligenceClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public DocumentIntelligenceClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceClientOptions options) { }
        public DocumentIntelligenceClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DocumentIntelligenceClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.AnalyzeResult> AnalyzeDocument(Azure.WaitUntil waitUntil, string modelId, Azure.AI.DocumentIntelligence.AnalyzeDocumentContent analyzeRequest = null, string pages = null, string locale = null, Azure.AI.DocumentIntelligence.StringIndexType? stringIndexType = default(Azure.AI.DocumentIntelligence.StringIndexType?), System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentAnalysisFeature> features = null, System.Collections.Generic.IEnumerable<string> queryFields = null, Azure.AI.DocumentIntelligence.ContentFormat? outputContentFormat = default(Azure.AI.DocumentIntelligence.ContentFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> AnalyzeDocument(Azure.WaitUntil waitUntil, string modelId, Azure.Core.RequestContent content, string pages = null, string locale = null, string stringIndexType = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentAnalysisFeature> features = null, System.Collections.Generic.IEnumerable<string> queryFields = null, string outputContentFormat = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.AnalyzeResult>> AnalyzeDocumentAsync(Azure.WaitUntil waitUntil, string modelId, Azure.AI.DocumentIntelligence.AnalyzeDocumentContent analyzeRequest = null, string pages = null, string locale = null, Azure.AI.DocumentIntelligence.StringIndexType? stringIndexType = default(Azure.AI.DocumentIntelligence.StringIndexType?), System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentAnalysisFeature> features = null, System.Collections.Generic.IEnumerable<string> queryFields = null, Azure.AI.DocumentIntelligence.ContentFormat? outputContentFormat = default(Azure.AI.DocumentIntelligence.ContentFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> AnalyzeDocumentAsync(Azure.WaitUntil waitUntil, string modelId, Azure.Core.RequestContent content, string pages = null, string locale = null, string stringIndexType = null, System.Collections.Generic.IEnumerable<Azure.AI.DocumentIntelligence.DocumentAnalysisFeature> features = null, System.Collections.Generic.IEnumerable<string> queryFields = null, string outputContentFormat = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.DocumentIntelligence.AnalyzeResult> ClassifyDocument(Azure.WaitUntil waitUntil, string classifierId, Azure.AI.DocumentIntelligence.ClassifyDocumentContent classifyRequest, Azure.AI.DocumentIntelligence.StringIndexType? stringIndexType = default(Azure.AI.DocumentIntelligence.StringIndexType?), Azure.AI.DocumentIntelligence.SplitMode? split = default(Azure.AI.DocumentIntelligence.SplitMode?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> ClassifyDocument(Azure.WaitUntil waitUntil, string classifierId, Azure.Core.RequestContent content, string stringIndexType = null, string split = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.DocumentIntelligence.AnalyzeResult>> ClassifyDocumentAsync(Azure.WaitUntil waitUntil, string classifierId, Azure.AI.DocumentIntelligence.ClassifyDocumentContent classifyRequest, Azure.AI.DocumentIntelligence.StringIndexType? stringIndexType = default(Azure.AI.DocumentIntelligence.StringIndexType?), Azure.AI.DocumentIntelligence.SplitMode? split = default(Azure.AI.DocumentIntelligence.SplitMode?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ClassifyDocumentAsync(Azure.WaitUntil waitUntil, string classifierId, Azure.Core.RequestContent content, string stringIndexType = null, string split = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class DocumentIntelligenceError : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceError>
    {
        internal DocumentIntelligenceError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentIntelligenceError> Details { get { throw null; } }
        public Azure.AI.DocumentIntelligence.InnerError Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        Azure.AI.DocumentIntelligence.DocumentIntelligenceError System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentIntelligenceError System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentIntelligenceError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentKeyValueElement : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentKeyValueElement>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentKeyValueElement>
    {
        internal DocumentKeyValueElement() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
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
        Azure.AI.DocumentIntelligence.DocumentLine System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentLine>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentLine>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentLine System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentLine>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentLine>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentLine>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentList : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentList>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentList>
    {
        internal DocumentList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentListItem> Items { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
        Azure.AI.DocumentIntelligence.DocumentList System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentList System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentListItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentListItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentListItem>
    {
        internal DocumentListItem() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.BoundingRegion> BoundingRegions { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Elements { get { throw null; } }
        public int Level { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
        Azure.AI.DocumentIntelligence.DocumentListItem System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentListItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentListItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentListItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentListItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentListItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentListItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentModelBuildOperationDetails : Azure.AI.DocumentIntelligence.OperationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails>
    {
        internal DocumentModelBuildOperationDetails() : base (default(string), default(Azure.AI.DocumentIntelligence.OperationStatus), default(System.DateTimeOffset), default(System.DateTimeOffset), default(System.Uri)) { }
        public Azure.AI.DocumentIntelligence.DocumentModelDetails Result { get { throw null; } }
        Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelBuildOperationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentModelComposeOperationDetails : Azure.AI.DocumentIntelligence.OperationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails>
    {
        internal DocumentModelComposeOperationDetails() : base (default(string), default(Azure.AI.DocumentIntelligence.OperationStatus), default(System.DateTimeOffset), default(System.DateTimeOffset), default(System.Uri)) { }
        public Azure.AI.DocumentIntelligence.DocumentModelDetails Result { get { throw null; } }
        Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelComposeOperationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentModelCopyToOperationDetails : Azure.AI.DocumentIntelligence.OperationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentModelCopyToOperationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentModelCopyToOperationDetails>
    {
        internal DocumentModelCopyToOperationDetails() : base (default(string), default(Azure.AI.DocumentIntelligence.OperationStatus), default(System.DateTimeOffset), default(System.DateTimeOffset), default(System.Uri)) { }
        public Azure.AI.DocumentIntelligence.DocumentModelDetails Result { get { throw null; } }
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
        public Azure.AI.DocumentIntelligence.AzureBlobFileListContentSource AzureBlobFileListSource { get { throw null; } }
        public Azure.AI.DocumentIntelligence.AzureBlobContentSource AzureBlobSource { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentBuildMode? BuildMode { get { throw null; } }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentTypeDetails> DocTypes { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string ModelId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
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
        public static bool operator !=(Azure.AI.DocumentIntelligence.DocumentSignatureType left, Azure.AI.DocumentIntelligence.DocumentSignatureType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentSpan : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentSpan>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentSpan>
    {
        internal DocumentSpan() { }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        Azure.AI.DocumentIntelligence.DocumentSpan System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentSpan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentSpan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentSpan System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentSpan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentSpan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentSpan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentStyle : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentStyle>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentStyle>
    {
        internal DocumentStyle() { }
        public string BackgroundColor { get { throw null; } }
        public string Color { get { throw null; } }
        public float Confidence { get { throw null; } }
        public Azure.AI.DocumentIntelligence.FontStyle? FontStyle { get { throw null; } }
        public Azure.AI.DocumentIntelligence.FontWeight? FontWeight { get { throw null; } }
        public bool? IsHandwritten { get { throw null; } }
        public string SimilarFontFamily { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentIntelligence.DocumentSpan> Spans { get { throw null; } }
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
        public static bool operator !=(Azure.AI.DocumentIntelligence.DocumentTableCellKind left, Azure.AI.DocumentIntelligence.DocumentTableCellKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentTypeDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentTypeDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentTypeDetails>
    {
        internal DocumentTypeDetails() { }
        public Azure.AI.DocumentIntelligence.DocumentBuildMode? BuildMode { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, float> FieldConfidence { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.DocumentIntelligence.DocumentFieldSchema> FieldSchema { get { throw null; } }
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
        Azure.AI.DocumentIntelligence.DocumentWord System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentWord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.DocumentWord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.DocumentWord System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentWord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentWord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.DocumentWord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FontStyle : System.IEquatable<Azure.AI.DocumentIntelligence.FontStyle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FontStyle(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.FontStyle Italic { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.FontStyle Normal { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.FontStyle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.FontStyle left, Azure.AI.DocumentIntelligence.FontStyle right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.FontStyle (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.FontStyle left, Azure.AI.DocumentIntelligence.FontStyle right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FontWeight : System.IEquatable<Azure.AI.DocumentIntelligence.FontWeight>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FontWeight(string value) { throw null; }
        public static Azure.AI.DocumentIntelligence.FontWeight Bold { get { throw null; } }
        public static Azure.AI.DocumentIntelligence.FontWeight Normal { get { throw null; } }
        public bool Equals(Azure.AI.DocumentIntelligence.FontWeight other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentIntelligence.FontWeight left, Azure.AI.DocumentIntelligence.FontWeight right) { throw null; }
        public static implicit operator Azure.AI.DocumentIntelligence.FontWeight (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentIntelligence.FontWeight left, Azure.AI.DocumentIntelligence.FontWeight right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InnerError : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.InnerError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.InnerError>
    {
        internal InnerError() { }
        public string Code { get { throw null; } }
        public Azure.AI.DocumentIntelligence.InnerError InnerErrorObject { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.AI.DocumentIntelligence.InnerError System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.InnerError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.InnerError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.InnerError System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.InnerError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.InnerError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.InnerError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static bool operator !=(Azure.AI.DocumentIntelligence.LengthUnit left, Azure.AI.DocumentIntelligence.LengthUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class OperationDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.OperationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.OperationDetails>
    {
        protected OperationDetails(string operationId, Azure.AI.DocumentIntelligence.OperationStatus status, System.DateTimeOffset createdDateTime, System.DateTimeOffset lastUpdatedDateTime, System.Uri resourceLocation) { }
        public string ApiVersion { get { throw null; } }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public Azure.AI.DocumentIntelligence.DocumentIntelligenceError Error { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public string OperationId { get { throw null; } }
        public int? PercentCompleted { get { throw null; } }
        public System.Uri ResourceLocation { get { throw null; } }
        public Azure.AI.DocumentIntelligence.OperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        Azure.AI.DocumentIntelligence.OperationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.OperationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.OperationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.OperationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.OperationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.OperationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.OperationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static bool operator !=(Azure.AI.DocumentIntelligence.ParagraphRole left, Azure.AI.DocumentIntelligence.ParagraphRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuotaDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.QuotaDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.QuotaDetails>
    {
        internal QuotaDetails() { }
        public int Quota { get { throw null; } }
        public System.DateTimeOffset QuotaResetDateTime { get { throw null; } }
        public int Used { get { throw null; } }
        Azure.AI.DocumentIntelligence.QuotaDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.QuotaDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.QuotaDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.QuotaDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.QuotaDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.QuotaDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.QuotaDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ResourceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ResourceDetails>
    {
        internal ResourceDetails() { }
        public Azure.AI.DocumentIntelligence.CustomDocumentModelsDetails CustomDocumentModels { get { throw null; } }
        public Azure.AI.DocumentIntelligence.QuotaDetails CustomNeuralDocumentModelBuilds { get { throw null; } }
        Azure.AI.DocumentIntelligence.ResourceDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ResourceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.DocumentIntelligence.ResourceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.DocumentIntelligence.ResourceDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ResourceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ResourceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.DocumentIntelligence.ResourceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.DocumentIntelligence.DocumentIntelligenceAdministrationClient, Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceClientOptions> AddDocumentIntelligenceAdministrationClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.DocumentIntelligence.DocumentIntelligenceAdministrationClient, Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceClientOptions> AddDocumentIntelligenceAdministrationClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.DocumentIntelligence.DocumentIntelligenceAdministrationClient, Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceClientOptions> AddDocumentIntelligenceAdministrationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.DocumentIntelligence.DocumentIntelligenceClient, Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceClientOptions> AddDocumentIntelligenceClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.DocumentIntelligence.DocumentIntelligenceClient, Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceClientOptions> AddDocumentIntelligenceClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.DocumentIntelligence.DocumentIntelligenceClient, Azure.AI.DocumentIntelligence.AzureAIDocumentIntelligenceClientOptions> AddDocumentIntelligenceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
