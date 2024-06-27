namespace Azure.Maps.Timezone
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JsonFormat : System.IEquatable<Azure.Maps.Timezone.JsonFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JsonFormat(string value) { throw null; }
        public static Azure.Maps.Timezone.JsonFormat Json { get { throw null; } }
        public bool Equals(Azure.Maps.Timezone.JsonFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Timezone.JsonFormat left, Azure.Maps.Timezone.JsonFormat right) { throw null; }
        public static implicit operator Azure.Maps.Timezone.JsonFormat (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Timezone.JsonFormat left, Azure.Maps.Timezone.JsonFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MapsTimezoneClient
    {
        protected MapsTimezoneClient() { }
        public MapsTimezoneClient(Azure.AzureKeyCredential credential) { }
        public MapsTimezoneClient(Azure.AzureKeyCredential credential, Azure.Maps.Timezone.MapsTimezoneClientOptions options) { }
        public MapsTimezoneClient(Azure.AzureSasCredential credential) { }
        public MapsTimezoneClient(Azure.AzureSasCredential credential, Azure.Maps.Timezone.MapsTimezoneClientOptions options) { }
        public MapsTimezoneClient(Azure.Core.TokenCredential credential, string clientId) { }
        public MapsTimezoneClient(Azure.Core.TokenCredential credential, string clientId, Azure.Maps.Timezone.MapsTimezoneClientOptions options) { }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Maps.Timezone.IanaId>> ConvertWindowsTimezoneToIana(string windowsTimezoneId, string windowsTerritoryCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Maps.Timezone.IanaId>>> ConvertWindowsTimezoneToIanaAsync(string windowsTimezoneId, string windowsTerritoryCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Maps.Timezone.IanaId>> GetIanaTimezoneIds(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Maps.Timezone.IanaId>>> GetIanaTimezoneIdsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Timezone.TimezoneIanaVersionResult> GetIanaVersion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Timezone.TimezoneIanaVersionResult>> GetIanaVersionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Timezone.TimezoneResult> GetTimezoneByCoordinates(Azure.Core.GeoJson.GeoPosition coordinates, Azure.Maps.Timezone.Models.Options.TimezoneBaseOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Timezone.TimezoneResult>> GetTimezoneByCoordinatesAsync(Azure.Core.GeoJson.GeoPosition coordinates, Azure.Maps.Timezone.Models.Options.TimezoneBaseOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Timezone.TimezoneResult> GetTimezoneByID(string timezoneId, Azure.Maps.Timezone.Models.Options.TimezoneBaseOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Timezone.TimezoneResult>> GetTimezoneByIDAsync(string timezoneId, Azure.Maps.Timezone.Models.Options.TimezoneBaseOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Maps.Timezone.TimezoneWindows>> GetWindowsTimezoneIds(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Maps.Timezone.TimezoneWindows>>> GetWindowsTimezoneIdsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MapsTimezoneClientOptions : Azure.Core.ClientOptions
    {
        public MapsTimezoneClientOptions(Azure.Maps.Timezone.MapsTimezoneClientOptions.ServiceVersion version = Azure.Maps.Timezone.MapsTimezoneClientOptions.ServiceVersion.V1_0, System.Uri endpoint = null) { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V1_0 = 1,
        }
    }
    public static partial class MapsTimezoneModelFactory
    {
        public static Azure.Maps.Timezone.CountryRecord CountryRecord(string name = null, string code = null) { throw null; }
        public static Azure.Maps.Timezone.IanaId IanaId(string id = null, bool? isAlias = default(bool?), string aliasOf = null, bool? hasZone1970Location = default(bool?)) { throw null; }
        public static Azure.Maps.Timezone.ReferenceTime ReferenceTime(string tag = null, string standardOffset = null, string daylightSavings = null, string wallTime = null, int? posixTzValidYear = default(int?), string posixTz = null, System.DateTimeOffset? sunrise = default(System.DateTimeOffset?), System.DateTimeOffset? sunset = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Maps.Timezone.RepresentativePoint RepresentativePoint(float? latitude = default(float?), float? longitude = default(float?)) { throw null; }
        public static Azure.Maps.Timezone.TimeTransition TimeTransition(string tag = null, string standardOffset = null, string daylightSavings = null, System.DateTimeOffset? utcStart = default(System.DateTimeOffset?), System.DateTimeOffset? utcEnd = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Maps.Timezone.TimezoneIanaVersionResult TimezoneIanaVersionResult(string version = null) { throw null; }
        public static Azure.Maps.Timezone.TimezoneId TimezoneId(string id = null, System.Collections.Generic.IEnumerable<string> aliases = null, System.Collections.Generic.IEnumerable<Azure.Maps.Timezone.CountryRecord> countries = null, Azure.Maps.Timezone.TimezoneNames names = null, Azure.Maps.Timezone.ReferenceTime referenceTime = null, Azure.Maps.Timezone.RepresentativePoint representativePoint = null, System.Collections.Generic.IEnumerable<Azure.Maps.Timezone.TimeTransition> timeTransitions = null) { throw null; }
        public static Azure.Maps.Timezone.TimezoneNames TimezoneNames(string isO6391LanguageCode = null, string generic = null, string standard = null, string daylight = null) { throw null; }
        public static Azure.Maps.Timezone.TimezoneResult TimezoneResult(string version = null, System.DateTimeOffset? referenceUtcTimestamp = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Maps.Timezone.TimezoneId> timeZones = null) { throw null; }
        public static Azure.Maps.Timezone.TimezoneWindows TimezoneWindows(string windowsId = null, string territory = null, System.Collections.Generic.IEnumerable<string> ianaIds = null) { throw null; }
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
    public partial class RepresentativePoint
    {
        internal RepresentativePoint() { }
        public float? Latitude { get { throw null; } }
        public float? Longitude { get { throw null; } }
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
    public partial class TimezoneIanaVersionResult
    {
        internal TimezoneIanaVersionResult() { }
        public string Version { get { throw null; } }
    }
    public partial class TimezoneId
    {
        internal TimezoneId() { }
        public System.Collections.Generic.IReadOnlyList<string> Aliases { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Timezone.CountryRecord> Countries { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Maps.Timezone.TimezoneNames Names { get { throw null; } }
        public Azure.Maps.Timezone.ReferenceTime ReferenceTime { get { throw null; } }
        public Azure.Maps.Timezone.RepresentativePoint RepresentativePoint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Timezone.TimeTransition> TimeTransitions { get { throw null; } }
    }
    public partial class TimezoneNames
    {
        internal TimezoneNames() { }
        public string Daylight { get { throw null; } }
        public string Generic { get { throw null; } }
        public string ISO6391LanguageCode { get { throw null; } }
        public string Standard { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimezoneOptions : System.IEquatable<Azure.Maps.Timezone.TimezoneOptions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimezoneOptions(string value) { throw null; }
        public static Azure.Maps.Timezone.TimezoneOptions All { get { throw null; } }
        public static Azure.Maps.Timezone.TimezoneOptions None { get { throw null; } }
        public static Azure.Maps.Timezone.TimezoneOptions Transitions { get { throw null; } }
        public static Azure.Maps.Timezone.TimezoneOptions ZoneInfo { get { throw null; } }
        public bool Equals(Azure.Maps.Timezone.TimezoneOptions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Timezone.TimezoneOptions left, Azure.Maps.Timezone.TimezoneOptions right) { throw null; }
        public static implicit operator Azure.Maps.Timezone.TimezoneOptions (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Timezone.TimezoneOptions left, Azure.Maps.Timezone.TimezoneOptions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TimezoneResult
    {
        internal TimezoneResult() { }
        public System.DateTimeOffset? ReferenceUtcTimestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Timezone.TimezoneId> TimeZones { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class TimezoneWindows
    {
        internal TimezoneWindows() { }
        public System.Collections.Generic.IReadOnlyList<string> IanaIds { get { throw null; } }
        public string Territory { get { throw null; } }
        public string WindowsId { get { throw null; } }
    }
}
namespace Azure.Maps.Timezone.Models.Options
{
    public partial class TimezoneBaseOptions
    {
        public TimezoneBaseOptions() { }
        public string AcceptLanguage { get { throw null; } set { } }
        public System.DateTimeOffset? DaylightSavingsTimeFrom { get { throw null; } set { } }
        public int? DaylightSavingsTimeLastingYears { get { throw null; } set { } }
        public Azure.Maps.Timezone.TimezoneOptions? Options { get { throw null; } set { } }
        public System.DateTimeOffset? TimeStamp { get { throw null; } set { } }
    }
}
