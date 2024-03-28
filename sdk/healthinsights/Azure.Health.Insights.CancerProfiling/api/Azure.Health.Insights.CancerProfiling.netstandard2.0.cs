namespace Azure.Health.Insights.CancerProfiling
{
    public partial class CancerProfilingClient
    {
        protected CancerProfilingClient() { }
        public CancerProfilingClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public CancerProfilingClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Health.Insights.CancerProfiling.CancerProfilingClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> InferCancerProfile(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceResult> InferCancerProfile(Azure.WaitUntil waitUntil, Azure.Health.Insights.CancerProfiling.OncoPhenotypeData oncoPhenotypeData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> InferCancerProfileAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceResult>> InferCancerProfileAsync(Azure.WaitUntil waitUntil, Azure.Health.Insights.CancerProfiling.OncoPhenotypeData oncoPhenotypeData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CancerProfilingClientOptions : Azure.Core.ClientOptions
    {
        public CancerProfilingClientOptions(Azure.Health.Insights.CancerProfiling.CancerProfilingClientOptions.ServiceVersion version = Azure.Health.Insights.CancerProfiling.CancerProfilingClientOptions.ServiceVersion.V2023_09_01_Preview) { }
        public enum ServiceVersion
        {
            V2023_09_01_Preview = 1,
        }
    }
    public partial class ClinicalCodedElement : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.ClinicalCodedElement>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.ClinicalCodedElement>
    {
        internal ClinicalCodedElement() { }
        public string Code { get { throw null; } }
        public string Name { get { throw null; } }
        public string System { get { throw null; } }
        public string Value { get { throw null; } }
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
        public static Azure.Health.Insights.CancerProfiling.ClinicalDocumentType Laboratory { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.ClinicalDocumentType PathologyReport { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.ClinicalDocumentType Procedure { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.ClinicalDocumentType Progress { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.ClinicalDocumentType RadiologyReport { get { throw null; } }
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
        Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentAdministrativeMetadata : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.DocumentAdministrativeMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.DocumentAdministrativeMetadata>
    {
        public DocumentAdministrativeMetadata() { }
        public string EncounterId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.CancerProfiling.FhirR4Extendible> OrderedProcedures { get { throw null; } }
        Azure.Health.Insights.CancerProfiling.DocumentAdministrativeMetadata System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.DocumentAdministrativeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.DocumentAdministrativeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.DocumentAdministrativeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.DocumentAdministrativeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.DocumentAdministrativeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.DocumentAdministrativeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentAuthor : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.DocumentAuthor>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.DocumentAuthor>
    {
        public DocumentAuthor() { }
        public string FullName { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        Azure.Health.Insights.CancerProfiling.DocumentAuthor System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.DocumentAuthor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.DocumentAuthor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.DocumentAuthor System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.DocumentAuthor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.DocumentAuthor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.DocumentAuthor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentContent : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.DocumentContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.DocumentContent>
    {
        public DocumentContent(Azure.Health.Insights.CancerProfiling.DocumentContentSourceType sourceType, string value) { }
        public Azure.Health.Insights.CancerProfiling.DocumentContentSourceType SourceType { get { throw null; } }
        public string Value { get { throw null; } }
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
    public partial class Encounter : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.Encounter>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.Encounter>
    {
        public Encounter(string id) { }
        public Azure.Health.Insights.CancerProfiling.EncounterClass? Class { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public Azure.Health.Insights.CancerProfiling.TimePeriod Period { get { throw null; } set { } }
        Azure.Health.Insights.CancerProfiling.Encounter System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.Encounter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.Encounter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.Encounter System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.Encounter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.Encounter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.Encounter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncounterClass : System.IEquatable<Azure.Health.Insights.CancerProfiling.EncounterClass>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncounterClass(string value) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.EncounterClass Ambulatory { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.EncounterClass Emergency { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.EncounterClass HealthHome { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.EncounterClass InPatient { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.EncounterClass Observation { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.EncounterClass Virtual { get { throw null; } }
        public bool Equals(Azure.Health.Insights.CancerProfiling.EncounterClass other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.CancerProfiling.EncounterClass left, Azure.Health.Insights.CancerProfiling.EncounterClass right) { throw null; }
        public static implicit operator Azure.Health.Insights.CancerProfiling.EncounterClass (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.CancerProfiling.EncounterClass left, Azure.Health.Insights.CancerProfiling.EncounterClass right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FhirR4CodeableConcept : Azure.Health.Insights.CancerProfiling.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4CodeableConcept>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4CodeableConcept>
    {
        public FhirR4CodeableConcept() { }
        public System.Collections.Generic.IList<Azure.Health.Insights.CancerProfiling.FhirR4Coding> Coding { get { throw null; } }
        public string Text { get { throw null; } set { } }
        Azure.Health.Insights.CancerProfiling.FhirR4CodeableConcept System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4CodeableConcept>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4CodeableConcept>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.FhirR4CodeableConcept System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4CodeableConcept>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4CodeableConcept>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4CodeableConcept>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Coding : Azure.Health.Insights.CancerProfiling.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Coding>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Coding>
    {
        public FhirR4Coding() { }
        public string Code { get { throw null; } set { } }
        public string Display { get { throw null; } set { } }
        public string System { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.Health.Insights.CancerProfiling.FhirR4Coding System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Coding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Coding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.FhirR4Coding System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Coding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Coding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Coding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Element : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Element>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Element>
    {
        internal FhirR4Element() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.CancerProfiling.FhirR4Extension> Extension { get { throw null; } }
        public string Id { get { throw null; } }
        Azure.Health.Insights.CancerProfiling.FhirR4Element System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Element>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Element>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.FhirR4Element System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Element>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Element>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Element>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Extendible : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Extendible>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Extendible>
    {
        public FhirR4Extendible() { }
        public Azure.Health.Insights.CancerProfiling.FhirR4CodeableConcept Code { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.CancerProfiling.FhirR4Extension> Extension { get { throw null; } }
        Azure.Health.Insights.CancerProfiling.FhirR4Extendible System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Extendible>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Extendible>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.FhirR4Extendible System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Extendible>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Extendible>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Extendible>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Extension : Azure.Health.Insights.CancerProfiling.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Extension>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Extension>
    {
        public FhirR4Extension(string url) { }
        public string Url { get { throw null; } }
        public bool? ValueBoolean { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.FhirR4CodeableConcept ValueCodeableConcept { get { throw null; } set { } }
        public string ValueDateTime { get { throw null; } set { } }
        public int? ValueInteger { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.FhirR4Period ValuePeriod { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.FhirR4Quantity ValueQuantity { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.FhirR4Range ValueRange { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.FhirR4Ratio ValueRatio { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.FhirR4Reference ValueReference { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.FhirR4SampledData ValueSampledData { get { throw null; } set { } }
        public string ValueString { get { throw null; } set { } }
        public System.TimeSpan? ValueTime { get { throw null; } set { } }
        Azure.Health.Insights.CancerProfiling.FhirR4Extension System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Extension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Extension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.FhirR4Extension System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Extension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Extension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Extension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Identifier : Azure.Health.Insights.CancerProfiling.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Identifier>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Identifier>
    {
        public FhirR4Identifier() { }
        public Azure.Health.Insights.CancerProfiling.FhirR4Reference Assigner { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.FhirR4Period Period { get { throw null; } set { } }
        public string System { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.FhirR4CodeableConcept Type { get { throw null; } set { } }
        public string Use { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.Health.Insights.CancerProfiling.FhirR4Identifier System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Identifier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Identifier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.FhirR4Identifier System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Identifier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Identifier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Identifier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Meta : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Meta>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Meta>
    {
        public FhirR4Meta() { }
        public string LastUpdated { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Profile { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.CancerProfiling.FhirR4Coding> Security { get { throw null; } }
        public string Source { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.CancerProfiling.FhirR4Coding> Tag { get { throw null; } }
        public string VersionId { get { throw null; } set { } }
        Azure.Health.Insights.CancerProfiling.FhirR4Meta System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Meta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Meta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.FhirR4Meta System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Meta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Meta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Meta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Period : Azure.Health.Insights.CancerProfiling.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Period>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Period>
    {
        public FhirR4Period() { }
        public string End { get { throw null; } set { } }
        public string Start { get { throw null; } set { } }
        Azure.Health.Insights.CancerProfiling.FhirR4Period System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Period>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Period>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.FhirR4Period System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Period>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Period>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Period>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Quantity : Azure.Health.Insights.CancerProfiling.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Quantity>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Quantity>
    {
        public FhirR4Quantity() { }
        public string Code { get { throw null; } set { } }
        public string Comparator { get { throw null; } set { } }
        public string System { get { throw null; } set { } }
        public string Unit { get { throw null; } set { } }
        public double? Value { get { throw null; } set { } }
        Azure.Health.Insights.CancerProfiling.FhirR4Quantity System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Quantity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Quantity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.FhirR4Quantity System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Quantity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Quantity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Quantity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Range : Azure.Health.Insights.CancerProfiling.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Range>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Range>
    {
        public FhirR4Range() { }
        public Azure.Health.Insights.CancerProfiling.FhirR4Quantity High { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.FhirR4Quantity Low { get { throw null; } set { } }
        Azure.Health.Insights.CancerProfiling.FhirR4Range System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Range>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Range>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.FhirR4Range System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Range>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Range>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Range>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Ratio : Azure.Health.Insights.CancerProfiling.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Ratio>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Ratio>
    {
        public FhirR4Ratio() { }
        public Azure.Health.Insights.CancerProfiling.FhirR4Quantity Denominator { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.FhirR4Quantity Numerator { get { throw null; } set { } }
        Azure.Health.Insights.CancerProfiling.FhirR4Ratio System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Ratio>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Ratio>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.FhirR4Ratio System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Ratio>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Ratio>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Ratio>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Reference : Azure.Health.Insights.CancerProfiling.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Reference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Reference>
    {
        public FhirR4Reference() { }
        public string Display { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.FhirR4Identifier Identifier { get { throw null; } set { } }
        public string Reference { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        Azure.Health.Insights.CancerProfiling.FhirR4Reference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Reference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Reference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.FhirR4Reference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Reference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Reference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Reference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Resource : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Resource>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Resource>
    {
        public FhirR4Resource(string resourceType) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public string ImplicitRules { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.FhirR4Meta Meta { get { throw null; } set { } }
        public string ResourceType { get { throw null; } }
        Azure.Health.Insights.CancerProfiling.FhirR4Resource System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Resource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4Resource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.FhirR4Resource System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Resource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Resource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4Resource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4SampledData : Azure.Health.Insights.CancerProfiling.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4SampledData>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4SampledData>
    {
        public FhirR4SampledData(Azure.Health.Insights.CancerProfiling.FhirR4Quantity origin, double period, int dimensions) { }
        public string Data { get { throw null; } set { } }
        public int Dimensions { get { throw null; } }
        public double? Factor { get { throw null; } set { } }
        public double? LowerLimit { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.FhirR4Quantity Origin { get { throw null; } }
        public double Period { get { throw null; } }
        public double? UpperLimit { get { throw null; } set { } }
        Azure.Health.Insights.CancerProfiling.FhirR4SampledData System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4SampledData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.FhirR4SampledData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.FhirR4SampledData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4SampledData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4SampledData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.FhirR4SampledData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class HealthInsightsCancerProfilingModelFactory
    {
        public static Azure.Health.Insights.CancerProfiling.ClinicalCodedElement ClinicalCodedElement(string system = null, string code = null, string name = null, string value = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence ClinicalNoteEvidence(string id = null, string text = null, int offset = 0, int length = 0) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.Encounter Encounter(string id = null, Azure.Health.Insights.CancerProfiling.TimePeriod period = null, Azure.Health.Insights.CancerProfiling.EncounterClass? @class = default(Azure.Health.Insights.CancerProfiling.EncounterClass?)) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.FhirR4CodeableConcept FhirR4CodeableConcept(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.FhirR4Extension> extension = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.FhirR4Coding> coding = null, string text = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.FhirR4Coding FhirR4Coding(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.FhirR4Extension> extension = null, string system = null, string version = null, string code = null, string display = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.FhirR4Element FhirR4Element(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.FhirR4Extension> extension = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.FhirR4Extension FhirR4Extension(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.FhirR4Extension> extension = null, string url = null, Azure.Health.Insights.CancerProfiling.FhirR4Quantity valueQuantity = null, Azure.Health.Insights.CancerProfiling.FhirR4CodeableConcept valueCodeableConcept = null, string valueString = null, bool? valueBoolean = default(bool?), int? valueInteger = default(int?), Azure.Health.Insights.CancerProfiling.FhirR4Range valueRange = null, Azure.Health.Insights.CancerProfiling.FhirR4Ratio valueRatio = null, Azure.Health.Insights.CancerProfiling.FhirR4SampledData valueSampledData = null, System.TimeSpan? valueTime = default(System.TimeSpan?), string valueDateTime = null, Azure.Health.Insights.CancerProfiling.FhirR4Period valuePeriod = null, Azure.Health.Insights.CancerProfiling.FhirR4Reference valueReference = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.FhirR4Identifier FhirR4Identifier(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.FhirR4Extension> extension = null, string use = null, Azure.Health.Insights.CancerProfiling.FhirR4CodeableConcept type = null, string system = null, string value = null, Azure.Health.Insights.CancerProfiling.FhirR4Period period = null, Azure.Health.Insights.CancerProfiling.FhirR4Reference assigner = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.FhirR4Period FhirR4Period(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.FhirR4Extension> extension = null, string start = null, string end = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.FhirR4Quantity FhirR4Quantity(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.FhirR4Extension> extension = null, double? value = default(double?), string comparator = null, string unit = null, string system = null, string code = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.FhirR4Range FhirR4Range(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.FhirR4Extension> extension = null, Azure.Health.Insights.CancerProfiling.FhirR4Quantity low = null, Azure.Health.Insights.CancerProfiling.FhirR4Quantity high = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.FhirR4Ratio FhirR4Ratio(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.FhirR4Extension> extension = null, Azure.Health.Insights.CancerProfiling.FhirR4Quantity numerator = null, Azure.Health.Insights.CancerProfiling.FhirR4Quantity denominator = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.FhirR4Reference FhirR4Reference(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.FhirR4Extension> extension = null, string reference = null, string type = null, Azure.Health.Insights.CancerProfiling.FhirR4Identifier identifier = null, string display = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.FhirR4Resource FhirR4Resource(string resourceType = null, string id = null, Azure.Health.Insights.CancerProfiling.FhirR4Meta meta = null, string implicitRules = null, string language = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.FhirR4SampledData FhirR4SampledData(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.FhirR4Extension> extension = null, Azure.Health.Insights.CancerProfiling.FhirR4Quantity origin = null, double period = 0, double? factor = default(double?), double? lowerLimit = default(double?), double? upperLimit = default(double?), int dimensions = 0, string data = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.InferenceEvidence InferenceEvidence(Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence patientDataEvidence = null, Azure.Health.Insights.CancerProfiling.ClinicalCodedElement patientInfoEvidence = null, float? importance = default(float?)) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference OncoPhenotypeInference(Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType type = default(Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType), string value = null, string description = null, float? confidenceScore = default(float?), System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.InferenceEvidence> evidence = null, string caseId = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceResult OncoPhenotypeInferenceResult(System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult> patientResults = null, string modelVersion = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult OncoPhenotypePatientResult(string patientId = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference> inferences = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.PatientDocument PatientDocument(Azure.Health.Insights.CancerProfiling.DocumentType type = default(Azure.Health.Insights.CancerProfiling.DocumentType), Azure.Health.Insights.CancerProfiling.ClinicalDocumentType? clinicalType = default(Azure.Health.Insights.CancerProfiling.ClinicalDocumentType?), string id = null, string language = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.DocumentAuthor> authors = null, Azure.Health.Insights.CancerProfiling.SpecialtyType? specialtyType = default(Azure.Health.Insights.CancerProfiling.SpecialtyType?), Azure.Health.Insights.CancerProfiling.DocumentAdministrativeMetadata administrativeMetadata = null, Azure.Health.Insights.CancerProfiling.DocumentContent content = null) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.PatientRecord PatientRecord(string id = null, Azure.Health.Insights.CancerProfiling.PatientDetails info = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.Encounter> encounters = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.CancerProfiling.PatientDocument> patientDocuments = null) { throw null; }
    }
    public partial class InferenceEvidence : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.InferenceEvidence>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.InferenceEvidence>
    {
        internal InferenceEvidence() { }
        public float? Importance { get { throw null; } }
        public Azure.Health.Insights.CancerProfiling.ClinicalNoteEvidence PatientDataEvidence { get { throw null; } }
        public Azure.Health.Insights.CancerProfiling.ClinicalCodedElement PatientInfoEvidence { get { throw null; } }
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
        Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OncoPhenotypeInferenceResult : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceResult>
    {
        internal OncoPhenotypeInferenceResult() { }
        public string ModelVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult> PatientResults { get { throw null; } }
        Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceResult System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceResult System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Health.Insights.CancerProfiling.OncoPhenotypeInferenceType DiagnosisDate { get { throw null; } }
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
        Azure.Health.Insights.CancerProfiling.OncoPhenotypeModelConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeModelConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeModelConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.OncoPhenotypeModelConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeModelConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeModelConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypeModelConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OncoPhenotypePatientResult : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult>
    {
        internal OncoPhenotypePatientResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.CancerProfiling.OncoPhenotypeInference> Inferences { get { throw null; } }
        public string PatientId { get { throw null; } }
        Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.OncoPhenotypePatientResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatientDetails : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.PatientDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientDetails>
    {
        public PatientDetails() { }
        public System.DateTimeOffset? BirthDate { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.CancerProfiling.FhirR4Resource> ClinicalInfo { get { throw null; } }
        public Azure.Health.Insights.CancerProfiling.PatientSex? Sex { get { throw null; } set { } }
        Azure.Health.Insights.CancerProfiling.PatientDetails System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.PatientDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.PatientDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.PatientDetails System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatientDocument : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.PatientDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientDocument>
    {
        public PatientDocument(Azure.Health.Insights.CancerProfiling.DocumentType type, string id, Azure.Health.Insights.CancerProfiling.DocumentContent content) { }
        public Azure.Health.Insights.CancerProfiling.DocumentAdministrativeMetadata AdministrativeMetadata { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.CancerProfiling.DocumentAuthor> Authors { get { throw null; } }
        public Azure.Health.Insights.CancerProfiling.ClinicalDocumentType? ClinicalType { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.DocumentContent Content { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.SpecialtyType? SpecialtyType { get { throw null; } set { } }
        public Azure.Health.Insights.CancerProfiling.DocumentType Type { get { throw null; } }
        Azure.Health.Insights.CancerProfiling.PatientDocument System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.PatientDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.PatientDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.PatientDocument System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatientRecord : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.PatientRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientRecord>
    {
        public PatientRecord(string id) { }
        public System.Collections.Generic.IList<Azure.Health.Insights.CancerProfiling.Encounter> Encounters { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Health.Insights.CancerProfiling.PatientDetails Info { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.CancerProfiling.PatientDocument> PatientDocuments { get { throw null; } }
        Azure.Health.Insights.CancerProfiling.PatientRecord System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.PatientRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.PatientRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.PatientRecord System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.PatientRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PatientSex : System.IEquatable<Azure.Health.Insights.CancerProfiling.PatientSex>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatientSex(string value) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.PatientSex Female { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.PatientSex Male { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.PatientSex Unspecified { get { throw null; } }
        public bool Equals(Azure.Health.Insights.CancerProfiling.PatientSex other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.CancerProfiling.PatientSex left, Azure.Health.Insights.CancerProfiling.PatientSex right) { throw null; }
        public static implicit operator Azure.Health.Insights.CancerProfiling.PatientSex (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.CancerProfiling.PatientSex left, Azure.Health.Insights.CancerProfiling.PatientSex right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpecialtyType : System.IEquatable<Azure.Health.Insights.CancerProfiling.SpecialtyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpecialtyType(string value) { throw null; }
        public static Azure.Health.Insights.CancerProfiling.SpecialtyType Pathology { get { throw null; } }
        public static Azure.Health.Insights.CancerProfiling.SpecialtyType Radiology { get { throw null; } }
        public bool Equals(Azure.Health.Insights.CancerProfiling.SpecialtyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.CancerProfiling.SpecialtyType left, Azure.Health.Insights.CancerProfiling.SpecialtyType right) { throw null; }
        public static implicit operator Azure.Health.Insights.CancerProfiling.SpecialtyType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.CancerProfiling.SpecialtyType left, Azure.Health.Insights.CancerProfiling.SpecialtyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TimePeriod : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.TimePeriod>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.TimePeriod>
    {
        public TimePeriod() { }
        public System.DateTimeOffset? End { get { throw null; } set { } }
        public System.DateTimeOffset? Start { get { throw null; } set { } }
        Azure.Health.Insights.CancerProfiling.TimePeriod System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.TimePeriod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.CancerProfiling.TimePeriod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.CancerProfiling.TimePeriod System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.TimePeriod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.TimePeriod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.CancerProfiling.TimePeriod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class HealthInsightsCancerProfilingClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Insights.CancerProfiling.CancerProfilingClient, Azure.Health.Insights.CancerProfiling.CancerProfilingClientOptions> AddCancerProfilingClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Insights.CancerProfiling.CancerProfilingClient, Azure.Health.Insights.CancerProfiling.CancerProfilingClientOptions> AddCancerProfilingClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
