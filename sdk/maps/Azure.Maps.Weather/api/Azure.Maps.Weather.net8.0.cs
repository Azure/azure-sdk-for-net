namespace Azure.Maps.Weather
{
    public partial class AzureMapsWeatherContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureMapsWeatherContext() { }
        public static Azure.Maps.Weather.AzureMapsWeatherContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class MapsWeatherClient
    {
        protected MapsWeatherClient() { }
        public MapsWeatherClient(Azure.AzureKeyCredential credential) { }
        public MapsWeatherClient(Azure.AzureKeyCredential credential, Azure.Maps.Weather.MapsWeatherClientOptions options) { }
        public MapsWeatherClient(Azure.AzureSasCredential credential) { }
        public MapsWeatherClient(Azure.AzureSasCredential credential, Azure.Maps.Weather.MapsWeatherClientOptions options) { }
        public MapsWeatherClient(Azure.Core.TokenCredential credential, string clientId) { }
        public MapsWeatherClient(Azure.Core.TokenCredential credential, string clientId, Azure.Maps.Weather.MapsWeatherClientOptions options) { }
        public virtual Azure.Response<Azure.Maps.Weather.Models.DailyAirQualityForecastResult> GetAirQualityDailyForecasts(Azure.Maps.Weather.Models.Options.GetAirQualityDailyForecastsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Weather.Models.DailyAirQualityForecastResult>> GetAirQualityDailyForecastsAsync(Azure.Maps.Weather.Models.Options.GetAirQualityDailyForecastsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Weather.Models.AirQualityResult> GetAirQualityHourlyForecasts(Azure.Maps.Weather.Models.Options.GetAirQualityHourlyForecastsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Weather.Models.AirQualityResult>> GetAirQualityHourlyForecastsAsync(Azure.Maps.Weather.Models.Options.GetAirQualityHourlyForecastsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Weather.Models.AirQualityResult> GetCurrentAirQuality(Azure.Maps.Weather.Models.Options.GetCurrentAirQualityOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Weather.Models.AirQualityResult>> GetCurrentAirQualityAsync(Azure.Maps.Weather.Models.Options.GetCurrentAirQualityOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Weather.Models.CurrentConditionsResult> GetCurrentWeatherConditions(Azure.Maps.Weather.Models.Options.GetCurrentWeatherConditionsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Weather.Models.CurrentConditionsResult>> GetCurrentWeatherConditionsAsync(Azure.Maps.Weather.Models.Options.GetCurrentWeatherConditionsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Weather.Models.DailyHistoricalActualsResult> GetDailyHistoricalActuals(Azure.Maps.Weather.Models.Options.GetDailyHistoricalActualsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Weather.Models.DailyHistoricalActualsResult>> GetDailyHistoricalActualsAsync(Azure.Maps.Weather.Models.Options.GetDailyHistoricalActualsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Weather.Models.DailyHistoricalNormalsResult> GetDailyHistoricalNormals(Azure.Maps.Weather.Models.Options.GetDailyHistoricalNormalsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Weather.Models.DailyHistoricalNormalsResult>> GetDailyHistoricalNormalsAsync(Azure.Maps.Weather.Models.Options.GetDailyHistoricalNormalsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Weather.Models.DailyHistoricalRecordsResult> GetDailyHistoricalRecords(Azure.Maps.Weather.Models.Options.GetDailyHistoricalRecordsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Weather.Models.DailyHistoricalRecordsResult>> GetDailyHistoricalRecordsAsync(Azure.Maps.Weather.Models.Options.GetDailyHistoricalRecordsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Weather.Models.DailyIndicesResult> GetDailyIndices(Azure.Maps.Weather.Models.Options.GetDailyIndicesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Weather.Models.DailyIndicesResult>> GetDailyIndicesAsync(Azure.Maps.Weather.Models.Options.GetDailyIndicesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Weather.Models.DailyForecastResult> GetDailyWeatherForecast(Azure.Maps.Weather.Models.Options.GetDailyWeatherForecastOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Weather.Models.DailyForecastResult>> GetDailyWeatherForecastAsync(Azure.Maps.Weather.Models.Options.GetDailyWeatherForecastOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Weather.Models.HourlyForecastResult> GetHourlyWeatherForecast(Azure.Maps.Weather.Models.Options.GetHourlyWeatherForecastOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Weather.Models.HourlyForecastResult>> GetHourlyWeatherForecastAsync(Azure.Maps.Weather.Models.Options.GetHourlyWeatherForecastOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Weather.Models.MinuteForecastResult> GetMinuteWeatherForecast(Azure.Maps.Weather.Models.Options.GetMinuteWeatherForecastOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Weather.Models.MinuteForecastResult>> GetMinuteWeatherForecastAsync(Azure.Maps.Weather.Models.Options.GetMinuteWeatherForecastOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Weather.Models.QuarterDayForecastResult> GetQuarterDayWeatherForecast(Azure.Maps.Weather.Models.Options.GetQuarterDayWeatherForecastOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Weather.Models.QuarterDayForecastResult>> GetQuarterDayWeatherForecastAsync(Azure.Maps.Weather.Models.Options.GetQuarterDayWeatherForecastOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Weather.Models.SevereWeatherAlertsResult> GetSevereWeatherAlerts(Azure.Maps.Weather.Models.Options.GetSevereWeatherAlertsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Weather.Models.SevereWeatherAlertsResult>> GetSevereWeatherAlertsAsync(Azure.Maps.Weather.Models.Options.GetSevereWeatherAlertsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Weather.Models.ActiveStormResult> GetTropicalStormActive(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Weather.Models.ActiveStormResult>> GetTropicalStormActiveAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Weather.Models.StormForecastResult> GetTropicalStormForecast(Azure.Maps.Weather.Models.Options.GetTropicalStormForecastOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Weather.Models.StormForecastResult>> GetTropicalStormForecastAsync(Azure.Maps.Weather.Models.Options.GetTropicalStormForecastOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Weather.Models.StormLocationsResult> GetTropicalStormLocations(Azure.Maps.Weather.Models.Options.GetTropicalStormLocationsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Weather.Models.StormLocationsResult>> GetTropicalStormLocationsAsync(Azure.Maps.Weather.Models.Options.GetTropicalStormLocationsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Weather.Models.StormSearchResult> GetTropicalStormSearch(Azure.Maps.Weather.Models.Options.GetTropicalStormSearchOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Weather.Models.StormSearchResult>> GetTropicalStormSearchAsync(Azure.Maps.Weather.Models.Options.GetTropicalStormSearchOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Weather.Models.WeatherAlongRouteResult> GetWeatherAlongRoute(Azure.Maps.Weather.Models.WeatherAlongRouteQuery query, Azure.Maps.Weather.WeatherLanguage language, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Weather.Models.WeatherAlongRouteResult>> GetWeatherAlongRouteAsync(Azure.Maps.Weather.Models.WeatherAlongRouteQuery query, Azure.Maps.Weather.WeatherLanguage language, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MapsWeatherClientOptions : Azure.Core.ClientOptions
    {
        public MapsWeatherClientOptions(Azure.Maps.Weather.MapsWeatherClientOptions.ServiceVersion version = Azure.Maps.Weather.MapsWeatherClientOptions.ServiceVersion.V1_1, System.Uri endpoint = null) { }
        public string ClientId { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V1_1 = 1,
        }
    }
    public partial class WeatherLanguage
    {
        public WeatherLanguage(string value) { }
        public static Azure.Maps.Weather.WeatherLanguage Arabic { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage BanglaBangladesh { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage BanglaIndia { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Bosnian { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Bulgarian { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Catalan { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Croatian { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Czech { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Danish { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage DutchBelgium { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage DutchNetherlands { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage EnglishAustralia { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage EnglishGreatBritain { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage EnglishNewZealand { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage EnglishUsa { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Estonian { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Filipino { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Finnish { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage FrenchCanada { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage FrenchFrance { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage German { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Greek { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Gujarati { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Hebrew { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Hindi { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Hungarian { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Icelandic { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Indonesian { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Italian { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Japanese { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Kannada { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Kazakh { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Korean { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Latvian { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Lithuanian { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Macedonian { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Malay { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Marathi { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Norwegian { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Polish { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage PortugueseBrazil { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage PortuguesePortugal { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Punjabi { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Romanian { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Russian { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage SerbianCyrillic { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage SerbianLatin { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage SimplifiedChinese { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Slovak { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Slovenian { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage SpanishLatinAmerica { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage SpanishMexico { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage SpanishSpain { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Swedish { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Tamil { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Telugu { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Thai { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage TraditionalChineseHongKong { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage TraditionalChineseTaiwan { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Turkish { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Ukrainian { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Urdu { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Uzbek { get { throw null; } }
        public static Azure.Maps.Weather.WeatherLanguage Vietnamese { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static implicit operator Azure.Maps.Weather.WeatherLanguage (string value) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Azure.Maps.Weather.Models
{
    public partial class ActiveStorm
    {
        internal ActiveStorm() { }
        public Azure.Maps.Weather.Models.BasinId? BasinId { get { throw null; } }
        public int? GovId { get { throw null; } }
        public bool? IsActive { get { throw null; } }
        public bool? IsSubtropical { get { throw null; } }
        public string Name { get { throw null; } }
        public string Year { get { throw null; } }
    }
    public partial class ActiveStormResult
    {
        internal ActiveStormResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.ActiveStorm> ActiveStorms { get { throw null; } }
        public string NextLink { get { throw null; } }
    }
    public partial class AirAndPollen
    {
        internal AirAndPollen() { }
        public string AirQualityType { get { throw null; } }
        public string Category { get { throw null; } }
        public int? CategoryValue { get { throw null; } }
        public string Description { get { throw null; } }
        public int? Value { get { throw null; } }
    }
    public partial class AirQuality
    {
        internal AirQuality() { }
        public string Category { get { throw null; } }
        public string CategoryColor { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.Maps.Weather.Models.DominantPollutant? DominantPollutant { get { throw null; } }
        public float? GlobalIndex { get { throw null; } }
        public float? Index { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.Pollutant> Pollutants { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class AirQualityResult
    {
        internal AirQualityResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.AirQuality> AirQualityResults { get { throw null; } }
        public string NextLink { get { throw null; } }
    }
    public partial class AlertDetails
    {
        internal AlertDetails() { }
        public string Description { get { throw null; } }
        public string Details { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public string Language { get { throw null; } }
        public Azure.Maps.Weather.Models.LatestStatus LatestStatus { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BasinId : System.IEquatable<Azure.Maps.Weather.Models.BasinId>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BasinId(string value) { throw null; }
        public static Azure.Maps.Weather.Models.BasinId AL { get { throw null; } }
        public static Azure.Maps.Weather.Models.BasinId CP { get { throw null; } }
        public static Azure.Maps.Weather.Models.BasinId EP { get { throw null; } }
        public static Azure.Maps.Weather.Models.BasinId NI { get { throw null; } }
        public static Azure.Maps.Weather.Models.BasinId NP { get { throw null; } }
        public static Azure.Maps.Weather.Models.BasinId SI { get { throw null; } }
        public static Azure.Maps.Weather.Models.BasinId SP { get { throw null; } }
        public bool Equals(Azure.Maps.Weather.Models.BasinId other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Weather.Models.BasinId left, Azure.Maps.Weather.Models.BasinId right) { throw null; }
        public static implicit operator Azure.Maps.Weather.Models.BasinId (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Weather.Models.BasinId left, Azure.Maps.Weather.Models.BasinId right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ColorValue
    {
        internal ColorValue() { }
        public int? Blue { get { throw null; } }
        public int? Green { get { throw null; } }
        public string Hex { get { throw null; } }
        public int? Red { get { throw null; } }
    }
    public partial class CurrentConditions
    {
        internal CurrentConditions() { }
        public Azure.Maps.Weather.Models.WeatherValue ApparentTemperature { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue CloudCeiling { get { throw null; } }
        public int? CloudCover { get { throw null; } }
        public System.DateTimeOffset? DateTime { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue DewPoint { get { throw null; } }
        public bool? HasPrecipitation { get { throw null; } }
        public Azure.Maps.Weather.Models.IconCode? IconCode { get { throw null; } }
        public bool? IsDaytime { get { throw null; } }
        public string ObstructionsToVisibility { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue PastTwentyFourHourTemperatureDeparture { get { throw null; } }
        public Azure.Maps.Weather.Models.PrecipitationSummary PrecipitationSummary { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Pressure { get { throw null; } }
        public Azure.Maps.Weather.Models.PressureTendency PressureTendency { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue RealFeelTemperature { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue RealFeelTemperatureShade { get { throw null; } }
        public int? RelativeHumidity { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Temperature { get { throw null; } }
        public Azure.Maps.Weather.Models.TemperatureSummary TemperatureSummary { get { throw null; } }
        public int? UvIndex { get { throw null; } }
        public string UvIndexDescription { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Visibility { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue WetBulbTemperature { get { throw null; } }
        public Azure.Maps.Weather.Models.WindDetails Wind { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue WindChillTemperature { get { throw null; } }
        public Azure.Maps.Weather.Models.WindDetails WindGust { get { throw null; } }
    }
    public partial class CurrentConditionsResult
    {
        internal CurrentConditionsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.CurrentConditions> Results { get { throw null; } }
    }
    public partial class DailyAirQuality
    {
        internal DailyAirQuality() { }
        public string Category { get { throw null; } }
        public string CategoryColor { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.Maps.Weather.Models.DominantPollutant? DominantPollutant { get { throw null; } }
        public float? GlobalIndex { get { throw null; } }
        public float? Index { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class DailyAirQualityForecastResult
    {
        internal DailyAirQualityForecastResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.DailyAirQuality> AirQualityResults { get { throw null; } }
        public string NextLink { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DailyDuration : System.IEquatable<Azure.Maps.Weather.Models.DailyDuration>
    {
        private readonly int _dummyPrimitive;
        public DailyDuration(int value) { throw null; }
        public static Azure.Maps.Weather.Models.DailyDuration FiveDays { get { throw null; } }
        public static Azure.Maps.Weather.Models.DailyDuration FourDays { get { throw null; } }
        public static Azure.Maps.Weather.Models.DailyDuration OneDay { get { throw null; } }
        public static Azure.Maps.Weather.Models.DailyDuration SevenDays { get { throw null; } }
        public static Azure.Maps.Weather.Models.DailyDuration SixDays { get { throw null; } }
        public static Azure.Maps.Weather.Models.DailyDuration ThreeDays { get { throw null; } }
        public static Azure.Maps.Weather.Models.DailyDuration TwoDays { get { throw null; } }
        public bool Equals(Azure.Maps.Weather.Models.DailyDuration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Weather.Models.DailyDuration left, Azure.Maps.Weather.Models.DailyDuration right) { throw null; }
        public static implicit operator Azure.Maps.Weather.Models.DailyDuration (int value) { throw null; }
        public static bool operator !=(Azure.Maps.Weather.Models.DailyDuration left, Azure.Maps.Weather.Models.DailyDuration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DailyForecast
    {
        internal DailyForecast() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.AirAndPollen> AirQuality { get { throw null; } }
        public System.DateTimeOffset? DateTime { get { throw null; } }
        public Azure.Maps.Weather.Models.DailyForecastDetail DaytimeForecast { get { throw null; } }
        public float? HoursOfSun { get { throw null; } }
        public Azure.Maps.Weather.Models.DegreeDaySummary MeanTemperatureDeviation { get { throw null; } }
        public Azure.Maps.Weather.Models.DailyForecastDetail NighttimeForecast { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValueRange RealFeelTemperature { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValueRange RealFeelTemperatureShade { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Sources { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValueRange Temperature { get { throw null; } }
    }
    public partial class DailyForecastDetail
    {
        internal DailyForecastDetail() { }
        public int? CloudCover { get { throw null; } }
        public bool? HasPrecipitation { get { throw null; } }
        public float? HoursOfIce { get { throw null; } }
        public float? HoursOfPrecipitation { get { throw null; } }
        public float? HoursOfRain { get { throw null; } }
        public float? HoursOfSnow { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Ice { get { throw null; } }
        public int? IceProbability { get { throw null; } }
        public Azure.Maps.Weather.Models.IconCode? IconCode { get { throw null; } }
        public string IconPhrase { get { throw null; } }
        public Azure.Maps.Weather.Models.LocalSource LocalSource { get { throw null; } }
        public string LongPhrase { get { throw null; } }
        public string PrecipitationIntensity { get { throw null; } }
        public int? PrecipitationProbability { get { throw null; } }
        public Azure.Maps.Weather.Models.PrecipitationType? PrecipitationType { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Rain { get { throw null; } }
        public int? RainProbability { get { throw null; } }
        public string ShortDescription { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Snow { get { throw null; } }
        public int? SnowProbability { get { throw null; } }
        public int? ThunderstormProbability { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue TotalLiquid { get { throw null; } }
        public Azure.Maps.Weather.Models.WindDetails Wind { get { throw null; } }
        public Azure.Maps.Weather.Models.WindDetails WindGust { get { throw null; } }
    }
    public partial class DailyForecastResult
    {
        internal DailyForecastResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.DailyForecast> Forecasts { get { throw null; } }
        public Azure.Maps.Weather.Models.DailyForecastSummary Summary { get { throw null; } }
    }
    public partial class DailyForecastSummary
    {
        internal DailyForecastSummary() { }
        public string Category { get { throw null; } }
        public System.DateTimeOffset? EndDate { get { throw null; } }
        public string Phrase { get { throw null; } }
        public int? Severity { get { throw null; } }
        public System.DateTimeOffset? StartDate { get { throw null; } }
    }
    public partial class DailyHistoricalActuals
    {
        internal DailyHistoricalActuals() { }
        public Azure.Maps.Weather.Models.DegreeDaySummary DegreeDaySummary { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Precipitation { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue SnowDepth { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Snowfall { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValueMaxMinAvg Temperature { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class DailyHistoricalActualsResult
    {
        internal DailyHistoricalActualsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.DailyHistoricalActuals> HistoricalActuals { get { throw null; } }
        public string NextLink { get { throw null; } }
    }
    public partial class DailyHistoricalNormals
    {
        internal DailyHistoricalNormals() { }
        public Azure.Maps.Weather.Models.DegreeDaySummary DegreeDaySummary { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Precipitation { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValueMaxMinAvg Temperature { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class DailyHistoricalNormalsResult
    {
        internal DailyHistoricalNormalsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.DailyHistoricalNormals> HistoricalNormals { get { throw null; } }
        public string NextLink { get { throw null; } }
    }
    public partial class DailyHistoricalRecords
    {
        internal DailyHistoricalRecords() { }
        public Azure.Maps.Weather.Models.WeatherValueYearMax Precipitation { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValueYearMax Snowfall { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValueYearMaxMinAvg Temperature { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class DailyHistoricalRecordsResult
    {
        internal DailyHistoricalRecordsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.DailyHistoricalRecords> HistoricalRecords { get { throw null; } }
        public string NextLink { get { throw null; } }
    }
    public partial class DailyIndex
    {
        internal DailyIndex() { }
        public string CategoryDescription { get { throw null; } }
        public int? CategoryValue { get { throw null; } }
        public System.DateTimeOffset? DateTime { get { throw null; } }
        public string Description { get { throw null; } }
        public int? IndexId { get { throw null; } }
        public string IndexName { get { throw null; } }
        public bool? IsAscending { get { throw null; } }
        public float? Value { get { throw null; } }
    }
    public partial class DailyIndicesResult
    {
        internal DailyIndicesResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.DailyIndex> Results { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DayQuarter : System.IEquatable<Azure.Maps.Weather.Models.DayQuarter>
    {
        private readonly int _dummyPrimitive;
        public DayQuarter(int value) { throw null; }
        public static Azure.Maps.Weather.Models.DayQuarter FirstQuarter { get { throw null; } }
        public static Azure.Maps.Weather.Models.DayQuarter ForthQuarter { get { throw null; } }
        public static Azure.Maps.Weather.Models.DayQuarter SecondQuarter { get { throw null; } }
        public static Azure.Maps.Weather.Models.DayQuarter ThirdQuarter { get { throw null; } }
        public bool Equals(Azure.Maps.Weather.Models.DayQuarter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Weather.Models.DayQuarter left, Azure.Maps.Weather.Models.DayQuarter right) { throw null; }
        public static implicit operator Azure.Maps.Weather.Models.DayQuarter (int value) { throw null; }
        public static bool operator !=(Azure.Maps.Weather.Models.DayQuarter left, Azure.Maps.Weather.Models.DayQuarter right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DegreeDaySummary
    {
        internal DegreeDaySummary() { }
        public Azure.Maps.Weather.Models.WeatherValue Cooling { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Heating { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DominantPollutant : System.IEquatable<Azure.Maps.Weather.Models.DominantPollutant>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DominantPollutant(string value) { throw null; }
        public static Azure.Maps.Weather.Models.DominantPollutant CarbonMonoxide { get { throw null; } }
        public static Azure.Maps.Weather.Models.DominantPollutant NitrogenDioxide { get { throw null; } }
        public static Azure.Maps.Weather.Models.DominantPollutant Ozone { get { throw null; } }
        public static Azure.Maps.Weather.Models.DominantPollutant ParticulateMatter10 { get { throw null; } }
        public static Azure.Maps.Weather.Models.DominantPollutant ParticulateMatter25 { get { throw null; } }
        public static Azure.Maps.Weather.Models.DominantPollutant SulfurDioxide { get { throw null; } }
        public bool Equals(Azure.Maps.Weather.Models.DominantPollutant other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Weather.Models.DominantPollutant left, Azure.Maps.Weather.Models.DominantPollutant right) { throw null; }
        public static implicit operator Azure.Maps.Weather.Models.DominantPollutant (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Weather.Models.DominantPollutant left, Azure.Maps.Weather.Models.DominantPollutant right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ForecastInterval
    {
        internal ForecastInterval() { }
        public int? CloudCover { get { throw null; } }
        public Azure.Maps.Weather.Models.ColorValue Color { get { throw null; } }
        public double? DecibelRelativeToZ { get { throw null; } }
        public Azure.Maps.Weather.Models.IconCode? IconCode { get { throw null; } }
        public int? Minute { get { throw null; } }
        public Azure.Maps.Weather.Models.PrecipitationType? PrecipitationType { get { throw null; } }
        public string ShortDescription { get { throw null; } }
        public Azure.Maps.Weather.Models.ColorValue SimplifiedColor { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public string Threshold { get { throw null; } }
    }
    public partial class HazardDetail
    {
        internal HazardDetail() { }
        public string HazardCode { get { throw null; } }
        public Azure.Maps.Weather.Models.HazardIndex? HazardIndex { get { throw null; } }
        public string ShortDescription { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HazardIndex : System.IEquatable<Azure.Maps.Weather.Models.HazardIndex>
    {
        private readonly int _dummyPrimitive;
        public HazardIndex(int value) { throw null; }
        public static Azure.Maps.Weather.Models.HazardIndex Emergency { get { throw null; } }
        public static Azure.Maps.Weather.Models.HazardIndex Informed { get { throw null; } }
        public static Azure.Maps.Weather.Models.HazardIndex NoHazard { get { throw null; } }
        public static Azure.Maps.Weather.Models.HazardIndex PayAttention { get { throw null; } }
        public static Azure.Maps.Weather.Models.HazardIndex TakeAction { get { throw null; } }
        public bool Equals(Azure.Maps.Weather.Models.HazardIndex other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Weather.Models.HazardIndex left, Azure.Maps.Weather.Models.HazardIndex right) { throw null; }
        public static implicit operator Azure.Maps.Weather.Models.HazardIndex (int value) { throw null; }
        public static bool operator !=(Azure.Maps.Weather.Models.HazardIndex left, Azure.Maps.Weather.Models.HazardIndex right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HourlyDuration : System.IEquatable<Azure.Maps.Weather.Models.HourlyDuration>
    {
        private readonly int _dummyPrimitive;
        public HourlyDuration(int value) { throw null; }
        public static Azure.Maps.Weather.Models.HourlyDuration FortyEightHours { get { throw null; } }
        public static Azure.Maps.Weather.Models.HourlyDuration NinetySixHours { get { throw null; } }
        public static Azure.Maps.Weather.Models.HourlyDuration OneHour { get { throw null; } }
        public static Azure.Maps.Weather.Models.HourlyDuration SeventyTwoHours { get { throw null; } }
        public static Azure.Maps.Weather.Models.HourlyDuration TwelveHours { get { throw null; } }
        public static Azure.Maps.Weather.Models.HourlyDuration TwentyFourHours { get { throw null; } }
        public bool Equals(Azure.Maps.Weather.Models.HourlyDuration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Weather.Models.HourlyDuration left, Azure.Maps.Weather.Models.HourlyDuration right) { throw null; }
        public static implicit operator Azure.Maps.Weather.Models.HourlyDuration (int value) { throw null; }
        public static bool operator !=(Azure.Maps.Weather.Models.HourlyDuration left, Azure.Maps.Weather.Models.HourlyDuration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HourlyForecast
    {
        internal HourlyForecast() { }
        public Azure.Maps.Weather.Models.WeatherValue CloudCeiling { get { throw null; } }
        public int? CloudCover { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue DewPoint { get { throw null; } }
        public bool? HasPrecipitation { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Ice { get { throw null; } }
        public int? IceProbability { get { throw null; } }
        public Azure.Maps.Weather.Models.IconCode? IconCode { get { throw null; } }
        public string IconPhrase { get { throw null; } }
        public bool? IsDaylight { get { throw null; } }
        public int? PrecipitationProbability { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Rain { get { throw null; } }
        public int? RainProbability { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue RealFeelTemperature { get { throw null; } }
        public int? RelativeHumidity { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Snow { get { throw null; } }
        public int? SnowProbability { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Temperature { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue TotalLiquid { get { throw null; } }
        public int? UvIndex { get { throw null; } }
        public string UvIndexDescription { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Visibility { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue WetBulbTemperature { get { throw null; } }
        public Azure.Maps.Weather.Models.WindDetails Wind { get { throw null; } }
        public Azure.Maps.Weather.Models.WindDetails WindGust { get { throw null; } }
    }
    public partial class HourlyForecastResult
    {
        internal HourlyForecastResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.HourlyForecast> Forecasts { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IconCode : System.IEquatable<Azure.Maps.Weather.Models.IconCode>
    {
        private readonly int _dummyPrimitive;
        public IconCode(int value) { throw null; }
        public static Azure.Maps.Weather.Models.IconCode Clear { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode Cloudy { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode Cold { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode Dreary { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode Flurries { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode Fog { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode FreezingRain { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode HazyMoonlight { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode HazySunshine { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode Hot { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode Ice { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode IntermittentClouds { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode IntermittentCloudsNight { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode MostlyClear { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode MostlyCloudy { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode MostlyCloudyNight { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode MostlyCloudyWithFlurries { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode MostlyCloudyWithFlurriesNight { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode MostlyCloudyWithShowers { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode MostlyCloudyWithShowersNight { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode MostlyCloudyWithSnow { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode MostlyCloudyWithSnowNight { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode MostlyCloudyWithThunderstorms { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode MostlyCloudyWithThunderstormsNight { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode MostlySunny { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode PartlyCloudy { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode PartlyCloudyWithShowers { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode PartlyCloudyWithThunderstorms { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode PartlySunny { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode PartlySunnyWithFlurries { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode PartlySunnyWithShowers { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode PartlySunnyWithThunderstorms { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode Rain { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode RainAndSnow { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode Showers { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode Sleet { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode Snow { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode Sunny { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode Thunderstorms { get { throw null; } }
        public static Azure.Maps.Weather.Models.IconCode Windy { get { throw null; } }
        public bool Equals(Azure.Maps.Weather.Models.IconCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Weather.Models.IconCode left, Azure.Maps.Weather.Models.IconCode right) { throw null; }
        public static implicit operator Azure.Maps.Weather.Models.IconCode (int value) { throw null; }
        public static bool operator !=(Azure.Maps.Weather.Models.IconCode left, Azure.Maps.Weather.Models.IconCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntervalSummary
    {
        internal IntervalSummary() { }
        public string BriefDescription { get { throw null; } }
        public int? EndMinute { get { throw null; } }
        public Azure.Maps.Weather.Models.IconCode? IconCode { get { throw null; } }
        public string LongPhrase { get { throw null; } }
        public string ShortDescription { get { throw null; } }
        public int? StartMinute { get { throw null; } }
        public int? TotalMinutes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JsonFormat : System.IEquatable<Azure.Maps.Weather.Models.JsonFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JsonFormat(string value) { throw null; }
        public static Azure.Maps.Weather.Models.JsonFormat Json { get { throw null; } }
        public bool Equals(Azure.Maps.Weather.Models.JsonFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Weather.Models.JsonFormat left, Azure.Maps.Weather.Models.JsonFormat right) { throw null; }
        public static implicit operator Azure.Maps.Weather.Models.JsonFormat (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Weather.Models.JsonFormat left, Azure.Maps.Weather.Models.JsonFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LatestStatus
    {
        internal LatestStatus() { }
        public Azure.Maps.Weather.Models.LatestStatusKeyword? English { get { throw null; } }
        public string Localized { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LatestStatusKeyword : System.IEquatable<Azure.Maps.Weather.Models.LatestStatusKeyword>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LatestStatusKeyword(string value) { throw null; }
        public static Azure.Maps.Weather.Models.LatestStatusKeyword Cancel { get { throw null; } }
        public static Azure.Maps.Weather.Models.LatestStatusKeyword Continue { get { throw null; } }
        public static Azure.Maps.Weather.Models.LatestStatusKeyword Correct { get { throw null; } }
        public static Azure.Maps.Weather.Models.LatestStatusKeyword Expire { get { throw null; } }
        public static Azure.Maps.Weather.Models.LatestStatusKeyword Extend { get { throw null; } }
        public static Azure.Maps.Weather.Models.LatestStatusKeyword New { get { throw null; } }
        public static Azure.Maps.Weather.Models.LatestStatusKeyword Update { get { throw null; } }
        public static Azure.Maps.Weather.Models.LatestStatusKeyword Upgrade { get { throw null; } }
        public bool Equals(Azure.Maps.Weather.Models.LatestStatusKeyword other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Weather.Models.LatestStatusKeyword left, Azure.Maps.Weather.Models.LatestStatusKeyword right) { throw null; }
        public static implicit operator Azure.Maps.Weather.Models.LatestStatusKeyword (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Weather.Models.LatestStatusKeyword left, Azure.Maps.Weather.Models.LatestStatusKeyword right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LatLongPair
    {
        internal LatLongPair() { }
        public double? Latitude { get { throw null; } }
        public double? Longitude { get { throw null; } }
    }
    public partial class LocalSource
    {
        internal LocalSource() { }
        public int? Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string WeatherCode { get { throw null; } }
    }
    public static partial class MapsWeatherModelFactory
    {
        public static Azure.Maps.Weather.Models.ActiveStorm ActiveStorm(string year = null, Azure.Maps.Weather.Models.BasinId? basinId = default(Azure.Maps.Weather.Models.BasinId?), string name = null, bool? isActive = default(bool?), bool? isSubtropical = default(bool?), int? govId = default(int?)) { throw null; }
        public static Azure.Maps.Weather.Models.ActiveStormResult ActiveStormResult(System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.ActiveStorm> activeStorms = null, string nextLink = null) { throw null; }
        public static Azure.Maps.Weather.Models.AirAndPollen AirAndPollen(string description = null, int? value = default(int?), string category = null, int? categoryValue = default(int?), string airQualityType = null) { throw null; }
        public static Azure.Maps.Weather.Models.AirQuality AirQuality(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), float? index = default(float?), float? globalIndex = default(float?), Azure.Maps.Weather.Models.DominantPollutant? dominantPollutant = default(Azure.Maps.Weather.Models.DominantPollutant?), string category = null, string categoryColor = null, string description = null, System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.Pollutant> pollutants = null) { throw null; }
        public static Azure.Maps.Weather.Models.AirQualityResult AirQualityResult(System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.AirQuality> airQualityResults = null, string nextLink = null) { throw null; }
        public static Azure.Maps.Weather.Models.AlertDetails AlertDetails(string name = null, string description = null, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), Azure.Maps.Weather.Models.LatestStatus latestStatus = null, string details = null, string language = null) { throw null; }
        public static Azure.Maps.Weather.Models.ColorValue ColorValue(int? red = default(int?), int? green = default(int?), int? blue = default(int?), string hex = null) { throw null; }
        public static Azure.Maps.Weather.Models.CurrentConditions CurrentConditions(System.DateTimeOffset? dateTime = default(System.DateTimeOffset?), string description = null, Azure.Maps.Weather.Models.IconCode? iconCode = default(Azure.Maps.Weather.Models.IconCode?), bool? hasPrecipitation = default(bool?), bool? isDaytime = default(bool?), Azure.Maps.Weather.Models.WeatherValue temperature = null, Azure.Maps.Weather.Models.WeatherValue realFeelTemperature = null, Azure.Maps.Weather.Models.WeatherValue realFeelTemperatureShade = null, int? relativeHumidity = default(int?), Azure.Maps.Weather.Models.WeatherValue dewPoint = null, Azure.Maps.Weather.Models.WindDetails wind = null, Azure.Maps.Weather.Models.WindDetails windGust = null, int? uvIndex = default(int?), string uvIndexDescription = null, Azure.Maps.Weather.Models.WeatherValue visibility = null, string obstructionsToVisibility = null, int? cloudCover = default(int?), Azure.Maps.Weather.Models.WeatherValue cloudCeiling = null, Azure.Maps.Weather.Models.WeatherValue pressure = null, Azure.Maps.Weather.Models.PressureTendency pressureTendency = null, Azure.Maps.Weather.Models.WeatherValue pastTwentyFourHourTemperatureDeparture = null, Azure.Maps.Weather.Models.WeatherValue apparentTemperature = null, Azure.Maps.Weather.Models.WeatherValue windChillTemperature = null, Azure.Maps.Weather.Models.WeatherValue wetBulbTemperature = null, Azure.Maps.Weather.Models.PrecipitationSummary precipitationSummary = null, Azure.Maps.Weather.Models.TemperatureSummary temperatureSummary = null) { throw null; }
        public static Azure.Maps.Weather.Models.CurrentConditionsResult CurrentConditionsResult(System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.CurrentConditions> results = null) { throw null; }
        public static Azure.Maps.Weather.Models.DailyAirQuality DailyAirQuality(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), float? index = default(float?), float? globalIndex = default(float?), Azure.Maps.Weather.Models.DominantPollutant? dominantPollutant = default(Azure.Maps.Weather.Models.DominantPollutant?), string category = null, string categoryColor = null, string description = null) { throw null; }
        public static Azure.Maps.Weather.Models.DailyAirQualityForecastResult DailyAirQualityForecastResult(System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.DailyAirQuality> airQualityResults = null, string nextLink = null) { throw null; }
        public static Azure.Maps.Weather.Models.DailyForecast DailyForecast(System.DateTimeOffset? dateTime = default(System.DateTimeOffset?), Azure.Maps.Weather.Models.WeatherValueRange temperature = null, Azure.Maps.Weather.Models.WeatherValueRange realFeelTemperature = null, Azure.Maps.Weather.Models.WeatherValueRange realFeelTemperatureShade = null, float? hoursOfSun = default(float?), Azure.Maps.Weather.Models.DegreeDaySummary meanTemperatureDeviation = null, System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.AirAndPollen> airQuality = null, Azure.Maps.Weather.Models.DailyForecastDetail daytimeForecast = null, Azure.Maps.Weather.Models.DailyForecastDetail nighttimeForecast = null, System.Collections.Generic.IEnumerable<string> sources = null) { throw null; }
        public static Azure.Maps.Weather.Models.DailyForecastDetail DailyForecastDetail(Azure.Maps.Weather.Models.IconCode? iconCode = default(Azure.Maps.Weather.Models.IconCode?), string iconPhrase = null, Azure.Maps.Weather.Models.LocalSource localSource = null, bool? hasPrecipitation = default(bool?), Azure.Maps.Weather.Models.PrecipitationType? precipitationType = default(Azure.Maps.Weather.Models.PrecipitationType?), string precipitationIntensity = null, string shortDescription = null, string longPhrase = null, int? precipitationProbability = default(int?), int? thunderstormProbability = default(int?), int? rainProbability = default(int?), int? snowProbability = default(int?), int? iceProbability = default(int?), Azure.Maps.Weather.Models.WindDetails wind = null, Azure.Maps.Weather.Models.WindDetails windGust = null, Azure.Maps.Weather.Models.WeatherValue totalLiquid = null, Azure.Maps.Weather.Models.WeatherValue rain = null, Azure.Maps.Weather.Models.WeatherValue snow = null, Azure.Maps.Weather.Models.WeatherValue ice = null, float? hoursOfPrecipitation = default(float?), float? hoursOfRain = default(float?), float? hoursOfSnow = default(float?), float? hoursOfIce = default(float?), int? cloudCover = default(int?)) { throw null; }
        public static Azure.Maps.Weather.Models.DailyForecastResult DailyForecastResult(Azure.Maps.Weather.Models.DailyForecastSummary summary = null, System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.DailyForecast> forecasts = null) { throw null; }
        public static Azure.Maps.Weather.Models.DailyForecastSummary DailyForecastSummary(System.DateTimeOffset? startDate = default(System.DateTimeOffset?), System.DateTimeOffset? endDate = default(System.DateTimeOffset?), int? severity = default(int?), string phrase = null, string category = null) { throw null; }
        public static Azure.Maps.Weather.Models.DailyHistoricalActuals DailyHistoricalActuals(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), Azure.Maps.Weather.Models.WeatherValueMaxMinAvg temperature = null, Azure.Maps.Weather.Models.DegreeDaySummary degreeDaySummary = null, Azure.Maps.Weather.Models.WeatherValue precipitation = null, Azure.Maps.Weather.Models.WeatherValue snowfall = null, Azure.Maps.Weather.Models.WeatherValue snowDepth = null) { throw null; }
        public static Azure.Maps.Weather.Models.DailyHistoricalActualsResult DailyHistoricalActualsResult(System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.DailyHistoricalActuals> historicalActuals = null, string nextLink = null) { throw null; }
        public static Azure.Maps.Weather.Models.DailyHistoricalNormals DailyHistoricalNormals(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), Azure.Maps.Weather.Models.WeatherValueMaxMinAvg temperature = null, Azure.Maps.Weather.Models.DegreeDaySummary degreeDaySummary = null, Azure.Maps.Weather.Models.WeatherValue precipitation = null) { throw null; }
        public static Azure.Maps.Weather.Models.DailyHistoricalNormalsResult DailyHistoricalNormalsResult(System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.DailyHistoricalNormals> historicalNormals = null, string nextLink = null) { throw null; }
        public static Azure.Maps.Weather.Models.DailyHistoricalRecords DailyHistoricalRecords(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), Azure.Maps.Weather.Models.WeatherValueYearMaxMinAvg temperature = null, Azure.Maps.Weather.Models.WeatherValueYearMax precipitation = null, Azure.Maps.Weather.Models.WeatherValueYearMax snowfall = null) { throw null; }
        public static Azure.Maps.Weather.Models.DailyHistoricalRecordsResult DailyHistoricalRecordsResult(System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.DailyHistoricalRecords> historicalRecords = null, string nextLink = null) { throw null; }
        public static Azure.Maps.Weather.Models.DailyIndex DailyIndex(string indexName = null, int? indexId = default(int?), System.DateTimeOffset? dateTime = default(System.DateTimeOffset?), float? value = default(float?), string categoryDescription = null, int? categoryValue = default(int?), bool? isAscending = default(bool?), string description = null) { throw null; }
        public static Azure.Maps.Weather.Models.DailyIndicesResult DailyIndicesResult(System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.DailyIndex> results = null) { throw null; }
        public static Azure.Maps.Weather.Models.DegreeDaySummary DegreeDaySummary(Azure.Maps.Weather.Models.WeatherValue heating = null, Azure.Maps.Weather.Models.WeatherValue cooling = null) { throw null; }
        public static Azure.Maps.Weather.Models.ForecastInterval ForecastInterval(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), int? minute = default(int?), double? decibelRelativeToZ = default(double?), string shortDescription = null, string threshold = null, Azure.Maps.Weather.Models.ColorValue color = null, Azure.Maps.Weather.Models.ColorValue simplifiedColor = null, Azure.Maps.Weather.Models.PrecipitationType? precipitationType = default(Azure.Maps.Weather.Models.PrecipitationType?), Azure.Maps.Weather.Models.IconCode? iconCode = default(Azure.Maps.Weather.Models.IconCode?), int? cloudCover = default(int?)) { throw null; }
        public static Azure.Maps.Weather.Models.HazardDetail HazardDetail(Azure.Maps.Weather.Models.HazardIndex? hazardIndex = default(Azure.Maps.Weather.Models.HazardIndex?), string hazardCode = null, string shortDescription = null) { throw null; }
        public static Azure.Maps.Weather.Models.HourlyForecast HourlyForecast(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), Azure.Maps.Weather.Models.IconCode? iconCode = default(Azure.Maps.Weather.Models.IconCode?), string iconPhrase = null, bool? hasPrecipitation = default(bool?), bool? isDaylight = default(bool?), Azure.Maps.Weather.Models.WeatherValue temperature = null, Azure.Maps.Weather.Models.WeatherValue realFeelTemperature = null, Azure.Maps.Weather.Models.WeatherValue wetBulbTemperature = null, Azure.Maps.Weather.Models.WeatherValue dewPoint = null, Azure.Maps.Weather.Models.WindDetails wind = null, Azure.Maps.Weather.Models.WindDetails windGust = null, int? relativeHumidity = default(int?), Azure.Maps.Weather.Models.WeatherValue visibility = null, Azure.Maps.Weather.Models.WeatherValue cloudCeiling = null, int? uvIndex = default(int?), string uvIndexDescription = null, int? precipitationProbability = default(int?), int? rainProbability = default(int?), int? snowProbability = default(int?), int? iceProbability = default(int?), Azure.Maps.Weather.Models.WeatherValue totalLiquid = null, Azure.Maps.Weather.Models.WeatherValue rain = null, Azure.Maps.Weather.Models.WeatherValue snow = null, Azure.Maps.Weather.Models.WeatherValue ice = null, int? cloudCover = default(int?)) { throw null; }
        public static Azure.Maps.Weather.Models.HourlyForecastResult HourlyForecastResult(System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.HourlyForecast> forecasts = null) { throw null; }
        public static Azure.Maps.Weather.Models.IntervalSummary IntervalSummary(int? startMinute = default(int?), int? endMinute = default(int?), int? totalMinutes = default(int?), string shortDescription = null, string briefDescription = null, string longPhrase = null, Azure.Maps.Weather.Models.IconCode? iconCode = default(Azure.Maps.Weather.Models.IconCode?)) { throw null; }
        public static Azure.Maps.Weather.Models.LatestStatus LatestStatus(string localized = null, Azure.Maps.Weather.Models.LatestStatusKeyword? english = default(Azure.Maps.Weather.Models.LatestStatusKeyword?)) { throw null; }
        public static Azure.Maps.Weather.Models.LatLongPair LatLongPair(double? latitude = default(double?), double? longitude = default(double?)) { throw null; }
        public static Azure.Maps.Weather.Models.LocalSource LocalSource(int? id = default(int?), string name = null, string weatherCode = null) { throw null; }
        public static Azure.Maps.Weather.Models.MinuteForecastResult MinuteForecastResult(Azure.Maps.Weather.Models.MinuteForecastSummary summary = null, System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.IntervalSummary> intervalSummaries = null, System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.ForecastInterval> intervals = null) { throw null; }
        public static Azure.Maps.Weather.Models.MinuteForecastSummary MinuteForecastSummary(string briefPhrase60 = null, string shortDescription = null, string briefDescription = null, string longPhrase = null, Azure.Maps.Weather.Models.IconCode? iconCode = default(Azure.Maps.Weather.Models.IconCode?)) { throw null; }
        public static Azure.Maps.Weather.Models.PastHoursTemperature PastHoursTemperature(Azure.Maps.Weather.Models.WeatherValue minimum = null, Azure.Maps.Weather.Models.WeatherValue maximum = null) { throw null; }
        public static Azure.Maps.Weather.Models.Pollutant Pollutant(Azure.Maps.Weather.Models.PollutantType? type = default(Azure.Maps.Weather.Models.PollutantType?), string name = null, float? index = default(float?), float? globalIndex = default(float?), Azure.Maps.Weather.Models.WeatherValue concentration = null) { throw null; }
        public static Azure.Maps.Weather.Models.PrecipitationSummary PrecipitationSummary(Azure.Maps.Weather.Models.WeatherValue pastHour = null, Azure.Maps.Weather.Models.WeatherValue pastThreeHours = null, Azure.Maps.Weather.Models.WeatherValue pastSixHours = null, Azure.Maps.Weather.Models.WeatherValue pastNineHours = null, Azure.Maps.Weather.Models.WeatherValue pastTwelveHours = null, Azure.Maps.Weather.Models.WeatherValue pastEighteenHours = null, Azure.Maps.Weather.Models.WeatherValue pastTwentyFourHours = null) { throw null; }
        public static Azure.Maps.Weather.Models.PressureTendency PressureTendency(string description = null, string code = null) { throw null; }
        public static Azure.Maps.Weather.Models.QuarterDayForecast QuarterDayForecast(System.DateTimeOffset? dateTime = default(System.DateTimeOffset?), System.DateTimeOffset? effectiveDate = default(System.DateTimeOffset?), Azure.Maps.Weather.Models.DayQuarter? quarter = default(Azure.Maps.Weather.Models.DayQuarter?), Azure.Maps.Weather.Models.IconCode? iconCode = default(Azure.Maps.Weather.Models.IconCode?), string iconPhrase = null, string phrase = null, Azure.Maps.Weather.Models.WeatherValueRange temperature = null, Azure.Maps.Weather.Models.WeatherValueRange realFeelTemperature = null, Azure.Maps.Weather.Models.WeatherValue dewPoint = null, int? relativeHumidity = default(int?), Azure.Maps.Weather.Models.WindDetails wind = null, Azure.Maps.Weather.Models.WindDetails windGust = null, Azure.Maps.Weather.Models.WeatherValue visibility = null, int? cloudCover = default(int?), bool? hasPrecipitation = default(bool?), Azure.Maps.Weather.Models.PrecipitationType? precipitationType = default(Azure.Maps.Weather.Models.PrecipitationType?), string precipitationIntensity = null, int? precipitationProbability = default(int?), int? thunderstormProbability = default(int?), Azure.Maps.Weather.Models.WeatherValue totalLiquid = null, Azure.Maps.Weather.Models.WeatherValue rain = null, Azure.Maps.Weather.Models.WeatherValue snow = null, Azure.Maps.Weather.Models.WeatherValue ice = null) { throw null; }
        public static Azure.Maps.Weather.Models.QuarterDayForecastResult QuarterDayForecastResult(System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.QuarterDayForecast> forecasts = null) { throw null; }
        public static Azure.Maps.Weather.Models.RadiusSector RadiusSector(double? beginBearing = default(double?), double? endBearing = default(double?), double? radius = default(double?)) { throw null; }
        public static Azure.Maps.Weather.Models.SevereWeatherAlert SevereWeatherAlert(string countryCode = null, int? alertId = default(int?), Azure.Maps.Weather.Models.SevereWeatherAlertDescription description = null, string category = null, int? priority = default(int?), string classification = null, string level = null, string source = null, int? sourceId = default(int?), string disclaimer = null, System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.AlertDetails> alertDetails = null) { throw null; }
        public static Azure.Maps.Weather.Models.SevereWeatherAlertDescription SevereWeatherAlertDescription(string description = null, string status = null) { throw null; }
        public static Azure.Maps.Weather.Models.SevereWeatherAlertsResult SevereWeatherAlertsResult(System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.SevereWeatherAlert> results = null) { throw null; }
        public static Azure.Maps.Weather.Models.StormForecast StormForecast(string timestamp = null, string initializedTimestamp = null, Azure.Maps.Weather.Models.LatLongPair coordinates = null, Azure.Maps.Weather.Models.WeatherValue maxWindGust = null, Azure.Maps.Weather.Models.WeatherValue sustainedWind = null, string status = null, Azure.Maps.Weather.Models.WeatherWindow weatherWindow = null, System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.StormWindRadiiSummary> windRadiiSummary = null) { throw null; }
        public static Azure.Maps.Weather.Models.StormForecastResult StormForecastResult(System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.StormForecast> stormForecasts = null, string nextLink = null) { throw null; }
        public static Azure.Maps.Weather.Models.StormLocation StormLocation(string timestamp = null, Azure.Maps.Weather.Models.LatLongPair coordinates = null, Azure.Maps.Weather.Models.WeatherValue maxWindGust = null, Azure.Maps.Weather.Models.WeatherValue sustainedWind = null, Azure.Maps.Weather.Models.WeatherValue minimumPressure = null, Azure.Maps.Weather.Models.WindDetails movement = null, string status = null, bool? isSubtropical = default(bool?), bool? hasTropicalPotential = default(bool?), bool? isPostTropical = default(bool?), System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.StormWindRadiiSummary> windRadiiSummary = null) { throw null; }
        public static Azure.Maps.Weather.Models.StormLocationsResult StormLocationsResult(System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.StormLocation> stormLocations = null, string nextLink = null) { throw null; }
        public static Azure.Maps.Weather.Models.StormSearchResult StormSearchResult(System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.StormSearchResultItem> storms = null, string nextLink = null) { throw null; }
        public static Azure.Maps.Weather.Models.StormSearchResultItem StormSearchResultItem(string year = null, Azure.Maps.Weather.Models.BasinId? basinId = default(Azure.Maps.Weather.Models.BasinId?), string name = null, bool? isActive = default(bool?), bool? isRetired = default(bool?), bool? isSubtropical = default(bool?), int? govId = default(int?)) { throw null; }
        public static Azure.Maps.Weather.Models.StormWindRadiiSummary StormWindRadiiSummary(string timestamp = null, Azure.Maps.Weather.Models.WeatherValue windSpeed = null, System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.RadiusSector> radiusSectorData = null, Azure.Core.GeoJson.GeoObject radiiGeometry = null) { throw null; }
        public static Azure.Maps.Weather.Models.SunGlare SunGlare(int? calculatedVehicleHeading = default(int?), int? glareIndex = default(int?)) { throw null; }
        public static Azure.Maps.Weather.Models.TemperatureSummary TemperatureSummary(Azure.Maps.Weather.Models.PastHoursTemperature pastSixHours = null, Azure.Maps.Weather.Models.PastHoursTemperature pastTwelveHours = null, Azure.Maps.Weather.Models.PastHoursTemperature pastTwentyFourHours = null) { throw null; }
        public static Azure.Maps.Weather.Models.WaypointForecast WaypointForecast(Azure.Maps.Weather.Models.IconCode? iconCode = default(Azure.Maps.Weather.Models.IconCode?), string shortDescription = null, bool? isDaytime = default(bool?), int? cloudCover = default(int?), Azure.Maps.Weather.Models.WeatherValue temperature = null, Azure.Maps.Weather.Models.WindDetails wind = null, Azure.Maps.Weather.Models.WindDetails windGust = null, Azure.Maps.Weather.Models.WeatherAlongRoutePrecipitation precipitation = null, int? lightningCount = default(int?), Azure.Maps.Weather.Models.SunGlare sunGlare = null, Azure.Maps.Weather.Models.WeatherHazards hazards = null, System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.WeatherNotification> notifications = null) { throw null; }
        public static Azure.Maps.Weather.Models.WeatherAlongRoutePrecipitation WeatherAlongRoutePrecipitation(double? dbz = default(double?), string type = null) { throw null; }
        public static Azure.Maps.Weather.Models.WeatherAlongRouteResult WeatherAlongRouteResult(Azure.Maps.Weather.Models.WeatherAlongRouteSummary summary = null, System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.WaypointForecast> waypoints = null) { throw null; }
        public static Azure.Maps.Weather.Models.WeatherAlongRouteSummary WeatherAlongRouteSummary(Azure.Maps.Weather.Models.IconCode? iconCode = default(Azure.Maps.Weather.Models.IconCode?), Azure.Maps.Weather.Models.WeatherHazards hazards = null) { throw null; }
        public static Azure.Maps.Weather.Models.WeatherHazards WeatherHazards(Azure.Maps.Weather.Models.HazardIndex? maxHazardIndex = default(Azure.Maps.Weather.Models.HazardIndex?), System.Collections.Generic.IEnumerable<Azure.Maps.Weather.Models.HazardDetail> details = null) { throw null; }
        public static Azure.Maps.Weather.Models.WeatherNotification WeatherNotification(string type = null, Azure.Maps.Weather.Models.HazardIndex? hazardIndex = default(Azure.Maps.Weather.Models.HazardIndex?), string hazardCode = null, string shortDescription = null) { throw null; }
        public static Azure.Maps.Weather.Models.WeatherValue WeatherValue(float? value = default(float?), string unitLabel = null, Azure.Maps.Weather.Models.UnitType? unitType = default(Azure.Maps.Weather.Models.UnitType?)) { throw null; }
        public static Azure.Maps.Weather.Models.WeatherValueMaxMinAvg WeatherValueMaxMinAvg(Azure.Maps.Weather.Models.WeatherValue maximum = null, Azure.Maps.Weather.Models.WeatherValue minimum = null, Azure.Maps.Weather.Models.WeatherValue average = null) { throw null; }
        public static Azure.Maps.Weather.Models.WeatherValueRange WeatherValueRange(Azure.Maps.Weather.Models.WeatherValue minimum = null, Azure.Maps.Weather.Models.WeatherValue maximum = null) { throw null; }
        public static Azure.Maps.Weather.Models.WeatherValueYear WeatherValueYear(float? value = default(float?), string unit = null, int? unitType = default(int?), int? year = default(int?)) { throw null; }
        public static Azure.Maps.Weather.Models.WeatherValueYearMax WeatherValueYearMax(Azure.Maps.Weather.Models.WeatherValueYear maximum = null) { throw null; }
        public static Azure.Maps.Weather.Models.WeatherValueYearMaxMinAvg WeatherValueYearMaxMinAvg(Azure.Maps.Weather.Models.WeatherValueYear maximum = null, Azure.Maps.Weather.Models.WeatherValueYear minimum = null, Azure.Maps.Weather.Models.WeatherValue average = null) { throw null; }
        public static Azure.Maps.Weather.Models.WeatherWindow WeatherWindow(Azure.Maps.Weather.Models.LatLongPair topLeft = null, Azure.Maps.Weather.Models.LatLongPair bottomRight = null, System.DateTimeOffset? beginTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? endTimestamp = default(System.DateTimeOffset?), string beginStatus = null, string endStatus = null, Azure.Core.GeoJson.GeoObject geometry = null) { throw null; }
        public static Azure.Maps.Weather.Models.WindDetails WindDetails(Azure.Maps.Weather.Models.WindDirection direction = null, Azure.Maps.Weather.Models.WeatherValue speed = null) { throw null; }
        public static Azure.Maps.Weather.Models.WindDirection WindDirection(int? degrees = default(int?), string description = null) { throw null; }
    }
    public partial class MinuteForecastResult
    {
        internal MinuteForecastResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.ForecastInterval> Intervals { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.IntervalSummary> IntervalSummaries { get { throw null; } }
        public Azure.Maps.Weather.Models.MinuteForecastSummary Summary { get { throw null; } }
    }
    public partial class MinuteForecastSummary
    {
        internal MinuteForecastSummary() { }
        public string BriefDescription { get { throw null; } }
        public string BriefPhrase60 { get { throw null; } }
        public Azure.Maps.Weather.Models.IconCode? IconCode { get { throw null; } }
        public string LongPhrase { get { throw null; } }
        public string ShortDescription { get { throw null; } }
    }
    public partial class PastHoursTemperature
    {
        internal PastHoursTemperature() { }
        public Azure.Maps.Weather.Models.WeatherValue Maximum { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Minimum { get { throw null; } }
    }
    public partial class Pollutant
    {
        internal Pollutant() { }
        public Azure.Maps.Weather.Models.WeatherValue Concentration { get { throw null; } }
        public float? GlobalIndex { get { throw null; } }
        public float? Index { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Maps.Weather.Models.PollutantType? Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PollutantType : System.IEquatable<Azure.Maps.Weather.Models.PollutantType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PollutantType(string value) { throw null; }
        public static Azure.Maps.Weather.Models.PollutantType CO { get { throw null; } }
        public static Azure.Maps.Weather.Models.PollutantType NO2 { get { throw null; } }
        public static Azure.Maps.Weather.Models.PollutantType O3 { get { throw null; } }
        public static Azure.Maps.Weather.Models.PollutantType PM10 { get { throw null; } }
        public static Azure.Maps.Weather.Models.PollutantType PM25 { get { throw null; } }
        public static Azure.Maps.Weather.Models.PollutantType SO2 { get { throw null; } }
        public bool Equals(Azure.Maps.Weather.Models.PollutantType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Weather.Models.PollutantType left, Azure.Maps.Weather.Models.PollutantType right) { throw null; }
        public static implicit operator Azure.Maps.Weather.Models.PollutantType (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Weather.Models.PollutantType left, Azure.Maps.Weather.Models.PollutantType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrecipitationSummary
    {
        internal PrecipitationSummary() { }
        public Azure.Maps.Weather.Models.WeatherValue PastEighteenHours { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue PastHour { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue PastNineHours { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue PastSixHours { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue PastThreeHours { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue PastTwelveHours { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue PastTwentyFourHours { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrecipitationType : System.IEquatable<Azure.Maps.Weather.Models.PrecipitationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrecipitationType(string value) { throw null; }
        public static Azure.Maps.Weather.Models.PrecipitationType Ice { get { throw null; } }
        public static Azure.Maps.Weather.Models.PrecipitationType Mix { get { throw null; } }
        public static Azure.Maps.Weather.Models.PrecipitationType Rain { get { throw null; } }
        public static Azure.Maps.Weather.Models.PrecipitationType Snow { get { throw null; } }
        public bool Equals(Azure.Maps.Weather.Models.PrecipitationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Weather.Models.PrecipitationType left, Azure.Maps.Weather.Models.PrecipitationType right) { throw null; }
        public static implicit operator Azure.Maps.Weather.Models.PrecipitationType (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Weather.Models.PrecipitationType left, Azure.Maps.Weather.Models.PrecipitationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PressureTendency
    {
        internal PressureTendency() { }
        public string Code { get { throw null; } }
        public string Description { get { throw null; } }
    }
    public partial class QuarterDayForecast
    {
        internal QuarterDayForecast() { }
        public int? CloudCover { get { throw null; } }
        public System.DateTimeOffset? DateTime { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue DewPoint { get { throw null; } }
        public System.DateTimeOffset? EffectiveDate { get { throw null; } }
        public bool? HasPrecipitation { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Ice { get { throw null; } }
        public Azure.Maps.Weather.Models.IconCode? IconCode { get { throw null; } }
        public string IconPhrase { get { throw null; } }
        public string Phrase { get { throw null; } }
        public string PrecipitationIntensity { get { throw null; } }
        public int? PrecipitationProbability { get { throw null; } }
        public Azure.Maps.Weather.Models.PrecipitationType? PrecipitationType { get { throw null; } }
        public Azure.Maps.Weather.Models.DayQuarter? Quarter { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Rain { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValueRange RealFeelTemperature { get { throw null; } }
        public int? RelativeHumidity { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Snow { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValueRange Temperature { get { throw null; } }
        public int? ThunderstormProbability { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue TotalLiquid { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Visibility { get { throw null; } }
        public Azure.Maps.Weather.Models.WindDetails Wind { get { throw null; } }
        public Azure.Maps.Weather.Models.WindDetails WindGust { get { throw null; } }
    }
    public partial class QuarterDayForecastResult
    {
        internal QuarterDayForecastResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.QuarterDayForecast> Forecasts { get { throw null; } }
    }
    public partial class RadiusSector
    {
        internal RadiusSector() { }
        public double? BeginBearing { get { throw null; } }
        public double? EndBearing { get { throw null; } }
        public double? Radius { get { throw null; } }
    }
    public partial class SevereWeatherAlert
    {
        internal SevereWeatherAlert() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.AlertDetails> AlertDetails { get { throw null; } }
        public int? AlertId { get { throw null; } }
        public string Category { get { throw null; } }
        public string Classification { get { throw null; } }
        public string CountryCode { get { throw null; } }
        public Azure.Maps.Weather.Models.SevereWeatherAlertDescription Description { get { throw null; } }
        public string Disclaimer { get { throw null; } }
        public string Level { get { throw null; } }
        public int? Priority { get { throw null; } }
        public string Source { get { throw null; } }
        public int? SourceId { get { throw null; } }
    }
    public partial class SevereWeatherAlertDescription
    {
        internal SevereWeatherAlertDescription() { }
        public string Description { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class SevereWeatherAlertsResult
    {
        internal SevereWeatherAlertsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.SevereWeatherAlert> Results { get { throw null; } }
    }
    public partial class StormForecast
    {
        internal StormForecast() { }
        public Azure.Maps.Weather.Models.LatLongPair Coordinates { get { throw null; } }
        public string InitializedTimestamp { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue MaxWindGust { get { throw null; } }
        public string Status { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue SustainedWind { get { throw null; } }
        public string Timestamp { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherWindow WeatherWindow { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.StormWindRadiiSummary> WindRadiiSummary { get { throw null; } }
    }
    public partial class StormForecastResult
    {
        internal StormForecastResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.StormForecast> StormForecasts { get { throw null; } }
    }
    public partial class StormLocation
    {
        internal StormLocation() { }
        public Azure.Maps.Weather.Models.LatLongPair Coordinates { get { throw null; } }
        public bool? HasTropicalPotential { get { throw null; } }
        public bool? IsPostTropical { get { throw null; } }
        public bool? IsSubtropical { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue MaxWindGust { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue MinimumPressure { get { throw null; } }
        public Azure.Maps.Weather.Models.WindDetails Movement { get { throw null; } }
        public string Status { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue SustainedWind { get { throw null; } }
        public string Timestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.StormWindRadiiSummary> WindRadiiSummary { get { throw null; } }
    }
    public partial class StormLocationsResult
    {
        internal StormLocationsResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.StormLocation> StormLocations { get { throw null; } }
    }
    public partial class StormSearchResult
    {
        internal StormSearchResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.StormSearchResultItem> Storms { get { throw null; } }
    }
    public partial class StormSearchResultItem
    {
        internal StormSearchResultItem() { }
        public Azure.Maps.Weather.Models.BasinId? BasinId { get { throw null; } }
        public int? GovId { get { throw null; } }
        public bool? IsActive { get { throw null; } }
        public bool? IsRetired { get { throw null; } }
        public bool? IsSubtropical { get { throw null; } }
        public string Name { get { throw null; } }
        public string Year { get { throw null; } }
    }
    public partial class StormWindRadiiSummary
    {
        internal StormWindRadiiSummary() { }
        public Azure.Core.GeoJson.GeoObject RadiiGeometry { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.RadiusSector> RadiusSectorData { get { throw null; } }
        public string Timestamp { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue WindSpeed { get { throw null; } }
    }
    public partial class SunGlare
    {
        internal SunGlare() { }
        public int? CalculatedVehicleHeading { get { throw null; } }
        public int? GlareIndex { get { throw null; } }
    }
    public partial class TemperatureSummary
    {
        internal TemperatureSummary() { }
        public Azure.Maps.Weather.Models.PastHoursTemperature PastSixHours { get { throw null; } }
        public Azure.Maps.Weather.Models.PastHoursTemperature PastTwelveHours { get { throw null; } }
        public Azure.Maps.Weather.Models.PastHoursTemperature PastTwentyFourHours { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnitType : System.IEquatable<Azure.Maps.Weather.Models.UnitType>
    {
        private readonly int _dummyPrimitive;
        public UnitType(int value) { throw null; }
        public static Azure.Maps.Weather.Models.UnitType Celsius { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType Centimeter { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType Fahrenheit { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType Feet { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType Float { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType HectoPascals { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType Inches { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType InchesOfMercury { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType Integer { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType Kelvin { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType Kilometer { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType KilometersPerHour { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType KiloPascals { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType Knots { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType Meter { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType MetersPerSecond { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType MicrogramsPerCubicMeterOfAir { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType Miles { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType MilesPerHour { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType Millibars { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType Millimeter { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType MillimetersOfMercury { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType Percent { get { throw null; } }
        public static Azure.Maps.Weather.Models.UnitType PoundsPerSquareInch { get { throw null; } }
        public bool Equals(Azure.Maps.Weather.Models.UnitType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Weather.Models.UnitType left, Azure.Maps.Weather.Models.UnitType right) { throw null; }
        public static implicit operator Azure.Maps.Weather.Models.UnitType (int value) { throw null; }
        public static bool operator !=(Azure.Maps.Weather.Models.UnitType left, Azure.Maps.Weather.Models.UnitType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WaypointForecast
    {
        internal WaypointForecast() { }
        public int? CloudCover { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherHazards Hazards { get { throw null; } }
        public Azure.Maps.Weather.Models.IconCode? IconCode { get { throw null; } }
        public bool? IsDaytime { get { throw null; } }
        public int? LightningCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.WeatherNotification> Notifications { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherAlongRoutePrecipitation Precipitation { get { throw null; } }
        public string ShortDescription { get { throw null; } }
        public Azure.Maps.Weather.Models.SunGlare SunGlare { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Temperature { get { throw null; } }
        public Azure.Maps.Weather.Models.WindDetails Wind { get { throw null; } }
        public Azure.Maps.Weather.Models.WindDetails WindGust { get { throw null; } }
    }
    public partial class WeatherAlongRoutePrecipitation
    {
        internal WeatherAlongRoutePrecipitation() { }
        public double? Dbz { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class WeatherAlongRouteQuery
    {
        public WeatherAlongRouteQuery() { }
        public System.Collections.Generic.List<Azure.Maps.Weather.Models.WeatherAlongRouteWaypoint> Waypoints { get { throw null; } set { } }
    }
    public partial class WeatherAlongRouteResult
    {
        internal WeatherAlongRouteResult() { }
        public Azure.Maps.Weather.Models.WeatherAlongRouteSummary Summary { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.WaypointForecast> Waypoints { get { throw null; } }
    }
    public partial class WeatherAlongRouteSummary
    {
        internal WeatherAlongRouteSummary() { }
        public Azure.Maps.Weather.Models.WeatherHazards Hazards { get { throw null; } }
        public Azure.Maps.Weather.Models.IconCode? IconCode { get { throw null; } }
    }
    public partial class WeatherAlongRouteWaypoint
    {
        public WeatherAlongRouteWaypoint() { }
        public Azure.Core.GeoJson.GeoPosition Coordinates { get { throw null; } set { } }
        public double EtaInMinutes { get { throw null; } set { } }
        public double? Heading { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeatherDataUnit : System.IEquatable<Azure.Maps.Weather.Models.WeatherDataUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeatherDataUnit(string value) { throw null; }
        public static Azure.Maps.Weather.Models.WeatherDataUnit Imperial { get { throw null; } }
        public static Azure.Maps.Weather.Models.WeatherDataUnit Metric { get { throw null; } }
        public bool Equals(Azure.Maps.Weather.Models.WeatherDataUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Weather.Models.WeatherDataUnit left, Azure.Maps.Weather.Models.WeatherDataUnit right) { throw null; }
        public static implicit operator Azure.Maps.Weather.Models.WeatherDataUnit (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Weather.Models.WeatherDataUnit left, Azure.Maps.Weather.Models.WeatherDataUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WeatherHazards
    {
        internal WeatherHazards() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Weather.Models.HazardDetail> Details { get { throw null; } }
        public Azure.Maps.Weather.Models.HazardIndex? MaxHazardIndex { get { throw null; } }
    }
    public partial class WeatherNotification
    {
        internal WeatherNotification() { }
        public string HazardCode { get { throw null; } }
        public Azure.Maps.Weather.Models.HazardIndex? HazardIndex { get { throw null; } }
        public string ShortDescription { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class WeatherValue
    {
        internal WeatherValue() { }
        public string UnitLabel { get { throw null; } }
        public Azure.Maps.Weather.Models.UnitType? UnitType { get { throw null; } }
        public float? Value { get { throw null; } }
    }
    public partial class WeatherValueMaxMinAvg
    {
        internal WeatherValueMaxMinAvg() { }
        public Azure.Maps.Weather.Models.WeatherValue Average { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Maximum { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Minimum { get { throw null; } }
    }
    public partial class WeatherValueRange
    {
        internal WeatherValueRange() { }
        public Azure.Maps.Weather.Models.WeatherValue Maximum { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Minimum { get { throw null; } }
    }
    public partial class WeatherValueYear
    {
        internal WeatherValueYear() { }
        public string Unit { get { throw null; } }
        public int? UnitType { get { throw null; } }
        public float? Value { get { throw null; } }
        public int? Year { get { throw null; } }
    }
    public partial class WeatherValueYearMax
    {
        internal WeatherValueYearMax() { }
        public Azure.Maps.Weather.Models.WeatherValueYear Maximum { get { throw null; } }
    }
    public partial class WeatherValueYearMaxMinAvg
    {
        internal WeatherValueYearMaxMinAvg() { }
        public Azure.Maps.Weather.Models.WeatherValue Average { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValueYear Maximum { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValueYear Minimum { get { throw null; } }
    }
    public partial class WeatherWindow
    {
        internal WeatherWindow() { }
        public string BeginStatus { get { throw null; } }
        public System.DateTimeOffset? BeginTimestamp { get { throw null; } }
        public Azure.Maps.Weather.Models.LatLongPair BottomRight { get { throw null; } }
        public string EndStatus { get { throw null; } }
        public System.DateTimeOffset? EndTimestamp { get { throw null; } }
        public Azure.Core.GeoJson.GeoObject Geometry { get { throw null; } }
        public Azure.Maps.Weather.Models.LatLongPair TopLeft { get { throw null; } }
    }
    public partial class WindDetails
    {
        internal WindDetails() { }
        public Azure.Maps.Weather.Models.WindDirection Direction { get { throw null; } }
        public Azure.Maps.Weather.Models.WeatherValue Speed { get { throw null; } }
    }
    public partial class WindDirection
    {
        internal WindDirection() { }
        public int? Degrees { get { throw null; } }
        public string Description { get { throw null; } }
    }
}
namespace Azure.Maps.Weather.Models.Options
{
    public partial class GetAirQualityDailyForecastsOptions : Azure.Maps.Weather.Models.Options.WeatherBaseOptions
    {
        public GetAirQualityDailyForecastsOptions() { }
        public int? DurationInDays { get { throw null; } set { } }
    }
    public partial class GetAirQualityHourlyForecastsOptions : Azure.Maps.Weather.Models.Options.WeatherBaseOptions
    {
        public GetAirQualityHourlyForecastsOptions() { }
        public int? DurationInHours { get { throw null; } set { } }
        public bool? IncludePollutantDetails { get { throw null; } set { } }
    }
    public partial class GetCurrentAirQualityOptions : Azure.Maps.Weather.Models.Options.WeatherBaseOptions
    {
        public GetCurrentAirQualityOptions() { }
        public bool? IncludePollutantDetails { get { throw null; } set { } }
    }
    public partial class GetCurrentWeatherConditionsOptions : Azure.Maps.Weather.Models.Options.WeatherBaseOptions
    {
        public GetCurrentWeatherConditionsOptions() { }
        public int? DurationInHours { get { throw null; } set { } }
        public bool IncludeDetails { get { throw null; } set { } }
        public Azure.Maps.Weather.Models.WeatherDataUnit? Unit { get { throw null; } set { } }
    }
    public partial class GetDailyHistoricalActualsOptions
    {
        public GetDailyHistoricalActualsOptions() { }
        public Azure.Core.GeoJson.GeoPosition Coordinates { get { throw null; } set { } }
        public System.DateTimeOffset EndDate { get { throw null; } set { } }
        public System.DateTimeOffset StartDate { get { throw null; } set { } }
        public Azure.Maps.Weather.Models.WeatherDataUnit? Unit { get { throw null; } set { } }
    }
    public partial class GetDailyHistoricalNormalsOptions
    {
        public GetDailyHistoricalNormalsOptions() { }
        public Azure.Core.GeoJson.GeoPosition Coordinates { get { throw null; } set { } }
        public System.DateTimeOffset EndDate { get { throw null; } set { } }
        public System.DateTimeOffset StartDate { get { throw null; } set { } }
        public Azure.Maps.Weather.Models.WeatherDataUnit? Unit { get { throw null; } set { } }
    }
    public partial class GetDailyHistoricalRecordsOptions
    {
        public GetDailyHistoricalRecordsOptions() { }
        public Azure.Core.GeoJson.GeoPosition Coordinates { get { throw null; } set { } }
        public System.DateTimeOffset EndDate { get { throw null; } set { } }
        public System.DateTimeOffset StartDate { get { throw null; } set { } }
        public Azure.Maps.Weather.Models.WeatherDataUnit? Unit { get { throw null; } set { } }
    }
    public partial class GetDailyIndicesOptions : Azure.Maps.Weather.Models.Options.WeatherBaseOptions
    {
        public GetDailyIndicesOptions() { }
        public int? DurationInDays { get { throw null; } set { } }
        public int? IndexGroupId { get { throw null; } set { } }
        public int? IndexId { get { throw null; } set { } }
    }
    public partial class GetDailyWeatherForecastOptions : Azure.Maps.Weather.Models.Options.WeatherBaseOptions
    {
        public GetDailyWeatherForecastOptions() { }
        public int? DurationInDays { get { throw null; } set { } }
        public Azure.Maps.Weather.Models.WeatherDataUnit? Unit { get { throw null; } set { } }
    }
    public partial class GetHourlyWeatherForecastOptions : Azure.Maps.Weather.Models.Options.WeatherBaseOptions
    {
        public GetHourlyWeatherForecastOptions() { }
        public int? DurationInHours { get { throw null; } set { } }
        public Azure.Maps.Weather.Models.WeatherDataUnit? Unit { get { throw null; } set { } }
    }
    public partial class GetMinuteWeatherForecastOptions : Azure.Maps.Weather.Models.Options.WeatherBaseOptions
    {
        public GetMinuteWeatherForecastOptions() { }
        public int? IntervalInMinutes { get { throw null; } set { } }
    }
    public partial class GetQuarterDayWeatherForecastOptions : Azure.Maps.Weather.Models.Options.WeatherBaseOptions
    {
        public GetQuarterDayWeatherForecastOptions() { }
        public int? DurationInDays { get { throw null; } set { } }
        public Azure.Maps.Weather.Models.WeatherDataUnit? Unit { get { throw null; } set { } }
    }
    public partial class GetSevereWeatherAlertsOptions : Azure.Maps.Weather.Models.Options.WeatherBaseOptions
    {
        public GetSevereWeatherAlertsOptions() { }
        public bool IncludeDetails { get { throw null; } set { } }
    }
    public partial class GetTropicalStormForecastOptions
    {
        public GetTropicalStormForecastOptions() { }
        public Azure.Maps.Weather.Models.BasinId BasinId { get { throw null; } set { } }
        public int GovernmentStormId { get { throw null; } set { } }
        public bool? IncludeDetails { get { throw null; } set { } }
        public bool? IncludeGeometricDetails { get { throw null; } set { } }
        public bool? IncludeWindowGeometry { get { throw null; } set { } }
        public Azure.Maps.Weather.Models.WeatherDataUnit? Unit { get { throw null; } set { } }
        public int Year { get { throw null; } set { } }
    }
    public partial class GetTropicalStormLocationsOptions
    {
        public GetTropicalStormLocationsOptions() { }
        public Azure.Maps.Weather.Models.BasinId BasinId { get { throw null; } set { } }
        public int GovernmentStormId { get { throw null; } set { } }
        public bool? IncludeCurrentStorm { get { throw null; } set { } }
        public bool? IncludeDetails { get { throw null; } set { } }
        public bool? IncludeGeometricDetails { get { throw null; } set { } }
        public Azure.Maps.Weather.Models.WeatherDataUnit? Unit { get { throw null; } set { } }
        public int Year { get { throw null; } set { } }
    }
    public partial class GetTropicalStormSearchOptions
    {
        public GetTropicalStormSearchOptions() { }
        public Azure.Maps.Weather.Models.BasinId BasinId { get { throw null; } set { } }
        public int GovernmentStormId { get { throw null; } set { } }
        public int Year { get { throw null; } set { } }
    }
    public partial class WeatherBaseOptions
    {
        public WeatherBaseOptions() { }
        public Azure.Core.GeoJson.GeoPosition Coordinates { get { throw null; } set { } }
        public Azure.Maps.Weather.WeatherLanguage Language { get { throw null; } set { } }
    }
}
