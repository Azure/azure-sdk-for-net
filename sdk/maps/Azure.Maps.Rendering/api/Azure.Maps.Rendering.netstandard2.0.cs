namespace Azure.Maps.Rendering
{
    public partial class AzureMapsRenderingContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureMapsRenderingContext() { }
        public static Azure.Maps.Rendering.AzureMapsRenderingContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CopyrightCaption
    {
        internal CopyrightCaption() { }
        public string Copyright { get { throw null; } }
        public string FormatVersion { get { throw null; } }
    }
    public partial class GetMapStaticImageOptions
    {
        public GetMapStaticImageOptions(Azure.Core.GeoJson.GeoBoundingBox boundingBox, System.Collections.Generic.IList<Azure.Maps.Rendering.ImagePushpinStyle> imagePushpinStyles = null, System.Collections.Generic.IList<Azure.Maps.Rendering.ImagePathStyle> imagePathStyles = null) { }
        public GetMapStaticImageOptions(Azure.Core.GeoJson.GeoPosition centerCoordinate, int widthInPixels, int heightInPixels, System.Collections.Generic.IList<Azure.Maps.Rendering.ImagePushpinStyle> imagePushpinStyles = null, System.Collections.Generic.IList<Azure.Maps.Rendering.ImagePathStyle> imagePathStyles = null) { }
        public Azure.Core.GeoJson.GeoBoundingBox BoundingBox { get { throw null; } }
        public Azure.Core.GeoJson.GeoPosition? CenterCoordinate { get { throw null; } }
        public int? HeightInPixels { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Maps.Rendering.ImagePathStyle> ImagePathStyles { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Maps.Rendering.ImagePushpinStyle> ImagePushpinStyles { get { throw null; } }
        public Azure.Maps.Rendering.RenderingLanguage? Language { get { throw null; } set { } }
        public Azure.Maps.LocalizedMapView? LocalizedMapView { get { throw null; } set { } }
        public int? WidthInPixels { get { throw null; } }
        public int? ZoomLevel { get { throw null; } set { } }
    }
    public partial class GetMapTileOptions
    {
        public GetMapTileOptions(Azure.Maps.Rendering.MapTileSetId mapTileSetId, Azure.Maps.Rendering.MapTileIndex mapTileIndex) { }
        public Azure.Maps.Rendering.RenderingLanguage? Language { get { throw null; } set { } }
        public Azure.Maps.LocalizedMapView? LocalizedMapView { get { throw null; } set { } }
        public Azure.Maps.Rendering.MapTileIndex MapTileIndex { get { throw null; } }
        public Azure.Maps.Rendering.MapTileSetId MapTileSetId { get { throw null; } }
        public Azure.Maps.Rendering.MapTileSize? MapTileSize { get { throw null; } set { } }
        public System.DateTimeOffset? TimeStamp { get { throw null; } set { } }
    }
    public partial class ImagePathStyle
    {
        public ImagePathStyle(System.Collections.Generic.IList<Azure.Core.GeoJson.GeoPosition> pathPositions) { }
        public int? CircleRadiusInMeters { get { throw null; } set { } }
        public System.Drawing.Color? FillColor { get { throw null; } set { } }
        public System.Drawing.Color? LineColor { get { throw null; } set { } }
        public int? LineWidthInPixels { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.GeoJson.GeoPosition> PathPositions { get { throw null; } }
    }
    public partial class ImagePushpinStyle
    {
        public ImagePushpinStyle(System.Collections.Generic.IList<Azure.Maps.Rendering.PushpinPosition> pushpinPositions) { }
        public System.Uri? CustomPushpinImageUri { get { throw null; } set { } }
        public System.Drawing.Point? LabelAnchorShiftInPixels { get { throw null; } set { } }
        public System.Drawing.Color? LabelColor { get { throw null; } set { } }
        public double? LabelScaleRatio { get { throw null; } set { } }
        public System.Drawing.Point? PushpinAnchorShiftInPixels { get { throw null; } set { } }
        public System.Drawing.Color? PushpinColor { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Maps.Rendering.PushpinPosition> PushpinPositions { get { throw null; } }
        public double? PushpinScaleRatio { get { throw null; } set { } }
        public int? RotationInDegrees { get { throw null; } set { } }
    }
    public partial class MapsRenderingClient
    {
        protected MapsRenderingClient() { }
        public MapsRenderingClient(Azure.AzureKeyCredential credential) { }
        public MapsRenderingClient(Azure.AzureKeyCredential credential, Azure.Maps.Rendering.MapsRenderingClientOptions options) { }
        public MapsRenderingClient(Azure.AzureSasCredential credential) { }
        public MapsRenderingClient(Azure.AzureSasCredential credential, Azure.Maps.Rendering.MapsRenderingClientOptions options) { }
        public MapsRenderingClient(Azure.Core.TokenCredential credential, string clientId) { }
        public MapsRenderingClient(Azure.Core.TokenCredential credential, string clientId, Azure.Maps.Rendering.MapsRenderingClientOptions options) { }
        public virtual Azure.Response<Azure.Maps.Rendering.CopyrightCaption> GetCopyrightCaption(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Rendering.CopyrightCaption>> GetCopyrightCaptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Rendering.RenderCopyright> GetCopyrightForTile(Azure.Maps.Rendering.MapTileIndex mapTileIndex, bool includeText = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Rendering.RenderCopyright>> GetCopyrightForTileAsync(Azure.Maps.Rendering.MapTileIndex mapTileIndex, bool includeText = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Rendering.RenderCopyright> GetCopyrightForWorld(bool includeText = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Rendering.RenderCopyright>> GetCopyrightForWorldAsync(bool includeText = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Rendering.RenderCopyright> GetCopyrightFromBoundingBox(Azure.Core.GeoJson.GeoBoundingBox geoBoundingBox, bool includeText = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Rendering.RenderCopyright>> GetCopyrightFromBoundingBoxAsync(Azure.Core.GeoJson.GeoBoundingBox geoBoundingBox, bool includeText = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<string>> GetMapCopyrightAttribution(Azure.Maps.Rendering.MapTileSetId tileSetId, Azure.Core.GeoJson.GeoBoundingBox boundingBox, int? zoom = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<string>>> GetMapCopyrightAttributionAsync(Azure.Maps.Rendering.MapTileSetId tileSetId, Azure.Core.GeoJson.GeoBoundingBox boundingBox, int? zoom = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetMapStateTile(string stateSetId, Azure.Maps.Rendering.MapTileIndex mapTileIndex, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetMapStateTileAsync(string stateSetId, Azure.Maps.Rendering.MapTileIndex mapTileIndex, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetMapStaticImage(Azure.Maps.Rendering.GetMapStaticImageOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetMapStaticImageAsync(Azure.Maps.Rendering.GetMapStaticImageOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetMapTile(Azure.Maps.Rendering.GetMapTileOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetMapTileAsync(Azure.Maps.Rendering.GetMapTileOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Rendering.MapTileSet> GetMapTileSet(Azure.Maps.Rendering.MapTileSetId tileSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Rendering.MapTileSet>> GetMapTileSetAsync(Azure.Maps.Rendering.MapTileSetId tileSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Maps.Rendering.MapTileIndex PositionToTileXY(Azure.Core.GeoJson.GeoPosition position, int zoom, int tileSize) { throw null; }
        public static Azure.Core.GeoJson.GeoBoundingBox TileXYToBoundingBox(Azure.Maps.Rendering.MapTileIndex mapTileIndex, int tileSize) { throw null; }
    }
    public partial class MapsRenderingClientOptions : Azure.Core.ClientOptions
    {
        public MapsRenderingClientOptions(Azure.Maps.Rendering.MapsRenderingClientOptions.ServiceVersion version = Azure.Maps.Rendering.MapsRenderingClientOptions.ServiceVersion.V2024_04_01, System.Uri endpoint = null, Azure.Maps.Rendering.MediaType? acceptMediaType = default(Azure.Maps.Rendering.MediaType?)) { }
        public Azure.Maps.Rendering.MediaType? AcceptMediaType { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2024_04_01 = 1,
        }
    }
    public static partial class MapsRenderingModelFactory
    {
        public static Azure.Maps.Rendering.CopyrightCaption CopyrightCaption(string formatVersion = null, string copyright = null) { throw null; }
        public static Azure.Maps.Rendering.RegionalCopyright RegionalCopyright(System.Collections.Generic.IEnumerable<string> copyrights = null, Azure.Maps.Rendering.RegionalCopyrightCountry country = null) { throw null; }
        public static Azure.Maps.Rendering.RegionalCopyrightCountry RegionalCopyrightCountry(string iso3 = null, string label = null) { throw null; }
        public static Azure.Maps.Rendering.RenderCopyright RenderCopyright(string formatVersion = null, System.Collections.Generic.IEnumerable<string> generalCopyrights = null, System.Collections.Generic.IEnumerable<Azure.Maps.Rendering.RegionalCopyright> regionalCopyrights = null) { throw null; }
    }
    public partial class MapTileIndex
    {
        public MapTileIndex(int x, int y, int z) { }
        public int X { get { throw null; } }
        public int Y { get { throw null; } }
        public int Z { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapTileScheme : System.IEquatable<Azure.Maps.Rendering.MapTileScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapTileScheme(string value) { throw null; }
        public static Azure.Maps.Rendering.MapTileScheme Tms { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileScheme Xyz { get { throw null; } }
        public bool Equals(Azure.Maps.Rendering.MapTileScheme other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Rendering.MapTileScheme left, Azure.Maps.Rendering.MapTileScheme right) { throw null; }
        public static implicit operator Azure.Maps.Rendering.MapTileScheme (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Rendering.MapTileScheme left, Azure.Maps.Rendering.MapTileScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MapTileSet
    {
        internal MapTileSet() { }
        public Azure.Core.GeoJson.GeoBoundingBox? BoundingBox { get { throw null; } }
        public Azure.Maps.Rendering.MapTileIndex? CenterTileIndex { get { throw null; } }
        public string CopyrightAttribution { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> GeoJsonDataFiles { get { throw null; } }
        public string MapTileLegend { get { throw null; } }
        public int? MaxZoomLevel { get { throw null; } }
        public int? MinZoomLevel { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> TileEndpoints { get { throw null; } }
        public string TileJsonVersion { get { throw null; } }
        public Azure.Maps.Rendering.MapTileScheme TileScheme { get { throw null; } }
        public string TileSetDescription { get { throw null; } }
        public string TileSetName { get { throw null; } }
        public string TileSetVersion { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapTileSetId : System.IEquatable<Azure.Maps.Rendering.MapTileSetId>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapTileSetId(string value) { throw null; }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftBase { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftBaseDarkgrey { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftBaseHybrid { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftBaseHybridDarkgrey { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftBaseHybridRoad { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftBaseLabels { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftBaseLabelsDarkgrey { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftBaseLabelsRoad { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftBaseRoad { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftImagery { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftTerraMain { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftTrafficAbsolute { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftTrafficAbsoluteMain { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftTrafficDelay { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftTrafficDelayMain { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftTrafficIncident { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftTrafficReducedMain { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftTrafficRelative { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftTrafficRelativeDark { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftTrafficRelativeMain { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftWeatherInfraredMain { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSetId MicrosoftWeatherRadarMain { get { throw null; } }
        public bool Equals(Azure.Maps.Rendering.MapTileSetId other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Rendering.MapTileSetId left, Azure.Maps.Rendering.MapTileSetId right) { throw null; }
        public static implicit operator Azure.Maps.Rendering.MapTileSetId (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Rendering.MapTileSetId left, Azure.Maps.Rendering.MapTileSetId right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapTileSize : System.IEquatable<Azure.Maps.Rendering.MapTileSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapTileSize(string value) { throw null; }
        public static Azure.Maps.Rendering.MapTileSize Size256 { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileSize Size512 { get { throw null; } }
        public bool Equals(Azure.Maps.Rendering.MapTileSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Rendering.MapTileSize left, Azure.Maps.Rendering.MapTileSize right) { throw null; }
        public static implicit operator Azure.Maps.Rendering.MapTileSize (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Rendering.MapTileSize left, Azure.Maps.Rendering.MapTileSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaType : System.IEquatable<Azure.Maps.Rendering.MediaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaType(string value) { throw null; }
        public static Azure.Maps.Rendering.MediaType ImageJpeg { get { throw null; } }
        public static Azure.Maps.Rendering.MediaType ImagePng { get { throw null; } }
        public bool Equals(Azure.Maps.Rendering.MediaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Rendering.MediaType left, Azure.Maps.Rendering.MediaType right) { throw null; }
        public static implicit operator Azure.Maps.Rendering.MediaType (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Rendering.MediaType left, Azure.Maps.Rendering.MediaType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PushpinPosition
    {
        public PushpinPosition(double longitude, double latitude, string? label = null) { }
    }
    public partial class RegionalCopyright
    {
        internal RegionalCopyright() { }
        public System.Collections.Generic.IReadOnlyList<string> Copyrights { get { throw null; } }
        public Azure.Maps.Rendering.RegionalCopyrightCountry Country { get { throw null; } }
    }
    public partial class RegionalCopyrightCountry
    {
        internal RegionalCopyrightCountry() { }
        public string Iso3 { get { throw null; } }
        public string Label { get { throw null; } }
    }
    public partial class RenderCopyright
    {
        internal RenderCopyright() { }
        public string FormatVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> GeneralCopyrights { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Rendering.RegionalCopyright> RegionalCopyrights { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RenderingLanguage : System.IEquatable<Azure.Maps.Rendering.RenderingLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RenderingLanguage(string value) { throw null; }
        public static Azure.Maps.Rendering.RenderingLanguage Arabic { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage Bulgarian { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage Czech { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage Danish { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage DutchNetherlands { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage EnglishAustralia { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage EnglishGreatBritain { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage EnglishNewZealand { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage EnglishUsa { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage Finnish { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage FrenchFrance { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage German { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage Greek { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage Hungarian { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage Indonesian { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage Italian { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage Korean { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage Lithuanian { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage Malay { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage NeutralGroundTruthLatin { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage NeutralGroundTruthLocal { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage Norwegian { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage Polish { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage PortugueseBrazil { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage PortuguesePortugal { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage Russian { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage SimplifiedChinese { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage Slovak { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage Slovenian { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage SpanishMexico { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage SpanishSpain { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage Swedish { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage Thai { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage TraditionalChinese { get { throw null; } }
        public static Azure.Maps.Rendering.RenderingLanguage Turkish { get { throw null; } }
        public bool Equals(Azure.Maps.Rendering.RenderingLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Rendering.RenderingLanguage left, Azure.Maps.Rendering.RenderingLanguage right) { throw null; }
        public static implicit operator Azure.Maps.Rendering.RenderingLanguage (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Rendering.RenderingLanguage left, Azure.Maps.Rendering.RenderingLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficTilesetId : System.IEquatable<Azure.Maps.Rendering.TrafficTilesetId>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficTilesetId(string value) { throw null; }
        public static Azure.Maps.Rendering.TrafficTilesetId MicrosoftTrafficRelativeMain { get { throw null; } }
        public static Azure.Maps.Rendering.TrafficTilesetId None { get { throw null; } }
        public bool Equals(Azure.Maps.Rendering.TrafficTilesetId other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Rendering.TrafficTilesetId left, Azure.Maps.Rendering.TrafficTilesetId right) { throw null; }
        public static implicit operator Azure.Maps.Rendering.TrafficTilesetId (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Rendering.TrafficTilesetId left, Azure.Maps.Rendering.TrafficTilesetId right) { throw null; }
        public override string ToString() { throw null; }
    }
}
