namespace Azure.Health.Insights.RadiologyInsights
{
    public partial class AgeMismatchInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference
    {
        internal AgeMismatchInference() { }
    }
    public partial class Annotation : Azure.Health.Insights.RadiologyInsights.Element
    {
        public Annotation(string text) { }
        public string AuthorString { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
        public string Time { get { throw null; } set { } }
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
    public partial class CodeableConcept : Azure.Health.Insights.RadiologyInsights.Element
    {
        public CodeableConcept() { }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.Coding> Coding { get { throw null; } }
        public string Text { get { throw null; } set { } }
    }
    public partial class Coding : Azure.Health.Insights.RadiologyInsights.Element
    {
        public Coding() { }
        public string Code { get { throw null; } set { } }
        public string Display { get { throw null; } set { } }
        public string System { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class CompleteOrderDiscrepancyInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference
    {
        internal CompleteOrderDiscrepancyInference() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.CodeableConcept> MissingBodyPartMeasurements { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.CodeableConcept> MissingBodyParts { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept OrderType { get { throw null; } }
    }
    public partial class CriticalResult
    {
        internal CriticalResult() { }
        public string Description { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.Observation Finding { get { throw null; } }
    }
    public partial class CriticalResultInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference
    {
        internal CriticalResultInference() { }
        public Azure.Health.Insights.RadiologyInsights.CriticalResult Result { get { throw null; } }
    }
    public partial class DocumentAdministrativeMetadata
    {
        public DocumentAdministrativeMetadata() { }
        public string EncounterId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.OrderedProcedure> OrderedProcedures { get { throw null; } }
    }
    public partial class DocumentAuthor
    {
        public DocumentAuthor() { }
        public string FullName { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
    }
    public partial class DocumentContent
    {
        public DocumentContent(Azure.Health.Insights.RadiologyInsights.DocumentContentSourceType sourceType, string value) { }
        public Azure.Health.Insights.RadiologyInsights.DocumentContentSourceType SourceType { get { throw null; } }
        public string Value { get { throw null; } }
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
    public abstract partial class DomainResource : Azure.Health.Insights.RadiologyInsights.Resource
    {
        protected DomainResource(string resourceType) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.Resource> Contained { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.Extension> Extension { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.Extension> ModifierExtension { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.Narrative Text { get { throw null; } set { } }
    }
    public partial class Element
    {
        internal Element() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.Extension> Extension { get { throw null; } }
        public string Id { get { throw null; } }
    }
    public partial class Encounter
    {
        public Encounter(string id) { }
        public Azure.Health.Insights.RadiologyInsights.EncounterClass? Class { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.TimePeriod Period { get { throw null; } set { } }
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
    public partial class Extendible
    {
        internal Extendible() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.Extension> Extension { get { throw null; } }
    }
    public partial class Extension : Azure.Health.Insights.RadiologyInsights.Element
    {
        public Extension(string url) { }
        public string Url { get { throw null; } set { } }
        public bool? ValueBoolean { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept ValueCodeableConcept { get { throw null; } set { } }
        public string ValueDateTime { get { throw null; } set { } }
        public int? ValueInteger { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Period ValuePeriod { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Quantity ValueQuantity { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Range ValueRange { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Ratio ValueRatio { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Reference ValueReference { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.SampledData ValueSampledData { get { throw null; } set { } }
        public string ValueString { get { throw null; } set { } }
        public System.TimeSpan? ValueTime { get { throw null; } set { } }
    }
    public partial class FindingInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference
    {
        internal FindingInference() { }
        public Azure.Health.Insights.RadiologyInsights.Observation Finding { get { throw null; } }
    }
    public partial class FindingOptions
    {
        public FindingOptions() { }
        public bool? ProvideFocusedSentenceEvidence { get { throw null; } set { } }
    }
    public partial class FollowupCommunicationInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference
    {
        internal FollowupCommunicationInference() { }
        public System.Collections.Generic.IReadOnlyList<System.DateTimeOffset> DateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Recipient { get { throw null; } }
        public bool WasAcknowledged { get { throw null; } }
    }
    public partial class FollowupRecommendationInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference
    {
        internal FollowupRecommendationInference() { }
        public string EffectiveDateTime { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.Period EffectivePeriod { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.RecommendationFinding> Findings { get { throw null; } }
        public bool IsConditional { get { throw null; } }
        public bool IsGuideline { get { throw null; } }
        public bool IsHedging { get { throw null; } }
        public bool IsOption { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation RecommendedProcedure { get { throw null; } }
    }
    public partial class FollowupRecommendationOptions
    {
        public FollowupRecommendationOptions() { }
        public bool? IncludeRecommendationsInReferences { get { throw null; } set { } }
        public bool? IncludeRecommendationsWithNoSpecifiedModality { get { throw null; } set { } }
        public bool? ProvideFocusedSentenceEvidence { get { throw null; } set { } }
    }
    public partial class GenericProcedureRecommendation : Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation
    {
        internal GenericProcedureRecommendation() { }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept Code { get { throw null; } }
        public string Description { get { throw null; } }
    }
    public static partial class HealthInsightsRadiologyInsightsModelFactory
    {
        public static Azure.Health.Insights.RadiologyInsights.AgeMismatchInference AgeMismatchInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.Annotation Annotation(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, string authorString = null, string time = null, string text = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.CodeableConcept CodeableConcept(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Coding> coding = null, string text = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.Coding Coding(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, string system = null, string version = null, string code = null, string display = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.CompleteOrderDiscrepancyInference CompleteOrderDiscrepancyInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, Azure.Health.Insights.RadiologyInsights.CodeableConcept orderType = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.CodeableConcept> missingBodyParts = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.CodeableConcept> missingBodyPartMeasurements = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.CriticalResult CriticalResult(string description = null, Azure.Health.Insights.RadiologyInsights.Observation finding = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.CriticalResultInference CriticalResultInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, Azure.Health.Insights.RadiologyInsights.CriticalResult result = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.Extension Extension(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, string url = null, Azure.Health.Insights.RadiologyInsights.Quantity valueQuantity = null, Azure.Health.Insights.RadiologyInsights.CodeableConcept valueCodeableConcept = null, string valueString = null, bool? valueBoolean = default(bool?), int? valueInteger = default(int?), Azure.Health.Insights.RadiologyInsights.Range valueRange = null, Azure.Health.Insights.RadiologyInsights.Ratio valueRatio = null, Azure.Health.Insights.RadiologyInsights.SampledData valueSampledData = null, System.TimeSpan? valueTime = default(System.TimeSpan?), string valueDateTime = null, Azure.Health.Insights.RadiologyInsights.Period valuePeriod = null, Azure.Health.Insights.RadiologyInsights.Reference valueReference = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FindingInference FindingInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, Azure.Health.Insights.RadiologyInsights.Observation finding = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FollowupCommunicationInference FollowupCommunicationInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, System.Collections.Generic.IEnumerable<System.DateTimeOffset> dateTime = null, System.Collections.Generic.IEnumerable<string> recipient = null, bool wasAcknowledged = false) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.FollowupRecommendationInference FollowupRecommendationInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, string effectiveDateTime = null, Azure.Health.Insights.RadiologyInsights.Period effectivePeriod = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.RecommendationFinding> findings = null, bool isConditional = false, bool isOption = false, bool isGuideline = false, bool isHedging = false, Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation recommendedProcedure = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.GenericProcedureRecommendation GenericProcedureRecommendation(Azure.Health.Insights.RadiologyInsights.CodeableConcept code = null, string description = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.Identifier Identifier(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, string use = null, Azure.Health.Insights.RadiologyInsights.CodeableConcept type = null, string system = null, string value = null, Azure.Health.Insights.RadiologyInsights.Period period = null, Azure.Health.Insights.RadiologyInsights.Reference assigner = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.ImagingProcedure ImagingProcedure(Azure.Health.Insights.RadiologyInsights.CodeableConcept modality = null, Azure.Health.Insights.RadiologyInsights.CodeableConcept anatomy = null, Azure.Health.Insights.RadiologyInsights.CodeableConcept laterality = null, Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes contrast = null, Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes view = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.ImagingProcedureRecommendation ImagingProcedureRecommendation(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.CodeableConcept> procedureCodes = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.ImagingProcedure> imagingProcedures = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.LateralityDiscrepancyInference LateralityDiscrepancyInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, Azure.Health.Insights.RadiologyInsights.CodeableConcept lateralityIndication = null, string discrepancyType = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.LimitedOrderDiscrepancyInference LimitedOrderDiscrepancyInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, Azure.Health.Insights.RadiologyInsights.CodeableConcept orderType = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.CodeableConcept> presentBodyParts = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.CodeableConcept> presentBodyPartMeasurements = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.Narrative Narrative(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, string status = null, string div = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.ObservationComponent ObservationComponent(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, Azure.Health.Insights.RadiologyInsights.CodeableConcept code = null, Azure.Health.Insights.RadiologyInsights.Quantity valueQuantity = null, Azure.Health.Insights.RadiologyInsights.CodeableConcept valueCodeableConcept = null, string valueString = null, bool? valueBoolean = default(bool?), int? valueInteger = default(int?), Azure.Health.Insights.RadiologyInsights.Range valueRange = null, Azure.Health.Insights.RadiologyInsights.Ratio valueRatio = null, Azure.Health.Insights.RadiologyInsights.SampledData valueSampledData = null, System.TimeSpan? valueTime = default(System.TimeSpan?), string valueDateTime = null, Azure.Health.Insights.RadiologyInsights.Period valuePeriod = null, Azure.Health.Insights.RadiologyInsights.Reference valueReference = null, Azure.Health.Insights.RadiologyInsights.CodeableConcept dataAbsentReason = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.CodeableConcept> interpretation = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.ObservationReferenceRange> referenceRange = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.OrderedProcedure OrderedProcedure(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, Azure.Health.Insights.RadiologyInsights.CodeableConcept code = null, string description = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.Period Period(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, string start = null, string end = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.Quantity Quantity(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, decimal? value = default(decimal?), string comparator = null, string unit = null, string system = null, string code = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes RadiologyCodeWithTypes(Azure.Health.Insights.RadiologyInsights.CodeableConcept code = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.CodeableConcept> types = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference RadiologyInsightsInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, string kind = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceResult RadiologyInsightsInferenceResult(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsPatientResult> patientResults = null, string modelVersion = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyInsightsPatientResult RadiologyInsightsPatientResult(string patientId = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference> inferences = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.RadiologyProcedureInference RadiologyProcedureInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.CodeableConcept> procedureCodes = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.ImagingProcedure> imagingProcedures = null, Azure.Health.Insights.RadiologyInsights.OrderedProcedure orderedProcedure = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.Range Range(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, Azure.Health.Insights.RadiologyInsights.Quantity low = null, Azure.Health.Insights.RadiologyInsights.Quantity high = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.Ratio Ratio(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, Azure.Health.Insights.RadiologyInsights.Quantity numerator = null, Azure.Health.Insights.RadiologyInsights.Quantity denominator = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.RecommendationFinding RecommendationFinding(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, Azure.Health.Insights.RadiologyInsights.Observation finding = null, Azure.Health.Insights.RadiologyInsights.CriticalResult criticalFinding = null, string recommendationFindingStatus = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.Reference Reference(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, string referenceProperty = null, string type = null, Azure.Health.Insights.RadiologyInsights.Identifier identifier = null, string display = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.SampledData SampledData(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, Azure.Health.Insights.RadiologyInsights.Quantity origin = null, [System.Runtime.CompilerServices.DecimalConstantAttribute((byte)0, (byte)0, (uint)0, (uint)0, (uint)0)] decimal period, decimal? factor = default(decimal?), decimal? lowerLimit = default(decimal?), decimal? upperLimit = default(decimal?), int dimensions = 0, string data = null) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.SexMismatchInference SexMismatchInference(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.Extension> extension = null, Azure.Health.Insights.RadiologyInsights.CodeableConcept sexIndication = null) { throw null; }
    }
    public partial class Identifier : Azure.Health.Insights.RadiologyInsights.Element
    {
        public Identifier() { }
        public Azure.Health.Insights.RadiologyInsights.Reference Assigner { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Period Period { get { throw null; } set { } }
        public string System { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept Type { get { throw null; } set { } }
        public string Use { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ImagingProcedure
    {
        internal ImagingProcedure() { }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept Anatomy { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes Contrast { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept Laterality { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept Modality { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.RadiologyCodeWithTypes View { get { throw null; } }
    }
    public partial class ImagingProcedureRecommendation : Azure.Health.Insights.RadiologyInsights.ProcedureRecommendation
    {
        internal ImagingProcedureRecommendation() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.ImagingProcedure> ImagingProcedures { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.CodeableConcept> ProcedureCodes { get { throw null; } }
    }
    public partial class LateralityDiscrepancyInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference
    {
        internal LateralityDiscrepancyInference() { }
        public string DiscrepancyType { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept LateralityIndication { get { throw null; } }
    }
    public partial class LimitedOrderDiscrepancyInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference
    {
        internal LimitedOrderDiscrepancyInference() { }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept OrderType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.CodeableConcept> PresentBodyPartMeasurements { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.CodeableConcept> PresentBodyParts { get { throw null; } }
    }
    public partial class Meta
    {
        public Meta() { }
        public string LastUpdated { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Profile { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.Coding> Security { get { throw null; } }
        public string Source { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.Coding> Tag { get { throw null; } }
        public string VersionId { get { throw null; } set { } }
    }
    public partial class Narrative : Azure.Health.Insights.RadiologyInsights.Element
    {
        public Narrative(string status, string div) { }
        public string Div { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class Observation : Azure.Health.Insights.RadiologyInsights.DomainResource
    {
        public Observation(Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType status, Azure.Health.Insights.RadiologyInsights.CodeableConcept code) : base (default(string)) { }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept BodySite { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.CodeableConcept> Category { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept Code { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.ObservationComponent> Component { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept DataAbsentReason { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.Reference> DerivedFrom { get { throw null; } }
        public string EffectiveDateTime { get { throw null; } set { } }
        public string EffectiveInstant { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Period EffectivePeriod { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Reference Encounter { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.Reference> HasMember { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.Identifier> Identifier { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.CodeableConcept> Interpretation { get { throw null; } }
        public string Issued { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept Method { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.Annotation> Note { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.ObservationReferenceRange> ReferenceRange { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.ObservationStatusCodeType Status { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Reference Subject { get { throw null; } set { } }
        public bool? ValueBoolean { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept ValueCodeableConcept { get { throw null; } set { } }
        public string ValueDateTime { get { throw null; } set { } }
        public int? ValueInteger { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Period ValuePeriod { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Quantity ValueQuantity { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Range ValueRange { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Ratio ValueRatio { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.SampledData ValueSampledData { get { throw null; } set { } }
        public string ValueString { get { throw null; } set { } }
        public System.TimeSpan? ValueTime { get { throw null; } set { } }
    }
    public partial class ObservationComponent : Azure.Health.Insights.RadiologyInsights.Element
    {
        public ObservationComponent(Azure.Health.Insights.RadiologyInsights.CodeableConcept code) { }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept Code { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept DataAbsentReason { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.CodeableConcept> Interpretation { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.ObservationReferenceRange> ReferenceRange { get { throw null; } }
        public bool? ValueBoolean { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept ValueCodeableConcept { get { throw null; } set { } }
        public string ValueDateTime { get { throw null; } set { } }
        public int? ValueInteger { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Period ValuePeriod { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Quantity ValueQuantity { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Range ValueRange { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Ratio ValueRatio { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Reference ValueReference { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.SampledData ValueSampledData { get { throw null; } set { } }
        public string ValueString { get { throw null; } set { } }
        public System.TimeSpan? ValueTime { get { throw null; } set { } }
    }
    public partial class ObservationReferenceRange
    {
        public ObservationReferenceRange() { }
        public Azure.Health.Insights.RadiologyInsights.Range Age { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.CodeableConcept> AppliesTo { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.Quantity High { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Quantity Low { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept Type { get { throw null; } set { } }
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
    public partial class OrderedProcedure : Azure.Health.Insights.RadiologyInsights.Extendible
    {
        public OrderedProcedure() { }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept Code { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
    }
    public partial class PatientDocument
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
    }
    public partial class PatientInfo
    {
        public PatientInfo() { }
        public System.DateTimeOffset? BirthDate { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.Resource> ClinicalInfo { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.PatientInfoSex? Sex { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PatientInfoSex : System.IEquatable<Azure.Health.Insights.RadiologyInsights.PatientInfoSex>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatientInfoSex(string value) { throw null; }
        public static Azure.Health.Insights.RadiologyInsights.PatientInfoSex Female { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.PatientInfoSex Male { get { throw null; } }
        public static Azure.Health.Insights.RadiologyInsights.PatientInfoSex Unspecified { get { throw null; } }
        public bool Equals(Azure.Health.Insights.RadiologyInsights.PatientInfoSex other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.RadiologyInsights.PatientInfoSex left, Azure.Health.Insights.RadiologyInsights.PatientInfoSex right) { throw null; }
        public static implicit operator Azure.Health.Insights.RadiologyInsights.PatientInfoSex (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.RadiologyInsights.PatientInfoSex left, Azure.Health.Insights.RadiologyInsights.PatientInfoSex right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PatientRecord
    {
        public PatientRecord(string id) { }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.Encounter> Encounters { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.PatientInfo Info { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.PatientDocument> PatientDocuments { get { throw null; } }
    }
    public partial class Period : Azure.Health.Insights.RadiologyInsights.Element
    {
        public Period() { }
        public string End { get { throw null; } set { } }
        public string Start { get { throw null; } set { } }
    }
    public abstract partial class ProcedureRecommendation
    {
        protected ProcedureRecommendation() { }
    }
    public partial class Quantity : Azure.Health.Insights.RadiologyInsights.Element
    {
        public Quantity() { }
        public string Code { get { throw null; } set { } }
        public string Comparator { get { throw null; } set { } }
        public string System { get { throw null; } set { } }
        public string Unit { get { throw null; } set { } }
        public decimal? Value { get { throw null; } set { } }
    }
    public partial class RadiologyCodeWithTypes
    {
        internal RadiologyCodeWithTypes() { }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.CodeableConcept> Types { get { throw null; } }
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
    public partial class RadiologyInsightsData
    {
        public RadiologyInsightsData(System.Collections.Generic.IEnumerable<Azure.Health.Insights.RadiologyInsights.PatientRecord> patients) { }
        public Azure.Health.Insights.RadiologyInsights.RadiologyInsightsModelConfiguration Configuration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.PatientRecord> Patients { get { throw null; } }
    }
    public abstract partial class RadiologyInsightsInference : Azure.Health.Insights.RadiologyInsights.Extendible
    {
        protected RadiologyInsightsInference() { }
    }
    public partial class RadiologyInsightsInferenceOptions
    {
        public RadiologyInsightsInferenceOptions() { }
        public Azure.Health.Insights.RadiologyInsights.FindingOptions Finding { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.FollowupRecommendationOptions FollowupRecommendation { get { throw null; } set { } }
    }
    public partial class RadiologyInsightsInferenceResult
    {
        internal RadiologyInsightsInferenceResult() { }
        public string ModelVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsPatientResult> PatientResults { get { throw null; } }
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
    public partial class RadiologyInsightsModelConfiguration
    {
        public RadiologyInsightsModelConfiguration() { }
        public bool? IncludeEvidence { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceOptions InferenceOptions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInferenceType> InferenceTypes { get { throw null; } }
        public string Locale { get { throw null; } set { } }
        public bool? Verbose { get { throw null; } set { } }
    }
    public partial class RadiologyInsightsPatientResult
    {
        internal RadiologyInsightsPatientResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference> Inferences { get { throw null; } }
        public string PatientId { get { throw null; } }
    }
    public partial class RadiologyProcedureInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference
    {
        internal RadiologyProcedureInference() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.ImagingProcedure> ImagingProcedures { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.OrderedProcedure OrderedProcedure { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.RadiologyInsights.CodeableConcept> ProcedureCodes { get { throw null; } }
    }
    public partial class Range : Azure.Health.Insights.RadiologyInsights.Element
    {
        public Range() { }
        public Azure.Health.Insights.RadiologyInsights.Quantity High { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Quantity Low { get { throw null; } set { } }
    }
    public partial class Ratio : Azure.Health.Insights.RadiologyInsights.Element
    {
        public Ratio() { }
        public Azure.Health.Insights.RadiologyInsights.Quantity Denominator { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Quantity Numerator { get { throw null; } set { } }
    }
    public partial class RecommendationFinding : Azure.Health.Insights.RadiologyInsights.Extendible
    {
        internal RecommendationFinding() { }
        public Azure.Health.Insights.RadiologyInsights.CriticalResult CriticalFinding { get { throw null; } }
        public Azure.Health.Insights.RadiologyInsights.Observation Finding { get { throw null; } }
        public string RecommendationFindingStatus { get { throw null; } }
    }
    public partial class Reference : Azure.Health.Insights.RadiologyInsights.Element
    {
        public Reference() { }
        public string Display { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Identifier Identifier { get { throw null; } set { } }
        public string ReferenceProperty { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
    }
    public partial class Resource
    {
        public Resource(string resourceType) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public string ImplicitRules { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Meta Meta { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class SampledData : Azure.Health.Insights.RadiologyInsights.Element
    {
        public SampledData(Azure.Health.Insights.RadiologyInsights.Quantity origin, decimal period, int dimensions) { }
        public string Data { get { throw null; } set { } }
        public int Dimensions { get { throw null; } set { } }
        public decimal? Factor { get { throw null; } set { } }
        public decimal? LowerLimit { get { throw null; } set { } }
        public Azure.Health.Insights.RadiologyInsights.Quantity Origin { get { throw null; } set { } }
        public decimal Period { get { throw null; } set { } }
        public decimal? UpperLimit { get { throw null; } set { } }
    }
    public partial class SexMismatchInference : Azure.Health.Insights.RadiologyInsights.RadiologyInsightsInference
    {
        internal SexMismatchInference() { }
        public Azure.Health.Insights.RadiologyInsights.CodeableConcept SexIndication { get { throw null; } }
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
    public partial class TimePeriod
    {
        public TimePeriod() { }
        public System.DateTimeOffset? End { get { throw null; } set { } }
        public System.DateTimeOffset? Start { get { throw null; } set { } }
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
