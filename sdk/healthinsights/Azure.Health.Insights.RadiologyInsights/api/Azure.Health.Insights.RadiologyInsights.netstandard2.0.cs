namespace Azure.Health.Insights.RadiologyInsights
{
    public partial class AgeMismatchInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.AgeMismatchInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.AgeMismatchInference>
    {
        internal AgeMismatchInference() { }
        Azure.Health.Insights.RadiologyInsights.AgeMismatchInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.AgeMismatchInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.AgeMismatchInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.AgeMismatchInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.AgeMismatchInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.AgeMismatchInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.AgeMismatchInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClinicalDocumentType : System.IEquatable<Azure.Health.Insights.RadiologyInsights.ClinicalDocumentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClinicalDocumentType(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.ClinicalDocumentType Consultation { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ClinicalDocumentType DischargeSummary { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ClinicalDocumentType HistoryAndPhysical { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ClinicalDocumentType Laboratory { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ClinicalDocumentType PathologyReport { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ClinicalDocumentType Procedure { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ClinicalDocumentType Progress { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ClinicalDocumentType RadiologyReport { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.ClinicalDocumentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.ClinicalDocumentType left, Azure.Health.Insights.RadiologyInsights.ClinicalDocumentType right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.ClinicalDocumentType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.ClinicalDocumentType left, Azure.Health.Insights.RadiologyInsights.ClinicalDocumentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CompleteOrderDiscrepancyInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.CompleteOrderDiscrepancyInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.CompleteOrderDiscrepancyInference>
    {
        internal CompleteOrderDiscrepancyInference() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> MissingBodyPartMeasurements { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> MissingBodyParts { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept OrderType { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.CompleteOrderDiscrepancyInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.CompleteOrderDiscrepancyInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.CompleteOrderDiscrepancyInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.CompleteOrderDiscrepancyInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.CompleteOrderDiscrepancyInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.CompleteOrderDiscrepancyInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.CompleteOrderDiscrepancyInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CriticalResult : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.CriticalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.CriticalResult>
    {
        internal CriticalResult() { }
        public string Description { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Observation Finding { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.CriticalResult System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.CriticalResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.CriticalResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.CriticalResult System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.CriticalResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.CriticalResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.CriticalResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CriticalResultInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.CriticalResultInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.CriticalResultInference>
    {
        internal CriticalResultInference() { }
        public Azure.Health.Insights.RadiologyInsights.CriticalResult Result { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.CriticalResultInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.CriticalResultInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.CriticalResultInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.CriticalResultInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.CriticalResultInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.CriticalResultInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.CriticalResultInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentAdministrativeMetadata : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.DocumentAdministrativeMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.DocumentAdministrativeMetadata>
    {
        public DocumentAdministrativeMetadata() { }
        public string EncounterId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4Extendible> OrderedProcedures { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.DocumentAdministrativeMetadata System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.DocumentAdministrativeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.DocumentAdministrativeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.DocumentAdministrativeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.DocumentAdministrativeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.DocumentAdministrativeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.DocumentAdministrativeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentAuthor : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.DocumentAuthor>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.DocumentAuthor>
    {
        public DocumentAuthor() { }
        public string FullName { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.DocumentAuthor System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.DocumentAuthor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.DocumentAuthor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.DocumentAuthor System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.DocumentAuthor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.DocumentAuthor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.DocumentAuthor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentContent : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.DocumentContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.DocumentContent>
    {
        public DocumentContent(Azure.Health.Insights.RadiologyInsights.DocumentContentSourceType sourceType, string value) { }
        public Azure.Health.Insights.RadiologyInsights.DocumentContentSourceType SourceType { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.DocumentContent System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.DocumentContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.DocumentContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.DocumentContent System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.DocumentContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.DocumentContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.DocumentContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentContentSourceType : System.IEquatable<Azure.Health.Insights.RadiologyInsights.DocumentContentSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentContentSourceType(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.DocumentContentSourceType Inline { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.DocumentContentSourceType Reference { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.DocumentContentSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.DocumentContentSourceType left, Azure.Health.Insights.RadiologyInsights.DocumentContentSourceType right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.DocumentContentSourceType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.DocumentContentSourceType left, Azure.Health.Insights.RadiologyInsights.DocumentContentSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentType : System.IEquatable<Azure.Health.Insights.RadiologyInsights.DocumentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentType(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.DocumentType Dicom { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.DocumentType FhirBundle { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.DocumentType GenomicSequencing { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.DocumentType Note { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.DocumentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.DocumentType left, Azure.Health.Insights.RadiologyInsights.DocumentType right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.DocumentType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.DocumentType left, Azure.Health.Insights.RadiologyInsights.DocumentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Encounter : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.Encounter>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.Encounter>
    {
        public Encounter(string id) { }
        public Azure.Health.Insights.RadiologyInsights.EncounterClass? Class { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.TimePeriod Period { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.Encounter System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.Encounter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.Encounter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.Encounter System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.Encounter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.Encounter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.Encounter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncounterClass : System.IEquatable<Azure.Health.Insights.RadiologyInsights.EncounterClass>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncounterClass(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.EncounterClass Ambulatory { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.EncounterClass Emergency { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.EncounterClass HealthHome { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.EncounterClass InPatient { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.EncounterClass Observation { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.EncounterClass Virtual { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.EncounterClass other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.EncounterClass left, Azure.Health.Insights.RadiologyInsights.EncounterClass right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.EncounterClass (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.EncounterClass left, Azure.Health.Insights.RadiologyInsights.EncounterClass right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FhirR4Annotation : Azure.Health.Insights.RadiologyInsights.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Annotation>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Annotation>
    {
        public FhirR4Annotation(string text) { }
        public string AuthorString { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
        public string Time { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.FhirR4Annotation System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Annotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Annotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Annotation System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Annotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Annotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Annotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4CodeableConcept : Azure.Health.Insights.RadiologyInsights.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept>
    {
        public FhirR4CodeableConcept() { }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4Coding> Coding { get { throw null; } }
        public string Text { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Coding : Azure.Health.Insights.RadiologyInsights.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Coding>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Coding>
    {
        public FhirR4Coding() { }
        public string Code { get { throw null; } set { } }
        public string Display { get { throw null; } set { } }
        public string System { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.FhirR4Coding System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Coding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Coding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Coding System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Coding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Coding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Coding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class FhirR4DomainResource : Azure.Health.Insights.RadiologyInsights.FhirR4Resource, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource>
    {
        protected FhirR4DomainResource(string resourceType) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4Resource> Contained { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> Extension { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> ModifierExtension { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Narrative Text { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Element : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Element>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Element>
    {
        internal FhirR4Element() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> Extension { get { throw null; } }
        public string Id { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.FhirR4Element System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Element>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Element>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Element System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Element>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Element>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Element>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Extendible : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Extendible>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Extendible>
    {
        public FhirR4Extendible() { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Code { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> Extension { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.FhirR4Extendible System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Extendible>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Extendible>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Extendible System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Extendible>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Extendible>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Extendible>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Extension : Azure.Health.Insights.RadiologyInsights.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Extension>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Extension>
    {
        public FhirR4Extension(string url) { }
        public string Url { get { throw null; } set { } }
        public bool? ValueBoolean { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept ValueCodeableConcept { get { throw null; } set { } }
        public string ValueDateTime { get { throw null; } set { } }
        public int? ValueInteger { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Period ValuePeriod { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Quantity ValueQuantity { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Range ValueRange { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Ratio ValueRatio { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Reference ValueReference { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4SampledData ValueSampledData { get { throw null; } set { } }
        public string ValueString { get { throw null; } set { } }
        public System.TimeSpan? ValueTime { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.FhirR4Extension System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Extension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Extension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Extension System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Extension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Extension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Extension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Identifier : Azure.Health.Insights.RadiologyInsights.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Identifier>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Identifier>
    {
        public FhirR4Identifier() { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Reference Assigner { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Period Period { get { throw null; } set { } }
        public string System { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Type { get { throw null; } set { } }
        public string Use { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.FhirR4Identifier System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Identifier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Identifier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Identifier System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Identifier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Identifier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Identifier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Meta : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Meta>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Meta>
    {
        public FhirR4Meta() { }
        public string LastUpdated { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Profile { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4Coding> Security { get { throw null; } }
        public string Source { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4Coding> Tag { get { throw null; } }
        public string VersionId { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.FhirR4Meta System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Meta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Meta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Meta System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Meta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Meta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Meta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Narrative : Azure.Health.Insights.RadiologyInsights.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Narrative>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Narrative>
    {
        public FhirR4Narrative(string status, string div) { }
        public string Div { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.FhirR4Narrative System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Narrative>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Narrative>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Narrative System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Narrative>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Narrative>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Narrative>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Observation : Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Observation>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Observation>
    {
        public FhirR4Observation(Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType status, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept code) : base (default(string)) { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept BodySite { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> Category { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Code { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent> Component { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept DataAbsentReason { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4Reference> DerivedFrom { get { throw null; } }
        public string EffectiveDateTime { get { throw null; } set { } }
        public string EffectiveInstant { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Period EffectivePeriod { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Reference Encounter { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4Reference> HasMember { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4Identifier> Identifier { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> Interpretation { get { throw null; } }
        public string Issued { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Method { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4Annotation> Note { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationReferenceRange> ReferenceRange { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType Status { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Reference Subject { get { throw null; } set { } }
        public bool? ValueBoolean { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept ValueCodeableConcept { get { throw null; } set { } }
        public string ValueDateTime { get { throw null; } set { } }
        public int? ValueInteger { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Period ValuePeriod { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Quantity ValueQuantity { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Range ValueRange { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Ratio ValueRatio { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4SampledData ValueSampledData { get { throw null; } set { } }
        public string ValueString { get { throw null; } set { } }
        public System.TimeSpan? ValueTime { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.FhirR4Observation System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Observation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Observation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Observation System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Observation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Observation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Observation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4ObservationComponent : Azure.Health.Insights.RadiologyInsights.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent>
    {
        public FhirR4ObservationComponent(Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept code) { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Code { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept DataAbsentReason { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> Interpretation { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationReferenceRange> ReferenceRange { get { throw null; } }
        public bool? ValueBoolean { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept ValueCodeableConcept { get { throw null; } set { } }
        public string ValueDateTime { get { throw null; } set { } }
        public int? ValueInteger { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Period ValuePeriod { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Quantity ValueQuantity { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Range ValueRange { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Ratio ValueRatio { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Reference ValueReference { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4SampledData ValueSampledData { get { throw null; } set { } }
        public string ValueString { get { throw null; } set { } }
        public System.TimeSpan? ValueTime { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4ObservationReferenceRange : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationReferenceRange>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationReferenceRange>
    {
        public FhirR4ObservationReferenceRange() { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Range Age { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> AppliesTo { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Quantity High { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Quantity Low { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Type { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.FhirR4ObservationReferenceRange System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationReferenceRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationReferenceRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4ObservationReferenceRange System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationReferenceRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationReferenceRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationReferenceRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Period : Azure.Health.Insights.RadiologyInsights.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Period>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Period>
    {
        public FhirR4Period() { }
        public string End { get { throw null; } set { } }
        public string Start { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.FhirR4Period System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Period>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Period>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Period System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Period>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Period>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Period>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Quantity : Azure.Health.Insights.RadiologyInsights.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Quantity>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Quantity>
    {
        public FhirR4Quantity() { }
        public string Code { get { throw null; } set { } }
        public string Comparator { get { throw null; } set { } }
        public string System { get { throw null; } set { } }
        public string Unit { get { throw null; } set { } }
        public double? Value { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.FhirR4Quantity System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Quantity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Quantity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Quantity System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Quantity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Quantity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Quantity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Range : Azure.Health.Insights.RadiologyInsights.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Range>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Range>
    {
        public FhirR4Range() { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Quantity High { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Quantity Low { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.FhirR4Range System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Range>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Range>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Range System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Range>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Range>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Range>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Ratio : Azure.Health.Insights.RadiologyInsights.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Ratio>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Ratio>
    {
        public FhirR4Ratio() { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Quantity Denominator { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Quantity Numerator { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.FhirR4Ratio System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Ratio>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Ratio>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Ratio System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Ratio>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Ratio>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Ratio>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Reference : Azure.Health.Insights.RadiologyInsights.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Reference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Reference>
    {
        public FhirR4Reference() { }
        public string Display { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Identifier Identifier { get { throw null; } set { } }
        public string Reference { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.FhirR4Reference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Reference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Reference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Reference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Reference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Reference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Reference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Resource : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Resource>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Resource>
    {
        public FhirR4Resource(string resourceType) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public string ImplicitRules { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Meta Meta { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.FhirR4Resource System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Resource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Resource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Resource System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Resource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Resource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Resource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4SampledData : Azure.Health.Insights.RadiologyInsights.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4SampledData>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4SampledData>
    {
        public FhirR4SampledData(Azure.Health.Insights.RadiologyInsights.FhirR4Quantity origin, double period, int dimensions) { }
        public string Data { get { throw null; } set { } }
        public int Dimensions { get { throw null; } set { } }
        public double? Factor { get { throw null; } set { } }
        public double? LowerLimit { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Quantity Origin { get { throw null; } set { } }
        public double Period { get { throw null; } set { } }
        public double? UpperLimit { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.FhirR4SampledData System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4SampledData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4SampledData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4SampledData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4SampledData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4SampledData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4SampledData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FindingInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FindingInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FindingInference>
    {
        internal FindingInference() { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Observation Finding { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.FindingInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FindingInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FindingInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FindingInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FindingInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FindingInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FindingInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FindingOptions : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FindingOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FindingOptions>
    {
        public FindingOptions() { }
        public bool? ProvideFocusedSentenceEvidence { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.FindingOptions System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FindingOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FindingOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FindingOptions System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FindingOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FindingOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FindingOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FollowupCommunicationInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference>
    {
        internal FollowupCommunicationInference() { }
        public System.Collections.Generic.IReadOnlyList<System.DateTimeOffset> DateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.MedicalProfessionalType> Recipient { get { throw null; } }
        public bool WasAcknowledged { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FollowupRecommendationInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FollowupRecommendationInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FollowupRecommendationInference>
    {
        internal FollowupRecommendationInference() { }
        public string EffectiveDateTime { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Period EffectivePeriod { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Extendible> Findings { get { throw null; } }
        public bool IsConditional { get { throw null; } }
        public bool IsGuideline { get { throw null; } }
        public bool IsHedging { get { throw null; } }
        public bool IsOption { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation RecommendedProcedure { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.FollowupRecommendationInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FollowupRecommendationInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FollowupRecommendationInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FollowupRecommendationInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FollowupRecommendationInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FollowupRecommendationInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FollowupRecommendationInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FollowupRecommendationOptions : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FollowupRecommendationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FollowupRecommendationOptions>
    {
        public FollowupRecommendationOptions() { }
        public bool? IncludeRecommendationsInReferences { get { throw null; } set { } }
        public bool? IncludeRecommendationsWithNoSpecifiedModality { get { throw null; } set { } }
        public bool? ProvideFocusedSentenceEvidence { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.FollowupRecommendationOptions System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FollowupRecommendationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FollowupRecommendationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FollowupRecommendationOptions System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FollowupRecommendationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FollowupRecommendationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FollowupRecommendationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenericProcedureRecommendation : Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.GenericProcedureRecommendation>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.GenericProcedureRecommendation>
    {
        internal GenericProcedureRecommendation() { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Code { get { throw null; } }
        public string Description { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.GenericProcedureRecommendation System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.GenericProcedureRecommendation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.GenericProcedureRecommendation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.GenericProcedureRecommendation System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.GenericProcedureRecommendation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.GenericProcedureRecommendation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.GenericProcedureRecommendation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class HealthInsightsRadiologyInsightsModelFactory
    {
        public static Azure.Health.Insights.RadiologyInsights.AgeMismatchInference AgeMismatchInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.CompleteOrderDiscrepancyInference CompleteOrderDiscrepancyInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept orderType = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> missingBodyParts = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> missingBodyPartMeasurements = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.CriticalResult CriticalResult(string description = null, Azure.Health.Insights.RadiologyInsights.FhirR4Observation finding = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.CriticalResultInference CriticalResultInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, Azure.Health.Insights.RadiologyInsights.CriticalResult result = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.Encounter Encounter(string id = null, Azure.Health.Insights.RadiologyInsights.TimePeriod period = null, Azure.Health.Insights.RadiologyInsights.EncounterClass? @class = default(Azure.Health.Insights.RadiologyInsights.EncounterClass?)) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4Annotation FhirR4Annotation(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, string authorString = null, string time = null, string text = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept FhirR4CodeableConcept(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Coding> coding = null, string text = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4Coding FhirR4Coding(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, string system = null, string version = null, string code = null, string display = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4Element FhirR4Element(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4Extension FhirR4Extension(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, string url = null, Azure.Health.Insights.RadiologyInsights.FhirR4Quantity valueQuantity = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept valueCodeableConcept = null, string valueString = null, bool? valueBoolean = default(bool?), int? valueInteger = default(int?), Azure.Health.Insights.RadiologyInsights.FhirR4Range valueRange = null, Azure.Health.Insights.RadiologyInsights.FhirR4Ratio valueRatio = null, Azure.Health.Insights.RadiologyInsights.FhirR4SampledData valueSampledData = null, System.TimeSpan? valueTime = default(System.TimeSpan?), string valueDateTime = null, Azure.Health.Insights.RadiologyInsights.FhirR4Period valuePeriod = null, Azure.Health.Insights.RadiologyInsights.FhirR4Reference valueReference = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4Identifier FhirR4Identifier(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, string use = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept type = null, string system = null, string value = null, Azure.Health.Insights.RadiologyInsights.FhirR4Period period = null, Azure.Health.Insights.RadiologyInsights.FhirR4Reference assigner = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4Narrative FhirR4Narrative(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, string status = null, string div = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent FhirR4ObservationComponent(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept code = null, Azure.Health.Insights.RadiologyInsights.FhirR4Quantity valueQuantity = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept valueCodeableConcept = null, string valueString = null, bool? valueBoolean = default(bool?), int? valueInteger = default(int?), Azure.Health.Insights.RadiologyInsights.FhirR4Range valueRange = null, Azure.Health.Insights.RadiologyInsights.FhirR4Ratio valueRatio = null, Azure.Health.Insights.RadiologyInsights.FhirR4SampledData valueSampledData = null, System.TimeSpan? valueTime = default(System.TimeSpan?), string valueDateTime = null, Azure.Health.Insights.RadiologyInsights.FhirR4Period valuePeriod = null, Azure.Health.Insights.RadiologyInsights.FhirR4Reference valueReference = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept dataAbsentReason = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> interpretation = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationReferenceRange> referenceRange = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4Period FhirR4Period(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, string start = null, string end = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4Quantity FhirR4Quantity(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, double? value = default(double?), string comparator = null, string unit = null, string system = null, string code = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4Range FhirR4Range(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, Azure.Health.Insights.RadiologyInsights.FhirR4Quantity low = null, Azure.Health.Insights.RadiologyInsights.FhirR4Quantity high = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4Ratio FhirR4Ratio(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, Azure.Health.Insights.RadiologyInsights.FhirR4Quantity numerator = null, Azure.Health.Insights.RadiologyInsights.FhirR4Quantity denominator = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4Reference FhirR4Reference(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, string reference = null, string type = null, Azure.Health.Insights.RadiologyInsights.FhirR4Identifier identifier = null, string display = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4SampledData FhirR4SampledData(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, Azure.Health.Insights.RadiologyInsights.FhirR4Quantity origin = null, double period = 0, double? factor = default(double?), double? lowerLimit = default(double?), double? upperLimit = default(double?), int dimensions = 0, string data = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FindingInference FindingInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, Azure.Health.Insights.RadiologyInsights.FhirR4Observation finding = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference FollowupCommunicationInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, System.Collections.Generic.IEnumerable<System.DateTimeOffset> dateTime = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.MedicalProfessionalType> recipient = null, bool wasAcknowledged = false) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FollowupRecommendationInference FollowupRecommendationInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, string effectiveDateTime = null, Azure.Health.Insights.RadiologyInsights.FhirR4Period effectivePeriod = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extendible> findings = null, bool isConditional = false, bool isOption = false, bool isGuideline = false, bool isHedging = false, Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation recommendedProcedure = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.GenericProcedureRecommendation GenericProcedureRecommendation(Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept code = null, string description = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.ImagingProcedure ImagingProcedure(Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept modality = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept anatomy = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept laterality = null, Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes contrast = null, Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes view = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.ImagingProcedureRecommendation ImagingProcedureRecommendation(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> procedureCodes = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.ImagingProcedure> imagingProcedures = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyInference LateralityDiscrepancyInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept lateralityIndication = null, Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyType discrepancyType = default(Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyType)) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.LimitedOrderDiscrepancyInference LimitedOrderDiscrepancyInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept orderType = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> presentBodyParts = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> presentBodyPartMeasurements = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.PatientDocument PatientDocument(Azure.Health.Insights.RadiologyInsights.DocumentType type = default(Azure.Health.Insights.RadiologyInsights.DocumentType), Azure.Health.Insights.RadiologyInsights.ClinicalDocumentType? clinicalType = default(Azure.Health.Insights.RadiologyInsights.ClinicalDocumentType?), string id = null, string language = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.DocumentAuthor> authors = null, Azure.Health.Insights.RadiologyInsights.SpecialtyType? specialtyType = default(Azure.Health.Insights.RadiologyInsights.SpecialtyType?), Azure.Health.Insights.RadiologyInsights.DocumentAdministrativeMetadata administrativeMetadata = null, Azure.Health.Insights.RadiologyInsights.DocumentContent content = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.PatientRecord PatientRecord(string id = null, Azure.Health.Insights.RadiologyInsights.PatientDetails info = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Encounter> encounters = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.PatientDocument> patientDocuments = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes RadiologyCodeWithTypes(Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept code = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> types = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference RadiologyInsightsInference(string kind = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceResult RadiologyInsightsInferenceResult(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsPatientResult> patientResults = null, string modelVersion = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsPatientResult RadiologyInsightsPatientResult(string patientId = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference> inferences = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyProcedureInference RadiologyProcedureInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> procedureCodes = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.ImagingProcedure> imagingProcedures = null, Azure.Health.Insights.RadiologyInsights.FhirR4Extendible orderedProcedure = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.SexMismatchInference SexMismatchInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept sexIndication = null) { throw null; }
    }
    public partial class ImagingProcedure : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ImagingProcedure>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ImagingProcedure>
    {
        internal ImagingProcedure() { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Anatomy { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes Contrast { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Laterality { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Modality { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes View { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.ImagingProcedure System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ImagingProcedure>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ImagingProcedure>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.ImagingProcedure System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ImagingProcedure>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ImagingProcedure>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ImagingProcedure>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImagingProcedureRecommendation : Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ImagingProcedureRecommendation>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ImagingProcedureRecommendation>
    {
        internal ImagingProcedureRecommendation() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.ImagingProcedure> ImagingProcedures { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> ProcedureCodes { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.ImagingProcedureRecommendation System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ImagingProcedureRecommendation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ImagingProcedureRecommendation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.ImagingProcedureRecommendation System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ImagingProcedureRecommendation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ImagingProcedureRecommendation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ImagingProcedureRecommendation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LateralityDiscrepancyInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyInference>
    {
        internal LateralityDiscrepancyInference() { }
        public Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyType DiscrepancyType { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept LateralityIndication { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LateralityDiscrepancyType : System.IEquatable<Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LateralityDiscrepancyType(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyType OrderLateralityMismatch { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyType TextLateralityContradiction { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyType TextLateralityMissing { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyType left, Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyType right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyType left, Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LimitedOrderDiscrepancyInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.LimitedOrderDiscrepancyInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.LimitedOrderDiscrepancyInference>
    {
        internal LimitedOrderDiscrepancyInference() { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept OrderType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> PresentBodyPartMeasurements { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> PresentBodyParts { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.LimitedOrderDiscrepancyInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.LimitedOrderDiscrepancyInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.LimitedOrderDiscrepancyInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.LimitedOrderDiscrepancyInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.LimitedOrderDiscrepancyInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.LimitedOrderDiscrepancyInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.LimitedOrderDiscrepancyInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MedicalProfessionalType : System.IEquatable<Azure.Health.Insights.RadiologyInsights.MedicalProfessionalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MedicalProfessionalType(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.MedicalProfessionalType Doctor { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.MedicalProfessionalType Midwife { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.MedicalProfessionalType Nurse { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.MedicalProfessionalType PhysicianAssistant { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.MedicalProfessionalType Unknown { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.MedicalProfessionalType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.MedicalProfessionalType left, Azure.Health.Insights.RadiologyInsights.MedicalProfessionalType right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.MedicalProfessionalType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.MedicalProfessionalType left, Azure.Health.Insights.RadiologyInsights.MedicalProfessionalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ObservationStatusCodeType : System.IEquatable<Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ObservationStatusCodeType(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType Amended { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType Cancelled { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType Corrected { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType EnteredInError { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType Final { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType Preliminary { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType Registered { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType Unknown { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType left, Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType left, Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PatientDetails : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PatientDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientDetails>
    {
        public PatientDetails() { }
        public System.DateTimeOffset? BirthDate { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4Resource> ClinicalInfo { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.PatientSex? Sex { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.PatientDetails System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PatientDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PatientDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.PatientDetails System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatientDocument : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PatientDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientDocument>
    {
        public PatientDocument(Azure.Health.Insights.RadiologyInsights.DocumentType type, string id, Azure.Health.Insights.RadiologyInsights.DocumentContent content) { }
        public Azure.Health.Insights.RadiologyInsights.DocumentAdministrativeMetadata AdministrativeMetadata { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.DocumentAuthor> Authors { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.ClinicalDocumentType? ClinicalType { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.DocumentContent Content { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.SpecialtyType? SpecialtyType { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.DocumentType Type { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.PatientDocument System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PatientDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PatientDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.PatientDocument System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatientRecord : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PatientRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientRecord>
    {
        public PatientRecord(string id) { }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.Encounter> Encounters { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.PatientDetails Info { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.PatientDocument> PatientDocuments { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.PatientRecord System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PatientRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PatientRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.PatientRecord System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PatientSex : System.IEquatable<Azure.Health.Insights.RadiologyInsights.PatientSex>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatientSex(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.PatientSex Female { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.PatientSex Male { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.PatientSex Unspecified { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.PatientSex other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.PatientSex left, Azure.Health.Insights.RadiologyInsights.PatientSex right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.PatientSex (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.PatientSex left, Azure.Health.Insights.RadiologyInsights.PatientSex right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ProcedureRecommendation : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation>
    {
        protected ProcedureRecommendation() { }
        Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RadiologyCodeWithTypes : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes>
    {
        internal RadiologyCodeWithTypes() { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> Types { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RadiologyInsightsClient
    {
        protected RadiologyInsightsClient() { }
        public RadiologyInsightsClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public RadiologyInsightsClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Health.Insights.RadiologyInsights.RadiologyInsightsClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> InferRadiologyInsights(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceResult> InferRadiologyInsights(Azure.WaitUntil waitUntil, Azure.Health.Insights.RadiologyInsights.RadiologyInsightsData radiologyInsightsData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> InferRadiologyInsightsAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceResult>> InferRadiologyInsightsAsync(Azure.WaitUntil waitUntil, Azure.Health.Insights.RadiologyInsights.RadiologyInsightsData radiologyInsightsData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RadiologyInsightsClientOptions : Azure.Core.ClientOptions
    {
        public RadiologyInsightsClientOptions(Azure.Health.Insights.RadiologyInsights.RadiologyInsightsClientOptions.ServiceVersion version = Azure.Health.Insights.RadiologyInsights.RadiologyInsightsClientOptions.ServiceVersion.V2023_09_01_Preview) { }
        public enum ServiceVersion
        {
            V2023_09_01_Preview = 1,
        }
    }
    public partial class RadiologyInsightsData : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsData>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsData>
    {
        public RadiologyInsightsData(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.PatientRecord> patients) { }
        public Azure.Health.Insights.RadiologyInsights.RadiologyInsightsModelConfiguration Configuration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.PatientRecord> Patients { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.RadiologyInsightsData System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.RadiologyInsightsData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RadiologyInsightsInference : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference>
    {
        protected RadiologyInsightsInference() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> Extension { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RadiologyInsightsInferenceOptions : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceOptions>
    {
        public RadiologyInsightsInferenceOptions() { }
        public Azure.Health.Insights.RadiologyInsights.FindingOptions FindingOptions { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FollowupRecommendationOptions FollowupRecommendationOptions { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceOptions System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceOptions System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RadiologyInsightsInferenceResult : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceResult>
    {
        internal RadiologyInsightsInferenceResult() { }
        public string ModelVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsPatientResult> PatientResults { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceResult System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceResult System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RadiologyInsightsInferenceType : System.IEquatable<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RadiologyInsightsInferenceType(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType AgeMismatch { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType CompleteOrderDiscrepancy { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType CriticalResult { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType Finding { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType FollowupCommunication { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType FollowupRecommendation { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType LateralityDiscrepancy { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType LimitedOrderDiscrepancy { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType RadiologyProcedure { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType SexMismatch { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType left, Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType left, Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RadiologyInsightsModelConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsModelConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsModelConfiguration>
    {
        public RadiologyInsightsModelConfiguration() { }
        public bool? IncludeEvidence { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceOptions InferenceOptions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType> InferenceTypes { get { throw null; } }
        public string Locale { get { throw null; } set { } }
        public bool? Verbose { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.RadiologyInsightsModelConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsModelConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsModelConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.RadiologyInsightsModelConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsModelConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsModelConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsModelConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RadiologyInsightsPatientResult : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsPatientResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsPatientResult>
    {
        internal RadiologyInsightsPatientResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference> Inferences { get { throw null; } }
        public string PatientId { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.RadiologyInsightsPatientResult System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsPatientResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsPatientResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.RadiologyInsightsPatientResult System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsPatientResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsPatientResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsPatientResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RadiologyProcedureInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyProcedureInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyProcedureInference>
    {
        internal RadiologyProcedureInference() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.ImagingProcedure> ImagingProcedures { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Extendible OrderedProcedure { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> ProcedureCodes { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.RadiologyProcedureInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyProcedureInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyProcedureInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.RadiologyProcedureInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyProcedureInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyProcedureInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyProcedureInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SexMismatchInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.SexMismatchInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.SexMismatchInference>
    {
        internal SexMismatchInference() { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept SexIndication { get { throw null; } }
        Azure.Health.Insights.RadiologyInsights.SexMismatchInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.SexMismatchInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.SexMismatchInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.SexMismatchInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.SexMismatchInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.SexMismatchInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.SexMismatchInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpecialtyType : System.IEquatable<Azure.Health.Insights.RadiologyInsights.SpecialtyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpecialtyType(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.SpecialtyType Pathology { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.SpecialtyType Radiology { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.SpecialtyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.SpecialtyType left, Azure.Health.Insights.RadiologyInsights.SpecialtyType right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.SpecialtyType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.SpecialtyType left, Azure.Health.Insights.RadiologyInsights.SpecialtyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TimePeriod : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.TimePeriod>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.TimePeriod>
    {
        public TimePeriod() { }
        public System.DateTimeOffset? End { get { throw null; } set { } }
        public System.DateTimeOffset? Start { get { throw null; } set { } }
        Azure.Health.Insights.RadiologyInsights.TimePeriod System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.TimePeriod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.TimePeriod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.TimePeriod System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.TimePeriod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.TimePeriod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.TimePeriod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class HealthInsightsRadiologyInsightsClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsClient, Azure.Health.Insights.RadiologyInsights.RadiologyInsightsClientOptions> AddRadiologyInsightsClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsClient, Azure.Health.Insights.RadiologyInsights.RadiologyInsightsClientOptions> AddRadiologyInsightsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
