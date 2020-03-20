namespace Azure.AI.FormRecognizer
{
    public partial class FormLayoutClient
    {
        protected FormLayoutClient() { }
        public FormLayoutClient(System.Uri endpoint, Azure.AI.FormRecognizer.Models.FormRecognizerApiKeyCredential credential) { }
        public FormLayoutClient(System.Uri endpoint, Azure.AI.FormRecognizer.Models.FormRecognizerApiKeyCredential credential, Azure.AI.FormRecognizer.FormRecognizerClientOptions options) { }
        public virtual Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedLayoutPage>> StartExtractLayouts(System.IO.Stream stream, Azure.AI.FormRecognizer.Models.ContentType contentType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedLayoutPage>> StartExtractLayouts(System.Uri uri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedLayoutPage>>> StartExtractLayoutsAsync(System.IO.Stream stream, Azure.AI.FormRecognizer.Models.ContentType contentType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedLayoutPage>>> StartExtractLayoutsAsync(System.Uri uri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FormRecognizerClientOptions : Azure.Core.ClientOptions
    {
        public FormRecognizerClientOptions(Azure.AI.FormRecognizer.FormRecognizerClientOptions.ServiceVersion version = Azure.AI.FormRecognizer.FormRecognizerClientOptions.ServiceVersion.V2_0_Preview) { }
        public Azure.AI.FormRecognizer.FormRecognizerClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V2_0_Preview = 1,
        }
    }
    public partial class ReceiptClient
    {
        protected ReceiptClient() { }
        public ReceiptClient(System.Uri endpoint, Azure.AI.FormRecognizer.Models.FormRecognizerApiKeyCredential credential) { }
        public ReceiptClient(System.Uri endpoint, Azure.AI.FormRecognizer.Models.FormRecognizerApiKeyCredential credential, Azure.AI.FormRecognizer.FormRecognizerClientOptions options) { }
        public virtual Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedReceipt>> StartExtractReceipts(System.IO.Stream stream, Azure.AI.FormRecognizer.Models.ContentType contentType, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedReceipt>> StartExtractReceipts(System.Uri uri, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedReceipt>>> StartExtractReceiptsAsync(System.IO.Stream stream, Azure.AI.FormRecognizer.Models.ContentType contentType, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedReceipt>>> StartExtractReceiptsAsync(System.Uri uri, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.AI.FormRecognizer.Custom
{
    public partial class CustomFormClient
    {
        protected CustomFormClient() { }
        public CustomFormClient(System.Uri endpoint, Azure.AI.FormRecognizer.Models.FormRecognizerApiKeyCredential credential) { }
        public CustomFormClient(System.Uri endpoint, Azure.AI.FormRecognizer.Models.FormRecognizerApiKeyCredential credential, Azure.AI.FormRecognizer.FormRecognizerClientOptions options) { }
        public virtual Azure.Response DeleteModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.FormRecognizer.Custom.CustomModelInfo> GetModelInfos(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.FormRecognizer.Custom.CustomModelInfo> GetModelInfosAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.FormRecognizer.Custom.SubscriptionProperties> GetSubscriptionProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Custom.SubscriptionProperties>> GetSubscriptionPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Custom.ExtractedPage>> StartExtractFormPages(string modelId, System.IO.Stream stream, Azure.AI.FormRecognizer.Models.ContentType contentType, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Custom.ExtractedPage>> StartExtractFormPages(string modelId, System.Uri uri, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Custom.ExtractedPage>>> StartExtractFormPagesAsync(string modelId, System.IO.Stream stream, Azure.AI.FormRecognizer.Models.ContentType contentType, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Custom.ExtractedPage>>> StartExtractFormPagesAsync(string modelId, System.Uri uri, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Custom.ExtractedLabeledForm>> StartExtractLabeledForms(string modelId, System.IO.Stream stream, Azure.AI.FormRecognizer.Models.ContentType contentType, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Custom.ExtractedLabeledForm>> StartExtractLabeledForms(string modelId, System.Uri uri, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Custom.ExtractedLabeledForm>>> StartExtractLabeledFormsAsync(string modelId, System.IO.Stream stream, Azure.AI.FormRecognizer.Models.ContentType contentType, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Custom.ExtractedLabeledForm>>> StartExtractLabeledFormsAsync(string modelId, System.Uri uri, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<Azure.AI.FormRecognizer.Custom.CustomModel> StartTraining(string source, Azure.AI.FormRecognizer.Custom.TrainingFileFilter filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.FormRecognizer.Custom.CustomModel>> StartTrainingAsync(string source, Azure.AI.FormRecognizer.Custom.TrainingFileFilter filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<Azure.AI.FormRecognizer.Custom.CustomLabeledModel> StartTrainingWithLabels(string source, Azure.AI.FormRecognizer.Custom.TrainingFileFilter filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.FormRecognizer.Custom.CustomLabeledModel>> StartTrainingWithLabelsAsync(string source, Azure.AI.FormRecognizer.Custom.TrainingFileFilter filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CustomLabeledModel
    {
        internal CustomLabeledModel() { }
        public float AveragePredictionAccuracy { get { throw null; } }
        public string ModelId { get { throw null; } }
        public Azure.AI.FormRecognizer.Custom.CustomModelInfo ModelInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Custom.FieldPredictionAccuracy> PredictionAccuracies { get { throw null; } }
        public Azure.AI.FormRecognizer.Custom.TrainingInfo TrainingInfo { get { throw null; } }
    }
    public partial class CustomModel
    {
        internal CustomModel() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Custom.CustomModelLearnedPage> LearnedPages { get { throw null; } }
        public string ModelId { get { throw null; } }
        public Azure.AI.FormRecognizer.Custom.CustomModelInfo ModelInfo { get { throw null; } }
        public Azure.AI.FormRecognizer.Custom.TrainingInfo TrainingInfo { get { throw null; } }
    }
    public partial class CustomModelInfo
    {
        internal CustomModelInfo() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public string ModelId { get { throw null; } }
        public Azure.AI.FormRecognizer.Custom.ModelStatus Status { get { throw null; } }
    }
    public partial class CustomModelLearnedPage
    {
        internal CustomModelLearnedPage() { }
        public string FormTypeId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> LearnedFields { get { throw null; } }
    }
    public partial class ExtractedField
    {
        internal ExtractedField() { }
        public float Confidence { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.BoundingBox NameBoundingBox { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RawExtractedItem> NameRawExtractedItems { get { throw null; } }
        public string Value { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.BoundingBox ValueBoundingBox { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RawExtractedItem> ValueRawExtractedItems { get { throw null; } }
    }
    public partial class ExtractedLabeledField
    {
        internal ExtractedLabeledField() { }
        public float? Confidence { get { throw null; } }
        public string Label { get { throw null; } }
        public int? PageNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RawExtractedItem> RawExtractedItems { get { throw null; } }
        public string Value { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.BoundingBox ValueBoundingBox { get { throw null; } }
    }
    public partial class ExtractedLabeledForm
    {
        internal ExtractedLabeledForm() { }
        public int EndPageNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Custom.ExtractedLabeledField> Fields { get { throw null; } }
        public string FormType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RawExtractedPage> RawExtractedPages { get { throw null; } }
        public int StartPageNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Custom.ExtractedLabeledTable> Tables { get { throw null; } }
        public string GetFieldValue(string label) { throw null; }
    }
    public partial class ExtractedLabeledTable : Azure.AI.FormRecognizer.Models.ExtractedTable
    {
        internal ExtractedLabeledTable() { }
        public int PageNumber { get { throw null; } }
    }
    public partial class ExtractedPage
    {
        internal ExtractedPage() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Custom.ExtractedField> Fields { get { throw null; } }
        public int? FormTypeId { get { throw null; } }
        public int PageNumber { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.RawExtractedPage RawExtractedPage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedTable> Tables { get { throw null; } }
        public string GetFieldValue(string fieldName) { throw null; }
    }
    public partial class FieldPredictionAccuracy
    {
        internal FieldPredictionAccuracy() { }
        public float Accuracy { get { throw null; } }
        public string Label { get { throw null; } }
    }
    public enum ModelStatus
    {
        Training = 0,
        Ready = 1,
        Invalid = 2,
    }
    public partial class SubscriptionProperties
    {
        internal SubscriptionProperties() { }
        public int Count { get { throw null; } set { } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } set { } }
        public int Limit { get { throw null; } set { } }
    }
    public partial class TrainingDocumentInfo
    {
        internal TrainingDocumentInfo() { }
        public string DocumentName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.FormRecognizer.Models.FormRecognizerError> Errors { get { throw null; } }
        public int PageCount { get { throw null; } set { } }
        public Azure.AI.FormRecognizer.Custom.TrainingStatus Status { get { throw null; } }
    }
    public partial class TrainingFileFilter
    {
        internal TrainingFileFilter() { }
        public bool? IncludeSubFolders { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
    }
    public partial class TrainingInfo
    {
        internal TrainingInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Custom.TrainingDocumentInfo> PerDocumentInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormRecognizerError> TrainingErrors { get { throw null; } }
    }
    public enum TrainingStatus
    {
        Succeeded = 0,
        PartiallySucceeded = 1,
        Failed = 2,
    }
}
namespace Azure.AI.FormRecognizer.Models
{
    public partial class BoundingBox
    {
        internal BoundingBox() { }
        public System.Drawing.PointF[] Points { get { throw null; } }
    }
    public enum ContentType
    {
        Pdf = 0,
        Png = 1,
        Jpeg = 2,
        Tiff = 3,
    }
    public partial class ExtractedLayoutPage
    {
        internal ExtractedLayoutPage() { }
        public int PageNumber { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.RawExtractedPage RawExtractedPage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedTable> Tables { get { throw null; } }
    }
    public partial class ExtractedReceipt
    {
        internal ExtractedReceipt() { }
        public int EndPageNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.Models.ExtractedReceiptField> ExtractedFields { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedReceiptItem> Items { get { throw null; } }
        public string MerchantAddress { get { throw null; } }
        public string MerchantName { get { throw null; } }
        public string MerchantPhoneNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RawExtractedPage> RawExtractedPage { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.ExtractedReceiptType ReceiptType { get { throw null; } }
        public int StartPageNumber { get { throw null; } }
        public float? Subtotal { get { throw null; } }
        public float? Tax { get { throw null; } }
        public float? Tip { get { throw null; } }
        public float? Total { get { throw null; } }
        public System.DateTimeOffset? TransactionDate { get { throw null; } }
        public System.DateTimeOffset? TransactionTime { get { throw null; } }
    }
    public partial class ExtractedReceiptField
    {
        internal ExtractedReceiptField() { }
        public Azure.AI.FormRecognizer.Models.BoundingBox BoundingBox { get { throw null; } }
        public float? Confidence { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class ExtractedReceiptItem
    {
        internal ExtractedReceiptItem() { }
        public string Name { get { throw null; } }
        public float? Price { get { throw null; } }
        public int? Quantity { get { throw null; } }
        public float? TotalPrice { get { throw null; } }
    }
    public enum ExtractedReceiptType
    {
        Unrecognized = 0,
        Itemized = 1,
    }
    public partial class ExtractedTable
    {
        internal ExtractedTable() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedTableCell> Cells { get { throw null; } }
        public int ColumnCount { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.ExtractedTableCell this[int row, int column] { get { throw null; } set { } }
        public int RowCount { get { throw null; } }
    }
    public partial class ExtractedTableCell
    {
        internal ExtractedTableCell() { }
        public Azure.AI.FormRecognizer.Models.BoundingBox BoundingBox { get { throw null; } }
        public int ColumnIndex { get { throw null; } }
        public int ColumnSpan { get { throw null; } }
        public float Confidence { get { throw null; } }
        public bool IsFooter { get { throw null; } }
        public bool IsHeader { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RawExtractedItem> RawExtractedItems { get { throw null; } }
        public int RowIndex { get { throw null; } }
        public int RowSpan { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public enum FieldValueType
    {
        String = 0,
        Date = 1,
        Time = 2,
        PhoneNumber = 3,
        Number = 4,
        Integer = 5,
        Array = 6,
        Object = 7,
    }
    public partial class FormRecognizerApiKeyCredential
    {
        public FormRecognizerApiKeyCredential(string apiKey) { }
        public void UpdateCredential(string apiKey) { }
    }
    public partial class FormRecognizerError
    {
        internal FormRecognizerError() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
    }
    public enum LengthUnit
    {
        Pixel = 0,
        Inch = 1,
    }
    public partial class RawExtractedItem
    {
        internal RawExtractedItem() { }
        public Azure.AI.FormRecognizer.Models.BoundingBox BoundingBox { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class RawExtractedLine : Azure.AI.FormRecognizer.Models.RawExtractedItem
    {
        internal RawExtractedLine() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RawExtractedWord> Words { get { throw null; } }
        public static implicit operator string (Azure.AI.FormRecognizer.Models.RawExtractedLine line) { throw null; }
    }
    public partial class RawExtractedPage
    {
        internal RawExtractedPage() { }
        public float Angle { get { throw null; } set { } }
        public float Height { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<Azure.AI.FormRecognizer.Models.RawExtractedLine> Lines { get { throw null; } set { } }
        public int Page { get { throw null; } set { } }
        public Azure.AI.FormRecognizer.Models.LengthUnit Unit { get { throw null; } set { } }
        public float Width { get { throw null; } set { } }
    }
    public partial class RawExtractedWord : Azure.AI.FormRecognizer.Models.RawExtractedItem
    {
        internal RawExtractedWord() { }
        public float? Confidence { get { throw null; } }
        public static implicit operator string (Azure.AI.FormRecognizer.Models.RawExtractedWord word) { throw null; }
    }
}
