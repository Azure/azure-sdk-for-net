namespace Azure.Maps
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LocalizedMapView : System.IEquatable<Azure.Maps.LocalizedMapView>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LocalizedMapView(string value) { throw null; }
        public static Azure.Maps.LocalizedMapView Argentina { get { throw null; } }
        public static Azure.Maps.LocalizedMapView Auto { get { throw null; } }
        public static Azure.Maps.LocalizedMapView Bahrain { get { throw null; } }
        public static Azure.Maps.LocalizedMapView India { get { throw null; } }
        public static Azure.Maps.LocalizedMapView Iraq { get { throw null; } }
        public static Azure.Maps.LocalizedMapView Jordan { get { throw null; } }
        public static Azure.Maps.LocalizedMapView Kuwait { get { throw null; } }
        public static Azure.Maps.LocalizedMapView Lebanon { get { throw null; } }
        public static Azure.Maps.LocalizedMapView Morocco { get { throw null; } }
        public static Azure.Maps.LocalizedMapView Oman { get { throw null; } }
        public static Azure.Maps.LocalizedMapView Pakistan { get { throw null; } }
        public static Azure.Maps.LocalizedMapView PalestinianAuthority { get { throw null; } }
        public static Azure.Maps.LocalizedMapView Qatar { get { throw null; } }
        public static Azure.Maps.LocalizedMapView SaudiArabia { get { throw null; } }
        public static Azure.Maps.LocalizedMapView Syria { get { throw null; } }
        public static Azure.Maps.LocalizedMapView Unified { get { throw null; } }
        public static Azure.Maps.LocalizedMapView UnitedArabEmirates { get { throw null; } }
        public static Azure.Maps.LocalizedMapView Yemen { get { throw null; } }
        public bool Equals(Azure.Maps.LocalizedMapView other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.LocalizedMapView left, Azure.Maps.LocalizedMapView right) { throw null; }
        public static implicit operator Azure.Maps.LocalizedMapView (string value) { throw null; }
        public static bool operator !=(Azure.Maps.LocalizedMapView left, Azure.Maps.LocalizedMapView right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class TileMath
    {
        public static void BestMapView(Azure.Core.GeoJson.GeoBoundingBox boundingBox, double mapWidth, double mapHeight, int padding, int tileSize, out double centerLat, out double centerLon, out double zoom) { throw null; }
        public static string[] GetQuadkeysInBoundingBox(Azure.Core.GeoJson.GeoBoundingBox boundingBox, int zoom, int tileSize) { throw null; }
        public static string[] GetQuadkeysInView(Azure.Core.GeoJson.GeoPosition position, int zoom, int width, int height, int tileSize) { throw null; }
        public static Azure.Core.GeoJson.GeoPosition GlobalPixelToPosition(Azure.Core.GeoJson.GeoPosition pixel, double zoom, int tileSize) { throw null; }
        public static void GlobalPixelToTileXY(Azure.Core.GeoJson.GeoPosition pixel, int tileSize, out int tileX, out int tileY) { throw null; }
        public static double GroundResolution(double latitude, double zoom, int tileSize) { throw null; }
        public static double MapScale(double latitude, double zoom, int screenDpi, int tileSize) { throw null; }
        public static double MapSize(double zoom, int tileSize) { throw null; }
        public static Azure.Core.GeoJson.GeoPosition PositionToGlobalPixel(Azure.Core.GeoJson.GeoPosition position, int zoom, int tileSize) { throw null; }
        public static void PositionToTileXY(Azure.Core.GeoJson.GeoPosition position, int zoom, int tileSize, out int tileX, out int tileY) { throw null; }
        public static void QuadKeyToTileXY(string quadKey, out int tileX, out int tileY, out int zoom) { throw null; }
        public static Azure.Core.GeoJson.GeoPosition ScaleGlobalPixel(Azure.Core.GeoJson.GeoPosition pixel, double oldZoom, double newZoom) { throw null; }
        public static Azure.Core.GeoJson.GeoBoundingBox TileXYToBoundingBox(int tileX, int tileY, double zoom, int tileSize) { throw null; }
        public static Azure.Core.GeoJson.GeoPosition TileXYToGlobalPixel(int tileX, int tileY, int tileSize) { throw null; }
        public static string TileXYToQuadKey(int tileX, int tileY, int zoom) { throw null; }
    }
}
