namespace Azure.AI.FormRecognizer
{
    public enum FormContentType
    {
        Json = 0,
        Pdf = 1,
        Png = 2,
        Jpeg = 3,
        Tiff = 4,
    }
    public partial class FormRecognizerClient
    {
        protected FormRecognizerClient() { }
        public FormRecognizerClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public FormRecognizerClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.FormRecognizer.FormRecognizerClientOptions options) { }
        public FormRecognizerClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public FormRecognizerClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.FormRecognizer.FormRecognizerClientOptions options) { }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeContentOperation StartRecognizeContent(System.IO.Stream form, Azure.AI.FormRecognizer.RecognizeContentOptions recognizeContentOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeContentOperation> StartRecognizeContentAsync(System.IO.Stream form, Azure.AI.FormRecognizer.RecognizeContentOptions recognizeContentOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeContentOperation StartRecognizeContentFromUri(System.Uri formUri, Azure.AI.FormRecognizer.RecognizeContentOptions recognizeContentOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeContentOperation> StartRecognizeContentFromUriAsync(System.Uri formUri, Azure.AI.FormRecognizer.RecognizeContentOptions recognizeContentOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeCustomFormsOperation StartRecognizeCustomForms(string modelId, System.IO.Stream form, Azure.AI.FormRecognizer.RecognizeCustomFormsOptions recognizeCustomFormsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeCustomFormsOperation> StartRecognizeCustomFormsAsync(string modelId, System.IO.Stream form, Azure.AI.FormRecognizer.RecognizeCustomFormsOptions recognizeCustomFormsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeCustomFormsOperation StartRecognizeCustomFormsFromUri(string modelId, System.Uri formUri, Azure.AI.FormRecognizer.RecognizeCustomFormsOptions recognizeCustomFormsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeCustomFormsOperation> StartRecognizeCustomFormsFromUriAsync(string modelId, System.Uri formUri, Azure.AI.FormRecognizer.RecognizeCustomFormsOptions recognizeCustomFormsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeReceiptsOperation StartRecognizeReceipts(System.IO.Stream receipt, Azure.AI.FormRecognizer.RecognizeReceiptsOptions recognizeReceiptsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeReceiptsOperation> StartRecognizeReceiptsAsync(System.IO.Stream receipt, Azure.AI.FormRecognizer.RecognizeReceiptsOptions recognizeReceiptsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeReceiptsOperation StartRecognizeReceiptsFromUri(System.Uri receiptUri, Azure.AI.FormRecognizer.RecognizeReceiptsOptions recognizeReceiptsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeReceiptsOperation> StartRecognizeReceiptsFromUriAsync(System.Uri receiptUri, Azure.AI.FormRecognizer.RecognizeReceiptsOptions recognizeReceiptsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FormRecognizerClientOptions : Azure.Core.ClientOptions
    {
        public FormRecognizerClientOptions(Azure.AI.FormRecognizer.FormRecognizerClientOptions.ServiceVersion version = Azure.AI.FormRecognizer.FormRecognizerClientOptions.ServiceVersion.V2_0) { }
        public Azure.AI.FormRecognizer.FormRecognizerClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V2_0 = 1,
        }
    }
    public static partial class OperationExtensions
    {
        public static System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Models.FormPageCollection>> WaitForCompletionAsync(this System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeContentOperation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Models.RecognizedFormCollection>> WaitForCompletionAsync(this System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeCustomFormsOperation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Models.RecognizedFormCollection>> WaitForCompletionAsync(this System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeReceiptsOperation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Training.CustomFormModelInfo>> WaitForCompletionAsync(this System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Training.CopyModelOperation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Training.CustomFormModel>> WaitForCompletionAsync(this System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Training.TrainingOperation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecognizeContentOptions
    {
        public RecognizeContentOptions() { }
        public Azure.AI.FormRecognizer.FormContentType? ContentType { get { throw null; } set { } }
    }
    public partial class RecognizeCustomFormsOptions
    {
        public RecognizeCustomFormsOptions() { }
        public Azure.AI.FormRecognizer.FormContentType? ContentType { get { throw null; } set { } }
        public bool IncludeFieldElements { get { throw null; } set { } }
    }
    public partial class RecognizeReceiptsOptions
    {
        public RecognizeReceiptsOptions() { }
        public Azure.AI.FormRecognizer.FormContentType? ContentType { get { throw null; } set { } }
        public bool IncludeFieldElements { get { throw null; } set { } }
    }
}
namespace Azure.AI.FormRecognizer.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FieldBoundingBox
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public System.Drawing.PointF this[int index] { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public partial class FieldData : Azure.AI.FormRecognizer.Models.FormElement
    {
        internal FieldData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormElement> FieldElements { get { throw null; } }
        public static implicit operator string (Azure.AI.FormRecognizer.Models.FieldData text) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FieldValue
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Azure.AI.FormRecognizer.Models.FieldValueType ValueType { get { throw null; } }
        public System.DateTime AsDate() { throw null; }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.Models.FormField> AsDictionary() { throw null; }
        public float AsFloat() { throw null; }
        public long AsInt64() { throw null; }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormField> AsList() { throw null; }
        public string AsPhoneNumber() { throw null; }
        public string AsString() { throw null; }
        public System.TimeSpan AsTime() { throw null; }
    }
    public enum FieldValueType
    {
        String = 0,
        Date = 1,
        Time = 2,
        PhoneNumber = 3,
        Float = 4,
        Int64 = 5,
        List = 6,
        Dictionary = 7,
    }
    public abstract partial class FormElement
    {
        internal FormElement() { }
        public Azure.AI.FormRecognizer.Models.FieldBoundingBox BoundingBox { get { throw null; } }
        public int PageNumber { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class FormField
    {
        internal FormField() { }
        public float Confidence { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FieldData LabelData { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FieldValue Value { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FieldData ValueData { get { throw null; } }
    }
    public partial class FormField<T>
    {
        public FormField(Azure.AI.FormRecognizer.Models.FormField field, T value) { }
        public float Confidence { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FieldData LabelData { get { throw null; } }
        public string Name { get { throw null; } }
        public T Value { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FieldData ValueData { get { throw null; } }
        public static implicit operator T (Azure.AI.FormRecognizer.Models.FormField<T> field) { throw null; }
    }
    public partial class FormLine : Azure.AI.FormRecognizer.Models.FormElement
    {
        internal FormLine() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormWord> Words { get { throw null; } }
    }
    public partial class FormPage
    {
        internal FormPage() { }
        public float Height { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormLine> Lines { get { throw null; } }
        public int PageNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormTable> Tables { get { throw null; } }
        public float TextAngle { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.LengthUnit Unit { get { throw null; } }
        public float Width { get { throw null; } }
    }
    public partial class FormPageCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.FormRecognizer.Models.FormPage>
    {
        internal FormPageCollection() : base (default(System.Collections.Generic.IList<Azure.AI.FormRecognizer.Models.FormPage>)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct FormPageRange
    {
        private int _dummyPrimitive;
        public int FirstPageNumber { get { throw null; } }
        public int LastPageNumber { get { throw null; } }
    }
    public partial class FormRecognizerError
    {
        internal FormRecognizerError() { }
        public string ErrorCode { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public static partial class FormRecognizerModelFactory
    {
        public static Azure.AI.FormRecognizer.Training.AccountProperties AccountProperties(int customModelCount, int customModelLimit) { throw null; }
        public static Azure.AI.FormRecognizer.Training.CustomFormModel CustomFormModel(string modelId, Azure.AI.FormRecognizer.Training.CustomFormModelStatus status, System.DateTimeOffset trainingStartedOn, System.DateTimeOffset trainingCompletedOn, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Training.CustomFormSubmodel> submodels, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Training.TrainingDocumentInfo> trainingDocuments, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormRecognizerError> errors) { throw null; }
        public static Azure.AI.FormRecognizer.Training.CustomFormModelField CustomFormModelField(string name, string label, float? accuracy) { throw null; }
        public static Azure.AI.FormRecognizer.Training.CustomFormModelInfo CustomFormModelInfo(string modelId, System.DateTimeOffset trainingStartedOn, System.DateTimeOffset trainingCompletedOn, Azure.AI.FormRecognizer.Training.CustomFormModelStatus status) { throw null; }
        public static Azure.AI.FormRecognizer.Training.CustomFormSubmodel CustomFormSubmodel(string formType, float? accuracy, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.Training.CustomFormModelField> fields) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldBoundingBox FieldBoundingBox(System.Collections.Generic.IReadOnlyList<System.Drawing.PointF> points) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldData FieldData(Azure.AI.FormRecognizer.Models.FieldBoundingBox boundingBox, int pageNumber, string text, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormElement> fieldElements) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldValue FieldValueWithDateValueType(System.DateTime value) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldValue FieldValueWithDictionaryValueType(System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.Models.FormField> value) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldValue FieldValueWithFloatValueType(float value) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldValue FieldValueWithInt64ValueType(long value) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldValue FieldValueWithListValueType(System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormField> value) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldValue FieldValueWithPhoneNumberValueType(string value) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldValue FieldValueWithStringValueType(string value) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldValue FieldValueWithTimeValueType(System.TimeSpan value) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FormField FormField(string name, Azure.AI.FormRecognizer.Models.FieldData labelData, Azure.AI.FormRecognizer.Models.FieldData valueData, Azure.AI.FormRecognizer.Models.FieldValue value, float confidence) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FormLine FormLine(Azure.AI.FormRecognizer.Models.FieldBoundingBox boundingBox, int pageNumber, string text, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormWord> words) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FormPage FormPage(int pageNumber, float width, float height, float textAngle, Azure.AI.FormRecognizer.Models.LengthUnit unit, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormLine> lines, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormTable> tables) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FormPageCollection FormPageCollection(System.Collections.Generic.IList<Azure.AI.FormRecognizer.Models.FormPage> list) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FormPageRange FormPageRange(int firstPageNumber, int lastPageNumber) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FormRecognizerError FormRecognizerError(string errorCode, string message) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FormTable FormTable(int pageNumber, int columnCount, int rowCount, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormTableCell> cells) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FormTableCell FormTableCell(Azure.AI.FormRecognizer.Models.FieldBoundingBox boundingBox, int pageNumber, string text, int columnIndex, int rowIndex, int columnSpan, int rowSpan, bool isHeader, bool isFooter, float confidence, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormElement> fieldElements) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FormWord FormWord(Azure.AI.FormRecognizer.Models.FieldBoundingBox boundingBox, int pageNumber, string text, float confidence) { throw null; }
        public static Azure.AI.FormRecognizer.Models.RecognizedForm RecognizedForm(string formType, Azure.AI.FormRecognizer.Models.FormPageRange pageRange, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.Models.FormField> fields, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormPage> pages) { throw null; }
        public static Azure.AI.FormRecognizer.Models.RecognizedFormCollection RecognizedFormCollection(System.Collections.Generic.IList<Azure.AI.FormRecognizer.Models.RecognizedForm> list) { throw null; }
        public static Azure.AI.FormRecognizer.Training.TrainingDocumentInfo TrainingDocumentInfo(string name, int pageCount, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.Models.FormRecognizerError> errors, Azure.AI.FormRecognizer.Training.TrainingStatus status) { throw null; }
    }
    public partial class FormTable
    {
        internal FormTable() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormTableCell> Cells { get { throw null; } }
        public int ColumnCount { get { throw null; } }
        public int PageNumber { get { throw null; } }
        public int RowCount { get { throw null; } }
    }
    public partial class FormTableCell : Azure.AI.FormRecognizer.Models.FormElement
    {
        internal FormTableCell() { }
        public int ColumnIndex { get { throw null; } }
        public int ColumnSpan { get { throw null; } }
        public float Confidence { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormElement> FieldElements { get { throw null; } }
        public bool IsFooter { get { throw null; } }
        public bool IsHeader { get { throw null; } }
        public int RowIndex { get { throw null; } }
        public int RowSpan { get { throw null; } }
    }
    public partial class FormWord : Azure.AI.FormRecognizer.Models.FormElement
    {
        internal FormWord() { }
        public float Confidence { get { throw null; } }
    }
    public enum LengthUnit
    {
        Pixel = 0,
        Inch = 1,
    }
    public partial class RecognizeContentOperation : Azure.Operation<Azure.AI.FormRecognizer.Models.FormPageCollection>
    {
        public RecognizeContentOperation(string operationId, Azure.AI.FormRecognizer.FormRecognizerClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.AI.FormRecognizer.Models.FormPageCollection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.Models.FormPageCollection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.Models.FormPageCollection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecognizeCustomFormsOperation : Azure.Operation<Azure.AI.FormRecognizer.Models.RecognizedFormCollection>
    {
        public RecognizeCustomFormsOperation(string operationId, Azure.AI.FormRecognizer.FormRecognizerClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.AI.FormRecognizer.Models.RecognizedFormCollection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.Models.RecognizedFormCollection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.Models.RecognizedFormCollection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecognizedForm
    {
        internal RecognizedForm() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.Models.FormField> Fields { get { throw null; } }
        public string FormType { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FormPageRange PageRange { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormPage> Pages { get { throw null; } }
    }
    public partial class RecognizedFormCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.FormRecognizer.Models.RecognizedForm>
    {
        internal RecognizedFormCollection() : base (default(System.Collections.Generic.IList<Azure.AI.FormRecognizer.Models.RecognizedForm>)) { }
    }
    public partial class RecognizeReceiptsOperation : Azure.Operation<Azure.AI.FormRecognizer.Models.RecognizedFormCollection>
    {
        public RecognizeReceiptsOperation(string operationId, Azure.AI.FormRecognizer.FormRecognizerClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.AI.FormRecognizer.Models.RecognizedFormCollection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.Models.RecognizedFormCollection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.Models.RecognizedFormCollection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class CopyAuthorization
    {
        internal CopyAuthorization() { }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public string ModelId { get { throw null; } }
        public static Azure.AI.FormRecognizer.Training.CopyAuthorization FromJson(string copyAuthorization) { throw null; }
        public string ToJson() { throw null; }
    }
    public partial class CopyModelOperation : Azure.Operation<Azure.AI.FormRecognizer.Training.CustomFormModelInfo>
    {
        public CopyModelOperation(string operationId, string targetModelId, Azure.AI.FormRecognizer.Training.FormTrainingClient client) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormRecognizerError> Errors { get { throw null; } }
        public string ModelId { get { throw null; } }
        public Azure.AI.FormRecognizer.Training.CustomFormModelStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Training.CustomFormSubmodel> Submodels { get { throw null; } }
        public System.DateTimeOffset TrainingCompletedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Training.TrainingDocumentInfo> TrainingDocuments { get { throw null; } }
        public System.DateTimeOffset TrainingStartedOn { get { throw null; } }
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
        public string ModelId { get { throw null; } }
        public Azure.AI.FormRecognizer.Training.CustomFormModelStatus Status { get { throw null; } }
        public System.DateTimeOffset TrainingCompletedOn { get { throw null; } }
        public System.DateTimeOffset TrainingStartedOn { get { throw null; } }
    }
    public enum CustomFormModelStatus
    {
        Invalid = 0,
        Ready = 1,
        Creating = 2,
    }
    public partial class CustomFormSubmodel
    {
        internal CustomFormSubmodel() { }
        public float? Accuracy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.Training.CustomFormModelField> Fields { get { throw null; } }
        public string FormType { get { throw null; } }
    }
    public partial class FormTrainingClient
    {
        protected FormTrainingClient() { }
        public FormTrainingClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public FormTrainingClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.FormRecognizer.FormRecognizerClientOptions options) { }
        public FormTrainingClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public FormTrainingClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.FormRecognizer.FormRecognizerClientOptions options) { }
        public virtual Azure.Response DeleteModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.FormRecognizer.Training.AccountProperties> GetAccountProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Training.AccountProperties>> GetAccountPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.FormRecognizer.Training.CopyAuthorization> GetCopyAuthorization(string resourceId, string resourceRegion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Training.CopyAuthorization>> GetCopyAuthorizationAsync(string resourceId, string resourceRegion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.FormRecognizer.Training.CustomFormModel> GetCustomModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Training.CustomFormModel>> GetCustomModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.FormRecognizer.Training.CustomFormModelInfo> GetCustomModels(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.FormRecognizer.Training.CustomFormModelInfo> GetCustomModelsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.FormRecognizerClient GetFormRecognizerClient() { throw null; }
        public virtual Azure.AI.FormRecognizer.Training.CopyModelOperation StartCopyModel(string modelId, Azure.AI.FormRecognizer.Training.CopyAuthorization target, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Training.CopyModelOperation> StartCopyModelAsync(string modelId, Azure.AI.FormRecognizer.Training.CopyAuthorization target, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Training.TrainingOperation StartTraining(System.Uri trainingFilesUri, bool useTrainingLabels, Azure.AI.FormRecognizer.Training.TrainingOptions trainingOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Training.TrainingOperation> StartTrainingAsync(System.Uri trainingFilesUri, bool useTrainingLabels, Azure.AI.FormRecognizer.Training.TrainingOptions trainingOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TrainingDocumentInfo
    {
        internal TrainingDocumentInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormRecognizerError> Errors { get { throw null; } }
        public string Name { get { throw null; } }
        public int PageCount { get { throw null; } }
        public Azure.AI.FormRecognizer.Training.TrainingStatus Status { get { throw null; } }
    }
    public partial class TrainingFileFilter
    {
        public TrainingFileFilter() { }
        public bool IncludeSubfolders { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
    }
    public partial class TrainingOperation : Azure.Operation<Azure.AI.FormRecognizer.Training.CustomFormModel>
    {
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
    public partial class TrainingOptions
    {
        public TrainingOptions() { }
        public Azure.AI.FormRecognizer.Training.TrainingFileFilter TrainingFileFilter { get { throw null; } set { } }
    }
    public enum TrainingStatus
    {
        Succeeded = 0,
        PartiallySucceeded = 1,
        Failed = 2,
    }
}
