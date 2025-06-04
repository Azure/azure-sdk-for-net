namespace Azure.Maps.Search
{
    public partial class AzureMapsSearchContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureMapsSearchContext() { }
        public static Azure.Maps.Search.AzureMapsSearchContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class MapsSearchClient
    {
        protected MapsSearchClient() { }
        public MapsSearchClient(Azure.AzureKeyCredential credential) { }
        public MapsSearchClient(Azure.AzureKeyCredential credential, Azure.Maps.Search.MapsSearchClientOptions options) { }
        public MapsSearchClient(Azure.AzureSasCredential credential) { }
        public MapsSearchClient(Azure.AzureSasCredential credential, Azure.Maps.Search.MapsSearchClientOptions options) { }
        public MapsSearchClient(Azure.Core.TokenCredential credential, string clientId) { }
        public MapsSearchClient(Azure.Core.TokenCredential credential, string clientId, Azure.Maps.Search.MapsSearchClientOptions options) { }
        public virtual Azure.Response<Azure.Maps.Search.Models.GeocodingResponse> GetGeocoding(string query = null, Azure.Maps.Search.Models.GeocodingQuery options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.GeocodingResponse>> GetGeocodingAsync(string query = null, Azure.Maps.Search.Models.GeocodingQuery options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Search.Models.GeocodingBatchResponse> GetGeocodingBatch(System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.GeocodingQuery> queries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.GeocodingBatchResponse>> GetGeocodingBatchAsync(System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.GeocodingQuery> queries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Search.Models.Boundary> GetPolygon(Azure.Maps.Search.Models.GetPolygonOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.Boundary>> GetPolygonAsync(Azure.Maps.Search.Models.GetPolygonOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Search.Models.GeocodingResponse> GetReverseGeocoding(Azure.Core.GeoJson.GeoPosition coordinates, Azure.Maps.Search.Models.ReverseGeocodingQuery options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.GeocodingResponse>> GetReverseGeocodingAsync(Azure.Core.GeoJson.GeoPosition coordinates, Azure.Maps.Search.Models.ReverseGeocodingQuery options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Search.Models.GeocodingBatchResponse> GetReverseGeocodingBatch(System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.ReverseGeocodingQuery> queries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.GeocodingBatchResponse>> GetReverseGeocodingBatchAsync(System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.ReverseGeocodingQuery> queries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MapsSearchClientOptions : Azure.Core.ClientOptions
    {
        public MapsSearchClientOptions(Azure.Maps.Search.MapsSearchClientOptions.ServiceVersion version = Azure.Maps.Search.MapsSearchClientOptions.ServiceVersion.V2_1, System.Uri endpoint = null, Azure.Maps.Search.SearchLanguage language = null) { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.Maps.Search.SearchLanguage SearchLanguage { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V1_0 = 1,
            V2_0 = 2,
            V2_1 = 3,
        }
    }
    public partial class SearchLanguage
    {
        public SearchLanguage(string value) { }
        public static Azure.Maps.Search.SearchLanguage Afrikaans { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Arabic { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Basque { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Bulgarian { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Catalan { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Croatian { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Czech { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Danish { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage DutchNetherlands { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage EnglishAustralia { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage EnglishGreatBritain { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage EnglishNewZealand { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage EnglishUsa { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Estonian { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Finnish { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage FrenchCanada { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage FrenchFrance { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Galician { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage German { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Greek { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Hebrew { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Hungarian { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Indonesian { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Italian { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Kazakh { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Latvian { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Lithuanian { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Malay { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage NeutralGroundTruthLatin { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage NeutralGroundTruthLocal { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Norwegian { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Polish { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage PortugueseBrazil { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage PortuguesePortugal { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Romanian { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Russian { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage SerbianCyrillic { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage SimplifiedChinese { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Slovak { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Slovenian { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage SpanishLatinAmerica { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage SpanishSpain { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Swedish { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Thai { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage TraditionalChinese { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Turkish { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Ukrainian { get { throw null; } }
        public static Azure.Maps.Search.SearchLanguage Vietnamese { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static implicit operator Azure.Maps.Search.SearchLanguage (string value) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Azure.Maps.Search.Models
{
    public partial class Address
    {
        internal Address() { }
        public string AddressLine { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.AddressAdminDistrictsItem> AdminDistricts { get { throw null; } }
        public Azure.Maps.Search.Models.AddressCountryRegion CountryRegion { get { throw null; } }
        public string FormattedAddress { get { throw null; } }
        public Azure.Maps.Search.Models.Intersection Intersection { get { throw null; } }
        public string Locality { get { throw null; } }
        public string Neighborhood { get { throw null; } }
        public string PostalCode { get { throw null; } }
        public string StreetName { get { throw null; } }
        public string StreetNumber { get { throw null; } }
    }
    public partial class AddressAdminDistrictsItem
    {
        internal AddressAdminDistrictsItem() { }
        public string Name { get { throw null; } }
        public string ShortName { get { throw null; } }
    }
    public partial class AddressCountryRegion
    {
        internal AddressCountryRegion() { }
        public string Iso { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class Boundary
    {
        internal Boundary() { }
        public Azure.Core.GeoJson.GeoCollection Geometry { get { throw null; } }
        public Azure.Maps.Search.Models.BoundaryProperties Properties { get { throw null; } }
    }
    public partial class BoundaryProperties
    {
        internal BoundaryProperties() { }
        public string Copyright { get { throw null; } }
        public string CopyrightUrl { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.GeometryCopyright> GeometriesCopyright { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BoundaryResultTypeEnum : System.IEquatable<Azure.Maps.Search.Models.BoundaryResultTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BoundaryResultTypeEnum(string value) { throw null; }
        public static Azure.Maps.Search.Models.BoundaryResultTypeEnum AdminDistrict { get { throw null; } }
        public static Azure.Maps.Search.Models.BoundaryResultTypeEnum AdminDistrict2 { get { throw null; } }
        public static Azure.Maps.Search.Models.BoundaryResultTypeEnum CountryRegion { get { throw null; } }
        public static Azure.Maps.Search.Models.BoundaryResultTypeEnum Locality { get { throw null; } }
        public static Azure.Maps.Search.Models.BoundaryResultTypeEnum Neighborhood { get { throw null; } }
        public static Azure.Maps.Search.Models.BoundaryResultTypeEnum PostalCode { get { throw null; } }
        public static Azure.Maps.Search.Models.BoundaryResultTypeEnum PostalCode2 { get { throw null; } }
        public static Azure.Maps.Search.Models.BoundaryResultTypeEnum PostalCode3 { get { throw null; } }
        public static Azure.Maps.Search.Models.BoundaryResultTypeEnum PostalCode4 { get { throw null; } }
        public bool Equals(Azure.Maps.Search.Models.BoundaryResultTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.Models.BoundaryResultTypeEnum left, Azure.Maps.Search.Models.BoundaryResultTypeEnum right) { throw null; }
        public static implicit operator Azure.Maps.Search.Models.BoundaryResultTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.Models.BoundaryResultTypeEnum left, Azure.Maps.Search.Models.BoundaryResultTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CalculationMethodEnum : System.IEquatable<Azure.Maps.Search.Models.CalculationMethodEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CalculationMethodEnum(string value) { throw null; }
        public static Azure.Maps.Search.Models.CalculationMethodEnum Interpolation { get { throw null; } }
        public static Azure.Maps.Search.Models.CalculationMethodEnum InterpolationOffset { get { throw null; } }
        public static Azure.Maps.Search.Models.CalculationMethodEnum Parcel { get { throw null; } }
        public static Azure.Maps.Search.Models.CalculationMethodEnum Rooftop { get { throw null; } }
        public bool Equals(Azure.Maps.Search.Models.CalculationMethodEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.Models.CalculationMethodEnum left, Azure.Maps.Search.Models.CalculationMethodEnum right) { throw null; }
        public static implicit operator Azure.Maps.Search.Models.CalculationMethodEnum (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.Models.CalculationMethodEnum left, Azure.Maps.Search.Models.CalculationMethodEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidenceEnum : System.IEquatable<Azure.Maps.Search.Models.ConfidenceEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidenceEnum(string value) { throw null; }
        public static Azure.Maps.Search.Models.ConfidenceEnum High { get { throw null; } }
        public static Azure.Maps.Search.Models.ConfidenceEnum Low { get { throw null; } }
        public static Azure.Maps.Search.Models.ConfidenceEnum Medium { get { throw null; } }
        public bool Equals(Azure.Maps.Search.Models.ConfidenceEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.Models.ConfidenceEnum left, Azure.Maps.Search.Models.ConfidenceEnum right) { throw null; }
        public static implicit operator Azure.Maps.Search.Models.ConfidenceEnum (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.Models.ConfidenceEnum left, Azure.Maps.Search.Models.ConfidenceEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ErrorAdditionalInfo
    {
        internal ErrorAdditionalInfo() { }
        public object Info { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class ErrorDetail
    {
        internal ErrorDetail() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.ErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.ErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeatureCollectionEnum : System.IEquatable<Azure.Maps.Search.Models.FeatureCollectionEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeatureCollectionEnum(string value) { throw null; }
        public static Azure.Maps.Search.Models.FeatureCollectionEnum FeatureCollection { get { throw null; } }
        public bool Equals(Azure.Maps.Search.Models.FeatureCollectionEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.Models.FeatureCollectionEnum left, Azure.Maps.Search.Models.FeatureCollectionEnum right) { throw null; }
        public static implicit operator Azure.Maps.Search.Models.FeatureCollectionEnum (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.Models.FeatureCollectionEnum left, Azure.Maps.Search.Models.FeatureCollectionEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FeaturesItem
    {
        internal FeaturesItem() { }
        public Azure.Core.GeoJson.GeoBoundingBox BoundingBox { get { throw null; } }
        public Azure.Core.GeoJson.GeoPoint Geometry { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Maps.Search.Models.FeaturesItemProperties Properties { get { throw null; } }
        public Azure.Maps.Search.Models.FeatureTypeEnum? Type { get { throw null; } }
    }
    public partial class FeaturesItemProperties
    {
        internal FeaturesItemProperties() { }
        public Azure.Maps.Search.Models.Address Address { get { throw null; } }
        public Azure.Maps.Search.Models.ConfidenceEnum? Confidence { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.GeocodePointsItem> GeocodePoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.MatchCodesEnum> MatchCodes { get { throw null; } }
        public string Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeatureTypeEnum : System.IEquatable<Azure.Maps.Search.Models.FeatureTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeatureTypeEnum(string value) { throw null; }
        public static Azure.Maps.Search.Models.FeatureTypeEnum Feature { get { throw null; } }
        public bool Equals(Azure.Maps.Search.Models.FeatureTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.Models.FeatureTypeEnum left, Azure.Maps.Search.Models.FeatureTypeEnum right) { throw null; }
        public static implicit operator Azure.Maps.Search.Models.FeatureTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.Models.FeatureTypeEnum left, Azure.Maps.Search.Models.FeatureTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GeocodePointsItem
    {
        internal GeocodePointsItem() { }
        public Azure.Maps.Search.Models.CalculationMethodEnum? CalculationMethod { get { throw null; } }
        public Azure.Core.GeoJson.GeoPoint Geometry { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.UsageTypeEnum> UsageTypes { get { throw null; } }
    }
    public partial class GeocodingBatchRequestItem
    {
        public GeocodingBatchRequestItem() { }
        public string AddressLine { get { throw null; } set { } }
        public string AdminDistrict { get { throw null; } set { } }
        public string AdminDistrict2 { get { throw null; } set { } }
        public string AdminDistrict3 { get { throw null; } set { } }
        public Azure.Core.GeoJson.GeoBoundingBox BoundingBox { get { throw null; } set { } }
        public Azure.Core.GeoJson.GeoPosition Coordinates { get { throw null; } set { } }
        public string CountryRegion { get { throw null; } set { } }
        public string Locality { get { throw null; } set { } }
        public string OptionalId { get { throw null; } set { } }
        public string PostalCode { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        public string View { get { throw null; } set { } }
    }
    public partial class GeocodingBatchResponse
    {
        internal GeocodingBatchResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.GeocodingBatchResponseItem> BatchItems { get { throw null; } }
        public string NextLink { get { throw null; } }
        public Azure.Maps.Search.Models.GeocodingBatchResponseSummary Summary { get { throw null; } }
    }
    public partial class GeocodingBatchResponseItem
    {
        internal GeocodingBatchResponseItem() { }
        public Azure.Maps.Search.Models.ErrorDetail Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.FeaturesItem> Features { get { throw null; } }
        public string NextLink { get { throw null; } }
        public string OptionalId { get { throw null; } }
        public Azure.Maps.Search.Models.FeatureCollectionEnum? Type { get { throw null; } }
    }
    public partial class GeocodingBatchResponseSummary
    {
        internal GeocodingBatchResponseSummary() { }
        public int? SuccessfulRequests { get { throw null; } }
        public int? TotalRequests { get { throw null; } }
    }
    public partial class GeocodingQuery
    {
        public GeocodingQuery() { }
        public string AddressLine { get { throw null; } set { } }
        public string AdminDistrict { get { throw null; } set { } }
        public string AdminDistrict2 { get { throw null; } set { } }
        public string AdminDistrict3 { get { throw null; } set { } }
        public Azure.Core.GeoJson.GeoBoundingBox BoundingBox { get { throw null; } set { } }
        public Azure.Core.GeoJson.GeoPosition? Coordinates { get { throw null; } set { } }
        public string CountryRegion { get { throw null; } set { } }
        public string Locality { get { throw null; } set { } }
        public Azure.Maps.LocalizedMapView? LocalizedMapView { get { throw null; } set { } }
        public string OptionalId { get { throw null; } set { } }
        public string PostalCode { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class GeocodingResponse
    {
        internal GeocodingResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.FeaturesItem> Features { get { throw null; } }
        public string NextLink { get { throw null; } }
        public Azure.Maps.Search.Models.FeatureCollectionEnum? Type { get { throw null; } }
    }
    public partial class GeometryCopyright
    {
        internal GeometryCopyright() { }
        public string Copyright { get { throw null; } }
        public string SourceName { get { throw null; } }
    }
    public partial class GetPolygonOptions
    {
        public GetPolygonOptions() { }
        public Azure.Core.GeoJson.GeoPosition Coordinates { get { throw null; } set { } }
        public Azure.Maps.LocalizedMapView? LocalizedMapView { get { throw null; } set { } }
        public Azure.Maps.Search.Models.ResolutionEnum? Resolution { get { throw null; } set { } }
        public Azure.Maps.Search.Models.BoundaryResultTypeEnum? ResultType { get { throw null; } set { } }
    }
    public partial class Intersection
    {
        internal Intersection() { }
        public string BaseStreet { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string IntersectionType { get { throw null; } }
        public string SecondaryStreet1 { get { throw null; } }
        public string SecondaryStreet2 { get { throw null; } }
    }
    public static partial class MapsSearchModelFactory
    {
        public static Azure.Maps.Search.Models.Address Address(string addressLine = null, string locality = null, string neighborhood = null, System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.AddressAdminDistrictsItem> adminDistricts = null, string postalCode = null, Azure.Maps.Search.Models.AddressCountryRegion countryRegion = null, string formattedAddress = null, string streetName = null, string streetNumber = null, Azure.Maps.Search.Models.Intersection intersection = null) { throw null; }
        public static Azure.Maps.Search.Models.AddressAdminDistrictsItem AddressAdminDistrictsItem(string name = null, string shortName = null) { throw null; }
        public static Azure.Maps.Search.Models.AddressCountryRegion AddressCountryRegion(string iso = null, string name = null) { throw null; }
        public static Azure.Maps.Search.Models.BoundaryProperties BoundaryProperties(string name = null, string copyright = null, string copyrightUrl = null, System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.GeometryCopyright> geometriesCopyright = null) { throw null; }
        public static Azure.Maps.Search.Models.ErrorAdditionalInfo ErrorAdditionalInfo(string type = null, object info = null) { throw null; }
        public static Azure.Maps.Search.Models.ErrorDetail ErrorDetail(string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.ErrorDetail> details = null, System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.ErrorAdditionalInfo> additionalInfo = null) { throw null; }
        public static Azure.Maps.Search.Models.FeaturesItemProperties FeaturesItemProperties(string type = null, Azure.Maps.Search.Models.ConfidenceEnum? confidence = default(Azure.Maps.Search.Models.ConfidenceEnum?), System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.MatchCodesEnum> matchCodes = null, Azure.Maps.Search.Models.Address address = null, System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.GeocodePointsItem> geocodePoints = null) { throw null; }
        public static Azure.Maps.Search.Models.GeocodingBatchResponse GeocodingBatchResponse(Azure.Maps.Search.Models.GeocodingBatchResponseSummary summary = null, System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.GeocodingBatchResponseItem> batchItems = null, string nextLink = null) { throw null; }
        public static Azure.Maps.Search.Models.GeocodingBatchResponseItem GeocodingBatchResponseItem(string optionalId = null, Azure.Maps.Search.Models.FeatureCollectionEnum? type = default(Azure.Maps.Search.Models.FeatureCollectionEnum?), System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.FeaturesItem> features = null, string nextLink = null, Azure.Maps.Search.Models.ErrorDetail error = null) { throw null; }
        public static Azure.Maps.Search.Models.GeocodingBatchResponseSummary GeocodingBatchResponseSummary(int? successfulRequests = default(int?), int? totalRequests = default(int?)) { throw null; }
        public static Azure.Maps.Search.Models.GeocodingResponse GeocodingResponse(Azure.Maps.Search.Models.FeatureCollectionEnum? type = default(Azure.Maps.Search.Models.FeatureCollectionEnum?), System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.FeaturesItem> features = null, string nextLink = null) { throw null; }
        public static Azure.Maps.Search.Models.GeometryCopyright GeometryCopyright(string sourceName = null, string copyright = null) { throw null; }
        public static Azure.Maps.Search.Models.Intersection Intersection(string baseStreet = null, string secondaryStreet1 = null, string secondaryStreet2 = null, string intersectionType = null, string displayName = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MatchCodesEnum : System.IEquatable<Azure.Maps.Search.Models.MatchCodesEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MatchCodesEnum(string value) { throw null; }
        public static Azure.Maps.Search.Models.MatchCodesEnum Ambiguous { get { throw null; } }
        public static Azure.Maps.Search.Models.MatchCodesEnum Good { get { throw null; } }
        public static Azure.Maps.Search.Models.MatchCodesEnum UpHierarchy { get { throw null; } }
        public bool Equals(Azure.Maps.Search.Models.MatchCodesEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.Models.MatchCodesEnum left, Azure.Maps.Search.Models.MatchCodesEnum right) { throw null; }
        public static implicit operator Azure.Maps.Search.Models.MatchCodesEnum (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.Models.MatchCodesEnum left, Azure.Maps.Search.Models.MatchCodesEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResolutionEnum : System.IEquatable<Azure.Maps.Search.Models.ResolutionEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResolutionEnum(string value) { throw null; }
        public static Azure.Maps.Search.Models.ResolutionEnum Huge { get { throw null; } }
        public static Azure.Maps.Search.Models.ResolutionEnum Large { get { throw null; } }
        public static Azure.Maps.Search.Models.ResolutionEnum Medium { get { throw null; } }
        public static Azure.Maps.Search.Models.ResolutionEnum Small { get { throw null; } }
        public bool Equals(Azure.Maps.Search.Models.ResolutionEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.Models.ResolutionEnum left, Azure.Maps.Search.Models.ResolutionEnum right) { throw null; }
        public static implicit operator Azure.Maps.Search.Models.ResolutionEnum (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.Models.ResolutionEnum left, Azure.Maps.Search.Models.ResolutionEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResultTypeEnum : System.IEquatable<Azure.Maps.Search.Models.ResultTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResultTypeEnum(string value) { throw null; }
        public static Azure.Maps.Search.Models.ResultTypeEnum Address { get { throw null; } }
        public static Azure.Maps.Search.Models.ResultTypeEnum AdminDivision1 { get { throw null; } }
        public static Azure.Maps.Search.Models.ResultTypeEnum AdminDivision2 { get { throw null; } }
        public static Azure.Maps.Search.Models.ResultTypeEnum CountryRegion { get { throw null; } }
        public static Azure.Maps.Search.Models.ResultTypeEnum Neighborhood { get { throw null; } }
        public static Azure.Maps.Search.Models.ResultTypeEnum PopulatedPlace { get { throw null; } }
        public static Azure.Maps.Search.Models.ResultTypeEnum Postcode1 { get { throw null; } }
        public bool Equals(Azure.Maps.Search.Models.ResultTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.Models.ResultTypeEnum left, Azure.Maps.Search.Models.ResultTypeEnum right) { throw null; }
        public static implicit operator Azure.Maps.Search.Models.ResultTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.Models.ResultTypeEnum left, Azure.Maps.Search.Models.ResultTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReverseGeocodingBatchRequestItem
    {
        public ReverseGeocodingBatchRequestItem() { }
        public Azure.Core.GeoJson.GeoPosition Coordinates { get { throw null; } set { } }
        public Azure.Maps.LocalizedMapView LocalizedMapView { get { throw null; } set { } }
        public string OptionalId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Maps.Search.Models.ResultTypeEnum> ResultTypes { get { throw null; } set { } }
    }
    public partial class ReverseGeocodingQuery
    {
        public ReverseGeocodingQuery() { }
        public Azure.Core.GeoJson.GeoPosition Coordinates { get { throw null; } set { } }
        public Azure.Maps.LocalizedMapView? LocalizedMapView { get { throw null; } set { } }
        public string OptionalId { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.ReverseGeocodingResultTypeEnum> ResultTypes { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReverseGeocodingResultTypeEnum : System.IEquatable<Azure.Maps.Search.Models.ReverseGeocodingResultTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReverseGeocodingResultTypeEnum(string value) { throw null; }
        public static Azure.Maps.Search.Models.ReverseGeocodingResultTypeEnum Address { get { throw null; } }
        public static Azure.Maps.Search.Models.ReverseGeocodingResultTypeEnum AdminDivision1 { get { throw null; } }
        public static Azure.Maps.Search.Models.ReverseGeocodingResultTypeEnum AdminDivision2 { get { throw null; } }
        public static Azure.Maps.Search.Models.ReverseGeocodingResultTypeEnum CountryRegion { get { throw null; } }
        public static Azure.Maps.Search.Models.ReverseGeocodingResultTypeEnum Neighborhood { get { throw null; } }
        public static Azure.Maps.Search.Models.ReverseGeocodingResultTypeEnum PopulatedPlace { get { throw null; } }
        public static Azure.Maps.Search.Models.ReverseGeocodingResultTypeEnum Postcode1 { get { throw null; } }
        public bool Equals(Azure.Maps.Search.Models.ReverseGeocodingResultTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.Models.ReverseGeocodingResultTypeEnum left, Azure.Maps.Search.Models.ReverseGeocodingResultTypeEnum right) { throw null; }
        public static implicit operator Azure.Maps.Search.Models.ReverseGeocodingResultTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.Models.ReverseGeocodingResultTypeEnum left, Azure.Maps.Search.Models.ReverseGeocodingResultTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsageTypeEnum : System.IEquatable<Azure.Maps.Search.Models.UsageTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsageTypeEnum(string value) { throw null; }
        public static Azure.Maps.Search.Models.UsageTypeEnum Display { get { throw null; } }
        public static Azure.Maps.Search.Models.UsageTypeEnum Route { get { throw null; } }
        public bool Equals(Azure.Maps.Search.Models.UsageTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.Models.UsageTypeEnum left, Azure.Maps.Search.Models.UsageTypeEnum right) { throw null; }
        public static implicit operator Azure.Maps.Search.Models.UsageTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.Models.UsageTypeEnum left, Azure.Maps.Search.Models.UsageTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
}
