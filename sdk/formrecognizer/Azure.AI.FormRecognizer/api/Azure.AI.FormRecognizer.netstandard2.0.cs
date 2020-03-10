namespace Azure.AI.FormRecognizer
{
    public partial class FormLayoutClient
    {
        protected FormLayoutClient() { }
        public FormLayoutClient(System.Uri endpoint, Azure.AI.FormRecognizer.Models.FormRecognizerApiKeyCredential credential) { }
        public FormLayoutClient(System.Uri endpoint, Azure.AI.FormRecognizer.Models.FormRecognizerApiKeyCredential credential, Azure.AI.FormRecognizer.FormRecognizerClientOptions options) { }
        public virtual Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedLayoutPage>> StartExtractLayout(System.IO.Stream stream, Azure.AI.FormRecognizer.Models.FormContentType contentType, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedLayoutPage>> StartExtractLayout(System.Uri uri, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedLayoutPage>>> StartExtractLayoutAsync(System.IO.Stream stream, Azure.AI.FormRecognizer.Models.FormContentType contentType, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedLayoutPage>>> StartExtractLayoutAsync(System.Uri uri, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FormRecognizerClientOptions : Azure.Core.ClientOptions
    {
        public FormRecognizerClientOptions(Azure.AI.FormRecognizer.FormRecognizerClientOptions.ServiceVersion version = Azure.AI.FormRecognizer.FormRecognizerClientOptions.ServiceVersion.V2_0_Preview) { }
        public Azure.AI.FormRecognizer.FormRecognizerClientOptions.ServiceVersion Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
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
        public virtual Azure.Response<Azure.AI.FormRecognizer.Models.ExtractedReceipt> ExtractReceipt(System.IO.Stream stream, Azure.AI.FormRecognizer.Models.FormContentType contentType, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.FormRecognizer.Models.ExtractedReceipt> ExtractReceipt(System.Uri uri, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Models.ExtractedReceipt>> ExtractReceiptAsync(System.IO.Stream stream, Azure.AI.FormRecognizer.Models.FormContentType contentType, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Models.ExtractedReceipt>> ExtractReceiptAsync(System.Uri uri, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.AI.FormRecognizer.Custom.ModelInfo> GetModels(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.FormRecognizer.Custom.ModelInfo> GetModelsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.FormRecognizer.Custom.SubscriptionProperties> GetSubscriptionProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Custom.SubscriptionProperties>> GetSubscriptionPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<Azure.AI.FormRecognizer.Models.ExtractedForm> StartExtractForm(string modelId, System.IO.Stream stream, Azure.AI.FormRecognizer.Models.FormContentType contentType, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<Azure.AI.FormRecognizer.Models.ExtractedForm> StartExtractForm(string modelId, System.Uri uri, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.FormRecognizer.Models.ExtractedForm>> StartExtractFormAsync(string modelId, System.IO.Stream stream, Azure.AI.FormRecognizer.Models.FormContentType contentType, bool includeRawPageExtractions = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<Azure.AI.FormRecognizer.Custom.CustomModel> StartTraining(string source, Azure.AI.FormRecognizer.Custom.TrainingFileFilter filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.FormRecognizer.Custom.CustomModel>> StartTrainingAsync(string source, Azure.AI.FormRecognizer.Custom.TrainingFileFilter filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<Azure.AI.FormRecognizer.Custom.CustomLabeledModel> StartTrainingWithLabels(string source, Azure.AI.FormRecognizer.Custom.TrainingFileFilter filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.FormRecognizer.Custom.CustomLabeledModel>> StartTrainingWithLabelsAsync(string source, Azure.AI.FormRecognizer.Custom.TrainingFileFilter filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CustomLabeledModel
    {
        internal CustomLabeledModel() { }
        public float AveragePredictionAccuracy { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ModelId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Custom.FieldPredictionAccuracy> PredictionAccuracies { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.AI.FormRecognizer.Custom.TrainingInfo TrainingInfo { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.AI.FormRecognizer.Custom.CustomModelTrainingStatus TrainingStatus { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class CustomModel
    {
        internal CustomModel() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Custom.CustomModelLearnedForm> LearnedForms { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ModelId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.AI.FormRecognizer.Custom.TrainingInfo TrainingInfo { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.AI.FormRecognizer.Custom.CustomModelTrainingStatus TrainingStatus { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class CustomModelLearnedForm
    {
        public CustomModelLearnedForm() { }
        public string FormTypeId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> LearnedFields { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class CustomModelTrainingStatus
    {
        internal CustomModelTrainingStatus() { }
        public System.DateTimeOffset? CreatedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ModelId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.AI.FormRecognizer.Models.ModelStatus TrainingStatus { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class FieldPredictionAccuracy
    {
        public FieldPredictionAccuracy() { }
        public float Accuracy { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Label { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class ModelInfo
    {
        internal ModelInfo() { }
        public System.DateTimeOffset CreatedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ModelId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.AI.FormRecognizer.Models.ModelStatus TrainingStatus { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class SubscriptionProperties
    {
        internal SubscriptionProperties() { }
        public int Count { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.DateTimeOffset LastUpdatedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public int Limit { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class TrainingDocumentInfo
    {
        public TrainingDocumentInfo() { }
        public string DocumentName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.Collections.Generic.IList<Azure.AI.FormRecognizer.Models.FormRecognizerError> Errors { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public int PageCount { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.AI.FormRecognizer.Models.TrainStatus Status { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class TrainingFileFilter
    {
        public TrainingFileFilter() { }
        public bool? IncludeSubFolders { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Prefix { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class TrainingInfo
    {
        internal TrainingInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Custom.TrainingDocumentInfo> PerDocumentInfo { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormRecognizerError> TrainingErrors { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
}
namespace Azure.AI.FormRecognizer.Models
{
    public partial class BoundingBox
    {
        internal BoundingBox() { }
        public System.Drawing.PointF[] Points { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public enum ContentType
    {
        ApplicationPdf = 0,
        ImageJpeg = 1,
        ImagePng = 2,
        ImageTiff = 3,
    }
    public partial class ExtractedField
    {
        internal ExtractedField() { }
        public float? Confidence { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Label { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.AI.FormRecognizer.Models.BoundingBox LabelOutline { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RawExtractedItem> LabelRawExtractedItems { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Value { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.AI.FormRecognizer.Models.BoundingBox ValueOutline { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RawExtractedItem> ValueRawExtractedItems { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class ExtractedForm
    {
        internal ExtractedForm() { }
        public string LearnedFormType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.AI.FormRecognizer.Models.PageRange PageRange { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedPage> Pages { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class ExtractedLayoutPage
    {
        internal ExtractedLayoutPage() { }
        public int PageNumber { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.AI.FormRecognizer.Models.RawExtractedPage RawExtractedPage { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedTable> Tables { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class ExtractedPage
    {
        internal ExtractedPage() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedField> Fields { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public int PageNumber { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.AI.FormRecognizer.Models.RawExtractedPage RawExtractedPage { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedTable> Tables { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class ExtractedReceipt
    {
        internal ExtractedReceipt() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.Models.ExtractedReceiptField> ExtractedFields { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedReceiptItem> Items { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string MerchantAddress { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string MerchantName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string MerchantPhoneNumber { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.AI.FormRecognizer.Models.PageRange PageRange { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.AI.FormRecognizer.Models.RawExtractedPage RawExtractedPage { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.AI.FormRecognizer.Models.ExtractedReceiptType ReceiptType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public float? Subtotal { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public float? Tax { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public float? Tip { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public float? Total { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset? TransactionDate { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset? TransactionTime { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class ExtractedReceiptField
    {
        internal ExtractedReceiptField() { }
        public Azure.AI.FormRecognizer.Models.BoundingBox BoundingBox { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public float? Confidence { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Text { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class ExtractedReceiptItem
    {
        internal ExtractedReceiptItem() { }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public float? Price { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public int? Quantity { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public float? TotalPrice { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public enum ExtractedReceiptType
    {
        Unrecognized = 1,
        Itemized = 2,
    }
    public partial class ExtractedTable
    {
        internal ExtractedTable() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.ExtractedTableCell> Cells { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public int ColumnCount { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.AI.FormRecognizer.Models.ExtractedTableCell this[int row, int column] { get { throw null; } set { } }
        public int RowCount { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class ExtractedTableCell
    {
        internal ExtractedTableCell() { }
        public Azure.AI.FormRecognizer.Models.BoundingBox BoundingBox { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public int ColumnIndex { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public int ColumnSpan { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public float Confidence { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool IsFooter { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool IsHeader { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RawExtractedItem> RawExtractedItems { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public int RowIndex { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public int RowSpan { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Text { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
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
    public enum FormContentType
    {
        Pdf = 1,
        Png = 2,
        Jpeg = 3,
        Tiff = 4,
    }
    public partial class FormRecognizerApiKeyCredential
    {
        public FormRecognizerApiKeyCredential(string apiKey) { }
        public void UpdateCredential(string apiKey) { }
    }
    public partial class FormRecognizerError
    {
        public FormRecognizerError() { }
        public string Code { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Message { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public enum LengthUnit
    {
        Pixel = 0,
        Inch = 1,
    }
    public enum ModelStatus
    {
        Creating = 0,
        Ready = 1,
        Invalid = 2,
    }
    public enum OperationStatus
    {
        NotStarted = 0,
        Running = 1,
        Succeeded = 2,
        Failed = 3,
    }
    public partial class PageRange
    {
        internal PageRange() { }
        public int EndPageNumber { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public int StartPageNumber { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class RawExtractedItem
    {
        internal RawExtractedItem() { }
        public Azure.AI.FormRecognizer.Models.BoundingBox BoundingBox { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Text { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class RawExtractedLine : Azure.AI.FormRecognizer.Models.RawExtractedItem
    {
        internal RawExtractedLine() { }
        public string Language { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RawExtractedWord> Words { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static implicit operator string (Azure.AI.FormRecognizer.Models.RawExtractedLine line) { throw null; }
    }
    public partial class RawExtractedPage
    {
        internal RawExtractedPage() { }
        public float Angle { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public float Height { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Language { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.Collections.Generic.ICollection<Azure.AI.FormRecognizer.Models.RawExtractedLine> Lines { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public int Page { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.AI.FormRecognizer.Models.LengthUnit Unit { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public float Width { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class RawExtractedWord : Azure.AI.FormRecognizer.Models.RawExtractedItem
    {
        internal RawExtractedWord() { }
        public float? Confidence { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static implicit operator string (Azure.AI.FormRecognizer.Models.RawExtractedWord word) { throw null; }
    }
    public enum TrainStatus
    {
        Succeeded = 0,
        PartiallySucceeded = 1,
        Failed = 2,
    }
}
