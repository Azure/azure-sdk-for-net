namespace Azure.Health.Insights.CancerProfiling
{
    public partial class CancerProfilingClient
    {
        protected CancerProfilingClient() { }
        public CancerProfilingClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public CancerProfilingClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Health.Insights.CancerProfiling.CancerProfilingClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> InferCancerProfile(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string repeatabilityRequestId = null, System.DateTimeOffset? repeatabilityFirstSent = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.Health.Insights.CancerProfiling.OncoPhenotypeResult> InferCancerProfile(Azure.WaitUntil waitUntil, Azure.Health.Insights.CancerProfiling.OncoPhenotypeData oncoPhenotypeData, string repeatabilityRequestId = null, System.DateTimeOffset? repeatabilityFirstSent = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> InferCancerProfileAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string repeatabilityRequestId = null, System.DateTimeOffset? repeatabilityFirstSent = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.Health.Insights.CancerProfiling.OncoPhenotypeResult>> InferCancerProfileAsync(Azure.WaitUntil waitUntil, Azure.Health.Insights.CancerProfiling.OncoPhenotypeData oncoPhenotypeData, string repeatabilityRequestId = null, System.DateTimeOffset? repeatabilityFirstSent = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CancerProfilingClientOptions : Azure.Core.ClientOptions
    {
        public CancerProfilingClientOptions(Azure.Health.Insights.CancerProfiling.CancerProfilingClientOptions.ServiceVersion version = Azure.Health.Insights.CancerProfiling.CancerProfilingClientOptions.ServiceVersion.V2023_03_01_Preview) { }
        public enum ServiceVersion
        {
            V2023_03_01_Preview = 1,
        }
    }
    public partial class ClinicalCodedElement
    {
        public ClinicalCodedElement(string system, string code) { }
        public string Code { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string System { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClinicalDocumentType : System.IEquatable<Azure.Health.Insights.CancerProfiling.ClinicalDocumentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClinicalDocumentType(string value) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.ClinicalDocumentType Consultation { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.ClinicalDocumentType DischargeSummary { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.ClinicalDocumentType HistoryAndPhysical { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.ClinicalDocumentType Imaging { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.ClinicalDocumentType Laboratory { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.ClinicalDocumentType Pathology { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.ClinicalDocumentType Procedure { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.ClinicalDocumentType Progress { get { throw null; } }
        public bool Equals(Azure.Health.Insights.CancerProfiling.ClinicalDocumentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.CancerProfiling.ClinicalDocumentType left, Azure.Health.Insights.CancerProfiling.ClinicalDocumentType right) { throw null; }
        public static implicit operator Azure.Health.Insights.CancerProfiling.ClinicalDocumentType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.CancerProfiling.ClinicalDocumentType left, Azure.Health.Insights.CancerProfiling.ClinicalDocumentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClinicalNoteEvidence
    {
        internal ClinicalNoteEvidence() { }
        public string Id { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class DocumentContent
    {
        public DocumentContent(Azure.Health.Insights.CancerProfiling.DocumentContentSourceType sourceType, string value) { }
        public Azure.Health.Insights.CancerProfiling.DocumentContentSourceType SourceType { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentContentSourceType : System.IEquatable<Azure.Health.Insights.CancerProfiling.DocumentContentSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentContentSourceType(string value) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.DocumentContentSourceType Inline { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.DocumentContentSourceType Reference { get { throw null; } }
        public bool Equals(Azure.Health.Insights.CancerProfiling.DocumentContentSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.CancerProfiling.DocumentContentSourceType left, Azure.Health.Insights.CancerProfiling.DocumentContentSourceType right) { throw null; }
        public static implicit operator Azure.Health.Insights.CancerProfiling.DocumentContentSourceType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.CancerProfiling.DocumentContentSourceType left, Azure.Health.Insights.CancerProfiling.DocumentContentSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentType : System.IEquatable<Azure.Health.Insights.CancerProfiling.DocumentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentType(string value) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.DocumentType Dicom { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.DocumentType FhirBundle { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.DocumentType GenomicSequencing { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.DocumentType Note { get { throw null; } }
        public bool Equals(Azure.Health.Insights.CancerProfiling.DocumentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.CancerProfiling.DocumentType left, Azure.Health.Insights.CancerProfiling.DocumentType right) { throw null; }
        public static implicit operator Azure.Health.Insights.CancerProfiling.DocumentType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.CancerProfiling.DocumentType left, Azure.Health.Insights.CancerProfiling.DocumentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InferenceEvidence
    {
        internal InferenceEvidence() { }
        public float? Importance { get { throw null; } }
        public Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence PatientDataEvidence { get { throw null; } }
        public Azure.Health.Insights.CancerProfiling.ClinicalCodedElement PatientInfoEvidence { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.Health.Insights.CancerProfiling.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.JobStatus Failed { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.JobStatus NotStarted { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.JobStatus PartiallyCompleted { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.JobStatus Running { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.JobStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.Health.Insights.CancerProfiling.JobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.CancerProfiling.JobStatus left, Azure.Health.Insights.CancerProfiling.JobStatus right) { throw null; }
        public static implicit operator Azure.Health.Insights.CancerProfiling.JobStatus (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.CancerProfiling.JobStatus left, Azure.Health.Insights.CancerProfiling.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OncoPhenotypeData
    {
        public OncoPhenotypeData(System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.PatientRecord> patients) { }
        public Azure.Health.Insights.CancerProfiling.OncoPhenotypeModelConfiguration Configuration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.CancerProfiling.PatientRecord> Patients { get { throw null; } }
    }
    public partial class OncoPhenotypeInference
    {
        internal OncoPhenotypeInference() { }
        public string CaseId { get { throw null; } }
        public float? ConfidenceScore { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.CancerProfiling.InferenceEvidence> Evidence { get { throw null; } }
        public Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType Type { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OncoPhenotypeInferenceType : System.IEquatable<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OncoPhenotypeInferenceType(string value) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType ClinicalStageM { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType ClinicalStageN { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType ClinicalStageT { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType Histology { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType PathologicStageM { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType PathologicStageN { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType PathologicStageT { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType TumorSite { get { throw null; } }
        public bool Equals(Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType left, Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType right) { throw null; }
        public static implicit operator Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType left, Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OncoPhenotypeModelConfiguration
    {
        public OncoPhenotypeModelConfiguration() { }
        public bool? CheckForCancerCase { get { throw null; } set { } }
        public bool? IncludeEvidence { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType> InferenceTypes { get { throw null; } }
        public bool? Verbose { get { throw null; } set { } }
    }
    public partial class OncoPhenotypePatientResult
    {
        internal OncoPhenotypePatientResult() { }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference> Inferences { get { throw null; } }
    }
    public partial class OncoPhenotypeResult
    {
        internal OncoPhenotypeResult() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdateDateTime { get { throw null; } }
        public Azure.Health.Insights.CancerProfiling.OncoPhenotypeResults Results { get { throw null; } }
        public Azure.Health.Insights.CancerProfiling.JobStatus Status { get { throw null; } }
    }
    public partial class OncoPhenotypeResults
    {
        internal OncoPhenotypeResults() { }
        public string ModelVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult> Patients { get { throw null; } }
    }
    public partial class PatientDocument
    {
        public PatientDocument(Azure.Health.Insights.CancerProfiling.DocumentType type, string id, Azure.Health.Insights.CancerProfiling.DocumentContent content) { }
        public Azure.Health.Insights.CancerProfiling.ClinicalDocumentType? ClinicalType { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.DocumentContent Content { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.DocumentType Type { get { throw null; } }
    }
    public partial class PatientInfo
    {
        public PatientInfo() { }
        public System.DateTimeOffset? BirthDate { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.CancerProfiling.ClinicalCodedElement> ClinicalInfo { get { throw null; } }
        public Azure.Health.Insights.CancerProfiling.PatientInfoSex? Sex { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PatientInfoSex : System.IEquatable<Azure.Health.Insights.CancerProfiling.PatientInfoSex>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatientInfoSex(string value) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.PatientInfoSex Female { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.PatientInfoSex Male { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.PatientInfoSex Unspecified { get { throw null; } }
        public bool Equals(Azure.Health.Insights.CancerProfiling.PatientInfoSex other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.CancerProfiling.PatientInfoSex left, Azure.Health.Insights.CancerProfiling.PatientInfoSex right) { throw null; }
        public static implicit operator Azure.Health.Insights.CancerProfiling.PatientInfoSex (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.CancerProfiling.PatientInfoSex left, Azure.Health.Insights.CancerProfiling.PatientInfoSex right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PatientRecord
    {
        public PatientRecord(string id) { }
        public System.Collections.Generic.IList<Azure.Health.Insights.CancerProfiling.PatientDocument> Data { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Health.Insights.CancerProfiling.PatientInfo Info { get { throw null; } set { } }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AzureHealthInsightsClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Insights.CancerProfiling.CancerProfilingClient, Azure.Health.Insights.CancerProfiling.CancerProfilingClientOptions> AddCancerProfilingClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Insights.CancerProfiling.CancerProfilingClient, Azure.Health.Insights.CancerProfiling.CancerProfilingClientOptions> AddCancerProfilingClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
