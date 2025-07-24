namespace Azure.Health.Insights.CancerProfiling
{
    public partial class AzureHealthInsightsCancerProfilingContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureHealthInsightsCancerProfilingContext() { }
        public static Azure.Health.Insights.CancerProfiling.AzureHealthInsightsCancerProfilingContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CancerProfilingClient
    {
        protected CancerProfilingClient() { }
        public CancerProfilingClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public CancerProfilingClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Health.Insights.CancerProfiling.CancerProfilingClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> InferCancerProfile(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.Health.Insights.CancerProfiling.OncoPhenotypeResults> InferCancerProfile(Azure.WaitUntil waitUntil, Azure.Health.Insights.CancerProfiling.OncoPhenotypeData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> InferCancerProfileAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.Health.Insights.CancerProfiling.OncoPhenotypeResults>> InferCancerProfileAsync(Azure.WaitUntil waitUntil, Azure.Health.Insights.CancerProfiling.OncoPhenotypeData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CancerProfilingClientOptions : Azure.Core.ClientOptions
    {
        public CancerProfilingClientOptions(Azure.Health.Insights.CancerProfiling.CancerProfilingClientOptions.ServiceVersion version = Azure.Health.Insights.CancerProfiling.CancerProfilingClientOptions.ServiceVersion.V2023_03_01_Preview) { }
        public enum ServiceVersion
        {
            V2023_03_01_Preview = 1,
        }
    }
    public partial class ClinicalCodedElement : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.ClinicalCodedElement>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.ClinicalCodedElement>
    {
        public ClinicalCodedElement(string system, string code) { }
        public string Code { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string System { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.ClinicalCodedElement System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.ClinicalCodedElement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.ClinicalCodedElement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.ClinicalCodedElement System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.ClinicalCodedElement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.ClinicalCodedElement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.ClinicalCodedElement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ClinicalNoteEvidence : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence>
    {
        internal ClinicalNoteEvidence() { }
        public string Id { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentContent : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.DocumentContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.DocumentContent>
    {
        public DocumentContent(Azure.Health.Insights.CancerProfiling.DocumentContentSourceType sourceType, string value) { }
        public Azure.Health.Insights.CancerProfiling.DocumentContentSourceType SourceType { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.DocumentContent System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.DocumentContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.DocumentContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.DocumentContent System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.DocumentContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.DocumentContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.DocumentContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public static partial class HealthInsightsCancerProfilingModelFactory
    {
        public static Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence ClinicalNoteEvidence(string id = null, string text = null, int offset = 0, int length = 0) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.InferenceEvidence InferenceEvidence(Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence patientDataEvidence = null, Azure.Health.Insights.CancerProfiling.ClinicalCodedElement patientInfoEvidence = null, float? importance = default(float?)) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference OncoPhenotypeInference(Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType type = default(Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType), string value = null, string description = null, float? confidenceScore = default(float?), System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.InferenceEvidence> evidence = null, string caseId = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult OncoPhenotypePatientResult(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference> inferences = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.OncoPhenotypeResults OncoPhenotypeResults(System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult> patients = null, string modelVersion = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.PatientDocument PatientDocument(Azure.Health.Insights.CancerProfiling.DocumentType type = default(Azure.Health.Insights.CancerProfiling.DocumentType), Azure.Health.Insights.CancerProfiling.ClinicalDocumentType? clinicalType = default(Azure.Health.Insights.CancerProfiling.ClinicalDocumentType?), string id = null, string language = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), Azure.Health.Insights.CancerProfiling.DocumentContent content = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.PatientRecord PatientRecord(string id = null, Azure.Health.Insights.CancerProfiling.PatientInfo info = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.PatientDocument> data = null) { throw null; }
    }
    public partial class InferenceEvidence : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.InferenceEvidence>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.InferenceEvidence>
    {
        internal InferenceEvidence() { }
        public float? Importance { get { throw null; } }
        public Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence PatientDataEvidence { get { throw null; } }
        public Azure.Health.Insights.CancerProfiling.ClinicalCodedElement PatientInfoEvidence { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.InferenceEvidence System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.InferenceEvidence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.InferenceEvidence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.InferenceEvidence System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.InferenceEvidence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.InferenceEvidence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.InferenceEvidence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OncoPhenotypeData : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeData>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeData>
    {
        public OncoPhenotypeData(System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.PatientRecord> patients) { }
        public Azure.Health.Insights.CancerProfiling.OncoPhenotypeModelConfiguration Configuration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.CancerProfiling.PatientRecord> Patients { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.OncoPhenotypeData System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.OncoPhenotypeData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OncoPhenotypeInference : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference>
    {
        internal OncoPhenotypeInference() { }
        public string CaseId { get { throw null; } }
        public float? ConfidenceScore { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.CancerProfiling.InferenceEvidence> Evidence { get { throw null; } }
        public Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType Type { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class OncoPhenotypeModelConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeModelConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeModelConfiguration>
    {
        public OncoPhenotypeModelConfiguration() { }
        public bool? CheckForCancerCase { get { throw null; } set { } }
        public bool? IncludeEvidence { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType> InferenceTypes { get { throw null; } }
        public bool? Verbose { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.OncoPhenotypeModelConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeModelConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeModelConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.OncoPhenotypeModelConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeModelConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeModelConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeModelConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OncoPhenotypePatientResult : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult>
    {
        internal OncoPhenotypePatientResult() { }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference> Inferences { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OncoPhenotypeResults : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeResults>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeResults>
    {
        internal OncoPhenotypeResults() { }
        public string ModelVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult> Patients { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.OncoPhenotypeResults System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.OncoPhenotypeResults System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatientDocument : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.PatientDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientDocument>
    {
        public PatientDocument(Azure.Health.Insights.CancerProfiling.DocumentType type, string id, Azure.Health.Insights.CancerProfiling.DocumentContent content) { }
        public Azure.Health.Insights.CancerProfiling.ClinicalDocumentType? ClinicalType { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.DocumentContent Content { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.DocumentType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.PatientDocument System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.PatientDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.PatientDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.PatientDocument System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatientInfo : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.PatientInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientInfo>
    {
        public PatientInfo() { }
        public System.DateTimeOffset? BirthDate { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.CancerProfiling.ClinicalCodedElement> ClinicalInfo { get { throw null; } }
        public Azure.Health.Insights.CancerProfiling.PatientInfoSex? Sex { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.PatientInfo System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.PatientInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.PatientInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.PatientInfo System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PatientRecord : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.PatientRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientRecord>
    {
        public PatientRecord(string id) { }
        public System.Collections.Generic.IList<Azure.Health.Insights.CancerProfiling.PatientDocument> Data { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Health.Insights.CancerProfiling.PatientInfo Info { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.PatientRecord System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.PatientRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.PatientRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.PatientRecord System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class HealthInsightsCancerProfilingClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Insights.CancerProfiling.CancerProfilingClient, Azure.Health.Insights.CancerProfiling.CancerProfilingClientOptions> AddCancerProfilingClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Insights.CancerProfiling.CancerProfilingClient, Azure.Health.Insights.CancerProfiling.CancerProfilingClientOptions> AddCancerProfilingClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
