namespace Azure.Health.Insights.ClinicalMatching
{
    public partial class AcceptedAge : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.AcceptedAge>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.AcceptedAge>
    {
        public AcceptedAge(Azure.Health.Insights.ClinicalMatching.AgeUnit unit, float value) { }
        public Azure.Health.Insights.ClinicalMatching.AgeUnit Unit { get { throw null; } }
        public float Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.AcceptedAge System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.AcceptedAge>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.AcceptedAge>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.AcceptedAge System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.AcceptedAge>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.AcceptedAge>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.AcceptedAge>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcceptedAgeRange : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.AcceptedAgeRange>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.AcceptedAgeRange>
    {
        public AcceptedAgeRange() { }
        public Azure.Health.Insights.ClinicalMatching.AcceptedAge MaximumAge { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.AcceptedAge MinimumAge { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.AcceptedAgeRange System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.AcceptedAgeRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.AcceptedAgeRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.AcceptedAgeRange System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.AcceptedAgeRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.AcceptedAgeRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.AcceptedAgeRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgeUnit : System.IEquatable<Azure.Health.Insights.ClinicalMatching.AgeUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgeUnit(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.AgeUnit Days { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.AgeUnit Months { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.AgeUnit Years { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.AgeUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.AgeUnit left, Azure.Health.Insights.ClinicalMatching.AgeUnit right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.AgeUnit (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.AgeUnit left, Azure.Health.Insights.ClinicalMatching.AgeUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AreaGeometry : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.AreaGeometry>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.AreaGeometry>
    {
        public AreaGeometry(Azure.Health.Insights.ClinicalMatching.GeoJsonGeometryType type, System.Collections.Generic.IEnumerable<float> coordinates) { }
        public System.Collections.Generic.IList<float> Coordinates { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.GeoJsonGeometryType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.AreaProperties System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.AreaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.AreaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.AreaProperties System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.AreaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.AreaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.AreaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureHealthInsightsClinicalMatchingContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureHealthInsightsClinicalMatchingContext() { }
        public static Azure.Health.Insights.ClinicalMatching.AzureHealthInsightsClinicalMatchingContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ClinicalCodedElement : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalCodedElement>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalCodedElement>
    {
        public ClinicalCodedElement(string system, string code) { }
        public string Code { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string System { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType Imaging { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType Laboratory { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType Pathology { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType Procedure { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType Progress { get { throw null; } }
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
        public virtual Azure.Operation<Azure.Health.Insights.ClinicalMatching.TrialMatcherResults> MatchTrials(Azure.WaitUntil waitUntil, Azure.Health.Insights.ClinicalMatching.TrialMatcherData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> MatchTrialsAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.Health.Insights.ClinicalMatching.TrialMatcherResults>> MatchTrialsAsync(Azure.WaitUntil waitUntil, Azure.Health.Insights.ClinicalMatching.TrialMatcherData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClinicalMatchingClientOptions : Azure.Core.ClientOptions
    {
        public ClinicalMatchingClientOptions(Azure.Health.Insights.ClinicalMatching.ClinicalMatchingClientOptions.ServiceVersion version = Azure.Health.Insights.ClinicalMatching.ClinicalMatchingClientOptions.ServiceVersion.V2023_03_01_Preview) { }
        public enum ServiceVersion
        {
            V2023_03_01_Preview = 1,
        }
    }
    public partial class ClinicalNoteEvidence : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence>
    {
        internal ClinicalNoteEvidence() { }
        public string Id { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClinicalTrialAcceptedSex : System.IEquatable<Azure.Health.Insights.ClinicalMatching.ClinicalTrialAcceptedSex>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClinicalTrialAcceptedSex(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialAcceptedSex All { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialAcceptedSex Female { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialAcceptedSex Male { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.ClinicalTrialAcceptedSex other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.ClinicalTrialAcceptedSex left, Azure.Health.Insights.ClinicalMatching.ClinicalTrialAcceptedSex right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.ClinicalTrialAcceptedSex (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.ClinicalTrialAcceptedSex left, Azure.Health.Insights.ClinicalMatching.ClinicalTrialAcceptedSex right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClinicalTrialDemographics : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialDemographics>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialDemographics>
    {
        public ClinicalTrialDemographics() { }
        public Azure.Health.Insights.ClinicalMatching.AcceptedAgeRange AcceptedAgeRange { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.ClinicalTrialAcceptedSex? AcceptedSex { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ClinicalTrialDemographics System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialDemographics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialDemographics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ClinicalTrialDemographics System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialDemographics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialDemographics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialDemographics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClinicalTrialDetails : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialDetails>
    {
        public ClinicalTrialDetails(string id, Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata metadata) { }
        public Azure.Health.Insights.ClinicalMatching.ClinicalTrialDemographics Demographics { get { throw null; } set { } }
        public string EligibilityCriteriaText { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata Metadata { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ClinicalTrialDetails System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ClinicalTrialDetails System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClinicalTrialMetadata : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata>
    {
        public ClinicalTrialMetadata(System.Collections.Generic.IEnumerable<string> conditions) { }
        public System.Collections.Generic.IList<string> Conditions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.ContactDetails> Contacts { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility> Facilities { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.ClinicalTrialPhase> Phases { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.ClinicalTrialRecruitmentStatus? RecruitmentStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sponsors { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.ClinicalTrialStudyType? StudyType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ClinicalTrialRegistryFilter System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialRegistryFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialRegistryFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ClinicalTrialRegistryFilter System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialRegistryFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialRegistryFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialRegistryFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClinicalTrialResearchFacility : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility>
    {
        public ClinicalTrialResearchFacility(string name, string countryOrRegion) { }
        public string City { get { throw null; } set { } }
        public string CountryOrRegion { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClinicalTrials : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrials>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ClinicalTrials>
    {
        public ClinicalTrials() { }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.ClinicalTrialDetails> CustomTrials { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.ClinicalTrialRegistryFilter> RegistryFilters { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public ContactDetails() { }
        public string Email { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ContactDetails System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ContactDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ContactDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ContactDetails System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ContactDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ContactDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ContactDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentContent : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.DocumentContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.DocumentContent>
    {
        public DocumentContent(Azure.Health.Insights.ClinicalMatching.DocumentContentSourceType sourceType, string value) { }
        public Azure.Health.Insights.ClinicalMatching.DocumentContentSourceType SourceType { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class ExtendedClinicalCodedElement : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement>
    {
        internal ExtendedClinicalCodedElement() { }
        public string Category { get { throw null; } }
        public string Code { get { throw null; } }
        public string Name { get { throw null; } }
        public string SemanticType { get { throw null; } }
        public string System { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GeographicArea : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.GeographicArea>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.GeographicArea>
    {
        public GeographicArea(Azure.Health.Insights.ClinicalMatching.GeoJsonType type, Azure.Health.Insights.ClinicalMatching.AreaGeometry geometry, Azure.Health.Insights.ClinicalMatching.AreaProperties properties) { }
        public Azure.Health.Insights.ClinicalMatching.AreaGeometry Geometry { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.AreaProperties Properties { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.GeoJsonType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence ClinicalNoteEvidence(string id = null, string text = null, int offset = 0, int length = 0) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.ClinicalTrialDetails ClinicalTrialDetails(string id = null, string eligibilityCriteriaText = null, Azure.Health.Insights.ClinicalMatching.ClinicalTrialDemographics demographics = null, Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata metadata = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement ExtendedClinicalCodedElement(string system = null, string code = null, string name = null, string value = null, string semanticType = null, string category = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.GeographicLocation GeographicLocation(string city = null, string state = null, string countryOrRegion = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.PatientDocument PatientDocument(Azure.Health.Insights.ClinicalMatching.DocumentType type = default(Azure.Health.Insights.ClinicalMatching.DocumentType), Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType? clinicalType = default(Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType?), string id = null, string language = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), Azure.Health.Insights.ClinicalMatching.DocumentContent content = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.PatientRecord PatientRecord(string id = null, Azure.Health.Insights.ClinicalMatching.PatientInfo info = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.PatientDocument> data = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.TrialMatcherInference TrialMatcherInference(Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceType type = default(Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceType), string value = null, string description = null, float? confidenceScore = default(float?), System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence> evidence = null, string id = null, Azure.Health.Insights.ClinicalMatching.ClinicalTrialSource? source = default(Azure.Health.Insights.ClinicalMatching.ClinicalTrialSource?), Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata metadata = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence TrialMatcherInferenceEvidence(string eligibilityCriteriaEvidence = null, Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence patientDataEvidence = null, Azure.Health.Insights.ClinicalMatching.ClinicalCodedElement patientInfoEvidence = null, float? importance = default(float?)) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration TrialMatcherModelConfiguration(bool? verbose = default(bool?), bool? includeEvidence = default(bool?), Azure.Health.Insights.ClinicalMatching.ClinicalTrials clinicalTrials = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult TrialMatcherPatientResult(string id = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.TrialMatcherInference> inferences = null, System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement> neededClinicalInfo = null) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.TrialMatcherResults TrialMatcherResults(System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult> patients = null, string modelVersion = null, System.DateTimeOffset? knowledgeGraphLastUpdateDate = default(System.DateTimeOffset?)) { throw null; }
    }
    public partial class PatientDocument : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.PatientDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientDocument>
    {
        public PatientDocument(Azure.Health.Insights.ClinicalMatching.DocumentType type, string id, Azure.Health.Insights.ClinicalMatching.DocumentContent content) { }
        public Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType? ClinicalType { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.DocumentContent Content { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.DocumentType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.PatientDocument System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.PatientDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.PatientDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.PatientDocument System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatientInfo : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.PatientInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientInfo>
    {
        public PatientInfo() { }
        public System.DateTimeOffset? BirthDate { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.ClinicalCodedElement> ClinicalInfo { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.PatientInfoSex? Sex { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.PatientInfo System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.PatientInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.PatientInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.PatientInfo System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PatientInfoSex : System.IEquatable<Azure.Health.Insights.ClinicalMatching.PatientInfoSex>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatientInfoSex(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.PatientInfoSex Female { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.PatientInfoSex Male { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.PatientInfoSex Unspecified { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.PatientInfoSex other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.PatientInfoSex left, Azure.Health.Insights.ClinicalMatching.PatientInfoSex right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.PatientInfoSex (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.PatientInfoSex left, Azure.Health.Insights.ClinicalMatching.PatientInfoSex right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PatientRecord : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.PatientRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientRecord>
    {
        public PatientRecord(string id) { }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.PatientDocument> Data { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.PatientInfo Info { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.PatientRecord System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.PatientRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.PatientRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.PatientRecord System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.PatientRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrialMatcherData : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherData>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherData>
    {
        public TrialMatcherData(System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.PatientRecord> patients) { }
        public Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration Configuration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.PatientRecord> Patients { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherData System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrialMatcherInference : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInference>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInference>
    {
        internal TrialMatcherInference() { }
        public float? ConfidenceScore { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence> Evidence { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata Metadata { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.ClinicalTrialSource? Source { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceType Type { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherInferenceEvidence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrialMatcherPatientResult : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult>
    {
        internal TrialMatcherPatientResult() { }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.ClinicalMatching.TrialMatcherInference> Inferences { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement> NeededClinicalInfo { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrialMatcherResults : System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherResults>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherResults>
    {
        internal TrialMatcherResults() { }
        public System.DateTimeOffset? KnowledgeGraphLastUpdateDate { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult> Patients { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherResults System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Insights.ClinicalMatching.TrialMatcherResults System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Insights.ClinicalMatching.TrialMatcherResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class HealthInsightsClinicalMatchingClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Insights.ClinicalMatching.ClinicalMatchingClient, Azure.Health.Insights.ClinicalMatching.ClinicalMatchingClientOptions> AddClinicalMatchingClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Insights.ClinicalMatching.ClinicalMatchingClient, Azure.Health.Insights.ClinicalMatching.ClinicalMatchingClientOptions> AddClinicalMatchingClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
