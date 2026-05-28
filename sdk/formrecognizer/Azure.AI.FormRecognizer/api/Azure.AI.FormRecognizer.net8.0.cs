namespace Azure.AI.FormRecognizer
{
    public enum FormContentType
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FormRecognizerAudience : System.IEquatable<Azure.AI.FormRecognizer.FormRecognizerAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FormRecognizerAudience(string value) { throw null; }
        public static Azure.AI.FormRecognizer.FormRecognizerAudience AzureChina { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerAudience AzureGovernment { get { throw null; } }
        public static Azure.AI.FormRecognizer.FormRecognizerAudience AzurePublicCloud { get { throw null; } }
        public bool Equals(Azure.AI.FormRecognizer.FormRecognizerAudience other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.FormRecognizer.FormRecognizerAudience left, Azure.AI.FormRecognizer.FormRecognizerAudience right) { throw null; }
        public static implicit operator Azure.AI.FormRecognizer.FormRecognizerAudience (string value) { throw null; }
        public static bool operator !=(Azure.AI.FormRecognizer.FormRecognizerAudience left, Azure.AI.FormRecognizer.FormRecognizerAudience right) { throw null; }
        public override string ToString() { throw null; }
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
        public Azure.AI.FormRecognizer.FormRecognizerAudience? Audience { get { throw null; } set { } }
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
    public partial class AnalyzedDocument
    {
        internal AnalyzedDocument() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.BoundingRegion> BoundingRegions { get { throw null; } }
        public float Confidence { get { throw null; } }
        public string DocumentType { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisFeature> Features { get { throw null; } }
        public string Locale { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Pages { get { throw null; } }
    }
    public partial class AnalyzeResult
    {
        internal AnalyzeResult() { }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzedDocument> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentKeyValuePair> KeyValuePairs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentLanguage> Languages { get { throw null; } }
        public string ModelId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentPage> Pages { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentParagraph> Paragraphs { get { throw null; } }
        public string ServiceVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentStyle> Styles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTable> Tables { get { throw null; } }
    }
    public partial class BlobContentSource : Azure.AI.FormRecognizer.DocumentAnalysis.DocumentContentSource
    {
        public BlobContentSource(System.Uri containerUri) { }
        public System.Uri ContainerUri { get { throw null; } }
        public string Prefix { get { throw null; } set { } }
    }
    public partial class BlobFileListContentSource : Azure.AI.FormRecognizer.DocumentAnalysis.DocumentContentSource
    {
        public BlobFileListContentSource(System.Uri containerUri, string fileList) { }
        public System.Uri ContainerUri { get { throw null; } }
        public string FileList { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BoundingRegion : System.IEquatable<Azure.AI.FormRecognizer.DocumentAnalysis.BoundingRegion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public System.Collections.Generic.IReadOnlyList<System.Drawing.PointF> BoundingPolygon { get { throw null; } }
        public int PageNumber { get { throw null; } }
        public bool Equals(Azure.AI.FormRecognizer.DocumentAnalysis.BoundingRegion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BuildDocumentClassifierOperation : Azure.Operation<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentClassifierDetails>
    {
        protected BuildDocumentClassifierOperation() { }
        public BuildDocumentClassifierOperation(string operationId, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelAdministrationClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public virtual int PercentCompleted { get { throw null; } }
        public override Azure.AI.FormRecognizer.DocumentAnalysis.DocumentClassifierDetails Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentClassifierDetails>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentClassifierDetails>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BuildDocumentModelOperation : Azure.Operation<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails>
    {
        protected BuildDocumentModelOperation() { }
        public BuildDocumentModelOperation(string operationId, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelAdministrationClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public virtual int PercentCompleted { get { throw null; } }
        public override Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BuildDocumentModelOptions
    {
        public BuildDocumentModelOptions() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ClassifierDocumentTypeDetails
    {
        public ClassifierDocumentTypeDetails(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentContentSource trainingDataSource) { }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentContentSource TrainingDataSource { get { throw null; } }
    }
    public partial class ClassifyDocumentOperation : Azure.Operation<Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeResult>
    {
        protected ClassifyDocumentOperation() { }
        public ClassifyDocumentOperation(string operationId, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClient client) { }
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
    public partial class ComposeDocumentModelOperation : Azure.Operation<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails>
    {
        protected ComposeDocumentModelOperation() { }
        public ComposeDocumentModelOperation(string operationId, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelAdministrationClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public virtual int PercentCompleted { get { throw null; } }
        public override Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CopyDocumentModelToOperation : Azure.Operation<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails>
    {
        protected CopyDocumentModelToOperation() { }
        public CopyDocumentModelToOperation(string operationId, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelAdministrationClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public virtual int PercentCompleted { get { throw null; } }
        public override Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CurrencyValue
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public double Amount { get { throw null; } }
        public string Code { get { throw null; } }
        public string Symbol { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentAnalysisAudience : System.IEquatable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentAnalysisAudience(string value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisAudience AzureChina { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisAudience AzureGovernment { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisAudience AzurePublicCloud { get { throw null; } }
        public bool Equals(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisAudience other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisAudience left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisAudience right) { throw null; }
        public static implicit operator Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisAudience (string value) { throw null; }
        public static bool operator !=(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisAudience left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisAudience right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentAnalysisClient
    {
        protected DocumentAnalysisClient() { }
        public DocumentAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public DocumentAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClientOptions options) { }
        public DocumentAnalysisClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DocumentAnalysisClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClientOptions options) { }
        public virtual Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeDocumentOperation AnalyzeDocument(Azure.WaitUntil waitUntil, string modelId, System.IO.Stream document, Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeDocumentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeDocumentOperation> AnalyzeDocumentAsync(Azure.WaitUntil waitUntil, string modelId, System.IO.Stream document, Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeDocumentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeDocumentOperation AnalyzeDocumentFromUri(Azure.WaitUntil waitUntil, string modelId, System.Uri documentUri, Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeDocumentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeDocumentOperation> AnalyzeDocumentFromUriAsync(Azure.WaitUntil waitUntil, string modelId, System.Uri documentUri, Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeDocumentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.DocumentAnalysis.ClassifyDocumentOperation ClassifyDocument(Azure.WaitUntil waitUntil, string classifierId, System.IO.Stream document, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.DocumentAnalysis.ClassifyDocumentOperation> ClassifyDocumentAsync(Azure.WaitUntil waitUntil, string classifierId, System.IO.Stream document, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.DocumentAnalysis.ClassifyDocumentOperation ClassifyDocumentFromUri(Azure.WaitUntil waitUntil, string classifierId, System.Uri documentUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.DocumentAnalysis.ClassifyDocumentOperation> ClassifyDocumentFromUriAsync(Azure.WaitUntil waitUntil, string classifierId, System.Uri documentUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DocumentAnalysisClientOptions : Azure.Core.ClientOptions
    {
        public DocumentAnalysisClientOptions(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClientOptions.ServiceVersion version = Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClientOptions.ServiceVersion.V2023_07_31) { }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisAudience? Audience { get { throw null; } set { } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V2022_08_31 = 1,
            V2023_07_31 = 2,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentAnalysisFeature : System.IEquatable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisFeature>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentAnalysisFeature(string value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisFeature Barcodes { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisFeature FontStyling { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisFeature Formulas { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisFeature KeyValuePairs { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisFeature Languages { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisFeature OcrHighResolution { get { throw null; } }
        public bool Equals(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisFeature other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisFeature left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisFeature right) { throw null; }
        public static implicit operator Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisFeature (string value) { throw null; }
        public static bool operator !=(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisFeature left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisFeature right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class DocumentAnalysisModelFactory
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.DocumentAnalysis.AddressValue AddressValue(string houseNumber, string poBox, string road, string city, string state, string postalCode, string countryRegion, string streetAddress) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.AddressValue AddressValue(string houseNumber = null, string poBox = null, string road = null, string city = null, string state = null, string postalCode = null, string countryRegion = null, string streetAddress = null, string unit = null, string cityDistrict = null, string stateDistrict = null, string suburb = null, string house = null, string level = null) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzedDocument AnalyzedDocument(string documentType = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> spans = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentField> fields = null, float confidence = 0f) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeResult AnalyzeResult(string modelId, string content, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentPage> pages, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTable> tables, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentKeyValuePair> keyValuePairs, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentStyle> styles, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentLanguage> languages, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzedDocument> documents) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzeResult AnalyzeResult(string modelId = null, string content = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentPage> pages = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTable> tables = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentKeyValuePair> keyValuePairs = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentStyle> styles = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentLanguage> languages = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzedDocument> documents = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentParagraph> paragraphs = null, string serviceVersion = null) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.BoundingRegion BoundingRegion(int pageNumber = 0, System.Collections.Generic.IReadOnlyList<System.Drawing.PointF> boundingPolygon = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.DocumentAnalysis.CurrencyValue CurrencyValue(double amount, string symbol) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.CurrencyValue CurrencyValue(double amount = 0, string symbol = null, string code = null) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcode DocumentBarcode(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind kind = default(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind), string value = null, System.Collections.Generic.IReadOnlyList<System.Drawing.PointF> boundingPolygon = null, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan span = default(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan), float confidence = 0f) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentClassifierBuildOperationDetails DocumentClassifierBuildOperationDetails(string operationId = null, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationStatus status = Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationStatus.NotStarted, int? percentCompleted = default(int?), System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.Uri resourceLocation = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.ResponseError error = null, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentClassifierDetails result = null, string serviceVersion = null) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentClassifierDetails DocumentClassifierDetails(string classifierId = null, string description = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), string serviceVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.DocumentAnalysis.ClassifierDocumentTypeDetails> documentTypes = null) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentField DocumentField(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldType fieldType, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldValue value, string content, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.BoundingRegion> boundingRegions, System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> spans, float? confidence) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldSchema DocumentFieldSchema(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldType type = Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldType.Unknown, string description = null, string example = null, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldSchema items = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldSchema> properties = null) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldValue DocumentFieldValueWithAddressFieldType(Azure.AI.FormRecognizer.DocumentAnalysis.AddressValue value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldValue DocumentFieldValueWithBooleanFieldType(bool value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldValue DocumentFieldValueWithCountryRegionFieldType(string value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldValue DocumentFieldValueWithCurrencyFieldType(Azure.AI.FormRecognizer.DocumentAnalysis.CurrencyValue value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldValue DocumentFieldValueWithDateFieldType(System.DateTimeOffset value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldValue DocumentFieldValueWithDictionaryFieldType(System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentField> value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldValue DocumentFieldValueWithDoubleFieldType(double value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldValue DocumentFieldValueWithInt64FieldType(int value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldValue DocumentFieldValueWithListFieldType(System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentField> value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldValue DocumentFieldValueWithPhoneNumberFieldType(string value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldValue DocumentFieldValueWithSelectionMarkFieldType(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSelectionMarkState value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldValue DocumentFieldValueWithSignatureFieldType(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSignatureType value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldValue DocumentFieldValueWithStringFieldType(string value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldValue DocumentFieldValueWithTimeFieldType(System.TimeSpan value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldValue DocumentFieldValueWithUnknownFieldType(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldType expectedFieldType) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFormula DocumentFormula(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFormulaKind kind = default(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFormulaKind), string value = null, System.Collections.Generic.IReadOnlyList<System.Drawing.PointF> boundingPolygon = null, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan span = default(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan), float confidence = 0f) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentKeyValueElement DocumentKeyValueElement(string content = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> spans = null) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentKeyValuePair DocumentKeyValuePair(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentKeyValueElement key, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentKeyValueElement value, float confidence) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentLanguage DocumentLanguage(string locale = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> spans = null, float confidence = 0f) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentLine DocumentLine(string content = null, System.Collections.Generic.IReadOnlyList<System.Drawing.PointF> boundingPolygon = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> spans = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentWord> words = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelBuildOperationDetails DocumentModelBuildOperationDetails(string operationId, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationStatus status, int? percentCompleted, System.DateTimeOffset createdOn, System.DateTimeOffset lastUpdatedOn, System.Uri resourceLocation, System.Collections.Generic.IReadOnlyDictionary<string, string> tags, Azure.ResponseError error, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails result) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelBuildOperationDetails DocumentModelBuildOperationDetails(string operationId = null, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationStatus status = Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationStatus.NotStarted, int? percentCompleted = default(int?), System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.Uri resourceLocation = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.ResponseError error = null, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails result = null, string serviceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelComposeOperationDetails DocumentModelComposeOperationDetails(string operationId, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationStatus status, int? percentCompleted, System.DateTimeOffset createdOn, System.DateTimeOffset lastUpdatedOn, System.Uri resourceLocation, System.Collections.Generic.IReadOnlyDictionary<string, string> tags, Azure.ResponseError error, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails result) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelComposeOperationDetails DocumentModelComposeOperationDetails(string operationId = null, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationStatus status = Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationStatus.NotStarted, int? percentCompleted = default(int?), System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.Uri resourceLocation = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.ResponseError error = null, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails result = null, string serviceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelCopyToOperationDetails DocumentModelCopyToOperationDetails(string operationId, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationStatus status, int? percentCompleted, System.DateTimeOffset createdOn, System.DateTimeOffset lastUpdatedOn, System.Uri resourceLocation, System.Collections.Generic.IReadOnlyDictionary<string, string> tags, Azure.ResponseError error, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails result) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelCopyToOperationDetails DocumentModelCopyToOperationDetails(string operationId = null, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationStatus status = Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationStatus.NotStarted, int? percentCompleted = default(int?), System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.Uri resourceLocation = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.ResponseError error = null, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails result = null, string serviceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails DocumentModelDetails(string modelId, string description, System.DateTimeOffset createdOn, System.Collections.Generic.IReadOnlyDictionary<string, string> tags, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTypeDetails> documentTypes) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails DocumentModelDetails(string modelId = null, string description = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTypeDetails> documentTypes = null, System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), string serviceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelSummary DocumentModelSummary(string modelId, string description, System.DateTimeOffset createdOn, System.Collections.Generic.IReadOnlyDictionary<string, string> tags) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelSummary DocumentModelSummary(string modelId = null, string description = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), string serviceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentPage DocumentPage(int pageNumber, float? angle, float? width, float? height, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentPageLengthUnit? unit, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> spans, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentWord> words, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSelectionMark> selectionMarks, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentLine> lines) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentPage DocumentPage(int pageNumber = 0, float? angle = default(float?), float? width = default(float?), float? height = default(float?), Azure.AI.FormRecognizer.DocumentAnalysis.DocumentPageLengthUnit? unit = default(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentPageLengthUnit?), System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> spans = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentWord> words = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSelectionMark> selectionMarks = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentLine> lines = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcode> barcodes = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFormula> formulas = null) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentParagraph DocumentParagraph(Azure.AI.FormRecognizer.DocumentAnalysis.ParagraphRole? role = default(Azure.AI.FormRecognizer.DocumentAnalysis.ParagraphRole?), string content = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> spans = null) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSelectionMark DocumentSelectionMark(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSelectionMarkState state = Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSelectionMarkState.Unselected, System.Collections.Generic.IReadOnlyList<System.Drawing.PointF> boundingPolygon = null, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan span = default(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan), float confidence = 0f) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan DocumentSpan(int offset = 0, int length = 0) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentStyle DocumentStyle(bool? isHandwritten, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> spans, float confidence) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentStyle DocumentStyle(bool? isHandwritten = default(bool?), System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> spans = null, float confidence = 0f, string similarFontFamily = null, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontStyle? fontStyle = default(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontStyle?), Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontWeight? fontWeight = default(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontWeight?), string color = null, string backgroundColor = null) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTable DocumentTable(int rowCount = 0, int columnCount = 0, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTableCell> cells = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> spans = null) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTableCell DocumentTableCell(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTableCellKind kind = default(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTableCellKind), int rowIndex = 0, int columnIndex = 0, int rowSpan = 0, int columnSpan = 0, string content = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.BoundingRegion> boundingRegions = null, System.Collections.Generic.IEnumerable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> spans = null) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTypeDetails DocumentTypeDetails(string description = null, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBuildMode? buildMode = default(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBuildMode?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldSchema> fieldSchema = null, System.Collections.Generic.IReadOnlyDictionary<string, float> fieldConfidence = null) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentWord DocumentWord(string content = null, System.Collections.Generic.IReadOnlyList<System.Drawing.PointF> boundingPolygon = null, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan span = default(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan), float confidence = 0f) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.DocumentAnalysis.OperationDetails OperationDetails(string operationId, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationStatus status, int? percentCompleted, System.DateTimeOffset createdOn, System.DateTimeOffset lastUpdatedOn, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind kind, System.Uri resourceLocation, System.Collections.Generic.IReadOnlyDictionary<string, string> tags, Azure.ResponseError error) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.OperationDetails OperationDetails(string operationId = null, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationStatus status = Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationStatus.NotStarted, int? percentCompleted = default(int?), System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind kind = default(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind), System.Uri resourceLocation = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.ResponseError error = null, string serviceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.DocumentAnalysis.OperationSummary OperationSummary(string operationId, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationStatus status, int? percentCompleted, System.DateTimeOffset createdOn, System.DateTimeOffset lastUpdatedOn, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind kind, System.Uri resourceLocation, System.Collections.Generic.IReadOnlyDictionary<string, string> tags) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.OperationSummary OperationSummary(string operationId = null, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationStatus status = Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationStatus.NotStarted, int? percentCompleted = default(int?), System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind kind = default(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind), System.Uri resourceLocation = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, string serviceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.FormRecognizer.DocumentAnalysis.ResourceDetails ResourceDetails(int customDocumentModelCount, int customDocumentModelLimit) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.ResourceDetails ResourceDetails(int customDocumentModelCount = 0, int customDocumentModelLimit = 0, Azure.AI.FormRecognizer.DocumentAnalysis.ResourceQuotaDetails neuralDocumentModelQuota = null) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.ResourceQuotaDetails ResourceQuotaDetails(int used = 0, int quota = 0, System.DateTimeOffset quotaResetsOn = default(System.DateTimeOffset)) { throw null; }
    }
    public partial class DocumentBarcode
    {
        internal DocumentBarcode() { }
        public System.Collections.Generic.IReadOnlyList<System.Drawing.PointF> BoundingPolygon { get { throw null; } }
        public float Confidence { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind Kind { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan Span { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentBarcodeKind : System.IEquatable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentBarcodeKind(string value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind Aztec { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind Codabar { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind Code128 { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind Code39 { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind Code93 { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind DataBar { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind DataBarExpanded { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind DataMatrix { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind Ean13 { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind Ean8 { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind Itf { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind MaxiCode { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind MicroQrCode { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind Pdf417 { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind QrCode { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind Upca { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind Upce { get { throw null; } }
        public bool Equals(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind right) { throw null; }
        public static implicit operator Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcodeKind right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class DocumentClassifierBuildOperationDetails : Azure.AI.FormRecognizer.DocumentAnalysis.OperationDetails
    {
        internal DocumentClassifierBuildOperationDetails() { }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentClassifierDetails Result { get { throw null; } }
    }
    public partial class DocumentClassifierDetails
    {
        internal DocumentClassifierDetails() { }
        public string ClassifierId { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.DocumentAnalysis.ClassifierDocumentTypeDetails> DocumentTypes { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string ServiceVersion { get { throw null; } }
    }
    public abstract partial class DocumentContentSource
    {
        internal DocumentContentSource() { }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentContentSourceKind Kind { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentContentSourceKind : System.IEquatable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentContentSourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentContentSourceKind(string value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentContentSourceKind Blob { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentContentSourceKind BlobFileList { get { throw null; } }
        public bool Equals(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentContentSourceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentContentSourceKind left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentContentSourceKind right) { throw null; }
        public static implicit operator Azure.AI.FormRecognizer.DocumentAnalysis.DocumentContentSourceKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentContentSourceKind left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentContentSourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentField
    {
        internal DocumentField() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.BoundingRegion> BoundingRegions { get { throw null; } }
        public float? Confidence { get { throw null; } }
        public string Content { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldType ExpectedFieldType { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldType FieldType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> Spans { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldValue Value { get { throw null; } }
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
        Unknown = 0,
        String = 1,
        Date = 2,
        Time = 3,
        PhoneNumber = 4,
        Double = 5,
        Int64 = 6,
        List = 7,
        Dictionary = 8,
        SelectionMark = 9,
        CountryRegion = 10,
        Signature = 11,
        Currency = 12,
        Address = 13,
        Boolean = 14,
    }
    public partial class DocumentFieldValue
    {
        internal DocumentFieldValue() { }
        public Azure.AI.FormRecognizer.DocumentAnalysis.AddressValue AsAddress() { throw null; }
        public bool AsBoolean() { throw null; }
        public string AsCountryRegion() { throw null; }
        public Azure.AI.FormRecognizer.DocumentAnalysis.CurrencyValue AsCurrency() { throw null; }
        public System.DateTimeOffset AsDate() { throw null; }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentField> AsDictionary() { throw null; }
        public double AsDouble() { throw null; }
        public long AsInt64() { throw null; }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentField> AsList() { throw null; }
        public string AsPhoneNumber() { throw null; }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSelectionMarkState AsSelectionMarkState() { throw null; }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSignatureType AsSignatureType() { throw null; }
        public string AsString() { throw null; }
        public System.TimeSpan AsTime() { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentFontStyle : System.IEquatable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontStyle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentFontStyle(string value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontStyle Italic { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontStyle Normal { get { throw null; } }
        public bool Equals(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontStyle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontStyle left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontStyle right) { throw null; }
        public static implicit operator Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontStyle (string value) { throw null; }
        public static bool operator !=(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontStyle left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontStyle right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentFontWeight : System.IEquatable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontWeight>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentFontWeight(string value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontWeight Bold { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontWeight Normal { get { throw null; } }
        public bool Equals(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontWeight other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontWeight left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontWeight right) { throw null; }
        public static implicit operator Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontWeight (string value) { throw null; }
        public static bool operator !=(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontWeight left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontWeight right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentFormula
    {
        internal DocumentFormula() { }
        public System.Collections.Generic.IReadOnlyList<System.Drawing.PointF> BoundingPolygon { get { throw null; } }
        public float Confidence { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFormulaKind Kind { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan Span { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentFormulaKind : System.IEquatable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFormulaKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentFormulaKind(string value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFormulaKind Display { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFormulaKind Inline { get { throw null; } }
        public bool Equals(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFormulaKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFormulaKind left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFormulaKind right) { throw null; }
        public static implicit operator Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFormulaKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFormulaKind left, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFormulaKind right) { throw null; }
        public override string ToString() { throw null; }
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
        public string Locale { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class DocumentLine
    {
        internal DocumentLine() { }
        public System.Collections.Generic.IReadOnlyList<System.Drawing.PointF> BoundingPolygon { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> Spans { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentWord> GetWords() { throw null; }
    }
    public partial class DocumentModelAdministrationClient
    {
        protected DocumentModelAdministrationClient() { }
        public DocumentModelAdministrationClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public DocumentModelAdministrationClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClientOptions options) { }
        public DocumentModelAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DocumentModelAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClientOptions options) { }
        public virtual Azure.AI.FormRecognizer.DocumentAnalysis.BuildDocumentClassifierOperation BuildDocumentClassifier(Azure.WaitUntil waitUntil, System.Collections.Generic.IDictionary<string, Azure.AI.FormRecognizer.DocumentAnalysis.ClassifierDocumentTypeDetails> documentTypes, string classifierId = null, string description = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.DocumentAnalysis.BuildDocumentClassifierOperation> BuildDocumentClassifierAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IDictionary<string, Azure.AI.FormRecognizer.DocumentAnalysis.ClassifierDocumentTypeDetails> documentTypes, string classifierId = null, string description = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.DocumentAnalysis.BuildDocumentModelOperation BuildDocumentModel(Azure.WaitUntil waitUntil, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentContentSource trainingDataSource, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBuildMode buildMode, string modelId = null, Azure.AI.FormRecognizer.DocumentAnalysis.BuildDocumentModelOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.DocumentAnalysis.BuildDocumentModelOperation BuildDocumentModel(Azure.WaitUntil waitUntil, System.Uri blobContainerUri, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBuildMode buildMode, string modelId = null, string prefix = null, Azure.AI.FormRecognizer.DocumentAnalysis.BuildDocumentModelOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.DocumentAnalysis.BuildDocumentModelOperation> BuildDocumentModelAsync(Azure.WaitUntil waitUntil, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentContentSource trainingDataSource, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBuildMode buildMode, string modelId = null, Azure.AI.FormRecognizer.DocumentAnalysis.BuildDocumentModelOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.DocumentAnalysis.BuildDocumentModelOperation> BuildDocumentModelAsync(Azure.WaitUntil waitUntil, System.Uri blobContainerUri, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBuildMode buildMode, string modelId = null, string prefix = null, Azure.AI.FormRecognizer.DocumentAnalysis.BuildDocumentModelOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.DocumentAnalysis.ComposeDocumentModelOperation ComposeDocumentModel(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> componentModelIds, string modelId = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.DocumentAnalysis.ComposeDocumentModelOperation> ComposeDocumentModelAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> componentModelIds, string modelId = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.FormRecognizer.DocumentAnalysis.CopyDocumentModelToOperation CopyDocumentModelTo(Azure.WaitUntil waitUntil, string modelId, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelCopyAuthorization target, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.FormRecognizer.DocumentAnalysis.CopyDocumentModelToOperation> CopyDocumentModelToAsync(Azure.WaitUntil waitUntil, string modelId, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelCopyAuthorization target, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteDocumentClassifier(string classifierId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDocumentClassifierAsync(string classifierId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteDocumentModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDocumentModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelCopyAuthorization> GetCopyAuthorization(string modelId = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelCopyAuthorization>> GetCopyAuthorizationAsync(string modelId = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentClassifierDetails> GetDocumentClassifier(string classifierId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentClassifierDetails>> GetDocumentClassifierAsync(string classifierId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentClassifierDetails> GetDocumentClassifiers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentClassifierDetails> GetDocumentClassifiersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails> GetDocumentModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails>> GetDocumentModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelSummary> GetDocumentModels(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelSummary> GetDocumentModelsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.OperationDetails> GetOperation(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.OperationDetails>> GetOperationAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.FormRecognizer.DocumentAnalysis.OperationSummary> GetOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.FormRecognizer.DocumentAnalysis.OperationSummary> GetOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.ResourceDetails> GetResourceDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.FormRecognizer.DocumentAnalysis.ResourceDetails>> GetResourceDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DocumentModelBuildOperationDetails : Azure.AI.FormRecognizer.DocumentAnalysis.OperationDetails
    {
        internal DocumentModelBuildOperationDetails() { }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails Result { get { throw null; } }
    }
    public partial class DocumentModelComposeOperationDetails : Azure.AI.FormRecognizer.DocumentAnalysis.OperationDetails
    {
        internal DocumentModelComposeOperationDetails() { }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails Result { get { throw null; } }
    }
    public partial class DocumentModelCopyAuthorization
    {
        public DocumentModelCopyAuthorization(string targetResourceId, string targetResourceRegion, string targetModelId, System.Uri targetModelLocation, string accessToken, System.DateTimeOffset expiresOn) { }
        public string AccessToken { get { throw null; } }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public string TargetModelId { get { throw null; } }
        public System.Uri TargetModelLocation { get { throw null; } }
        public string TargetResourceId { get { throw null; } }
        public string TargetResourceRegion { get { throw null; } }
    }
    public partial class DocumentModelCopyToOperationDetails : Azure.AI.FormRecognizer.DocumentAnalysis.OperationDetails
    {
        internal DocumentModelCopyToOperationDetails() { }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentModelDetails Result { get { throw null; } }
    }
    public partial class DocumentModelDetails
    {
        internal DocumentModelDetails() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTypeDetails> DocumentTypes { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string ModelId { get { throw null; } }
        public string ServiceVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DocumentModelSummary
    {
        internal DocumentModelSummary() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string ModelId { get { throw null; } }
        public string ServiceVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentOperationKind : System.IEquatable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentOperationKind(string value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind DocumentClassifierBuild { get { throw null; } }
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
        public float? Angle { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBarcode> Barcodes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFormula> Formulas { get { throw null; } }
        public float? Height { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentLine> Lines { get { throw null; } }
        public int PageNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSelectionMark> SelectionMarks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> Spans { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentPageLengthUnit? Unit { get { throw null; } }
        public float? Width { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentWord> Words { get { throw null; } }
    }
    public enum DocumentPageLengthUnit
    {
        Pixel = 0,
        Inch = 1,
    }
    public partial class DocumentParagraph
    {
        internal DocumentParagraph() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.BoundingRegion> BoundingRegions { get { throw null; } }
        public string Content { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.ParagraphRole? Role { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan> Spans { get { throw null; } }
    }
    public partial class DocumentSelectionMark
    {
        internal DocumentSelectionMark() { }
        public System.Collections.Generic.IReadOnlyList<System.Drawing.PointF> BoundingPolygon { get { throw null; } }
        public float Confidence { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan Span { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSelectionMarkState State { get { throw null; } }
    }
    public enum DocumentSelectionMarkState
    {
        Unselected = 0,
        Selected = 1,
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentSpan : System.IEquatable<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan>
    {
        private readonly int _dummyPrimitive;
        public int Index { get { throw null; } }
        public int Length { get { throw null; } }
        public bool Equals(Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentStyle
    {
        internal DocumentStyle() { }
        public string BackgroundColor { get { throw null; } }
        public string Color { get { throw null; } }
        public float Confidence { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontStyle? FontStyle { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFontWeight? FontWeight { get { throw null; } }
        public bool? IsHandwritten { get { throw null; } }
        public string SimilarFontFamily { get { throw null; } }
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
        public int ColumnSpan { get { throw null; } }
        public string Content { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentTableCellKind Kind { get { throw null; } }
        public int RowIndex { get { throw null; } }
        public int RowSpan { get { throw null; } }
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
    public partial class DocumentTypeDetails
    {
        internal DocumentTypeDetails() { }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentBuildMode? BuildMode { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, float> FieldConfidence { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldSchema> FieldSchema { get { throw null; } }
    }
    public partial class DocumentWord
    {
        internal DocumentWord() { }
        public System.Collections.Generic.IReadOnlyList<System.Drawing.PointF> BoundingPolygon { get { throw null; } }
        public float Confidence { get { throw null; } }
        public string Content { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentSpan Span { get { throw null; } }
    }
    public partial class OperationDetails
    {
        internal OperationDetails() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind Kind { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public string OperationId { get { throw null; } }
        public int? PercentCompleted { get { throw null; } }
        public System.Uri ResourceLocation { get { throw null; } }
        public string ServiceVersion { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class OperationSummary
    {
        internal OperationSummary() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationKind Kind { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public string OperationId { get { throw null; } }
        public int? PercentCompleted { get { throw null; } }
        public System.Uri ResourceLocation { get { throw null; } }
        public string ServiceVersion { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.DocumentOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParagraphRole : System.IEquatable<Azure.AI.FormRecognizer.DocumentAnalysis.ParagraphRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParagraphRole(string value) { throw null; }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.ParagraphRole Footnote { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.ParagraphRole FormulaBlock { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.ParagraphRole PageFooter { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.ParagraphRole PageHeader { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.ParagraphRole PageNumber { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.ParagraphRole SectionHeading { get { throw null; } }
        public static Azure.AI.FormRecognizer.DocumentAnalysis.ParagraphRole Title { get { throw null; } }
        public bool Equals(Azure.AI.FormRecognizer.DocumentAnalysis.ParagraphRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.FormRecognizer.DocumentAnalysis.ParagraphRole left, Azure.AI.FormRecognizer.DocumentAnalysis.ParagraphRole right) { throw null; }
        public static implicit operator Azure.AI.FormRecognizer.DocumentAnalysis.ParagraphRole (string value) { throw null; }
        public static bool operator !=(Azure.AI.FormRecognizer.DocumentAnalysis.ParagraphRole left, Azure.AI.FormRecognizer.DocumentAnalysis.ParagraphRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceDetails
    {
        internal ResourceDetails() { }
        public int CustomDocumentModelCount { get { throw null; } }
        public int CustomDocumentModelLimit { get { throw null; } }
        public Azure.AI.FormRecognizer.DocumentAnalysis.ResourceQuotaDetails NeuralDocumentModelQuota { get { throw null; } }
    }
    public partial class ResourceQuotaDetails
    {
        internal ResourceQuotaDetails() { }
        public int Quota { get { throw null; } }
        public System.DateTimeOffset QuotaResetsOn { get { throw null; } }
        public int Used { get { throw null; } }
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
    public static partial class DocumentAnalysisClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClient, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClientOptions> AddDocumentAnalysisClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClient, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClientOptions> AddDocumentAnalysisClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClient, Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClientOptions> AddDocumentAnalysisClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
    public static partial class FormRecognizerClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.FormRecognizer.FormRecognizerClient, Azure.AI.FormRecognizer.FormRecognizerClientOptions> AddFormRecognizerClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.FormRecognizer.FormRecognizerClient, Azure.AI.FormRecognizer.FormRecognizerClientOptions> AddFormRecognizerClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.FormRecognizer.FormRecognizerClient, Azure.AI.FormRecognizer.FormRecognizerClientOptions> AddFormRecognizerClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
