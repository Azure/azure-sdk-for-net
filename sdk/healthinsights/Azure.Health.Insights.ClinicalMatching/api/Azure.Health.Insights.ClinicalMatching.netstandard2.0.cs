namespace Azure.Health.Insights.ClinicalMatching
{
    public partial class AcceptedAge
    {
        public AcceptedAge(Azure.Health.Insights.ClinicalMatching.AgeUnit unit, float value) { }
        public Azure.Health.Insights.ClinicalMatching.AgeUnit Unit { get { throw null; } }
        public float Value { get { throw null; } }
    }
    public partial class AcceptedAgeRange
    {
        public AcceptedAgeRange() { }
        public Azure.Health.Insights.ClinicalMatching.AcceptedAge MaximumAge { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.AcceptedAge MinimumAge { get { throw null; } set { } }
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
    public partial class AreaGeometry
    {
        public AreaGeometry(Azure.Health.Insights.ClinicalMatching.GeoJsonGeometryType type, System.Collections.Generic.IEnumerable<float> coordinates) { }
        public System.Collections.Generic.IList<float> Coordinates { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.GeoJsonGeometryType Type { get { throw null; } }
    }
    public partial class AreaProperties
    {
        public AreaProperties(Azure.Health.Insights.ClinicalMatching.GeoJsonPropertiesSubType subType, double radius) { }
        public double Radius { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.GeoJsonPropertiesSubType SubType { get { throw null; } }
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
        public virtual Azure.Operation<System.BinaryData> MatchTrials(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string repeatabilityRequestId = null, System.DateTimeOffset? repeatabilityFirstSent = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.Health.Insights.ClinicalMatching.TrialMatcherResult> MatchTrials(Azure.WaitUntil waitUntil, Azure.Health.Insights.ClinicalMatching.TrialMatcherData trialMatcherData, string repeatabilityRequestId = null, System.DateTimeOffset? repeatabilityFirstSent = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> MatchTrialsAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string repeatabilityRequestId = null, System.DateTimeOffset? repeatabilityFirstSent = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.Health.Insights.ClinicalMatching.TrialMatcherResult>> MatchTrialsAsync(Azure.WaitUntil waitUntil, Azure.Health.Insights.ClinicalMatching.TrialMatcherData trialMatcherData, string repeatabilityRequestId = null, System.DateTimeOffset? repeatabilityFirstSent = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClinicalMatchingClientOptions : Azure.Core.ClientOptions
    {
        public ClinicalMatchingClientOptions(Azure.Health.Insights.ClinicalMatching.ClinicalMatchingClientOptions.ServiceVersion version = Azure.Health.Insights.ClinicalMatching.ClinicalMatchingClientOptions.ServiceVersion.V2023_03_01_Preview) { }
        public enum ServiceVersion
        {
            V2023_03_01_Preview = 1,
        }
    }
    public partial class ClinicalNoteEvidence
    {
        internal ClinicalNoteEvidence() { }
        public string Id { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Text { get { throw null; } }
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
    public partial class ClinicalTrialDemographics
    {
        public ClinicalTrialDemographics() { }
        public Azure.Health.Insights.ClinicalMatching.AcceptedAgeRange AcceptedAgeRange { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.ClinicalTrialAcceptedSex? AcceptedSex { get { throw null; } set { } }
    }
    public partial class ClinicalTrialDetails
    {
        public ClinicalTrialDetails(string id, Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata metadata) { }
        public Azure.Health.Insights.ClinicalMatching.ClinicalTrialDemographics Demographics { get { throw null; } set { } }
        public string EligibilityCriteriaText { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.ClinicalTrialMetadata Metadata { get { throw null; } }
    }
    public partial class ClinicalTrialMetadata
    {
        public ClinicalTrialMetadata(System.Collections.Generic.IEnumerable<string> conditions) { }
        public System.Collections.Generic.IList<string> Conditions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.ContactDetails> Contacts { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.ClinicalTrialResearchFacility> Facilities { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.ClinicalTrialPhase> Phases { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.ClinicalTrialRecruitmentStatus? RecruitmentStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sponsors { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.ClinicalTrialStudyType? StudyType { get { throw null; } set { } }
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
    public partial class ClinicalTrialRegistryFilter
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
    }
    public partial class ClinicalTrialResearchFacility
    {
        public ClinicalTrialResearchFacility(string name, string countryOrRegion) { }
        public string City { get { throw null; } set { } }
        public string CountryOrRegion { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
    }
    public partial class ClinicalTrials
    {
        public ClinicalTrials() { }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.ClinicalTrialDetails> CustomTrials { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.ClinicalTrialRegistryFilter> RegistryFilters { get { throw null; } }
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
    public partial class ContactDetails
    {
        public ContactDetails() { }
        public string Email { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
    }
    public partial class DocumentContent
    {
        public DocumentContent(Azure.Health.Insights.ClinicalMatching.DocumentContentSourceType sourceType, string value) { }
        public Azure.Health.Insights.ClinicalMatching.DocumentContentSourceType SourceType { get { throw null; } }
        public string Value { get { throw null; } }
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
    public partial class ExtendedClinicalCodedElement
    {
        internal ExtendedClinicalCodedElement() { }
        public string Category { get { throw null; } }
        public string Code { get { throw null; } }
        public string Name { get { throw null; } }
        public string SemanticType { get { throw null; } }
        public string System { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class GeographicArea
    {
        public GeographicArea(Azure.Health.Insights.ClinicalMatching.GeoJsonType type, Azure.Health.Insights.ClinicalMatching.AreaGeometry geometry, Azure.Health.Insights.ClinicalMatching.AreaProperties properties) { }
        public Azure.Health.Insights.ClinicalMatching.AreaGeometry Geometry { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.AreaProperties Properties { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.GeoJsonType Type { get { throw null; } }
    }
    public partial class GeographicLocation
    {
        public GeographicLocation(string countryOrRegion) { }
        public string City { get { throw null; } set { } }
        public string CountryOrRegion { get { throw null; } }
        public string State { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.Health.Insights.ClinicalMatching.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.Health.Insights.ClinicalMatching.JobStatus Failed { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.JobStatus NotStarted { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.JobStatus PartiallyCompleted { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.JobStatus Running { get { throw null; } }
        public static Azure.Health.Insights.ClinicalMatching.JobStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.Health.Insights.ClinicalMatching.JobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Insights.ClinicalMatching.JobStatus left, Azure.Health.Insights.ClinicalMatching.JobStatus right) { throw null; }
        public static implicit operator Azure.Health.Insights.ClinicalMatching.JobStatus (string value) { throw null; }
        public static bool operator !=(Azure.Health.Insights.ClinicalMatching.JobStatus left, Azure.Health.Insights.ClinicalMatching.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PatientDocument
    {
        public PatientDocument(Azure.Health.Insights.ClinicalMatching.DocumentType type, string id, Azure.Health.Insights.ClinicalMatching.DocumentContent content) { }
        public Azure.Health.Insights.ClinicalMatching.ClinicalDocumentType? ClinicalType { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.DocumentContent Content { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public Azure.Health.Insights.ClinicalMatching.DocumentType Type { get { throw null; } }
    }
    public partial class PatientInfo
    {
        public PatientInfo() { }
        public System.DateTimeOffset? BirthDate { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.ClinicalCodedElement> ClinicalInfo { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.PatientInfoSex? Sex { get { throw null; } set { } }
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
    public partial class PatientRecord
    {
        public PatientRecord(string id) { }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.PatientDocument> Data { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.PatientInfo Info { get { throw null; } set { } }
    }
    public partial class TrialMatcherData
    {
        public TrialMatcherData(System.Collections.Generic.IEnumerable<Azure.Health.Insights.ClinicalMatching.PatientRecord> patients) { }
        public Azure.Health.Insights.ClinicalMatching.TrialMatcherModelConfiguration Configuration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Health.Insights.ClinicalMatching.PatientRecord> Patients { get { throw null; } }
    }
    public partial class TrialMatcherInference
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
    }
    public partial class TrialMatcherInferenceEvidence
    {
        internal TrialMatcherInferenceEvidence() { }
        public string EligibilityCriteriaEvidence { get { throw null; } }
        public float? Importance { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.ClinicalNoteEvidence PatientDataEvidence { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.ClinicalCodedElement PatientInfoEvidence { get { throw null; } }
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
    public partial class TrialMatcherModelConfiguration
    {
        public TrialMatcherModelConfiguration(Azure.Health.Insights.ClinicalMatching.ClinicalTrials clinicalTrials) { }
        public Azure.Health.Insights.ClinicalMatching.ClinicalTrials ClinicalTrials { get { throw null; } }
        public bool? IncludeEvidence { get { throw null; } set { } }
        public bool? Verbose { get { throw null; } set { } }
    }
    public partial class TrialMatcherPatientResult
    {
        internal TrialMatcherPatientResult() { }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.ClinicalMatching.TrialMatcherInference> Inferences { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.ClinicalMatching.ExtendedClinicalCodedElement> NeededClinicalInfo { get { throw null; } }
    }
    public partial class TrialMatcherResult
    {
        internal TrialMatcherResult() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdateDateTime { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.TrialMatcherResults Results { get { throw null; } }
        public Azure.Health.Insights.ClinicalMatching.JobStatus Status { get { throw null; } }
    }
    public partial class TrialMatcherResults
    {
        internal TrialMatcherResults() { }
        public System.DateTimeOffset? KnowledgeGraphLastUpdateDate { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Insights.ClinicalMatching.TrialMatcherPatientResult> Patients { get { throw null; } }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AzureHealthInsightsClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Insights.ClinicalMatching.ClinicalMatchingClient, Azure.Health.Insights.ClinicalMatching.ClinicalMatchingClientOptions> AddClinicalMatchingClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Insights.ClinicalMatching.ClinicalMatchingClient, Azure.Health.Insights.ClinicalMatching.ClinicalMatchingClientOptions> AddClinicalMatchingClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
