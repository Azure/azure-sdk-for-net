namespace Azure.Health.Insights.ClinicalMatching
{
    public partial class AreaGeometry : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.AreaGeometry>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.AreaGeometry>
    {
        public AreaGeometry(Azure.Health.Insights.ClinicalMatching.GeoJsonGeometryType type, System.Collections.Generic.IEnumerable<float> coordinates) { }
        public System.Collections.Generic.IList<float> Coordinates { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.GeoJsonGeometryType Type { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.AreaGeometry System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.AreaGeometry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.AreaGeometry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.AreaGeometry System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.AreaGeometry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.AreaGeometry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.AreaGeometry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AreaProperties : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.AreaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.AreaProperties>
    {
        public AreaProperties(Azure.Health.Insights.ClinicalMatching.GeoJsonPropertiesSubType subType, double radius) { }
        public double Radius { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.GeoJsonPropertiesSubType SubType { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.AreaProperties System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.AreaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.AreaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.AreaProperties System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.AreaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.AreaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.AreaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClinicalCodedElement : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalCodedElement>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalCodedElement>
    {
        internal ClinicalCodedElement() { }
        public string Code { get { throw null; } }
        public string Name { get { throw null; } }
        public string System { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.ClinicalCodedElement System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalCodedElement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalCodedElement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ClinicalCodedElement System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalCodedElement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalCodedElement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalCodedElement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClinicalDocumentType : System.IEquatable<Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClinicalDocumentType(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType Consultation { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType DischargeSummary { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType HistoryAndPhysical { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType Laboratory { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType PathologyReport { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType Procedure { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType Progress { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType RadiologyReport { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType left, Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType left, Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClinicalMatchingClient
    {
        protected ClinicalMatchingClient() { }
        public ClinicalMatchingClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ClinicalMatchingClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Health.Insights.ClinicalMatching.ClinicalMatchingClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> MatchTrials(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceResult> MatchTrials(Azure.WaitUntil waitUntil, Azure.Health.Insights.ClinicalMatching.TrialMatcherData trialMatcherData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> MatchTrialsAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceResult>> MatchTrialsAsync(Azure.WaitUntil waitUntil, Azure.Health.Insights.ClinicalMatching.TrialMatcherData trialMatcherData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClinicalMatchingClientOptions : Azure.Core.ClientOptions
    {
        public ClinicalMatchingClientOptions(Azure.Health.Insights.ClinicalMatching.ClinicalMatchingClientOptions.ServiceVersion version = Azure.Health.Insights.ClinicalMatching.ClinicalMatchingClientOptions.ServiceVersion.V2023_09_01_Preview) { }
        public enum ServiceVersion
        {
            V2023_09_01_Preview = 1,
        }
    }
    public partial class ClinicalNoteEvidence : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence>
    {
        internal ClinicalNoteEvidence() { }
        public string Id { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClinicalTrialMetadata : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata>
    {
        internal ClinicalTrialMetadata() { }
        public System.Collections.Generic.IReadOnlyList<string> Conditions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.ClinicalMatching.ContactDetails> Contacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility> Facilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.ClinicalMatching.ClinicalTrialPhase> Phases { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.ClinicalTrialRecruitmentStatus? RecruitmentStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Sponsors { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.ClinicalTrialStudyType? StudyType { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClinicalTrialPhase : System.IEquatable<Azure.Health.Insights.ClinicalMatching.ClinicalTrialPhase>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClinicalTrialPhase(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialPhase EarlyPhase1 { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialPhase NotApplicable { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialPhase Phase1 { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialPhase Phase2 { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialPhase Phase3 { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialPhase Phase4 { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.ClinicalTrialPhase other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.ClinicalTrialPhase left, Azure.Health.Insights.ClinicalMatching.ClinicalTrialPhase right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.ClinicalTrialPhase (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.ClinicalTrialPhase left, Azure.Health.Insights.ClinicalMatching.ClinicalTrialPhase right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClinicalTrialPurpose : System.IEquatable<Azure.Health.Insights.ClinicalMatching.ClinicalTrialPurpose>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClinicalTrialPurpose(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialPurpose BasicScience { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialPurpose DeviceFeasibility { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialPurpose Diagnostic { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialPurpose HealthServicesResearch { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialPurpose NotApplicable { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialPurpose Other { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialPurpose Prevention { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialPurpose Screening { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialPurpose SupportiveCare { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialPurpose Treatment { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.ClinicalTrialPurpose other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.ClinicalTrialPurpose left, Azure.Health.Insights.ClinicalMatching.ClinicalTrialPurpose right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.ClinicalTrialPurpose (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.ClinicalTrialPurpose left, Azure.Health.Insights.ClinicalMatching.ClinicalTrialPurpose right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClinicalTrialRecruitmentStatus : System.IEquatable<Azure.Health.Insights.ClinicalMatching.ClinicalTrialRecruitmentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClinicalTrialRecruitmentStatus(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialRecruitmentStatus EnrollingByInvitation { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialRecruitmentStatus NotYetRecruiting { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialRecruitmentStatus Recruiting { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialRecruitmentStatus UnknownStatus { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.ClinicalTrialRecruitmentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.ClinicalTrialRecruitmentStatus left, Azure.Health.Insights.ClinicalMatching.ClinicalTrialRecruitmentStatus right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.ClinicalTrialRecruitmentStatus (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.ClinicalTrialRecruitmentStatus left, Azure.Health.Insights.ClinicalMatching.ClinicalTrialRecruitmentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClinicalTrialRegistryFilter : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialRegistryFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialRegistryFilter>
    {
        public ClinicalTrialRegistryFilter() { }
        public System.Collections.Generic.IList<string> Conditions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.GeographicArea> FacilityAreas { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.GeographicLocation> FacilityLocations { get { throw null; } }
        public System.Collections.Generic.IList<string> FacilityNames { get { throw null; } }
        public System.Collections.Generic.IList<string> Ids { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.ClinicalTrialPhase> Phases { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.ClinicalTrialPurpose> Purposes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.ClinicalTrialRecruitmentStatus> RecruitmentStatuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.ClinicalTrialSource> Sources { get { throw null; } }
        public System.Collections.Generic.IList<string> Sponsors { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.ClinicalTrialStudyType> StudyTypes { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.ClinicalTrialRegistryFilter System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialRegistryFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialRegistryFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ClinicalTrialRegistryFilter System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialRegistryFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialRegistryFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialRegistryFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClinicalTrialResearchFacility : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility>
    {
        internal ClinicalTrialResearchFacility() { }
        public string City { get { throw null; } }
        public string CountryOrRegion { get { throw null; } }
        public string Name { get { throw null; } }
        public string State { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClinicalTrials : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrials>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrials>
    {
        public ClinicalTrials() { }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4ResearchStudy> CustomTrials { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.ClinicalTrialRegistryFilter> RegistryFilters { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.ClinicalTrials System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ClinicalTrials System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClinicalTrialSource : System.IEquatable<Azure.Health.Insights.ClinicalMatching.ClinicalTrialSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClinicalTrialSource(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialSource ClinicaltrialsGov { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialSource Custom { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.ClinicalTrialSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.ClinicalTrialSource left, Azure.Health.Insights.ClinicalMatching.ClinicalTrialSource right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.ClinicalTrialSource (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.ClinicalTrialSource left, Azure.Health.Insights.ClinicalMatching.ClinicalTrialSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClinicalTrialStudyType : System.IEquatable<Azure.Health.Insights.ClinicalMatching.ClinicalTrialStudyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClinicalTrialStudyType(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialStudyType ExpandedAccess { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialStudyType Interventional { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialStudyType Observational { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialStudyType PatientRegistries { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.ClinicalTrialStudyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.ClinicalTrialStudyType left, Azure.Health.Insights.ClinicalMatching.ClinicalTrialStudyType right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.ClinicalTrialStudyType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.ClinicalTrialStudyType left, Azure.Health.Insights.ClinicalMatching.ClinicalTrialStudyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContactDetails : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ContactDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ContactDetails>
    {
        internal ContactDetails() { }
        public string Email { get { throw null; } }
        public string Name { get { throw null; } }
        public string Phone { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.ContactDetails System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ContactDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ContactDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ContactDetails System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ContactDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ContactDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ContactDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContactPointSystem : System.IEquatable<Azure.Health.Insights.ClinicalMatching.ContactPointSystem>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContactPointSystem(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.ContactPointSystem Email { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ContactPointSystem Fax { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ContactPointSystem Other { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ContactPointSystem Pager { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ContactPointSystem Phone { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ContactPointSystem Sms { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ContactPointSystem Url { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.ContactPointSystem other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.ContactPointSystem left, Azure.Health.Insights.ClinicalMatching.ContactPointSystem right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.ContactPointSystem (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.ContactPointSystem left, Azure.Health.Insights.ClinicalMatching.ContactPointSystem right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContactPointUse : System.IEquatable<Azure.Health.Insights.ClinicalMatching.ContactPointUse>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContactPointUse(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.ContactPointUse Home { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ContactPointUse Mobile { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ContactPointUse Old { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ContactPointUse Temp { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ContactPointUse Work { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.ContactPointUse other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.ContactPointUse left, Azure.Health.Insights.ClinicalMatching.ContactPointUse right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.ContactPointUse (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.ContactPointUse left, Azure.Health.Insights.ClinicalMatching.ContactPointUse right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentAdministrativeMetadata : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.DocumentAdministrativeMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.DocumentAdministrativeMetadata>
    {
        public DocumentAdministrativeMetadata() { }
        public string EncounterId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4Extendible> OrderedProcedures { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.DocumentAdministrativeMetadata System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.DocumentAdministrativeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.DocumentAdministrativeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.DocumentAdministrativeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.DocumentAdministrativeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.DocumentAdministrativeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.DocumentAdministrativeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentAuthor : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.DocumentAuthor>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.DocumentAuthor>
    {
        public DocumentAuthor() { }
        public string FullName { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.DocumentAuthor System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.DocumentAuthor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.DocumentAuthor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.DocumentAuthor System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.DocumentAuthor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.DocumentAuthor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.DocumentAuthor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentContent : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.DocumentContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.DocumentContent>
    {
        public DocumentContent(Azure.Health.Insights.ClinicalMatching.DocumentContentSourceType sourceType, string value) { }
        public Azure.Health.Insights.ClinicalMatching.DocumentContentSourceType SourceType { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.DocumentContent System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.DocumentContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.DocumentContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.DocumentContent System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.DocumentContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.DocumentContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.DocumentContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentContentSourceType : System.IEquatable<Azure.Health.Insights.ClinicalMatching.DocumentContentSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentContentSourceType(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.DocumentContentSourceType Inline { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.DocumentContentSourceType Reference { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.DocumentContentSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.DocumentContentSourceType left, Azure.Health.Insights.ClinicalMatching.DocumentContentSourceType right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.DocumentContentSourceType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.DocumentContentSourceType left, Azure.Health.Insights.ClinicalMatching.DocumentContentSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentType : System.IEquatable<Azure.Health.Insights.ClinicalMatching.DocumentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentType(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.DocumentType Dicom { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.DocumentType FhirBundle { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.DocumentType GenomicSequencing { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.DocumentType Note { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.DocumentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.DocumentType left, Azure.Health.Insights.ClinicalMatching.DocumentType right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.DocumentType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.DocumentType left, Azure.Health.Insights.ClinicalMatching.DocumentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Encounter : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.Encounter>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.Encounter>
    {
        public Encounter(string id) { }
        public Azure.Health.Insights.ClinicalMatching.EncounterClass? Class { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.TimePeriod Period { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.Encounter System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.Encounter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.Encounter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.Encounter System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.Encounter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.Encounter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.Encounter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncounterClass : System.IEquatable<Azure.Health.Insights.ClinicalMatching.EncounterClass>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncounterClass(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.EncounterClass Ambulatory { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.EncounterClass Emergency { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.EncounterClass HealthHome { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.EncounterClass InPatient { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.EncounterClass Observation { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.EncounterClass Virtual { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.EncounterClass other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.EncounterClass left, Azure.Health.Insights.ClinicalMatching.EncounterClass right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.EncounterClass (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.EncounterClass left, Azure.Health.Insights.ClinicalMatching.EncounterClass right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExtendedClinicalCodedElement : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement>
    {
        internal ExtendedClinicalCodedElement() { }
        public string Category { get { throw null; } }
        public string Code { get { throw null; } }
        public string Name { get { throw null; } }
        public string SemanticType { get { throw null; } }
        public string System { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Annotation : Azure.Health.Insights.ClinicalMatching.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Annotation>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Annotation>
    {
        public FhirR4Annotation(string text) { }
        public string AuthorString { get { throw null; } set { } }
        public string Text { get { throw null; } }
        public string Time { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.FhirR4Annotation System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Annotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Annotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.FhirR4Annotation System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Annotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Annotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Annotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4CodeableConcept : Azure.Health.Insights.ClinicalMatching.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept>
    {
        public FhirR4CodeableConcept() { }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4Coding> Coding { get { throw null; } }
        public string Text { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Coding : Azure.Health.Insights.ClinicalMatching.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Coding>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Coding>
    {
        public FhirR4Coding() { }
        public string Code { get { throw null; } set { } }
        public string Display { get { throw null; } set { } }
        public string System { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.FhirR4Coding System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Coding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Coding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.FhirR4Coding System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Coding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Coding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Coding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4ContactDetail : Azure.Health.Insights.ClinicalMatching.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4ContactDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4ContactDetail>
    {
        public FhirR4ContactDetail() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4ContactPoint> Telecom { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.FhirR4ContactDetail System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4ContactDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4ContactDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.FhirR4ContactDetail System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4ContactDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4ContactDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4ContactDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4ContactPoint : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4ContactPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4ContactPoint>
    {
        public FhirR4ContactPoint() { }
        public Azure.Health.Insights.ClinicalMatching.FhirR4Period Period { get { throw null; } set { } }
        public int? Rank { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.ContactPointSystem? System { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.ContactPointUse? Use { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.FhirR4ContactPoint System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4ContactPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4ContactPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.FhirR4ContactPoint System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4ContactPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4ContactPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4ContactPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class FhirR4DomainResource : Azure.Health.Insights.ClinicalMatching.FhirR4Resource, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4DomainResource>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4DomainResource>
    {
        protected FhirR4DomainResource(string resourceType) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4Resource> Contained { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4Extension> Extension { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4Extension> ModifierExtension { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4Narrative Text { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.FhirR4DomainResource System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4DomainResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4DomainResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.FhirR4DomainResource System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4DomainResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4DomainResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4DomainResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Element : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Element>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Element>
    {
        internal FhirR4Element() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.ClinicalMatching.FhirR4Extension> Extension { get { throw null; } }
        public string Id { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.FhirR4Element System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Element>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Element>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.FhirR4Element System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Element>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Element>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Element>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Extendible : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Extendible>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Extendible>
    {
        public FhirR4Extendible() { }
        public Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept Code { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4Extension> Extension { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.FhirR4Extendible System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Extendible>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Extendible>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.FhirR4Extendible System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Extendible>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Extendible>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Extendible>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Extension : Azure.Health.Insights.ClinicalMatching.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Extension>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Extension>
    {
        public FhirR4Extension(string url) { }
        public string Url { get { throw null; } }
        public bool? ValueBoolean { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept ValueCodeableConcept { get { throw null; } set { } }
        public string ValueDateTime { get { throw null; } set { } }
        public int? ValueInteger { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4Period ValuePeriod { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4Quantity ValueQuantity { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4Range ValueRange { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4Ratio ValueRatio { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4Reference ValueReference { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4SampledData ValueSampledData { get { throw null; } set { } }
        public string ValueString { get { throw null; } set { } }
        public System.TimeSpan? ValueTime { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.FhirR4Extension System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Extension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Extension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.FhirR4Extension System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Extension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Extension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Extension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Identifier : Azure.Health.Insights.ClinicalMatching.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Identifier>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Identifier>
    {
        public FhirR4Identifier() { }
        public Azure.Health.Insights.ClinicalMatching.FhirR4Reference Assigner { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4Period Period { get { throw null; } set { } }
        public string System { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept Type { get { throw null; } set { } }
        public string Use { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.FhirR4Identifier System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Identifier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Identifier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.FhirR4Identifier System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Identifier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Identifier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Identifier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Meta : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Meta>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Meta>
    {
        public FhirR4Meta() { }
        public string LastUpdated { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Profile { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4Coding> Security { get { throw null; } }
        public string Source { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4Coding> Tag { get { throw null; } }
        public string VersionId { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.FhirR4Meta System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Meta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Meta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.FhirR4Meta System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Meta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Meta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Meta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Narrative : Azure.Health.Insights.ClinicalMatching.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Narrative>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Narrative>
    {
        public FhirR4Narrative(string status, string div) { }
        public string Div { get { throw null; } }
        public string Status { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.FhirR4Narrative System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Narrative>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Narrative>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.FhirR4Narrative System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Narrative>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Narrative>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Narrative>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Period : Azure.Health.Insights.ClinicalMatching.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Period>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Period>
    {
        public FhirR4Period() { }
        public string End { get { throw null; } set { } }
        public string Start { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.FhirR4Period System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Period>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Period>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.FhirR4Period System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Period>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Period>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Period>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Quantity : Azure.Health.Insights.ClinicalMatching.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Quantity>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Quantity>
    {
        public FhirR4Quantity() { }
        public string Code { get { throw null; } set { } }
        public string Comparator { get { throw null; } set { } }
        public string System { get { throw null; } set { } }
        public string Unit { get { throw null; } set { } }
        public double? Value { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.FhirR4Quantity System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Quantity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Quantity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.FhirR4Quantity System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Quantity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Quantity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Quantity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Range : Azure.Health.Insights.ClinicalMatching.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Range>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Range>
    {
        public FhirR4Range() { }
        public Azure.Health.Insights.ClinicalMatching.FhirR4Quantity High { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4Quantity Low { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.FhirR4Range System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Range>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Range>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.FhirR4Range System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Range>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Range>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Range>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Ratio : Azure.Health.Insights.ClinicalMatching.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Ratio>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Ratio>
    {
        public FhirR4Ratio() { }
        public Azure.Health.Insights.ClinicalMatching.FhirR4Quantity Denominator { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4Quantity Numerator { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.FhirR4Ratio System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Ratio>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Ratio>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.FhirR4Ratio System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Ratio>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Ratio>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Ratio>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Reference : Azure.Health.Insights.ClinicalMatching.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Reference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Reference>
    {
        public FhirR4Reference() { }
        public string Display { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4Identifier Identifier { get { throw null; } set { } }
        public string Reference { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.FhirR4Reference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Reference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Reference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.FhirR4Reference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Reference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Reference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Reference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4ResearchStudy : Azure.Health.Insights.ClinicalMatching.FhirR4DomainResource, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4ResearchStudy>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4ResearchStudy>
    {
        public FhirR4ResearchStudy(Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType status) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.ResearchStudyArm> Arm { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept> Category { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept> Condition { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4ContactDetail> Contact { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4Reference> Enrollment { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept> Focus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4Identifier> Identifier { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept> Keyword { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept> Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4Annotation> Note { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.ResearchStudyObjective> Objective { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4Reference> PartOf { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4Period Period { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept Phase { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept PrimaryPurposeType { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4Reference PrincipalInvestigator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4Reference> Protocol { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept ReasonStopped { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4Reference> Site { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4Reference Sponsor { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType Status { get { throw null; } }
        public string Title { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.FhirR4ResearchStudy System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4ResearchStudy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4ResearchStudy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.FhirR4ResearchStudy System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4ResearchStudy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4ResearchStudy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4ResearchStudy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4Resource : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Resource>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Resource>
    {
        public FhirR4Resource(string resourceType) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public string ImplicitRules { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4Meta Meta { get { throw null; } set { } }
        public string ResourceType { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.FhirR4Resource System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Resource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4Resource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.FhirR4Resource System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Resource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Resource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4Resource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirR4SampledData : Azure.Health.Insights.ClinicalMatching.FhirR4Element, System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4SampledData>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4SampledData>
    {
        public FhirR4SampledData(Azure.Health.Insights.ClinicalMatching.FhirR4Quantity origin, double period, int dimensions) { }
        public string Data { get { throw null; } set { } }
        public int Dimensions { get { throw null; } }
        public double? Factor { get { throw null; } set { } }
        public double? LowerLimit { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4Quantity Origin { get { throw null; } }
        public double Period { get { throw null; } }
        public double? UpperLimit { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.FhirR4SampledData System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4SampledData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.FhirR4SampledData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.FhirR4SampledData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4SampledData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4SampledData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.FhirR4SampledData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GeographicArea : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.GeographicArea>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.GeographicArea>
    {
        public GeographicArea(Azure.Health.Insights.ClinicalMatching.GeoJsonType type, Azure.Health.Insights.ClinicalMatching.AreaGeometry geometry, Azure.Health.Insights.ClinicalMatching.AreaProperties properties) { }
        public Azure.Health.Insights.ClinicalMatching.AreaGeometry Geometry { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.AreaProperties Properties { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.GeoJsonType Type { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.GeographicArea System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.GeographicArea>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.GeographicArea>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.GeographicArea System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.GeographicArea>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.GeographicArea>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.GeographicArea>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GeographicLocation : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.GeographicLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.GeographicLocation>
    {
        public GeographicLocation(string countryOrRegion) { }
        public string City { get { throw null; } set { } }
        public string CountryOrRegion { get { throw null; } }
        public string State { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.GeographicLocation System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.GeographicLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.GeographicLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.GeographicLocation System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.GeographicLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.GeographicLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.GeographicLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeoJsonGeometryType : System.IEquatable<Azure.Health.Insights.ClinicalMatching.GeoJsonGeometryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GeoJsonGeometryType(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.GeoJsonGeometryType Point { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.GeoJsonGeometryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.GeoJsonGeometryType left, Azure.Health.Insights.ClinicalMatching.GeoJsonGeometryType right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.GeoJsonGeometryType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.GeoJsonGeometryType left, Azure.Health.Insights.ClinicalMatching.GeoJsonGeometryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeoJsonPropertiesSubType : System.IEquatable<Azure.Health.Insights.ClinicalMatching.GeoJsonPropertiesSubType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GeoJsonPropertiesSubType(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.GeoJsonPropertiesSubType Circle { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.GeoJsonPropertiesSubType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.GeoJsonPropertiesSubType left, Azure.Health.Insights.ClinicalMatching.GeoJsonPropertiesSubType right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.GeoJsonPropertiesSubType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.GeoJsonPropertiesSubType left, Azure.Health.Insights.ClinicalMatching.GeoJsonPropertiesSubType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeoJsonType : System.IEquatable<Azure.Health.Insights.ClinicalMatching.GeoJsonType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GeoJsonType(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.GeoJsonType Feature { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.GeoJsonType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.GeoJsonType left, Azure.Health.Insights.ClinicalMatching.GeoJsonType right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.GeoJsonType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.GeoJsonType left, Azure.Health.Insights.ClinicalMatching.GeoJsonType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class HealthInsightsClinicalMatchingModelFactory
    {
        public static Azure.Health.Insights.ClinicalMatching.ClinicalCodedElement ClinicalCodedElement(string system = null, string code = null, string name = null, string value = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence ClinicalNoteEvidence(string id = null, string text = null, int offset = 0, int length = 0) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata ClinicalTrialMetadata(System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.ClinicalTrialPhase> phases = null, Azure.Health.Insights.ClinicalMatching.ClinicalTrialStudyType? studyType = default(Azure.Health.Insights.ClinicalMatching.ClinicalTrialStudyType?), Azure.Health.Insights.ClinicalMatching.ClinicalTrialRecruitmentStatus? recruitmentStatus = default(Azure.Health.Insights.ClinicalMatching.ClinicalTrialRecruitmentStatus?), System.Collections.Generic.IEnumerable<string> conditions = null, System.Collections.Generic.IEnumerable<string> sponsors = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.ContactDetails> contacts = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility> facilities = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility ClinicalTrialResearchFacility(string name = null, string city = null, string state = null, string countryOrRegion = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.ContactDetails ContactDetails(string name = null, string email = null, string phone = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.Encounter Encounter(string id = null, Azure.Health.Insights.ClinicalMatching.TimePeriod period = null, Azure.Health.Insights.ClinicalMatching.EncounterClass? @class = default(Azure.Health.Insights.ClinicalMatching.EncounterClass?)) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement ExtendedClinicalCodedElement(string system = null, string code = null, string name = null, string value = null, string semanticType = null, string category = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.FhirR4Annotation FhirR4Annotation(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Extension> extension = null, string authorString = null, string time = null, string text = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept FhirR4CodeableConcept(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Extension> extension = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Coding> coding = null, string text = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.FhirR4Coding FhirR4Coding(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Extension> extension = null, string system = null, string version = null, string code = null, string display = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.FhirR4ContactDetail FhirR4ContactDetail(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Extension> extension = null, string name = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4ContactPoint> telecom = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.FhirR4Element FhirR4Element(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Extension> extension = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.FhirR4Extension FhirR4Extension(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Extension> extension = null, string url = null, Azure.Health.Insights.ClinicalMatching.FhirR4Quantity valueQuantity = null, Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept valueCodeableConcept = null, string valueString = null, bool? valueBoolean = default(bool?), int? valueInteger = default(int?), Azure.Health.Insights.ClinicalMatching.FhirR4Range valueRange = null, Azure.Health.Insights.ClinicalMatching.FhirR4Ratio valueRatio = null, Azure.Health.Insights.ClinicalMatching.FhirR4SampledData valueSampledData = null, System.TimeSpan? valueTime = default(System.TimeSpan?), string valueDateTime = null, Azure.Health.Insights.ClinicalMatching.FhirR4Period valuePeriod = null, Azure.Health.Insights.ClinicalMatching.FhirR4Reference valueReference = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.FhirR4Identifier FhirR4Identifier(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Extension> extension = null, string use = null, Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept type = null, string system = null, string value = null, Azure.Health.Insights.ClinicalMatching.FhirR4Period period = null, Azure.Health.Insights.ClinicalMatching.FhirR4Reference assigner = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.FhirR4Narrative FhirR4Narrative(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Extension> extension = null, string status = null, string div = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.FhirR4Period FhirR4Period(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Extension> extension = null, string start = null, string end = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.FhirR4Quantity FhirR4Quantity(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Extension> extension = null, double? value = default(double?), string comparator = null, string unit = null, string system = null, string code = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.FhirR4Range FhirR4Range(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Extension> extension = null, Azure.Health.Insights.ClinicalMatching.FhirR4Quantity low = null, Azure.Health.Insights.ClinicalMatching.FhirR4Quantity high = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.FhirR4Ratio FhirR4Ratio(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Extension> extension = null, Azure.Health.Insights.ClinicalMatching.FhirR4Quantity numerator = null, Azure.Health.Insights.ClinicalMatching.FhirR4Quantity denominator = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.FhirR4Reference FhirR4Reference(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Extension> extension = null, string reference = null, string type = null, Azure.Health.Insights.ClinicalMatching.FhirR4Identifier identifier = null, string display = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.FhirR4ResearchStudy FhirR4ResearchStudy(string id = null, Azure.Health.Insights.ClinicalMatching.FhirR4Meta meta = null, string implicitRules = null, string language = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null, Azure.Health.Insights.ClinicalMatching.FhirR4Narrative text = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Resource> contained = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Extension> extension = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Extension> modifierExtension = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Identifier> identifier = null, string title = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Reference> protocol = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Reference> partOf = null, Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType status = default(Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType), Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept primaryPurposeType = null, Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept phase = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept> category = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept> focus = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept> condition = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4ContactDetail> contact = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept> keyword = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept> location = null, string description = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Reference> enrollment = null, Azure.Health.Insights.ClinicalMatching.FhirR4Period period = null, Azure.Health.Insights.ClinicalMatching.FhirR4Reference sponsor = null, Azure.Health.Insights.ClinicalMatching.FhirR4Reference principalInvestigator = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Reference> site = null, Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept reasonStopped = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Annotation> note = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.ResearchStudyArm> arm = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.ResearchStudyObjective> objective = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.FhirR4Resource FhirR4Resource(string resourceType = null, string id = null, Azure.Health.Insights.ClinicalMatching.FhirR4Meta meta = null, string implicitRules = null, string language = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.FhirR4SampledData FhirR4SampledData(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.FhirR4Extension> extension = null, Azure.Health.Insights.ClinicalMatching.FhirR4Quantity origin = null, double period = 0, double? factor = default(double?), double? lowerLimit = default(double?), double? upperLimit = default(double?), int dimensions = 0, string data = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.GeographicLocation GeographicLocation(string city = null, string state = null, string countryOrRegion = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.PatientDocument PatientDocument(Azure.Health.Insights.ClinicalMatching.DocumentType type = default(Azure.Health.Insights.ClinicalMatching.DocumentType), Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType? clinicalType = default(Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType?), string id = null, string language = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.DocumentAuthor> authors = null, Azure.Health.Insights.ClinicalMatching.SpecialtyType? specialtyType = default(Azure.Health.Insights.ClinicalMatching.SpecialtyType?), Azure.Health.Insights.ClinicalMatching.DocumentAdministrativeMetadata administrativeMetadata = null, Azure.Health.Insights.ClinicalMatching.DocumentContent content = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.PatientRecord PatientRecord(string id = null, Azure.Health.Insights.ClinicalMatching.PatientDetails info = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.Encounter> encounters = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.PatientDocument> patientDocuments = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.ResearchStudyArm ResearchStudyArm(string name = null, Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept type = null, string description = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.ResearchStudyObjective ResearchStudyObjective(string name = null, Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept type = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.TrialMatcherInference TrialMatcherInference(Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceType type = default(Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceType), string value = null, string description = null, float? confidenceScore = default(float?), System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence> evidence = null, string clinicalTrialId = null, Azure.Health.Insights.ClinicalMatching.ClinicalTrialSource? source = default(Azure.Health.Insights.ClinicalMatching.ClinicalTrialSource?), Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata metadata = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence TrialMatcherInferenceEvidence(string eligibilityCriteriaEvidence = null, Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence patientDataEvidence = null, Azure.Health.Insights.ClinicalMatching.ClinicalCodedElement patientInfoEvidence = null, float? importance = default(float?)) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceResult TrialMatcherInferenceResult(System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult> patientResults = null, string modelVersion = null, System.DateTimeOffset? knowledgeGraphLastUpdateDate = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration TrialMatcherModelConfiguration(bool? verbose = default(bool?), bool? includeEvidence = default(bool?), Azure.Health.Insights.ClinicalMatching.ClinicalTrials clinicalTrials = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult TrialMatcherPatientResult(string patientId = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.TrialMatcherInference> inferences = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement> neededClinicalInfo = null) { throw null; }
    }
    public partial class PatientDetails : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.PatientDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientDetails>
    {
        public PatientDetails() { }
        public System.DateTimeOffset? BirthDate { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.FhirR4Resource> ClinicalInfo { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.PatientSex? Sex { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.PatientDetails System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.PatientDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.PatientDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.PatientDetails System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatientDocument : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.PatientDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientDocument>
    {
        public PatientDocument(Azure.Health.Insights.ClinicalMatching.DocumentType type, string id, Azure.Health.Insights.ClinicalMatching.DocumentContent content) { }
        public Azure.Health.Insights.ClinicalMatching.DocumentAdministrativeMetadata AdministrativeMetadata { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.DocumentAuthor> Authors { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType? ClinicalType { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.DocumentContent Content { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.SpecialtyType? SpecialtyType { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.DocumentType Type { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.PatientDocument System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.PatientDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.PatientDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.PatientDocument System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatientRecord : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.PatientRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientRecord>
    {
        public PatientRecord(string id) { }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.Encounter> Encounters { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.PatientDetails Info { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.PatientDocument> PatientDocuments { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.PatientRecord System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.PatientRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.PatientRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.PatientRecord System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PatientSex : System.IEquatable<Azure.Health.Insights.ClinicalMatching.PatientSex>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatientSex(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.PatientSex Female { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.PatientSex Male { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.PatientSex Unspecified { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.PatientSex other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.PatientSex left, Azure.Health.Insights.ClinicalMatching.PatientSex right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.PatientSex (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.PatientSex left, Azure.Health.Insights.ClinicalMatching.PatientSex right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResearchStudyArm : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ResearchStudyArm>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ResearchStudyArm>
    {
        public ResearchStudyArm(string name) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept Type { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.ResearchStudyArm System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ResearchStudyArm>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ResearchStudyArm>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ResearchStudyArm System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ResearchStudyArm>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ResearchStudyArm>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ResearchStudyArm>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResearchStudyObjective : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ResearchStudyObjective>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ResearchStudyObjective>
    {
        public ResearchStudyObjective(string name) { }
        public string Name { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.FhirR4CodeableConcept Type { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.ResearchStudyObjective System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ResearchStudyObjective>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ResearchStudyObjective>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ResearchStudyObjective System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ResearchStudyObjective>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ResearchStudyObjective>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ResearchStudyObjective>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResearchStudyStatusCodeType : System.IEquatable<Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResearchStudyStatusCodeType(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType Active { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType AdministrativelyCompleted { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType Approved { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType ClosedToAccrual { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType ClosedToAccrualAndIntervention { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType Completed { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType Disapproved { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType InReview { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType TemporarilyClosedToAccrual { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType TemporarilyClosedToAccrualAndIntervention { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType Withdrawn { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType left, Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType left, Azure.Health.Insights.ClinicalMatching.ResearchStudyStatusCodeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpecialtyType : System.IEquatable<Azure.Health.Insights.ClinicalMatching.SpecialtyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpecialtyType(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.SpecialtyType Pathology { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.SpecialtyType Radiology { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.SpecialtyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.SpecialtyType left, Azure.Health.Insights.ClinicalMatching.SpecialtyType right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.SpecialtyType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.SpecialtyType left, Azure.Health.Insights.ClinicalMatching.SpecialtyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TimePeriod : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TimePeriod>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TimePeriod>
    {
        public TimePeriod() { }
        public System.DateTimeOffset? End { get { throw null; } set { } }
        public System.DateTimeOffset? Start { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.TimePeriod System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TimePeriod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TimePeriod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.TimePeriod System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TimePeriod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TimePeriod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TimePeriod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrialMatcherData : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherData>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherData>
    {
        public TrialMatcherData(System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.PatientRecord> patients) { }
        public Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration Configuration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.PatientRecord> Patients { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherData System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrialMatcherInference : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInference>
    {
        internal TrialMatcherInference() { }
        public string ClinicalTrialId { get { throw null; } }
        public float? ConfidenceScore { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence> Evidence { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata Metadata { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.ClinicalTrialSource? Source { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceType Type { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherInference System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherInference System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrialMatcherInferenceEvidence : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence>
    {
        internal TrialMatcherInferenceEvidence() { }
        public string EligibilityCriteriaEvidence { get { throw null; } }
        public float? Importance { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence PatientDataEvidence { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.ClinicalCodedElement PatientInfoEvidence { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrialMatcherInferenceResult : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceResult>
    {
        internal TrialMatcherInferenceResult() { }
        public System.DateTimeOffset? KnowledgeGraphLastUpdateDate { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult> PatientResults { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceResult System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceResult System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrialMatcherInferenceType : System.IEquatable<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrialMatcherInferenceType(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceType TrialEligibility { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceType left, Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceType right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceType left, Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrialMatcherModelConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration>
    {
        public TrialMatcherModelConfiguration(Azure.Health.Insights.ClinicalMatching.ClinicalTrials clinicalTrials) { }
        public Azure.Health.Insights.ClinicalMatching.ClinicalTrials ClinicalTrials { get { throw null; } }
        public bool? IncludeEvidence { get { throw null; } set { } }
        public bool? Verbose { get { throw null; } set { } }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrialMatcherPatientResult : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult>
    {
        internal TrialMatcherPatientResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.ClinicalMatching.TrialMatcherInference> Inferences { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement> NeededClinicalInfo { get { throw null; } }
        public string PatientId { get { throw null; } }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class HealthInsightsClinicalMatchingClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Insights.ClinicalMatching.ClinicalMatchingClient, Azure.Health.Insights.ClinicalMatching.ClinicalMatchingClientOptions> AddClinicalMatchingClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Insights.ClinicalMatching.ClinicalMatchingClient, Azure.Health.Insights.ClinicalMatching.ClinicalMatchingClientOptions> AddClinicalMatchingClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
