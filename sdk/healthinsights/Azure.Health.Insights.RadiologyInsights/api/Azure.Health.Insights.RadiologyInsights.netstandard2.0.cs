namespace Azure.Health.Insights.RadiologyInsights
{
    public partial class AgeMismatchInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.AgeMismatchInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.AgeMismatchInference>
    {
        internal AgeMismatchInference() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.AgeMismatchInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.AgeMismatchInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.AgeMismatchInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.AgeMismatchInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.AgeMismatchInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.AgeMismatchInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.AgeMismatchInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessmentValueRange : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.AssessmentValueRange>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.AssessmentValueRange>
    {
        internal AssessmentValueRange() { }
        public string Maximum { get { throw null; } }
        public string Minimum { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.AssessmentValueRange System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.AssessmentValueRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.AssessmentValueRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.AssessmentValueRange System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.AssessmentValueRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.AssessmentValueRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.AssessmentValueRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureHealthInsightsRadiologyInsightsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureHealthInsightsRadiologyInsightsContext() { }
        public static Azure.Health.Insights.RadiologyInsights.AzureHealthInsightsRadiologyInsightsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ClinicalDocumentAuthor : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ClinicalDocumentAuthor>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ClinicalDocumentAuthor>
    {
        public ClinicalDocumentAuthor() { }
        public string FullName { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.ClinicalDocumentAuthor System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ClinicalDocumentAuthor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ClinicalDocumentAuthor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.ClinicalDocumentAuthor System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ClinicalDocumentAuthor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ClinicalDocumentAuthor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ClinicalDocumentAuthor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClinicalDocumentContent : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContent>
    {
        public ClinicalDocumentContent(Azure.Health.Insights.RadiologyInsights.DocumentContentSourceType sourceType, string value) { }
        public Azure.Health.Insights.RadiologyInsights.DocumentContentSourceType SourceType { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContent System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContent System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClinicalDocumentContentType : System.IEquatable<Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClinicalDocumentContentType(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContentType Dicom { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContentType FhirBundle { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContentType GenomicSequencing { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContentType Note { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContentType left, Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContentType right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContentType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContentType left, Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContentType right) { throw null; }
        public override string ToString() { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.CompleteOrderDiscrepancyInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.CompleteOrderDiscrepancyInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.CompleteOrderDiscrepancyInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.CompleteOrderDiscrepancyInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.CompleteOrderDiscrepancyInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.CompleteOrderDiscrepancyInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.CompleteOrderDiscrepancyInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContactPointSystem : System.IEquatable<Azure.Health.Insights.RadiologyInsights.ContactPointSystem>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContactPointSystem(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.ContactPointSystem Email { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ContactPointSystem Fax { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ContactPointSystem Other { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ContactPointSystem Pager { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ContactPointSystem Phone { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ContactPointSystem Sms { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ContactPointSystem Url { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.ContactPointSystem other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.ContactPointSystem left, Azure.Health.Insights.RadiologyInsights.ContactPointSystem right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.ContactPointSystem (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.ContactPointSystem left, Azure.Health.Insights.RadiologyInsights.ContactPointSystem right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContactPointUse : System.IEquatable<Azure.Health.Insights.RadiologyInsights.ContactPointUse>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContactPointUse(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.ContactPointUse Home { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ContactPointUse Mobile { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ContactPointUse Old { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ContactPointUse Temp { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ContactPointUse Work { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.ContactPointUse other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.ContactPointUse left, Azure.Health.Insights.RadiologyInsights.ContactPointUse right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.ContactPointUse (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.ContactPointUse left, Azure.Health.Insights.RadiologyInsights.ContactPointUse right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CriticalResult : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.CriticalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.CriticalResult>
    {
        internal CriticalResult() { }
        public string Description { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Observation Finding { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.OrderedProcedure> OrderedProcedures { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.DocumentAdministrativeMetadata System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.DocumentAdministrativeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.DocumentAdministrativeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.DocumentAdministrativeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.DocumentAdministrativeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.DocumentAdministrativeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.DocumentAdministrativeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        internal FhirR4Annotation() { }
        public string AuthorString { get { throw null; } }
        public string Text { get { throw null; } }
        public string Time { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Coding System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Coding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Coding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Coding System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Coding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Coding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Coding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Condition : Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Condition>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Condition>
    {
        internal FhirR4Condition() : base (default(string)) { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Quantity AbatementAge { get { throw null; } }
        public string AbatementDateTime { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Period AbatementPeriod { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Range AbatementRange { get { throw null; } }
        public string AbatementString { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> BodySite { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> Category { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept ClinicalStatus { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Code { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Reference Encounter { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Identifier> Identifier { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Annotation> Note { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Quantity OnsetAge { get { throw null; } }
        public string OnsetDateTime { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Period OnsetPeriod { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Range OnsetRange { get { throw null; } }
        public string OnsetString { get { throw null; } }
        public string RecordedDate { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Severity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4ConditionStage> Stage { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept VerificationStatus { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Condition System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Condition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Condition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Condition System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Condition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Condition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Condition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4ConditionStage : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ConditionStage>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ConditionStage>
    {
        internal FhirR4ConditionStage() { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Summary { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4ConditionStage System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ConditionStage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ConditionStage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4ConditionStage System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ConditionStage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ConditionStage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ConditionStage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4ContactDetail : Azure.Health.Insights.RadiologyInsights.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ContactDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ContactDetail>
    {
        internal FhirR4ContactDetail() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4ContactPoint> Telecom { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4ContactDetail System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ContactDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ContactDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4ContactDetail System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ContactDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ContactDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ContactDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4ContactPoint : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ContactPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ContactPoint>
    {
        internal FhirR4ContactPoint() { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Period Period { get { throw null; } }
        public int? Rank { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.ContactPointSystem? System { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.ContactPointUse? Use { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4ContactPoint System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ContactPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ContactPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4ContactPoint System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ContactPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ContactPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ContactPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class FhirR4DomainResource : Azure.Health.Insights.RadiologyInsights.FhirR4Resource, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource>
    {
        protected FhirR4DomainResource(string resourceType) : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Resource> Contained { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> Extension { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> ModifierExtension { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Narrative Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Element : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Element>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Element>
    {
        public FhirR4Element() { }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> Extension { get { throw null; } }
        public string Id { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Element System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Element>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Element>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Element System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Element>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Element>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Element>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Meta System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Meta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Meta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Meta System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Meta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Meta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Meta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Narrative : Azure.Health.Insights.RadiologyInsights.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Narrative>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Narrative>
    {
        internal FhirR4Narrative() { }
        public string Div { get { throw null; } }
        public string Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Narrative System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Narrative>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Narrative>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Narrative System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Narrative>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Narrative>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Narrative>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Observation : Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Observation>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Observation>
    {
        internal FhirR4Observation() : base (default(string)) { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept BodySite { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> Category { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent> Component { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept DataAbsentReason { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Reference> DerivedFrom { get { throw null; } }
        public string EffectiveDateTime { get { throw null; } }
        public string EffectiveInstant { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Period EffectivePeriod { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Reference Encounter { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Reference> HasMember { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Identifier> Identifier { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> Interpretation { get { throw null; } }
        public string Issued { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Method { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Annotation> Note { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationReferenceRange> ReferenceRange { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType Status { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Reference Subject { get { throw null; } }
        public bool? ValueBoolean { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept ValueCodeableConcept { get { throw null; } }
        public string ValueDateTime { get { throw null; } }
        public int? ValueInteger { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Period ValuePeriod { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Quantity ValueQuantity { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Range ValueRange { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Ratio ValueRatio { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4SampledData ValueSampledData { get { throw null; } }
        public string ValueString { get { throw null; } }
        public System.TimeSpan? ValueTime { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Observation System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Observation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Observation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Observation System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Observation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Observation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Observation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4ObservationComponent : Azure.Health.Insights.RadiologyInsights.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent>
    {
        internal FhirR4ObservationComponent() { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Code { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept DataAbsentReason { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> Interpretation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationReferenceRange> ReferenceRange { get { throw null; } }
        public bool? ValueBoolean { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept ValueCodeableConcept { get { throw null; } }
        public string ValueDateTime { get { throw null; } }
        public int? ValueInteger { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Period ValuePeriod { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Quantity ValueQuantity { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Range ValueRange { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Ratio ValueRatio { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Reference ValueReference { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4SampledData ValueSampledData { get { throw null; } }
        public string ValueString { get { throw null; } }
        public System.TimeSpan? ValueTime { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4ObservationReferenceRange : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationReferenceRange>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationReferenceRange>
    {
        internal FhirR4ObservationReferenceRange() { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Range Age { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> AppliesTo { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Quantity High { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Quantity Low { get { throw null; } }
        public string Text { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Reference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Reference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4Reference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4Reference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Reference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Reference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4Reference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4ResearchStudy : Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ResearchStudy>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ResearchStudy>
    {
        internal FhirR4ResearchStudy() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.ResearchStudyArm> Arm { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> Condition { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4ContactDetail> Contact { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Reference> Enrollment { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> Focus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Identifier> Identifier { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> Keyword { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Annotation> Note { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.ResearchStudyObjective> Objective { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Reference> PartOf { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Period Period { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Phase { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept PrimaryPurposeType { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Reference PrincipalInvestigator { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Reference> Protocol { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept ReasonStopped { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Reference> Site { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Reference Sponsor { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType Status { get { throw null; } }
        public string Title { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4ResearchStudy System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ResearchStudy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FhirR4ResearchStudy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FhirR4ResearchStudy System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ResearchStudy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ResearchStudy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FhirR4ResearchStudy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FindingOptions System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FindingOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FindingOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FindingOptions System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FindingOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FindingOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FindingOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FollowupCommunicationInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference>
    {
        internal FollowupCommunicationInference() { }
        public System.Collections.Generic.IReadOnlyList<System.DateTimeOffset> CommunicatedAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.MedicalProfessionalType> Recipient { get { throw null; } }
        public bool WasAcknowledged { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FollowupRecommendationInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.FollowupRecommendationInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.FollowupRecommendationInference>
    {
        internal FollowupRecommendationInference() { }
        public string EffectiveAt { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Period EffectivePeriod { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.RecommendationFinding> Findings { get { throw null; } }
        public bool IsConditional { get { throw null; } }
        public bool IsGuideline { get { throw null; } }
        public bool IsHedging { get { throw null; } }
        public bool IsOption { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation RecommendedProcedure { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.GenericProcedureRecommendation System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.GenericProcedureRecommendation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.GenericProcedureRecommendation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.GenericProcedureRecommendation System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.GenericProcedureRecommendation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.GenericProcedureRecommendation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.GenericProcedureRecommendation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GuidanceInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.GuidanceInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.GuidanceInference>
    {
        internal GuidanceInference() { }
        public Azure.Health.Insights.RadiologyInsights.FindingInference Finding { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Identifier { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> MissingGuidanceInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.PresentGuidanceInformation> PresentGuidanceInformation { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.GuidanceRankingType Ranking { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FollowupRecommendationInference> RecommendationProposals { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.GuidanceInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.GuidanceInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.GuidanceInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.GuidanceInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.GuidanceInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.GuidanceInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.GuidanceInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GuidanceOptions : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.GuidanceOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.GuidanceOptions>
    {
        public GuidanceOptions(bool showGuidanceInHistory) { }
        public bool ShowGuidanceInHistory { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.GuidanceOptions System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.GuidanceOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.GuidanceOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.GuidanceOptions System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.GuidanceOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.GuidanceOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.GuidanceOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GuidanceRankingType : System.IEquatable<Azure.Health.Insights.RadiologyInsights.GuidanceRankingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GuidanceRankingType(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.GuidanceRankingType High { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.GuidanceRankingType Low { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.GuidanceRankingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.GuidanceRankingType left, Azure.Health.Insights.RadiologyInsights.GuidanceRankingType right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.GuidanceRankingType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.GuidanceRankingType left, Azure.Health.Insights.RadiologyInsights.GuidanceRankingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class HealthInsightsRadiologyInsightsModelFactory
    {
        public static Azure.Health.Insights.RadiologyInsights.AgeMismatchInference AgeMismatchInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.AssessmentValueRange AssessmentValueRange(string minimum = null, string maximum = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.CompleteOrderDiscrepancyInference CompleteOrderDiscrepancyInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept orderType = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> missingBodyParts = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> missingBodyPartMeasurements = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.CriticalResult CriticalResult(string description = null, Azure.Health.Insights.RadiologyInsights.FhirR4Observation finding = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.CriticalResultInference CriticalResultInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, Azure.Health.Insights.RadiologyInsights.CriticalResult result = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4Annotation FhirR4Annotation(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, string authorString = null, string time = null, string text = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4Condition FhirR4Condition(string id = null, Azure.Health.Insights.RadiologyInsights.FhirR4Meta meta = null, string implicitRules = null, string language = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null, Azure.Health.Insights.RadiologyInsights.FhirR4Narrative text = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Resource> contained = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> modifierExtension = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Identifier> identifier = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept clinicalStatus = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept verificationStatus = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> category = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept severity = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept code = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> bodySite = null, Azure.Health.Insights.RadiologyInsights.FhirR4Reference encounter = null, string onsetDateTime = null, Azure.Health.Insights.RadiologyInsights.FhirR4Quantity onsetAge = null, Azure.Health.Insights.RadiologyInsights.FhirR4Period onsetPeriod = null, Azure.Health.Insights.RadiologyInsights.FhirR4Range onsetRange = null, string onsetString = null, string abatementDateTime = null, Azure.Health.Insights.RadiologyInsights.FhirR4Quantity abatementAge = null, Azure.Health.Insights.RadiologyInsights.FhirR4Period abatementPeriod = null, Azure.Health.Insights.RadiologyInsights.FhirR4Range abatementRange = null, string abatementString = null, string recordedDate = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4ConditionStage> stage = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Annotation> note = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4ConditionStage FhirR4ConditionStage(Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept summary = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept type = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4ContactDetail FhirR4ContactDetail(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, string name = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4ContactPoint> telecom = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4ContactPoint FhirR4ContactPoint(Azure.Health.Insights.RadiologyInsights.ContactPointSystem? system = default(Azure.Health.Insights.RadiologyInsights.ContactPointSystem?), string value = null, Azure.Health.Insights.RadiologyInsights.ContactPointUse? use = default(Azure.Health.Insights.RadiologyInsights.ContactPointUse?), int? rank = default(int?), Azure.Health.Insights.RadiologyInsights.FhirR4Period period = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4DomainResource FhirR4DomainResource(string resourceType = null, string id = null, Azure.Health.Insights.RadiologyInsights.FhirR4Meta meta = null, string implicitRules = null, string language = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null, Azure.Health.Insights.RadiologyInsights.FhirR4Narrative text = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Resource> contained = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> modifierExtension = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4Narrative FhirR4Narrative(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, string status = null, string div = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4Observation FhirR4Observation(string id = null, Azure.Health.Insights.RadiologyInsights.FhirR4Meta meta = null, string implicitRules = null, string language = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null, Azure.Health.Insights.RadiologyInsights.FhirR4Narrative text = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Resource> contained = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> modifierExtension = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Identifier> identifier = null, Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType status = default(Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType), System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> category = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept code = null, Azure.Health.Insights.RadiologyInsights.FhirR4Reference subject = null, Azure.Health.Insights.RadiologyInsights.FhirR4Reference encounter = null, string effectiveDateTime = null, Azure.Health.Insights.RadiologyInsights.FhirR4Period effectivePeriod = null, string effectiveInstant = null, string issued = null, Azure.Health.Insights.RadiologyInsights.FhirR4Quantity valueQuantity = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept valueCodeableConcept = null, string valueString = null, bool? valueBoolean = default(bool?), int? valueInteger = default(int?), Azure.Health.Insights.RadiologyInsights.FhirR4Range valueRange = null, Azure.Health.Insights.RadiologyInsights.FhirR4Ratio valueRatio = null, Azure.Health.Insights.RadiologyInsights.FhirR4SampledData valueSampledData = null, System.TimeSpan? valueTime = default(System.TimeSpan?), string valueDateTime = null, Azure.Health.Insights.RadiologyInsights.FhirR4Period valuePeriod = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept dataAbsentReason = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> interpretation = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Annotation> note = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept bodySite = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept method = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationReferenceRange> referenceRange = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Reference> hasMember = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Reference> derivedFrom = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent> component = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4ObservationComponent FhirR4ObservationComponent(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept code = null, Azure.Health.Insights.RadiologyInsights.FhirR4Quantity valueQuantity = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept valueCodeableConcept = null, string valueString = null, bool? valueBoolean = default(bool?), int? valueInteger = default(int?), Azure.Health.Insights.RadiologyInsights.FhirR4Range valueRange = null, Azure.Health.Insights.RadiologyInsights.FhirR4Ratio valueRatio = null, Azure.Health.Insights.RadiologyInsights.FhirR4SampledData valueSampledData = null, System.TimeSpan? valueTime = default(System.TimeSpan?), string valueDateTime = null, Azure.Health.Insights.RadiologyInsights.FhirR4Period valuePeriod = null, Azure.Health.Insights.RadiologyInsights.FhirR4Reference valueReference = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept dataAbsentReason = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> interpretation = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4ObservationReferenceRange> referenceRange = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4ObservationReferenceRange FhirR4ObservationReferenceRange(Azure.Health.Insights.RadiologyInsights.FhirR4Quantity low = null, Azure.Health.Insights.RadiologyInsights.FhirR4Quantity high = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept type = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> appliesTo = null, Azure.Health.Insights.RadiologyInsights.FhirR4Range age = null, string text = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FhirR4ResearchStudy FhirR4ResearchStudy(string id = null, Azure.Health.Insights.RadiologyInsights.FhirR4Meta meta = null, string implicitRules = null, string language = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null, Azure.Health.Insights.RadiologyInsights.FhirR4Narrative text = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Resource> contained = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> modifierExtension = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Identifier> identifier = null, string title = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Reference> protocol = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Reference> partOf = null, Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType status = default(Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType), Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept primaryPurposeType = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept phase = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> category = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> focus = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> condition = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4ContactDetail> contact = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> keyword = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> location = null, string description = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Reference> enrollment = null, Azure.Health.Insights.RadiologyInsights.FhirR4Period period = null, Azure.Health.Insights.RadiologyInsights.FhirR4Reference sponsor = null, Azure.Health.Insights.RadiologyInsights.FhirR4Reference principalInvestigator = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Reference> site = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept reasonStopped = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Annotation> note = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.ResearchStudyArm> arm = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.ResearchStudyObjective> objective = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FindingInference FindingInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, Azure.Health.Insights.RadiologyInsights.FhirR4Observation finding = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference FollowupCommunicationInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, System.Collections.Generic.IEnumerable<System.DateTimeOffset> communicatedAt = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.MedicalProfessionalType> recipient = null, bool wasAcknowledged = false) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FollowupRecommendationInference FollowupRecommendationInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, string effectiveAt = null, Azure.Health.Insights.RadiologyInsights.FhirR4Period effectivePeriod = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.RecommendationFinding> findings = null, bool isConditional = false, bool isOption = false, bool isGuideline = false, bool isHedging = false, Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation recommendedProcedure = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.GenericProcedureRecommendation GenericProcedureRecommendation(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept code = null, string description = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.GuidanceInference GuidanceInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, Azure.Health.Insights.RadiologyInsights.FindingInference finding = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept identifier = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.PresentGuidanceInformation> presentGuidanceInformation = null, Azure.Health.Insights.RadiologyInsights.GuidanceRankingType ranking = default(Azure.Health.Insights.RadiologyInsights.GuidanceRankingType), System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FollowupRecommendationInference> recommendationProposals = null, System.Collections.Generic.IEnumerable<string> missingGuidanceInformation = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.ImagingProcedure ImagingProcedure(Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept modality = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept anatomy = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept laterality = null, Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes contrast = null, Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes view = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.ImagingProcedureRecommendation ImagingProcedureRecommendation(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> procedureCodes = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.ImagingProcedure> imagingProcedures = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyInference LateralityDiscrepancyInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept lateralityIndication = null, Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyType discrepancyType = default(Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyType)) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.LimitedOrderDiscrepancyInference LimitedOrderDiscrepancyInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept orderType = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> presentBodyParts = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> presentBodyPartMeasurements = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.PresentGuidanceInformation PresentGuidanceInformation(string presentGuidanceItem = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Observation> sizes = null, Azure.Health.Insights.RadiologyInsights.FhirR4Quantity maximumDiameterAsInText = null, System.Collections.Generic.IEnumerable<string> presentGuidanceValues = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation ProcedureRecommendation(string kind = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureInference QualityMeasureInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, string qualityMeasureDenominator = null, Azure.Health.Insights.RadiologyInsights.QualityMeasureComplianceType complianceType = default(Azure.Health.Insights.RadiologyInsights.QualityMeasureComplianceType), System.Collections.Generic.IEnumerable<string> qualityCriteria = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes RadiologyCodeWithTypes(Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept code = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> types = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference RadiologyInsightsInference(string kind = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceResult RadiologyInsightsInferenceResult(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsPatientResult> patientResults = null, string modelVersion = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsJob RadiologyInsightsJob(Azure.Health.Insights.RadiologyInsights.RadiologyInsightsData jobData = null, Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceResult result = null, string id = null, Azure.Health.Insights.RadiologyInsights.JobStatus status = default(Azure.Health.Insights.RadiologyInsights.JobStatus), System.DateTimeOffset? createdAt = default(System.DateTimeOffset?), System.DateTimeOffset? expiresAt = default(System.DateTimeOffset?), System.DateTimeOffset? updatedAt = default(System.DateTimeOffset?), Azure.ResponseError error = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsPatientResult RadiologyInsightsPatientResult(string patientId = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference> inferences = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyProcedureInference RadiologyProcedureInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> procedureCodes = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.ImagingProcedure> imagingProcedures = null, Azure.Health.Insights.RadiologyInsights.OrderedProcedure orderedProcedure = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.RecommendationFinding RecommendationFinding(Azure.Health.Insights.RadiologyInsights.FhirR4Observation finding = null, Azure.Health.Insights.RadiologyInsights.CriticalResult criticalFinding = null, Azure.Health.Insights.RadiologyInsights.RecommendationFindingStatusType recommendationFindingStatus = default(Azure.Health.Insights.RadiologyInsights.RecommendationFindingStatusType), System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.ResearchStudyArm ResearchStudyArm(string name = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept type = null, string description = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.ResearchStudyObjective ResearchStudyObjective(string name = null, Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept type = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentInference ScoringAndAssessmentInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> extension = null, Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType category = default(Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType), string categoryDescription = null, string singleValue = null, Azure.Health.Insights.RadiologyInsights.AssessmentValueRange rangeValue = null) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.ImagingProcedureRecommendation System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ImagingProcedureRecommendation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ImagingProcedureRecommendation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.ImagingProcedureRecommendation System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ImagingProcedureRecommendation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ImagingProcedureRecommendation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ImagingProcedureRecommendation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.Health.Insights.RadiologyInsights.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.JobStatus Canceled { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.JobStatus Failed { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.JobStatus NotStarted { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.JobStatus Running { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.JobStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.JobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.JobStatus left, Azure.Health.Insights.RadiologyInsights.JobStatus right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.JobStatus (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.JobStatus left, Azure.Health.Insights.RadiologyInsights.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LateralityDiscrepancyInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyInference>
    {
        internal LateralityDiscrepancyInference() { }
        public Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyType DiscrepancyType { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept LateralityIndication { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class OrderedProcedure : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.OrderedProcedure>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.OrderedProcedure>
    {
        public OrderedProcedure() { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Code { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> Extension { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.OrderedProcedure System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.OrderedProcedure>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.OrderedProcedure>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.OrderedProcedure System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.OrderedProcedure>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.OrderedProcedure>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.OrderedProcedure>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatientDetails : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PatientDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientDetails>
    {
        public PatientDetails() { }
        public System.DateTimeOffset? BirthDate { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.FhirR4Resource> ClinicalInfo { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.PatientSex? Sex { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.PatientDetails System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PatientDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PatientDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.PatientDetails System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatientDocument : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PatientDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientDocument>
    {
        public PatientDocument(Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContentType type, string id, Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContent content) { }
        public Azure.Health.Insights.RadiologyInsights.DocumentAdministrativeMetadata AdministrativeMetadata { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.ClinicalDocumentAuthor> Authors { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.ClinicalDocumentType? ClinicalType { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContent Content { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.SpecialtyType? SpecialtyType { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.ClinicalDocumentContentType Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.PatientDocument System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PatientDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PatientDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.PatientDocument System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatientEncounter : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PatientEncounter>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientEncounter>
    {
        public PatientEncounter(string id) { }
        public Azure.Health.Insights.RadiologyInsights.EncounterClass? Class { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.TimePeriod Period { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.PatientEncounter System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PatientEncounter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PatientEncounter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.PatientEncounter System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientEncounter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientEncounter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientEncounter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatientRecord : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PatientRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PatientRecord>
    {
        public PatientRecord(string id) { }
        public Azure.Health.Insights.RadiologyInsights.PatientDetails Details { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.PatientEncounter> Encounters { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.PatientDocument> PatientDocuments { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class PresentGuidanceInformation : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PresentGuidanceInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PresentGuidanceInformation>
    {
        internal PresentGuidanceInformation() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> Extension { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Quantity MaximumDiameterAsInText { get { throw null; } }
        public string PresentGuidanceItem { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PresentGuidanceValues { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Observation> Sizes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.PresentGuidanceInformation System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PresentGuidanceInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.PresentGuidanceInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.PresentGuidanceInformation System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PresentGuidanceInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PresentGuidanceInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.PresentGuidanceInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ProcedureRecommendation : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation>
    {
        protected ProcedureRecommendation() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> Extension { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QualityMeasureComplianceType : System.IEquatable<Azure.Health.Insights.RadiologyInsights.QualityMeasureComplianceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QualityMeasureComplianceType(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureComplianceType DenominatorException { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureComplianceType NotEligible { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureComplianceType PerformanceMet { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureComplianceType PerformanceNotMet { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.QualityMeasureComplianceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.QualityMeasureComplianceType left, Azure.Health.Insights.RadiologyInsights.QualityMeasureComplianceType right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.QualityMeasureComplianceType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.QualityMeasureComplianceType left, Azure.Health.Insights.RadiologyInsights.QualityMeasureComplianceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QualityMeasureInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.QualityMeasureInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.QualityMeasureInference>
    {
        internal QualityMeasureInference() { }
        public Azure.Health.Insights.RadiologyInsights.QualityMeasureComplianceType ComplianceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> QualityCriteria { get { throw null; } }
        public string QualityMeasureDenominator { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.QualityMeasureInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.QualityMeasureInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.QualityMeasureInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.QualityMeasureInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.QualityMeasureInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.QualityMeasureInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.QualityMeasureInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QualityMeasureOptions : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.QualityMeasureOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.QualityMeasureOptions>
    {
        public QualityMeasureOptions(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.QualityMeasureType> measureTypes) { }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.QualityMeasureType> MeasureTypes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.QualityMeasureOptions System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.QualityMeasureOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.QualityMeasureOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.QualityMeasureOptions System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.QualityMeasureOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.QualityMeasureOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.QualityMeasureOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QualityMeasureType : System.IEquatable<Azure.Health.Insights.RadiologyInsights.QualityMeasureType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QualityMeasureType(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Acrad36 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Acrad37 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Acrad38 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Acrad39 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Acrad40 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Acrad41 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Acrad42 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Mednax55 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Mips145 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Mips147 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Mips195 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Mips360 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Mips364 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Mips405 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Mips406 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Mips436 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Mips76 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Msn13 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Msn15 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Qmm17 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Qmm18 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Qmm19 { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.QualityMeasureType Qmm26 { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.QualityMeasureType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.QualityMeasureType left, Azure.Health.Insights.RadiologyInsights.QualityMeasureType right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.QualityMeasureType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.QualityMeasureType left, Azure.Health.Insights.RadiologyInsights.QualityMeasureType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RadiologyCodeWithTypes : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes>
    {
        internal RadiologyCodeWithTypes() { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> Types { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public RadiologyInsightsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public RadiologyInsightsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Health.Insights.RadiologyInsights.RadiologyInsightsClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> InferRadiologyInsights(Azure.WaitUntil waitUntil, string id, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<string> expand = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceResult> InferRadiologyInsights(Azure.WaitUntil waitUntil, string id, Azure.Health.Insights.RadiologyInsights.RadiologyInsightsJob resource, System.Collections.Generic.IEnumerable<string> expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> InferRadiologyInsightsAsync(Azure.WaitUntil waitUntil, string id, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<string> expand = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceResult>> InferRadiologyInsightsAsync(Azure.WaitUntil waitUntil, string id, Azure.Health.Insights.RadiologyInsights.RadiologyInsightsJob resource, System.Collections.Generic.IEnumerable<string> expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RadiologyInsightsClientOptions : Azure.Core.ClientOptions
    {
        public RadiologyInsightsClientOptions(Azure.Health.Insights.RadiologyInsights.RadiologyInsightsClientOptions.ServiceVersion version = Azure.Health.Insights.RadiologyInsights.RadiologyInsightsClientOptions.ServiceVersion.V2024_10_01) { }
        public enum ServiceVersion
        {
            V2024_04_01 = 1,
            V2024_10_01 = 2,
        }
    }
    public partial class RadiologyInsightsData : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsData>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsData>
    {
        public RadiologyInsightsData(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.PatientRecord> patients) { }
        public Azure.Health.Insights.RadiologyInsights.RadiologyInsightsModelConfiguration Configuration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.PatientRecord> Patients { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.Health.Insights.RadiologyInsights.GuidanceOptions GuidanceOptions { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.QualityMeasureOptions QualityMeasureOptions { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType Guidance { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType LateralityDiscrepancy { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType LimitedOrderDiscrepancy { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType QualityMeasure { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType RadiologyProcedure { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType ScoringAndAssessment { get { throw null; } }
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
    public partial class RadiologyInsightsJob : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsJob>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsJob>
    {
        public RadiologyInsightsJob() { }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.DateTimeOffset? ExpiresAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.RadiologyInsightsData JobData { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceResult Result { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.JobStatus Status { get { throw null; } }
        public System.DateTimeOffset? UpdatedAt { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.RadiologyInsightsJob System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.RadiologyInsightsJob System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RadiologyInsightsModelConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsModelConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsModelConfiguration>
    {
        public RadiologyInsightsModelConfiguration() { }
        public bool? IncludeEvidence { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceOptions InferenceOptions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType> InferenceTypes { get { throw null; } }
        public string Locale { get { throw null; } set { } }
        public bool? Verbose { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.Health.Insights.RadiologyInsights.OrderedProcedure OrderedProcedure { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept> ProcedureCodes { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.RadiologyProcedureInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyProcedureInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RadiologyProcedureInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.RadiologyProcedureInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyProcedureInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyProcedureInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RadiologyProcedureInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendationFinding : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RecommendationFinding>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RecommendationFinding>
    {
        internal RecommendationFinding() { }
        public Azure.Health.Insights.RadiologyInsights.CriticalResult CriticalFinding { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.FhirR4Extension> Extension { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4Observation Finding { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.RecommendationFindingStatusType RecommendationFindingStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.RecommendationFinding System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RecommendationFinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.RecommendationFinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.RecommendationFinding System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RecommendationFinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RecommendationFinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.RecommendationFinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendationFindingStatusType : System.IEquatable<Azure.Health.Insights.RadiologyInsights.RecommendationFindingStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationFindingStatusType(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.RecommendationFindingStatusType Conditional { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.RecommendationFindingStatusType Differential { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.RecommendationFindingStatusType Present { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.RecommendationFindingStatusType RuleOut { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.RecommendationFindingStatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.RecommendationFindingStatusType left, Azure.Health.Insights.RadiologyInsights.RecommendationFindingStatusType right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.RecommendationFindingStatusType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.RecommendationFindingStatusType left, Azure.Health.Insights.RadiologyInsights.RecommendationFindingStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResearchStudyArm : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ResearchStudyArm>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ResearchStudyArm>
    {
        internal ResearchStudyArm() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.ResearchStudyArm System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ResearchStudyArm>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ResearchStudyArm>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.ResearchStudyArm System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ResearchStudyArm>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ResearchStudyArm>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ResearchStudyArm>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResearchStudyObjective : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ResearchStudyObjective>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ResearchStudyObjective>
    {
        internal ResearchStudyObjective() { }
        public string Name { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.ResearchStudyObjective System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ResearchStudyObjective>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ResearchStudyObjective>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.ResearchStudyObjective System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ResearchStudyObjective>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ResearchStudyObjective>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ResearchStudyObjective>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResearchStudyStatusCodeType : System.IEquatable<Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResearchStudyStatusCodeType(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType Active { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType AdministrativelyCompleted { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType Approved { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType ClosedToAccrual { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType ClosedToAccrualAndIntervention { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType Completed { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType Disapproved { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType InReview { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType TemporarilyClosedToAccrual { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType TemporarilyClosedToAccrualAndIntervention { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType Withdrawn { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType left, Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType left, Azure.Health.Insights.RadiologyInsights.ResearchStudyStatusCodeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScoringAndAssessmentCategoryType : System.IEquatable<Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScoringAndAssessmentCategoryType(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType AgatstonScore { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType AlbertaStrokeProgramEarlyCtScore { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType AscvdRisk { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType Birads { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType CadRads { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType CalciumMassScore { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType CalciumScoreUnspecified { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType CalciumVolumeScore { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType CeusLiRads { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType CRadsColonicFindings { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType CRadsExtracolonicFindings { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType FraxScore { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType HnpccMutationRisk { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType KellgrenLawrenceGradingScale { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType LifetimeBreastCancerRisk { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType LiRads { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType LungRads { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType ModifiedGailModelRisk { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType NiRads { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType ORads { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType ORadsMri { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType PiRads { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType RiskOfMalignancyIndex { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType TenYearChdRisk { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType TenYearChdRiskArterialAge { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType TenYearChdRiskObservedAge { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType TiRads { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType TonnisClassification { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType TreatmentResponseLiRads { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType TScore { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType TyrerCusickModelRisk { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType UsLiRads { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType UsLiRadsVisualizationScore { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType ZScore { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType left, Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType left, Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScoringAndAssessmentInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentInference>
    {
        internal ScoringAndAssessmentInference() { }
        public Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentCategoryType Category { get { throw null; } }
        public string CategoryDescription { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.AssessmentValueRange RangeValue { get { throw null; } }
        public string SingleValue { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.ScoringAndAssessmentInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SexMismatchInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.RadiologyInsights.SexMismatchInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.RadiologyInsights.SexMismatchInference>
    {
        internal SexMismatchInference() { }
        public Azure.Health.Insights.RadiologyInsights.FhirR4CodeableConcept SexIndication { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsClient, Azure.Health.Insights.RadiologyInsights.RadiologyInsightsClientOptions> AddRadiologyInsightsClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsClient, Azure.Health.Insights.RadiologyInsights.RadiologyInsightsClientOptions> AddRadiologyInsightsClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsClient, Azure.Health.Insights.RadiologyInsights.RadiologyInsightsClientOptions> AddRadiologyInsightsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
