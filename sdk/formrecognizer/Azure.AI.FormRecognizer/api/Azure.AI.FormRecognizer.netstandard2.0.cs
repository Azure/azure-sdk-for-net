namespace Azure.AI.FormRecognizer
{
    public enum FormContentType
    {
        Json = 0,
        Pdf = 1,
        Png = 2,
        Jpeg = 3,
        Tiff = 4,
        Bmp = 5,
    }
    public enum FormReadingOrder
    {
        Basic = 0,
        Natural = 1,
    }
    public partial class FormRecognizerClient
    {
        protected FormRecognizerClient() { }
        public FormRecognizerClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public FormRecognizerClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.FormRecognizer.FormRecognizerClientOptions options) { }
        public FormRecognizerClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public FormRecognizerClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.FormRecognizer.FormRecognizerClientOptions options) { }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeBusinessCardsOperation StartRecognizeBusinessCards(System.IO.Stream businessCard, Azure.AI.FormRecognizer.RecognizeBusinessCardsOptions recognizeBusinessCardsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeBusinessCardsOperation> StartRecognizeBusinessCardsAsync(System.IO.Stream businessCard, Azure.AI.FormRecognizer.RecognizeBusinessCardsOptions recognizeBusinessCardsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeBusinessCardsOperation StartRecognizeBusinessCardsFromUri(System.Uri businessCardUri, Azure.AI.FormRecognizer.RecognizeBusinessCardsOptions recognizeBusinessCardsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeBusinessCardsOperation> StartRecognizeBusinessCardsFromUriAsync(System.Uri businessCardUri, Azure.AI.FormRecognizer.RecognizeBusinessCardsOptions recognizeBusinessCardsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeContentOperation StartRecognizeContent(System.IO.Stream form, Azure.AI.FormRecognizer.RecognizeContentOptions recognizeContentOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeContentOperation> StartRecognizeContentAsync(System.IO.Stream form, Azure.AI.FormRecognizer.RecognizeContentOptions recognizeContentOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeContentOperation StartRecognizeContentFromUri(System.Uri formUri, Azure.AI.FormRecognizer.RecognizeContentOptions recognizeContentOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeContentOperation> StartRecognizeContentFromUriAsync(System.Uri formUri, Azure.AI.FormRecognizer.RecognizeContentOptions recognizeContentOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeCustomFormsOperation StartRecognizeCustomForms(string modelId, System.IO.Stream form, Azure.AI.FormRecognizer.RecognizeCustomFormsOptions recognizeCustomFormsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeCustomFormsOperation> StartRecognizeCustomFormsAsync(string modelId, System.IO.Stream form, Azure.AI.FormRecognizer.RecognizeCustomFormsOptions recognizeCustomFormsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeCustomFormsOperation StartRecognizeCustomFormsFromUri(string modelId, System.Uri formUri, Azure.AI.FormRecognizer.RecognizeCustomFormsOptions recognizeCustomFormsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeCustomFormsOperation> StartRecognizeCustomFormsFromUriAsync(string modelId, System.Uri formUri, Azure.AI.FormRecognizer.RecognizeCustomFormsOptions recognizeCustomFormsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeIdentityDocumentsOperation StartRecognizeIdentityDocuments(System.IO.Stream identityDocument, Azure.AI.FormRecognizer.RecognizeIdentityDocumentsOptions recognizeIdentityDocumentsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeIdentityDocumentsOperation> StartRecognizeIdentityDocumentsAsync(System.IO.Stream identityDocument, Azure.AI.FormRecognizer.RecognizeIdentityDocumentsOptions recognizeIdentityDocumentsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeIdentityDocumentsOperation StartRecognizeIdentityDocumentsFromUri(System.Uri identityDocumentUri, Azure.AI.FormRecognizer.RecognizeIdentityDocumentsOptions recognizeIdentityDocumentsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeIdentityDocumentsOperation> StartRecognizeIdentityDocumentsFromUriAsync(System.Uri identityDocumentUri, Azure.AI.FormRecognizer.RecognizeIdentityDocumentsOptions recognizeIdentityDocumentsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeInvoicesOperation StartRecognizeInvoices(System.IO.Stream invoice, Azure.AI.FormRecognizer.RecognizeInvoicesOptions recognizeInvoicesOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeInvoicesOperation> StartRecognizeInvoicesAsync(System.IO.Stream invoice, Azure.AI.FormRecognizer.RecognizeInvoicesOptions recognizeInvoicesOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeInvoicesOperation StartRecognizeInvoicesFromUri(System.Uri invoiceUri, Azure.AI.FormRecognizer.RecognizeInvoicesOptions recognizeInvoicesOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeInvoicesOperation> StartRecognizeInvoicesFromUriAsync(System.Uri invoiceUri, Azure.AI.FormRecognizer.RecognizeInvoicesOptions recognizeInvoicesOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeReceiptsOperation StartRecognizeReceipts(System.IO.Stream receipt, Azure.AI.FormRecognizer.RecognizeReceiptsOptions recognizeReceiptsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeReceiptsOperation> StartRecognizeReceiptsAsync(System.IO.Stream receipt, Azure.AI.FormRecognizer.RecognizeReceiptsOptions recognizeReceiptsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Models.RecognizeReceiptsOperation StartRecognizeReceiptsFromUri(System.Uri receiptUri, Azure.AI.FormRecognizer.RecognizeReceiptsOptions recognizeReceiptsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeReceiptsOperation> StartRecognizeReceiptsFromUriAsync(System.Uri receiptUri, Azure.AI.FormRecognizer.RecognizeReceiptsOptions recognizeReceiptsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FormRecognizerClientOptions : Azure.Core.ClientOptions
    {
        public FormRecognizerClientOptions(Azure.AI.FormRecognizer.FormRecognizerClientOptions.ServiceVersion version = Azure.AI.FormRecognizer.FormRecognizerClientOptions.ServiceVersion.V2_1) { }
        public Azure.AI.FormRecognizer.FormRecognizerClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V2_0 = 1,
            V2_1 = 2,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FormRecognizerLanguage : System.IEquatable<Azure.AI.FormRecognizer.FormRecognizerLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FormRecognizerLanguage(string value) { throw null; }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Af { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Ast { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Bi { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Br { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Ca { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Ceb { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Ch { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Co { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Crh { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Cs { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Csb { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Da { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage De { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage En { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Es { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Et { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Eu { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Fi { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Fil { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Fj { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Fr { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Fur { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Fy { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Ga { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Gd { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Gil { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Gl { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Gv { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Hni { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Hsb { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Ht { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Hu { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Ia { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Id { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage It { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Iu { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Ja { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Jv { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Kaa { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Kac { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Kea { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Kha { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Kl { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Ko { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Ku { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Kw { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Lb { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Ms { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Mww { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Nap { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Nl { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage No { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Oc { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Pl { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Pt { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Quc { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Rm { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Sco { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Sl { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Sq { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Sv { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Sw { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Tet { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Tr { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Tt { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Uz { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Vo { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Wae { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Yua { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Za { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage ZhHans { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage ZhHant { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLanguage Zu { get { throw null; } }
        public bool Equals(Azure.AI.FormRecognizer.FormRecognizerLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.FormRecognizer.FormRecognizerLanguage left, Azure.AI.FormRecognizer.FormRecognizerLanguage right) { throw null; }
        public static implicit operator Azure.AI.FormRecognizer.FormRecognizerLanguage (string value) { throw null; }
        public static bool operator !=(Azure.AI.FormRecognizer.FormRecognizerLanguage left, Azure.AI.FormRecognizer.FormRecognizerLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FormRecognizerLocale : System.IEquatable<Azure.AI.FormRecognizer.FormRecognizerLocale>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FormRecognizerLocale(string value) { throw null; }
        public static Azure.AI.FormRecognizer.FormRecognizerLocale EnAU { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLocale EnCA { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLocale EnGB { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLocale EnIN { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerLocale EnUS { get { throw null; } }
        public bool Equals(Azure.AI.FormRecognizer.FormRecognizerLocale other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.FormRecognizer.FormRecognizerLocale left, Azure.AI.FormRecognizer.FormRecognizerLocale right) { throw null; }
        public static implicit operator Azure.AI.FormRecognizer.FormRecognizerLocale (string value) { throw null; }
        public static bool operator !=(Azure.AI.FormRecognizer.FormRecognizerLocale left, Azure.AI.FormRecognizer.FormRecognizerLocale right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class OperationExtensions
    {
        public static System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Models.RecognizedFormCollection>> WaitForCompletionAsync(this System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeBusinessCardsOperation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Models.FormPageCollection>> WaitForCompletionAsync(this System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeContentOperation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Models.RecognizedFormCollection>> WaitForCompletionAsync(this System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeCustomFormsOperation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Models.RecognizedFormCollection>> WaitForCompletionAsync(this System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeInvoicesOperation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Models.RecognizedFormCollection>> WaitForCompletionAsync(this System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Models.RecognizeReceiptsOperation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Training.CustomFormModelInfo>> WaitForCompletionAsync(this System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Training.CopyModelOperation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Training.CustomFormModel>> WaitForCompletionAsync(this System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Training.CreateComposedModelOperation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.Training.CustomFormModel>> WaitForCompletionAsync(this System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Training.TrainingOperation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecognizeBusinessCardsOptions
    {
        public RecognizeBusinessCardsOptions() { }
        public Azure.AI.FormRecognizer.FormContentType? ContentType { get { throw null; } set { } }
        public bool IncludeFieldElements { get { throw null; } set { } }
        public Azure.AI.FormRecognizer.FormRecognizerLocale? Locale { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Pages { get { throw null; } }
    }
    public partial class RecognizeContentOptions
    {
        public RecognizeContentOptions() { }
        public Azure.AI.FormRecognizer.FormContentType? ContentType { get { throw null; } set { } }
        public Azure.AI.FormRecognizer.FormRecognizerLanguage? Language { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Pages { get { throw null; } }
        public Azure.AI.FormRecognizer.FormReadingOrder? ReadingOrder { get { throw null; } set { } }
    }
    public partial class RecognizeCustomFormsOptions
    {
        public RecognizeCustomFormsOptions() { }
        public Azure.AI.FormRecognizer.FormContentType? ContentType { get { throw null; } set { } }
        public bool IncludeFieldElements { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Pages { get { throw null; } }
    }
    public partial class RecognizeIdentityDocumentsOptions
    {
        public RecognizeIdentityDocumentsOptions() { }
        public Azure.AI.FormRecognizer.FormContentType? ContentType { get { throw null; } set { } }
        public bool IncludeFieldElements { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Pages { get { throw null; } }
    }
    public partial class RecognizeInvoicesOptions
    {
        public RecognizeInvoicesOptions() { }
        public Azure.AI.FormRecognizer.FormContentType? ContentType { get { throw null; } set { } }
        public bool IncludeFieldElements { get { throw null; } set { } }
        public Azure.AI.FormRecognizer.FormRecognizerLocale? Locale { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Pages { get { throw null; } }
    }
    public partial class RecognizeReceiptsOptions
    {
        public RecognizeReceiptsOptions() { }
        public Azure.AI.FormRecognizer.FormContentType? ContentType { get { throw null; } set { } }
        public bool IncludeFieldElements { get { throw null; } set { } }
        public Azure.AI.FormRecognizer.FormRecognizerLocale? Locale { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Pages { get { throw null; } }
    }
}
namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    public partial class AccountProperties
    {
        internal AccountProperties() { }
        public int Count { get { throw null; } }
        public int Limit { get { throw null; } }
    }
    public partial class AnalyzedDocument
    {
        internal AnalyzedDocument() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.BoundingRegion> BoundingRegions { get { throw null; } }
        public float Confidence { get { throw null; } }
        public string DocType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentField> Fields { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class AnalyzeDocumentOperation : Azure.Operation<Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeResult>
    {
        protected AnalyzeDocumentOperation() { }
        public AnalyzeDocumentOperation(string operationId, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AnalyzeDocumentOptions
    {
        public AnalyzeDocumentOptions() { }
        public string Locale { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Pages { get { throw null; } }
    }
    public partial class AnalyzeResult
    {
        internal AnalyzeResult() { }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzedDocument> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentEntity> Entities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentKeyValuePair> KeyValuePairs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentLanguage> Languages { get { throw null; } }
        public string ModelId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentPage> Pages { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentStyle> Styles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTable> Tables { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BoundingBox
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public System.Drawing.PointF this[int index] { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public partial class BoundingRegion
    {
        internal BoundingRegion() { }
        public Azure.AI.FormRecognizer.DocumentAnalysis.BoundingBox BoundingBox { get { throw null; } }
        public int PageNumber { get { throw null; } }
    }
    public partial class BuildModelOperation : Azure.Operation<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModel>
    {
        protected BuildModelOperation() { }
        public BuildModelOperation(string operationId, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelAdministrationClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public virtual int PercentCompleted { get { throw null; } }
        public override Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModel Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModel>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModel>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BuildModelOptions
    {
        public BuildModelOptions() { }
        public string ModelDescription { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class CopyAuthorization
    {
        internal CopyAuthorization() { }
        public System.DateTimeOffset ExpirationDateTime { get { throw null; } }
        public string TargetModelId { get { throw null; } }
        public string TargetModelLocation { get { throw null; } }
        public string TargetResourceRegion { get { throw null; } }
    }
    public partial class CopyModelOperation : Azure.Operation<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModel>
    {
        protected CopyModelOperation() { }
        public CopyModelOperation(string operationId, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelAdministrationClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public virtual int PercentCompleted { get { throw null; } }
        public override Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModel Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModel>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModel>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CurrencyValue
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public double Amount { get { throw null; } }
        public string Symbol { get { throw null; } }
    }
    public partial class DocTypeInfo
    {
        internal DocTypeInfo() { }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBuildMode? BuildMode { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, float> FieldConfidence { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldSchema> FieldSchema { get { throw null; } }
    }
    public partial class DocumentAnalysisClient
    {
        protected DocumentAnalysisClient() { }
        public DocumentAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public DocumentAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClientOptions options) { }
        public DocumentAnalysisClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DocumentAnalysisClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClientOptions options) { }
        public virtual Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeDocumentOperation StartAnalyzeDocument(string modelId, System.IO.Stream document, Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeDocumentOptions analyzeDocumentOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeDocumentOperation> StartAnalyzeDocumentAsync(string modelId, System.IO.Stream document, Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeDocumentOptions analyzeDocumentOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeDocumentOperation StartAnalyzeDocumentFromUri(string modelId, System.Uri documentUri, Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeDocumentOptions analyzeDocumentOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeDocumentOperation> StartAnalyzeDocumentFromUriAsync(string modelId, System.Uri documentUri, Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeDocumentOptions analyzeDocumentOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DocumentAnalysisClientOptions : Azure.Core.ClientOptions
    {
        public DocumentAnalysisClientOptions(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClientOptions.ServiceVersion version = Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClientOptions.ServiceVersion.V2022_01_30_preview) { }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V2022_01_30_preview = 1,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentBuildMode : System.IEquatable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBuildMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentBuildMode(string value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBuildMode Neural { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBuildMode Template { get { throw null; } }
        public bool Equals(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBuildMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBuildMode left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBuildMode right) { throw null; }
        public static implicit operator Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBuildMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBuildMode left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBuildMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentEntity
    {
        internal DocumentEntity() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.BoundingRegion> BoundingRegions { get { throw null; } }
        public string Category { get { throw null; } }
        public float Confidence { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> Spans { get { throw null; } }
        public string SubCategory { get { throw null; } }
    }
    public partial class DocumentField
    {
        internal DocumentField() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.BoundingRegion> BoundingRegions { get { throw null; } }
        public float? Confidence { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> Spans { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldType ValueType { get { throw null; } }
        public string AsCountryRegion() { throw null; }
        public Azure.AI.FormRecognizer.DocumentAnalysis.CurrencyValue AsCurrency() { throw null; }
        public System.DateTime AsDate() { throw null; }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentField> AsDictionary() { throw null; }
        public double AsDouble() { throw null; }
        public long AsInt64() { throw null; }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentField> AsList() { throw null; }
        public string AsPhoneNumber() { throw null; }
        public Azure.AI.FormRecognizer.DocumentAnalysis.SelectionMarkState AsSelectionMarkState() { throw null; }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSignatureType AsSignatureType() { throw null; }
        public string AsString() { throw null; }
        public System.TimeSpan AsTime() { throw null; }
    }
    public partial class DocumentFieldSchema
    {
        internal DocumentFieldSchema() { }
        public string Description { get { throw null; } }
        public string Example { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldSchema Items { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldSchema> Properties { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldType Type { get { throw null; } }
    }
    public enum DocumentFieldType
    {
        String = 0,
        Date = 1,
        Time = 2,
        PhoneNumber = 3,
        Double = 4,
        Int64 = 5,
        List = 6,
        Dictionary = 7,
        SelectionMark = 8,
        CountryRegion = 9,
        Signature = 10,
        Currency = 11,
    }
    public partial class DocumentKeyValueElement
    {
        internal DocumentKeyValueElement() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.BoundingRegion> BoundingRegions { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class DocumentKeyValuePair
    {
        internal DocumentKeyValuePair() { }
        public float Confidence { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentKeyValueElement Key { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentKeyValueElement Value { get { throw null; } }
    }
    public partial class DocumentLanguage
    {
        internal DocumentLanguage() { }
        public float Confidence { get { throw null; } }
        public string LanguageCode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class DocumentLine
    {
        internal DocumentLine() { }
        public Azure.AI.FormRecognizer.DocumentAnalysis.BoundingBox BoundingBox { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class DocumentModel : Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelInfo
    {
        internal DocumentModel() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.DocumentAnalysis.DocTypeInfo> DocTypes { get { throw null; } }
    }
    public partial class DocumentModelAdministrationClient
    {
        protected DocumentModelAdministrationClient() { }
        public DocumentModelAdministrationClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public DocumentModelAdministrationClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClientOptions options) { }
        public DocumentModelAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DocumentModelAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClientOptions options) { }
        public virtual Azure.Response DeleteModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.AccountProperties> GetAccountProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.AccountProperties>> GetAccountPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.CopyAuthorization> GetCopyAuthorization(string modelId = null, string modelDescription = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.CopyAuthorization>> GetCopyAuthorizationAsync(string modelId = null, string modelDescription = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModel> GetModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModel>> GetModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelInfo> GetModels(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelInfo> GetModelsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.ModelOperation> GetOperation(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.ModelOperation>> GetOperationAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.FormRecognizer.DocumentAnalysis.ModelOperationInfo> GetOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.FormRecognizer.DocumentAnalysis.ModelOperationInfo> GetOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.DocumentAnalysis.BuildModelOperation StartBuildModel(System.Uri trainingFilesUri, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBuildMode buildMode, string modelId = null, Azure.AI.FormRecognizer.DocumentAnalysis.BuildModelOptions buildModelOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.DocumentAnalysis.BuildModelOperation> StartBuildModelAsync(System.Uri trainingFilesUri, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBuildMode buildMode, string modelId = null, Azure.AI.FormRecognizer.DocumentAnalysis.BuildModelOptions buildModelOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.DocumentAnalysis.CopyModelOperation StartCopyModel(string modelId, Azure.AI.FormRecognizer.DocumentAnalysis.CopyAuthorization target, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.DocumentAnalysis.CopyModelOperation> StartCopyModelAsync(string modelId, Azure.AI.FormRecognizer.DocumentAnalysis.CopyAuthorization target, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.DocumentAnalysis.BuildModelOperation StartCreateComposedModel(System.Collections.Generic.IEnumerable<string> modelIds, string modelId = null, string modelDescription = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.DocumentAnalysis.BuildModelOperation> StartCreateComposedModelAsync(System.Collections.Generic.IEnumerable<string> modelIds, string modelId = null, string modelDescription = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DocumentModelInfo
    {
        internal DocumentModelInfo() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public string ModelId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentOperationKind : System.IEquatable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentOperationKind(string value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind DocumentModelBuild { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind DocumentModelCompose { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind DocumentModelCopyTo { get { throw null; } }
        public bool Equals(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind right) { throw null; }
        public static implicit operator Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum DocumentOperationStatus
    {
        NotStarted = 0,
        Running = 1,
        Failed = 2,
        Succeeded = 3,
        Canceled = 4,
    }
    public partial class DocumentPage
    {
        internal DocumentPage() { }
        public float Angle { get { throw null; } }
        public float Height { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentLine> Lines { get { throw null; } }
        public int PageNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSelectionMark> SelectionMarks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> Spans { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.LengthUnit Unit { get { throw null; } }
        public float Width { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentWord> Words { get { throw null; } }
    }
    public partial class DocumentSelectionMark
    {
        internal DocumentSelectionMark() { }
        public Azure.AI.FormRecognizer.DocumentAnalysis.BoundingBox BoundingBox { get { throw null; } }
        public float Confidence { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan Span { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.SelectionMarkState State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentSignatureType : System.IEquatable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSignatureType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentSignatureType(string value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSignatureType Signed { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSignatureType Unsigned { get { throw null; } }
        public bool Equals(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSignatureType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSignatureType left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSignatureType right) { throw null; }
        public static implicit operator Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSignatureType (string value) { throw null; }
        public static bool operator !=(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSignatureType left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSignatureType right) { throw null; }
        public override string ToString() { throw null; }
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
        public float Confidence { get { throw null; } }
        public bool? IsHandwritten { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class DocumentTable
    {
        internal DocumentTable() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.BoundingRegion> BoundingRegions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTableCell> Cells { get { throw null; } }
        public int ColumnCount { get { throw null; } }
        public int RowCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class DocumentTableCell
    {
        internal DocumentTableCell() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.BoundingRegion> BoundingRegions { get { throw null; } }
        public int ColumnIndex { get { throw null; } }
        public int? ColumnSpan { get { throw null; } }
        public string Content { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTableCellKind? Kind { get { throw null; } }
        public int RowIndex { get { throw null; } }
        public int? RowSpan { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> Spans { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentTableCellKind : System.IEquatable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTableCellKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentTableCellKind(string value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTableCellKind ColumnHeader { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTableCellKind Content { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTableCellKind Description { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTableCellKind RowHeader { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTableCellKind StubHead { get { throw null; } }
        public bool Equals(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTableCellKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTableCellKind left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTableCellKind right) { throw null; }
        public static implicit operator Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTableCellKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTableCellKind left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTableCellKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentWord
    {
        internal DocumentWord() { }
        public Azure.AI.FormRecognizer.DocumentAnalysis.BoundingBox BoundingBox { get { throw null; } }
        public float Confidence { get { throw null; } }
        public string Content { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan Span { get { throw null; } }
    }
    public enum LengthUnit
    {
        Pixel = 0,
        Inch = 1,
    }
    public partial class ModelOperation : Azure.AI.FormRecognizer.DocumentAnalysis.ModelOperationInfo
    {
        internal ModelOperation() { }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModel Result { get { throw null; } }
    }
    public partial class ModelOperationInfo
    {
        internal ModelOperationInfo() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind Kind { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public string OperationId { get { throw null; } }
        public int? PercentCompleted { get { throw null; } }
        public string ResourceLocation { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public enum SelectionMarkState
    {
        Unselected = 0,
        Selected = 1,
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
        public string AsCountryRegion() { throw null; }
        public System.DateTime AsDate() { throw null; }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.Models.FormField> AsDictionary() { throw null; }
        public float AsFloat() { throw null; }
        public long AsInt64() { throw null; }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormField> AsList() { throw null; }
        public string AsPhoneNumber() { throw null; }
        public Azure.AI.FormRecognizer.Models.SelectionMarkState AsSelectionMarkState() { throw null; }
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
        SelectionMark = 8,
        CountryRegion = 9,
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
        public Azure.AI.FormRecognizer.Models.TextAppearance Appearance { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormWord> Words { get { throw null; } }
    }
    public partial class FormPage
    {
        internal FormPage() { }
        public float Height { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormLine> Lines { get { throw null; } }
        public int PageNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormSelectionMark> SelectionMarks { get { throw null; } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.Training.CustomFormModel CustomFormModel(string modelId, Azure.AI.FormRecognizer.Training.CustomFormModelStatus status, System.DateTimeOffset trainingStartedOn, System.DateTimeOffset trainingCompletedOn, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Training.CustomFormSubmodel> submodels, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Training.TrainingDocumentInfo> trainingDocuments, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormRecognizerError> errors) { throw null; }
        public static Azure.AI.FormRecognizer.Training.CustomFormModel CustomFormModel(string modelId, Azure.AI.FormRecognizer.Training.CustomFormModelStatus status, System.DateTimeOffset trainingStartedOn, System.DateTimeOffset trainingCompletedOn, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Training.CustomFormSubmodel> submodels, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Training.TrainingDocumentInfo> trainingDocuments, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormRecognizerError> errors, string modelName, Azure.AI.FormRecognizer.Training.CustomFormModelProperties properties) { throw null; }
        public static Azure.AI.FormRecognizer.Training.CustomFormModelField CustomFormModelField(string name, string label, float? accuracy) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.Training.CustomFormModelInfo CustomFormModelInfo(string modelId, System.DateTimeOffset trainingStartedOn, System.DateTimeOffset trainingCompletedOn, Azure.AI.FormRecognizer.Training.CustomFormModelStatus status) { throw null; }
        public static Azure.AI.FormRecognizer.Training.CustomFormModelInfo CustomFormModelInfo(string modelId, System.DateTimeOffset trainingStartedOn, System.DateTimeOffset trainingCompletedOn, Azure.AI.FormRecognizer.Training.CustomFormModelStatus status, string modelName, Azure.AI.FormRecognizer.Training.CustomFormModelProperties properties) { throw null; }
        public static Azure.AI.FormRecognizer.Training.CustomFormModelProperties CustomFormModelProperties(bool isComposedModel) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.Training.CustomFormSubmodel CustomFormSubmodel(string formType, float? accuracy, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.Training.CustomFormModelField> fields) { throw null; }
        public static Azure.AI.FormRecognizer.Training.CustomFormSubmodel CustomFormSubmodel(string formType, float? accuracy, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.Training.CustomFormModelField> fields, string modelId) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldBoundingBox FieldBoundingBox(System.Collections.Generic.IReadOnlyList<System.Drawing.PointF> points) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldData FieldData(Azure.AI.FormRecognizer.Models.FieldBoundingBox boundingBox, int pageNumber, string text, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormElement> fieldElements) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldValue FieldValueWithCountryRegionValueType(string value) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldValue FieldValueWithDateValueType(System.DateTime value) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldValue FieldValueWithDictionaryValueType(System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.Models.FormField> value) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldValue FieldValueWithFloatValueType(float value) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldValue FieldValueWithInt64ValueType(long value) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldValue FieldValueWithListValueType(System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormField> value) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldValue FieldValueWithPhoneNumberValueType(string value) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldValue FieldValueWithSelectionMarkValueType(Azure.AI.FormRecognizer.Models.SelectionMarkState value) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldValue FieldValueWithStringValueType(string value) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FieldValue FieldValueWithTimeValueType(System.TimeSpan value) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FormField FormField(string name, Azure.AI.FormRecognizer.Models.FieldData labelData, Azure.AI.FormRecognizer.Models.FieldData valueData, Azure.AI.FormRecognizer.Models.FieldValue value, float confidence) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.Models.FormLine FormLine(Azure.AI.FormRecognizer.Models.FieldBoundingBox boundingBox, int pageNumber, string text, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormWord> words) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FormLine FormLine(Azure.AI.FormRecognizer.Models.FieldBoundingBox boundingBox, int pageNumber, string text, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormWord> words, Azure.AI.FormRecognizer.Models.TextAppearance appearance) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.Models.FormPage FormPage(int pageNumber, float width, float height, float textAngle, Azure.AI.FormRecognizer.Models.LengthUnit unit, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormLine> lines, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormTable> tables) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FormPage FormPage(int pageNumber, float width, float height, float textAngle, Azure.AI.FormRecognizer.Models.LengthUnit unit, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormLine> lines, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormTable> tables, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormSelectionMark> selectionMarks) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FormPageCollection FormPageCollection(System.Collections.Generic.IList<Azure.AI.FormRecognizer.Models.FormPage> list) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FormPageRange FormPageRange(int firstPageNumber, int lastPageNumber) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FormRecognizerError FormRecognizerError(string errorCode, string message) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FormSelectionMark FormSelectionMark(Azure.AI.FormRecognizer.Models.FieldBoundingBox boundingBox, int pageNumber, string text, float confidence, Azure.AI.FormRecognizer.Models.SelectionMarkState state) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.Models.FormTable FormTable(int pageNumber, int columnCount, int rowCount, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormTableCell> cells) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FormTable FormTable(int pageNumber, int columnCount, int rowCount, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormTableCell> cells, Azure.AI.FormRecognizer.Models.FieldBoundingBox boundingBox) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FormTableCell FormTableCell(Azure.AI.FormRecognizer.Models.FieldBoundingBox boundingBox, int pageNumber, string text, int columnIndex, int rowIndex, int columnSpan, int rowSpan, bool isHeader, bool isFooter, float confidence, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormElement> fieldElements) { throw null; }
        public static Azure.AI.FormRecognizer.Models.FormWord FormWord(Azure.AI.FormRecognizer.Models.FieldBoundingBox boundingBox, int pageNumber, string text, float confidence) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.Models.RecognizedForm RecognizedForm(string formType, Azure.AI.FormRecognizer.Models.FormPageRange pageRange, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.Models.FormField> fields, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormPage> pages) { throw null; }
        public static Azure.AI.FormRecognizer.Models.RecognizedForm RecognizedForm(string formType, Azure.AI.FormRecognizer.Models.FormPageRange pageRange, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.Models.FormField> fields, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormPage> pages, string modelId, float? formTypeConfidence) { throw null; }
        public static Azure.AI.FormRecognizer.Models.RecognizedFormCollection RecognizedFormCollection(System.Collections.Generic.IList<Azure.AI.FormRecognizer.Models.RecognizedForm> list) { throw null; }
        public static Azure.AI.FormRecognizer.Models.TextAppearance TextAppearance(Azure.AI.FormRecognizer.Models.TextStyleName styleName, float styleConfidence) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.Training.TrainingDocumentInfo TrainingDocumentInfo(string name, int pageCount, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.Models.FormRecognizerError> errors, Azure.AI.FormRecognizer.Training.TrainingStatus status) { throw null; }
        public static Azure.AI.FormRecognizer.Training.TrainingDocumentInfo TrainingDocumentInfo(string name, int pageCount, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.Models.FormRecognizerError> errors, Azure.AI.FormRecognizer.Training.TrainingStatus status, string modelId) { throw null; }
    }
    public partial class FormSelectionMark : Azure.AI.FormRecognizer.Models.FormElement
    {
        internal FormSelectionMark() { }
        public float Confidence { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.SelectionMarkState State { get { throw null; } }
    }
    public partial class FormTable
    {
        internal FormTable() { }
        public Azure.AI.FormRecognizer.Models.FieldBoundingBox BoundingBox { get { throw null; } }
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
    public partial class RecognizeBusinessCardsOperation : Azure.Operation<Azure.AI.FormRecognizer.Models.RecognizedFormCollection>
    {
        protected RecognizeBusinessCardsOperation() { }
        public RecognizeBusinessCardsOperation(string operationId, Azure.AI.FormRecognizer.FormRecognizerClient client) { }
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
    public partial class RecognizeContentOperation : Azure.Operation<Azure.AI.FormRecognizer.Models.FormPageCollection>
    {
        protected RecognizeContentOperation() { }
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
        protected RecognizeCustomFormsOperation() { }
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
        public float? FormTypeConfidence { get { throw null; } }
        public string ModelId { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.FormPageRange PageRange { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormPage> Pages { get { throw null; } }
    }
    public partial class RecognizedFormCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.FormRecognizer.Models.RecognizedForm>
    {
        internal RecognizedFormCollection() : base (default(System.Collections.Generic.IList<Azure.AI.FormRecognizer.Models.RecognizedForm>)) { }
    }
    public partial class RecognizeIdentityDocumentsOperation : Azure.Operation<Azure.AI.FormRecognizer.Models.RecognizedFormCollection>
    {
        protected RecognizeIdentityDocumentsOperation() { }
        public RecognizeIdentityDocumentsOperation(string operationId, Azure.AI.FormRecognizer.FormRecognizerClient client) { }
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
    public partial class RecognizeInvoicesOperation : Azure.Operation<Azure.AI.FormRecognizer.Models.RecognizedFormCollection>
    {
        protected RecognizeInvoicesOperation() { }
        public RecognizeInvoicesOperation(string operationId, Azure.AI.FormRecognizer.FormRecognizerClient client) { }
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
    public partial class RecognizeReceiptsOperation : Azure.Operation<Azure.AI.FormRecognizer.Models.RecognizedFormCollection>
    {
        protected RecognizeReceiptsOperation() { }
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
    public enum SelectionMarkState
    {
        Unselected = 0,
        Selected = 1,
    }
    public partial class TextAppearance
    {
        internal TextAppearance() { }
        public float StyleConfidence { get { throw null; } }
        public Azure.AI.FormRecognizer.Models.TextStyleName StyleName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextStyleName : System.IEquatable<Azure.AI.FormRecognizer.Models.TextStyleName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TextStyleName(string value) { throw null; }
        public static Azure.AI.FormRecognizer.Models.TextStyleName Handwriting { get { throw null; } }
        public static Azure.AI.FormRecognizer.Models.TextStyleName Other { get { throw null; } }
        public bool Equals(Azure.AI.FormRecognizer.Models.TextStyleName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.FormRecognizer.Models.TextStyleName left, Azure.AI.FormRecognizer.Models.TextStyleName right) { throw null; }
        public static implicit operator Azure.AI.FormRecognizer.Models.TextStyleName (string value) { throw null; }
        public static bool operator !=(Azure.AI.FormRecognizer.Models.TextStyleName left, Azure.AI.FormRecognizer.Models.TextStyleName right) { throw null; }
        public override string ToString() { throw null; }
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
        protected CopyModelOperation() { }
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
    public partial class CreateComposedModelOperation : Azure.AI.FormRecognizer.Training.CreateCustomFormModelOperation
    {
        protected CreateComposedModelOperation() { }
        public CreateComposedModelOperation(string operationId, Azure.AI.FormRecognizer.Training.FormTrainingClient client) { }
    }
    public partial class CreateCustomFormModelOperation : Azure.Operation<Azure.AI.FormRecognizer.Training.CustomFormModel>
    {
        protected CreateCustomFormModelOperation() { }
        public CreateCustomFormModelOperation(string operationId, Azure.AI.FormRecognizer.Training.FormTrainingClient client) { }
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
    public partial class CustomFormModel
    {
        internal CustomFormModel() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormRecognizerError> Errors { get { throw null; } }
        public string ModelId { get { throw null; } }
        public string ModelName { get { throw null; } }
        public Azure.AI.FormRecognizer.Training.CustomFormModelProperties Properties { get { throw null; } }
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
        public string ModelName { get { throw null; } }
        public Azure.AI.FormRecognizer.Training.CustomFormModelProperties Properties { get { throw null; } }
        public Azure.AI.FormRecognizer.Training.CustomFormModelStatus Status { get { throw null; } }
        public System.DateTimeOffset TrainingCompletedOn { get { throw null; } }
        public System.DateTimeOffset TrainingStartedOn { get { throw null; } }
    }
    public partial class CustomFormModelProperties
    {
        internal CustomFormModelProperties() { }
        public bool IsComposedModel { get { throw null; } }
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
        public string ModelId { get { throw null; } }
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
        public virtual Azure.AI.FormRecognizer.Training.CreateComposedModelOperation StartCreateComposedModel(System.Collections.Generic.IEnumerable<string> modelIds, string modelName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Training.CreateComposedModelOperation> StartCreateComposedModelAsync(System.Collections.Generic.IEnumerable<string> modelIds, string modelName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AI.FormRecognizer.Training.TrainingOperation StartTraining(System.Uri trainingFilesUri, bool useTrainingLabels, Azure.AI.FormRecognizer.Training.TrainingOptions trainingOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.Training.TrainingOperation StartTraining(System.Uri trainingFilesUri, bool useTrainingLabels, string modelName = null, Azure.AI.FormRecognizer.Training.TrainingOptions trainingOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Training.TrainingOperation> StartTrainingAsync(System.Uri trainingFilesUri, bool useTrainingLabels, Azure.AI.FormRecognizer.Training.TrainingOptions trainingOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.Training.TrainingOperation> StartTrainingAsync(System.Uri trainingFilesUri, bool useTrainingLabels, string modelName = null, Azure.AI.FormRecognizer.Training.TrainingOptions trainingOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TrainingDocumentInfo
    {
        internal TrainingDocumentInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.Models.FormRecognizerError> Errors { get { throw null; } }
        public string ModelId { get { throw null; } }
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
    public partial class TrainingOperation : Azure.AI.FormRecognizer.Training.CreateCustomFormModelOperation
    {
        protected TrainingOperation() { }
        public TrainingOperation(string operationId, Azure.AI.FormRecognizer.Training.FormTrainingClient client) { }
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
namespace Microsoft.Extensions.Azure
{
    public static partial class FormRecognizerClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.FormRecognizer.FormRecognizerClient, Azure.AI.FormRecognizer.FormRecognizerClientOptions> AddFormRecognizerClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.FormRecognizer.FormRecognizerClient, Azure.AI.FormRecognizer.FormRecognizerClientOptions> AddFormRecognizerClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.FormRecognizer.FormRecognizerClient, Azure.AI.FormRecognizer.FormRecognizerClientOptions> AddFormRecognizerClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
