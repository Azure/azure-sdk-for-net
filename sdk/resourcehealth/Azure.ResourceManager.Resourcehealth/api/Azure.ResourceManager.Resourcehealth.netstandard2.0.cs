namespace Azure.ResourceManager.Resourcehealth
{
    public partial class AvailabilityStatusData : Azure.ResourceManager.Models.ResourceData
    {
        internal AvailabilityStatusData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Resourcehealth.Models.AvailabilityStatusProperties Properties { get { throw null; } }
    }
    public partial class AvailabilityStatusResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvailabilityStatusResource() { }
        public virtual Azure.ResourceManager.Resourcehealth.AvailabilityStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resourcehealth.AvailabilityStatusResource> Get(string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resourcehealth.AvailabilityStatusResource>> GetAsync(string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ResourcehealthExtensions
    {
        public static Azure.ResourceManager.Resourcehealth.AvailabilityStatusResource GetAvailabilityStatus(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Resourcehealth.AvailabilityStatusResource GetAvailabilityStatusResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.Resourcehealth.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvailabilityStateValue : System.IEquatable<Azure.ResourceManager.Resourcehealth.Models.AvailabilityStateValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvailabilityStateValue(string value) { throw null; }
        public static Azure.ResourceManager.Resourcehealth.Models.AvailabilityStateValue Available { get { throw null; } }
        public static Azure.ResourceManager.Resourcehealth.Models.AvailabilityStateValue Degraded { get { throw null; } }
        public static Azure.ResourceManager.Resourcehealth.Models.AvailabilityStateValue Unavailable { get { throw null; } }
        public static Azure.ResourceManager.Resourcehealth.Models.AvailabilityStateValue Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resourcehealth.Models.AvailabilityStateValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resourcehealth.Models.AvailabilityStateValue left, Azure.ResourceManager.Resourcehealth.Models.AvailabilityStateValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resourcehealth.Models.AvailabilityStateValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resourcehealth.Models.AvailabilityStateValue left, Azure.ResourceManager.Resourcehealth.Models.AvailabilityStateValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvailabilityStatusProperties
    {
        internal AvailabilityStatusProperties() { }
        public Azure.ResourceManager.Resourcehealth.Models.AvailabilityStateValue? AvailabilityState { get { throw null; } }
        public string DetailedStatus { get { throw null; } }
        public string HealthEventCategory { get { throw null; } }
        public string HealthEventCause { get { throw null; } }
        public string HealthEventId { get { throw null; } }
        public string HealthEventType { get { throw null; } }
        public System.DateTimeOffset? OccuredOn { get { throw null; } }
        public Azure.ResourceManager.Resourcehealth.Models.ReasonChronicityType? ReasonChronicity { get { throw null; } }
        public string ReasonType { get { throw null; } }
        public Azure.ResourceManager.Resourcehealth.Models.AvailabilityStatusPropertiesRecentlyResolved RecentlyResolved { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resourcehealth.Models.RecommendedAction> RecommendedActions { get { throw null; } }
        public System.DateTimeOffset? ReportedOn { get { throw null; } }
        public System.DateTimeOffset? ResolutionETA { get { throw null; } }
        public System.DateTimeOffset? RootCauseAttributionOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resourcehealth.Models.ServiceImpactingEvent> ServiceImpactingEvents { get { throw null; } }
        public string Summary { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public partial class AvailabilityStatusPropertiesRecentlyResolved
    {
        internal AvailabilityStatusPropertiesRecentlyResolved() { }
        public System.DateTimeOffset? ResolvedOn { get { throw null; } }
        public System.DateTimeOffset? UnavailableOccuredOn { get { throw null; } }
        public string UnavailableSummary { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReasonChronicityType : System.IEquatable<Azure.ResourceManager.Resourcehealth.Models.ReasonChronicityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReasonChronicityType(string value) { throw null; }
        public static Azure.ResourceManager.Resourcehealth.Models.ReasonChronicityType Persistent { get { throw null; } }
        public static Azure.ResourceManager.Resourcehealth.Models.ReasonChronicityType Transient { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resourcehealth.Models.ReasonChronicityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resourcehealth.Models.ReasonChronicityType left, Azure.ResourceManager.Resourcehealth.Models.ReasonChronicityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resourcehealth.Models.ReasonChronicityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resourcehealth.Models.ReasonChronicityType left, Azure.ResourceManager.Resourcehealth.Models.ReasonChronicityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecommendedAction
    {
        internal RecommendedAction() { }
        public string Action { get { throw null; } }
        public System.Uri ActionUri { get { throw null; } }
        public string ActionUrlText { get { throw null; } }
    }
    public partial class ServiceImpactingEvent
    {
        internal ServiceImpactingEvent() { }
        public string CorrelationId { get { throw null; } }
        public System.DateTimeOffset? EventStartOn { get { throw null; } }
        public System.DateTimeOffset? EventStatusLastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.Resourcehealth.Models.ServiceImpactingEventIncidentProperties IncidentProperties { get { throw null; } }
        public string StatusValue { get { throw null; } }
    }
    public partial class ServiceImpactingEventIncidentProperties
    {
        internal ServiceImpactingEventIncidentProperties() { }
        public string IncidentType { get { throw null; } }
        public string Region { get { throw null; } }
        public string Service { get { throw null; } }
        public string Title { get { throw null; } }
    }
}
