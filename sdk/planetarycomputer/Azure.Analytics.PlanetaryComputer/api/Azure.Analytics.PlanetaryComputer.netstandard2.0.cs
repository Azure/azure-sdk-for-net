namespace Azure.Analytics.PlanetaryComputer
{
    public partial class AzureAnalyticsPlanetaryComputerContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAnalyticsPlanetaryComputerContext() { }
        public static Azure.Analytics.PlanetaryComputer.AzureAnalyticsPlanetaryComputerContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BandStatistics : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.BandStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.BandStatistics>
    {
        internal BandStatistics() { }
        public float Count { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<float>> Histogram { get { throw null; } }
        public float Majority { get { throw null; } }
        public float MaskedPixels { get { throw null; } }
        public float Maximum { get { throw null; } }
        public float Mean { get { throw null; } }
        public float Median { get { throw null; } }
        public float Minimum { get { throw null; } }
        public float Minority { get { throw null; } }
        public float Percentile2 { get { throw null; } }
        public float Percentile98 { get { throw null; } }
        public float Std { get { throw null; } }
        public float Sum { get { throw null; } }
        public float Unique { get { throw null; } }
        public float ValidPercent { get { throw null; } }
        public float ValidPixels { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.BandStatistics JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.BandStatistics PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.BandStatistics System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.BandStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.BandStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.BandStatistics System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.BandStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.BandStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.BandStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ColorMapNames : System.IEquatable<Azure.Analytics.PlanetaryComputer.ColorMapNames>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ColorMapNames(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Accent { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames AccentR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Afmhot { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames AfmhotR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Ai4gLulc { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames AlosFnf { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames AlosPalsarMask { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Autumn { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames AutumnR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Binary { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames BinaryR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Blues { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames BluesR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Bone { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames BoneR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Brbg { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames BrbgR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Brg { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames BrgR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Bugn { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames BugnR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Bupu { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames BupuR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Bwr { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames BwrR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames CCap { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Cfastie { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames ChesapeakeLc13 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames ChesapeakeLc7 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames ChesapeakeLu { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames ChlorisBiomass { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Cividis { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames CividisR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Cmrmap { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames CmrmapR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Cool { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames CoolR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Coolwarm { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames CoolwarmR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Copper { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames CopperR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Cubehelix { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames CubehelixR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Dark2 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Dark2R { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames DrcogLulc { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames EsaCciLc { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames EsaWorldcover { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Flag { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames FlagR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames GapLulc { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames GistEarth { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames GistEarthR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames GistGray { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames GistGrayR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames GistHeat { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames GistHeatR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames GistNcar { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames GistNcarR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames GistRainbow { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames GistRainbowR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames GistStern { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames GistSternR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames GistYarg { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames GistYargR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Gnbu { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames GnbuR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Gnuplot { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Gnuplot2 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Gnuplot2R { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames GnuplotR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Gray { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames GrayR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Greens { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames GreensR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Greys { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames GreysR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Hot { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames HotR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Hsv { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames HsvR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Inferno { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames InfernoR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames IoBii { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames IoLulc { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames IoLulc9Class { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Jet { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames JetR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames JrcChange { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames JrcExtent { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames JrcOccurrence { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames JrcRecurrence { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames JrcSeasonality { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames JrcTransitions { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames LidarClassification { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames LidarHag { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames LidarHagAlternative { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames LidarIntensity { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames LidarReturns { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Magma { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames MagmaR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Modis10A1 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Modis10A2 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Modis13A1Q1 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Modis14A1A2 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Modis15A2HA3H { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Modis16A3GFET { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Modis16A3GFPET { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Modis17A2HA2HGF { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Modis17A3HGF { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Modis64A1 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames MtbsSeverity { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames NipySpectral { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames NipySpectralR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames NrcanLulc { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Ocean { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames OceanR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Oranges { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames OrangesR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Orrd { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames OrrdR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Paired { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames PairedR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Pastel1 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Pastel1R { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Pastel2 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Pastel2R { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Pink { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames PinkR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Piyg { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames PiygR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Plasma { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames PlasmaR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Prgn { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames PrgnR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Prism { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames PrismR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Pubu { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Pubugn { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames PubugnR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames PubuR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Puor { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames PuorR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Purd { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames PurdR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Purples { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames PurplesR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Qpe { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Rainbow { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames RainbowR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Rdbu { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames RdbuR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Rdgy { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames RdgyR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Rdpu { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames RdpuR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Rdylbu { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames RdylbuR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Rdylgn { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames RdylgnR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Reds { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames RedsR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Rplumbo { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Schwarzwald { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Seismic { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames SeismicR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Set1 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Set1R { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Set2 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Set2R { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Set3 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Set3R { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Spectral { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames SpectralR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Spring { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames SpringR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Summer { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames SummerR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Tab10 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Tab10R { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Tab20 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Tab20b { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Tab20bR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Tab20c { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Tab20cR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Tab20R { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Terrain { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames TerrainR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Twilight { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames TwilightR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames TwilightShifted { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames TwilightShiftedR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames UsdaCdl { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames UsdaCdlCorn { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames UsdaCdlCotton { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames UsdaCdlSoybeans { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames UsdaCdlWheat { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames UsgsLcmap { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Viirs10a1 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Viirs13a1 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Viirs14a1 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Viirs15a2H { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Viridis { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames ViridisR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Winter { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames WinterR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Wistia { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames WistiaR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Ylgn { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Ylgnbu { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames YlgnbuR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames YlgnR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Ylorbr { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames YlorbrR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Ylorrd { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames YlorrdR { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.ColorMapNames other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.ColorMapNames left, Azure.Analytics.PlanetaryComputer.ColorMapNames right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.ColorMapNames (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.ColorMapNames? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.ColorMapNames left, Azure.Analytics.PlanetaryComputer.ColorMapNames right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataClient
    {
        protected DataClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.ImageResponse> CreateStaticImage(string collectionId, Azure.Analytics.PlanetaryComputer.ImageParameters body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateStaticImage(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.ImageResponse>> CreateStaticImageAsync(string collectionId, Azure.Analytics.PlanetaryComputer.ImageParameters body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateStaticImageAsync(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<System.BinaryData> CropGeoJson(string collectionId, string itemId, string format, Azure.Analytics.PlanetaryComputer.GeoJsonFeature body, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string colorFormula = null, string coordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CropGeoJson(string collectionId, string itemId, string format, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), string algorithm = null, string algorithmParams = null, string colorFormula = null, string coordinateReferenceSystem = null, string resampling = null, int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, string colorMapName = null, string colorMap = null, bool? returnMask = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> CropGeoJsonAsync(string collectionId, string itemId, string format, Azure.Analytics.PlanetaryComputer.GeoJsonFeature body, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string colorFormula = null, string coordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CropGeoJsonAsync(string collectionId, string itemId, string format, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), string algorithm = null, string algorithmParams = null, string colorFormula = null, string coordinateReferenceSystem = null, string resampling = null, int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, string colorMapName = null, string colorMap = null, bool? returnMask = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<System.BinaryData> CropGeoJsonWithDimensions(string collectionId, string itemId, int width, int height, string format, Azure.Analytics.PlanetaryComputer.GeoJsonFeature body, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string colorFormula = null, string coordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CropGeoJsonWithDimensions(string collectionId, string itemId, int width, int height, string format, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), string algorithm = null, string algorithmParams = null, string colorFormula = null, string coordinateReferenceSystem = null, string resampling = null, int? maxSize = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, string colorMapName = null, string colorMap = null, bool? returnMask = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> CropGeoJsonWithDimensionsAsync(string collectionId, string itemId, int width, int height, string format, Azure.Analytics.PlanetaryComputer.GeoJsonFeature body, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string colorFormula = null, string coordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CropGeoJsonWithDimensionsAsync(string collectionId, string itemId, int width, int height, string format, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), string algorithm = null, string algorithmParams = null, string colorFormula = null, string coordinateReferenceSystem = null, string resampling = null, int? maxSize = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, string colorMapName = null, string colorMap = null, bool? returnMask = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.BandStatistics>>> GetAssetStatistics(string collectionId, string itemId, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), bool? categorical = default(bool?), System.Collections.Generic.IEnumerable<string> categoriesPixels = null, System.Collections.Generic.IEnumerable<int> percentiles = null, string histogramBins = null, string histogramRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetAssetStatistics(string collectionId, string itemId, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string resampling, int? maxSize, bool? categorical, System.Collections.Generic.IEnumerable<string> categoriesPixels, System.Collections.Generic.IEnumerable<int> percentiles, string histogramBins, string histogramRange, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.BandStatistics>>>> GetAssetStatisticsAsync(string collectionId, string itemId, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), bool? categorical = default(bool?), System.Collections.Generic.IEnumerable<string> categoriesPixels = null, System.Collections.Generic.IEnumerable<int> percentiles = null, string histogramBins = null, string histogramRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAssetStatisticsAsync(string collectionId, string itemId, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string resampling, int? maxSize, bool? categorical, System.Collections.Generic.IEnumerable<string> categoriesPixels, System.Collections.Generic.IEnumerable<int> percentiles, string histogramBins, string histogramRange, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetAvailableAssets(string collectionId, string itemId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<string>> GetAvailableAssets(string collectionId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAvailableAssetsAsync(string collectionId, string itemId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<string>>> GetAvailableAssetsAsync(string collectionId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetBounds(string collectionId, string itemId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacItemBounds> GetBounds(string collectionId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetBoundsAsync(string collectionId, string itemId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacItemBounds>> GetBoundsAsync(string collectionId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetClassMapLegend(string classmapName, int? trimStart, int? trimEnd, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData>> GetClassMapLegend(string classmapName, int? trimStart = default(int?), int? trimEnd = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetClassMapLegendAsync(string classmapName, int? trimStart, int? trimEnd, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData>>> GetClassMapLegendAsync(string classmapName, int? trimStart = default(int?), int? trimEnd = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson> GetGeoJsonStatistics(string collectionId, string itemId, Azure.Analytics.PlanetaryComputer.GeoJsonFeature body, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), string coordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), bool? categorical = default(bool?), System.Collections.Generic.IEnumerable<string> categoriesPixels = null, System.Collections.Generic.IEnumerable<int> percentiles = null, string histogramBins = null, string histogramRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetGeoJsonStatistics(string collectionId, string itemId, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), string coordinateReferenceSystem = null, string resampling = null, int? maxSize = default(int?), bool? categorical = default(bool?), System.Collections.Generic.IEnumerable<string> categoriesPixels = null, System.Collections.Generic.IEnumerable<int> percentiles = null, string histogramBins = null, string histogramRange = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson>> GetGeoJsonStatisticsAsync(string collectionId, string itemId, Azure.Analytics.PlanetaryComputer.GeoJsonFeature body, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), string coordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), bool? categorical = default(bool?), System.Collections.Generic.IEnumerable<string> categoriesPixels = null, System.Collections.Generic.IEnumerable<int> percentiles = null, string histogramBins = null, string histogramRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGeoJsonStatisticsAsync(string collectionId, string itemId, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), string coordinateReferenceSystem = null, string resampling = null, int? maxSize = default(int?), bool? categorical = default(bool?), System.Collections.Generic.IEnumerable<string> categoriesPixels = null, System.Collections.Generic.IEnumerable<int> percentiles = null, string histogramBins = null, string histogramRange = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetInfoGeoJson(string collectionId, string itemId, System.Collections.Generic.IEnumerable<string> assets, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature> GetInfoGeoJson(string collectionId, string itemId, System.Collections.Generic.IEnumerable<string> assets = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetInfoGeoJsonAsync(string collectionId, string itemId, System.Collections.Generic.IEnumerable<string> assets, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature>> GetInfoGeoJsonAsync(string collectionId, string itemId, System.Collections.Generic.IEnumerable<string> assets = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetIntervalLegend(string classmapName, int? trimStart, int? trimEnd, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IList<System.BinaryData>>> GetIntervalLegend(string classmapName, int? trimStart = default(int?), int? trimEnd = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetIntervalLegendAsync(string classmapName, int? trimStart, int? trimEnd, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IList<System.BinaryData>>>> GetIntervalLegendAsync(string classmapName, int? trimStart = default(int?), int? trimEnd = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetItemAssetDetails(string collectionId, string itemId, System.Collections.Generic.IEnumerable<string> assets, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, Azure.Analytics.PlanetaryComputer.TilerInfo>> GetItemAssetDetails(string collectionId, string itemId, System.Collections.Generic.IEnumerable<string> assets = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetItemAssetDetailsAsync(string collectionId, string itemId, System.Collections.Generic.IEnumerable<string> assets, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, Azure.Analytics.PlanetaryComputer.TilerInfo>>> GetItemAssetDetailsAsync(string collectionId, string itemId, System.Collections.Generic.IEnumerable<string> assets = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetLegend(string colorMapName, float? height, float? width, int? trimStart, int? trimEnd, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetLegend(string colorMapName, float? height = default(float?), float? width = default(float?), int? trimStart = default(int?), int? trimEnd = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLegendAsync(string colorMapName, float? height, float? width, int? trimStart, int? trimEnd, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetLegendAsync(string colorMapName, float? height = default(float?), float? width = default(float?), int? trimStart = default(int?), int? trimEnd = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetMosaicsAssetsForPoint(string searchId, float longitude, float latitude, int? scanLimit, int? itemsLimit, int? timeLimit, bool? exitWhenFull, bool? skipCovered, string coordinateReferenceSystem, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.PlanetaryComputer.StacItemPointAsset>> GetMosaicsAssetsForPoint(string searchId, float longitude, float latitude, int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string coordinateReferenceSystem = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMosaicsAssetsForPointAsync(string searchId, float longitude, float latitude, int? scanLimit, int? itemsLimit, int? timeLimit, bool? exitWhenFull, bool? skipCovered, string coordinateReferenceSystem, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.PlanetaryComputer.StacItemPointAsset>>> GetMosaicsAssetsForPointAsync(string searchId, float longitude, float latitude, int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string coordinateReferenceSystem = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetMosaicsAssetsForTile(string searchId, string tileMatrixSetId, float z, float x, float y, string collectionId, int? scanLimit, int? itemsLimit, int? timeLimit, bool? exitWhenFull, bool? skipCovered, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<System.BinaryData>> GetMosaicsAssetsForTile(string searchId, string tileMatrixSetId, float z, float x, float y, string collectionId, int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMosaicsAssetsForTileAsync(string searchId, string tileMatrixSetId, float z, float x, float y, string collectionId, int? scanLimit, int? itemsLimit, int? timeLimit, bool? exitWhenFull, bool? skipCovered, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<System.BinaryData>>> GetMosaicsAssetsForTileAsync(string searchId, string tileMatrixSetId, float z, float x, float y, string collectionId, int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetMosaicsSearchInfo(string searchId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration> GetMosaicsSearchInfo(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMosaicsSearchInfoAsync(string searchId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration>> GetMosaicsSearchInfoAsync(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetMosaicsTile(string searchId, string tileMatrixSetId, float z, float x, float y, float scale, string format, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string buffer = null, string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetMosaicsTile(string searchId, string tileMatrixSetId, float z, float x, float y, float scale, string format, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, int? scanLimit, int? itemsLimit, int? timeLimit, bool? exitWhenFull, bool? skipCovered, string algorithm, string algorithmParams, string buffer, string colorFormula, string collection, string resampling, string pixelSelection, System.Collections.Generic.IEnumerable<string> rescale, string colorMapName, string colorMap, bool? returnMask, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetMosaicsTileAsync(string searchId, string tileMatrixSetId, float z, float x, float y, float scale, string format, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string buffer = null, string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMosaicsTileAsync(string searchId, string tileMatrixSetId, float z, float x, float y, float scale, string format, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, int? scanLimit, int? itemsLimit, int? timeLimit, bool? exitWhenFull, bool? skipCovered, string algorithm, string algorithmParams, string buffer, string colorFormula, string collection, string resampling, string pixelSelection, System.Collections.Generic.IEnumerable<string> rescale, string colorMapName, string colorMap, bool? returnMask, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TileJsonMetadata> GetMosaicsTileJson(string searchId, string tileMatrixSetId, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, int? minZoom = default(int?), int? maxZoom = default(int?), Azure.Analytics.PlanetaryComputer.TilerImageFormat? tileFormat = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? tileScale = default(int?), string buffer = null, string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetMosaicsTileJson(string searchId, string tileMatrixSetId, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, int? scanLimit, int? itemsLimit, int? timeLimit, bool? exitWhenFull, bool? skipCovered, string algorithm, string algorithmParams, int? minZoom, int? maxZoom, string tileFormat, int? tileScale, string buffer, string colorFormula, string collection, string resampling, string pixelSelection, System.Collections.Generic.IEnumerable<string> rescale, string colorMapName, string colorMap, bool? returnMask, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TileJsonMetadata>> GetMosaicsTileJsonAsync(string searchId, string tileMatrixSetId, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, int? minZoom = default(int?), int? maxZoom = default(int?), Azure.Analytics.PlanetaryComputer.TilerImageFormat? tileFormat = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? tileScale = default(int?), string buffer = null, string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMosaicsTileJsonAsync(string searchId, string tileMatrixSetId, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, int? scanLimit, int? itemsLimit, int? timeLimit, bool? exitWhenFull, bool? skipCovered, string algorithm, string algorithmParams, int? minZoom, int? maxZoom, string tileFormat, int? tileScale, string buffer, string colorFormula, string collection, string resampling, string pixelSelection, System.Collections.Generic.IEnumerable<string> rescale, string colorMapName, string colorMap, bool? returnMask, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetMosaicsWmtsCapabilities(string searchId, string tileMatrixSetId, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, Azure.Analytics.PlanetaryComputer.TilerImageFormat? tileFormat = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? tileScale = default(int?), int? minZoom = default(int?), int? maxZoom = default(int?), string buffer = null, string colorFormula = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetMosaicsWmtsCapabilities(string searchId, string tileMatrixSetId, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string algorithm, string algorithmParams, string tileFormat, int? tileScale, int? minZoom, int? maxZoom, string buffer, string colorFormula, string resampling, System.Collections.Generic.IEnumerable<string> rescale, string colorMapName, string colorMap, bool? returnMask, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetMosaicsWmtsCapabilitiesAsync(string searchId, string tileMatrixSetId, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, Azure.Analytics.PlanetaryComputer.TilerImageFormat? tileFormat = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? tileScale = default(int?), int? minZoom = default(int?), int? maxZoom = default(int?), string buffer = null, string colorFormula = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMosaicsWmtsCapabilitiesAsync(string searchId, string tileMatrixSetId, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string algorithm, string algorithmParams, string tileFormat, int? tileScale, int? minZoom, int? maxZoom, string buffer, string colorFormula, string resampling, System.Collections.Generic.IEnumerable<string> rescale, string colorMapName, string colorMap, bool? returnMask, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetPart(string collectionId, string itemId, float minx, float miny, float maxx, float maxy, string format, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string colorFormula = null, string dstCrs = null, string coordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPart(string collectionId, string itemId, float minx, float miny, float maxx, float maxy, string format, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string algorithm, string algorithmParams, string colorFormula, string dstCrs, string coordinateReferenceSystem, string resampling, int? maxSize, int? height, int? width, System.Collections.Generic.IEnumerable<string> rescale, string colorMapName, string colorMap, bool? returnMask, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetPartAsync(string collectionId, string itemId, float minx, float miny, float maxx, float maxy, string format, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string colorFormula = null, string dstCrs = null, string coordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPartAsync(string collectionId, string itemId, float minx, float miny, float maxx, float maxy, string format, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string algorithm, string algorithmParams, string colorFormula, string dstCrs, string coordinateReferenceSystem, string resampling, int? maxSize, int? height, int? width, System.Collections.Generic.IEnumerable<string> rescale, string colorMapName, string colorMap, bool? returnMask, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetPartWithDimensions(string collectionId, string itemId, float minx, float miny, float maxx, float maxy, int width, int height, string format, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string colorFormula = null, string dstCrs = null, string coordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPartWithDimensions(string collectionId, string itemId, float minx, float miny, float maxx, float maxy, int width, int height, string format, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string algorithm, string algorithmParams, string colorFormula, string dstCrs, string coordinateReferenceSystem, string resampling, int? maxSize, System.Collections.Generic.IEnumerable<string> rescale, string colorMapName, string colorMap, bool? returnMask, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetPartWithDimensionsAsync(string collectionId, string itemId, float minx, float miny, float maxx, float maxy, int width, int height, string format, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string colorFormula = null, string dstCrs = null, string coordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPartWithDimensionsAsync(string collectionId, string itemId, float minx, float miny, float maxx, float maxy, int width, int height, string format, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string algorithm, string algorithmParams, string colorFormula, string dstCrs, string coordinateReferenceSystem, string resampling, int? maxSize, System.Collections.Generic.IEnumerable<string> rescale, string colorMapName, string colorMap, bool? returnMask, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint> GetPoint(string collectionId, string itemId, float longitude, float latitude, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), string coordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPoint(string collectionId, string itemId, float longitude, float latitude, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string coordinateReferenceSystem, string resampling, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint>> GetPointAsync(string collectionId, string itemId, float longitude, float latitude, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), string coordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPointAsync(string collectionId, string itemId, float longitude, float latitude, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string coordinateReferenceSystem, string resampling, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetPreview(string collectionId, string itemId, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, Azure.Analytics.PlanetaryComputer.TilerImageFormat? format = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), string colorFormula = null, string dstCrs = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPreview(string collectionId, string itemId, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string algorithm, string algorithmParams, string format, string colorFormula, string dstCrs, string resampling, int? maxSize, int? height, int? width, System.Collections.Generic.IEnumerable<string> rescale, string colorMapName, string colorMap, bool? returnMask, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetPreviewAsync(string collectionId, string itemId, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, Azure.Analytics.PlanetaryComputer.TilerImageFormat? format = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), string colorFormula = null, string dstCrs = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPreviewAsync(string collectionId, string itemId, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string algorithm, string algorithmParams, string format, string colorFormula, string dstCrs, string resampling, int? maxSize, int? height, int? width, System.Collections.Generic.IEnumerable<string> rescale, string colorMapName, string colorMap, bool? returnMask, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetPreviewWithFormat(string collectionId, string itemId, string format, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string colorFormula = null, string dstCrs = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPreviewWithFormat(string collectionId, string itemId, string format, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string algorithm, string algorithmParams, string colorFormula, string dstCrs, string resampling, int? maxSize, int? height, int? width, System.Collections.Generic.IEnumerable<string> rescale, string colorMapName, string colorMap, bool? returnMask, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetPreviewWithFormatAsync(string collectionId, string itemId, string format, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string colorFormula = null, string dstCrs = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPreviewWithFormatAsync(string collectionId, string itemId, string format, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string algorithm, string algorithmParams, string colorFormula, string dstCrs, string resampling, int? maxSize, int? height, int? width, System.Collections.Generic.IEnumerable<string> rescale, string colorMapName, string colorMap, bool? returnMask, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetStaticImage(string collectionId, string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetStaticImage(string collectionId, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetStaticImageAsync(string collectionId, string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetStaticImageAsync(string collectionId, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TilerStacItemStatistics> GetStatistics(string collectionId, string itemId, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), bool? categorical = default(bool?), System.Collections.Generic.IEnumerable<string> categoriesPixels = null, System.Collections.Generic.IEnumerable<int> percentiles = null, string histogramBins = null, string histogramRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetStatistics(string collectionId, string itemId, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string resampling, int? maxSize, bool? categorical, System.Collections.Generic.IEnumerable<string> categoriesPixels, System.Collections.Generic.IEnumerable<int> percentiles, string histogramBins, string histogramRange, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TilerStacItemStatistics>> GetStatisticsAsync(string collectionId, string itemId, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), bool? categorical = default(bool?), System.Collections.Generic.IEnumerable<string> categoriesPixels = null, System.Collections.Generic.IEnumerable<int> percentiles = null, string histogramBins = null, string histogramRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetStatisticsAsync(string collectionId, string itemId, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string resampling, int? maxSize, bool? categorical, System.Collections.Generic.IEnumerable<string> categoriesPixels, System.Collections.Generic.IEnumerable<int> percentiles, string histogramBins, string histogramRange, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetTile(string collectionId, string itemId, string tileMatrixSetId, float z, float x, float y, float scale, string format, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string buffer = null, string colorFormula = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<string> subdatasetBands = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTile(string collectionId, string itemId, string tileMatrixSetId, float z, float x, float y, float scale, string format, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string algorithm, string algorithmParams, string buffer, string colorFormula, string resampling, System.Collections.Generic.IEnumerable<string> rescale, string colorMapName, string colorMap, bool? returnMask, string subdatasetName, System.Collections.Generic.IEnumerable<string> subdatasetBands, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetTileAsync(string collectionId, string itemId, string tileMatrixSetId, float z, float x, float y, float scale, string format, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string buffer = null, string colorFormula = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<string> subdatasetBands = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTileAsync(string collectionId, string itemId, string tileMatrixSetId, float z, float x, float y, float scale, string format, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string algorithm, string algorithmParams, string buffer, string colorFormula, string resampling, System.Collections.Generic.IEnumerable<string> rescale, string colorMapName, string colorMap, bool? returnMask, string subdatasetName, System.Collections.Generic.IEnumerable<string> subdatasetBands, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TileJsonMetadata> GetTileJson(string collectionId, string itemId, string tileMatrixSetId, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, Azure.Analytics.PlanetaryComputer.TilerImageFormat? tileFormat = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? tileScale = default(int?), int? minZoom = default(int?), int? maxZoom = default(int?), string buffer = null, string colorFormula = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTileJson(string collectionId, string itemId, string tileMatrixSetId, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string algorithm, string algorithmParams, string tileFormat, int? tileScale, int? minZoom, int? maxZoom, string buffer, string colorFormula, string resampling, System.Collections.Generic.IEnumerable<string> rescale, string colorMapName, string colorMap, bool? returnMask, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TileJsonMetadata>> GetTileJsonAsync(string collectionId, string itemId, string tileMatrixSetId, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, Azure.Analytics.PlanetaryComputer.TilerImageFormat? tileFormat = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? tileScale = default(int?), int? minZoom = default(int?), int? maxZoom = default(int?), string buffer = null, string colorFormula = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTileJsonAsync(string collectionId, string itemId, string tileMatrixSetId, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string algorithm, string algorithmParams, string tileFormat, int? tileScale, int? minZoom, int? maxZoom, string buffer, string colorFormula, string resampling, System.Collections.Generic.IEnumerable<string> rescale, string colorMapName, string colorMap, bool? returnMask, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetTileMatrices(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<string>> GetTileMatrices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTileMatricesAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<string>>> GetTileMatricesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTileMatrixDefinitions(string tileMatrixSetId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TileMatrixSet> GetTileMatrixDefinitions(string tileMatrixSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTileMatrixDefinitionsAsync(string tileMatrixSetId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TileMatrixSet>> GetTileMatrixDefinitionsAsync(string tileMatrixSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetWmtsCapabilities(string collectionId, string itemId, string tileMatrixSetId, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, Azure.Analytics.PlanetaryComputer.TilerImageFormat? tileFormat = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? tileScale = default(int?), int? minZoom = default(int?), int? maxZoom = default(int?), string buffer = null, string colorFormula = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetWmtsCapabilities(string collectionId, string itemId, string tileMatrixSetId, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string algorithm, string algorithmParams, string tileFormat, int? tileScale, int? minZoom, int? maxZoom, string buffer, string colorFormula, string resampling, System.Collections.Generic.IEnumerable<string> rescale, string colorMapName, string colorMap, bool? returnMask, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetWmtsCapabilitiesAsync(string collectionId, string itemId, string tileMatrixSetId, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, string assetBandIndices = null, bool? assetAsBand = default(bool?), float? noData = default(float?), bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, Azure.Analytics.PlanetaryComputer.TilerImageFormat? tileFormat = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? tileScale = default(int?), int? minZoom = default(int?), int? maxZoom = default(int?), string buffer = null, string colorFormula = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWmtsCapabilitiesAsync(string collectionId, string itemId, string tileMatrixSetId, System.Collections.Generic.IEnumerable<string> assets, string expression, string assetBandIndices, bool? assetAsBand, float? noData, bool? unscale, string algorithm, string algorithmParams, string tileFormat, int? tileScale, int? minZoom, int? maxZoom, string buffer, string colorFormula, string resampling, System.Collections.Generic.IEnumerable<string> rescale, string colorMapName, string colorMap, bool? returnMask, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response RegisterMosaicsSearch(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult> RegisterMosaicsSearch(System.Collections.Generic.IEnumerable<string> collections = null, System.Collections.Generic.IEnumerable<string> ids = null, float? boundingBox = default(float?), Azure.Analytics.PlanetaryComputer.GeoJsonGeometry intersects = null, System.Collections.Generic.IDictionary<string, System.BinaryData> query = null, System.Collections.Generic.IDictionary<string, System.BinaryData> filter = null, string datetime = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacSortExtension> sortBy = null, Azure.Analytics.PlanetaryComputer.FilterLanguage? filterLanguage = default(Azure.Analytics.PlanetaryComputer.FilterLanguage?), Azure.Analytics.PlanetaryComputer.MosaicMetadata metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegisterMosaicsSearchAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult>> RegisterMosaicsSearchAsync(System.Collections.Generic.IEnumerable<string> collections = null, System.Collections.Generic.IEnumerable<string> ids = null, float? boundingBox = default(float?), Azure.Analytics.PlanetaryComputer.GeoJsonGeometry intersects = null, System.Collections.Generic.IDictionary<string, System.BinaryData> query = null, System.Collections.Generic.IDictionary<string, System.BinaryData> filter = null, string datetime = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacSortExtension> sortBy = null, Azure.Analytics.PlanetaryComputer.FilterLanguage? filterLanguage = default(Azure.Analytics.PlanetaryComputer.FilterLanguage?), Azure.Analytics.PlanetaryComputer.MosaicMetadata metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DefaultLocation : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.DefaultLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.DefaultLocation>
    {
        public DefaultLocation(int zoom, System.Collections.Generic.IEnumerable<float> coordinates) { }
        public System.Collections.Generic.IList<float> Coordinates { get { throw null; } }
        public int Zoom { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.DefaultLocation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.DefaultLocation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.DefaultLocation System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.DefaultLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.DefaultLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.DefaultLocation System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.DefaultLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.DefaultLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.DefaultLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ErrorInfo>
    {
        internal ErrorInfo() { }
        public Azure.ResponseError Error { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.ErrorInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.ErrorInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.ErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.ErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeatureType : System.IEquatable<Azure.Analytics.PlanetaryComputer.FeatureType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeatureType(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.FeatureType Feature { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.FeatureType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.FeatureType left, Azure.Analytics.PlanetaryComputer.FeatureType right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.FeatureType (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.FeatureType? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.FeatureType left, Azure.Analytics.PlanetaryComputer.FeatureType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FilterLanguage : System.IEquatable<Azure.Analytics.PlanetaryComputer.FilterLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FilterLanguage(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.FilterLanguage Cql2Json { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.FilterLanguage Cql2Text { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.FilterLanguage CqlJson { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.FilterLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.FilterLanguage left, Azure.Analytics.PlanetaryComputer.FilterLanguage right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.FilterLanguage (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.FilterLanguage? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.FilterLanguage left, Azure.Analytics.PlanetaryComputer.FilterLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GeoJsonFeature : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GeoJsonFeature>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GeoJsonFeature>
    {
        public GeoJsonFeature(Azure.Analytics.PlanetaryComputer.GeoJsonGeometry geometry, Azure.Analytics.PlanetaryComputer.FeatureType type) { }
        public Azure.Analytics.PlanetaryComputer.GeoJsonGeometry Geometry { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Properties { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.FeatureType Type { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GeoJsonFeature JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.PlanetaryComputer.GeoJsonFeature geoJsonFeature) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.GeoJsonFeature PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GeoJsonFeature System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GeoJsonFeature>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GeoJsonFeature>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GeoJsonFeature System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GeoJsonFeature>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GeoJsonFeature>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GeoJsonFeature>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class GeoJsonGeometry : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GeoJsonGeometry>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GeoJsonGeometry>
    {
        internal GeoJsonGeometry() { }
        public System.Collections.Generic.IList<float> BoundingBox { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GeoJsonGeometry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GeoJsonGeometry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GeoJsonGeometry System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GeoJsonGeometry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GeoJsonGeometry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GeoJsonGeometry System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GeoJsonGeometry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GeoJsonGeometry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GeoJsonGeometry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageParameters : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ImageParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ImageParameters>
    {
        public ImageParameters(System.Collections.Generic.IDictionary<string, System.BinaryData> cql, string renderParameters, int columns, int rows) { }
        public int Columns { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Cql { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.GeoJsonGeometry Geometry { get { throw null; } set { } }
        public string ImageSize { get { throw null; } set { } }
        public string RenderParameters { get { throw null; } }
        public int Rows { get { throw null; } }
        public bool? ShowBranding { get { throw null; } set { } }
        public float? Zoom { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.ImageParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.PlanetaryComputer.ImageParameters imageParameters) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.ImageParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.ImageParameters System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ImageParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ImageParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.ImageParameters System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ImageParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ImageParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ImageParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageResponse : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ImageResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ImageResponse>
    {
        internal ImageResponse() { }
        public System.Uri Url { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.ImageResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.ImageResponse (Azure.Response result) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.ImageResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.ImageResponse System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ImageResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ImageResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.ImageResponse System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ImageResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ImageResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ImageResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IngestionClient
    {
        protected IngestionClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelAllOperations(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response CancelAllOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAllOperationsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAllOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelOperation(System.Guid operationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response CancelOperation(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelOperationAsync(System.Guid operationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelOperationAsync(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionInformation> Create(string collectionId, Azure.Analytics.PlanetaryComputer.IngestionInformation body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Create(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionInformation>> CreateAsync(string collectionId, Azure.Analytics.PlanetaryComputer.IngestionInformation body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateRun(string collectionId, System.Guid ingestionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionRun> CreateRun(string collectionId, System.Guid ingestionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateRunAsync(string collectionId, System.Guid ingestionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionRun>> CreateRunAsync(string collectionId, System.Guid ingestionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionSource> CreateSource(Azure.Analytics.PlanetaryComputer.IngestionSource body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateSource(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionSource>> CreateSourceAsync(Azure.Analytics.PlanetaryComputer.IngestionSource body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateSourceAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation Delete(Azure.WaitUntil waitUntil, string collectionId, System.Guid ingestionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation Delete(Azure.WaitUntil waitUntil, string collectionId, System.Guid ingestionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteAsync(Azure.WaitUntil waitUntil, string collectionId, System.Guid ingestionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteAsync(Azure.WaitUntil waitUntil, string collectionId, System.Guid ingestionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteSource(System.Guid id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteSource(System.Guid id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSourceAsync(System.Guid id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSourceAsync(System.Guid id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Get(string collectionId, System.Guid ingestionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionInformation> Get(string collectionId, System.Guid ingestionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAll(string collectionId, int? top, int? skip, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.PlanetaryComputer.IngestionInformation> GetAll(string collectionId, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllAsync(string collectionId, int? top, int? skip, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.PlanetaryComputer.IngestionInformation> GetAllAsync(string collectionId, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(string collectionId, System.Guid ingestionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionInformation>> GetAsync(string collectionId, System.Guid ingestionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetManagedIdentities(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.PlanetaryComputer.ManagedIdentityMetadata> GetManagedIdentities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetManagedIdentitiesAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.PlanetaryComputer.ManagedIdentityMetadata> GetManagedIdentitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetOperation(System.Guid operationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.LongRunningOperation> GetOperation(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetOperationAsync(System.Guid operationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.LongRunningOperation>> GetOperationAsync(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.PlanetaryComputer.LongRunningOperation> GetOperations(int? top = default(int?), int? skip = default(int?), string collectionId = null, Azure.Analytics.PlanetaryComputer.OperationStatus? status = default(Azure.Analytics.PlanetaryComputer.OperationStatus?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetOperations(int? top, int? skip, string collectionId, string status, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.PlanetaryComputer.LongRunningOperation> GetOperationsAsync(int? top = default(int?), int? skip = default(int?), string collectionId = null, Azure.Analytics.PlanetaryComputer.OperationStatus? status = default(Azure.Analytics.PlanetaryComputer.OperationStatus?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetOperationsAsync(int? top, int? skip, string collectionId, string status, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetRun(string collectionId, System.Guid ingestionId, System.Guid runId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionRun> GetRun(string collectionId, System.Guid ingestionId, System.Guid runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRunAsync(string collectionId, System.Guid ingestionId, System.Guid runId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionRun>> GetRunAsync(string collectionId, System.Guid ingestionId, System.Guid runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetRuns(string collectionId, System.Guid ingestionId, int? top, int? skip, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.PlanetaryComputer.IngestionRun> GetRuns(string collectionId, System.Guid ingestionId, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetRunsAsync(string collectionId, System.Guid ingestionId, int? top, int? skip, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.PlanetaryComputer.IngestionRun> GetRunsAsync(string collectionId, System.Guid ingestionId, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSource(System.Guid id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionSource> GetSource(System.Guid id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSourceAsync(System.Guid id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionSource>> GetSourceAsync(System.Guid id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSources(int? top, int? skip, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.PlanetaryComputer.IngestionSourceSummary> GetSources(int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSourcesAsync(int? top, int? skip, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.PlanetaryComputer.IngestionSourceSummary> GetSourcesAsync(int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionSource> ReplaceSource(System.Guid id, Azure.Analytics.PlanetaryComputer.IngestionSource body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReplaceSource(System.Guid id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionSource>> ReplaceSourceAsync(System.Guid id, Azure.Analytics.PlanetaryComputer.IngestionSource body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplaceSourceAsync(System.Guid id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Update(string collectionId, System.Guid ingestionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(string collectionId, System.Guid ingestionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class IngestionInformation : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionInformation>
    {
        public IngestionInformation(Azure.Analytics.PlanetaryComputer.IngestionType importType) { }
        public System.DateTimeOffset CreationTime { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public System.Guid Id { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.IngestionType ImportType { get { throw null; } set { } }
        public bool? KeepOriginalAssets { get { throw null; } set { } }
        public bool? SkipExistingItems { get { throw null; } set { } }
        public System.Uri SourceCatalogUrl { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.IngestionStatus Status { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.IngestionInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.IngestionInformation (Azure.Response result) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.PlanetaryComputer.IngestionInformation ingestionInformation) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.IngestionInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.IngestionInformation System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.IngestionInformation System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IngestionRun : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionRun>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionRun>
    {
        internal IngestionRun() { }
        public System.DateTimeOffset CreationTime { get { throw null; } }
        public System.Guid Id { get { throw null; } }
        public bool? KeepOriginalAssets { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.IngestionRunInformation Operation { get { throw null; } }
        public System.Guid? ParentRunId { get { throw null; } }
        public bool? SkipExistingItems { get { throw null; } }
        public System.Uri SourceCatalogUrl { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.IngestionRun JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.IngestionRun (Azure.Response result) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.IngestionRun PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.IngestionRun System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.IngestionRun System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IngestionRunInformation : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionRunInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionRunInformation>
    {
        internal IngestionRunInformation() { }
        public System.DateTimeOffset CreationTime { get { throw null; } }
        public System.DateTimeOffset? FinishTime { get { throw null; } }
        public System.Guid Id { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.OperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.OperationStatusHistoryItem> StatusHistory { get { throw null; } }
        public int TotalFailedItems { get { throw null; } }
        public int TotalItems { get { throw null; } }
        public int TotalPendingItems { get { throw null; } }
        public int TotalSuccessfulItems { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.IngestionRunInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.IngestionRunInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.IngestionRunInformation System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionRunInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionRunInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.IngestionRunInformation System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionRunInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionRunInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionRunInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class IngestionSource : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionSource>
    {
        internal IngestionSource() { }
        public System.DateTimeOffset? Created { get { throw null; } }
        public System.Guid Id { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.IngestionSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.IngestionSource (Azure.Response result) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.PlanetaryComputer.IngestionSource ingestionSource) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.IngestionSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.IngestionSource System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.IngestionSource System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IngestionSourceSummary : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionSourceSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionSourceSummary>
    {
        internal IngestionSourceSummary() { }
        public System.DateTimeOffset? Created { get { throw null; } }
        public System.Guid Id { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.IngestionSourceType Kind { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.IngestionSourceSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.IngestionSourceSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.IngestionSourceSummary System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionSourceSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionSourceSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.IngestionSourceSummary System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionSourceSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionSourceSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionSourceSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IngestionSourceType : System.IEquatable<Azure.Analytics.PlanetaryComputer.IngestionSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IngestionSourceType(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.IngestionSourceType BlobManagedIdentity { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.IngestionSourceType SharedAccessSignatureToken { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.IngestionSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.IngestionSourceType left, Azure.Analytics.PlanetaryComputer.IngestionSourceType right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.IngestionSourceType (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.IngestionSourceType? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.IngestionSourceType left, Azure.Analytics.PlanetaryComputer.IngestionSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IngestionStatus : System.IEquatable<Azure.Analytics.PlanetaryComputer.IngestionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IngestionStatus(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.IngestionStatus Deleting { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.IngestionStatus Ready { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.IngestionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.IngestionStatus left, Azure.Analytics.PlanetaryComputer.IngestionStatus right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.IngestionStatus (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.IngestionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.IngestionStatus left, Azure.Analytics.PlanetaryComputer.IngestionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IngestionType : System.IEquatable<Azure.Analytics.PlanetaryComputer.IngestionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IngestionType(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.IngestionType StaticCatalog { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.IngestionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.IngestionType left, Azure.Analytics.PlanetaryComputer.IngestionType right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.IngestionType (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.IngestionType? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.IngestionType left, Azure.Analytics.PlanetaryComputer.IngestionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LegendConfigType : System.IEquatable<Azure.Analytics.PlanetaryComputer.LegendConfigType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LegendConfigType(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.LegendConfigType Classmap { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.LegendConfigType Continuous { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.LegendConfigType Interval { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.LegendConfigType None { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.LegendConfigType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.LegendConfigType left, Azure.Analytics.PlanetaryComputer.LegendConfigType right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.LegendConfigType (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.LegendConfigType? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.LegendConfigType left, Azure.Analytics.PlanetaryComputer.LegendConfigType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LineString : Azure.Analytics.PlanetaryComputer.GeoJsonGeometry, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.LineString>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.LineString>
    {
        public LineString(System.Collections.Generic.IEnumerable<float> coordinates) { }
        public System.Collections.Generic.IList<float> Coordinates { get { throw null; } }
        protected override Azure.Analytics.PlanetaryComputer.GeoJsonGeometry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Analytics.PlanetaryComputer.GeoJsonGeometry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.LineString System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.LineString>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.LineString>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.LineString System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.LineString>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.LineString>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.LineString>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LongRunningOperation : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.LongRunningOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.LongRunningOperation>
    {
        internal LongRunningOperation() { }
        public System.Collections.Generic.IDictionary<string, string> AdditionalInformation { get { throw null; } }
        public string CollectionId { get { throw null; } }
        public System.DateTimeOffset CreationTime { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.ErrorInfo Error { get { throw null; } }
        public System.DateTimeOffset? FinishTime { get { throw null; } }
        public System.Guid Id { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.OperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.OperationStatusHistoryItem> StatusHistory { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.LongRunningOperation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.LongRunningOperation (Azure.Response result) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.LongRunningOperation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.LongRunningOperation System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.LongRunningOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.LongRunningOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.LongRunningOperation System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.LongRunningOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.LongRunningOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.LongRunningOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedIdentityConnection : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityConnection>
    {
        public ManagedIdentityConnection(System.Uri containerUri, System.Guid objectId) { }
        public System.Uri ContainerUri { get { throw null; } set { } }
        public System.Guid ObjectId { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.ManagedIdentityConnection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.ManagedIdentityConnection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.ManagedIdentityConnection System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.ManagedIdentityConnection System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedIdentityIngestionSource : Azure.Analytics.PlanetaryComputer.IngestionSource, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityIngestionSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityIngestionSource>
    {
        public ManagedIdentityIngestionSource(System.Guid id, Azure.Analytics.PlanetaryComputer.ManagedIdentityConnection connectionInfo) { }
        public Azure.Analytics.PlanetaryComputer.ManagedIdentityConnection ConnectionInfo { get { throw null; } set { } }
        protected override Azure.Analytics.PlanetaryComputer.IngestionSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Analytics.PlanetaryComputer.IngestionSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.ManagedIdentityIngestionSource System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityIngestionSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityIngestionSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.ManagedIdentityIngestionSource System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityIngestionSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityIngestionSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityIngestionSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedIdentityMetadata : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityMetadata>
    {
        internal ManagedIdentityMetadata() { }
        public System.Guid ObjectId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.ManagedIdentityMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.ManagedIdentityMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.ManagedIdentityMetadata System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.ManagedIdentityMetadata System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ManagedIdentityMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedStorageSharedAccessSignatureClient
    {
        protected ManagedStorageSharedAccessSignatureClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetSign(System.Uri href, int? durationInMinutes, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink> GetSign(System.Uri href, int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSignAsync(System.Uri href, int? durationInMinutes, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink>> GetSignAsync(System.Uri href, int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetToken(string collectionId, int? durationInMinutes, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureToken> GetToken(string collectionId, int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTokenAsync(string collectionId, int? durationInMinutes, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureToken>> GetTokenAsync(string collectionId, int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RevokeToken(int? durationInMinutes, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response RevokeToken(int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokeTokenAsync(int? durationInMinutes, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokeTokenAsync(int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MosaicMetadata : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.MosaicMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.MosaicMetadata>
    {
        public MosaicMetadata() { }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public string Bounds { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Defaults { get { throw null; } }
        public int? MaxZoom { get { throw null; } set { } }
        public int? MinZoom { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.MosaicMetadataType? Type { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.MosaicMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.MosaicMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.MosaicMetadata System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.MosaicMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.MosaicMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.MosaicMetadata System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.MosaicMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.MosaicMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.MosaicMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MosaicMetadataType : System.IEquatable<Azure.Analytics.PlanetaryComputer.MosaicMetadataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MosaicMetadataType(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.MosaicMetadataType Mosaic { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.MosaicMetadataType Search { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.MosaicMetadataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.MosaicMetadataType left, Azure.Analytics.PlanetaryComputer.MosaicMetadataType right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.MosaicMetadataType (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.MosaicMetadataType? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.MosaicMetadataType left, Azure.Analytics.PlanetaryComputer.MosaicMetadataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MultiLineString : Azure.Analytics.PlanetaryComputer.GeoJsonGeometry, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.MultiLineString>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.MultiLineString>
    {
        public MultiLineString(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<float>> coordinates) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<float>> Coordinates { get { throw null; } }
        protected override Azure.Analytics.PlanetaryComputer.GeoJsonGeometry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Analytics.PlanetaryComputer.GeoJsonGeometry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.MultiLineString System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.MultiLineString>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.MultiLineString>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.MultiLineString System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.MultiLineString>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.MultiLineString>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.MultiLineString>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultiPoint : Azure.Analytics.PlanetaryComputer.GeoJsonGeometry, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.MultiPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.MultiPoint>
    {
        public MultiPoint(System.Collections.Generic.IEnumerable<float> coordinates) { }
        public System.Collections.Generic.IList<float> Coordinates { get { throw null; } }
        protected override Azure.Analytics.PlanetaryComputer.GeoJsonGeometry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Analytics.PlanetaryComputer.GeoJsonGeometry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.MultiPoint System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.MultiPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.MultiPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.MultiPoint System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.MultiPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.MultiPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.MultiPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultiPolygon : Azure.Analytics.PlanetaryComputer.GeoJsonGeometry, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.MultiPolygon>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.MultiPolygon>
    {
        public MultiPolygon(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.Collections.Generic.IList<float>>> coordinates) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<System.Collections.Generic.IList<float>>> Coordinates { get { throw null; } }
        protected override Azure.Analytics.PlanetaryComputer.GeoJsonGeometry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Analytics.PlanetaryComputer.GeoJsonGeometry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.MultiPolygon System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.MultiPolygon>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.MultiPolygon>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.MultiPolygon System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.MultiPolygon>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.MultiPolygon>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.MultiPolygon>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NoDataType : System.IEquatable<Azure.Analytics.PlanetaryComputer.NoDataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NoDataType(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.NoDataType Alpha { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.NoDataType Internal { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.NoDataType Mask { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.NoDataType Nodata { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.NoDataType None { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.NoDataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.NoDataType left, Azure.Analytics.PlanetaryComputer.NoDataType right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.NoDataType (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.NoDataType? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.NoDataType left, Azure.Analytics.PlanetaryComputer.NoDataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationStatus : System.IEquatable<Azure.Analytics.PlanetaryComputer.OperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationStatus(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.OperationStatus Canceled { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.OperationStatus Canceling { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.OperationStatus Failed { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.OperationStatus Pending { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.OperationStatus Running { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.OperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.OperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.OperationStatus left, Azure.Analytics.PlanetaryComputer.OperationStatus right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.OperationStatus (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.OperationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.OperationStatus left, Azure.Analytics.PlanetaryComputer.OperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationStatusHistoryItem : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.OperationStatusHistoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.OperationStatusHistoryItem>
    {
        internal OperationStatusHistoryItem() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.OperationStatus Status { get { throw null; } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.OperationStatusHistoryItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.OperationStatusHistoryItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.OperationStatusHistoryItem System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.OperationStatusHistoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.OperationStatusHistoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.OperationStatusHistoryItem System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.OperationStatusHistoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.OperationStatusHistoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.OperationStatusHistoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartitionType : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PartitionType>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PartitionType>
    {
        public PartitionType() { }
        public Azure.Analytics.PlanetaryComputer.PartitionTypeScheme? Scheme { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.PartitionType JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.PartitionType (Azure.Response result) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.PlanetaryComputer.PartitionType partitionType) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.PartitionType PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.PartitionType System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PartitionType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PartitionType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.PartitionType System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PartitionType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PartitionType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PartitionType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartitionTypeScheme : System.IEquatable<Azure.Analytics.PlanetaryComputer.PartitionTypeScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartitionTypeScheme(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.PartitionTypeScheme Month { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PartitionTypeScheme None { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PartitionTypeScheme Year { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.PartitionTypeScheme other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.PartitionTypeScheme left, Azure.Analytics.PlanetaryComputer.PartitionTypeScheme right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.PartitionTypeScheme (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.PartitionTypeScheme? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.PartitionTypeScheme left, Azure.Analytics.PlanetaryComputer.PartitionTypeScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PixelSelection : System.IEquatable<Azure.Analytics.PlanetaryComputer.PixelSelection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PixelSelection(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.PixelSelection First { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PixelSelection Highest { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PixelSelection LastBandHigh { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PixelSelection LastBandLow { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PixelSelection Lowest { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PixelSelection Mean { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PixelSelection Median { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PixelSelection StandardDeviation { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.PixelSelection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.PixelSelection left, Azure.Analytics.PlanetaryComputer.PixelSelection right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.PixelSelection (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.PixelSelection? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.PixelSelection left, Azure.Analytics.PlanetaryComputer.PixelSelection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class PlanetaryComputerModelFactory
    {
        public static Azure.Analytics.PlanetaryComputer.BandStatistics BandStatistics(float minimum = 0f, float maximum = 0f, float mean = 0f, float count = 0f, float sum = 0f, float std = 0f, float median = 0f, float majority = 0f, float minority = 0f, float unique = 0f, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<float>> histogram = null, float validPercent = 0f, float maskedPixels = 0f, float validPixels = 0f, float percentile2 = 0f, float percentile98 = 0f) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.DefaultLocation DefaultLocation(int zoom = 0, System.Collections.Generic.IEnumerable<float> coordinates = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.ErrorInfo ErrorInfo(Azure.ResponseError error = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GeoJsonFeature GeoJsonFeature(Azure.Analytics.PlanetaryComputer.GeoJsonGeometry geometry = null, Azure.Analytics.PlanetaryComputer.FeatureType type = default(Azure.Analytics.PlanetaryComputer.FeatureType), System.Collections.Generic.IDictionary<string, System.BinaryData> properties = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GeoJsonGeometry GeoJsonGeometry(string type = null, System.Collections.Generic.IEnumerable<float> boundingBox = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.ImageParameters ImageParameters(System.Collections.Generic.IDictionary<string, System.BinaryData> cql = null, float? zoom = default(float?), Azure.Analytics.PlanetaryComputer.GeoJsonGeometry geometry = null, string renderParameters = null, int columns = 0, int rows = 0, bool? showBranding = default(bool?), string imageSize = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.ImageResponse ImageResponse(System.Uri url = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.IngestionInformation IngestionInformation(System.Guid id = default(System.Guid), Azure.Analytics.PlanetaryComputer.IngestionType importType = default(Azure.Analytics.PlanetaryComputer.IngestionType), string displayName = null, System.Uri sourceCatalogUrl = null, bool? skipExistingItems = default(bool?), bool? keepOriginalAssets = default(bool?), System.DateTimeOffset creationTime = default(System.DateTimeOffset), Azure.Analytics.PlanetaryComputer.IngestionStatus status = default(Azure.Analytics.PlanetaryComputer.IngestionStatus)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.IngestionRun IngestionRun(System.Guid id = default(System.Guid), System.Guid? parentRunId = default(System.Guid?), Azure.Analytics.PlanetaryComputer.IngestionRunInformation operation = null, System.DateTimeOffset creationTime = default(System.DateTimeOffset), System.Uri sourceCatalogUrl = null, bool? skipExistingItems = default(bool?), bool? keepOriginalAssets = default(bool?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.IngestionRunInformation IngestionRunInformation(System.Guid id = default(System.Guid), Azure.Analytics.PlanetaryComputer.OperationStatus status = default(Azure.Analytics.PlanetaryComputer.OperationStatus), System.DateTimeOffset creationTime = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.OperationStatusHistoryItem> statusHistory = null, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? finishTime = default(System.DateTimeOffset?), int totalItems = 0, int totalPendingItems = 0, int totalSuccessfulItems = 0, int totalFailedItems = 0) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.IngestionSource IngestionSource(System.Guid id = default(System.Guid), System.DateTimeOffset? created = default(System.DateTimeOffset?), string kind = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.IngestionSourceSummary IngestionSourceSummary(System.Guid id = default(System.Guid), Azure.Analytics.PlanetaryComputer.IngestionSourceType kind = default(Azure.Analytics.PlanetaryComputer.IngestionSourceType), System.DateTimeOffset? created = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.LineString LineString(System.Collections.Generic.IEnumerable<float> boundingBox = null, System.Collections.Generic.IEnumerable<float> coordinates = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.LongRunningOperation LongRunningOperation(System.Guid id = default(System.Guid), Azure.Analytics.PlanetaryComputer.OperationStatus status = default(Azure.Analytics.PlanetaryComputer.OperationStatus), string type = null, System.DateTimeOffset creationTime = default(System.DateTimeOffset), string collectionId = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.OperationStatusHistoryItem> statusHistory = null, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? finishTime = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, string> additionalInformation = null, Azure.Analytics.PlanetaryComputer.ErrorInfo error = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.ManagedIdentityConnection ManagedIdentityConnection(System.Uri containerUri = null, System.Guid objectId = default(System.Guid)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.ManagedIdentityIngestionSource ManagedIdentityIngestionSource(System.Guid id = default(System.Guid), System.DateTimeOffset? created = default(System.DateTimeOffset?), Azure.Analytics.PlanetaryComputer.ManagedIdentityConnection connectionInfo = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.ManagedIdentityMetadata ManagedIdentityMetadata(System.Guid objectId = default(System.Guid), Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.MosaicMetadata MosaicMetadata(Azure.Analytics.PlanetaryComputer.MosaicMetadataType? type = default(Azure.Analytics.PlanetaryComputer.MosaicMetadataType?), string bounds = null, int? minZoom = default(int?), int? maxZoom = default(int?), string name = null, System.Collections.Generic.IEnumerable<string> assets = null, System.Collections.Generic.IDictionary<string, string> defaults = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.MultiLineString MultiLineString(System.Collections.Generic.IEnumerable<float> boundingBox = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<float>> coordinates = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.MultiPoint MultiPoint(System.Collections.Generic.IEnumerable<float> boundingBox = null, System.Collections.Generic.IEnumerable<float> coordinates = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.MultiPolygon MultiPolygon(System.Collections.Generic.IEnumerable<float> boundingBox = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.Collections.Generic.IList<float>>> coordinates = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.OperationStatusHistoryItem OperationStatusHistoryItem(System.DateTimeOffset timestamp = default(System.DateTimeOffset), Azure.Analytics.PlanetaryComputer.OperationStatus status = default(Azure.Analytics.PlanetaryComputer.OperationStatus), string errorCode = null, string errorMessage = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.PartitionType PartitionType(Azure.Analytics.PlanetaryComputer.PartitionTypeScheme? scheme = default(Azure.Analytics.PlanetaryComputer.PartitionTypeScheme?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.PointGeometry PointGeometry(System.Collections.Generic.IEnumerable<float> boundingBox = null, string coordinates = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.PolygonGeometry PolygonGeometry(System.Collections.Generic.IEnumerable<float> boundingBox = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.Collections.Generic.IList<float>>> coordinates = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.RenderConfiguration RenderConfiguration(string id = null, string name = null, string description = null, Azure.Analytics.PlanetaryComputer.RenderOptionType? type = default(Azure.Analytics.PlanetaryComputer.RenderOptionType?), string options = null, Azure.Analytics.PlanetaryComputer.RenderOptionVectorOptions vectorOptions = null, int? minZoom = default(int?), Azure.Analytics.PlanetaryComputer.RenderOptionLegend legend = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.RenderOptionCondition> conditions = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.RenderOptionCondition RenderOptionCondition(string property = null, string value = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.RenderOptionLegend RenderOptionLegend(Azure.Analytics.PlanetaryComputer.LegendConfigType? type = default(Azure.Analytics.PlanetaryComputer.LegendConfigType?), System.Collections.Generic.IEnumerable<string> labels = null, int? trimStart = default(int?), int? trimEnd = default(int?), float? scaleFactor = default(float?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.RenderOptionVectorOptions RenderOptionVectorOptions(string tilejsonKey = null, string sourceLayer = null, string fillColor = null, string strokeColor = null, int? strokeWidth = default(int?), System.Collections.Generic.IEnumerable<string> filter = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.SearchOptionsFields SearchOptionsFields(System.Collections.Generic.IEnumerable<string> include = null, System.Collections.Generic.IEnumerable<string> exclude = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink SharedAccessSignatureSignedLink(System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), System.Uri href = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.SharedAccessSignatureToken SharedAccessSignatureToken(System.DateTimeOffset expiresOn = default(System.DateTimeOffset), string token = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenConnection SharedAccessSignatureTokenConnection(System.Uri containerUri = null, string sharedAccessSignatureToken = null, System.DateTimeOffset? expiration = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenIngestionSource SharedAccessSignatureTokenIngestionSource(System.Guid id = default(System.Guid), System.DateTimeOffset? created = default(System.DateTimeOffset?), Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenConnection connectionInfo = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacAsset StacAsset(string platform = null, System.Collections.Generic.IEnumerable<string> instruments = null, string constellation = null, string mission = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacProvider> providers = null, float? gsd = default(float?), System.DateTimeOffset? created = default(System.DateTimeOffset?), System.DateTimeOffset? updated = default(System.DateTimeOffset?), string title = null, string description = null, string href = null, string type = null, System.Collections.Generic.IEnumerable<string> roles = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacCatalogCollections StacCatalogCollections(System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacLink> links = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacCollectionResource> collections = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacCollectionResource StacCollectionResource(string createdOn = null, string updatedOn = null, string shortDescription = null, System.Collections.Generic.IEnumerable<string> stacExtensions = null, string id = null, string description = null, string stacVersion = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacLink> links = null, string title = null, string type = null, System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.StacAsset> assets = null, System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.StacItemAsset> itemAssets = null, string license = null, Azure.Analytics.PlanetaryComputer.StacExtensionExtent extent = null, System.Collections.Generic.IEnumerable<string> keywords = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacProvider> providers = null, System.Collections.Generic.IDictionary<string, System.BinaryData> summaries = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacCollectionTemporalExtent StacCollectionTemporalExtent(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<string>> interval = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacConformanceClasses StacConformanceClasses(System.Collections.Generic.IEnumerable<System.Uri> conformsTo = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacContextExtension StacContextExtension(int returned = 0, int? limit = default(int?), int? matched = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacExtensionExtent StacExtensionExtent(Azure.Analytics.PlanetaryComputer.StacExtensionSpatialExtent spatial = null, Azure.Analytics.PlanetaryComputer.StacCollectionTemporalExtent temporal = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacExtensionSpatialExtent StacExtensionSpatialExtent(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<float>> boundingBox = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacItemAsset StacItemAsset(string platform = null, System.Collections.Generic.IEnumerable<string> instruments = null, string constellation = null, string mission = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacProvider> providers = null, float? gsd = default(float?), System.DateTimeOffset? created = default(System.DateTimeOffset?), System.DateTimeOffset? updated = default(System.DateTimeOffset?), string title = null, string description = null, string href = null, string type = null, System.Collections.Generic.IEnumerable<string> roles = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacItemBounds StacItemBounds(System.Collections.Generic.IEnumerable<float> bounds = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacItemCollectionResource StacItemCollectionResource(string stacVersion = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacLink> links = null, string createdOn = null, string updatedOn = null, string shortDescription = null, System.Collections.Generic.IEnumerable<string> stacExtensions = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacItemResource> features = null, System.Collections.Generic.IEnumerable<float> boundingBox = null, Azure.Analytics.PlanetaryComputer.StacContextExtension context = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection StacItemOrStacItemCollection(string type = null, string stacVersion = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacLink> links = null, string createdOn = null, string updatedOn = null, string shortDescription = null, System.Collections.Generic.IEnumerable<string> stacExtensions = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacItemPointAsset StacItemPointAsset(string id = null, System.Collections.Generic.IEnumerable<float> boundingBox = null, System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.StacAsset> assets = null, string collectionId = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacItemProperties StacItemProperties(string platform = null, System.Collections.Generic.IEnumerable<string> instruments = null, string constellation = null, string mission = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacProvider> providers = null, float? gsd = default(float?), System.DateTimeOffset? created = default(System.DateTimeOffset?), System.DateTimeOffset? updated = default(System.DateTimeOffset?), string title = null, string description = null, string datetime = null, System.DateTimeOffset? startDatetime = default(System.DateTimeOffset?), System.DateTimeOffset? endDatetime = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacItemResource StacItemResource(string stacVersion = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacLink> links = null, string createdOn = null, string updatedOn = null, string shortDescription = null, System.Collections.Generic.IEnumerable<string> stacExtensions = null, Azure.Analytics.PlanetaryComputer.GeoJsonGeometry geometry = null, string id = null, string collection = null, System.Collections.Generic.IEnumerable<float> boundingBox = null, Azure.Analytics.PlanetaryComputer.StacItemProperties properties = null, System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.StacAsset> assets = null, string timestamp = null, string eTag = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson StacItemStatisticsGeoJson(Azure.Analytics.PlanetaryComputer.GeoJsonGeometry geometry = null, Azure.Analytics.PlanetaryComputer.FeatureType type = default(Azure.Analytics.PlanetaryComputer.FeatureType), Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJsonProperties properties = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJsonProperties StacItemStatisticsGeoJsonProperties(System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.BandStatistics> statistics = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacLandingPage StacLandingPage(string createdOn = null, string updatedOn = null, string shortDescription = null, System.Collections.Generic.IEnumerable<string> stacExtensions = null, string id = null, string description = null, string title = null, string stacVersion = null, System.Collections.Generic.IEnumerable<System.Uri> conformsTo = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacLink> links = null, string type = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacLink StacLink(string rel = null, string title = null, Azure.Analytics.PlanetaryComputer.StacLinkType? type = default(Azure.Analytics.PlanetaryComputer.StacLinkType?), string href = null, string hreflang = null, int? length = default(int?), Azure.Analytics.PlanetaryComputer.StacLinkMethod? method = default(Azure.Analytics.PlanetaryComputer.StacLinkMethod?), System.Collections.Generic.IDictionary<string, string> headers = null, System.Collections.Generic.IDictionary<string, System.BinaryData> body = null, bool? merge = default(bool?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacMosaic StacMosaic(string id = null, string name = null, string description = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> cql = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacMosaicConfiguration StacMosaicConfiguration(System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacMosaic> mosaics = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.RenderConfiguration> renderOptions = null, Azure.Analytics.PlanetaryComputer.DefaultLocation defaultLocation = null, System.Collections.Generic.IDictionary<string, System.BinaryData> defaultCustomQuery = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacProvider StacProvider(string name = null, string description = null, System.Collections.Generic.IEnumerable<string> roles = null, string url = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacQueryable StacQueryable(string name = null, System.Collections.Generic.IDictionary<string, System.BinaryData> definition = null, bool? createIndex = default(bool?), Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataType? dataType = default(Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataType?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacSearchParameters StacSearchParameters(System.Collections.Generic.IEnumerable<string> collections = null, System.Collections.Generic.IEnumerable<string> ids = null, System.Collections.Generic.IEnumerable<float> boundingBox = null, Azure.Analytics.PlanetaryComputer.GeoJsonGeometry intersects = null, string datetime = null, int? limit = default(int?), System.Collections.Generic.IDictionary<string, System.BinaryData> conformanceClass = null, Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode? sign = default(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode?), int? durationInMinutes = default(int?), System.Collections.Generic.IDictionary<string, System.BinaryData> query = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacSortExtension> sortBy = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.SearchOptionsFields> fields = null, System.Collections.Generic.IDictionary<string, System.BinaryData> filter = null, string filterCoordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.FilterLanguage? filterLang = default(Azure.Analytics.PlanetaryComputer.FilterLanguage?), string token = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacSortExtension StacSortExtension(string field = null, Azure.Analytics.PlanetaryComputer.StacSearchSortingDirection direction = default(Azure.Analytics.PlanetaryComputer.StacSearchSortingDirection)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TileJsonMetadata TileJsonMetadata(string tileJson = null, string name = null, string description = null, string version = null, string attribution = null, string template = null, string legend = null, Azure.Analytics.PlanetaryComputer.TileAddressingScheme? scheme = default(Azure.Analytics.PlanetaryComputer.TileAddressingScheme?), System.Collections.Generic.IEnumerable<string> tiles = null, System.Collections.Generic.IEnumerable<string> grids = null, System.Collections.Generic.IEnumerable<string> data = null, int? minZoom = default(int?), int? maxZoom = default(int?), System.Collections.Generic.IEnumerable<float> bounds = null, System.Collections.Generic.IEnumerable<float> center = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TileMatrix TileMatrix(string title = null, string description = null, System.Collections.Generic.IEnumerable<string> keywords = null, string id = null, float scaleDenominator = 0f, float cellSize = 0f, Azure.Analytics.PlanetaryComputer.TileMatrixCornerOfOrigin? cornerOfOrigin = default(Azure.Analytics.PlanetaryComputer.TileMatrixCornerOfOrigin?), System.Collections.Generic.IEnumerable<float> pointOfOrigin = null, int tileWidth = 0, int tileHeight = 0, int matrixWidth = 0, int matrixHeight = 0, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.VariableMatrixWidth> variableMatrixWidths = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TileMatrixSet TileMatrixSet(string title = null, string description = null, System.Collections.Generic.IEnumerable<string> keywords = null, string id = null, string uri = null, System.Collections.Generic.IEnumerable<string> orderedAxes = null, string crs = null, System.Uri wellKnownScaleSet = null, Azure.Analytics.PlanetaryComputer.TileMatrixSetBoundingBox boundingBox = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.TileMatrix> tileMatrices = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TileMatrixSetBoundingBox TileMatrixSetBoundingBox(System.Collections.Generic.IEnumerable<string> lowerLeft = null, System.Collections.Generic.IEnumerable<string> upperRight = null, string crs = null, System.Collections.Generic.IEnumerable<string> orderedAxes = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint TilerCoreModelsResponsesPoint(System.Collections.Generic.IEnumerable<float> coordinates = null, System.Collections.Generic.IEnumerable<float> values = null, System.Collections.Generic.IEnumerable<string> bandNames = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TilerInfo TilerInfo(System.Collections.Generic.IEnumerable<float> bounds = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.BinaryData>> bandMetadata = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<string>> bandDescriptions = null, string dtype = null, Azure.Analytics.PlanetaryComputer.NoDataType? noDataType = default(Azure.Analytics.PlanetaryComputer.NoDataType?), System.Collections.Generic.IEnumerable<string> colorInterpretation = null, string driver = null, int? count = default(int?), int? width = default(int?), int? height = default(int?), System.Collections.Generic.IEnumerable<int> overviews = null, System.Collections.Generic.IEnumerable<int> scales = null, System.Collections.Generic.IEnumerable<int> offsets = null, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> colormap = null, int? minZoom = default(int?), int? maxZoom = default(int?), string coordinateReferenceSystem = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature TilerInfoGeoJsonFeature(Azure.Analytics.PlanetaryComputer.FeatureType type = default(Azure.Analytics.PlanetaryComputer.FeatureType), Azure.Analytics.PlanetaryComputer.GeoJsonGeometry geometry = null, System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.TilerInfo> properties = null, string id = null, float? boundingBox = default(float?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult TilerMosaicSearchRegistrationResult(string searchId = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacLink> links = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TilerStacItemStatistics TilerStacItemStatistics(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TilerStacSearchDefinition TilerStacSearchDefinition(string hash = null, System.Collections.Generic.IDictionary<string, System.BinaryData> search = null, string where = null, string orderBy = null, System.DateTimeOffset lastUsed = default(System.DateTimeOffset), int useCount = 0, Azure.Analytics.PlanetaryComputer.MosaicMetadata metadata = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration TilerStacSearchRegistration(Azure.Analytics.PlanetaryComputer.TilerStacSearchDefinition search = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacLink> links = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TileSettings TileSettings(int minZoom = 0, int maxItemsPerTile = 0, Azure.Analytics.PlanetaryComputer.DefaultLocation defaultLocation = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.UserCollectionSettings UserCollectionSettings(Azure.Analytics.PlanetaryComputer.TileSettings tileSettings = null, Azure.Analytics.PlanetaryComputer.StacMosaicConfiguration mosaicConfiguration = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.VariableMatrixWidth VariableMatrixWidth(int coalesce = 0, int minTileRow = 0, int maxTileRow = 0) { throw null; }
    }
    public partial class PlanetaryComputerProClient
    {
        protected PlanetaryComputerProClient() { }
        public PlanetaryComputerProClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public PlanetaryComputerProClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.PlanetaryComputer.PlanetaryComputerProClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Analytics.PlanetaryComputer.DataClient GetDataClient() { throw null; }
        public virtual Azure.Analytics.PlanetaryComputer.IngestionClient GetIngestionClient() { throw null; }
        public virtual Azure.Analytics.PlanetaryComputer.ManagedStorageSharedAccessSignatureClient GetManagedStorageSharedAccessSignatureClient() { throw null; }
        public virtual Azure.Analytics.PlanetaryComputer.StacClient GetStacClient() { throw null; }
    }
    public partial class PlanetaryComputerProClientOptions : Azure.Core.ClientOptions
    {
        public PlanetaryComputerProClientOptions(Azure.Analytics.PlanetaryComputer.PlanetaryComputerProClientOptions.ServiceVersion version = Azure.Analytics.PlanetaryComputer.PlanetaryComputerProClientOptions.ServiceVersion.V2025_04_30_Preview) { }
        public enum ServiceVersion
        {
            V2025_04_30_Preview = 1,
        }
    }
    public partial class PointGeometry : Azure.Analytics.PlanetaryComputer.GeoJsonGeometry, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PointGeometry>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PointGeometry>
    {
        public PointGeometry(string coordinates) { }
        public string Coordinates { get { throw null; } set { } }
        protected override Azure.Analytics.PlanetaryComputer.GeoJsonGeometry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Analytics.PlanetaryComputer.GeoJsonGeometry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.PointGeometry System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PointGeometry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PointGeometry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.PointGeometry System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PointGeometry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PointGeometry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PointGeometry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolygonGeometry : Azure.Analytics.PlanetaryComputer.GeoJsonGeometry, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PolygonGeometry>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PolygonGeometry>
    {
        public PolygonGeometry(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.Collections.Generic.IList<float>>> coordinates) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<System.Collections.Generic.IList<float>>> Coordinates { get { throw null; } }
        protected override Azure.Analytics.PlanetaryComputer.GeoJsonGeometry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Analytics.PlanetaryComputer.GeoJsonGeometry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.PolygonGeometry System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PolygonGeometry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PolygonGeometry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.PolygonGeometry System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PolygonGeometry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PolygonGeometry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PolygonGeometry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RenderConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.RenderConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RenderConfiguration>
    {
        public RenderConfiguration(string id, string name) { }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.RenderOptionCondition> Conditions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.RenderOptionLegend Legend { get { throw null; } set { } }
        public int? MinZoom { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Options { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.RenderOptionType? Type { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.RenderOptionVectorOptions VectorOptions { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.RenderConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.RenderConfiguration (Azure.Response result) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.PlanetaryComputer.RenderConfiguration renderConfiguration) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.RenderConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.RenderConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.RenderConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.RenderConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.RenderConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RenderConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RenderConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RenderConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RenderOptionCondition : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.RenderOptionCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RenderOptionCondition>
    {
        public RenderOptionCondition(string property) { }
        public string Property { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.RenderOptionCondition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.RenderOptionCondition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.RenderOptionCondition System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.RenderOptionCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.RenderOptionCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.RenderOptionCondition System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RenderOptionCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RenderOptionCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RenderOptionCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RenderOptionLegend : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.RenderOptionLegend>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RenderOptionLegend>
    {
        public RenderOptionLegend() { }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        public float? ScaleFactor { get { throw null; } set { } }
        public int? TrimEnd { get { throw null; } set { } }
        public int? TrimStart { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.LegendConfigType? Type { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.RenderOptionLegend JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.RenderOptionLegend PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.RenderOptionLegend System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.RenderOptionLegend>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.RenderOptionLegend>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.RenderOptionLegend System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RenderOptionLegend>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RenderOptionLegend>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RenderOptionLegend>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RenderOptionType : System.IEquatable<Azure.Analytics.PlanetaryComputer.RenderOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RenderOptionType(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.RenderOptionType RasterTile { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.RenderOptionType VtLine { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.RenderOptionType VtPolygon { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.RenderOptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.RenderOptionType left, Azure.Analytics.PlanetaryComputer.RenderOptionType right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.RenderOptionType (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.RenderOptionType? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.RenderOptionType left, Azure.Analytics.PlanetaryComputer.RenderOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RenderOptionVectorOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.RenderOptionVectorOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RenderOptionVectorOptions>
    {
        public RenderOptionVectorOptions(string tilejsonKey, string sourceLayer) { }
        public string FillColor { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Filter { get { throw null; } }
        public string SourceLayer { get { throw null; } set { } }
        public string StrokeColor { get { throw null; } set { } }
        public int? StrokeWidth { get { throw null; } set { } }
        public string TilejsonKey { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.RenderOptionVectorOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.RenderOptionVectorOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.RenderOptionVectorOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.RenderOptionVectorOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.RenderOptionVectorOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.RenderOptionVectorOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RenderOptionVectorOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RenderOptionVectorOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RenderOptionVectorOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResamplingMethod : System.IEquatable<Azure.Analytics.PlanetaryComputer.ResamplingMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResamplingMethod(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.ResamplingMethod Average { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ResamplingMethod Bilinear { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ResamplingMethod Cubic { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ResamplingMethod CubicSpline { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ResamplingMethod Gauss { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ResamplingMethod Lanczos { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ResamplingMethod Mode { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ResamplingMethod Nearest { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ResamplingMethod Rms { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.ResamplingMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.ResamplingMethod left, Azure.Analytics.PlanetaryComputer.ResamplingMethod right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.ResamplingMethod (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.ResamplingMethod? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.ResamplingMethod left, Azure.Analytics.PlanetaryComputer.ResamplingMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchOptionsFields : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.SearchOptionsFields>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SearchOptionsFields>
    {
        public SearchOptionsFields() { }
        public System.Collections.Generic.IList<string> Exclude { get { throw null; } }
        public System.Collections.Generic.IList<string> Include { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.SearchOptionsFields JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.SearchOptionsFields PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.SearchOptionsFields System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.SearchOptionsFields>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.SearchOptionsFields>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.SearchOptionsFields System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SearchOptionsFields>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SearchOptionsFields>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SearchOptionsFields>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedAccessSignatureSignedLink : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink>
    {
        internal SharedAccessSignatureSignedLink() { }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public System.Uri Href { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink (Azure.Response result) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedAccessSignatureToken : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureToken>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureToken>
    {
        internal SharedAccessSignatureToken() { }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public string Token { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.SharedAccessSignatureToken JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.SharedAccessSignatureToken (Azure.Response result) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.SharedAccessSignatureToken PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.SharedAccessSignatureToken System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureToken>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureToken>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.SharedAccessSignatureToken System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureToken>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureToken>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureToken>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedAccessSignatureTokenConnection : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenConnection>
    {
        public SharedAccessSignatureTokenConnection(System.Uri containerUri) { }
        public System.Uri ContainerUri { get { throw null; } set { } }
        public System.DateTimeOffset? Expiration { get { throw null; } }
        public string SharedAccessSignatureToken { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenConnection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenConnection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenConnection System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenConnection System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedAccessSignatureTokenIngestionSource : Azure.Analytics.PlanetaryComputer.IngestionSource, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenIngestionSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenIngestionSource>
    {
        public SharedAccessSignatureTokenIngestionSource(System.Guid id, Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenConnection connectionInfo) { }
        public Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenConnection ConnectionInfo { get { throw null; } set { } }
        protected override Azure.Analytics.PlanetaryComputer.IngestionSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Analytics.PlanetaryComputer.IngestionSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenIngestionSource System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenIngestionSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenIngestionSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenIngestionSource System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenIngestionSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenIngestionSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenIngestionSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacAsset : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacAsset>
    {
        public StacAsset(string href) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Constellation { get { throw null; } set { } }
        public System.DateTimeOffset? Created { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public float? Gsd { get { throw null; } set { } }
        public string Href { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Instruments { get { throw null; } }
        public string Mission { get { throw null; } set { } }
        public string Platform { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacProvider> Providers { get { throw null; } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string Title { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public System.DateTimeOffset? Updated { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacAsset JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.StacAsset PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacAsset System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacAsset System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StacAssetUrlSigningMode : System.IEquatable<Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StacAssetUrlSigningMode(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode False { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode True { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode left, Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode left, Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StacCatalogCollections : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacCatalogCollections>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacCatalogCollections>
    {
        internal StacCatalogCollections() { }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacCollectionResource> Collections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacLink> Links { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacCatalogCollections JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.StacCatalogCollections (Azure.Response result) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.StacCatalogCollections PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacCatalogCollections System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacCatalogCollections>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacCatalogCollections>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacCatalogCollections System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacCatalogCollections>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacCatalogCollections>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacCatalogCollections>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacClient
    {
        protected StacClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacMosaic> AddMosaic(string collectionId, Azure.Analytics.PlanetaryComputer.StacMosaic body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddMosaic(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacMosaic>> AddMosaicAsync(string collectionId, Azure.Analytics.PlanetaryComputer.StacMosaic body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddMosaicAsync(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation CreateCollection(Azure.WaitUntil waitUntil, Azure.Analytics.PlanetaryComputer.StacCollectionResource body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CreateCollection(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateCollectionAsset(string collectionId, Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateCollectionAssetAsync(string collectionId, Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateCollectionAsync(Azure.WaitUntil waitUntil, Azure.Analytics.PlanetaryComputer.StacCollectionResource body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateCollectionAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation CreateItem(Azure.WaitUntil waitUntil, string collectionId, Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CreateItem(Azure.WaitUntil waitUntil, string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateItemAsync(Azure.WaitUntil waitUntil, string collectionId, Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateItemAsync(Azure.WaitUntil waitUntil, string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacCollectionResource> CreateOrReplaceCollection(string collectionId, Azure.Analytics.PlanetaryComputer.StacCollectionResource body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplaceCollection(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacCollectionResource>> CreateOrReplaceCollectionAsync(string collectionId, Azure.Analytics.PlanetaryComputer.StacCollectionResource body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceCollectionAsync(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation CreateOrReplaceItem(Azure.WaitUntil waitUntil, string collectionId, string itemId, Azure.Analytics.PlanetaryComputer.StacItemResource body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CreateOrReplaceItem(Azure.WaitUntil waitUntil, string collectionId, string itemId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateOrReplaceItemAsync(Azure.WaitUntil waitUntil, string collectionId, string itemId, Azure.Analytics.PlanetaryComputer.StacItemResource body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateOrReplaceItemAsync(Azure.WaitUntil waitUntil, string collectionId, string itemId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateQueryables(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.PlanetaryComputer.StacQueryable>> CreateQueryables(string collectionId, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacQueryable> body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateQueryablesAsync(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.PlanetaryComputer.StacQueryable>>> CreateQueryablesAsync(string collectionId, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacQueryable> body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.RenderConfiguration> CreateRenderOption(string collectionId, Azure.Analytics.PlanetaryComputer.RenderConfiguration body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateRenderOption(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.RenderConfiguration>> CreateRenderOptionAsync(string collectionId, Azure.Analytics.PlanetaryComputer.RenderConfiguration body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateRenderOptionAsync(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteCollection(Azure.WaitUntil waitUntil, string collectionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation DeleteCollection(Azure.WaitUntil waitUntil, string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteCollectionAsset(string collectionId, string assetId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacCollectionResource> DeleteCollectionAsset(string collectionId, string assetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteCollectionAssetAsync(string collectionId, string assetId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacCollectionResource>> DeleteCollectionAssetAsync(string collectionId, string assetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteCollectionAsync(Azure.WaitUntil waitUntil, string collectionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteCollectionAsync(Azure.WaitUntil waitUntil, string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation DeleteItem(Azure.WaitUntil waitUntil, string collectionId, string itemId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation DeleteItem(Azure.WaitUntil waitUntil, string collectionId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteItemAsync(Azure.WaitUntil waitUntil, string collectionId, string itemId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteItemAsync(Azure.WaitUntil waitUntil, string collectionId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteMosaic(string collectionId, string mosaicId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteMosaic(string collectionId, string mosaicId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteMosaicAsync(string collectionId, string mosaicId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteMosaicAsync(string collectionId, string mosaicId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteQueryable(string collectionId, string queryableName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteQueryable(string collectionId, string queryableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteQueryableAsync(string collectionId, string queryableName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteQueryableAsync(string collectionId, string queryableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRenderOption(string collectionId, string renderOptionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteRenderOption(string collectionId, string renderOptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRenderOptionAsync(string collectionId, string renderOptionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRenderOptionAsync(string collectionId, string renderOptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacCollectionResource> GetCollection(string collectionId, Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode? sign = default(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode?), int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCollection(string collectionId, string sign, int? durationInMinutes, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacCollectionResource>> GetCollectionAsync(string collectionId, Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode? sign = default(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode?), int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionAsync(string collectionId, string sign, int? durationInMinutes, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetCollectionConfiguration(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.UserCollectionSettings> GetCollectionConfiguration(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionConfigurationAsync(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.UserCollectionSettings>> GetCollectionConfigurationAsync(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCollectionQueryables(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData>> GetCollectionQueryables(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionQueryablesAsync(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData>>> GetCollectionQueryablesAsync(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacCatalogCollections> GetCollections(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode? sign = default(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode?), int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCollections(string sign, int? durationInMinutes, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacCatalogCollections>> GetCollectionsAsync(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode? sign = default(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode?), int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionsAsync(string sign, int? durationInMinutes, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetCollectionThumbnail(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetCollectionThumbnail(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionThumbnailAsync(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetCollectionThumbnailAsync(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetConformanceClass(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacConformanceClasses> GetConformanceClass(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConformanceClassAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacConformanceClasses>> GetConformanceClassAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetItem(string collectionId, string itemId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacItemResource> GetItem(string collectionId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetItemAsync(string collectionId, string itemId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacItemResource>> GetItemAsync(string collectionId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetItemCollection(string collectionId, int? limit, System.Collections.Generic.IEnumerable<string> boundingBox, string datetime, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacItemCollectionResource> GetItemCollection(string collectionId, int? limit = default(int?), System.Collections.Generic.IEnumerable<string> boundingBox = null, string datetime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetItemCollectionAsync(string collectionId, int? limit, System.Collections.Generic.IEnumerable<string> boundingBox, string datetime, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacItemCollectionResource>> GetItemCollectionAsync(string collectionId, int? limit = default(int?), System.Collections.Generic.IEnumerable<string> boundingBox = null, string datetime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetLandingPage(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacLandingPage> GetLandingPage(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLandingPageAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacLandingPage>> GetLandingPageAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetMosaic(string collectionId, string mosaicId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacMosaic> GetMosaic(string collectionId, string mosaicId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMosaicAsync(string collectionId, string mosaicId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacMosaic>> GetMosaicAsync(string collectionId, string mosaicId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetMosaics(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.PlanetaryComputer.StacMosaic>> GetMosaics(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMosaicsAsync(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.PlanetaryComputer.StacMosaic>>> GetMosaicsAsync(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPartitionType(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.PartitionType> GetPartitionType(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPartitionTypeAsync(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.PartitionType>> GetPartitionTypeAsync(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetQueryables(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData>> GetQueryables(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetQueryablesAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData>>> GetQueryablesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRenderOption(string collectionId, string renderOptionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.RenderConfiguration> GetRenderOption(string collectionId, string renderOptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRenderOptionAsync(string collectionId, string renderOptionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.RenderConfiguration>> GetRenderOptionAsync(string collectionId, string renderOptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRenderOptions(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.PlanetaryComputer.RenderConfiguration>> GetRenderOptions(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRenderOptionsAsync(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.PlanetaryComputer.RenderConfiguration>>> GetRenderOptionsAsync(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTileSettings(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TileSettings> GetTileSettings(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTileSettingsAsync(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TileSettings>> GetTileSettingsAsync(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReplaceCollectionAsset(string collectionId, string assetId, Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplaceCollectionAssetAsync(string collectionId, string assetId, Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacMosaic> ReplaceMosaic(string collectionId, string mosaicId, Azure.Analytics.PlanetaryComputer.StacMosaic body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReplaceMosaic(string collectionId, string mosaicId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacMosaic>> ReplaceMosaicAsync(string collectionId, string mosaicId, Azure.Analytics.PlanetaryComputer.StacMosaic body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplaceMosaicAsync(string collectionId, string mosaicId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response ReplacePartitionType(string collectionId, Azure.Analytics.PlanetaryComputer.PartitionType body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReplacePartitionType(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplacePartitionTypeAsync(string collectionId, Azure.Analytics.PlanetaryComputer.PartitionType body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplacePartitionTypeAsync(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacQueryable> ReplaceQueryable(string collectionId, string queryableName, Azure.Analytics.PlanetaryComputer.StacQueryable body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReplaceQueryable(string collectionId, string queryableName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacQueryable>> ReplaceQueryableAsync(string collectionId, string queryableName, Azure.Analytics.PlanetaryComputer.StacQueryable body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplaceQueryableAsync(string collectionId, string queryableName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.RenderConfiguration> ReplaceRenderOption(string collectionId, string renderOptionId, Azure.Analytics.PlanetaryComputer.RenderConfiguration body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReplaceRenderOption(string collectionId, string renderOptionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.RenderConfiguration>> ReplaceRenderOptionAsync(string collectionId, string renderOptionId, Azure.Analytics.PlanetaryComputer.RenderConfiguration body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplaceRenderOptionAsync(string collectionId, string renderOptionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TileSettings> ReplaceTileSettings(string collectionId, Azure.Analytics.PlanetaryComputer.TileSettings body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReplaceTileSettings(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TileSettings>> ReplaceTileSettingsAsync(string collectionId, Azure.Analytics.PlanetaryComputer.TileSettings body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplaceTileSettingsAsync(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacItemCollectionResource> Search(Azure.Analytics.PlanetaryComputer.StacSearchParameters body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Search(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacItemCollectionResource>> SearchAsync(Azure.Analytics.PlanetaryComputer.StacSearchParameters body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SearchAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation UpdateItem(Azure.WaitUntil waitUntil, string collectionId, string itemId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> UpdateItemAsync(Azure.WaitUntil waitUntil, string collectionId, string itemId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class StacCollectionResource : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacCollectionResource>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacCollectionResource>
    {
        public StacCollectionResource(string id, string description, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacLink> links, string license, Azure.Analytics.PlanetaryComputer.StacExtensionExtent extent) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.StacAsset> Assets { get { throw null; } }
        public string CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.StacExtensionExtent Extent { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.StacItemAsset> ItemAssets { get { throw null; } }
        public System.Collections.Generic.IList<string> Keywords { get { throw null; } }
        public string License { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacLink> Links { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacProvider> Providers { get { throw null; } }
        public string ShortDescription { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> StacExtensions { get { throw null; } }
        public string StacVersion { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Summaries { get { throw null; } }
        public string Title { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public string UpdatedOn { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacCollectionResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.StacCollectionResource (Azure.Response result) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.PlanetaryComputer.StacCollectionResource stacCollectionResource) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.StacCollectionResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacCollectionResource System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacCollectionResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacCollectionResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacCollectionResource System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacCollectionResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacCollectionResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacCollectionResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacCollectionTemporalExtent : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacCollectionTemporalExtent>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacCollectionTemporalExtent>
    {
        public StacCollectionTemporalExtent(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<string>> interval) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> Interval { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacCollectionTemporalExtent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.StacCollectionTemporalExtent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacCollectionTemporalExtent System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacCollectionTemporalExtent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacCollectionTemporalExtent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacCollectionTemporalExtent System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacCollectionTemporalExtent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacCollectionTemporalExtent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacCollectionTemporalExtent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacConformanceClasses : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacConformanceClasses>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacConformanceClasses>
    {
        internal StacConformanceClasses() { }
        public System.Collections.Generic.IList<System.Uri> ConformsTo { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacConformanceClasses JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.StacConformanceClasses (Azure.Response result) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.StacConformanceClasses PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacConformanceClasses System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacConformanceClasses>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacConformanceClasses>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacConformanceClasses System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacConformanceClasses>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacConformanceClasses>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacConformanceClasses>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacContextExtension : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacContextExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacContextExtension>
    {
        public StacContextExtension(int returned) { }
        public int? Limit { get { throw null; } set { } }
        public int? Matched { get { throw null; } set { } }
        public int Returned { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacContextExtension JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.StacContextExtension PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacContextExtension System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacContextExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacContextExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacContextExtension System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacContextExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacContextExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacContextExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacExtensionExtent : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacExtensionExtent>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacExtensionExtent>
    {
        public StacExtensionExtent(Azure.Analytics.PlanetaryComputer.StacExtensionSpatialExtent spatial, Azure.Analytics.PlanetaryComputer.StacCollectionTemporalExtent temporal) { }
        public Azure.Analytics.PlanetaryComputer.StacExtensionSpatialExtent Spatial { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.StacCollectionTemporalExtent Temporal { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacExtensionExtent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.StacExtensionExtent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacExtensionExtent System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacExtensionExtent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacExtensionExtent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacExtensionExtent System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacExtensionExtent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacExtensionExtent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacExtensionExtent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacExtensionSpatialExtent : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacExtensionSpatialExtent>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacExtensionSpatialExtent>
    {
        public StacExtensionSpatialExtent() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<float>> BoundingBox { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacExtensionSpatialExtent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.StacExtensionSpatialExtent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacExtensionSpatialExtent System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacExtensionSpatialExtent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacExtensionSpatialExtent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacExtensionSpatialExtent System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacExtensionSpatialExtent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacExtensionSpatialExtent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacExtensionSpatialExtent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacItemAsset : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemAsset>
    {
        public StacItemAsset(string title, string type) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Constellation { get { throw null; } set { } }
        public System.DateTimeOffset? Created { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public float? Gsd { get { throw null; } set { } }
        public string Href { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Instruments { get { throw null; } }
        public string Mission { get { throw null; } set { } }
        public string Platform { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacProvider> Providers { get { throw null; } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string Title { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public System.DateTimeOffset? Updated { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacItemAsset JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.StacItemAsset PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacItemAsset System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacItemAsset System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacItemBounds : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemBounds>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemBounds>
    {
        internal StacItemBounds() { }
        public System.Collections.Generic.IList<float> Bounds { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacItemBounds JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.StacItemBounds (Azure.Response result) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.StacItemBounds PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacItemBounds System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemBounds>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemBounds>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacItemBounds System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemBounds>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemBounds>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemBounds>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacItemCollectionResource : Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemCollectionResource>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemCollectionResource>
    {
        public StacItemCollectionResource(System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacItemResource> features) { }
        public System.Collections.Generic.IList<float> BoundingBox { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.StacContextExtension Context { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacItemResource> Features { get { throw null; } }
        protected override Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.StacItemCollectionResource (Azure.Response result) { throw null; }
        protected override Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacItemCollectionResource System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemCollectionResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemCollectionResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacItemCollectionResource System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemCollectionResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemCollectionResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemCollectionResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class StacItemOrStacItemCollection : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection>
    {
        internal StacItemOrStacItemCollection() { }
        public string CreatedOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacLink> Links { get { throw null; } }
        public string ShortDescription { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> StacExtensions { get { throw null; } }
        public string StacVersion { get { throw null; } set { } }
        public string UpdatedOn { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection stacItemOrStacItemCollection) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacItemPointAsset : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemPointAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemPointAsset>
    {
        internal StacItemPointAsset() { }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.StacAsset> Assets { get { throw null; } }
        public System.Collections.Generic.IList<float> BoundingBox { get { throw null; } }
        public string CollectionId { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacItemPointAsset JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.StacItemPointAsset PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacItemPointAsset System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemPointAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemPointAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacItemPointAsset System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemPointAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemPointAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemPointAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacItemProperties : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemProperties>
    {
        public StacItemProperties(string datetime) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Constellation { get { throw null; } set { } }
        public System.DateTimeOffset? Created { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndDatetime { get { throw null; } set { } }
        public float? Gsd { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Instruments { get { throw null; } }
        public string Mission { get { throw null; } set { } }
        public string Platform { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacProvider> Providers { get { throw null; } }
        public System.DateTimeOffset? StartDatetime { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public System.DateTimeOffset? Updated { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacItemProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.StacItemProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacItemProperties System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacItemProperties System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacItemResource : Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemResource>
    {
        public StacItemResource(Azure.Analytics.PlanetaryComputer.GeoJsonGeometry geometry, string id, System.Collections.Generic.IEnumerable<float> boundingBox, Azure.Analytics.PlanetaryComputer.StacItemProperties properties, System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.StacAsset> assets) { }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.StacAsset> Assets { get { throw null; } }
        public System.Collections.Generic.IList<float> BoundingBox { get { throw null; } }
        public string Collection { get { throw null; } set { } }
        public string ETag { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.GeoJsonGeometry Geometry { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.StacItemProperties Properties { get { throw null; } set { } }
        public string Timestamp { get { throw null; } set { } }
        protected override Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.StacItemResource (Azure.Response result) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.PlanetaryComputer.StacItemResource stacItemResource) { throw null; }
        protected override Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacItemResource System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacItemResource System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacItemStatisticsGeoJson : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson>
    {
        internal StacItemStatisticsGeoJson() { }
        public Azure.Analytics.PlanetaryComputer.GeoJsonGeometry Geometry { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJsonProperties Properties { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.FeatureType Type { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson (Azure.Response result) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacItemStatisticsGeoJsonProperties : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJsonProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJsonProperties>
    {
        internal StacItemStatisticsGeoJsonProperties() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.BandStatistics> Statistics { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJsonProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJsonProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJsonProperties System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJsonProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJsonProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJsonProperties System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJsonProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJsonProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJsonProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacLandingPage : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacLandingPage>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacLandingPage>
    {
        internal StacLandingPage() { }
        public System.Collections.Generic.IList<System.Uri> ConformsTo { get { throw null; } }
        public string CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacLink> Links { get { throw null; } }
        public string ShortDescription { get { throw null; } }
        public System.Collections.Generic.IList<string> StacExtensions { get { throw null; } }
        public string StacVersion { get { throw null; } }
        public string Title { get { throw null; } }
        public string Type { get { throw null; } }
        public string UpdatedOn { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacLandingPage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.StacLandingPage (Azure.Response result) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.StacLandingPage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacLandingPage System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacLandingPage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacLandingPage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacLandingPage System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacLandingPage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacLandingPage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacLandingPage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacLink : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacLink>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacLink>
    {
        public StacLink(string href) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Body { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Headers { get { throw null; } }
        public string Href { get { throw null; } set { } }
        public string Hreflang { get { throw null; } set { } }
        public int? Length { get { throw null; } set { } }
        public bool? Merge { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.StacLinkMethod? Method { get { throw null; } set { } }
        public string Rel { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.StacLinkType? Type { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacLink JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.StacLink PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacLink System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacLink System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StacLinkMethod : System.IEquatable<Azure.Analytics.PlanetaryComputer.StacLinkMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StacLinkMethod(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacLinkMethod GET { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkMethod POST { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.StacLinkMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.StacLinkMethod left, Azure.Analytics.PlanetaryComputer.StacLinkMethod right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.StacLinkMethod (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.StacLinkMethod? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.StacLinkMethod left, Azure.Analytics.PlanetaryComputer.StacLinkMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StacLinkType : System.IEquatable<Azure.Analytics.PlanetaryComputer.StacLinkType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StacLinkType(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacLinkType ApplicationGeoJson { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkType ApplicationJson { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkType ApplicationXBinary { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkType ApplicationXml { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkType ApplicationXProtobuf { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkType ImageJp2 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkType ImageJpeg { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkType ImageJpg { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkType ImagePng { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkType ImageTiffApplicationGeotiff { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkType ImageWebp { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkType TextHtml { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkType TextPlain { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.StacLinkType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.StacLinkType left, Azure.Analytics.PlanetaryComputer.StacLinkType right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.StacLinkType (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.StacLinkType? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.StacLinkType left, Azure.Analytics.PlanetaryComputer.StacLinkType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StacMosaic : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacMosaic>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacMosaic>
    {
        public StacMosaic(string id, string name, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> cql) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> Cql { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacMosaic JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.StacMosaic (Azure.Response result) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.PlanetaryComputer.StacMosaic stacMosaic) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.StacMosaic PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacMosaic System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacMosaic>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacMosaic>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacMosaic System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacMosaic>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacMosaic>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacMosaic>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacMosaicConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacMosaicConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacMosaicConfiguration>
    {
        internal StacMosaicConfiguration() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> DefaultCustomQuery { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.DefaultLocation DefaultLocation { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacMosaic> Mosaics { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.RenderConfiguration> RenderOptions { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacMosaicConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.StacMosaicConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacMosaicConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacMosaicConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacMosaicConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacMosaicConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacMosaicConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacMosaicConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacMosaicConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacProvider : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacProvider>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacProvider>
    {
        public StacProvider(string name) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string Url { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacProvider JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.StacProvider PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacProvider System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacProvider>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacProvider>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacProvider System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacProvider>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacProvider>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacProvider>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacQueryable : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacQueryable>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacQueryable>
    {
        public StacQueryable(string name, System.Collections.Generic.IDictionary<string, System.BinaryData> definition) { }
        public bool? CreateIndex { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataType? DataType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Definition { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacQueryable JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.StacQueryable (Azure.Response result) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.PlanetaryComputer.StacQueryable stacQueryable) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.StacQueryable PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacQueryable System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacQueryable>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacQueryable>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacQueryable System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacQueryable>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacQueryable>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacQueryable>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StacQueryableDefinitionDataType : System.IEquatable<Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StacQueryableDefinitionDataType(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataType Boolean { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataType Date { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataType Number { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataType String { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataType Timestamp { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataType left, Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataType right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataType (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataType? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataType left, Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StacSearchParameters : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacSearchParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacSearchParameters>
    {
        public StacSearchParameters() { }
        public System.Collections.Generic.IList<float> BoundingBox { get { throw null; } }
        public System.Collections.Generic.IList<string> Collections { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ConformanceClass { get { throw null; } }
        public string Datetime { get { throw null; } set { } }
        public int? DurationInMinutes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.SearchOptionsFields> Fields { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Filter { get { throw null; } }
        public string FilterCoordinateReferenceSystem { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.FilterLanguage? FilterLang { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Ids { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.GeoJsonGeometry Intersects { get { throw null; } set { } }
        public int? Limit { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Query { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode? Sign { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacSortExtension> SortBy { get { throw null; } }
        public string Token { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacSearchParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.PlanetaryComputer.StacSearchParameters stacSearchParameters) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.StacSearchParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacSearchParameters System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacSearchParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacSearchParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacSearchParameters System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacSearchParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacSearchParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacSearchParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StacSearchSortingDirection : System.IEquatable<Azure.Analytics.PlanetaryComputer.StacSearchSortingDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StacSearchSortingDirection(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacSearchSortingDirection Asc { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacSearchSortingDirection Desc { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.StacSearchSortingDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.StacSearchSortingDirection left, Azure.Analytics.PlanetaryComputer.StacSearchSortingDirection right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.StacSearchSortingDirection (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.StacSearchSortingDirection? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.StacSearchSortingDirection left, Azure.Analytics.PlanetaryComputer.StacSearchSortingDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StacSortExtension : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacSortExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacSortExtension>
    {
        public StacSortExtension(string field, Azure.Analytics.PlanetaryComputer.StacSearchSortingDirection direction) { }
        public Azure.Analytics.PlanetaryComputer.StacSearchSortingDirection Direction { get { throw null; } }
        public string Field { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacSortExtension JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.StacSortExtension PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacSortExtension System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacSortExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacSortExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacSortExtension System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacSortExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacSortExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacSortExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TerrainAlgorithm : System.IEquatable<Azure.Analytics.PlanetaryComputer.TerrainAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TerrainAlgorithm(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TerrainAlgorithm Contours { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TerrainAlgorithm Hillshade { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TerrainAlgorithm NormalizedIndex { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TerrainAlgorithm Terrainrgb { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TerrainAlgorithm Terrarium { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm left, Azure.Analytics.PlanetaryComputer.TerrainAlgorithm right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.TerrainAlgorithm (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm left, Azure.Analytics.PlanetaryComputer.TerrainAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TileAddressingScheme : System.IEquatable<Azure.Analytics.PlanetaryComputer.TileAddressingScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TileAddressingScheme(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TileAddressingScheme Tms { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TileAddressingScheme Xyz { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.TileAddressingScheme other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.TileAddressingScheme left, Azure.Analytics.PlanetaryComputer.TileAddressingScheme right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.TileAddressingScheme (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.TileAddressingScheme? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.TileAddressingScheme left, Azure.Analytics.PlanetaryComputer.TileAddressingScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TileJsonMetadata : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileJsonMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileJsonMetadata>
    {
        internal TileJsonMetadata() { }
        public string Attribution { get { throw null; } }
        public System.Collections.Generic.IList<float> Bounds { get { throw null; } }
        public System.Collections.Generic.IList<float> Center { get { throw null; } }
        public System.Collections.Generic.IList<string> Data { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IList<string> Grids { get { throw null; } }
        public string Legend { get { throw null; } }
        public int? MaxZoom { get { throw null; } }
        public int? MinZoom { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.TileAddressingScheme? Scheme { get { throw null; } }
        public string Template { get { throw null; } }
        public string TileJson { get { throw null; } }
        public System.Collections.Generic.IList<string> Tiles { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TileJsonMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.TileJsonMetadata (Azure.Response result) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.TileJsonMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TileJsonMetadata System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileJsonMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileJsonMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TileJsonMetadata System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileJsonMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileJsonMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileJsonMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TileMatrix : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileMatrix>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileMatrix>
    {
        internal TileMatrix() { }
        public float CellSize { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixCornerOfOrigin? CornerOfOrigin { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<string> Keywords { get { throw null; } }
        public int MatrixHeight { get { throw null; } }
        public int MatrixWidth { get { throw null; } }
        public System.Collections.Generic.IList<float> PointOfOrigin { get { throw null; } }
        public float ScaleDenominator { get { throw null; } }
        public int TileHeight { get { throw null; } }
        public int TileWidth { get { throw null; } }
        public string Title { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.VariableMatrixWidth> VariableMatrixWidths { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TileMatrix JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.TileMatrix PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TileMatrix System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileMatrix>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileMatrix>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TileMatrix System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileMatrix>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileMatrix>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileMatrix>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TileMatrixCornerOfOrigin : System.IEquatable<Azure.Analytics.PlanetaryComputer.TileMatrixCornerOfOrigin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TileMatrixCornerOfOrigin(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TileMatrixCornerOfOrigin BottomLeft { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TileMatrixCornerOfOrigin TopLeft { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.TileMatrixCornerOfOrigin other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.TileMatrixCornerOfOrigin left, Azure.Analytics.PlanetaryComputer.TileMatrixCornerOfOrigin right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.TileMatrixCornerOfOrigin (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.TileMatrixCornerOfOrigin? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.TileMatrixCornerOfOrigin left, Azure.Analytics.PlanetaryComputer.TileMatrixCornerOfOrigin right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TileMatrixSet : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileMatrixSet>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileMatrixSet>
    {
        internal TileMatrixSet() { }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetBoundingBox BoundingBox { get { throw null; } }
        public string Crs { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<string> Keywords { get { throw null; } }
        public System.Collections.Generic.IList<string> OrderedAxes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.TileMatrix> TileMatrices { get { throw null; } }
        public string Title { get { throw null; } }
        public string Uri { get { throw null; } }
        public System.Uri WellKnownScaleSet { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TileMatrixSet JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.TileMatrixSet (Azure.Response result) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.TileMatrixSet PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TileMatrixSet System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileMatrixSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileMatrixSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TileMatrixSet System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileMatrixSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileMatrixSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileMatrixSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TileMatrixSetBoundingBox : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileMatrixSetBoundingBox>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileMatrixSetBoundingBox>
    {
        internal TileMatrixSetBoundingBox() { }
        public string Crs { get { throw null; } }
        public System.Collections.Generic.IList<string> LowerLeft { get { throw null; } }
        public System.Collections.Generic.IList<string> OrderedAxes { get { throw null; } }
        public System.Collections.Generic.IList<string> UpperRight { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TileMatrixSetBoundingBox JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.TileMatrixSetBoundingBox PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TileMatrixSetBoundingBox System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileMatrixSetBoundingBox>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileMatrixSetBoundingBox>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TileMatrixSetBoundingBox System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileMatrixSetBoundingBox>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileMatrixSetBoundingBox>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileMatrixSetBoundingBox>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TilerCoreModelsResponsesPoint : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint>
    {
        internal TilerCoreModelsResponsesPoint() { }
        public System.Collections.Generic.IList<string> BandNames { get { throw null; } }
        public System.Collections.Generic.IList<float> Coordinates { get { throw null; } }
        public System.Collections.Generic.IList<float> Values { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint (Azure.Response result) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TilerImageFormat : System.IEquatable<Azure.Analytics.PlanetaryComputer.TilerImageFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TilerImageFormat(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TilerImageFormat Jp2 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TilerImageFormat Jpeg { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TilerImageFormat Jpg { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TilerImageFormat Npy { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TilerImageFormat Png { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TilerImageFormat Pngraw { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TilerImageFormat Tif { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TilerImageFormat Webp { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.TilerImageFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.TilerImageFormat left, Azure.Analytics.PlanetaryComputer.TilerImageFormat right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.TilerImageFormat (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.TilerImageFormat? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.TilerImageFormat left, Azure.Analytics.PlanetaryComputer.TilerImageFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TilerInfo : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerInfo>
    {
        internal TilerInfo() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> BandDescriptions { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<System.BinaryData>> BandMetadata { get { throw null; } }
        public System.Collections.Generic.IList<float> Bounds { get { throw null; } }
        public System.Collections.Generic.IList<string> ColorInterpretation { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Colormap { get { throw null; } }
        public string CoordinateReferenceSystem { get { throw null; } }
        public int? Count { get { throw null; } }
        public string Driver { get { throw null; } }
        public string Dtype { get { throw null; } }
        public int? Height { get { throw null; } }
        public int? MaxZoom { get { throw null; } }
        public int? MinZoom { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.NoDataType? NoDataType { get { throw null; } }
        public System.Collections.Generic.IList<int> Offsets { get { throw null; } }
        public System.Collections.Generic.IList<int> Overviews { get { throw null; } }
        public System.Collections.Generic.IList<int> Scales { get { throw null; } }
        public int? Width { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TilerInfo System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TilerInfo System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TilerInfoGeoJsonFeature : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature>
    {
        internal TilerInfoGeoJsonFeature() { }
        public float? BoundingBox { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.GeoJsonGeometry Geometry { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.TilerInfo> Properties { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.FeatureType Type { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature (Azure.Response result) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TilerMosaicSearchRegistrationResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult>
    {
        internal TilerMosaicSearchRegistrationResult() { }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacLink> Links { get { throw null; } }
        public string SearchId { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult (Azure.Response result) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TilerStacItemStatistics : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerStacItemStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerStacItemStatistics>
    {
        internal TilerStacItemStatistics() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerStacItemStatistics JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.TilerStacItemStatistics (Azure.Response result) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerStacItemStatistics PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TilerStacItemStatistics System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerStacItemStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerStacItemStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TilerStacItemStatistics System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerStacItemStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerStacItemStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerStacItemStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TilerStacSearchDefinition : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerStacSearchDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerStacSearchDefinition>
    {
        internal TilerStacSearchDefinition() { }
        public string Hash { get { throw null; } }
        public System.DateTimeOffset LastUsed { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.MosaicMetadata Metadata { get { throw null; } }
        public string OrderBy { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Search { get { throw null; } }
        public int UseCount { get { throw null; } }
        public string Where { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerStacSearchDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerStacSearchDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TilerStacSearchDefinition System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerStacSearchDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerStacSearchDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TilerStacSearchDefinition System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerStacSearchDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerStacSearchDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerStacSearchDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TilerStacSearchRegistration : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration>
    {
        internal TilerStacSearchRegistration() { }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacLink> Links { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.TilerStacSearchDefinition Search { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration (Azure.Response result) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TileSettings : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSettings>
    {
        public TileSettings(int minZoom, int maxItemsPerTile) { }
        public Azure.Analytics.PlanetaryComputer.DefaultLocation DefaultLocation { get { throw null; } set { } }
        public int MaxItemsPerTile { get { throw null; } set { } }
        public int MinZoom { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.TileSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.TileSettings (Azure.Response result) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.PlanetaryComputer.TileSettings tileSettings) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.TileSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TileSettings System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TileSettings System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserCollectionSettings : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.UserCollectionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.UserCollectionSettings>
    {
        internal UserCollectionSettings() { }
        public Azure.Analytics.PlanetaryComputer.StacMosaicConfiguration MosaicConfiguration { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.TileSettings TileSettings { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.UserCollectionSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.UserCollectionSettings (Azure.Response result) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.UserCollectionSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.UserCollectionSettings System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.UserCollectionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.UserCollectionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.UserCollectionSettings System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.UserCollectionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.UserCollectionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.UserCollectionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VariableMatrixWidth : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.VariableMatrixWidth>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.VariableMatrixWidth>
    {
        internal VariableMatrixWidth() { }
        public int Coalesce { get { throw null; } }
        public int MaxTileRow { get { throw null; } }
        public int MinTileRow { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.VariableMatrixWidth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.VariableMatrixWidth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.VariableMatrixWidth System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.VariableMatrixWidth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.VariableMatrixWidth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.VariableMatrixWidth System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.VariableMatrixWidth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.VariableMatrixWidth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.VariableMatrixWidth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class PlanetaryComputerClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.PlanetaryComputer.PlanetaryComputerProClient, Azure.Analytics.PlanetaryComputer.PlanetaryComputerProClientOptions> AddPlanetaryComputerProClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.PlanetaryComputer.PlanetaryComputerProClient, Azure.Analytics.PlanetaryComputer.PlanetaryComputerProClientOptions> AddPlanetaryComputerProClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
