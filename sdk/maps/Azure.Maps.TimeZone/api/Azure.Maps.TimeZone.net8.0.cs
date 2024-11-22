namespace Azure.Maps.TimeZone
{
    public partial class CountryRecord
    {
        internal CountryRecord() { }
        public string Code { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class IanaId
    {
        internal IanaId() { }
        public string AliasOf { get { throw null; } }
        public bool? HasZone1970Location { get { throw null; } }
        public string Id { get { throw null; } }
        public bool? IsAlias { get { throw null; } }
    }
    public partial class MapsTimeZoneClient
    {
        protected MapsTimeZoneClient() { }
        public MapsTimeZoneClient(Azure.AzureKeyCredential credential) { }
        public MapsTimeZoneClient(Azure.AzureKeyCredential credential, Azure.Maps.TimeZone.MapsTimeZoneClientOptions options) { }
        public MapsTimeZoneClient(Azure.AzureSasCredential credential) { }
        public MapsTimeZoneClient(Azure.AzureSasCredential credential, Azure.Maps.TimeZone.MapsTimeZoneClientOptions options) { }
        public MapsTimeZoneClient(Azure.Core.TokenCredential credential, string clientId) { }
        public MapsTimeZoneClient(Azure.Core.TokenCredential credential, string clientId, Azure.Maps.TimeZone.MapsTimeZoneClientOptions options) { }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Maps.TimeZone.IanaId>> ConvertWindowsTimeZoneToIana(string windowsTimezoneId, string windowsTerritoryCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Maps.TimeZone.IanaId>>> ConvertWindowsTimeZoneToIanaAsync(string windowsTimezoneId, string windowsTerritoryCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Maps.TimeZone.IanaId>> GetIanaTimeZoneIds(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Maps.TimeZone.IanaId>>> GetIanaTimeZoneIdsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.TimeZone.Models.TimeZoneIanaVersionResult> GetIanaVersion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.TimeZone.Models.TimeZoneIanaVersionResult>> GetIanaVersionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.TimeZone.Models.TimeZoneInformation> GetTimeZoneByCoordinates(Azure.Core.GeoJson.GeoPosition coordinates, Azure.Maps.TimeZone.Models.Options.TimeZoneBaseOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.TimeZone.Models.TimeZoneInformation>> GetTimeZoneByCoordinatesAsync(Azure.Core.GeoJson.GeoPosition coordinates, Azure.Maps.TimeZone.Models.Options.TimeZoneBaseOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.TimeZone.Models.TimeZoneInformation> GetTimeZoneByID(string timezoneId, Azure.Maps.TimeZone.Models.Options.TimeZoneBaseOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.TimeZone.Models.TimeZoneInformation>> GetTimeZoneByIDAsync(string timezoneId, Azure.Maps.TimeZone.Models.Options.TimeZoneBaseOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Maps.TimeZone.Models.TimeZoneWindows>> GetWindowsTimeZoneIds(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Maps.TimeZone.Models.TimeZoneWindows>>> GetWindowsTimeZoneIdsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MapsTimeZoneClientOptions : Azure.Core.ClientOptions
    {
        public MapsTimeZoneClientOptions(Azure.Maps.TimeZone.MapsTimeZoneClientOptions.ServiceVersion version = Azure.Maps.TimeZone.MapsTimeZoneClientOptions.ServiceVersion.V1_0, System.Uri endpoint = null) { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V1_0 = 1,
        }
    }
    public static partial class MapsTimeZoneModelFactory
    {
        public static Azure.Maps.TimeZone.CountryRecord CountryRecord(string name = null, string code = null) { throw null; }
        public static Azure.Maps.TimeZone.IanaId IanaId(string id = null, bool? isAlias = default(bool?), string aliasOf = null, bool? hasZone1970Location = default(bool?)) { throw null; }
        public static Azure.Maps.TimeZone.ReferenceTime ReferenceTime(string tag = null, string standardOffset = null, string daylightSavings = null, string wallTime = null, int? posixTzValidYear = default(int?), string posixTz = null, System.DateTimeOffset? sunrise = default(System.DateTimeOffset?), System.DateTimeOffset? sunset = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Maps.TimeZone.TimeTransition TimeTransition(string tag = null, string standardOffset = null, string daylightSavings = null, System.DateTimeOffset? utcStart = default(System.DateTimeOffset?), System.DateTimeOffset? utcEnd = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Maps.TimeZone.Models.TimeZoneIanaVersionResult TimeZoneIanaVersionResult(string version = null) { throw null; }
        public static Azure.Maps.TimeZone.TimezoneId TimezoneId(string id = null, System.Collections.Generic.IEnumerable<string> aliases = null, System.Collections.Generic.IEnumerable<Azure.Maps.TimeZone.CountryRecord> countries = null, Azure.Maps.TimeZone.Models.TimeZoneNames names = null, Azure.Maps.TimeZone.ReferenceTime referenceTime = null, Azure.Maps.TimeZone.Models.RepresentativePoint representativePoint = null, System.Collections.Generic.IEnumerable<Azure.Maps.TimeZone.TimeTransition> timeTransitions = null) { throw null; }
        public static Azure.Maps.TimeZone.Models.TimeZoneInformation TimeZoneInformation(string version = null, System.DateTimeOffset? referenceUtcTimestamp = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Maps.TimeZone.TimezoneId> timeZones = null) { throw null; }
        public static Azure.Maps.TimeZone.Models.TimeZoneNames TimeZoneNames(string iso6391LanguageCode = null, string generic = null, string standard = null, string daylight = null) { throw null; }
        public static Azure.Maps.TimeZone.Models.TimeZoneWindows TimeZoneWindows(string windowsId = null, string territory = null, System.Collections.Generic.IEnumerable<string> ianaIds = null) { throw null; }
    }
    public partial class ReferenceTime
    {
        internal ReferenceTime() { }
        public string DaylightSavings { get { throw null; } }
        public string PosixTz { get { throw null; } }
        public int? PosixTzValidYear { get { throw null; } }
        public string StandardOffset { get { throw null; } }
        public System.DateTimeOffset? Sunrise { get { throw null; } }
        public System.DateTimeOffset? Sunset { get { throw null; } }
        public string Tag { get { throw null; } }
        public string WallTime { get { throw null; } }
    }
    public partial class TimeTransition
    {
        internal TimeTransition() { }
        public string DaylightSavings { get { throw null; } }
        public string StandardOffset { get { throw null; } }
        public string Tag { get { throw null; } }
        public System.DateTimeOffset? UtcEnd { get { throw null; } }
        public System.DateTimeOffset? UtcStart { get { throw null; } }
    }
    public partial class TimezoneId
    {
        internal TimezoneId() { }
        public System.Collections.Generic.IReadOnlyList<string> Aliases { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.TimeZone.CountryRecord> Countries { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Maps.TimeZone.Models.TimeZoneNames Names { get { throw null; } }
        public Azure.Maps.TimeZone.ReferenceTime ReferenceTime { get { throw null; } }
        public Azure.Maps.TimeZone.Models.RepresentativePoint RepresentativePoint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.TimeZone.TimeTransition> TimeTransitions { get { throw null; } }
    }
}
namespace Azure.Maps.TimeZone.Models
{
    public partial class RepresentativePoint
    {
        internal RepresentativePoint() { }
        public Azure.Core.GeoJson.GeoPosition geoPosition { get { throw null; } set { } }
    }
    public partial class TimeZoneIanaVersionResult
    {
        internal TimeZoneIanaVersionResult() { }
        public string Version { get { throw null; } }
    }
    public partial class TimeZoneInformation
    {
        internal TimeZoneInformation() { }
        public System.DateTimeOffset? ReferenceUtcTimestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.TimeZone.TimezoneId> TimeZones { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class TimeZoneNames
    {
        internal TimeZoneNames() { }
        public string Daylight { get { throw null; } }
        public string Generic { get { throw null; } }
        public string Iso6391LanguageCode { get { throw null; } }
        public string Standard { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimeZoneOptions : System.IEquatable<Azure.Maps.TimeZone.Models.TimeZoneOptions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeZoneOptions(string value) { throw null; }
        public static Azure.Maps.TimeZone.Models.TimeZoneOptions All { get { throw null; } }
        public static Azure.Maps.TimeZone.Models.TimeZoneOptions None { get { throw null; } }
        public static Azure.Maps.TimeZone.Models.TimeZoneOptions Transitions { get { throw null; } }
        public static Azure.Maps.TimeZone.Models.TimeZoneOptions ZoneInfo { get { throw null; } }
        public bool Equals(Azure.Maps.TimeZone.Models.TimeZoneOptions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.TimeZone.Models.TimeZoneOptions left, Azure.Maps.TimeZone.Models.TimeZoneOptions right) { throw null; }
        public static implicit operator Azure.Maps.TimeZone.Models.TimeZoneOptions (string value) { throw null; }
        public static bool operator !=(Azure.Maps.TimeZone.Models.TimeZoneOptions left, Azure.Maps.TimeZone.Models.TimeZoneOptions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TimeZoneWindows
    {
        internal TimeZoneWindows() { }
        public System.Collections.Generic.IReadOnlyList<string> IanaIds { get { throw null; } }
        public string Territory { get { throw null; } }
        public string WindowsId { get { throw null; } }
    }
}
namespace Azure.Maps.TimeZone.Models.Options
{
    public partial class TimeZoneBaseOptions
    {
        public TimeZoneBaseOptions() { }
        public string AcceptLanguage { get { throw null; } set { } }
        public System.DateTimeOffset? DaylightSavingsTimeFrom { get { throw null; } set { } }
        public int? DaylightSavingsTimeLastingYears { get { throw null; } set { } }
        public Azure.Maps.TimeZone.Models.TimeZoneOptions? Options { get { throw null; } set { } }
        public System.DateTimeOffset? TimeStamp { get { throw null; } set { } }
    }
}
