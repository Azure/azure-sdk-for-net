namespace Azure.Maps.Render
{
    public partial class CopyrightCaption
    {
        internal CopyrightCaption() { }
        public string CopyrightsCaption { get { throw null; } }
        public string FormatVersion { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapImageLayer : System.IEquatable<Azure.Maps.Render.MapImageLayer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapImageLayer(string value) { throw null; }
        public static Azure.Maps.Render.MapImageLayer Basic { get { throw null; } }
        public static Azure.Maps.Render.MapImageLayer Hybrid { get { throw null; } }
        public static Azure.Maps.Render.MapImageLayer Labels { get { throw null; } }
        public bool Equals(Azure.Maps.Render.MapImageLayer other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Render.MapImageLayer left, Azure.Maps.Render.MapImageLayer right) { throw null; }
        public static implicit operator Azure.Maps.Render.MapImageLayer (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Render.MapImageLayer left, Azure.Maps.Render.MapImageLayer right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapImageStyle : System.IEquatable<Azure.Maps.Render.MapImageStyle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapImageStyle(string value) { throw null; }
        public static Azure.Maps.Render.MapImageStyle Dark { get { throw null; } }
        public static Azure.Maps.Render.MapImageStyle Main { get { throw null; } }
        public bool Equals(Azure.Maps.Render.MapImageStyle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Render.MapImageStyle left, Azure.Maps.Render.MapImageStyle right) { throw null; }
        public static implicit operator Azure.Maps.Render.MapImageStyle (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Render.MapImageStyle left, Azure.Maps.Render.MapImageStyle right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MapsRenderClient
    {
        protected MapsRenderClient() { }
        public MapsRenderClient(Azure.AzureKeyCredential credential) { }
        public MapsRenderClient(Azure.AzureKeyCredential credential, Azure.Maps.Render.MapsRenderClientOptions options) { }
        public MapsRenderClient(Azure.Core.TokenCredential credential, string clientId) { }
        public MapsRenderClient(Azure.Core.TokenCredential credential, string clientId, Azure.Maps.Render.MapsRenderClientOptions options) { }
        public virtual Azure.Response<Azure.Maps.Render.CopyrightCaption> GetCopyrightCaption(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Render.CopyrightCaption>> GetCopyrightCaptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Render.RenderCopyrights> GetCopyrightForTile(Azure.Maps.Render.TileIndex tileIndex, bool includeText = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Render.RenderCopyrights>> GetCopyrightForTileAsync(Azure.Maps.Render.TileIndex tileIndex, bool includeText = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Render.RenderCopyrights> GetCopyrightForWorld(bool includeText = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Render.RenderCopyrights>> GetCopyrightForWorldAsync(bool includeText = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Render.RenderCopyrights> GetCopyrightFromBoundingBox(Azure.Core.GeoJson.GeoBoundingBox geoBoundingBox, bool includeText = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Render.RenderCopyrights>> GetCopyrightFromBoundingBoxAsync(Azure.Core.GeoJson.GeoBoundingBox geoBoundingBox, bool includeText = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetMapImageryTile(Azure.Maps.Render.TileIndex tileIndex, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetMapImageryTileAsync(Azure.Maps.Render.TileIndex tileIndex, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetMapStateTile(string statesetId, Azure.Maps.Render.TileIndex tileIndex, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetMapStateTileAsync(string statesetId, Azure.Maps.Render.TileIndex tileIndex, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetMapStaticImage(Azure.Maps.Render.RenderStaticImageOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetMapStaticImageAsync(Azure.Maps.Render.RenderStaticImageOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetMapTile(Azure.Maps.Render.RenderTileOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetMapTileAsync(Azure.Maps.Render.RenderTileOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MapsRenderClientOptions : Azure.Core.ClientOptions
    {
        public MapsRenderClientOptions(Azure.Maps.Render.MapsRenderClientOptions.ServiceVersion version = Azure.Maps.Render.MapsRenderClientOptions.ServiceVersion.V1_0, System.Uri endpoint = null) { }
        public enum ServiceVersion
        {
            V1_0 = 1,
        }
    }
    public static partial class MapsRenderModelFactory
    {
        public static Azure.Maps.Render.CopyrightCaption CopyrightCaption(string formatVersion = null, string copyrightsCaption = null) { throw null; }
        public static Azure.Maps.Render.RegionCopyrights RegionCopyrights(System.Collections.Generic.IEnumerable<string> copyrights = null, Azure.Maps.Render.RegionCopyrightsCountry country = null) { throw null; }
        public static Azure.Maps.Render.RegionCopyrightsCountry RegionCopyrightsCountry(string iso3 = null, string label = null) { throw null; }
        public static Azure.Maps.Render.RenderCopyrights RenderCopyrights(string formatVersion = null, System.Collections.Generic.IEnumerable<string> generalCopyrights = null, System.Collections.Generic.IEnumerable<Azure.Maps.Render.RegionCopyrights> regions = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapTileLayer : System.IEquatable<Azure.Maps.Render.MapTileLayer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapTileLayer(string value) { throw null; }
        public static Azure.Maps.Render.MapTileLayer Basic { get { throw null; } }
        public static Azure.Maps.Render.MapTileLayer Hybrid { get { throw null; } }
        public static Azure.Maps.Render.MapTileLayer Labels { get { throw null; } }
        public static Azure.Maps.Render.MapTileLayer Terra { get { throw null; } }
        public bool Equals(Azure.Maps.Render.MapTileLayer other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Render.MapTileLayer left, Azure.Maps.Render.MapTileLayer right) { throw null; }
        public static implicit operator Azure.Maps.Render.MapTileLayer (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Render.MapTileLayer left, Azure.Maps.Render.MapTileLayer right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapTileSize : System.IEquatable<Azure.Maps.Render.MapTileSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapTileSize(string value) { throw null; }
        public static Azure.Maps.Render.MapTileSize Size256 { get { throw null; } }
        public static Azure.Maps.Render.MapTileSize Size512 { get { throw null; } }
        public bool Equals(Azure.Maps.Render.MapTileSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Render.MapTileSize left, Azure.Maps.Render.MapTileSize right) { throw null; }
        public static implicit operator Azure.Maps.Render.MapTileSize (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Render.MapTileSize left, Azure.Maps.Render.MapTileSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapTileStyle : System.IEquatable<Azure.Maps.Render.MapTileStyle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapTileStyle(string value) { throw null; }
        public static Azure.Maps.Render.MapTileStyle Dark { get { throw null; } }
        public static Azure.Maps.Render.MapTileStyle Main { get { throw null; } }
        public static Azure.Maps.Render.MapTileStyle ShadedRelief { get { throw null; } }
        public bool Equals(Azure.Maps.Render.MapTileStyle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Render.MapTileStyle left, Azure.Maps.Render.MapTileStyle right) { throw null; }
        public static implicit operator Azure.Maps.Render.MapTileStyle (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Render.MapTileStyle left, Azure.Maps.Render.MapTileStyle right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PathStyle
    {
        public PathStyle(System.Collections.Generic.IList<Azure.Core.GeoJson.GeoPosition> pathPositions) { }
        public PathStyle(string dataStorageId) { }
        public int? CircleRadiusInMeters { get { throw null; } set { } }
        public string DataStorageId { get { throw null; } }
        public System.Drawing.Color? FillColor { get { throw null; } set { } }
        public System.Drawing.Color? LineColor { get { throw null; } set { } }
        public int? LineWidthInPixels { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.GeoJson.GeoPosition> PathPositions { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public partial class PinPosition
    {
        public PinPosition(double longitude, double latitude, string? label = null) { }
        public PinPosition(string dataStorageId, string? label = null) { }
        public override string ToString() { throw null; }
    }
    public partial class PushpinStyle
    {
        public PushpinStyle(System.Collections.Generic.IList<Azure.Maps.Render.PinPosition> pinPositions, System.Drawing.Point? pinAnchorShift = default(System.Drawing.Point?), System.Drawing.Color? pinColor = default(System.Drawing.Color?), double? pinScale = default(double?), System.Uri? customPinImage = null, System.Drawing.Point? labelAnchorShift = default(System.Drawing.Point?), System.Drawing.Color? labelColor = default(System.Drawing.Color?), double? labelScale = default(double?), int? rotation = default(int?)) { }
        public System.Uri? CustomPinImage { get { throw null; } set { } }
        public System.Drawing.Point? LabelAnchorShiftInPixels { get { throw null; } set { } }
        public System.Drawing.Color? LabelColor { get { throw null; } set { } }
        public double? LabelScale { get { throw null; } set { } }
        public System.Drawing.Point? PinAnchorShiftInPixels { get { throw null; } set { } }
        public System.Drawing.Color? PinColor { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Maps.Render.PinPosition> PinPositions { get { throw null; } }
        public double? PinScale { get { throw null; } set { } }
        public int? RotationInDegrees { get { throw null; } set { } }
        public override string ToString() { throw null; }
    }
    public partial class RegionCopyrights
    {
        internal RegionCopyrights() { }
        public System.Collections.Generic.IReadOnlyList<string> Copyrights { get { throw null; } }
        public Azure.Maps.Render.RegionCopyrightsCountry Country { get { throw null; } }
    }
    public partial class RegionCopyrightsCountry
    {
        internal RegionCopyrightsCountry() { }
        public string Iso3 { get { throw null; } }
        public string Label { get { throw null; } }
    }
    public partial class RenderCopyrights
    {
        internal RenderCopyrights() { }
        public string FormatVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> GeneralCopyrights { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Render.RegionCopyrights> Regions { get { throw null; } }
    }
    public partial class RenderStaticImageOptions
    {
        public RenderStaticImageOptions(Azure.Core.GeoJson.GeoBoundingBox boundingBox) { }
        public RenderStaticImageOptions(Azure.Core.GeoJson.GeoPosition centerCoordinate, int widthInPixels, int heightInPixels) { }
        public Azure.Core.GeoJson.GeoBoundingBox BoundingBox { get { throw null; } }
        public Azure.Core.GeoJson.GeoPosition? CenterCoordinate { get { throw null; } }
        public int? HeightInPixels { get { throw null; } }
        public Azure.Maps.LocalizedMapView? LocalizedMapView { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Maps.Render.PathStyle> Paths { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Maps.Render.PushpinStyle> Pins { get { throw null; } set { } }
        public string RenderLanguage { get { throw null; } set { } }
        public Azure.Maps.Render.MapImageLayer? TileLayer { get { throw null; } set { } }
        public Azure.Maps.Render.MapImageStyle? TileStyle { get { throw null; } set { } }
        public int? WidthInPixels { get { throw null; } }
        public int? ZoomLevel { get { throw null; } set { } }
    }
    public partial class RenderTileOptions
    {
        public RenderTileOptions() { }
        public Azure.Maps.LocalizedMapView? LocalizedMapView { get { throw null; } set { } }
        public string RenderLanguage { get { throw null; } set { } }
        public Azure.Maps.Render.TileFormat TileFormat { get { throw null; } set { } }
        public Azure.Maps.Render.TileIndex TileIndex { get { throw null; } set { } }
        public Azure.Maps.Render.MapTileLayer TileLayer { get { throw null; } set { } }
        public Azure.Maps.Render.MapTileSize? TileSize { get { throw null; } set { } }
        public Azure.Maps.Render.MapTileStyle TileStyle { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TileFormat : System.IEquatable<Azure.Maps.Render.TileFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TileFormat(string value) { throw null; }
        public static Azure.Maps.Render.TileFormat Pbf { get { throw null; } }
        public static Azure.Maps.Render.TileFormat Png { get { throw null; } }
        public bool Equals(Azure.Maps.Render.TileFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Render.TileFormat left, Azure.Maps.Render.TileFormat right) { throw null; }
        public static implicit operator Azure.Maps.Render.TileFormat (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Render.TileFormat left, Azure.Maps.Render.TileFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TileIndex
    {
        public TileIndex(int x, int y, int z) { }
        public int X { get { throw null; } }
        public int Y { get { throw null; } }
        public int Z { get { throw null; } }
    }
    public static partial class TileMath
    {
        public static void BestMapView(Azure.Core.GeoJson.GeoBoundingBox boundingBox, double mapWidth, double mapHeight, int padding, int tileSize, out double centerLat, out double centerLon, out double zoom) { throw null; }
        public static void PositionToTileXY(Azure.Core.GeoJson.GeoPosition position, int zoom, int tileSize, out int tileX, out int tileY) { throw null; }
        public static Azure.Core.GeoJson.GeoBoundingBox TileXYToBoundingBox(int tileX, int tileY, double zoom, int tileSize) { throw null; }
    }
}
