namespace Azure.AI.FormRecognizer
{
    public partial class FormRecognizerClient
    {
        protected FormRecognizerClient() { }
        public FormRecognizerClient(System.Uri endpoint, Azure.AI.FormRecognizer.Models.FormRecognizerApiKeyCredential credential) { }
        public FormRecognizerClient(System.Uri endpoint, Azure.AI.FormRecognizer.Models.FormRecognizerApiKeyCredential credential, Azure.AI.FormRecognizer.FormRecognizerClientOptions options) { }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeBusinessCardOperation StartRecognizeBusinessCards(System.IO.Stream businessCardFileStream, Azure.AI.FormRecognizer.Models.ContentType contentType, bool includeTextElements = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeBusinessCardOperation StartRecognizeBusinessCards(System.Uri businessCardFileStream, bool includeTextElements = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeBusinessCardOperation> StartRecognizeBusinessCardsAsync(System.IO.Stream businessCardFileStream, Azure.AI.FormRecognizer.Models.ContentType contentType, bool includeTextElements = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeBusinessCardOperation> StartRecognizeBusinessCardsAsync(System.Uri businessCardFileStream, bool includeTextElements = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeContentOperation StartRecognizeContent(System.IO.Stream formFileStream, Azure.AI.FormRecognizer.Models.ContentType contentType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeContentOperation StartRecognizeContent(System.Uri formFileUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeContentOperation> StartRecognizeContentAsync(System.IO.Stream formFileStream, Azure.AI.FormRecognizer.Models.ContentType contentType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeContentOperation> StartRecognizeContentAsync(System.Uri formFileUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.RecognizeFormOperation StartRecognizeForms(string modelId, System.IO.Stream formFileStream, Azure.AI.FormRecognizer.Models.ContentType contentType, bool includeTextElements = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.RecognizeFormOperation StartRecognizeForms(string modelId, System.Uri formFileUri, bool includeTextElements = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.RecognizeFormOperation> StartRecognizeFormsAsync(string modelId, System.IO.Stream formFileStream, Azure.AI.FormRecognizer.Models.ContentType contentType, bool includeTextElements = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.RecognizeFormOperation> StartRecognizeFormsAsync(string modelId, System.Uri formFileUri, bool includeTextElements = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.RecognizeLabeledFormOperation StartRecognizeLabeledForms(string modelId, System.IO.Stream formFileStream, Azure.AI.FormRecognizer.Models.ContentType contentType, bool includeTextElements = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.RecognizeLabeledFormOperation StartRecognizeLabeledForms(string modelId, System.Uri formFileUri, bool includeTextElements = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.RecognizeLabeledFormOperation> StartRecognizeLabeledFormsAsync(string modelId, System.IO.Stream formFileStream, Azure.AI.FormRecognizer.Models.ContentType contentType, bool includeTextElements = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.RecognizeLabeledFormOperation> StartRecognizeLabeledFormsAsync(string modelId, System.Uri formFileUri, bool includeTextElements = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeUSReceiptOperation StartRecognizeUSReceipts(System.IO.Stream receiptFileStream, Azure.AI.FormRecognizer.Models.ContentType contentType, bool includeTextElements = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeUSReceiptOperation StartRecognizeUSReceipts(System.Uri receiptFileUri, bool includeTextElements = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeUSReceiptOperation> StartRecognizeUSReceiptsAsync(System.IO.Stream receiptFileStream, Azure.AI.FormRecognizer.Models.ContentType contentType, bool includeTextElements = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeUSReceiptOperation> StartRecognizeUSReceiptsAsync(System.Uri receiptFileUri, bool includeTextElements = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class RecognizeFormOperation : Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.CustomFormPage>>
    {
        public RecognizeFormOperation(string id, Azure.AI.FormRecognizer.FormRecognizerClient client, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.CustomFormPage> Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.CustomFormPage>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.CustomFormPage>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecognizeLabeledFormOperation : Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.CustomLabeledForm>>
    {
        public RecognizeLabeledFormOperation(string id, Azure.AI.FormRecognizer.FormRecognizerClient client, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.CustomLabeledForm> Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.CustomLabeledForm>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.CustomLabeledForm>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.AI.FormRecognizer.Models
{
    public partial class BoundingBox
    {
        internal BoundingBox() { }
        public System.Drawing.PointF[] Points { get { throw null; } }
    }
    public partial class BusinessCard
    {
        internal BusinessCard() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormPageElements> PageTextElements { get { throw null; } }
    }
    public enum ContentType
    {
        Pdf = 0,
        Png = 1,
        Jpeg = 2,
        Tiff = 3,
    }
    public partial class CustomFormPage
    {
        internal CustomFormPage() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormCheckBox> CheckBoxes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormField> Fields { get { throw null; } }
        public int PageNumber { get { throw null; } set { } }
        public int? PageTypeId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormTable> Tables { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FormPageElements TextElements { get { throw null; } }
        public string GetFieldValue(string fieldName) { throw null; }
    }
    public partial class CustomLabeledForm
    {
        internal CustomLabeledForm() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.LabeledFormCheckBox> CheckBoxes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.LabeledFormField> Fields { get { throw null; } }
        public string FormType { get { throw null; } }
        public float FormTypeConfidence { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FormPageRange PageRange { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormPageElements> PageTextElements { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.LabeledFormTable> Tables { get { throw null; } }
        public string GetFieldValue(string label) { throw null; }
    }
    public partial class FormCheckBox
    {
        public FormCheckBox() { }
        public Azure.AI.FormRecognizer.Models.BoundingBox BoundingBox { get { throw null; } }
        public float Confidence { get { throw null; } }
        public bool IsChecked { get { throw null; } }
        public bool IsUnchecked { get { throw null; } }
    }
    public partial class FormField
    {
        internal FormField() { }
        public float Confidence { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.BoundingBox NameBoundingBox { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormTextElement> NameTextElements { get { throw null; } }
        public string Value { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.BoundingBox ValueBoundingBox { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormTextElement> ValueTextElements { get { throw null; } }
    }
    public partial class FormPageContent
    {
        internal FormPageContent() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormCheckBox> CheckBoxes { get { throw null; } }
        public int PageNumber { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormTable> Tables { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FormPageElements TextElements { get { throw null; } }
    }
    public partial class FormPageElements
    {
        internal FormPageElements() { }
        public float Angle { get { throw null; } set { } }
        public float Height { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<Azure.AI.FormRecognizer.Models.LineTextElement> Lines { get { throw null; } set { } }
        public int PageNumber { get { throw null; } set { } }
        public Azure.AI.FormRecognizer.Models.LengthUnit Unit { get { throw null; } set { } }
        public float Width { get { throw null; } set { } }
    }
    public partial class FormPageRange
    {
        internal FormPageRange() { }
        public int FirstPageNumber { get { throw null; } }
        public int LastPageNumber { get { throw null; } }
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
    public partial class FormTable
    {
        internal FormTable() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormTableCell> Cells { get { throw null; } }
        public int ColumnCount { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FormTableCell this[int row, int column] { get { throw null; } set { } }
        public int RowCount { get { throw null; } }
    }
    public partial class FormTableCell
    {
        internal FormTableCell() { }
        public Azure.AI.FormRecognizer.Models.BoundingBox BoundingBox { get { throw null; } }
        public int ColumnIndex { get { throw null; } }
        public int ColumnSpan { get { throw null; } }
        public float Confidence { get { throw null; } }
        public bool IsFooter { get { throw null; } }
        public bool IsHeader { get { throw null; } }
        public int RowIndex { get { throw null; } }
        public int RowSpan { get { throw null; } }
        public string Text { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormTextElement> TextElements { get { throw null; } }
    }
    public partial class FormTextElement
    {
        internal FormTextElement() { }
        public Azure.AI.FormRecognizer.Models.BoundingBox BoundingBox { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public enum LabeledFieldType
    {
        StringValue = 0,
        DateValue = 1,
        TimeValue = 2,
        PhoneNumberValue = 3,
        FloatValue = 4,
        IntegerValue = 5,
        ArrayValue = 6,
        ObjectValue = 7,
    }
    public partial class LabeledFormCheckBox : Azure.AI.FormRecognizer.Models.FormCheckBox
    {
        public LabeledFormCheckBox() { }
        public int PageNumber { get { throw null; } }
    }
    public partial class LabeledFormField
    {
        internal LabeledFormField() { }
        public float? Confidence { get { throw null; } }
        public string Label { get { throw null; } }
        public int? PageNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormTextElement> TextElements { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.LabeledFieldType Type { get { throw null; } }
        public string Value { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.BoundingBox ValueBoundingBox { get { throw null; } }
        public System.DateTimeOffset GetDateTimeOffset() { throw null; }
        public float GetFloat() { throw null; }
        public int GetInt32() { throw null; }
        public string GetPhoneNumber() { throw null; }
        public string GetString() { throw null; }
    }
    public partial class LabeledFormTable : Azure.AI.FormRecognizer.Models.FormTable
    {
        internal LabeledFormTable() { }
        public int PageNumber { get { throw null; } }
    }
    public enum LengthUnit
    {
        Pixel = 0,
        Inch = 1,
    }
    public partial class LineTextElement : Azure.AI.FormRecognizer.Models.FormTextElement
    {
        internal LineTextElement() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.WordTextElement> Words { get { throw null; } }
        public static implicit operator string (Azure.AI.FormRecognizer.Models.LineTextElement line) { throw null; }
    }
    public partial class RecognizeBusinessCardOperation : Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.BusinessCard>>
    {
        public RecognizeBusinessCardOperation(string id, Azure.AI.FormRecognizer.FormRecognizerClient client, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.BusinessCard> Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.BusinessCard>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.BusinessCard>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecognizeContentOperation : Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormPageContent>>
    {
        public RecognizeContentOperation(string id, Azure.AI.FormRecognizer.FormRecognizerClient client, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormPageContent> Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormPageContent>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormPageContent>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecognizeUSReceiptOperation : Azure.Operation<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.UnitedStatesReceipt>>
    {
        public RecognizeUSReceiptOperation(string id, Azure.AI.FormRecognizer.FormRecognizerClient client, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.UnitedStatesReceipt> Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.UnitedStatesReceipt>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.UnitedStatesReceipt>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UnitedStatesReceipt
    {
        internal UnitedStatesReceipt() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.Models.UnitedStatesReceiptField> Fields { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.UnitedStatesReceiptItem> Items { get { throw null; } }
        public string MerchantAddress { get { throw null; } }
        public string MerchantName { get { throw null; } }
        public string MerchantPhoneNumber { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FormPageRange PageRange { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormPageElements> PageTextElements { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.UnitedStatesReceiptType ReceiptType { get { throw null; } }
        public float? Subtotal { get { throw null; } }
        public float? Tax { get { throw null; } }
        public float? Tip { get { throw null; } }
        public float? Total { get { throw null; } }
        public System.DateTimeOffset? TransactionDate { get { throw null; } }
        public System.DateTimeOffset? TransactionTime { get { throw null; } }
    }
    public partial class UnitedStatesReceiptField
    {
        internal UnitedStatesReceiptField() { }
        public Azure.AI.FormRecognizer.Models.BoundingBox BoundingBox { get { throw null; } }
        public float? Confidence { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class UnitedStatesReceiptItem
    {
        internal UnitedStatesReceiptItem() { }
        public string Name { get { throw null; } }
        public float? Price { get { throw null; } }
        public int? Quantity { get { throw null; } }
        public float? TotalPrice { get { throw null; } }
    }
    public enum UnitedStatesReceiptType
    {
        Unrecognized = 0,
        Itemized = 1,
    }
    public partial class WordTextElement : Azure.AI.FormRecognizer.Models.FormTextElement
    {
        internal WordTextElement() { }
        public float? Confidence { get { throw null; } }
        public static implicit operator string (Azure.AI.FormRecognizer.Models.WordTextElement word) { throw null; }
    }
}
namespace Azure.AI.FormRecognizer.Training
{
    public partial class AccountProperties
    {
        internal AccountProperties() { }
        public int CustomModelCount { get { throw null; } set { } }
        public int CustomModelLimit { get { throw null; } set { } }
    }
    public partial class CustomComposedModel
    {
        internal CustomComposedModel() { }
        public Azure.AI.FormRecognizer.Training.CustomModelInfo ModelInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Training.CustomLabeledModel> Models { get { throw null; } }
        public Azure.AI.FormRecognizer.Training.TrainingInfo TrainingInfo { get { throw null; } }
    }
    public partial class CustomLabeledModel
    {
        internal CustomLabeledModel() { }
        public float AveragePredictionAccuracy { get { throw null; } }
        public string FormType { get { throw null; } }
        public Azure.AI.FormRecognizer.Training.CustomModelInfo ModelInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Training.FieldPredictionAccuracy> PredictionAccuracies { get { throw null; } }
        public Azure.AI.FormRecognizer.Training.TrainingInfo TrainingInfo { get { throw null; } }
    }
    public partial class CustomModel
    {
        internal CustomModel() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Training.CustomModelLearnedPage> LearnedPages { get { throw null; } }
        public Azure.AI.FormRecognizer.Training.CustomModelInfo ModelInfo { get { throw null; } }
        public Azure.AI.FormRecognizer.Training.TrainingInfo TrainingInfo { get { throw null; } }
    }
    public partial class CustomModelInfo
    {
        internal CustomModelInfo() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public string ModelId { get { throw null; } }
        public Azure.AI.FormRecognizer.Training.CustomModelStatus Status { get { throw null; } }
    }
    public partial class CustomModelLearnedPage
    {
        internal CustomModelLearnedPage() { }
        public System.Collections.Generic.IReadOnlyList<string> LearnedFields { get { throw null; } }
        public string PageTypeId { get { throw null; } }
    }
    public enum CustomModelStatus
    {
        Training = 0,
        Ready = 1,
        Invalid = 2,
    }
    public partial class CustomTrainingClient
    {
        protected CustomTrainingClient() { }
        public CustomTrainingClient(System.Uri endpoint, Azure.AI.FormRecognizer.Models.FormRecognizerApiKeyCredential credential) { }
        public CustomTrainingClient(System.Uri endpoint, Azure.AI.FormRecognizer.Models.FormRecognizerApiKeyCredential credential, Azure.AI.FormRecognizer.FormRecognizerClientOptions options) { }
        public virtual Azure.Response DeleteModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.FormRecognizer.Training.AccountProperties> GetAccountProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Training.AccountProperties>> GetAccountPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Training.CustomLabeledModel GetCustomLabeledModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Training.CustomLabeledModel>> GetCustomLabeledModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.FormRecognizer.Training.CustomModel> GetCustomModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Training.CustomModel>> GetCustomModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.FormRecognizer.Training.CustomModelInfo> GetModelInfos(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.FormRecognizer.Training.CustomModelInfo> GetModelInfosAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<Azure.AI.FormRecognizer.Training.CustomComposedModel> StartComposeModel(System.Collections.Generic.IEnumerable<string> modelIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.FormRecognizer.Training.CustomComposedModel>> StartComposeModelAsync(System.Collections.Generic.IEnumerable<string> modelIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Training.TrainingOperation StartTraining(System.Uri trainingFiles, Azure.AI.FormRecognizer.Training.TrainingFileFilter filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Training.TrainingOperation> StartTrainingAsync(System.Uri trainingFiles, Azure.AI.FormRecognizer.Training.TrainingFileFilter filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Training.TrainingWithLabelsOperation StartTrainingWithLabels(System.Uri trainingFiles, Azure.AI.FormRecognizer.Training.TrainingFileFilter filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Training.TrainingWithLabelsOperation> StartTrainingWithLabelsAsync(System.Uri trainingFiles, Azure.AI.FormRecognizer.Training.TrainingFileFilter filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FieldPredictionAccuracy
    {
        internal FieldPredictionAccuracy() { }
        public float Accuracy { get { throw null; } }
        public string Label { get { throw null; } }
    }
    public partial class TrainingDocumentInfo
    {
        internal TrainingDocumentInfo() { }
        public string DocumentName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.FormRecognizer.Models.FormRecognizerError> Errors { get { throw null; } }
        public int PageCount { get { throw null; } set { } }
        public Azure.AI.FormRecognizer.Training.TrainingStatus Status { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Training.TrainingDocumentInfo> DocumentInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormRecognizerError> Errors { get { throw null; } }
    }
    public partial class TrainingOperation : Azure.Operation<Azure.AI.FormRecognizer.Training.CustomModel>
    {
        protected TrainingOperation() { }
        public TrainingOperation(string id, Azure.AI.FormRecognizer.FormRecognizerClient client, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.AI.FormRecognizer.Training.CustomModel Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.Training.CustomModel>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.Training.CustomModel>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public enum TrainingStatus
    {
        Succeeded = 0,
        PartiallySucceeded = 1,
        Failed = 2,
    }
    public partial class TrainingWithLabelsOperation : Azure.Operation<Azure.AI.FormRecognizer.Training.CustomLabeledModel>
    {
        protected TrainingWithLabelsOperation() { }
        public TrainingWithLabelsOperation(string id, Azure.AI.FormRecognizer.FormRecognizerClient client, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.AI.FormRecognizer.Training.CustomLabeledModel Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.Training.CustomLabeledModel>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.Training.CustomLabeledModel>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
