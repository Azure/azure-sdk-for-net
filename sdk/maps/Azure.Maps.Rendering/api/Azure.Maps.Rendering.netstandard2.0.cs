namespace Azure.Maps.Rendering
{
    public partial class CopyrightCaption
    {
        internal CopyrightCaption() { }
        public string Copyright { get { throw null; } }
        public string FormatVersion { get { throw null; } }
    }
    public partial class GetMapStaticImageOptions
    {
        public GetMapStaticImageOptions(Azure.Core.GeoJson.GeoBoundingBox boundingBox) { }
        public GetMapStaticImageOptions(Azure.Core.GeoJson.GeoPosition centerCoordinate, int widthInPixels, int heightInPixels) { }
        public Azure.Core.GeoJson.GeoBoundingBox BoundingBox { get { throw null; } }
        public Azure.Core.GeoJson.GeoPosition? CenterCoordinate { get { throw null; } }
        public int? HeightInPixels { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Maps.Rendering.ImagePathStyle> ImagePathStyles { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Maps.Rendering.ImagePushpinStyle> ImagePushpinStyles { get { throw null; } set { } }
        public Azure.Maps.LocalizedMapView? LocalizedMapView { get { throw null; } set { } }
        public Azure.Maps.Rendering.MapImageLayer? MapImageLayer { get { throw null; } set { } }
        public Azure.Maps.Rendering.MapImageStyle? MapImageStyle { get { throw null; } set { } }
        public string RenderLanguage { get { throw null; } set { } }
        public int? WidthInPixels { get { throw null; } }
        public int? ZoomLevel { get { throw null; } set { } }
    }
    public partial class GetMapTileOptions
    {
        public GetMapTileOptions() { }
        public Azure.Maps.LocalizedMapView? LocalizedMapView { get { throw null; } set { } }
        public Azure.Maps.Rendering.MapTileFormat MapTileFormat { get { throw null; } set { } }
        public Azure.Maps.Rendering.MapTileIndex MapTileIndex { get { throw null; } set { } }
        public Azure.Maps.Rendering.MapTileLayer MapTileLayer { get { throw null; } set { } }
        public Azure.Maps.Rendering.MapTileStyle MapTileStyle { get { throw null; } set { } }
        public string RenderLanguage { get { throw null; } set { } }
        public Azure.Maps.Rendering.MapTileSize? TileSize { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapImageLayer : System.IEquatable<Azure.Maps.Rendering.MapImageLayer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapImageLayer(string value) { throw null; }
        public static Azure.Maps.Rendering.MapImageLayer Basic { get { throw null; } }
        public static Azure.Maps.Rendering.MapImageLayer Hybrid { get { throw null; } }
        public static Azure.Maps.Rendering.MapImageLayer Labels { get { throw null; } }
        public bool Equals(Azure.Maps.Rendering.MapImageLayer other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Rendering.MapImageLayer left, Azure.Maps.Rendering.MapImageLayer right) { throw null; }
        public static implicit operator Azure.Maps.Rendering.MapImageLayer (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Rendering.MapImageLayer left, Azure.Maps.Rendering.MapImageLayer right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapImageStyle : System.IEquatable<Azure.Maps.Rendering.MapImageStyle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapImageStyle(string value) { throw null; }
        public static Azure.Maps.Rendering.MapImageStyle Dark { get { throw null; } }
        public static Azure.Maps.Rendering.MapImageStyle Main { get { throw null; } }
        public bool Equals(Azure.Maps.Rendering.MapImageStyle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Rendering.MapImageStyle left, Azure.Maps.Rendering.MapImageStyle right) { throw null; }
        public static implicit operator Azure.Maps.Rendering.MapImageStyle (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Rendering.MapImageStyle left, Azure.Maps.Rendering.MapImageStyle right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MapsRenderingClient
    {
        protected MapsRenderingClient() { }
        public MapsRenderingClient(Azure.AzureKeyCredential credential) { }
        public MapsRenderingClient(Azure.AzureKeyCredential credential, Azure.Maps.Rendering.MapsRenderingClientOptions options) { }
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
        public virtual Azure.Response<System.IO.Stream> GetMapImageryTile(Azure.Maps.Rendering.MapTileIndex mapTileIndex, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetMapImageryTileAsync(Azure.Maps.Rendering.MapTileIndex mapTileIndex, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetMapStateTile(string stateSetId, Azure.Maps.Rendering.MapTileIndex mapTileIndex, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetMapStateTileAsync(string stateSetId, Azure.Maps.Rendering.MapTileIndex mapTileIndex, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetMapStaticImage(Azure.Maps.Rendering.GetMapStaticImageOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetMapStaticImageAsync(Azure.Maps.Rendering.GetMapStaticImageOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetMapTile(Azure.Maps.Rendering.GetMapTileOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetMapTileAsync(Azure.Maps.Rendering.GetMapTileOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Maps.Rendering.MapTileIndex PositionToTileXY(Azure.Core.GeoJson.GeoPosition position, int zoom, int tileSize) { throw null; }
        public static Azure.Core.GeoJson.GeoBoundingBox TileXYToBoundingBox(Azure.Maps.Rendering.MapTileIndex mapTileIndex, int tileSize) { throw null; }
    }
    public partial class MapsRenderingClientOptions : Azure.Core.ClientOptions
    {
        public MapsRenderingClientOptions(Azure.Maps.Rendering.MapsRenderingClientOptions.ServiceVersion version = Azure.Maps.Rendering.MapsRenderingClientOptions.ServiceVersion.V1_0, System.Uri endpoint = null) { }
        public enum ServiceVersion
        {
            V1_0 = 1,
        }
    }
    public static partial class MapsRenderingModelFactory
    {
        public static Azure.Maps.Rendering.CopyrightCaption CopyrightCaption(string formatVersion = null, string copyright = null) { throw null; }
        public static Azure.Maps.Rendering.RegionalCopyright RegionalCopyright(System.Collections.Generic.IEnumerable<string> copyrights = null, Azure.Maps.Rendering.RegionalCopyrightCountry country = null) { throw null; }
        public static Azure.Maps.Rendering.RegionalCopyrightCountry RegionalCopyrightCountry(string iso3 = null, string label = null) { throw null; }
        public static Azure.Maps.Rendering.RenderCopyright RenderCopyright(string formatVersion = null, System.Collections.Generic.IEnumerable<string> generalCopyrights = null, System.Collections.Generic.IEnumerable<Azure.Maps.Rendering.RegionalCopyright> regionalCopyrights = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapTileFormat : System.IEquatable<Azure.Maps.Rendering.MapTileFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapTileFormat(string value) { throw null; }
        public static Azure.Maps.Rendering.MapTileFormat Pbf { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileFormat Png { get { throw null; } }
        public bool Equals(Azure.Maps.Rendering.MapTileFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Rendering.MapTileFormat left, Azure.Maps.Rendering.MapTileFormat right) { throw null; }
        public static implicit operator Azure.Maps.Rendering.MapTileFormat (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Rendering.MapTileFormat left, Azure.Maps.Rendering.MapTileFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MapTileIndex
    {
        public MapTileIndex(int x, int y, int z) { }
        public int X { get { throw null; } }
        public int Y { get { throw null; } }
        public int Z { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapTileLayer : System.IEquatable<Azure.Maps.Rendering.MapTileLayer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapTileLayer(string value) { throw null; }
        public static Azure.Maps.Rendering.MapTileLayer Basic { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileLayer Hybrid { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileLayer Labels { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileLayer Terra { get { throw null; } }
        public bool Equals(Azure.Maps.Rendering.MapTileLayer other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Rendering.MapTileLayer left, Azure.Maps.Rendering.MapTileLayer right) { throw null; }
        public static implicit operator Azure.Maps.Rendering.MapTileLayer (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Rendering.MapTileLayer left, Azure.Maps.Rendering.MapTileLayer right) { throw null; }
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
    public readonly partial struct MapTileStyle : System.IEquatable<Azure.Maps.Rendering.MapTileStyle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapTileStyle(string value) { throw null; }
        public static Azure.Maps.Rendering.MapTileStyle Dark { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileStyle Main { get { throw null; } }
        public static Azure.Maps.Rendering.MapTileStyle ShadedRelief { get { throw null; } }
        public bool Equals(Azure.Maps.Rendering.MapTileStyle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Rendering.MapTileStyle left, Azure.Maps.Rendering.MapTileStyle right) { throw null; }
        public static implicit operator Azure.Maps.Rendering.MapTileStyle (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Rendering.MapTileStyle left, Azure.Maps.Rendering.MapTileStyle right) { throw null; }
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
}
