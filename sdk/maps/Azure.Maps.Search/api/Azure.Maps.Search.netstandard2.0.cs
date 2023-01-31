namespace Azure.Maps.Search
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElectricVehicleConnector : System.IEquatable<Azure.Maps.Search.ElectricVehicleConnector>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElectricVehicleConnector(string value) { throw null; }
        public static Azure.Maps.Search.ElectricVehicleConnector Chademo { get { throw null; } }
        public static Azure.Maps.Search.ElectricVehicleConnector Iec60309AC1PhaseBlue { get { throw null; } }
        public static Azure.Maps.Search.ElectricVehicleConnector Iec60309DCWhite { get { throw null; } }
        public static Azure.Maps.Search.ElectricVehicleConnector Iec62196Type1 { get { throw null; } }
        public static Azure.Maps.Search.ElectricVehicleConnector Iec62196Type1CCS { get { throw null; } }
        public static Azure.Maps.Search.ElectricVehicleConnector Iec62196Type2CableAttached { get { throw null; } }
        public static Azure.Maps.Search.ElectricVehicleConnector Iec62196Type2CCS { get { throw null; } }
        public static Azure.Maps.Search.ElectricVehicleConnector Iec62196Type2Outlet { get { throw null; } }
        public static Azure.Maps.Search.ElectricVehicleConnector Iec62196Type3 { get { throw null; } }
        public static Azure.Maps.Search.ElectricVehicleConnector StandardHouseholdCountrySpecific { get { throw null; } }
        public static Azure.Maps.Search.ElectricVehicleConnector Tesla { get { throw null; } }
        public bool Equals(Azure.Maps.Search.ElectricVehicleConnector other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.ElectricVehicleConnector left, Azure.Maps.Search.ElectricVehicleConnector right) { throw null; }
        public static implicit operator Azure.Maps.Search.ElectricVehicleConnector (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.ElectricVehicleConnector left, Azure.Maps.Search.ElectricVehicleConnector right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FuzzySearchBatchOperation : Azure.Operation<Azure.Maps.Search.Models.SearchAddressBatchResult>
    {
        protected FuzzySearchBatchOperation() { }
        public FuzzySearchBatchOperation(Azure.Maps.Search.MapsSearchClient client, string id) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Maps.Search.Models.SearchAddressBatchResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Maps.Search.Models.SearchAddressBatchResult> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Maps.Search.Models.SearchAddressBatchResult> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Maps.Search.Models.SearchAddressBatchResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Maps.Search.Models.SearchAddressBatchResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FuzzySearchOptions : Azure.Maps.Search.SearchPointOfInterestOptions
    {
        public FuzzySearchOptions() { }
        public Azure.Core.GeoJson.GeoBoundingBox BoundingBox { get { throw null; } set { } }
        public Azure.Maps.Search.GeographicEntity? EntityType { get { throw null; } set { } }
        public new System.Collections.Generic.IEnumerable<Azure.Maps.Search.SearchIndex> ExtendedPostalCodesFor { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.Maps.Search.SearchIndex> IndexFilter { get { throw null; } set { } }
        public bool? IsTypeAhead { get { throw null; } set { } }
        public int? MaxFuzzyLevel { get { throw null; } set { } }
        public int? MinFuzzyLevel { get { throw null; } set { } }
        public Azure.Maps.Search.OperatingHoursRange? OperatingHours { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeographicEntity : System.IEquatable<Azure.Maps.Search.GeographicEntity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GeographicEntity(string value) { throw null; }
        public static Azure.Maps.Search.GeographicEntity Country { get { throw null; } }
        public static Azure.Maps.Search.GeographicEntity CountrySecondarySubdivision { get { throw null; } }
        public static Azure.Maps.Search.GeographicEntity CountrySubdivision { get { throw null; } }
        public static Azure.Maps.Search.GeographicEntity CountryTertiarySubdivision { get { throw null; } }
        public static Azure.Maps.Search.GeographicEntity Municipality { get { throw null; } }
        public static Azure.Maps.Search.GeographicEntity MunicipalitySubdivision { get { throw null; } }
        public static Azure.Maps.Search.GeographicEntity Neighborhood { get { throw null; } }
        public static Azure.Maps.Search.GeographicEntity PostalCodeArea { get { throw null; } }
        public bool Equals(Azure.Maps.Search.GeographicEntity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.GeographicEntity left, Azure.Maps.Search.GeographicEntity right) { throw null; }
        public static implicit operator Azure.Maps.Search.GeographicEntity (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.GeographicEntity left, Azure.Maps.Search.GeographicEntity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MapsSearchClient
    {
        protected MapsSearchClient() { }
        public MapsSearchClient(Azure.AzureKeyCredential credential) { }
        public MapsSearchClient(Azure.AzureKeyCredential credential, Azure.Maps.Search.MapsSearchClientOptions options) { }
        public MapsSearchClient(Azure.Core.TokenCredential credential, string clientId) { }
        public MapsSearchClient(Azure.Core.TokenCredential credential, string clientId, Azure.Maps.Search.MapsSearchClientOptions options) { }
        public virtual Azure.Maps.Search.FuzzySearchBatchOperation FuzzyBatchSearch(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.FuzzySearchQuery> queries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Maps.Search.FuzzySearchBatchOperation> FuzzyBatchSearchAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.FuzzySearchQuery> queries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Search.Models.SearchAddressResult> FuzzySearch(string query, Azure.Maps.Search.FuzzySearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.SearchAddressResult>> FuzzySearchAsync(string query, Azure.Maps.Search.FuzzySearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Search.Models.SearchAddressBatchResult> GetImmediateFuzzyBatchSearch(System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.FuzzySearchQuery> queries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.SearchAddressBatchResult>> GetImmediateFuzzyBatchSearchAsync(System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.FuzzySearchQuery> queries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Search.Models.ReverseSearchAddressBatchResult> GetImmediateReverseSearchAddressBatch(System.Collections.Generic.IEnumerable<Azure.Maps.Search.ReverseSearchAddressQuery> queries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.ReverseSearchAddressBatchResult>> GetImmediateReverseSearchAddressBatchAsync(System.Collections.Generic.IEnumerable<Azure.Maps.Search.ReverseSearchAddressQuery> queries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Search.Models.SearchAddressBatchResult> GetImmediateSearchAddressBatch(System.Collections.Generic.IEnumerable<Azure.Maps.Search.SearchAddressQuery> queries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.SearchAddressBatchResult>> GetImmediateSearchAddressBatchAsync(System.Collections.Generic.IEnumerable<Azure.Maps.Search.SearchAddressQuery> queries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Search.Models.PointOfInterestCategoryTreeResult> GetPointOfInterestCategoryTree(Azure.Maps.Search.SearchLanguage? language = default(Azure.Maps.Search.SearchLanguage?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.PointOfInterestCategoryTreeResult>> GetPointOfInterestCategoryTreeAsync(Azure.Maps.Search.SearchLanguage? language = default(Azure.Maps.Search.SearchLanguage?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Search.Models.PolygonResult> GetPolygons(System.Collections.Generic.IEnumerable<string> geometryIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.PolygonResult>> GetPolygonsAsync(System.Collections.Generic.IEnumerable<string> geometryIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Search.Models.ReverseSearchAddressResult> ReverseSearchAddress(Azure.Maps.Search.ReverseSearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.ReverseSearchAddressResult>> ReverseSearchAddressAsync(Azure.Maps.Search.ReverseSearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Maps.Search.ReverseSearchAddressBatchOperation ReverseSearchAddressBatch(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.Maps.Search.ReverseSearchAddressQuery> queries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Maps.Search.ReverseSearchAddressBatchOperation> ReverseSearchAddressBatchAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.Maps.Search.ReverseSearchAddressQuery> queries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Search.Models.ReverseSearchCrossStreetAddressResult> ReverseSearchCrossStreetAddress(Azure.Maps.Search.ReverseSearchCrossStreetOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.ReverseSearchCrossStreetAddressResult>> ReverseSearchCrossStreetAddressAsync(Azure.Maps.Search.ReverseSearchCrossStreetOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Search.Models.SearchAddressResult> SearchAddress(string query, Azure.Maps.Search.SearchAddressOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.SearchAddressResult>> SearchAddressAsync(string query, Azure.Maps.Search.SearchAddressOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Maps.Search.SearchAddressBatchOperation SearchAddressBatch(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.Maps.Search.SearchAddressQuery> queries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Maps.Search.SearchAddressBatchOperation> SearchAddressBatchAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.Maps.Search.SearchAddressQuery> queries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Search.Models.SearchAddressResult> SearchInsideGeometry(string query, Azure.Core.GeoJson.GeoCollection geometryCollection, Azure.Maps.Search.SearchInsideGeometryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Search.Models.SearchAddressResult> SearchInsideGeometry(string query, Azure.Core.GeoJson.GeoObject geometry, Azure.Maps.Search.SearchInsideGeometryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.SearchAddressResult>> SearchInsideGeometryAsync(string query, Azure.Core.GeoJson.GeoCollection geometryCollection, Azure.Maps.Search.SearchInsideGeometryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.SearchAddressResult>> SearchInsideGeometryAsync(string query, Azure.Core.GeoJson.GeoObject geometry, Azure.Maps.Search.SearchInsideGeometryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Search.Models.SearchAddressResult> SearchNearbyPointOfInterest(Azure.Maps.Search.SearchNearbyPointOfInterestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.SearchAddressResult>> SearchNearbyPointOfInterestAsync(Azure.Maps.Search.SearchNearbyPointOfInterestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Search.Models.SearchAddressResult> SearchPointOfInterest(string query, bool? IsTypeAhead = default(bool?), Azure.Maps.Search.OperatingHoursRange? OperatingHours = default(Azure.Maps.Search.OperatingHoursRange?), Azure.Core.GeoJson.GeoBoundingBox BoundingBox = null, Azure.Maps.Search.SearchPointOfInterestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Search.Models.SearchAddressResult> SearchPointOfInterestAlongRoute(string query, int maxDetourTime, Azure.Core.GeoJson.GeoLineString route, Azure.Maps.Search.SearchAlongRouteOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.SearchAddressResult>> SearchPointOfInterestAlongRouteAsync(string query, int maxDetourTime, Azure.Core.GeoJson.GeoLineString route, Azure.Maps.Search.SearchAlongRouteOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.SearchAddressResult>> SearchPointOfInterestAsync(string query, bool? IsTypeAhead = default(bool?), Azure.Maps.Search.OperatingHoursRange? OperatingHours = default(Azure.Maps.Search.OperatingHoursRange?), Azure.Core.GeoJson.GeoBoundingBox BoundingBox = null, Azure.Maps.Search.SearchPointOfInterestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Search.Models.SearchAddressResult> SearchPointOfInterestCategory(Azure.Maps.Search.SearchPointOfInterestCategoryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.SearchAddressResult>> SearchPointOfInterestCategoryAsync(Azure.Maps.Search.SearchPointOfInterestCategoryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Search.Models.SearchAddressResult> SearchStructuredAddress(Azure.Maps.Search.StructuredAddress address, Azure.Maps.Search.Models.SearchStructuredAddressOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Search.Models.SearchAddressResult>> SearchStructuredAddressAsync(Azure.Maps.Search.StructuredAddress address, Azure.Maps.Search.Models.SearchStructuredAddressOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MapsSearchClientOptions : Azure.Core.ClientOptions
    {
        public MapsSearchClientOptions(Azure.Maps.Search.MapsSearchClientOptions.ServiceVersion version = Azure.Maps.Search.MapsSearchClientOptions.ServiceVersion.V1_0, System.Uri endpoint = null) { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V1_0 = 1,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperatingHoursRange : System.IEquatable<Azure.Maps.Search.OperatingHoursRange>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperatingHoursRange(string value) { throw null; }
        public static Azure.Maps.Search.OperatingHoursRange NextSevenDays { get { throw null; } }
        public bool Equals(Azure.Maps.Search.OperatingHoursRange other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.OperatingHoursRange left, Azure.Maps.Search.OperatingHoursRange right) { throw null; }
        public static implicit operator Azure.Maps.Search.OperatingHoursRange (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.OperatingHoursRange left, Azure.Maps.Search.OperatingHoursRange right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PointOfInterestExtendedPostalCodes : System.IEquatable<Azure.Maps.Search.PointOfInterestExtendedPostalCodes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PointOfInterestExtendedPostalCodes(string value) { throw null; }
        public static Azure.Maps.Search.PointOfInterestExtendedPostalCodes None { get { throw null; } }
        public static Azure.Maps.Search.PointOfInterestExtendedPostalCodes PointOfInterest { get { throw null; } }
        public bool Equals(Azure.Maps.Search.PointOfInterestExtendedPostalCodes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.PointOfInterestExtendedPostalCodes left, Azure.Maps.Search.PointOfInterestExtendedPostalCodes right) { throw null; }
        public static implicit operator Azure.Maps.Search.PointOfInterestExtendedPostalCodes (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.PointOfInterestExtendedPostalCodes left, Azure.Maps.Search.PointOfInterestExtendedPostalCodes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReverseSearchAddressBatchOperation : Azure.Operation<Azure.Maps.Search.Models.ReverseSearchAddressBatchResult>
    {
        protected ReverseSearchAddressBatchOperation() { }
        public ReverseSearchAddressBatchOperation(Azure.Maps.Search.MapsSearchClient client, string id) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Maps.Search.Models.ReverseSearchAddressBatchResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Maps.Search.Models.ReverseSearchAddressBatchResult> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Maps.Search.Models.ReverseSearchAddressBatchResult> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Maps.Search.Models.ReverseSearchAddressBatchResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Maps.Search.Models.ReverseSearchAddressBatchResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReverseSearchAddressQuery
    {
        public ReverseSearchAddressQuery(Azure.Maps.Search.ReverseSearchOptions options = null) { }
        public Azure.Maps.Search.ReverseSearchOptions ReverseSearchAddressOptions { get { throw null; } }
    }
    public partial class ReverseSearchBaseOptions
    {
        public ReverseSearchBaseOptions() { }
        public Azure.Core.GeoJson.GeoPosition? Coordinates { get { throw null; } set { } }
        public int? Heading { get { throw null; } set { } }
        public Azure.Maps.Search.SearchLanguage Language { get { throw null; } set { } }
        public Azure.Maps.LocalizedMapView? LocalizedMapView { get { throw null; } set { } }
        public int? RadiusInMeters { get { throw null; } set { } }
    }
    public partial class ReverseSearchCrossStreetOptions : Azure.Maps.Search.ReverseSearchBaseOptions
    {
        public ReverseSearchCrossStreetOptions() { }
        public int? Top { get { throw null; } set { } }
    }
    public partial class ReverseSearchOptions : Azure.Maps.Search.ReverseSearchBaseOptions
    {
        public ReverseSearchOptions() { }
        public bool? AllowFreeformNewline { get { throw null; } set { } }
        public Azure.Maps.Search.GeographicEntity? EntityType { get { throw null; } set { } }
        public bool? IncludeMatchType { get { throw null; } set { } }
        public bool? IncludeRoadUse { get { throw null; } set { } }
        public bool? IncludeSpeedLimit { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.Maps.Search.RoadKind> RoadUse { get { throw null; } set { } }
        public int? StreetNumber { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoadKind : System.IEquatable<Azure.Maps.Search.RoadKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoadKind(string value) { throw null; }
        public static Azure.Maps.Search.RoadKind Arterial { get { throw null; } }
        public static Azure.Maps.Search.RoadKind LimitedAccess { get { throw null; } }
        public static Azure.Maps.Search.RoadKind LocalStreet { get { throw null; } }
        public static Azure.Maps.Search.RoadKind Ramp { get { throw null; } }
        public static Azure.Maps.Search.RoadKind Rotary { get { throw null; } }
        public static Azure.Maps.Search.RoadKind Terminal { get { throw null; } }
        public bool Equals(Azure.Maps.Search.RoadKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.RoadKind left, Azure.Maps.Search.RoadKind right) { throw null; }
        public static implicit operator Azure.Maps.Search.RoadKind (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.RoadKind left, Azure.Maps.Search.RoadKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchAddressBaseOptions : Azure.Maps.Search.SearchBaseOptions
    {
        public SearchAddressBaseOptions() { }
        public Azure.Core.GeoJson.GeoPosition? Coordinates { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<string> CountryFilter { get { throw null; } set { } }
        public int? RadiusInMeters { get { throw null; } set { } }
    }
    public partial class SearchAddressBatchOperation : Azure.Operation<Azure.Maps.Search.Models.SearchAddressBatchResult>
    {
        protected SearchAddressBatchOperation() { }
        public SearchAddressBatchOperation(Azure.Maps.Search.MapsSearchClient client, string id) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Maps.Search.Models.SearchAddressBatchResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Maps.Search.Models.SearchAddressBatchResult> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Maps.Search.Models.SearchAddressBatchResult> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Maps.Search.Models.SearchAddressBatchResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Maps.Search.Models.SearchAddressBatchResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SearchAddressOptions : Azure.Maps.Search.SearchAddressBaseOptions
    {
        public SearchAddressOptions() { }
        public Azure.Core.GeoJson.GeoBoundingBox BoundingBox { get { throw null; } set { } }
        public Azure.Maps.Search.GeographicEntity? EntityType { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.Maps.Search.SearchIndex> ExtendedPostalCodesFor { get { throw null; } set { } }
        public bool? IsTypeAhead { get { throw null; } set { } }
    }
    public partial class SearchAddressQuery
    {
        public SearchAddressQuery(string query, Azure.Maps.Search.SearchAddressOptions options = null) { }
        public string Query { get { throw null; } }
        public Azure.Maps.Search.SearchAddressOptions SearchAddressOptions { get { throw null; } }
    }
    public partial class SearchAlongRouteOptions : Azure.Maps.Search.SearchGeometryBaseOptions
    {
        public SearchAlongRouteOptions() { }
        public System.Collections.Generic.IEnumerable<string> BrandFilter { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.Maps.Search.ElectricVehicleConnector> ElectricVehicleConnectorFilter { get { throw null; } set { } }
    }
    public partial class SearchBaseOptions
    {
        public SearchBaseOptions() { }
        public Azure.Maps.Search.SearchLanguage Language { get { throw null; } set { } }
        public Azure.Maps.LocalizedMapView? LocalizedMapView { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class SearchGeometryBaseOptions
    {
        public SearchGeometryBaseOptions() { }
        public System.Collections.Generic.IEnumerable<int> CategoryFilter { get { throw null; } set { } }
        public Azure.Maps.LocalizedMapView? LocalizedMapView { get { throw null; } set { } }
        public Azure.Maps.Search.OperatingHoursRange? OperatingHours { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchIndex : System.IEquatable<Azure.Maps.Search.SearchIndex>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchIndex(string value) { throw null; }
        public static Azure.Maps.Search.SearchIndex Addresses { get { throw null; } }
        public static Azure.Maps.Search.SearchIndex CrossStreets { get { throw null; } }
        public static Azure.Maps.Search.SearchIndex Geographies { get { throw null; } }
        public static Azure.Maps.Search.SearchIndex PointAddresses { get { throw null; } }
        public static Azure.Maps.Search.SearchIndex PointsOfInterest { get { throw null; } }
        public static Azure.Maps.Search.SearchIndex Streets { get { throw null; } }
        public bool Equals(Azure.Maps.Search.SearchIndex other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.SearchIndex left, Azure.Maps.Search.SearchIndex right) { throw null; }
        public static implicit operator Azure.Maps.Search.SearchIndex (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.SearchIndex left, Azure.Maps.Search.SearchIndex right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchInsideGeometryOptions : Azure.Maps.Search.SearchGeometryBaseOptions
    {
        public SearchInsideGeometryOptions() { }
        public System.Collections.Generic.IEnumerable<Azure.Maps.Search.SearchIndex> ExtendedPostalCodesFor { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.Maps.Search.SearchIndex> IndexFilter { get { throw null; } set { } }
        public Azure.Maps.Search.SearchLanguage Language { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchLanguage : System.IEquatable<Azure.Maps.Search.SearchLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchLanguage(string value) { throw null; }
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
        public bool Equals(Azure.Maps.Search.SearchLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.SearchLanguage left, Azure.Maps.Search.SearchLanguage right) { throw null; }
        public static implicit operator Azure.Maps.Search.SearchLanguage (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.SearchLanguage left, Azure.Maps.Search.SearchLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchNearbyPointOfInterestOptions : Azure.Maps.Search.SearchPointOfInterestOptions
    {
        public SearchNearbyPointOfInterestOptions() { }
        public new System.Collections.Generic.IEnumerable<Azure.Maps.Search.SearchIndex> ExtendedPostalCodesFor { get { throw null; } set { } }
    }
    public partial class SearchPointOfInterestCategoryOptions : Azure.Maps.Search.SearchPointOfInterestOptions
    {
        public SearchPointOfInterestCategoryOptions() { }
        public Azure.Core.GeoJson.GeoBoundingBox BoundingBox { get { throw null; } set { } }
        public new System.Collections.Generic.IEnumerable<Azure.Maps.Search.SearchIndex> ExtendedPostalCodesFor { get { throw null; } set { } }
        public bool? IsTypeAhead { get { throw null; } set { } }
        public Azure.Maps.Search.OperatingHoursRange? OperatingHours { get { throw null; } set { } }
        public string query { get { throw null; } set { } }
    }
    public partial class SearchPointOfInterestOptions : Azure.Maps.Search.SearchAddressBaseOptions
    {
        public SearchPointOfInterestOptions() { }
        public System.Collections.Generic.IEnumerable<string> BrandFilter { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<int> CategoryFilter { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.Maps.Search.ElectricVehicleConnector> ElectricVehicleConnectorFilter { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.Maps.Search.PointOfInterestExtendedPostalCodes> ExtendedPostalCodesFor { get { throw null; } set { } }
    }
    public partial class StructuredAddress
    {
        public StructuredAddress() { }
        public string CountryCode { get { throw null; } set { } }
        public string CountrySecondarySubdivision { get { throw null; } set { } }
        public string CountrySubdivision { get { throw null; } set { } }
        public string CountryTertiarySubdivision { get { throw null; } set { } }
        public string CrossStreet { get { throw null; } set { } }
        public string Municipality { get { throw null; } set { } }
        public string MunicipalitySubdivision { get { throw null; } set { } }
        public string PostalCode { get { throw null; } set { } }
        public string StreetName { get { throw null; } set { } }
        public string StreetNumber { get { throw null; } set { } }
    }
}
namespace Azure.Maps.Search.Models
{
    public partial class AddressRanges
    {
        internal AddressRanges() { }
        public Azure.Core.GeoJson.GeoPosition From { get { throw null; } }
        public string RangeLeft { get { throw null; } }
        public string RangeRight { get { throw null; } }
        public Azure.Core.GeoJson.GeoPosition To { get { throw null; } }
    }
    public partial class BatchResult
    {
        internal BatchResult() { }
        public int? SuccessfulRequests { get { throw null; } }
        public int? TotalRequests { get { throw null; } }
    }
    public partial class BrandName
    {
        internal BrandName() { }
        public string Name { get { throw null; } }
    }
    public partial class ClassificationName
    {
        internal ClassificationName() { }
        public string Name { get { throw null; } }
        public string NameLocale { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntryPointType : System.IEquatable<Azure.Maps.Search.Models.EntryPointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntryPointType(string value) { throw null; }
        public static Azure.Maps.Search.Models.EntryPointType Main { get { throw null; } }
        public static Azure.Maps.Search.Models.EntryPointType Minor { get { throw null; } }
        public bool Equals(Azure.Maps.Search.Models.EntryPointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.Models.EntryPointType left, Azure.Maps.Search.Models.EntryPointType right) { throw null; }
        public static implicit operator Azure.Maps.Search.Models.EntryPointType (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.Models.EntryPointType left, Azure.Maps.Search.Models.EntryPointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FacilityEntryPoint
    {
        internal FacilityEntryPoint() { }
        public Azure.Maps.Search.Models.EntryPointType? EntryPointType { get { throw null; } }
        public Azure.Core.GeoJson.GeoPosition Position { get { throw null; } }
    }
    public partial class FuzzySearchQuery
    {
        public FuzzySearchQuery(string query, Azure.Maps.Search.FuzzySearchOptions options = null) { }
        public Azure.Maps.Search.FuzzySearchOptions FuzzySearchOptions { get { throw null; } }
        public string Query { get { throw null; } }
    }
    public partial class GeoJsonLineStringData
    {
        public GeoJsonLineStringData(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<double>> coordinates) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<double>> Coordinates { get { throw null; } }
    }
    public partial class GeoJsonMultiLineStringData
    {
        public GeoJsonMultiLineStringData(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.Collections.Generic.IList<double>>> coordinates) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<System.Collections.Generic.IList<double>>> Coordinates { get { throw null; } }
    }
    public partial class GeoJsonMultiPointData
    {
        public GeoJsonMultiPointData(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<double>> coordinates) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<double>> Coordinates { get { throw null; } }
    }
    public partial class GeoJsonMultiPolygonData
    {
        public GeoJsonMultiPolygonData(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.Collections.Generic.IList<System.Collections.Generic.IList<double>>>> coordinates) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<System.Collections.Generic.IList<System.Collections.Generic.IList<double>>>> Coordinates { get { throw null; } }
    }
    public abstract partial class GeoJsonObject
    {
        protected GeoJsonObject() { }
    }
    public enum GeoJsonObjectType
    {
        GeoJsonPoint = 0,
        GeoJsonMultiPoint = 1,
        GeoJsonLineString = 2,
        GeoJsonMultiLineString = 3,
        GeoJsonPolygon = 4,
        GeoJsonMultiPolygon = 5,
        GeoJsonGeometryCollection = 6,
        GeoJsonFeature = 7,
        GeoJsonFeatureCollection = 8,
    }
    public partial class GeoJsonPointData
    {
        public GeoJsonPointData(System.Collections.Generic.IEnumerable<double> coordinates) { }
        public System.Collections.Generic.IList<double> Coordinates { get { throw null; } }
    }
    public partial class GeoJsonPolygonData
    {
        public GeoJsonPolygonData(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.Collections.Generic.IList<double>>> coordinates) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<System.Collections.Generic.IList<double>>> Coordinates { get { throw null; } }
    }
    public partial class GeometryIdentifier
    {
        internal GeometryIdentifier() { }
        public string Id { get { throw null; } }
    }
    public partial class MapsAddress
    {
        internal MapsAddress() { }
        public Azure.Core.GeoJson.GeoBoundingBox BoundingBox { get { throw null; } }
        public string BuildingNumber { get { throw null; } }
        public string Country { get { throw null; } }
        public string CountryCode { get { throw null; } }
        public string CountryCodeIso3 { get { throw null; } }
        public string CountrySecondarySubdivision { get { throw null; } }
        public string CountrySubdivision { get { throw null; } }
        public string CountrySubdivisionName { get { throw null; } }
        public string CountryTertiarySubdivision { get { throw null; } }
        public string CrossStreet { get { throw null; } }
        public string ExtendedPostalCode { get { throw null; } }
        public string FreeformAddress { get { throw null; } }
        public string LocalName { get { throw null; } }
        public string Municipality { get { throw null; } }
        public string MunicipalitySubdivision { get { throw null; } }
        public string PostalCode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RouteNumbers { get { throw null; } }
        public string Street { get { throw null; } }
        public string StreetName { get { throw null; } }
        public string StreetNameAndNumber { get { throw null; } }
        public string StreetNumber { get { throw null; } }
    }
    public partial class MapsDataSource
    {
        internal MapsDataSource() { }
        public Azure.Maps.Search.Models.GeometryIdentifier Geometry { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapsEntityType : System.IEquatable<Azure.Maps.Search.Models.MapsEntityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapsEntityType(string value) { throw null; }
        public static Azure.Maps.Search.Models.MapsEntityType Position { get { throw null; } }
        public bool Equals(Azure.Maps.Search.Models.MapsEntityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.Models.MapsEntityType left, Azure.Maps.Search.Models.MapsEntityType right) { throw null; }
        public static implicit operator Azure.Maps.Search.Models.MapsEntityType (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.Models.MapsEntityType left, Azure.Maps.Search.Models.MapsEntityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapsQueryType : System.IEquatable<Azure.Maps.Search.Models.MapsQueryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapsQueryType(string value) { throw null; }
        public static Azure.Maps.Search.Models.MapsQueryType Global { get { throw null; } }
        public static Azure.Maps.Search.Models.MapsQueryType Nearby { get { throw null; } }
        public bool Equals(Azure.Maps.Search.Models.MapsQueryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.Models.MapsQueryType left, Azure.Maps.Search.Models.MapsQueryType right) { throw null; }
        public static implicit operator Azure.Maps.Search.Models.MapsQueryType (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.Models.MapsQueryType left, Azure.Maps.Search.Models.MapsQueryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapsSearchMatchType : System.IEquatable<Azure.Maps.Search.Models.MapsSearchMatchType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapsSearchMatchType(string value) { throw null; }
        public static Azure.Maps.Search.Models.MapsSearchMatchType AddressPoint { get { throw null; } }
        public static Azure.Maps.Search.Models.MapsSearchMatchType HouseNumberRange { get { throw null; } }
        public static Azure.Maps.Search.Models.MapsSearchMatchType Street { get { throw null; } }
        public bool Equals(Azure.Maps.Search.Models.MapsSearchMatchType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.Models.MapsSearchMatchType left, Azure.Maps.Search.Models.MapsSearchMatchType right) { throw null; }
        public static implicit operator Azure.Maps.Search.Models.MapsSearchMatchType (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.Models.MapsSearchMatchType left, Azure.Maps.Search.Models.MapsSearchMatchType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class MapsSearchModelFactory
    {
        public static Azure.Maps.Search.Models.BrandName BrandName(string name = null) { throw null; }
        public static Azure.Maps.Search.Models.ClassificationName ClassificationName(string nameLocale = null, string name = null) { throw null; }
        public static Azure.Maps.Search.Models.GeometryIdentifier GeometryIdentifier(string id = null) { throw null; }
        public static Azure.Maps.Search.Models.MapsDataSource MapsDataSource(Azure.Maps.Search.Models.GeometryIdentifier geometry = null) { throw null; }
        public static Azure.Maps.Search.Models.OperatingHours OperatingHours(string mode = null, System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.OperatingHoursTimeRange> timeRanges = null) { throw null; }
        public static Azure.Maps.Search.Models.PointOfInterestCategory PointOfInterestCategory(int? id = default(int?), string name = null, System.Collections.Generic.IEnumerable<int> childIds = null, System.Collections.Generic.IEnumerable<string> synonyms = null) { throw null; }
        public static Azure.Maps.Search.Models.PointOfInterestCategorySet PointOfInterestCategorySet(int? id = default(int?)) { throw null; }
        public static Azure.Maps.Search.Models.PointOfInterestCategoryTreeResult PointOfInterestCategoryTreeResult(System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.PointOfInterestCategory> categories = null) { throw null; }
        public static Azure.Maps.Search.Models.PointOfInterestClassification PointOfInterestClassification(string code = null, System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.ClassificationName> names = null) { throw null; }
        public static Azure.Maps.Search.Models.PolygonObject PolygonObject(string providerId = null, Azure.Core.GeoJson.GeoObject geometryData = null) { throw null; }
        public static Azure.Maps.Search.Models.PolygonResult PolygonResult(System.Collections.Generic.IEnumerable<Azure.Maps.Search.Models.PolygonObject> polygons = null) { throw null; }
        public static Azure.Maps.Search.Models.ReverseSearchAddressItem ReverseSearchAddressItem(Azure.Maps.Search.Models.MapsAddress address = null, string position = null, System.Collections.Generic.IEnumerable<Azure.Maps.Search.RoadKind> roadUse = null, Azure.Maps.Search.Models.MapsSearchMatchType? matchType = default(Azure.Maps.Search.Models.MapsSearchMatchType?)) { throw null; }
        public static Azure.Maps.Search.Models.ReverseSearchCrossStreetAddressResultItem ReverseSearchCrossStreetAddressResultItem(Azure.Maps.Search.Models.MapsAddress address = null, string position = null) { throw null; }
    }
    public partial class OperatingHours
    {
        internal OperatingHours() { }
        public string Mode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.OperatingHoursTimeRange> TimeRanges { get { throw null; } }
    }
    public partial class OperatingHoursTimeRange
    {
        internal OperatingHoursTimeRange() { }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
    }
    public partial class PointOfInterest
    {
        internal PointOfInterest() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.BrandName> Brands { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Categories { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.PointOfInterestCategorySet> CategorySets { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.PointOfInterestClassification> Classifications { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Maps.Search.Models.OperatingHours OperatingHours { get { throw null; } }
        public string Phone { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class PointOfInterestCategory
    {
        internal PointOfInterestCategory() { }
        public System.Collections.Generic.IReadOnlyList<int> ChildIds { get { throw null; } }
        public int? Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Synonyms { get { throw null; } }
    }
    public partial class PointOfInterestCategorySet
    {
        internal PointOfInterestCategorySet() { }
        public int? Id { get { throw null; } }
    }
    public partial class PointOfInterestCategoryTreeResult
    {
        internal PointOfInterestCategoryTreeResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.PointOfInterestCategory> Categories { get { throw null; } }
    }
    public partial class PointOfInterestClassification
    {
        internal PointOfInterestClassification() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.ClassificationName> Names { get { throw null; } }
    }
    public partial class PolygonObject
    {
        internal PolygonObject() { }
        public Azure.Core.GeoJson.GeoObject GeometryData { get { throw null; } }
        public string ProviderId { get { throw null; } }
    }
    public partial class PolygonResult
    {
        internal PolygonResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.PolygonObject> Polygons { get { throw null; } }
    }
    public partial class ReverseSearchAddressBatchItemResponse : Azure.Maps.Search.Models.ReverseSearchAddressResult
    {
        internal ReverseSearchAddressBatchItemResponse() { }
        public Azure.ResponseError ResponseError { get { throw null; } }
    }
    public partial class ReverseSearchAddressBatchResult : Azure.Maps.Search.Models.BatchResult
    {
        internal ReverseSearchAddressBatchResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.ReverseSearchAddressBatchItemResponse> Results { get { throw null; } }
    }
    public partial class ReverseSearchAddressItem
    {
        internal ReverseSearchAddressItem() { }
        public Azure.Maps.Search.Models.MapsAddress Address { get { throw null; } }
        public Azure.Maps.Search.Models.MapsSearchMatchType? MatchType { get { throw null; } }
        public string Position { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.RoadKind> RoadUse { get { throw null; } }
    }
    public partial class ReverseSearchAddressResult
    {
        internal ReverseSearchAddressResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.ReverseSearchAddressItem> Addresses { get { throw null; } }
        public string Query { get { throw null; } }
        public int? QueryTime { get { throw null; } }
        public Azure.Maps.Search.Models.MapsQueryType? QueryType { get { throw null; } }
    }
    public partial class ReverseSearchCrossStreetAddressResult
    {
        internal ReverseSearchCrossStreetAddressResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.ReverseSearchCrossStreetAddressResultItem> Addresses { get { throw null; } }
        public string Query { get { throw null; } }
        public int? QueryTime { get { throw null; } }
        public Azure.Maps.Search.Models.MapsQueryType? QueryType { get { throw null; } }
    }
    public partial class ReverseSearchCrossStreetAddressResultItem
    {
        internal ReverseSearchCrossStreetAddressResultItem() { }
        public Azure.Maps.Search.Models.MapsAddress Address { get { throw null; } }
        public string Position { get { throw null; } }
    }
    public partial class SearchAddressBatchItemResponse : Azure.Maps.Search.Models.SearchAddressResult
    {
        internal SearchAddressBatchItemResponse() { }
        public Azure.ResponseError ResponseError { get { throw null; } }
    }
    public partial class SearchAddressBatchResult : Azure.Maps.Search.Models.BatchResult
    {
        internal SearchAddressBatchResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.SearchAddressBatchItemResponse> Results { get { throw null; } }
    }
    public partial class SearchAddressResult
    {
        internal SearchAddressResult() { }
        public int? FuzzyLevel { get { throw null; } }
        public Azure.Core.GeoJson.GeoPosition GeoBias { get { throw null; } }
        public int? NumResults { get { throw null; } }
        public string Query { get { throw null; } }
        public int? QueryTime { get { throw null; } }
        public Azure.Maps.Search.Models.MapsQueryType? QueryType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.SearchAddressResultItem> Results { get { throw null; } }
        public int? Skip { get { throw null; } }
        public int? Top { get { throw null; } }
        public int? TotalResults { get { throw null; } }
    }
    public partial class SearchAddressResultItem
    {
        internal SearchAddressResultItem() { }
        public Azure.Maps.Search.Models.MapsAddress Address { get { throw null; } }
        public Azure.Maps.Search.Models.AddressRanges AddressRanges { get { throw null; } }
        public string DataSourceInfo { get { throw null; } }
        public Azure.Maps.Search.Models.MapsDataSource DataSources { get { throw null; } }
        public System.TimeSpan DetourTime { get { throw null; } }
        public double? DistanceInMeters { get { throw null; } }
        public Azure.Maps.Search.GeographicEntity? EntityType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Search.Models.FacilityEntryPoint> EntryPoints { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Maps.Search.Models.MapsSearchMatchType? MatchType { get { throw null; } }
        public Azure.Maps.Search.Models.PointOfInterest PointOfInterest { get { throw null; } }
        public Azure.Core.GeoJson.GeoPosition Position { get { throw null; } }
        public double? Score { get { throw null; } }
        public Azure.Maps.Search.Models.SearchAddressResultType? SearchAddressResultType { get { throw null; } }
        public Azure.Core.GeoJson.GeoBoundingBox Viewport { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchAddressResultType : System.IEquatable<Azure.Maps.Search.Models.SearchAddressResultType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public static Azure.Maps.Search.Models.SearchAddressResultType AddressRange { get { throw null; } }
        public static Azure.Maps.Search.Models.SearchAddressResultType CrossStreet { get { throw null; } }
        public static Azure.Maps.Search.Models.SearchAddressResultType Geography { get { throw null; } }
        public static Azure.Maps.Search.Models.SearchAddressResultType PointAddress { get { throw null; } }
        public static Azure.Maps.Search.Models.SearchAddressResultType PointOfInterest { get { throw null; } }
        public static Azure.Maps.Search.Models.SearchAddressResultType Street { get { throw null; } }
        public bool Equals(Azure.Maps.Search.Models.SearchAddressResultType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Search.Models.SearchAddressResultType left, Azure.Maps.Search.Models.SearchAddressResultType right) { throw null; }
        public static implicit operator Azure.Maps.Search.Models.SearchAddressResultType (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Search.Models.SearchAddressResultType left, Azure.Maps.Search.Models.SearchAddressResultType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchStructuredAddressOptions : Azure.Maps.Search.SearchBaseOptions
    {
        public SearchStructuredAddressOptions() { }
        public Azure.Maps.Search.GeographicEntity? EntityType { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.Maps.Search.SearchIndex> ExtendedPostalCodesFor { get { throw null; } set { } }
    }
}
