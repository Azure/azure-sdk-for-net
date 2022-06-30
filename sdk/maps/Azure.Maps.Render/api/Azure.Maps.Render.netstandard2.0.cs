namespace Azure.Maps.Render
{
    public partial class MapsRenderClient
    {
        protected MapsRenderClient() { }
        public MapsRenderClient(Azure.AzureKeyCredential credential, System.Uri endpoint) { }
        public MapsRenderClient(Azure.AzureKeyCredential credential, System.Uri endpoint = null, Azure.Maps.Render.MapsRenderClientOptions options = null) { }
        public MapsRenderClient(Azure.Core.TokenCredential credential, System.Uri endpoint, string clientId) { }
        public MapsRenderClient(Azure.Core.TokenCredential credential, System.Uri endpoint = null, string clientId = null, Azure.Maps.Render.MapsRenderClientOptions options = null) { }
        public virtual Azure.Response<Azure.Maps.Render.Models.CopyrightCaption> GetCopyrightCaption(Azure.Maps.Render.Models.ResponseFormat? format = default(Azure.Maps.Render.Models.ResponseFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Render.Models.CopyrightCaption>> GetCopyrightCaptionAsync(Azure.Maps.Render.Models.ResponseFormat? format = default(Azure.Maps.Render.Models.ResponseFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Render.Models.RenderCopyrights> GetCopyrightForTile(Azure.Maps.Render.Models.TileIndex tileIndex, Azure.Maps.Render.Models.ResponseFormat? format = default(Azure.Maps.Render.Models.ResponseFormat?), bool includeText = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Render.Models.RenderCopyrights>> GetCopyrightForTileAsync(Azure.Maps.Render.Models.TileIndex tileIndex, Azure.Maps.Render.Models.ResponseFormat? format = default(Azure.Maps.Render.Models.ResponseFormat?), bool includeText = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Render.Models.RenderCopyrights> GetCopyrightForWorld(Azure.Maps.Render.Models.ResponseFormat? format = default(Azure.Maps.Render.Models.ResponseFormat?), bool includeText = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Render.Models.RenderCopyrights>> GetCopyrightForWorldAsync(Azure.Maps.Render.Models.ResponseFormat? format = default(Azure.Maps.Render.Models.ResponseFormat?), bool includeText = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Render.Models.RenderCopyrights> GetCopyrightFromBoundingBox(Azure.Core.GeoJson.GeoBoundingBox geoBoundingBox, Azure.Maps.Render.Models.ResponseFormat? format = default(Azure.Maps.Render.Models.ResponseFormat?), bool includeText = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Render.Models.RenderCopyrights>> GetCopyrightFromBoundingBoxAsync(Azure.Core.GeoJson.GeoBoundingBox geoBoundingBox, Azure.Maps.Render.Models.ResponseFormat? format = default(Azure.Maps.Render.Models.ResponseFormat?), bool includeText = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetMapImageryTile(Azure.Maps.Render.Models.TileIndex tileIndex, Azure.Maps.Render.Models.MapImageryStyle? style = default(Azure.Maps.Render.Models.MapImageryStyle?), Azure.Maps.Render.Models.RasterTileFormat? format = default(Azure.Maps.Render.Models.RasterTileFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetMapImageryTileAsync(Azure.Maps.Render.Models.TileIndex tileIndex, Azure.Maps.Render.Models.MapImageryStyle? style = default(Azure.Maps.Render.Models.MapImageryStyle?), Azure.Maps.Render.Models.RasterTileFormat? format = default(Azure.Maps.Render.Models.RasterTileFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetMapStateTile(string statesetId, Azure.Maps.Render.Models.TileIndex tileIndex, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetMapStateTileAsync(string statesetId, Azure.Maps.Render.Models.TileIndex tileIndex, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetMapStaticImage(Azure.Maps.Render.Models.RenderStaticImageOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetMapStaticImageAsync(Azure.Maps.Render.Models.RenderStaticImageOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetMapTile(Azure.Maps.Render.Models.RenderTileOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetMapTileAsync(Azure.Maps.Render.Models.RenderTileOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MapsRenderClientOptions : Azure.Core.ClientOptions
    {
        public MapsRenderClientOptions(Azure.Maps.Render.MapsRenderClientOptions.ServiceVersion version = Azure.Maps.Render.MapsRenderClientOptions.ServiceVersion.V1_0) { }
        public enum ServiceVersion
        {
            V1_0 = 1,
        }
    }
}
namespace Azure.Maps.Render.Models
{
    public partial class CopyrightCaption
    {
        internal CopyrightCaption() { }
        public string CopyrightsCaption { get { throw null; } }
        public string FormatVersion { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LocalizedMapView : System.IEquatable<Azure.Maps.Render.Models.LocalizedMapView>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LocalizedMapView(string value) { throw null; }
        public static Azure.Maps.Render.Models.LocalizedMapView AE { get { throw null; } }
        public static Azure.Maps.Render.Models.LocalizedMapView AR { get { throw null; } }
        public static Azure.Maps.Render.Models.LocalizedMapView Auto { get { throw null; } }
        public static Azure.Maps.Render.Models.LocalizedMapView BH { get { throw null; } }
        public static Azure.Maps.Render.Models.LocalizedMapView IN { get { throw null; } }
        public static Azure.Maps.Render.Models.LocalizedMapView IQ { get { throw null; } }
        public static Azure.Maps.Render.Models.LocalizedMapView JO { get { throw null; } }
        public static Azure.Maps.Render.Models.LocalizedMapView KW { get { throw null; } }
        public static Azure.Maps.Render.Models.LocalizedMapView LB { get { throw null; } }
        public static Azure.Maps.Render.Models.LocalizedMapView MA { get { throw null; } }
        public static Azure.Maps.Render.Models.LocalizedMapView OM { get { throw null; } }
        public static Azure.Maps.Render.Models.LocalizedMapView PK { get { throw null; } }
        public static Azure.Maps.Render.Models.LocalizedMapView PS { get { throw null; } }
        public static Azure.Maps.Render.Models.LocalizedMapView QA { get { throw null; } }
        public static Azure.Maps.Render.Models.LocalizedMapView SA { get { throw null; } }
        public static Azure.Maps.Render.Models.LocalizedMapView SY { get { throw null; } }
        public static Azure.Maps.Render.Models.LocalizedMapView Unified { get { throw null; } }
        public static Azure.Maps.Render.Models.LocalizedMapView YE { get { throw null; } }
        public bool Equals(Azure.Maps.Render.Models.LocalizedMapView other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Render.Models.LocalizedMapView left, Azure.Maps.Render.Models.LocalizedMapView right) { throw null; }
        public static implicit operator Azure.Maps.Render.Models.LocalizedMapView (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Render.Models.LocalizedMapView left, Azure.Maps.Render.Models.LocalizedMapView right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapImageryStyle : System.IEquatable<Azure.Maps.Render.Models.MapImageryStyle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapImageryStyle(string value) { throw null; }
        public static Azure.Maps.Render.Models.MapImageryStyle Satellite { get { throw null; } }
        public bool Equals(Azure.Maps.Render.Models.MapImageryStyle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Render.Models.MapImageryStyle left, Azure.Maps.Render.Models.MapImageryStyle right) { throw null; }
        public static implicit operator Azure.Maps.Render.Models.MapImageryStyle (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Render.Models.MapImageryStyle left, Azure.Maps.Render.Models.MapImageryStyle right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapImageStyle : System.IEquatable<Azure.Maps.Render.Models.MapImageStyle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapImageStyle(string value) { throw null; }
        public static Azure.Maps.Render.Models.MapImageStyle Dark { get { throw null; } }
        public static Azure.Maps.Render.Models.MapImageStyle Main { get { throw null; } }
        public bool Equals(Azure.Maps.Render.Models.MapImageStyle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Render.Models.MapImageStyle left, Azure.Maps.Render.Models.MapImageStyle right) { throw null; }
        public static implicit operator Azure.Maps.Render.Models.MapImageStyle (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Render.Models.MapImageStyle left, Azure.Maps.Render.Models.MapImageStyle right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class MapsRenderModelFactory
    {
        public static Azure.Maps.Render.Models.CopyrightCaption CopyrightCaption(string formatVersion = null, string copyrightsCaption = null) { throw null; }
        public static Azure.Maps.Render.Models.RegionCopyrights RegionCopyrights(System.Collections.Generic.IEnumerable<string> copyrights = null, Azure.Maps.Render.Models.RegionCopyrightsCountry country = null) { throw null; }
        public static Azure.Maps.Render.Models.RegionCopyrightsCountry RegionCopyrightsCountry(string isO3 = null, string label = null) { throw null; }
        public static Azure.Maps.Render.Models.RenderCopyrights RenderCopyrights(string formatVersion = null, System.Collections.Generic.IEnumerable<string> generalCopyrights = null, System.Collections.Generic.IEnumerable<Azure.Maps.Render.Models.RegionCopyrights> regions = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapTileLayer : System.IEquatable<Azure.Maps.Render.Models.MapTileLayer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapTileLayer(string value) { throw null; }
        public static Azure.Maps.Render.Models.MapTileLayer Basic { get { throw null; } }
        public static Azure.Maps.Render.Models.MapTileLayer Hybrid { get { throw null; } }
        public static Azure.Maps.Render.Models.MapTileLayer Labels { get { throw null; } }
        public static Azure.Maps.Render.Models.MapTileLayer Terra { get { throw null; } }
        public bool Equals(Azure.Maps.Render.Models.MapTileLayer other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Render.Models.MapTileLayer left, Azure.Maps.Render.Models.MapTileLayer right) { throw null; }
        public static implicit operator Azure.Maps.Render.Models.MapTileLayer (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Render.Models.MapTileLayer left, Azure.Maps.Render.Models.MapTileLayer right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapTileSize : System.IEquatable<Azure.Maps.Render.Models.MapTileSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapTileSize(string value) { throw null; }
        public static Azure.Maps.Render.Models.MapTileSize Size256 { get { throw null; } }
        public static Azure.Maps.Render.Models.MapTileSize Size512 { get { throw null; } }
        public bool Equals(Azure.Maps.Render.Models.MapTileSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Render.Models.MapTileSize left, Azure.Maps.Render.Models.MapTileSize right) { throw null; }
        public static implicit operator Azure.Maps.Render.Models.MapTileSize (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Render.Models.MapTileSize left, Azure.Maps.Render.Models.MapTileSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapTileStyle : System.IEquatable<Azure.Maps.Render.Models.MapTileStyle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapTileStyle(string value) { throw null; }
        public static Azure.Maps.Render.Models.MapTileStyle Dark { get { throw null; } }
        public static Azure.Maps.Render.Models.MapTileStyle Main { get { throw null; } }
        public static Azure.Maps.Render.Models.MapTileStyle ShadedRelief { get { throw null; } }
        public bool Equals(Azure.Maps.Render.Models.MapTileStyle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Render.Models.MapTileStyle left, Azure.Maps.Render.Models.MapTileStyle right) { throw null; }
        public static implicit operator Azure.Maps.Render.Models.MapTileStyle (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Render.Models.MapTileStyle left, Azure.Maps.Render.Models.MapTileStyle right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RasterTileFormat : System.IEquatable<Azure.Maps.Render.Models.RasterTileFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RasterTileFormat(string value) { throw null; }
        public static Azure.Maps.Render.Models.RasterTileFormat Png { get { throw null; } }
        public bool Equals(Azure.Maps.Render.Models.RasterTileFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Render.Models.RasterTileFormat left, Azure.Maps.Render.Models.RasterTileFormat right) { throw null; }
        public static implicit operator Azure.Maps.Render.Models.RasterTileFormat (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Render.Models.RasterTileFormat left, Azure.Maps.Render.Models.RasterTileFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegionCopyrights
    {
        internal RegionCopyrights() { }
        public System.Collections.Generic.IReadOnlyList<string> Copyrights { get { throw null; } }
        public Azure.Maps.Render.Models.RegionCopyrightsCountry Country { get { throw null; } }
    }
    public partial class RegionCopyrightsCountry
    {
        internal RegionCopyrightsCountry() { }
        public string ISO3 { get { throw null; } }
        public string Label { get { throw null; } }
    }
    public partial class RenderCopyrights
    {
        internal RenderCopyrights() { }
        public string FormatVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> GeneralCopyrights { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Render.Models.RegionCopyrights> Regions { get { throw null; } }
    }
    public partial class RenderStaticImageOptions
    {
        public RenderStaticImageOptions() { }
        public System.Collections.Generic.IEnumerable<double> BoundingBox { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<double> Center { get { throw null; } set { } }
        public Azure.Maps.Render.Models.RasterTileFormat? Format { get { throw null; } set { } }
        public int? Height { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public Azure.Maps.Render.Models.StaticMapLayer? Layer { get { throw null; } set { } }
        public Azure.Maps.Render.Models.LocalizedMapView? LocalizedMapView { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<string> Path { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<string> Pins { get { throw null; } set { } }
        public Azure.Maps.Render.Models.MapImageStyle? Style { get { throw null; } set { } }
        public int? Width { get { throw null; } set { } }
        public int? Zoom { get { throw null; } set { } }
    }
    public partial class RenderTileOptions
    {
        public RenderTileOptions() { }
        public Azure.Maps.Render.Models.TileFormat Format { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public Azure.Maps.Render.Models.MapTileLayer Layer { get { throw null; } set { } }
        public Azure.Maps.Render.Models.LocalizedMapView? LocalizedMapView { get { throw null; } set { } }
        public Azure.Maps.Render.Models.MapTileStyle Style { get { throw null; } set { } }
        public Azure.Maps.Render.Models.TileIndex TileIndex { get { throw null; } set { } }
        public Azure.Maps.Render.Models.MapTileSize? TileSize { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponseFormat : System.IEquatable<Azure.Maps.Render.Models.ResponseFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponseFormat(string value) { throw null; }
        public static Azure.Maps.Render.Models.ResponseFormat Json { get { throw null; } }
        public static Azure.Maps.Render.Models.ResponseFormat Xml { get { throw null; } }
        public bool Equals(Azure.Maps.Render.Models.ResponseFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Render.Models.ResponseFormat left, Azure.Maps.Render.Models.ResponseFormat right) { throw null; }
        public static implicit operator Azure.Maps.Render.Models.ResponseFormat (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Render.Models.ResponseFormat left, Azure.Maps.Render.Models.ResponseFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StaticMapLayer : System.IEquatable<Azure.Maps.Render.Models.StaticMapLayer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StaticMapLayer(string value) { throw null; }
        public static Azure.Maps.Render.Models.StaticMapLayer Basic { get { throw null; } }
        public static Azure.Maps.Render.Models.StaticMapLayer Hybrid { get { throw null; } }
        public static Azure.Maps.Render.Models.StaticMapLayer Labels { get { throw null; } }
        public bool Equals(Azure.Maps.Render.Models.StaticMapLayer other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Render.Models.StaticMapLayer left, Azure.Maps.Render.Models.StaticMapLayer right) { throw null; }
        public static implicit operator Azure.Maps.Render.Models.StaticMapLayer (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Render.Models.StaticMapLayer left, Azure.Maps.Render.Models.StaticMapLayer right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TileFormat : System.IEquatable<Azure.Maps.Render.Models.TileFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TileFormat(string value) { throw null; }
        public static Azure.Maps.Render.Models.TileFormat Pbf { get { throw null; } }
        public static Azure.Maps.Render.Models.TileFormat Png { get { throw null; } }
        public bool Equals(Azure.Maps.Render.Models.TileFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Render.Models.TileFormat left, Azure.Maps.Render.Models.TileFormat right) { throw null; }
        public static implicit operator Azure.Maps.Render.Models.TileFormat (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Render.Models.TileFormat left, Azure.Maps.Render.Models.TileFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TileIndex
    {
        public TileIndex(int z, int x, int y) { }
        public int X { get { throw null; } }
        public int Y { get { throw null; } }
        public int Z { get { throw null; } }
    }
}
