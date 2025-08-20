namespace Azure.Maps.TimeZones
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdditionalTimeZoneReturnInformation : System.IEquatable<Azure.Maps.TimeZones.AdditionalTimeZoneReturnInformation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdditionalTimeZoneReturnInformation(string value) { throw null; }
        public static Azure.Maps.TimeZones.AdditionalTimeZoneReturnInformation All { get { throw null; } }
        public static Azure.Maps.TimeZones.AdditionalTimeZoneReturnInformation None { get { throw null; } }
        public static Azure.Maps.TimeZones.AdditionalTimeZoneReturnInformation Transitions { get { throw null; } }
        public static Azure.Maps.TimeZones.AdditionalTimeZoneReturnInformation ZoneInfo { get { throw null; } }
        public bool Equals(Azure.Maps.TimeZones.AdditionalTimeZoneReturnInformation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.TimeZones.AdditionalTimeZoneReturnInformation left, Azure.Maps.TimeZones.AdditionalTimeZoneReturnInformation right) { throw null; }
        public static implicit operator Azure.Maps.TimeZones.AdditionalTimeZoneReturnInformation (string value) { throw null; }
        public static bool operator !=(Azure.Maps.TimeZones.AdditionalTimeZoneReturnInformation left, Azure.Maps.TimeZones.AdditionalTimeZoneReturnInformation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureMapsTimeZonesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureMapsTimeZonesContext() { }
        public static Azure.Maps.TimeZones.AzureMapsTimeZonesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CountryRecord
    {
        internal CountryRecord() { }
        public string Code { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class GetTimeZoneOptions
    {
        public GetTimeZoneOptions() { }
        public string AcceptLanguage { get { throw null; } set { } }
        public Azure.Maps.TimeZones.AdditionalTimeZoneReturnInformation? AdditionalTimeZoneReturnInformation { get { throw null; } set { } }
        public System.DateTimeOffset? DaylightSavingsTimeTransitionFrom { get { throw null; } set { } }
        public int? DaylightSavingsTimeTransitionInYears { get { throw null; } set { } }
        public System.DateTimeOffset? TimeStamp { get { throw null; } set { } }
    }
    public partial class IanaId
    {
        internal IanaId() { }
        public string AliasOf { get { throw null; } }
        public bool? HasZone1970Location { get { throw null; } }
        public string Id { get { throw null; } }
    }
    public partial class IanaIdData
    {
        internal IanaIdData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.TimeZones.IanaId> IanaIds { get { throw null; } }
    }
    public partial class MapsTimeZoneClient
    {
        protected MapsTimeZoneClient() { }
        public MapsTimeZoneClient(Azure.AzureKeyCredential credential) { }
        public MapsTimeZoneClient(Azure.AzureKeyCredential credential, Azure.Maps.TimeZones.MapsTimeZoneClientOptions options) { }
        public MapsTimeZoneClient(Azure.AzureSasCredential credential, Azure.Maps.TimeZones.MapsTimeZoneClientOptions options = null) { }
        public MapsTimeZoneClient(Azure.Core.TokenCredential credential, string clientId) { }
        public MapsTimeZoneClient(Azure.Core.TokenCredential credential, string clientId, Azure.Maps.TimeZones.MapsTimeZoneClientOptions options) { }
        public virtual Azure.Response<Azure.Maps.TimeZones.IanaIdData> ConvertWindowsTimeZoneToIana(string windowsTimeZoneId, string windowsTerritoryCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.TimeZones.IanaIdData>> ConvertWindowsTimeZoneToIanaAsync(string windowsTimeZoneId, string windowsTerritoryCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.TimeZones.TimeZoneIanaVersionResult> GetIanaVersion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.TimeZones.TimeZoneIanaVersionResult>> GetIanaVersionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.TimeZones.TimeZoneResult> GetTimeZoneByCoordinates(Azure.Core.GeoJson.GeoPosition coordinates, Azure.Maps.TimeZones.GetTimeZoneOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.TimeZones.TimeZoneResult>> GetTimeZoneByCoordinatesAsync(Azure.Core.GeoJson.GeoPosition coordinates, Azure.Maps.TimeZones.GetTimeZoneOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.TimeZones.TimeZoneResult> GetTimeZoneById(string timeZoneId, Azure.Maps.TimeZones.GetTimeZoneOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.TimeZones.TimeZoneResult>> GetTimeZoneByIdAsync(string timeZoneId, Azure.Maps.TimeZones.GetTimeZoneOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.TimeZones.IanaIdData> GetTimeZoneIanaIds(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.TimeZones.IanaIdData>> GetTimeZoneIanaIdsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.TimeZones.WindowsTimeZoneData> GetWindowsTimeZoneIds(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.TimeZones.WindowsTimeZoneData>> GetWindowsTimeZoneIdsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MapsTimeZoneClientOptions : Azure.Core.ClientOptions
    {
        public MapsTimeZoneClientOptions(Azure.Maps.TimeZones.MapsTimeZoneClientOptions.ServiceVersion version = Azure.Maps.TimeZones.MapsTimeZoneClientOptions.ServiceVersion.V1_0) { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V1_0 = 1,
        }
    }
    public static partial class MapsTimeZonesModelFactory
    {
        public static Azure.Maps.TimeZones.CountryRecord CountryRecord(string name = null, string code = null) { throw null; }
        public static Azure.Maps.TimeZones.TimeZoneIanaVersionResult TimeZoneIanaVersionResult(string version = null) { throw null; }
        public static Azure.Maps.TimeZones.TimeZoneName TimeZoneName(string iso6391LanguageCode = null, string generic = null, string standard = null, string daylight = null) { throw null; }
        public static Azure.Maps.TimeZones.TimeZoneResult TimeZoneResult(string version = null, System.DateTimeOffset? referenceUtcTimestamp = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Maps.TimeZones.TimeZoneId> timeZones = null) { throw null; }
        public static Azure.Maps.TimeZones.WindowsTimeZone WindowsTimeZone(string windowsId = null, string territory = null, System.Collections.Generic.IEnumerable<string> ianaIds = null) { throw null; }
    }
    public partial class ReferenceTime
    {
        internal ReferenceTime() { }
        public System.TimeSpan DaylightSavingsOffset { get { throw null; } }
        public string PosixTimeZone { get { throw null; } }
        public int? PosixTimeZoneValidYear { get { throw null; } }
        public System.TimeSpan StandardOffset { get { throw null; } }
        public System.DateTimeOffset? Sunrise { get { throw null; } }
        public System.DateTimeOffset? Sunset { get { throw null; } }
        public string Tag { get { throw null; } }
        public System.DateTimeOffset WallTime { get { throw null; } }
    }
    public partial class TimeTransition
    {
        internal TimeTransition() { }
        public System.TimeSpan DaylightSavingsOffset { get { throw null; } }
        public System.TimeSpan StandardOffset { get { throw null; } }
        public string Tag { get { throw null; } }
        public System.DateTimeOffset? UtcEnd { get { throw null; } }
        public System.DateTimeOffset? UtcStart { get { throw null; } }
    }
    public partial class TimeZoneIanaVersionResult
    {
        internal TimeZoneIanaVersionResult() { }
        public string Version { get { throw null; } }
    }
    public partial class TimeZoneId
    {
        internal TimeZoneId() { }
        public System.Collections.Generic.IReadOnlyList<string> Aliases { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.TimeZones.CountryRecord> Countries { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Maps.TimeZones.TimeZoneName Name { get { throw null; } }
        public Azure.Maps.TimeZones.ReferenceTime ReferenceTime { get { throw null; } }
        public Azure.Core.GeoJson.GeoPosition RepresentativePoint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.TimeZones.TimeTransition> TimeTransitions { get { throw null; } }
    }
    public partial class TimeZoneName
    {
        internal TimeZoneName() { }
        public string Daylight { get { throw null; } }
        public string Generic { get { throw null; } }
        public string Iso6391LanguageCode { get { throw null; } }
        public string Standard { get { throw null; } }
    }
    public partial class TimeZoneResult
    {
        internal TimeZoneResult() { }
        public System.DateTimeOffset? ReferenceUtcTimestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.TimeZones.TimeZoneId> TimeZones { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class WindowsTimeZone
    {
        internal WindowsTimeZone() { }
        public System.Collections.Generic.IReadOnlyList<string> IanaIds { get { throw null; } }
        public string Territory { get { throw null; } }
        public string WindowsId { get { throw null; } }
    }
    public partial class WindowsTimeZoneData
    {
        internal WindowsTimeZoneData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.TimeZones.WindowsTimeZone> WindowsTimeZones { get { throw null; } }
    }
}
