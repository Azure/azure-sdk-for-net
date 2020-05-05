namespace Azure.AI.FormRecognizer
{
    public partial class FormRecognizerClient
    {
        protected FormRecognizerClient() { }
        public FormRecognizerClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public FormRecognizerClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.FormRecognizer.FormRecognizerClientOptions options) { }
        public virtual Azure.AI.FormRecognizer.Training.FormTrainingClient GetFormTrainingClient() { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeContentOperation StartRecognizeContent(System.IO.Stream formFileStream, Azure.AI.FormRecognizer.Models.RecognizeOptions recognizeOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeContentOperation> StartRecognizeContentAsync(System.IO.Stream formFileStream, Azure.AI.FormRecognizer.Models.RecognizeOptions recognizeOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeContentOperation StartRecognizeContentFromUri(System.Uri formFileUri, Azure.AI.FormRecognizer.Models.RecognizeOptions recognizeOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeContentOperation> StartRecognizeContentFromUriAsync(System.Uri formFileUri, Azure.AI.FormRecognizer.Models.RecognizeOptions recognizeOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeCustomFormsOperation StartRecognizeCustomForms(string modelId, System.IO.Stream formFileStream, Azure.AI.FormRecognizer.Models.RecognizeOptions recognizeOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeCustomFormsOperation> StartRecognizeCustomFormsAsync(string modelId, System.IO.Stream formFileStream, Azure.AI.FormRecognizer.Models.RecognizeOptions recognizeOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeCustomFormsOperation StartRecognizeCustomFormsFromUri(string modelId, System.Uri formFileUri, Azure.AI.FormRecognizer.Models.RecognizeOptions recognizeOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeCustomFormsOperation> StartRecognizeCustomFormsFromUriAsync(string modelId, System.Uri formFileUri, Azure.AI.FormRecognizer.Models.RecognizeOptions recognizeOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeReceiptsOperation StartRecognizeReceipts(System.IO.Stream receiptFileStream, Azure.AI.FormRecognizer.Models.RecognizeOptions recognizeOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeReceiptsOperation> StartRecognizeReceiptsAsync(System.IO.Stream receiptFileStream, Azure.AI.FormRecognizer.Models.RecognizeOptions recognizeOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeReceiptsOperation StartRecognizeReceiptsFromUri(System.Uri receiptFileUri, Azure.AI.FormRecognizer.Models.RecognizeOptions recognizeOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeReceiptsOperation> StartRecognizeReceiptsFromUriAsync(System.Uri receiptFileUri, Azure.AI.FormRecognizer.Models.RecognizeOptions recognizeOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public static partial class OperationExtensions
    {
        public static System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormPage>>> WaitForCompletionAsync(this System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeContentOperation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RecognizedForm>>> WaitForCompletionAsync(this System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeCustomFormsOperation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RecognizedReceipt>>> WaitForCompletionAsync(this System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeReceiptsOperation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Training.CustomFormModel>> WaitForCompletionAsync(this System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Training.TrainingOperation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.AI.FormRecognizer.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BoundingBox
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public System.Drawing.PointF this[int index] { get { throw null; } }
    }
    public enum ContentType
    {
        Json = 0,
        Pdf = 1,
        Png = 2,
        Jpeg = 3,
        Tiff = 4,
    }
    public partial class FieldText : Azure.AI.FormRecognizer.Models.FormContent
    {
        internal FieldText() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormContent> TextContent { get { throw null; } }
        public static implicit operator string (Azure.AI.FormRecognizer.Models.FieldText text) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FieldValue
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Azure.AI.FormRecognizer.Models.FieldValueType Type { get { throw null; } }
        public System.DateTime AsDate() { throw null; }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.Models.FormField> AsDictionary() { throw null; }
        public float AsFloat() { throw null; }
        public int AsInt32() { throw null; }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormField> AsList() { throw null; }
        public string AsPhoneNumber() { throw null; }
        public string AsString() { throw null; }
        public System.TimeSpan AsTime() { throw null; }
    }
    public enum FieldValueType
    {
        StringType = 0,
        DateType = 1,
        TimeType = 2,
        PhoneNumberType = 3,
        FloatType = 4,
        IntegerType = 5,
        ListType = 6,
        DictionaryType = 7,
    }
    public abstract partial class FormContent
    {
        internal FormContent() { }
        public Azure.AI.FormRecognizer.Models.BoundingBox BoundingBox { get { throw null; } }
        public int PageNumber { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class FormField
    {
        internal FormField() { }
        public float Confidence { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FieldText LabelText { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FieldValue Value { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FieldText ValueText { get { throw null; } }
    }
    public partial class FormField<T>
    {
        internal FormField() { }
        public float Confidence { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FieldText LabelText { get { throw null; } }
        public string Name { get { throw null; } }
        public T Value { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FieldText ValueText { get { throw null; } }
        public static implicit operator T (Azure.AI.FormRecognizer.Models.FormField<T> field) { throw null; }
    }
    public partial class FormLine : Azure.AI.FormRecognizer.Models.FormContent
    {
        internal FormLine() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormWord> Words { get { throw null; } }
    }
    public partial class FormPage
    {
        internal FormPage() { }
        public float Height { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormLine> Lines { get { throw null; } set { } }
        public int PageNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormTable> Tables { get { throw null; } }
        public float TextAngle { get { throw null; } set { } }
        public Azure.AI.FormRecognizer.Models.LengthUnit Unit { get { throw null; } set { } }
        public float Width { get { throw null; } set { } }
    }
    public partial class FormPageRange
    {
        internal FormPageRange() { }
        public int FirstPageNumber { get { throw null; } }
        public int LastPageNumber { get { throw null; } }
    }
    public partial class FormRecognizerError
    {
        internal FormRecognizerError() { }
        public string ErrorCode { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class FormTable
    {
        internal FormTable() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormTableCell> Cells { get { throw null; } }
        public int ColumnCount { get { throw null; } }
        public int PageNumber { get { throw null; } }
        public int RowCount { get { throw null; } }
    }
    public partial class FormTableCell : Azure.AI.FormRecognizer.Models.FormContent
    {
        internal FormTableCell() { }
        public int ColumnIndex { get { throw null; } }
        public int ColumnSpan { get { throw null; } }
        public float Confidence { get { throw null; } }
        public bool IsFooter { get { throw null; } }
        public bool IsHeader { get { throw null; } }
        public int RowIndex { get { throw null; } }
        public int RowSpan { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormContent> TextContent { get { throw null; } }
    }
    public partial class FormWord : Azure.AI.FormRecognizer.Models.FormContent
    {
        internal FormWord() { }
        public float Confidence { get { throw null; } }
    }
    public enum LengthUnit
    {
        Pixel = 0,
        Inch = 1,
    }
    public static partial class ReceiptExtensions
    {
        public static Azure.AI.FormRecognizer.Models.USReceipt AsUSReceipt(this Azure.AI.FormRecognizer.Models.RecognizedReceipt receipt) { throw null; }
    }
    public partial class RecognizeContentOperation : Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormPage>>
    {
        protected RecognizeContentOperation() { }
        public RecognizeContentOperation(string operationId, Azure.AI.FormRecognizer.FormRecognizerClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormPage> Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormPage>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormPage>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecognizeCustomFormsOperation : Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RecognizedForm>>
    {
        protected RecognizeCustomFormsOperation() { }
        public RecognizeCustomFormsOperation(string operationId, Azure.AI.FormRecognizer.FormRecognizerClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RecognizedForm> Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RecognizedForm>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RecognizedForm>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecognizedForm
    {
        internal RecognizedForm() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.Models.FormField> Fields { get { throw null; } }
        public string FormType { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FormPageRange PageRange { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormPage> Pages { get { throw null; } }
    }
    public partial class RecognizedReceipt
    {
        internal RecognizedReceipt() { }
        public string ReceiptLocale { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.RecognizedForm RecognizedForm { get { throw null; } }
    }
    public partial class RecognizeOptions
    {
        public RecognizeOptions() { }
        public Azure.AI.FormRecognizer.Models.ContentType? ContentType { get { throw null; } set { } }
        public bool IncludeTextContent { get { throw null; } set { } }
    }
    public partial class RecognizeReceiptsOperation : Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RecognizedReceipt>>
    {
        protected RecognizeReceiptsOperation() { }
        public RecognizeReceiptsOperation(string operationId, Azure.AI.FormRecognizer.FormRecognizerClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RecognizedReceipt> Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RecognizedReceipt>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.RecognizedReceipt>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class USReceipt : Azure.AI.FormRecognizer.Models.RecognizedReceipt
    {
        internal USReceipt() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.USReceiptItem> Items { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FormField<string> MerchantAddress { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FormField<string> MerchantName { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FormField<string> MerchantPhoneNumber { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.USReceiptType ReceiptType { get { throw null; } }
        public float ReceiptTypeConfidence { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FormField<float> Subtotal { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FormField<float> Tax { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FormField<float> Tip { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FormField<float> Total { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FormField<System.DateTime> TransactionDate { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FormField<System.TimeSpan> TransactionTime { get { throw null; } }
    }
    public partial class USReceiptItem
    {
        internal USReceiptItem() { }
        public Azure.AI.FormRecognizer.Models.FormField<string> Name { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FormField<float> Price { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FormField<float> Quantity { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FormField<float> TotalPrice { get { throw null; } }
    }
    public enum USReceiptType
    {
        Unrecognized = 0,
        Itemized = 1,
        CreditCard = 2,
        Gas = 3,
        Parking = 4,
        Other = 5,
    }
}
namespace Azure.AI.FormRecognizer.Training
{
    public partial class AccountProperties
    {
        internal AccountProperties() { }
        public int CustomModelCount { get { throw null; } }
        public int CustomModelLimit { get { throw null; } }
    }
    public partial class CopyModelOperation : Azure.Operation<Azure.AI.FormRecognizer.Training.CustomFormModelInfo>
    {
        protected CopyModelOperation() { }
        public CopyModelOperation(string operationId, Azure.AI.FormRecognizer.FormRecognizerClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.AI.FormRecognizer.Training.CustomFormModelInfo Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.Training.CustomFormModelInfo>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.Training.CustomFormModelInfo>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CustomFormModel
    {
        internal CustomFormModel() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormRecognizerError> Errors { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public string ModelId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Training.CustomFormSubModel> Models { get { throw null; } }
        public Azure.AI.FormRecognizer.Training.CustomFormModelStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Training.TrainingDocumentInfo> TrainingDocuments { get { throw null; } }
    }
    public partial class CustomFormModelField
    {
        internal CustomFormModelField() { }
        public float? Accuracy { get { throw null; } }
        public string Label { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class CustomFormModelInfo
    {
        internal CustomFormModelInfo() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public string ModelId { get { throw null; } }
        public Azure.AI.FormRecognizer.Training.CustomFormModelStatus Status { get { throw null; } }
    }
    public enum CustomFormModelStatus
    {
        Invalid = 0,
        Ready = 1,
        Training = 2,
        Copying = 3,
    }
    public partial class CustomFormSubModel
    {
        internal CustomFormSubModel() { }
        public float? Accuracy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.Training.CustomFormModelField> Fields { get { throw null; } }
        public string FormType { get { throw null; } }
    }
    public partial class FormTrainingClient
    {
        protected FormTrainingClient() { }
        public FormTrainingClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public FormTrainingClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.FormRecognizer.FormRecognizerClientOptions options) { }
        public virtual Azure.Response DeleteModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.FormRecognizer.Training.AccountProperties> GetAccountProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Training.AccountProperties>> GetAccountPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.FormRecognizer.Training.CustomFormModel> GetCustomModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Training.CustomFormModel>> GetCustomModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.FormRecognizer.Training.CustomFormModelInfo> GetCustomModels(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.FormRecognizer.Training.CustomFormModelInfo> GetCustomModelsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Training.CopyModelOperation StartCopyModel(string sourceModelId, System.Uri targetEndpoint, Azure.AzureKeyCredential targetCredential, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Training.CopyModelOperation> StartCopyModelAsync(string sourceModelId, System.Uri targetEndpoint, Azure.AzureKeyCredential targetCredential, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Training.TrainingOperation StartTraining(System.Uri trainingFilesUri, bool useTrainingLabels = false, Azure.AI.FormRecognizer.Training.TrainingFileFilter filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Training.TrainingOperation> StartTrainingAsync(System.Uri trainingFilesUri, bool useTrainingLabels = false, Azure.AI.FormRecognizer.Training.TrainingFileFilter filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TrainingDocumentInfo
    {
        internal TrainingDocumentInfo() { }
        public string DocumentName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormRecognizerError> Errors { get { throw null; } }
        public int PageCount { get { throw null; } }
        public Azure.AI.FormRecognizer.Training.TrainingStatus Status { get { throw null; } }
    }
    public partial class TrainingFileFilter
    {
        internal TrainingFileFilter() { }
        public bool IncludeSubFolders { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
    }
    public partial class TrainingOperation : Azure.Operation<Azure.AI.FormRecognizer.Training.CustomFormModel>
    {
        protected TrainingOperation() { }
        public TrainingOperation(string operationId, Azure.AI.FormRecognizer.Training.FormTrainingClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.AI.FormRecognizer.Training.CustomFormModel Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.Training.CustomFormModel>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.Training.CustomFormModel>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public enum TrainingStatus
    {
        Succeeded = 0,
        PartiallySucceeded = 1,
        Failed = 2,
    }
}
