namespace Azure.Analytics.PlanetaryComputer
{
    public partial class AssetMetadata : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.AssetMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.AssetMetadata>
    {
        public AssetMetadata(string key, string kind, System.Collections.Generic.IEnumerable<string> roles, string title, string description) { }
        public string Description { get { throw null; } }
        public string Key { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.AssetMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.AssetMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.AssetMetadata System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.AssetMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.AssetMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.AssetMetadata System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.AssetMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.AssetMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.AssetMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetStatisticsResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.AssetStatisticsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.AssetStatisticsResult>
    {
        internal AssetStatisticsResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.AssetStatisticsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.AssetStatisticsResult (Azure.Response response) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.AssetStatisticsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.AssetStatisticsResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.AssetStatisticsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.AssetStatisticsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.AssetStatisticsResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.AssetStatisticsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.AssetStatisticsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.AssetStatisticsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
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
    public partial class ClassMapLegendResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ClassMapLegendResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ClassMapLegendResult>
    {
        internal ClassMapLegendResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.ClassMapLegendResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.ClassMapLegendResult (Azure.Response response) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.ClassMapLegendResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.ClassMapLegendResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ClassMapLegendResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.ClassMapLegendResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.ClassMapLegendResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ClassMapLegendResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ClassMapLegendResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.ClassMapLegendResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Algae { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames AlgaeR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames AlosFnf { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames AlosPalsarMask { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Amp { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames AmpR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Autumn { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames AutumnR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Balance { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames BalanceR { get { throw null; } }
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
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Curl { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames CurlR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Dark2 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Dark2R { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Deep { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames DeepR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Delta { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames DeltaR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Dense { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames DenseR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Diff { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames DiffR { get { throw null; } }
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
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Haline { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames HalineR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Hot { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames HotR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Hsv { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames HsvR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Ice { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames IceR { get { throw null; } }
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
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Matter { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames MatterR { get { throw null; } }
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
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Oxy { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames OxyR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Paired { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames PairedR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Pastel1 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Pastel1R { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Pastel2 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Pastel2R { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Phase { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames PhaseR { get { throw null; } }
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
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Rain { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Rainbow { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames RainbowR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames RainR { get { throw null; } }
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
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Solar { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames SolarR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Spectral { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames SpectralR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Speed { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames SpeedR { get { throw null; } }
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
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Tarn { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames TarnR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Tempo { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames TempoR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Terrain { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames TerrainR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Thermal { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames ThermalR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Topo { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames TopoR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Turbid { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames TurbidR { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames Turbo { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.ColorMapNames TurboR { get { throw null; } }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.ColorMapNames left, Azure.Analytics.PlanetaryComputer.ColorMapNames right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.ColorMapNames (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.ColorMapNames? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.ColorMapNames left, Azure.Analytics.PlanetaryComputer.ColorMapNames right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CropCollectionFeatureByFormatOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureByFormatOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureByFormatOptions>
    {
        public CropCollectionFeatureByFormatOptions(string collectionId, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public string Bbox { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string Collection { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string DestinationCrs { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public int? Height { get { throw null; } set { } }
        public string Ids { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public int? MaxSize { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public int? Width { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.CropCollectionFeatureByFormatOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.CropCollectionFeatureByFormatOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.CropCollectionFeatureByFormatOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureByFormatOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureByFormatOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.CropCollectionFeatureByFormatOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureByFormatOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureByFormatOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureByFormatOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CropCollectionFeatureOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureOptions>
    {
        public CropCollectionFeatureOptions(string collectionId) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public string Bbox { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string Collection { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string DestinationCrs { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? Format { get { throw null; } set { } }
        public int? Height { get { throw null; } set { } }
        public string Ids { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public int? MaxSize { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public int? Width { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.CropCollectionFeatureOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.CropCollectionFeatureOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.CropCollectionFeatureOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.CropCollectionFeatureOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CropCollectionFeatureWidthByHeightOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureWidthByHeightOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureWidthByHeightOptions>
    {
        public CropCollectionFeatureWidthByHeightOptions(string collectionId, int width, int height, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public string Bbox { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string Collection { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string DestinationCrs { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public int Height { get { throw null; } }
        public string Ids { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public int? MaxSize { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public int Width { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.CropCollectionFeatureWidthByHeightOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.CropCollectionFeatureWidthByHeightOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.CropCollectionFeatureWidthByHeightOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureWidthByHeightOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureWidthByHeightOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.CropCollectionFeatureWidthByHeightOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureWidthByHeightOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureWidthByHeightOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropCollectionFeatureWidthByHeightOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CropFeatureByFormatOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropFeatureByFormatOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropFeatureByFormatOptions>
    {
        public CropFeatureByFormatOptions(string collectionId, string itemId, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string DestinationCrs { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public int? Height { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public int? MaxSize { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public int? Width { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.CropFeatureByFormatOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.CropFeatureByFormatOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.CropFeatureByFormatOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropFeatureByFormatOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropFeatureByFormatOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.CropFeatureByFormatOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropFeatureByFormatOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropFeatureByFormatOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropFeatureByFormatOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CropFeatureOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropFeatureOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropFeatureOptions>
    {
        public CropFeatureOptions(string collectionId, string itemId) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string DestinationCrs { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? Format { get { throw null; } set { } }
        public int? Height { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public int? MaxSize { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public int? Width { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.CropFeatureOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.CropFeatureOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.CropFeatureOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropFeatureOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropFeatureOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.CropFeatureOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropFeatureOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropFeatureOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropFeatureOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CropFeatureWidthByHeightOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropFeatureWidthByHeightOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropFeatureWidthByHeightOptions>
    {
        public CropFeatureWidthByHeightOptions(string collectionId, string itemId, int width, int height, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string DestinationCrs { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public int Height { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int? MaxSize { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public int Width { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.CropFeatureWidthByHeightOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.CropFeatureWidthByHeightOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.CropFeatureWidthByHeightOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropFeatureWidthByHeightOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropFeatureWidthByHeightOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.CropFeatureWidthByHeightOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropFeatureWidthByHeightOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropFeatureWidthByHeightOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropFeatureWidthByHeightOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CropSearchFeatureByFormatOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureByFormatOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureByFormatOptions>
    {
        public CropSearchFeatureByFormatOptions(string searchId, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string Collection { get { throw null; } set { } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string DestinationCrs { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public int? Height { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public int? MaxSize { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public int? Width { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.CropSearchFeatureByFormatOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.CropSearchFeatureByFormatOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.CropSearchFeatureByFormatOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureByFormatOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureByFormatOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.CropSearchFeatureByFormatOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureByFormatOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureByFormatOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureByFormatOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CropSearchFeatureOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureOptions>
    {
        public CropSearchFeatureOptions(string searchId) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string Collection { get { throw null; } set { } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string DestinationCrs { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? Format { get { throw null; } set { } }
        public int? Height { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public int? MaxSize { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public int? Width { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.CropSearchFeatureOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.CropSearchFeatureOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.CropSearchFeatureOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.CropSearchFeatureOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CropSearchFeatureWidthByHeightOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureWidthByHeightOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureWidthByHeightOptions>
    {
        public CropSearchFeatureWidthByHeightOptions(string searchId, int width, int height, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string Collection { get { throw null; } set { } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string DestinationCrs { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public int Height { get { throw null; } }
        public int? ItemsLimit { get { throw null; } set { } }
        public int? MaxSize { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public int Width { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.CropSearchFeatureWidthByHeightOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.CropSearchFeatureWidthByHeightOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.CropSearchFeatureWidthByHeightOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureWidthByHeightOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureWidthByHeightOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.CropSearchFeatureWidthByHeightOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureWidthByHeightOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureWidthByHeightOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.CropSearchFeatureWidthByHeightOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataClient
    {
        protected DataClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CropCollectionFeature(Azure.Core.RequestContent content, Azure.Analytics.PlanetaryComputer.CropCollectionFeatureOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CropCollectionFeatureAsync(Azure.Core.RequestContent content, Azure.Analytics.PlanetaryComputer.CropCollectionFeatureOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CropCollectionFeatureByFormat(Azure.Core.RequestContent content, Azure.Analytics.PlanetaryComputer.CropCollectionFeatureByFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CropCollectionFeatureByFormatAsync(Azure.Core.RequestContent content, Azure.Analytics.PlanetaryComputer.CropCollectionFeatureByFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CropCollectionFeatureWidthByHeight(Azure.Core.RequestContent content, Azure.Analytics.PlanetaryComputer.CropCollectionFeatureWidthByHeightOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CropCollectionFeatureWidthByHeightAsync(Azure.Core.RequestContent content, Azure.Analytics.PlanetaryComputer.CropCollectionFeatureWidthByHeightOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CropFeature(Azure.Core.RequestContent content, Azure.Analytics.PlanetaryComputer.CropFeatureOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CropFeatureAsync(Azure.Core.RequestContent content, Azure.Analytics.PlanetaryComputer.CropFeatureOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CropFeatureByFormat(Azure.Core.RequestContent content, Azure.Analytics.PlanetaryComputer.CropFeatureByFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CropFeatureByFormatAsync(Azure.Core.RequestContent content, Azure.Analytics.PlanetaryComputer.CropFeatureByFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CropFeatureWidthByHeight(Azure.Core.RequestContent content, Azure.Analytics.PlanetaryComputer.CropFeatureWidthByHeightOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CropFeatureWidthByHeightAsync(Azure.Core.RequestContent content, Azure.Analytics.PlanetaryComputer.CropFeatureWidthByHeightOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CropSearchFeature(Azure.Core.RequestContent content, Azure.Analytics.PlanetaryComputer.CropSearchFeatureOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CropSearchFeatureAsync(Azure.Core.RequestContent content, Azure.Analytics.PlanetaryComputer.CropSearchFeatureOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CropSearchFeatureByFormat(Azure.Core.RequestContent content, Azure.Analytics.PlanetaryComputer.CropSearchFeatureByFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CropSearchFeatureByFormatAsync(Azure.Core.RequestContent content, Azure.Analytics.PlanetaryComputer.CropSearchFeatureByFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CropSearchFeatureWidthByHeight(Azure.Core.RequestContent content, Azure.Analytics.PlanetaryComputer.CropSearchFeatureWidthByHeightOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CropSearchFeatureWidthByHeightAsync(Azure.Core.RequestContent content, Azure.Analytics.PlanetaryComputer.CropSearchFeatureWidthByHeightOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetClassMapLegend(string classmapName, int? trimStart, int? trimEnd, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.ClassMapLegendResult> GetClassMapLegend(string classmapName, int? trimStart = default(int?), int? trimEnd = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetClassMapLegendAsync(string classmapName, int? trimStart, int? trimEnd, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.ClassMapLegendResult>> GetClassMapLegendAsync(string classmapName, int? trimStart = default(int?), int? trimEnd = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCollectionAssetsForBbox(Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForBboxOptions options, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<System.BinaryData>> GetCollectionAssetsForBbox(Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForBboxOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionAssetsForBboxAsync(Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForBboxOptions options, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<System.BinaryData>>> GetCollectionAssetsForBboxAsync(Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForBboxOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCollectionAssetsForTile(Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileOptions options, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.PlanetaryComputer.TilerAssetGeoJson>> GetCollectionAssetsForTile(Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionAssetsForTileAsync(Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileOptions options, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.PlanetaryComputer.TilerAssetGeoJson>>> GetCollectionAssetsForTileAsync(Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCollectionAssetsForTileNoTms(Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileNoTmsOptions options, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<System.BinaryData>> GetCollectionAssetsForTileNoTms(Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileNoTmsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionAssetsForTileNoTmsAsync(Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileNoTmsOptions options, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<System.BinaryData>>> GetCollectionAssetsForTileNoTmsAsync(Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileNoTmsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCollectionBboxCrop(Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionBboxCropAsync(Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCollectionBboxCropWithDimensions(Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropWithDimensionsOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionBboxCropWithDimensionsAsync(Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropWithDimensionsOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCollectionInfo(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration> GetCollectionInfo(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionInfoAsync(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration>> GetCollectionInfoAsync(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint> GetCollectionPoint(Azure.Analytics.PlanetaryComputer.GetCollectionPointOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCollectionPointAssets(Azure.Analytics.PlanetaryComputer.GetCollectionPointAssetsOptions options, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.PlanetaryComputer.StacItemPointAsset>> GetCollectionPointAssets(Azure.Analytics.PlanetaryComputer.GetCollectionPointAssetsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionPointAssetsAsync(Azure.Analytics.PlanetaryComputer.GetCollectionPointAssetsOptions options, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.PlanetaryComputer.StacItemPointAsset>>> GetCollectionPointAssetsAsync(Azure.Analytics.PlanetaryComputer.GetCollectionPointAssetsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint>> GetCollectionPointAsync(Azure.Analytics.PlanetaryComputer.GetCollectionPointOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCollectionTile(Azure.Analytics.PlanetaryComputer.GetCollectionTileOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionTileAsync(Azure.Analytics.PlanetaryComputer.GetCollectionTileOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCollectionTileByFormat(Azure.Analytics.PlanetaryComputer.GetCollectionTileByFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionTileByFormatAsync(Azure.Analytics.PlanetaryComputer.GetCollectionTileByFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCollectionTileByScale(Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCollectionTileByScaleAndFormat(Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleAndFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionTileByScaleAndFormatAsync(Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleAndFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionTileByScaleAsync(Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TileJsonMetadata> GetCollectionTileJson(Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TileJsonMetadata>> GetCollectionTileJsonAsync(Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TileJsonMetadata> GetCollectionTileJsonByTms(Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonByTmsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TileJsonMetadata>> GetCollectionTileJsonByTmsAsync(Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonByTmsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCollectionTileNoTms(Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionTileNoTmsAsync(Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCollectionTileNoTmsByFormat(Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionTileNoTmsByFormatAsync(Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCollectionTileNoTmsByScale(Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCollectionTileNoTmsByScaleAndFormat(Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleAndFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionTileNoTmsByScaleAndFormatAsync(Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleAndFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionTileNoTmsByScaleAsync(Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TileSetMetadata> GetCollectionTilesetMetadata(Azure.Analytics.PlanetaryComputer.GetCollectionTilesetMetadataOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TileSetMetadata>> GetCollectionTilesetMetadataAsync(Azure.Analytics.PlanetaryComputer.GetCollectionTilesetMetadataOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TileSetList> GetCollectionTilesets(Azure.Analytics.PlanetaryComputer.GetCollectionTilesetsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TileSetList>> GetCollectionTilesetsAsync(Azure.Analytics.PlanetaryComputer.GetCollectionTilesetsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCollectionWmtsCapabilities(Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionWmtsCapabilitiesAsync(Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCollectionWmtsCapabilitiesByTms(Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesByTmsOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionWmtsCapabilitiesByTmsAsync(Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesByTmsOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetIntervalLegend(string classmapName, int? trimStart, int? trimEnd, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IList<System.Collections.Generic.IList<long>>>> GetIntervalLegend(string classmapName, int? trimStart = default(int?), int? trimEnd = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetIntervalLegendAsync(string classmapName, int? trimStart, int? trimEnd, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IList<System.Collections.Generic.IList<long>>>>> GetIntervalLegendAsync(string classmapName, int? trimStart = default(int?), int? trimEnd = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.AssetStatisticsResult> GetItemAssetStatistics(Azure.Analytics.PlanetaryComputer.GetItemAssetStatisticsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.AssetStatisticsResult>> GetItemAssetStatisticsAsync(Azure.Analytics.PlanetaryComputer.GetItemAssetStatisticsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetItemAvailableAssets(Azure.Analytics.PlanetaryComputer.GetItemAvailableAssetsOptions options, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<string>> GetItemAvailableAssets(Azure.Analytics.PlanetaryComputer.GetItemAvailableAssetsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetItemAvailableAssetsAsync(Azure.Analytics.PlanetaryComputer.GetItemAvailableAssetsOptions options, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<string>>> GetItemAvailableAssetsAsync(Azure.Analytics.PlanetaryComputer.GetItemAvailableAssetsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetItemBboxCrop(Azure.Analytics.PlanetaryComputer.GetItemBboxCropOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetItemBboxCropAsync(Azure.Analytics.PlanetaryComputer.GetItemBboxCropOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetItemBboxCropWithDimensions(Azure.Analytics.PlanetaryComputer.GetItemBboxCropWithDimensionsOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetItemBboxCropWithDimensionsAsync(Azure.Analytics.PlanetaryComputer.GetItemBboxCropWithDimensionsOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacItemBounds> GetItemBounds(Azure.Analytics.PlanetaryComputer.GetItemTilesetsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacItemBounds>> GetItemBoundsAsync(Azure.Analytics.PlanetaryComputer.GetItemTilesetsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson> GetItemFeatureStatistics(Azure.Analytics.PlanetaryComputer.GeoJsonFeature body, Azure.Analytics.PlanetaryComputer.GetItemFeatureStatisticsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson>> GetItemFeatureStatisticsAsync(Azure.Analytics.PlanetaryComputer.GeoJsonFeature body, Azure.Analytics.PlanetaryComputer.GetItemFeatureStatisticsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TilerInfoMapResult> GetItemInfo(Azure.Analytics.PlanetaryComputer.GetItemInfoOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TilerInfoMapResult>> GetItemInfoAsync(Azure.Analytics.PlanetaryComputer.GetItemInfoOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature> GetItemInfoGeoJson(Azure.Analytics.PlanetaryComputer.GetItemInfoOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature>> GetItemInfoGeoJsonAsync(Azure.Analytics.PlanetaryComputer.GetItemInfoOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint> GetItemPoint(Azure.Analytics.PlanetaryComputer.GetItemPointOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint>> GetItemPointAsync(Azure.Analytics.PlanetaryComputer.GetItemPointOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetItemPreview(Azure.Analytics.PlanetaryComputer.GetItemPreviewOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetItemPreviewAsync(Azure.Analytics.PlanetaryComputer.GetItemPreviewOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetItemPreviewWithFormat(Azure.Analytics.PlanetaryComputer.GetItemPreviewWithFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetItemPreviewWithFormatAsync(Azure.Analytics.PlanetaryComputer.GetItemPreviewWithFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TilerStacItemStatistics> GetItemStatistics(Azure.Analytics.PlanetaryComputer.GetItemStatisticsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TilerStacItemStatistics>> GetItemStatisticsAsync(Azure.Analytics.PlanetaryComputer.GetItemStatisticsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TileJsonMetadata> GetItemTileJson(Azure.Analytics.PlanetaryComputer.GetItemTileJsonOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TileJsonMetadata>> GetItemTileJsonAsync(Azure.Analytics.PlanetaryComputer.GetItemTileJsonOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TileJsonMetadata> GetItemTileJsonByTms(Azure.Analytics.PlanetaryComputer.GetItemTileJsonByTmsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TileJsonMetadata>> GetItemTileJsonByTmsAsync(Azure.Analytics.PlanetaryComputer.GetItemTileJsonByTmsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetItemWmtsCapabilities(Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetItemWmtsCapabilitiesAsync(Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetItemWmtsCapabilitiesByTms(Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesByTmsOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetItemWmtsCapabilitiesByTmsAsync(Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesByTmsOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetLegend(Azure.Analytics.PlanetaryComputer.GetLegendOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLegendAsync(Azure.Analytics.PlanetaryComputer.GetLegendOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSearchAssetsForTile(Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileOptions options, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.PlanetaryComputer.TilerAssetGeoJson>> GetSearchAssetsForTile(Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSearchAssetsForTileAsync(Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileOptions options, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.PlanetaryComputer.TilerAssetGeoJson>>> GetSearchAssetsForTileAsync(Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSearchAssetsForTileNoTms(Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileNoTmsOptions options, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<System.BinaryData>> GetSearchAssetsForTileNoTms(Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileNoTmsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSearchAssetsForTileNoTmsAsync(Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileNoTmsOptions options, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<System.BinaryData>>> GetSearchAssetsForTileNoTmsAsync(Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileNoTmsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSearchBboxAssets(Azure.Analytics.PlanetaryComputer.GetSearchBboxAssetsOptions options, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<System.BinaryData>> GetSearchBboxAssets(Azure.Analytics.PlanetaryComputer.GetSearchBboxAssetsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSearchBboxAssetsAsync(Azure.Analytics.PlanetaryComputer.GetSearchBboxAssetsOptions options, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<System.BinaryData>>> GetSearchBboxAssetsAsync(Azure.Analytics.PlanetaryComputer.GetSearchBboxAssetsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSearchBboxCrop(Azure.Analytics.PlanetaryComputer.GetSearchBboxCropOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSearchBboxCropAsync(Azure.Analytics.PlanetaryComputer.GetSearchBboxCropOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSearchBboxCropWithDimensions(Azure.Analytics.PlanetaryComputer.GetSearchBboxCropWithDimensionsOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSearchBboxCropWithDimensionsAsync(Azure.Analytics.PlanetaryComputer.GetSearchBboxCropWithDimensionsOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSearchInfo(string searchId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration> GetSearchInfo(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSearchInfoAsync(string searchId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration>> GetSearchInfoAsync(string searchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint> GetSearchPoint(Azure.Analytics.PlanetaryComputer.GetSearchPointOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint>> GetSearchPointAsync(Azure.Analytics.PlanetaryComputer.GetSearchPointOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSearchPointWithAssets(Azure.Analytics.PlanetaryComputer.GetSearchPointWithAssetsOptions options, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.PlanetaryComputer.StacItemPointAsset>> GetSearchPointWithAssets(Azure.Analytics.PlanetaryComputer.GetSearchPointWithAssetsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSearchPointWithAssetsAsync(Azure.Analytics.PlanetaryComputer.GetSearchPointWithAssetsOptions options, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.PlanetaryComputer.StacItemPointAsset>>> GetSearchPointWithAssetsAsync(Azure.Analytics.PlanetaryComputer.GetSearchPointWithAssetsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSearchTile(Azure.Analytics.PlanetaryComputer.GetSearchTileOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSearchTileAsync(Azure.Analytics.PlanetaryComputer.GetSearchTileOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSearchTileByFormat(Azure.Analytics.PlanetaryComputer.GetSearchTileByFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSearchTileByFormatAsync(Azure.Analytics.PlanetaryComputer.GetSearchTileByFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSearchTileByScale(Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSearchTileByScaleAndFormat(Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleAndFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSearchTileByScaleAndFormatAsync(Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleAndFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSearchTileByScaleAsync(Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TileJsonMetadata> GetSearchTileJson(Azure.Analytics.PlanetaryComputer.GetSearchTileJsonOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TileJsonMetadata>> GetSearchTileJsonAsync(Azure.Analytics.PlanetaryComputer.GetSearchTileJsonOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TileJsonMetadata> GetSearchTileJsonByTms(Azure.Analytics.PlanetaryComputer.GetSearchTileJsonByTmsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TileJsonMetadata>> GetSearchTileJsonByTmsAsync(Azure.Analytics.PlanetaryComputer.GetSearchTileJsonByTmsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSearchTileNoTms(Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSearchTileNoTmsAsync(Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSearchTileNoTmsByFormat(Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSearchTileNoTmsByFormatAsync(Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSearchTileNoTmsByScale(Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSearchTileNoTmsByScaleAndFormat(Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleAndFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSearchTileNoTmsByScaleAndFormatAsync(Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleAndFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSearchTileNoTmsByScaleAsync(Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TileSetMetadata> GetSearchTilesetMetadata(Azure.Analytics.PlanetaryComputer.GetSearchTilesetMetadataOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TileSetMetadata>> GetSearchTilesetMetadataAsync(Azure.Analytics.PlanetaryComputer.GetSearchTilesetMetadataOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TileSetList> GetSearchTilesets(Azure.Analytics.PlanetaryComputer.GetSearchTilesetsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TileSetList>> GetSearchTilesetsAsync(Azure.Analytics.PlanetaryComputer.GetSearchTilesetsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSearchWmtsCapabilities(Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSearchWmtsCapabilitiesAsync(Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSearchWmtsCapabilitiesByTms(Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesByTmsOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSearchWmtsCapabilitiesByTmsAsync(Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesByTmsOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTile(Azure.Analytics.PlanetaryComputer.GetTileOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTileAsync(Azure.Analytics.PlanetaryComputer.GetTileOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTileByFormat(Azure.Analytics.PlanetaryComputer.GetTileByFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTileByFormatAsync(Azure.Analytics.PlanetaryComputer.GetTileByFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTileByScale(Azure.Analytics.PlanetaryComputer.GetTileByScaleOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTileByScaleAndFormat(Azure.Analytics.PlanetaryComputer.GetTileByScaleAndFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTileByScaleAndFormatAsync(Azure.Analytics.PlanetaryComputer.GetTileByScaleAndFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTileByScaleAsync(Azure.Analytics.PlanetaryComputer.GetTileByScaleOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTileMatrices(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<string>> GetTileMatrices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTileMatricesAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<string>>> GetTileMatricesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTileMatrixDefinitions(string tileMatrixSetId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TileMatrixSet> GetTileMatrixDefinitions(string tileMatrixSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTileMatrixDefinitionsAsync(string tileMatrixSetId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TileMatrixSet>> GetTileMatrixDefinitionsAsync(string tileMatrixSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTileNoTms(Azure.Analytics.PlanetaryComputer.GetTileNoTmsOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTileNoTmsAsync(Azure.Analytics.PlanetaryComputer.GetTileNoTmsOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTileNoTmsByFormat(Azure.Analytics.PlanetaryComputer.GetTileNoTmsByFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTileNoTmsByFormatAsync(Azure.Analytics.PlanetaryComputer.GetTileNoTmsByFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTileNoTmsByScale(Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTileNoTmsByScaleAndFormat(Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleAndFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTileNoTmsByScaleAndFormatAsync(Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleAndFormatOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTileNoTmsByScaleAsync(Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TileSetMetadata> GetTilesetMetadata(Azure.Analytics.PlanetaryComputer.GetItemTilesetMetadataOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TileSetMetadata>> GetTilesetMetadataAsync(Azure.Analytics.PlanetaryComputer.GetItemTilesetMetadataOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TileSetList> GetTilesets(Azure.Analytics.PlanetaryComputer.GetItemTilesetsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TileSetList>> GetTilesetsAsync(Azure.Analytics.PlanetaryComputer.GetItemTilesetsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult> RegisterMosaicsSearch(Azure.Analytics.PlanetaryComputer.RegisterMosaic body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegisterMosaicsSearch(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult>> RegisterMosaicsSearchAsync(Azure.Analytics.PlanetaryComputer.RegisterMosaic body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegisterMosaicsSearchAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeatureKind : System.IEquatable<Azure.Analytics.PlanetaryComputer.FeatureKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeatureKind(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.FeatureKind Feature { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.FeatureKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.FeatureKind left, Azure.Analytics.PlanetaryComputer.FeatureKind right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.FeatureKind (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.FeatureKind? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.FeatureKind left, Azure.Analytics.PlanetaryComputer.FeatureKind right) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.FilterLanguage left, Azure.Analytics.PlanetaryComputer.FilterLanguage right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.FilterLanguage (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.FilterLanguage? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.FilterLanguage left, Azure.Analytics.PlanetaryComputer.FilterLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GeoJsonFeature : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GeoJsonFeature>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GeoJsonFeature>
    {
        public GeoJsonFeature(Azure.Analytics.PlanetaryComputer.GeoJsonGeometry geometry, Azure.Analytics.PlanetaryComputer.FeatureKind type) { }
        public Azure.Analytics.PlanetaryComputer.GeoJsonGeometry Geometry { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Properties { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.FeatureKind Type { get { throw null; } }
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
    public partial class GetCollectionAssetsForBboxOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForBboxOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForBboxOptions>
    {
        public GetCollectionAssetsForBboxOptions(string collectionId, float minX, float minY, float maxX, float maxY) { }
        public string Bbox { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Ids { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public float MaxX { get { throw null; } }
        public float MaxY { get { throw null; } }
        public float MinX { get { throw null; } }
        public float MinY { get { throw null; } }
        public string Query { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForBboxOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForBboxOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForBboxOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForBboxOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForBboxOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForBboxOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForBboxOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForBboxOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForBboxOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionAssetsForTileNoTmsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileNoTmsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileNoTmsOptions>
    {
        public GetCollectionAssetsForTileNoTmsOptions(string collectionId, float z, float x, float y) { }
        public string Bbox { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Ids { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetId? TileMatrixSetId { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileNoTmsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileNoTmsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileNoTmsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileNoTmsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileNoTmsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileNoTmsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileNoTmsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileNoTmsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileNoTmsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionAssetsForTileOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileOptions>
    {
        public GetCollectionAssetsForTileOptions(string collectionId, string tileMatrixSetId, float z, float x, float y) { }
        public string Bbox { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Ids { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        public int? TimeLimit { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionBboxCropOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropOptions>
    {
        public GetCollectionBboxCropOptions(string collectionId, float minX, float minY, float maxX, float maxY, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public string Bbox { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string Collection { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string DestinationCrs { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public int? Height { get { throw null; } set { } }
        public string Ids { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public int? MaxSize { get { throw null; } set { } }
        public float MaxX { get { throw null; } }
        public float MaxY { get { throw null; } }
        public float MinX { get { throw null; } }
        public float MinY { get { throw null; } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public int? Width { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionBboxCropWithDimensionsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropWithDimensionsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropWithDimensionsOptions>
    {
        public GetCollectionBboxCropWithDimensionsOptions(string collectionId, float minX, float minY, float maxX, float maxY, int width, int height, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public string Bbox { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string Collection { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string DestinationCrs { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public int Height { get { throw null; } }
        public string Ids { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public int? MaxSize { get { throw null; } set { } }
        public float MaxX { get { throw null; } }
        public float MaxY { get { throw null; } }
        public float MinX { get { throw null; } }
        public float MinY { get { throw null; } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public int Width { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropWithDimensionsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropWithDimensionsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropWithDimensionsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropWithDimensionsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropWithDimensionsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropWithDimensionsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropWithDimensionsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropWithDimensionsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropWithDimensionsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionPointAssetsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionPointAssetsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionPointAssetsOptions>
    {
        public GetCollectionPointAssetsOptions(string collectionId, float longitude, float latitude) { }
        public string Bbox { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Ids { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public float Latitude { get { throw null; } }
        public float Longitude { get { throw null; } }
        public string Query { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionPointAssetsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionPointAssetsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionPointAssetsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionPointAssetsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionPointAssetsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionPointAssetsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionPointAssetsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionPointAssetsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionPointAssetsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionPointOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionPointOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionPointOptions>
    {
        public GetCollectionPointOptions(string collectionId, float longitude, float latitude) { }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public string Bbox { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string CollectionId { get { throw null; } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Ids { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public float Latitude { get { throw null; } }
        public float Longitude { get { throw null; } }
        public string NoData { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionPointOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionPointOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionPointOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionPointOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionPointOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionPointOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionPointOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionPointOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionPointOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionThumbnailOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionThumbnailOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionThumbnailOptions>
    {
        public GetCollectionThumbnailOptions(string collectionId) { }
        public string CollectionId { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionThumbnailOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionThumbnailOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionThumbnailOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionThumbnailOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionThumbnailOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionThumbnailOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionThumbnailOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionThumbnailOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionThumbnailOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionTileByFormatOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByFormatOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByFormatOptions>
    {
        public GetCollectionTileByFormatOptions(string collectionId, string tileMatrixSetId, float z, float x, float y, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public string Bbox { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string Collection { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public string Ids { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? Scale { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTileByFormatOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTileByFormatOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionTileByFormatOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByFormatOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByFormatOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionTileByFormatOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByFormatOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByFormatOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByFormatOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionTileByScaleAndFormatOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleAndFormatOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleAndFormatOptions>
    {
        public GetCollectionTileByScaleAndFormatOptions(string collectionId, string tileMatrixSetId, float z, float x, float y, float scale, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public string Bbox { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string Collection { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public string Ids { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public float Scale { get { throw null; } }
        public int? ScanLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleAndFormatOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleAndFormatOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleAndFormatOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleAndFormatOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleAndFormatOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleAndFormatOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleAndFormatOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleAndFormatOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleAndFormatOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionTileByScaleOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleOptions>
    {
        public GetCollectionTileByScaleOptions(string collectionId, string tileMatrixSetId, float z, float x, float y, float scale) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public string Bbox { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string Collection { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? Format { get { throw null; } set { } }
        public string Ids { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public float Scale { get { throw null; } }
        public int? ScanLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionTileJsonByTmsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonByTmsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonByTmsOptions>
    {
        public GetCollectionTileJsonByTmsOptions(string collectionId, string tileMatrixSetId) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public string Bbox { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string Collection { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Ids { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public int? MaxZoom { get { throw null; } set { } }
        public int? MinZoom { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? TileFormat { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        public int? TileScale { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonByTmsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonByTmsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonByTmsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonByTmsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonByTmsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonByTmsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonByTmsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonByTmsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonByTmsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionTileJsonOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonOptions>
    {
        public GetCollectionTileJsonOptions(string collectionId) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public string Bbox { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string Collection { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Ids { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public int? MaxZoom { get { throw null; } set { } }
        public int? MinZoom { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? TileFormat { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetId? TileMatrixSetId { get { throw null; } set { } }
        public int? TileScale { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionTileNoTmsByFormatOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByFormatOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByFormatOptions>
    {
        public GetCollectionTileNoTmsByFormatOptions(string collectionId, float z, float x, float y, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public string Bbox { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string Collection { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public string Ids { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? Scale { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetId? TileMatrixSetId { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByFormatOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByFormatOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByFormatOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByFormatOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByFormatOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByFormatOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByFormatOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByFormatOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByFormatOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionTileNoTmsByScaleAndFormatOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleAndFormatOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleAndFormatOptions>
    {
        public GetCollectionTileNoTmsByScaleAndFormatOptions(string collectionId, float z, float x, float y, float scale, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public string Bbox { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string Collection { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public string Ids { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public float Scale { get { throw null; } }
        public int? ScanLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetId? TileMatrixSetId { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleAndFormatOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleAndFormatOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleAndFormatOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleAndFormatOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleAndFormatOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleAndFormatOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleAndFormatOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleAndFormatOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleAndFormatOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionTileNoTmsByScaleOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleOptions>
    {
        public GetCollectionTileNoTmsByScaleOptions(string collectionId, float z, float x, float y, float scale) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public string Bbox { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string Collection { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? Format { get { throw null; } set { } }
        public string Ids { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public float Scale { get { throw null; } }
        public int? ScanLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetId? TileMatrixSetId { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionTileNoTmsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsOptions>
    {
        public GetCollectionTileNoTmsOptions(string collectionId, float z, float x, float y) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public string Bbox { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string Collection { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? Format { get { throw null; } set { } }
        public string Ids { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? Scale { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetId? TileMatrixSetId { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionTileOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileOptions>
    {
        public GetCollectionTileOptions(string collectionId, string tileMatrixSetId, float z, float x, float y) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public string Bbox { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string Collection { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? Format { get { throw null; } set { } }
        public string Ids { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? Scale { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTileOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTileOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionTileOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionTileOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTileOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionTilesetMetadataOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTilesetMetadataOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTilesetMetadataOptions>
    {
        public GetCollectionTilesetMetadataOptions(string collectionId, string tileMatrixSetId) { }
        public string Bbox { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string Ids { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTilesetMetadataOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTilesetMetadataOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionTilesetMetadataOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTilesetMetadataOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTilesetMetadataOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionTilesetMetadataOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTilesetMetadataOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTilesetMetadataOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTilesetMetadataOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionTilesetsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTilesetsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTilesetsOptions>
    {
        public GetCollectionTilesetsOptions(string collectionId) { }
        public string Bbox { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string Ids { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTilesetsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionTilesetsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionTilesetsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTilesetsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionTilesetsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionTilesetsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTilesetsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTilesetsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionTilesetsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionWmtsCapabilitiesByTmsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesByTmsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesByTmsOptions>
    {
        public GetCollectionWmtsCapabilitiesByTmsOptions(string collectionId, string tileMatrixSetId) { }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public string Bbox { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string CollectionId { get { throw null; } }
        public string Datetime { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Ids { get { throw null; } set { } }
        public int? MaxZoom { get { throw null; } set { } }
        public int? MinZoom { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? TileFormat { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        public int? TileScale { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesByTmsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesByTmsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesByTmsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesByTmsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesByTmsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesByTmsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesByTmsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesByTmsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesByTmsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionWmtsCapabilitiesOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesOptions>
    {
        public GetCollectionWmtsCapabilitiesOptions(string collectionId) { }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public string Bbox { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string CollectionId { get { throw null; } }
        public string Datetime { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Ids { get { throw null; } set { } }
        public int? MaxZoom { get { throw null; } set { } }
        public int? MinZoom { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? TileFormat { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetId? TileMatrixSetId { get { throw null; } set { } }
        public int? TileScale { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetItemAssetStatisticsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemAssetStatisticsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemAssetStatisticsOptions>
    {
        public GetItemAssetStatisticsOptions(string collectionId, string itemId) { }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> AssetExpression { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public bool? Categorical { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> CategoriesPixels { get { throw null; } }
        public string CollectionId { get { throw null; } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public int? Height { get { throw null; } set { } }
        public string HistogramBins { get { throw null; } set { } }
        public string HistogramRange { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public int? MaxSize { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Percentiles { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public int? Width { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemAssetStatisticsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemAssetStatisticsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetItemAssetStatisticsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemAssetStatisticsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemAssetStatisticsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetItemAssetStatisticsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemAssetStatisticsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemAssetStatisticsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemAssetStatisticsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetItemAvailableAssetsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemAvailableAssetsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemAvailableAssetsOptions>
    {
        public GetItemAvailableAssetsOptions(string collectionId, string itemId) { }
        public string CollectionId { get { throw null; } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemAvailableAssetsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemAvailableAssetsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetItemAvailableAssetsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemAvailableAssetsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemAvailableAssetsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetItemAvailableAssetsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemAvailableAssetsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemAvailableAssetsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemAvailableAssetsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetItemBboxCropOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemBboxCropOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemBboxCropOptions>
    {
        public GetItemBboxCropOptions(string collectionId, string itemId, float minX, float minY, float maxX, float maxY, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string DestinationCrs { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public int? Height { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public int? MaxSize { get { throw null; } set { } }
        public float MaxX { get { throw null; } }
        public float MaxY { get { throw null; } }
        public float MinX { get { throw null; } }
        public float MinY { get { throw null; } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public int? Width { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemBboxCropOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemBboxCropOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetItemBboxCropOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemBboxCropOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemBboxCropOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetItemBboxCropOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemBboxCropOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemBboxCropOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemBboxCropOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetItemBboxCropWithDimensionsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemBboxCropWithDimensionsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemBboxCropWithDimensionsOptions>
    {
        public GetItemBboxCropWithDimensionsOptions(string collectionId, string itemId, float minX, float minY, float maxX, float maxY, int width, int height, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string DestinationCrs { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public int Height { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int? MaxSize { get { throw null; } set { } }
        public float MaxX { get { throw null; } }
        public float MaxY { get { throw null; } }
        public float MinX { get { throw null; } }
        public float MinY { get { throw null; } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public int Width { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemBboxCropWithDimensionsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemBboxCropWithDimensionsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetItemBboxCropWithDimensionsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemBboxCropWithDimensionsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemBboxCropWithDimensionsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetItemBboxCropWithDimensionsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemBboxCropWithDimensionsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemBboxCropWithDimensionsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemBboxCropWithDimensionsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetItemCollectionOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemCollectionOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemCollectionOptions>
    {
        public GetItemCollectionOptions(string collectionId) { }
        public System.Collections.Generic.IList<string> BoundingBox { get { throw null; } }
        public string CollectionId { get { throw null; } }
        public string Datetime { get { throw null; } set { } }
        public int? DurationInMinutes { get { throw null; } set { } }
        public int? Limit { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode? Sign { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemCollectionOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemCollectionOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetItemCollectionOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemCollectionOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemCollectionOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetItemCollectionOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemCollectionOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemCollectionOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemCollectionOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetItemFeatureStatisticsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemFeatureStatisticsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemFeatureStatisticsOptions>
    {
        public GetItemFeatureStatisticsOptions(string collectionId, string itemId) { }
        public string Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public bool? Categorical { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> CategoriesPixels { get { throw null; } }
        public string CollectionId { get { throw null; } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string DestinationCrs { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public int? Height { get { throw null; } set { } }
        public string HistogramBins { get { throw null; } set { } }
        public string HistogramRange { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public int? MaxSize { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Percentiles { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public int? Width { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemFeatureStatisticsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemFeatureStatisticsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetItemFeatureStatisticsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemFeatureStatisticsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemFeatureStatisticsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetItemFeatureStatisticsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemFeatureStatisticsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemFeatureStatisticsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemFeatureStatisticsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetItemInfoOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemInfoOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemInfoOptions>
    {
        public GetItemInfoOptions(string collectionId, string itemId) { }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public string CollectionId { get { throw null; } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemInfoOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemInfoOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetItemInfoOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemInfoOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemInfoOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetItemInfoOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemInfoOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemInfoOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemInfoOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetItemPointOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemPointOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemPointOptions>
    {
        public GetItemPointOptions(string collectionId, string itemId, float longitude, float latitude) { }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string CollectionId { get { throw null; } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public float Latitude { get { throw null; } }
        public float Longitude { get { throw null; } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemPointOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemPointOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetItemPointOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemPointOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemPointOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetItemPointOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemPointOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemPointOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemPointOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetItemPreviewOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemPreviewOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemPreviewOptions>
    {
        public GetItemPreviewOptions(string collectionId, string itemId) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string DstCrs { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? Format { get { throw null; } set { } }
        public int? Height { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public int? MaxSize { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public int? Width { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemPreviewOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemPreviewOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetItemPreviewOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemPreviewOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemPreviewOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetItemPreviewOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemPreviewOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemPreviewOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemPreviewOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetItemPreviewWithFormatOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemPreviewWithFormatOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemPreviewWithFormatOptions>
    {
        public GetItemPreviewWithFormatOptions(string collectionId, string itemId, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string DstCrs { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public int? Height { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public int? MaxSize { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public int? Width { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemPreviewWithFormatOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemPreviewWithFormatOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetItemPreviewWithFormatOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemPreviewWithFormatOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemPreviewWithFormatOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetItemPreviewWithFormatOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemPreviewWithFormatOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemPreviewWithFormatOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemPreviewWithFormatOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetItemStatisticsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemStatisticsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemStatisticsOptions>
    {
        public GetItemStatisticsOptions(string collectionId, string itemId) { }
        public string Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public bool? Categorical { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> CategoriesPixels { get { throw null; } }
        public string CollectionId { get { throw null; } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public int? Height { get { throw null; } set { } }
        public string HistogramBins { get { throw null; } set { } }
        public string HistogramRange { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public int? MaxSize { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Percentiles { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public int? Width { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemStatisticsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemStatisticsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetItemStatisticsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemStatisticsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemStatisticsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetItemStatisticsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemStatisticsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemStatisticsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemStatisticsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetItemTileJsonByTmsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemTileJsonByTmsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemTileJsonByTmsOptions>
    {
        public GetItemTileJsonByTmsOptions(string collectionId, string itemId, string tileMatrixSetId) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public int? MaxZoom { get { throw null; } set { } }
        public int? MinZoom { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? TileFormat { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        public int? TileScale { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemTileJsonByTmsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemTileJsonByTmsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetItemTileJsonByTmsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemTileJsonByTmsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemTileJsonByTmsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetItemTileJsonByTmsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemTileJsonByTmsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemTileJsonByTmsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemTileJsonByTmsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetItemTileJsonOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemTileJsonOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemTileJsonOptions>
    {
        public GetItemTileJsonOptions(string collectionId, string itemId) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public int? MaxZoom { get { throw null; } set { } }
        public int? MinZoom { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? TileFormat { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetId? TileMatrixSetId { get { throw null; } set { } }
        public int? TileScale { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemTileJsonOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemTileJsonOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetItemTileJsonOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemTileJsonOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemTileJsonOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetItemTileJsonOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemTileJsonOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemTileJsonOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemTileJsonOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetItemTilesetMetadataOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemTilesetMetadataOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemTilesetMetadataOptions>
    {
        public GetItemTilesetMetadataOptions(string collectionId, string itemId, string tileMatrixSetId) { }
        public string CollectionId { get { throw null; } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemTilesetMetadataOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemTilesetMetadataOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetItemTilesetMetadataOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemTilesetMetadataOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemTilesetMetadataOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetItemTilesetMetadataOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemTilesetMetadataOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemTilesetMetadataOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemTilesetMetadataOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetItemTilesetsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemTilesetsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemTilesetsOptions>
    {
        public GetItemTilesetsOptions(string collectionId, string itemId) { }
        public string CollectionId { get { throw null; } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemTilesetsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemTilesetsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetItemTilesetsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemTilesetsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemTilesetsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetItemTilesetsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemTilesetsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemTilesetsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemTilesetsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetItemWmtsCapabilitiesByTmsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesByTmsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesByTmsOptions>
    {
        public GetItemWmtsCapabilitiesByTmsOptions(string collectionId, string itemId, string tileMatrixSetId) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public int? MaxZoom { get { throw null; } set { } }
        public int? MinZoom { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? TileFormat { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        public int? TileScale { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesByTmsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesByTmsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesByTmsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesByTmsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesByTmsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesByTmsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesByTmsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesByTmsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesByTmsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetItemWmtsCapabilitiesOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesOptions>
    {
        public GetItemWmtsCapabilitiesOptions(string collectionId, string itemId) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public int? MaxZoom { get { throw null; } set { } }
        public int? MinZoom { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? TileFormat { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetId? TileMatrixSetId { get { throw null; } set { } }
        public int? TileScale { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetLegendOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetLegendOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetLegendOptions>
    {
        public GetLegendOptions(string colorMapName) { }
        public string ColorMapName { get { throw null; } }
        public float? Height { get { throw null; } set { } }
        public int? TrimEnd { get { throw null; } set { } }
        public int? TrimStart { get { throw null; } set { } }
        public float? Width { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetLegendOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetLegendOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetLegendOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetLegendOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetLegendOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetLegendOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetLegendOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetLegendOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetLegendOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchAssetsForTileNoTmsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileNoTmsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileNoTmsOptions>
    {
        public GetSearchAssetsForTileNoTmsOptions(string searchId, float z, float x, float y) { }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetId? TileMatrixSetId { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileNoTmsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileNoTmsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileNoTmsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileNoTmsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileNoTmsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileNoTmsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileNoTmsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileNoTmsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileNoTmsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchAssetsForTileOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileOptions>
    {
        public GetSearchAssetsForTileOptions(string searchId, string tileMatrixSetId, string collectionId, float z, float x, float y) { }
        public string CollectionId { get { throw null; } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        public int? TimeLimit { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchBboxAssetsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxAssetsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxAssetsOptions>
    {
        public GetSearchBboxAssetsOptions(string searchId, float minX, float minY, float maxX, float maxY) { }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public float MaxX { get { throw null; } }
        public float MaxY { get { throw null; } }
        public float MinX { get { throw null; } }
        public float MinY { get { throw null; } }
        public int? ScanLimit { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchBboxAssetsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchBboxAssetsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchBboxAssetsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxAssetsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxAssetsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchBboxAssetsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxAssetsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxAssetsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxAssetsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchBboxCropOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxCropOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxCropOptions>
    {
        public GetSearchBboxCropOptions(string searchId, float minX, float minY, float maxX, float maxY, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string Collection { get { throw null; } set { } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string DestinationCrs { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public int? Height { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public int? MaxSize { get { throw null; } set { } }
        public float MaxX { get { throw null; } }
        public float MaxY { get { throw null; } }
        public float MinX { get { throw null; } }
        public float MinY { get { throw null; } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public int? Width { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchBboxCropOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchBboxCropOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchBboxCropOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxCropOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxCropOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchBboxCropOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxCropOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxCropOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxCropOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchBboxCropWithDimensionsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxCropWithDimensionsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxCropWithDimensionsOptions>
    {
        public GetSearchBboxCropWithDimensionsOptions(string searchId, float minX, float minY, float maxX, float maxY, int width, int height, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string Collection { get { throw null; } set { } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string DestinationCrs { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public int Height { get { throw null; } }
        public int? ItemsLimit { get { throw null; } set { } }
        public int? MaxSize { get { throw null; } set { } }
        public float MaxX { get { throw null; } }
        public float MaxY { get { throw null; } }
        public float MinX { get { throw null; } }
        public float MinY { get { throw null; } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public int Width { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchBboxCropWithDimensionsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchBboxCropWithDimensionsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchBboxCropWithDimensionsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxCropWithDimensionsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxCropWithDimensionsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchBboxCropWithDimensionsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxCropWithDimensionsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxCropWithDimensionsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchBboxCropWithDimensionsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchPointOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchPointOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchPointOptions>
    {
        public GetSearchPointOptions(string searchId, float longitude, float latitude) { }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public float Latitude { get { throw null; } }
        public float Longitude { get { throw null; } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchPointOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchPointOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchPointOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchPointOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchPointOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchPointOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchPointOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchPointOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchPointOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchPointWithAssetsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchPointWithAssetsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchPointWithAssetsOptions>
    {
        public GetSearchPointWithAssetsOptions(string searchId, float longitude, float latitude) { }
        public string CoordinateReferenceSystem { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public float Latitude { get { throw null; } }
        public float Longitude { get { throw null; } }
        public int? ScanLimit { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchPointWithAssetsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchPointWithAssetsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchPointWithAssetsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchPointWithAssetsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchPointWithAssetsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchPointWithAssetsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchPointWithAssetsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchPointWithAssetsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchPointWithAssetsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchTileByFormatOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByFormatOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByFormatOptions>
    {
        public GetSearchTileByFormatOptions(string searchId, string tileMatrixSetId, float z, float x, float y, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string Collection { get { throw null; } set { } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public int? ItemsLimit { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? Scale { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTileByFormatOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTileByFormatOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchTileByFormatOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByFormatOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByFormatOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchTileByFormatOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByFormatOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByFormatOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByFormatOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchTileByScaleAndFormatOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleAndFormatOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleAndFormatOptions>
    {
        public GetSearchTileByScaleAndFormatOptions(string searchId, string tileMatrixSetId, float z, float x, float y, float scale, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string Collection { get { throw null; } set { } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public int? ItemsLimit { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public float Scale { get { throw null; } }
        public int? ScanLimit { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleAndFormatOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleAndFormatOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleAndFormatOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleAndFormatOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleAndFormatOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleAndFormatOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleAndFormatOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleAndFormatOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleAndFormatOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchTileByScaleOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleOptions>
    {
        public GetSearchTileByScaleOptions(string searchId, string tileMatrixSetId, float z, float x, float y, float scale) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string Collection { get { throw null; } set { } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? Format { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public float Scale { get { throw null; } }
        public int? ScanLimit { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchTileJsonByTmsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileJsonByTmsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileJsonByTmsOptions>
    {
        public GetSearchTileJsonByTmsOptions(string searchId, string tileMatrixSetId) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string Collection { get { throw null; } set { } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public int? MaxZoom { get { throw null; } set { } }
        public int? MinZoom { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? TileFormat { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        public int? TileScale { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTileJsonByTmsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTileJsonByTmsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchTileJsonByTmsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileJsonByTmsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileJsonByTmsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchTileJsonByTmsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileJsonByTmsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileJsonByTmsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileJsonByTmsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchTileJsonOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileJsonOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileJsonOptions>
    {
        public GetSearchTileJsonOptions(string searchId) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string CollectionId { get { throw null; } set { } }
        public string ColorFormula { get { throw null; } set { } }
        public string Colormap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColormapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public int? MaxZoom { get { throw null; } set { } }
        public int? MinZoom { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? TileFormat { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetId? TileMatrixSetId { get { throw null; } set { } }
        public int? TileScale { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTileJsonOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTileJsonOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchTileJsonOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileJsonOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileJsonOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchTileJsonOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileJsonOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileJsonOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileJsonOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchTileNoTmsByFormatOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByFormatOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByFormatOptions>
    {
        public GetSearchTileNoTmsByFormatOptions(string searchId, float z, float x, float y, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string Collection { get { throw null; } set { } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public int? ItemsLimit { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? Scale { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetId? TileMatrixSetId { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByFormatOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByFormatOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByFormatOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByFormatOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByFormatOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByFormatOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByFormatOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByFormatOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByFormatOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchTileNoTmsByScaleAndFormatOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleAndFormatOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleAndFormatOptions>
    {
        public GetSearchTileNoTmsByScaleAndFormatOptions(string searchId, float z, float x, float y, float scale, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string Collection { get { throw null; } set { } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public int? ItemsLimit { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public float Scale { get { throw null; } }
        public int? ScanLimit { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetId? TileMatrixSetId { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleAndFormatOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleAndFormatOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleAndFormatOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleAndFormatOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleAndFormatOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleAndFormatOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleAndFormatOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleAndFormatOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleAndFormatOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchTileNoTmsByScaleOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleOptions>
    {
        public GetSearchTileNoTmsByScaleOptions(string searchId, float z, float x, float y, float scale) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string Collection { get { throw null; } set { } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? Format { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public float Scale { get { throw null; } }
        public int? ScanLimit { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetId? TileMatrixSetId { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchTileNoTmsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsOptions>
    {
        public GetSearchTileNoTmsOptions(string searchId, float z, float x, float y) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string Collection { get { throw null; } set { } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? Format { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? Scale { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetId? TileMatrixSetId { get { throw null; } set { } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchTileOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileOptions>
    {
        public GetSearchTileOptions(string searchId, string tileMatrixSetId, float z, float x, float y) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string Collection { get { throw null; } set { } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public bool? ExitWhenFull { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? Format { get { throw null; } set { } }
        public int? ItemsLimit { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PixelSelection? PixelSelection { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? Scale { get { throw null; } set { } }
        public int? ScanLimit { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public bool? SkipCovered { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        public int? TimeLimit { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTileOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTileOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchTileOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTileOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchTileOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTileOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchTilesetMetadataOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTilesetMetadataOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTilesetMetadataOptions>
    {
        public GetSearchTilesetMetadataOptions(string searchId, string tileMatrixSetId) { }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTilesetMetadataOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTilesetMetadataOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchTilesetMetadataOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTilesetMetadataOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTilesetMetadataOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchTilesetMetadataOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTilesetMetadataOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTilesetMetadataOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTilesetMetadataOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchTilesetsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTilesetsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTilesetsOptions>
    {
        public GetSearchTilesetsOptions(string searchId) { }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTilesetsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchTilesetsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchTilesetsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTilesetsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchTilesetsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchTilesetsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTilesetsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTilesetsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchTilesetsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchWmtsCapabilitiesByTmsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesByTmsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesByTmsOptions>
    {
        public GetSearchWmtsCapabilitiesByTmsOptions(string searchId, string tileMatrixSetId) { }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string Expression { get { throw null; } set { } }
        public int? MaxZoom { get { throw null; } set { } }
        public int? MinZoom { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? TileFormat { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        public int? TileScale { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesByTmsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesByTmsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesByTmsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesByTmsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesByTmsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesByTmsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesByTmsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesByTmsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesByTmsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSearchWmtsCapabilitiesOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesOptions>
    {
        public GetSearchWmtsCapabilitiesOptions(string searchId) { }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public string Expression { get { throw null; } set { } }
        public int? MaxZoom { get { throw null; } set { } }
        public int? MinZoom { get { throw null; } set { } }
        public string NoData { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public string SearchId { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? TileFormat { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetId? TileMatrixSetId { get { throw null; } set { } }
        public int? TileScale { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetTileByFormatOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileByFormatOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileByFormatOptions>
    {
        public GetTileByFormatOptions(string collectionId, string itemId, string tileMatrixSetId, float z, float x, float y, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public string ItemId { get { throw null; } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? Scale { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetTileByFormatOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetTileByFormatOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetTileByFormatOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileByFormatOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileByFormatOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetTileByFormatOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileByFormatOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileByFormatOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileByFormatOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetTileByScaleAndFormatOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileByScaleAndFormatOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileByScaleAndFormatOptions>
    {
        public GetTileByScaleAndFormatOptions(string collectionId, string itemId, string tileMatrixSetId, float z, float x, float y, float scale, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public string ItemId { get { throw null; } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public float Scale { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetTileByScaleAndFormatOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetTileByScaleAndFormatOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetTileByScaleAndFormatOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileByScaleAndFormatOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileByScaleAndFormatOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetTileByScaleAndFormatOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileByScaleAndFormatOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileByScaleAndFormatOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileByScaleAndFormatOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetTileByScaleOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileByScaleOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileByScaleOptions>
    {
        public GetTileByScaleOptions(string collectionId, string itemId, string tileMatrixSetId, float z, float x, float y, float scale) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? Format { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public float Scale { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetTileByScaleOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetTileByScaleOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetTileByScaleOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileByScaleOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileByScaleOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetTileByScaleOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileByScaleOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileByScaleOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileByScaleOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetTileNoTmsByFormatOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByFormatOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByFormatOptions>
    {
        public GetTileNoTmsByFormatOptions(string collectionId, string itemId, float z, float x, float y, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public string ItemId { get { throw null; } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? Scale { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetId? TileMatrixSetId { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetTileNoTmsByFormatOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetTileNoTmsByFormatOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetTileNoTmsByFormatOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByFormatOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByFormatOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetTileNoTmsByFormatOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByFormatOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByFormatOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByFormatOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetTileNoTmsByScaleAndFormatOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleAndFormatOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleAndFormatOptions>
    {
        public GetTileNoTmsByScaleAndFormatOptions(string collectionId, string itemId, float z, float x, float y, float scale, string format) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string Format { get { throw null; } }
        public string ItemId { get { throw null; } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public float Scale { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetId? TileMatrixSetId { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleAndFormatOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleAndFormatOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleAndFormatOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleAndFormatOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleAndFormatOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleAndFormatOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleAndFormatOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleAndFormatOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleAndFormatOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetTileNoTmsByScaleOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleOptions>
    {
        public GetTileNoTmsByScaleOptions(string collectionId, string itemId, float z, float x, float y, float scale) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? Format { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public float Scale { get { throw null; } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetId? TileMatrixSetId { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetTileNoTmsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsOptions>
    {
        public GetTileNoTmsOptions(string collectionId, string itemId, float z, float x, float y) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? Format { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? Scale { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TileMatrixSetId? TileMatrixSetId { get { throw null; } set { } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetTileNoTmsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetTileNoTmsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetTileNoTmsOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetTileNoTmsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileNoTmsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetTileOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileOptions>
    {
        public GetTileOptions(string collectionId, string itemId, string tileMatrixSetId, float z, float x, float y) { }
        public Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? Algorithm { get { throw null; } set { } }
        public string AlgorithmParams { get { throw null; } set { } }
        public bool? AssetAsBand { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssetBandIndices { get { throw null; } }
        public System.Collections.Generic.IList<string> Assets { get { throw null; } }
        public System.Collections.Generic.IList<int> Bidx { get { throw null; } }
        public float? Buffer { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string ColorFormula { get { throw null; } set { } }
        public string ColorMap { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ColorMapNames? ColorMapName { get { throw null; } set { } }
        public string Crs { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.TilerImageFormat? Format { get { throw null; } set { } }
        public string ItemId { get { throw null; } }
        public string NoData { get { throw null; } set { } }
        public int? Padding { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.WarpKernelResampling? Reproject { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.ResamplingMethod? Resampling { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rescale { get { throw null; } }
        public bool? ReturnMask { get { throw null; } set { } }
        public int? Scale { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Sel { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.SelMethod? SelMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SubdatasetBands { get { throw null; } }
        public string SubdatasetName { get { throw null; } set { } }
        public string TileMatrixSetId { get { throw null; } }
        public bool? Unscale { get { throw null; } set { } }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        public float Z { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.GetTileOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.GetTileOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.GetTileOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.GetTileOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.GetTileOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.GetTileOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Response DeleteSource(System.Guid sourceId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteSource(System.Guid sourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSourceAsync(System.Guid sourceId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSourceAsync(System.Guid sourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Get(string collectionId, System.Guid ingestionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionInformation> Get(string collectionId, System.Guid ingestionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAll(string collectionId, int? maxCount, int? skip, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.PlanetaryComputer.IngestionInformation> GetAll(string collectionId, int? maxCount = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllAsync(string collectionId, int? maxCount, int? skip, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.PlanetaryComputer.IngestionInformation> GetAllAsync(string collectionId, int? maxCount = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(string collectionId, System.Guid ingestionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionInformation>> GetAsync(string collectionId, System.Guid ingestionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetManagedIdentities(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.PlanetaryComputer.ManagedIdentityMetadata> GetManagedIdentities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetManagedIdentitiesAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.PlanetaryComputer.ManagedIdentityMetadata> GetManagedIdentitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetOperation(System.Guid operationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperation> GetOperation(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetOperationAsync(System.Guid operationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperation>> GetOperationAsync(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperation> GetOperations(int? maxCount = default(int?), int? skip = default(int?), string collectionId = null, Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus? status = default(Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetOperations(int? maxCount, int? skip, string collectionId, string status, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperation> GetOperationsAsync(int? maxCount = default(int?), int? skip = default(int?), string collectionId = null, Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus? status = default(Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetOperationsAsync(int? maxCount, int? skip, string collectionId, string status, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetRun(string collectionId, System.Guid ingestionId, System.Guid runId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionRun> GetRun(string collectionId, System.Guid ingestionId, System.Guid runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRunAsync(string collectionId, System.Guid ingestionId, System.Guid runId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionRun>> GetRunAsync(string collectionId, System.Guid ingestionId, System.Guid runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetRuns(string collectionId, System.Guid ingestionId, int? maxCount, int? skip, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.PlanetaryComputer.IngestionRun> GetRuns(string collectionId, System.Guid ingestionId, int? maxCount = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetRunsAsync(string collectionId, System.Guid ingestionId, int? maxCount, int? skip, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.PlanetaryComputer.IngestionRun> GetRunsAsync(string collectionId, System.Guid ingestionId, int? maxCount = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSource(System.Guid sourceId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionSource> GetSource(System.Guid sourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSourceAsync(System.Guid sourceId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionSource>> GetSourceAsync(System.Guid sourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSources(int? maxCount, int? skip, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.PlanetaryComputer.IngestionSourceSummary> GetSources(int? maxCount = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSourcesAsync(int? maxCount, int? skip, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.PlanetaryComputer.IngestionSourceSummary> GetSourcesAsync(int? maxCount = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionSource> ReplaceSource(System.Guid sourceId, Azure.Analytics.PlanetaryComputer.IngestionSource body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReplaceSource(System.Guid sourceId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.IngestionSource>> ReplaceSourceAsync(System.Guid sourceId, Azure.Analytics.PlanetaryComputer.IngestionSource body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplaceSourceAsync(System.Guid sourceId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Update(string collectionId, System.Guid ingestionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(string collectionId, System.Guid ingestionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class IngestionInformation : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionInformation>
    {
        public IngestionInformation(Azure.Analytics.PlanetaryComputer.IngestionKind importKind) { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public System.Guid Id { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.IngestionKind ImportKind { get { throw null; } set { } }
        public bool? KeepOriginalAssets { get { throw null; } set { } }
        public bool? SkipExistingItems { get { throw null; } set { } }
        public System.Uri SourceCatalogUri { get { throw null; } set { } }
        public System.Uri StacGeoparquetUri { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.IngestionStatus Status { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.IngestionInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.IngestionInformation (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.PlanetaryComputer.IngestionInformation ingestionInformation) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.IngestionInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.IngestionInformation System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.IngestionInformation System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IngestionKind : System.IEquatable<Azure.Analytics.PlanetaryComputer.IngestionKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IngestionKind(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.IngestionKind StacGeoparquet { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.IngestionKind StaticCatalog { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.IngestionKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.IngestionKind left, Azure.Analytics.PlanetaryComputer.IngestionKind right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.IngestionKind (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.IngestionKind? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.IngestionKind left, Azure.Analytics.PlanetaryComputer.IngestionKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IngestionRun : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionRun>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionRun>
    {
        internal IngestionRun() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Guid Id { get { throw null; } }
        public bool? KeepOriginalAssets { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.IngestionRunInformation Operation { get { throw null; } }
        public System.Guid? ParentRunId { get { throw null; } }
        public bool? SkipExistingItems { get { throw null; } }
        public System.Uri SourceCatalogUri { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.IngestionRun JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.IngestionRun (Azure.Response response) { throw null; }
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
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.DateTimeOffset? FinishedOn { get { throw null; } }
        public System.Guid Id { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatusHistoryItem> StatusHistory { get { throw null; } }
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
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Guid Id { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.IngestionSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.IngestionSource (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.PlanetaryComputer.IngestionSource ingestionSource) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.IngestionSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.IngestionSource System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.IngestionSource System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IngestionSourceKind : System.IEquatable<Azure.Analytics.PlanetaryComputer.IngestionSourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IngestionSourceKind(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.IngestionSourceKind BlobManagedIdentity { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.IngestionSourceKind SharedAccessSignatureToken { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.IngestionSourceKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.IngestionSourceKind left, Azure.Analytics.PlanetaryComputer.IngestionSourceKind right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.IngestionSourceKind (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.IngestionSourceKind? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.IngestionSourceKind left, Azure.Analytics.PlanetaryComputer.IngestionSourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IngestionSourceSummary : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.IngestionSourceSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.IngestionSourceSummary>
    {
        internal IngestionSourceSummary() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Guid Id { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.IngestionSourceKind Kind { get { throw null; } }
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
    public readonly partial struct IngestionStatus : System.IEquatable<Azure.Analytics.PlanetaryComputer.IngestionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IngestionStatus(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.IngestionStatus Deleting { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.IngestionStatus Ready { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.IngestionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.IngestionStatus left, Azure.Analytics.PlanetaryComputer.IngestionStatus right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.IngestionStatus (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.IngestionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.IngestionStatus left, Azure.Analytics.PlanetaryComputer.IngestionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LegendConfigKind : System.IEquatable<Azure.Analytics.PlanetaryComputer.LegendConfigKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LegendConfigKind(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.LegendConfigKind Classmap { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.LegendConfigKind Continuous { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.LegendConfigKind Interval { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.LegendConfigKind None { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.LegendConfigKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.LegendConfigKind left, Azure.Analytics.PlanetaryComputer.LegendConfigKind right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.LegendConfigKind (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.LegendConfigKind? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.LegendConfigKind left, Azure.Analytics.PlanetaryComputer.LegendConfigKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LineString : Azure.Analytics.PlanetaryComputer.GeoJsonGeometry, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.LineString>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.LineString>
    {
        public LineString(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<float>> coordinates) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<float>> Coordinates { get { throw null; } }
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
        public virtual Azure.Response GetToken(string collectionId, int? durationInMinutes, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureToken> GetToken(string collectionId, int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTokenAsync(string collectionId, int? durationInMinutes, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureToken>> GetTokenAsync(string collectionId, int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUrl(System.Uri href, int? durationInMinutes, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink> GetUrl(System.Uri href, int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUrlAsync(System.Uri href, int? durationInMinutes, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink>> GetUrlAsync(System.Uri href, int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.Analytics.PlanetaryComputer.MosaicMetadataKind? Kind { get { throw null; } set { } }
        public int? MaxZoom { get { throw null; } set { } }
        public int? MinZoom { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
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
    public readonly partial struct MosaicMetadataKind : System.IEquatable<Azure.Analytics.PlanetaryComputer.MosaicMetadataKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MosaicMetadataKind(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.MosaicMetadataKind Mosaic { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.MosaicMetadataKind Search { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.MosaicMetadataKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.MosaicMetadataKind left, Azure.Analytics.PlanetaryComputer.MosaicMetadataKind right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.MosaicMetadataKind (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.MosaicMetadataKind? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.MosaicMetadataKind left, Azure.Analytics.PlanetaryComputer.MosaicMetadataKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MultiLineString : Azure.Analytics.PlanetaryComputer.GeoJsonGeometry, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.MultiLineString>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.MultiLineString>
    {
        public MultiLineString(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.Collections.Generic.IList<float>>> coordinates) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<System.Collections.Generic.IList<float>>> Coordinates { get { throw null; } }
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
        public MultiPoint(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<float>> coordinates) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<float>> Coordinates { get { throw null; } }
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
        public MultiPolygon(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.Collections.Generic.IList<System.Collections.Generic.IList<float>>>> coordinates) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<System.Collections.Generic.IList<System.Collections.Generic.IList<float>>>> Coordinates { get { throw null; } }
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
    public readonly partial struct NoDataKind : System.IEquatable<Azure.Analytics.PlanetaryComputer.NoDataKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NoDataKind(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.NoDataKind Alpha { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.NoDataKind Internal { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.NoDataKind Mask { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.NoDataKind Nodata { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.NoDataKind None { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.NoDataKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.NoDataKind left, Azure.Analytics.PlanetaryComputer.NoDataKind right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.NoDataKind (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.NoDataKind? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.NoDataKind left, Azure.Analytics.PlanetaryComputer.NoDataKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PartitionKind : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PartitionKind>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PartitionKind>
    {
        public PartitionKind() { }
        public Azure.Analytics.PlanetaryComputer.PartitionKindScheme? Scheme { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.PartitionKind JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.PartitionKind (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.PlanetaryComputer.PartitionKind partitionKind) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.PartitionKind PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.PartitionKind System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PartitionKind>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PartitionKind>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.PartitionKind System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PartitionKind>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PartitionKind>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PartitionKind>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartitionKindScheme : System.IEquatable<Azure.Analytics.PlanetaryComputer.PartitionKindScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartitionKindScheme(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.PartitionKindScheme Month { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PartitionKindScheme None { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PartitionKindScheme Year { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.PartitionKindScheme other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.PartitionKindScheme left, Azure.Analytics.PlanetaryComputer.PartitionKindScheme right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.PartitionKindScheme (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.PartitionKindScheme? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.PartitionKindScheme left, Azure.Analytics.PlanetaryComputer.PartitionKindScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PixelSelection : System.IEquatable<Azure.Analytics.PlanetaryComputer.PixelSelection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PixelSelection(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.PixelSelection Count { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PixelSelection First { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PixelSelection Highest { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PixelSelection LastBandHigh { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PixelSelection LastBandLow { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PixelSelection Lowest { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PixelSelection Mean { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PixelSelection Median { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PixelSelection StandardDeviation { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.PixelSelection other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.PixelSelection left, Azure.Analytics.PlanetaryComputer.PixelSelection right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.PixelSelection (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.PixelSelection? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.PixelSelection left, Azure.Analytics.PlanetaryComputer.PixelSelection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlanetaryComputerErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerErrorInfo>
    {
        internal PlanetaryComputerErrorInfo() { }
        public Azure.ResponseError Error { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.PlanetaryComputerErrorInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.PlanetaryComputerErrorInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.PlanetaryComputerErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.PlanetaryComputerErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class PlanetaryComputerModelFactory
    {
        public static Azure.Analytics.PlanetaryComputer.AssetMetadata AssetMetadata(string key = null, string kind = null, System.Collections.Generic.IEnumerable<string> roles = null, string title = null, string description = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.AssetStatisticsResult AssetStatisticsResult(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.BandStatistics BandStatistics(float minimum = 0f, float maximum = 0f, float mean = 0f, float count = 0f, float sum = 0f, float std = 0f, float median = 0f, float majority = 0f, float minority = 0f, float unique = 0f, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<float>> histogram = null, float validPercent = 0f, float maskedPixels = 0f, float validPixels = 0f, float percentile2 = 0f, float percentile98 = 0f) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.ClassMapLegendResult ClassMapLegendResult(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.CropCollectionFeatureByFormatOptions CropCollectionFeatureByFormatOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string format = null, string coordinateReferenceSystem = null, int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), string destinationCrs = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.CropCollectionFeatureOptions CropCollectionFeatureOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string coordinateReferenceSystem = null, int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), string destinationCrs = null, Azure.Analytics.PlanetaryComputer.TilerImageFormat? format = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.CropCollectionFeatureWidthByHeightOptions CropCollectionFeatureWidthByHeightOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, int width = 0, int height = 0, string format = null, string coordinateReferenceSystem = null, int? maxSize = default(int?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), string destinationCrs = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.CropFeatureByFormatOptions CropFeatureByFormatOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string itemId = null, string format = null, string colorFormula = null, string coordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), string destinationCrs = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.CropFeatureOptions CropFeatureOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string itemId = null, string colorFormula = null, string coordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), string destinationCrs = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TilerImageFormat? format = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.CropFeatureWidthByHeightOptions CropFeatureWidthByHeightOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string itemId = null, int width = 0, int height = 0, string format = null, string colorFormula = null, string coordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), string destinationCrs = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.CropSearchFeatureByFormatOptions CropSearchFeatureByFormatOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string searchId = null, string format = null, string coordinateReferenceSystem = null, int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), string destinationCrs = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.CropSearchFeatureOptions CropSearchFeatureOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string searchId = null, string coordinateReferenceSystem = null, int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), string destinationCrs = null, Azure.Analytics.PlanetaryComputer.TilerImageFormat? format = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.CropSearchFeatureWidthByHeightOptions CropSearchFeatureWidthByHeightOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string searchId = null, int width = 0, int height = 0, string format = null, string coordinateReferenceSystem = null, int? maxSize = default(int?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), string destinationCrs = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.DefaultLocation DefaultLocation(int zoom = 0, System.Collections.Generic.IEnumerable<float> coordinates = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GeoJsonFeature GeoJsonFeature(Azure.Analytics.PlanetaryComputer.GeoJsonGeometry geometry = null, Azure.Analytics.PlanetaryComputer.FeatureKind type = default(Azure.Analytics.PlanetaryComputer.FeatureKind), System.Collections.Generic.IDictionary<string, System.BinaryData> properties = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GeoJsonGeometry GeoJsonGeometry(string type = null, System.Collections.Generic.IEnumerable<float> boundingBox = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForBboxOptions GetCollectionAssetsForBboxOptions(string collectionId = null, int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), float minX = 0f, float minY = 0f, float maxX = 0f, float maxY = 0f, string coordinateReferenceSystem = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileNoTmsOptions GetCollectionAssetsForTileNoTmsOptions(string collectionId = null, int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), float z = 0f, float x = 0f, float y = 0f, Azure.Analytics.PlanetaryComputer.TileMatrixSetId? tileMatrixSetId = default(Azure.Analytics.PlanetaryComputer.TileMatrixSetId?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionAssetsForTileOptions GetCollectionAssetsForTileOptions(string collectionId = null, int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), string tileMatrixSetId = null, float z = 0f, float x = 0f, float y = 0f) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropOptions GetCollectionBboxCropOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, float minX = 0f, float minY = 0f, float maxX = 0f, float maxY = 0f, string format = null, string coordinateReferenceSystem = null, string destinationCrs = null, int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionBboxCropWithDimensionsOptions GetCollectionBboxCropWithDimensionsOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, float minX = 0f, float minY = 0f, float maxX = 0f, float maxY = 0f, int width = 0, int height = 0, string format = null, string coordinateReferenceSystem = null, string destinationCrs = null, int? maxSize = default(int?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionPointAssetsOptions GetCollectionPointAssetsOptions(int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), string collectionId = null, float longitude = 0f, float latitude = 0f, string coordinateReferenceSystem = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionPointOptions GetCollectionPointOptions(string collectionId = null, float longitude = 0f, float latitude = 0f, int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), string coordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionThumbnailOptions GetCollectionThumbnailOptions(string collectionId = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionTileByFormatOptions GetCollectionTileByFormatOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string tileMatrixSetId = null, float z = 0f, float x = 0f, float y = 0f, string format = null, int? scale = default(int?), float? buffer = default(float?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleAndFormatOptions GetCollectionTileByScaleAndFormatOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string tileMatrixSetId = null, float z = 0f, float x = 0f, float y = 0f, float scale = 0f, string format = null, float? buffer = default(float?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionTileByScaleOptions GetCollectionTileByScaleOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string tileMatrixSetId = null, float z = 0f, float x = 0f, float y = 0f, float scale = 0f, Azure.Analytics.PlanetaryComputer.TilerImageFormat? format = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), float? buffer = default(float?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonByTmsOptions GetCollectionTileJsonByTmsOptions(string collectionId = null, string tileMatrixSetId = null, System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, Azure.Analytics.PlanetaryComputer.TilerImageFormat? tileFormat = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? tileScale = default(int?), int? minZoom = default(int?), int? maxZoom = default(int?), float? buffer = default(float?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionTileJsonOptions GetCollectionTileJsonOptions(string collectionId = null, System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, Azure.Analytics.PlanetaryComputer.TileMatrixSetId? tileMatrixSetId = default(Azure.Analytics.PlanetaryComputer.TileMatrixSetId?), Azure.Analytics.PlanetaryComputer.TilerImageFormat? tileFormat = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? tileScale = default(int?), int? minZoom = default(int?), int? maxZoom = default(int?), float? buffer = default(float?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByFormatOptions GetCollectionTileNoTmsByFormatOptions(string collectionId = null, System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, float z = 0f, float x = 0f, float y = 0f, string format = null, Azure.Analytics.PlanetaryComputer.TileMatrixSetId? tileMatrixSetId = default(Azure.Analytics.PlanetaryComputer.TileMatrixSetId?), int? scale = default(int?), float? buffer = default(float?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleAndFormatOptions GetCollectionTileNoTmsByScaleAndFormatOptions(string collectionId = null, System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, float z = 0f, float x = 0f, float y = 0f, Azure.Analytics.PlanetaryComputer.TileMatrixSetId? tileMatrixSetId = default(Azure.Analytics.PlanetaryComputer.TileMatrixSetId?), float scale = 0f, string format = null, float? buffer = default(float?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsByScaleOptions GetCollectionTileNoTmsByScaleOptions(string collectionId = null, System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, float z = 0f, float x = 0f, float y = 0f, float scale = 0f, Azure.Analytics.PlanetaryComputer.TileMatrixSetId? tileMatrixSetId = default(Azure.Analytics.PlanetaryComputer.TileMatrixSetId?), Azure.Analytics.PlanetaryComputer.TilerImageFormat? format = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), float? buffer = default(float?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionTileNoTmsOptions GetCollectionTileNoTmsOptions(string collectionId = null, System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, float z = 0f, float x = 0f, float y = 0f, Azure.Analytics.PlanetaryComputer.TileMatrixSetId? tileMatrixSetId = default(Azure.Analytics.PlanetaryComputer.TileMatrixSetId?), Azure.Analytics.PlanetaryComputer.TilerImageFormat? format = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? scale = default(int?), float? buffer = default(float?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionTileOptions GetCollectionTileOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string tileMatrixSetId = null, float z = 0f, float x = 0f, float y = 0f, Azure.Analytics.PlanetaryComputer.TilerImageFormat? format = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? scale = default(int?), float? buffer = default(float?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionTilesetMetadataOptions GetCollectionTilesetMetadataOptions(string collectionId = null, string tileMatrixSetId = null, string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionTilesetsOptions GetCollectionTilesetsOptions(string collectionId = null, string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesByTmsOptions GetCollectionWmtsCapabilitiesByTmsOptions(string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string collectionId = null, string tileMatrixSetId = null, Azure.Analytics.PlanetaryComputer.TilerImageFormat? tileFormat = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? tileScale = default(int?), int? minZoom = default(int?), int? maxZoom = default(int?), System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetCollectionWmtsCapabilitiesOptions GetCollectionWmtsCapabilitiesOptions(string ids = null, string bbox = null, string query = null, string sortBy = null, string datetime = null, string collectionId = null, Azure.Analytics.PlanetaryComputer.TileMatrixSetId? tileMatrixSetId = default(Azure.Analytics.PlanetaryComputer.TileMatrixSetId?), Azure.Analytics.PlanetaryComputer.TilerImageFormat? tileFormat = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? tileScale = default(int?), int? minZoom = default(int?), int? maxZoom = default(int?), System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetItemAssetStatisticsOptions GetItemAssetStatisticsOptions(string collectionId = null, string itemId = null, System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), bool? categorical = default(bool?), System.Collections.Generic.IEnumerable<int> categoriesPixels = null, System.Collections.Generic.IEnumerable<int> percentiles = null, string histogramBins = null, string histogramRange = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), System.Collections.Generic.IEnumerable<string> assetExpression = null, int? height = default(int?), int? width = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetItemAvailableAssetsOptions GetItemAvailableAssetsOptions(string collectionId = null, string itemId = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetItemBboxCropOptions GetItemBboxCropOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string itemId = null, float minX = 0f, float minY = 0f, float maxX = 0f, float maxY = 0f, string format = null, string colorFormula = null, string coordinateReferenceSystem = null, string destinationCrs = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetItemBboxCropWithDimensionsOptions GetItemBboxCropWithDimensionsOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string itemId = null, float minX = 0f, float minY = 0f, float maxX = 0f, float maxY = 0f, int width = 0, int height = 0, string format = null, string colorFormula = null, string coordinateReferenceSystem = null, string destinationCrs = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetItemCollectionOptions GetItemCollectionOptions(string collectionId = null, int? limit = default(int?), System.Collections.Generic.IEnumerable<string> boundingBox = null, string datetime = null, Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode? sign = default(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode?), int? durationInMinutes = default(int?), string token = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetItemFeatureStatisticsOptions GetItemFeatureStatisticsOptions(string collectionId = null, string itemId = null, System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), string coordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), bool? categorical = default(bool?), System.Collections.Generic.IEnumerable<int> categoriesPixels = null, System.Collections.Generic.IEnumerable<int> percentiles = null, string histogramBins = null, string histogramRange = null, string destinationCrs = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), string algorithm = null, string algorithmParams = null, int? height = default(int?), int? width = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetItemInfoOptions GetItemInfoOptions(string collectionId = null, string itemId = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), System.Collections.Generic.IEnumerable<string> assets = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetItemPointOptions GetItemPointOptions(string collectionId = null, string itemId = null, float longitude = 0f, float latitude = 0f, System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), string coordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetItemPreviewOptions GetItemPreviewOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string itemId = null, Azure.Analytics.PlanetaryComputer.TilerImageFormat? format = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), string colorFormula = null, string dstCrs = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetItemPreviewWithFormatOptions GetItemPreviewWithFormatOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string itemId = null, string format = null, string colorFormula = null, string dstCrs = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetItemStatisticsOptions GetItemStatisticsOptions(string collectionId = null, string itemId = null, System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), int? maxSize = default(int?), bool? categorical = default(bool?), System.Collections.Generic.IEnumerable<int> categoriesPixels = null, System.Collections.Generic.IEnumerable<int> percentiles = null, string histogramBins = null, string histogramRange = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), string algorithm = null, string algorithmParams = null, int? height = default(int?), int? width = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetItemTileJsonByTmsOptions GetItemTileJsonByTmsOptions(string collectionId = null, string itemId = null, string tileMatrixSetId = null, System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, Azure.Analytics.PlanetaryComputer.TilerImageFormat? tileFormat = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? tileScale = default(int?), int? minZoom = default(int?), int? maxZoom = default(int?), float? buffer = default(float?), string colorFormula = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetItemTileJsonOptions GetItemTileJsonOptions(string collectionId = null, string itemId = null, System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, Azure.Analytics.PlanetaryComputer.TileMatrixSetId? tileMatrixSetId = default(Azure.Analytics.PlanetaryComputer.TileMatrixSetId?), Azure.Analytics.PlanetaryComputer.TilerImageFormat? tileFormat = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? tileScale = default(int?), int? minZoom = default(int?), int? maxZoom = default(int?), float? buffer = default(float?), string colorFormula = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetItemTilesetMetadataOptions GetItemTilesetMetadataOptions(string collectionId = null, string itemId = null, string tileMatrixSetId = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetItemTilesetsOptions GetItemTilesetsOptions(string collectionId = null, string itemId = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesByTmsOptions GetItemWmtsCapabilitiesByTmsOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string itemId = null, string tileMatrixSetId = null, Azure.Analytics.PlanetaryComputer.TilerImageFormat? tileFormat = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? tileScale = default(int?), int? minZoom = default(int?), int? maxZoom = default(int?), float? buffer = default(float?), string colorFormula = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetItemWmtsCapabilitiesOptions GetItemWmtsCapabilitiesOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string itemId = null, Azure.Analytics.PlanetaryComputer.TileMatrixSetId? tileMatrixSetId = default(Azure.Analytics.PlanetaryComputer.TileMatrixSetId?), Azure.Analytics.PlanetaryComputer.TilerImageFormat? tileFormat = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? tileScale = default(int?), int? minZoom = default(int?), int? maxZoom = default(int?), float? buffer = default(float?), string colorFormula = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetLegendOptions GetLegendOptions(string colorMapName = null, float? height = default(float?), float? width = default(float?), int? trimStart = default(int?), int? trimEnd = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileNoTmsOptions GetSearchAssetsForTileNoTmsOptions(string searchId = null, int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), float z = 0f, float x = 0f, float y = 0f, Azure.Analytics.PlanetaryComputer.TileMatrixSetId? tileMatrixSetId = default(Azure.Analytics.PlanetaryComputer.TileMatrixSetId?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchAssetsForTileOptions GetSearchAssetsForTileOptions(string searchId = null, int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), string tileMatrixSetId = null, string collectionId = null, float z = 0f, float x = 0f, float y = 0f) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchBboxAssetsOptions GetSearchBboxAssetsOptions(string searchId = null, int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), float minX = 0f, float minY = 0f, float maxX = 0f, float maxY = 0f, string coordinateReferenceSystem = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchBboxCropOptions GetSearchBboxCropOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string searchId = null, float minX = 0f, float minY = 0f, float maxX = 0f, float maxY = 0f, string format = null, string coordinateReferenceSystem = null, string destinationCrs = null, int? maxSize = default(int?), int? height = default(int?), int? width = default(int?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchBboxCropWithDimensionsOptions GetSearchBboxCropWithDimensionsOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string searchId = null, float minX = 0f, float minY = 0f, float maxX = 0f, float maxY = 0f, int width = 0, int height = 0, string format = null, string coordinateReferenceSystem = null, string destinationCrs = null, int? maxSize = default(int?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchPointOptions GetSearchPointOptions(string searchId = null, float longitude = 0f, float latitude = 0f, int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), string coordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchPointWithAssetsOptions GetSearchPointWithAssetsOptions(int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), string searchId = null, float longitude = 0f, float latitude = 0f, string coordinateReferenceSystem = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchTileByFormatOptions GetSearchTileByFormatOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string searchId = null, string tileMatrixSetId = null, float z = 0f, float x = 0f, float y = 0f, string format = null, int? scale = default(int?), float? buffer = default(float?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleAndFormatOptions GetSearchTileByScaleAndFormatOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string searchId = null, string tileMatrixSetId = null, float z = 0f, float x = 0f, float y = 0f, float scale = 0f, string format = null, float? buffer = default(float?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchTileByScaleOptions GetSearchTileByScaleOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string searchId = null, string tileMatrixSetId = null, float z = 0f, float x = 0f, float y = 0f, float scale = 0f, Azure.Analytics.PlanetaryComputer.TilerImageFormat? format = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), float? buffer = default(float?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchTileJsonByTmsOptions GetSearchTileJsonByTmsOptions(string searchId = null, string tileMatrixSetId = null, System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, Azure.Analytics.PlanetaryComputer.TilerImageFormat? tileFormat = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? tileScale = default(int?), int? minZoom = default(int?), int? maxZoom = default(int?), float? buffer = default(float?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchTileJsonOptions GetSearchTileJsonOptions(string searchId = null, System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TileMatrixSetId? tileMatrixSetId = default(Azure.Analytics.PlanetaryComputer.TileMatrixSetId?), Azure.Analytics.PlanetaryComputer.TilerImageFormat? tileFormat = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? tileScale = default(int?), int? minZoom = default(int?), int? maxZoom = default(int?), int? padding = default(int?), float? buffer = default(float?), string colorFormula = null, string collectionId = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colormapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colormap = null, bool? returnMask = default(bool?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByFormatOptions GetSearchTileNoTmsByFormatOptions(string searchId = null, System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, float z = 0f, float x = 0f, float y = 0f, string format = null, Azure.Analytics.PlanetaryComputer.TileMatrixSetId? tileMatrixSetId = default(Azure.Analytics.PlanetaryComputer.TileMatrixSetId?), int? scale = default(int?), float? buffer = default(float?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleAndFormatOptions GetSearchTileNoTmsByScaleAndFormatOptions(string searchId = null, System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, float z = 0f, float x = 0f, float y = 0f, Azure.Analytics.PlanetaryComputer.TileMatrixSetId? tileMatrixSetId = default(Azure.Analytics.PlanetaryComputer.TileMatrixSetId?), float scale = 0f, string format = null, float? buffer = default(float?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsByScaleOptions GetSearchTileNoTmsByScaleOptions(string searchId = null, System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, float z = 0f, float x = 0f, float y = 0f, float scale = 0f, Azure.Analytics.PlanetaryComputer.TileMatrixSetId? tileMatrixSetId = default(Azure.Analytics.PlanetaryComputer.TileMatrixSetId?), Azure.Analytics.PlanetaryComputer.TilerImageFormat? format = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), float? buffer = default(float?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchTileNoTmsOptions GetSearchTileNoTmsOptions(string searchId = null, System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, float z = 0f, float x = 0f, float y = 0f, Azure.Analytics.PlanetaryComputer.TileMatrixSetId? tileMatrixSetId = default(Azure.Analytics.PlanetaryComputer.TileMatrixSetId?), Azure.Analytics.PlanetaryComputer.TilerImageFormat? format = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? scale = default(int?), float? buffer = default(float?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchTileOptions GetSearchTileOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), int? scanLimit = default(int?), int? itemsLimit = default(int?), int? timeLimit = default(int?), bool? exitWhenFull = default(bool?), bool? skipCovered = default(bool?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string searchId = null, string tileMatrixSetId = null, float z = 0f, float x = 0f, float y = 0f, Azure.Analytics.PlanetaryComputer.TilerImageFormat? format = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? scale = default(int?), float? buffer = default(float?), string colorFormula = null, string collection = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), Azure.Analytics.PlanetaryComputer.PixelSelection? pixelSelection = default(Azure.Analytics.PlanetaryComputer.PixelSelection?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchTilesetMetadataOptions GetSearchTilesetMetadataOptions(string searchId = null, string tileMatrixSetId = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchTilesetsOptions GetSearchTilesetsOptions(string searchId = null, string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesByTmsOptions GetSearchWmtsCapabilitiesByTmsOptions(string searchId = null, string tileMatrixSetId = null, Azure.Analytics.PlanetaryComputer.TilerImageFormat? tileFormat = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? tileScale = default(int?), int? minZoom = default(int?), int? maxZoom = default(int?), System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetSearchWmtsCapabilitiesOptions GetSearchWmtsCapabilitiesOptions(string searchId = null, Azure.Analytics.PlanetaryComputer.TileMatrixSetId? tileMatrixSetId = default(Azure.Analytics.PlanetaryComputer.TileMatrixSetId?), Azure.Analytics.PlanetaryComputer.TilerImageFormat? tileFormat = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? tileScale = default(int?), int? minZoom = default(int?), int? maxZoom = default(int?), System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetTileByFormatOptions GetTileByFormatOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string itemId = null, string tileMatrixSetId = null, float z = 0f, float x = 0f, float y = 0f, string format = null, int? scale = default(int?), float? buffer = default(float?), string colorFormula = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetTileByScaleAndFormatOptions GetTileByScaleAndFormatOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string itemId = null, string tileMatrixSetId = null, float z = 0f, float x = 0f, float y = 0f, float scale = 0f, string format = null, float? buffer = default(float?), string colorFormula = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetTileByScaleOptions GetTileByScaleOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string itemId = null, string tileMatrixSetId = null, float z = 0f, float x = 0f, float y = 0f, float scale = 0f, Azure.Analytics.PlanetaryComputer.TilerImageFormat? format = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), float? buffer = default(float?), string colorFormula = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetTileNoTmsByFormatOptions GetTileNoTmsByFormatOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string itemId = null, float z = 0f, float x = 0f, float y = 0f, string format = null, Azure.Analytics.PlanetaryComputer.TileMatrixSetId? tileMatrixSetId = default(Azure.Analytics.PlanetaryComputer.TileMatrixSetId?), int? scale = default(int?), float? buffer = default(float?), string colorFormula = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleAndFormatOptions GetTileNoTmsByScaleAndFormatOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string itemId = null, float z = 0f, float x = 0f, float y = 0f, Azure.Analytics.PlanetaryComputer.TileMatrixSetId? tileMatrixSetId = default(Azure.Analytics.PlanetaryComputer.TileMatrixSetId?), float scale = 0f, string format = null, float? buffer = default(float?), string colorFormula = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetTileNoTmsByScaleOptions GetTileNoTmsByScaleOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string itemId = null, float z = 0f, float x = 0f, float y = 0f, float scale = 0f, Azure.Analytics.PlanetaryComputer.TileMatrixSetId? tileMatrixSetId = default(Azure.Analytics.PlanetaryComputer.TileMatrixSetId?), Azure.Analytics.PlanetaryComputer.TilerImageFormat? format = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), float? buffer = default(float?), string colorFormula = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetTileNoTmsOptions GetTileNoTmsOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string itemId = null, float z = 0f, float x = 0f, float y = 0f, Azure.Analytics.PlanetaryComputer.TileMatrixSetId? tileMatrixSetId = default(Azure.Analytics.PlanetaryComputer.TileMatrixSetId?), Azure.Analytics.PlanetaryComputer.TilerImageFormat? format = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? scale = default(int?), float? buffer = default(float?), string colorFormula = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.GetTileOptions GetTileOptions(System.Collections.Generic.IEnumerable<int> bidx = null, System.Collections.Generic.IEnumerable<string> assets = null, string expression = null, System.Collections.Generic.IEnumerable<string> assetBandIndices = null, bool? assetAsBand = default(bool?), string noData = null, bool? unscale = default(bool?), Azure.Analytics.PlanetaryComputer.WarpKernelResampling? reproject = default(Azure.Analytics.PlanetaryComputer.WarpKernelResampling?), Azure.Analytics.PlanetaryComputer.TerrainAlgorithm? algorithm = default(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm?), string algorithmParams = null, string collectionId = null, string itemId = null, string tileMatrixSetId = null, float z = 0f, float x = 0f, float y = 0f, Azure.Analytics.PlanetaryComputer.TilerImageFormat? format = default(Azure.Analytics.PlanetaryComputer.TilerImageFormat?), int? scale = default(int?), float? buffer = default(float?), string colorFormula = null, Azure.Analytics.PlanetaryComputer.ResamplingMethod? resampling = default(Azure.Analytics.PlanetaryComputer.ResamplingMethod?), System.Collections.Generic.IEnumerable<string> rescale = null, Azure.Analytics.PlanetaryComputer.ColorMapNames? colorMapName = default(Azure.Analytics.PlanetaryComputer.ColorMapNames?), string colorMap = null, bool? returnMask = default(bool?), int? padding = default(int?), string subdatasetName = null, System.Collections.Generic.IEnumerable<int> subdatasetBands = null, string crs = null, string datetime = null, System.Collections.Generic.IEnumerable<string> sel = null, Azure.Analytics.PlanetaryComputer.SelMethod? selMethod = default(Azure.Analytics.PlanetaryComputer.SelMethod?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.IngestionInformation IngestionInformation(System.Guid id = default(System.Guid), Azure.Analytics.PlanetaryComputer.IngestionKind importKind = default(Azure.Analytics.PlanetaryComputer.IngestionKind), string displayName = null, System.Uri sourceCatalogUri = null, System.Uri stacGeoparquetUri = null, bool? skipExistingItems = default(bool?), bool? keepOriginalAssets = default(bool?), System.DateTimeOffset createdOn = default(System.DateTimeOffset), Azure.Analytics.PlanetaryComputer.IngestionStatus status = default(Azure.Analytics.PlanetaryComputer.IngestionStatus)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.IngestionRun IngestionRun(System.Guid id = default(System.Guid), System.Guid? parentRunId = default(System.Guid?), Azure.Analytics.PlanetaryComputer.IngestionRunInformation operation = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.Uri sourceCatalogUri = null, bool? skipExistingItems = default(bool?), bool? keepOriginalAssets = default(bool?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.IngestionRunInformation IngestionRunInformation(System.Guid id = default(System.Guid), Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus status = default(Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus), System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatusHistoryItem> statusHistory = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? finishedOn = default(System.DateTimeOffset?), int totalItems = 0, int totalPendingItems = 0, int totalSuccessfulItems = 0, int totalFailedItems = 0) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.IngestionSource IngestionSource(System.Guid id = default(System.Guid), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string kind = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.IngestionSourceSummary IngestionSourceSummary(System.Guid id = default(System.Guid), Azure.Analytics.PlanetaryComputer.IngestionSourceKind kind = default(Azure.Analytics.PlanetaryComputer.IngestionSourceKind), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.LineString LineString(System.Collections.Generic.IEnumerable<float> boundingBox = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<float>> coordinates = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.ManagedIdentityConnection ManagedIdentityConnection(System.Uri containerUri = null, System.Guid objectId = default(System.Guid)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.ManagedIdentityIngestionSource ManagedIdentityIngestionSource(System.Guid id = default(System.Guid), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.Analytics.PlanetaryComputer.ManagedIdentityConnection connectionInfo = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.ManagedIdentityMetadata ManagedIdentityMetadata(System.Guid objectId = default(System.Guid), Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.MosaicMetadata MosaicMetadata(Azure.Analytics.PlanetaryComputer.MosaicMetadataKind? kind = default(Azure.Analytics.PlanetaryComputer.MosaicMetadataKind?), string bounds = null, int? minZoom = default(int?), int? maxZoom = default(int?), string name = null, System.Collections.Generic.IEnumerable<string> assets = null, System.Collections.Generic.IDictionary<string, string> defaults = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.MultiLineString MultiLineString(System.Collections.Generic.IEnumerable<float> boundingBox = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.Collections.Generic.IList<float>>> coordinates = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.MultiPoint MultiPoint(System.Collections.Generic.IEnumerable<float> boundingBox = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<float>> coordinates = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.MultiPolygon MultiPolygon(System.Collections.Generic.IEnumerable<float> boundingBox = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.Collections.Generic.IList<System.Collections.Generic.IList<float>>>> coordinates = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.PartitionKind PartitionKind(Azure.Analytics.PlanetaryComputer.PartitionKindScheme? scheme = default(Azure.Analytics.PlanetaryComputer.PartitionKindScheme?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.PlanetaryComputerErrorInfo PlanetaryComputerErrorInfo(Azure.ResponseError error = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperation PlanetaryComputerOperation(System.Guid id = default(System.Guid), Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus status = default(Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus), string kind = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), string collectionId = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatusHistoryItem> statusHistory = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? finishedOn = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, string> additionalInformation = null, Azure.Analytics.PlanetaryComputer.PlanetaryComputerErrorInfo error = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatusHistoryItem PlanetaryComputerOperationStatusHistoryItem(System.DateTimeOffset occurredOn = default(System.DateTimeOffset), Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus status = default(Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus), string errorCode = null, string errorMessage = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.PointGeometry PointGeometry(System.Collections.Generic.IEnumerable<float> boundingBox = null, System.Collections.Generic.IEnumerable<float> coordinates = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.PolygonGeometry PolygonGeometry(System.Collections.Generic.IEnumerable<float> boundingBox = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.Collections.Generic.IList<float>>> coordinates = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.QueryableDefinitionsResult QueryableDefinitionsResult(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.RegisterMosaic RegisterMosaic(System.Collections.Generic.IEnumerable<string> collections = null, System.Collections.Generic.IEnumerable<string> ids = null, System.Collections.Generic.IEnumerable<float> boundingBox = null, Azure.Analytics.PlanetaryComputer.GeoJsonGeometry intersects = null, System.Collections.Generic.IDictionary<string, System.BinaryData> query = null, System.Collections.Generic.IDictionary<string, System.BinaryData> filter = null, string datetime = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacSortExtension> sortBy = null, Azure.Analytics.PlanetaryComputer.FilterLanguage? filterLanguage = default(Azure.Analytics.PlanetaryComputer.FilterLanguage?), Azure.Analytics.PlanetaryComputer.MosaicMetadata metadata = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.RenderConfiguration RenderConfiguration(string id = null, string name = null, string description = null, Azure.Analytics.PlanetaryComputer.RenderOptionKind? kind = default(Azure.Analytics.PlanetaryComputer.RenderOptionKind?), string options = null, Azure.Analytics.PlanetaryComputer.RenderOptionVectorOptions vectorOptions = null, int? minZoom = default(int?), Azure.Analytics.PlanetaryComputer.RenderOptionLegend legend = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.RenderOptionCondition> conditions = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.RenderOptionCondition RenderOptionCondition(string property = null, string value = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.RenderOptionLegend RenderOptionLegend(Azure.Analytics.PlanetaryComputer.LegendConfigKind? kind = default(Azure.Analytics.PlanetaryComputer.LegendConfigKind?), System.Collections.Generic.IEnumerable<string> labels = null, int? trimStart = default(int?), int? trimEnd = default(int?), float? scaleFactor = default(float?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.RenderOptionVectorOptions RenderOptionVectorOptions(string tileJsonKey = null, string sourceLayer = null, string fillColor = null, string strokeColor = null, int? strokeWidth = default(int?), System.Collections.Generic.IEnumerable<string> filter = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.SearchOptionsFields SearchOptionsFields(System.Collections.Generic.IEnumerable<string> include = null, System.Collections.Generic.IEnumerable<string> exclude = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink SharedAccessSignatureSignedLink(System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), System.Uri href = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.SharedAccessSignatureToken SharedAccessSignatureToken(System.DateTimeOffset expiresOn = default(System.DateTimeOffset), string token = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenConnection SharedAccessSignatureTokenConnection(System.Uri containerUri = null, string sharedAccessSignatureToken = null, System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenIngestionSource SharedAccessSignatureTokenIngestionSource(System.Guid id = default(System.Guid), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.Analytics.PlanetaryComputer.SharedAccessSignatureTokenConnection connectionInfo = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacAsset StacAsset(string platform = null, System.Collections.Generic.IEnumerable<string> instruments = null, string constellation = null, string mission = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacProvider> providers = null, float? gsd = default(float?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string title = null, string description = null, string href = null, string kind = null, System.Collections.Generic.IEnumerable<string> roles = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0004")]
        public static Azure.Analytics.PlanetaryComputer.StacAssetData StacAssetData(Azure.Analytics.PlanetaryComputer.AssetMetadata data = null, System.ClientModel.FileBinaryContent file = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacCatalogCollections StacCatalogCollections(System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacLink> links = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacCollection> collections = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacCollection StacCollection(System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string shortDescription = null, System.Collections.Generic.IEnumerable<string> stacExtensions = null, string id = null, string description = null, string stacVersion = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacLink> links = null, string title = null, string kind = null, System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.StacAsset> assets = null, System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.StacItemAsset> itemAssets = null, string license = null, Azure.Analytics.PlanetaryComputer.StacExtensionExtent extent = null, System.Collections.Generic.IEnumerable<string> keywords = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacProvider> providers = null, System.Collections.Generic.IDictionary<string, System.BinaryData> summaries = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacCollectionTemporalExtent StacCollectionTemporalExtent(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<string>> interval = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacConformanceClasses StacConformanceClasses(System.Collections.Generic.IEnumerable<System.Uri> conformsTo = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacContextExtension StacContextExtension(int returned = 0, int? limit = default(int?), int? matched = default(int?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacExtensionExtent StacExtensionExtent(Azure.Analytics.PlanetaryComputer.StacExtensionSpatialExtent spatial = null, Azure.Analytics.PlanetaryComputer.StacCollectionTemporalExtent temporal = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacExtensionSpatialExtent StacExtensionSpatialExtent(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<float>> boundingBox = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacItem StacItem(string stacVersion = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacLink> links = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string shortDescription = null, System.Collections.Generic.IEnumerable<string> stacExtensions = null, Azure.Analytics.PlanetaryComputer.GeoJsonGeometry geometry = null, string id = null, string collection = null, System.Collections.Generic.IEnumerable<float> boundingBox = null, Azure.Analytics.PlanetaryComputer.StacItemProperties properties = null, System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.StacAsset> assets = null, System.DateTimeOffset? recordedOn = default(System.DateTimeOffset?), Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacItemAsset StacItemAsset(string platform = null, System.Collections.Generic.IEnumerable<string> instruments = null, string constellation = null, string mission = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacProvider> providers = null, float? gsd = default(float?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string title = null, string description = null, string href = null, string kind = null, System.Collections.Generic.IEnumerable<string> roles = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacItemBounds StacItemBounds(System.Collections.Generic.IEnumerable<float> bounds = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacItemCollection StacItemCollection(string stacVersion = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacLink> links = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string shortDescription = null, System.Collections.Generic.IEnumerable<string> stacExtensions = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacItem> features = null, System.Collections.Generic.IEnumerable<float> boundingBox = null, Azure.Analytics.PlanetaryComputer.StacContextExtension context = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection StacItemOrStacItemCollection(string kind = null, string stacVersion = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacLink> links = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string shortDescription = null, System.Collections.Generic.IEnumerable<string> stacExtensions = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacItemPointAsset StacItemPointAsset(string id = null, System.Collections.Generic.IEnumerable<float> boundingBox = null, System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.StacAsset> assets = null, string collectionId = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacItemProperties StacItemProperties(string platform = null, System.Collections.Generic.IEnumerable<string> instruments = null, string constellation = null, string mission = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacProvider> providers = null, float? gsd = default(float?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string title = null, string description = null, string datetime = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson StacItemStatisticsGeoJson(Azure.Analytics.PlanetaryComputer.GeoJsonGeometry geometry = null, Azure.Analytics.PlanetaryComputer.FeatureKind type = default(Azure.Analytics.PlanetaryComputer.FeatureKind), Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJsonProperties properties = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJsonProperties StacItemStatisticsGeoJsonProperties(System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.BandStatistics> statistics = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacLandingPage StacLandingPage(System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string shortDescription = null, System.Collections.Generic.IEnumerable<string> stacExtensions = null, string id = null, string description = null, string title = null, string stacVersion = null, System.Collections.Generic.IEnumerable<System.Uri> conformsTo = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacLink> links = null, string kind = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacLink StacLink(string rel = null, string title = null, Azure.Analytics.PlanetaryComputer.StacLinkKind? kind = default(Azure.Analytics.PlanetaryComputer.StacLinkKind?), string href = null, string hreflang = null, int? length = default(int?), Azure.Analytics.PlanetaryComputer.StacLinkMethod? method = default(Azure.Analytics.PlanetaryComputer.StacLinkMethod?), System.Collections.Generic.IDictionary<string, string> headers = null, System.Collections.Generic.IDictionary<string, System.BinaryData> body = null, bool? merge = default(bool?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacMosaic StacMosaic(string id = null, string name = null, string description = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> cql = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacMosaicConfiguration StacMosaicConfiguration(System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacMosaic> mosaics = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.RenderConfiguration> renderOptions = null, Azure.Analytics.PlanetaryComputer.DefaultLocation defaultLocation = null, System.Collections.Generic.IDictionary<string, System.BinaryData> defaultCustomQuery = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacProvider StacProvider(string name = null, string description = null, System.Collections.Generic.IEnumerable<string> roles = null, string url = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacQueryable StacQueryable(string name = null, System.Collections.Generic.IDictionary<string, System.BinaryData> definition = null, bool? createIndex = default(bool?), Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataKind? dataKind = default(Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataKind?)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacSearchParameters StacSearchParameters(System.Collections.Generic.IEnumerable<string> collections = null, System.Collections.Generic.IEnumerable<string> ids = null, System.Collections.Generic.IEnumerable<float> boundingBox = null, Azure.Analytics.PlanetaryComputer.GeoJsonGeometry intersects = null, string datetime = null, int? limit = default(int?), System.Collections.Generic.IDictionary<string, System.BinaryData> conformanceClass = null, System.Collections.Generic.IDictionary<string, System.BinaryData> query = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacSortExtension> sortBy = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.SearchOptionsFields> fields = null, System.Collections.Generic.IDictionary<string, System.BinaryData> filter = null, string filterCoordinateReferenceSystem = null, Azure.Analytics.PlanetaryComputer.FilterLanguage? filterLang = default(Azure.Analytics.PlanetaryComputer.FilterLanguage?), string token = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacSortExtension StacSortExtension(string field = null, Azure.Analytics.PlanetaryComputer.StacSearchSortingDirection direction = default(Azure.Analytics.PlanetaryComputer.StacSearchSortingDirection)) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TileJsonMetadata TileJsonMetadata(string tileJson = null, string name = null, string description = null, string version = null, string attribution = null, string template = null, string legend = null, Azure.Analytics.PlanetaryComputer.TileAddressingScheme? scheme = default(Azure.Analytics.PlanetaryComputer.TileAddressingScheme?), System.Collections.Generic.IEnumerable<string> tiles = null, System.Collections.Generic.IEnumerable<string> grids = null, System.Collections.Generic.IEnumerable<string> data = null, int? minZoom = default(int?), int? maxZoom = default(int?), System.Collections.Generic.IEnumerable<float> bounds = null, System.Collections.Generic.IEnumerable<float> center = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TileMatrix TileMatrix(string title = null, string description = null, System.Collections.Generic.IEnumerable<string> keywords = null, string id = null, float scaleDenominator = 0f, float cellSize = 0f, Azure.Analytics.PlanetaryComputer.TileMatrixCornerOfOrigin? cornerOfOrigin = default(Azure.Analytics.PlanetaryComputer.TileMatrixCornerOfOrigin?), System.Collections.Generic.IEnumerable<float> pointOfOrigin = null, int tileWidth = 0, int tileHeight = 0, int matrixWidth = 0, int matrixHeight = 0, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.VariableMatrixWidth> variableMatrixWidths = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TileMatrixSet TileMatrixSet(string title = null, string description = null, System.Collections.Generic.IEnumerable<string> keywords = null, string id = null, string uri = null, System.Collections.Generic.IEnumerable<string> orderedAxes = null, string crs = null, System.Uri wellKnownScaleSet = null, Azure.Analytics.PlanetaryComputer.TileMatrixSetBoundingBox boundingBox = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.TileMatrix> tileMatrices = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TileMatrixSetBoundingBox TileMatrixSetBoundingBox(System.Collections.Generic.IEnumerable<string> lowerLeft = null, System.Collections.Generic.IEnumerable<string> upperRight = null, string crs = null, System.Collections.Generic.IEnumerable<string> orderedAxes = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TileMatrixSetLimitsEntry TileMatrixSetLimitsEntry(string tileMatrix = null, int minTileRow = 0, int maxTileRow = 0, int minTileCol = 0, int maxTileCol = 0) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TilerAssetGeoJson TilerAssetGeoJson(string id = null, string collection = null, System.Collections.Generic.IEnumerable<float> boundingBox = null, System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.StacAsset> assets = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint TilerCoreModelsResponsesPoint(System.Collections.Generic.IEnumerable<float> coordinates = null, System.Collections.Generic.IEnumerable<float> values = null, System.Collections.Generic.IEnumerable<string> bandNames = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TilerInfo TilerInfo(System.Collections.Generic.IEnumerable<float> bounds = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.BinaryData>> bandMetadata = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<string>> bandDescriptions = null, string dataType = null, Azure.Analytics.PlanetaryComputer.NoDataKind? noDataType = default(Azure.Analytics.PlanetaryComputer.NoDataKind?), System.Collections.Generic.IEnumerable<string> colorInterpretation = null, string driver = null, int? count = default(int?), int? width = default(int?), int? height = default(int?), System.Collections.Generic.IEnumerable<int> overviews = null, System.Collections.Generic.IEnumerable<int> scales = null, System.Collections.Generic.IEnumerable<int> offsets = null, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> colorMap = null, int? minZoom = default(int?), int? maxZoom = default(int?), string coordinateReferenceSystem = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature TilerInfoGeoJsonFeature(Azure.Analytics.PlanetaryComputer.FeatureKind type = default(Azure.Analytics.PlanetaryComputer.FeatureKind), Azure.Analytics.PlanetaryComputer.GeoJsonGeometry geometry = null, System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.TilerInfo> properties = null, string id = null, System.Collections.Generic.IEnumerable<float> boundingBox = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TilerInfoMapResult TilerInfoMapResult(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult TilerMosaicSearchRegistrationResult(string searchId = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacLink> links = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TilerStacItemStatistics TilerStacItemStatistics(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TilerStacSearchDefinition TilerStacSearchDefinition(string hash = null, System.Collections.Generic.IDictionary<string, System.BinaryData> search = null, System.DateTimeOffset lastUsedOn = default(System.DateTimeOffset), int useCount = 0, Azure.Analytics.PlanetaryComputer.MosaicMetadata metadata = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration TilerStacSearchRegistration(Azure.Analytics.PlanetaryComputer.TilerStacSearchDefinition search = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacLink> links = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TileSetBoundingBox TileSetBoundingBox(System.Collections.Generic.IEnumerable<double> lowerLeft = null, System.Collections.Generic.IEnumerable<double> upperRight = null, string crs = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TileSetEntry TileSetEntry(string title = null, string dataType = null, string crs = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.TileSetLink> links = null, Azure.Analytics.PlanetaryComputer.TileSetBoundingBox boundingBox = null, string accessConstraints = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TileSetLink TileSetLink(string href = null, string rel = null, string kind = null, string title = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TileSetList TileSetList(System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.TileSetEntry> tilesets = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TileSetMetadata TileSetMetadata(string title = null, string dataType = null, string crs = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.TileSetLink> links = null, Azure.Analytics.PlanetaryComputer.TileSetBoundingBox boundingBox = null, string accessConstraints = null, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.TileMatrixSetLimitsEntry> tileMatrixSetLimits = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TileSettings TileSettings(int minZoom = 0, int maxItemsPerTile = 0, Azure.Analytics.PlanetaryComputer.DefaultLocation defaultLocation = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.UserCollectionSettings UserCollectionSettings(Azure.Analytics.PlanetaryComputer.TileSettings tileSettings = null, Azure.Analytics.PlanetaryComputer.StacMosaicConfiguration mosaicConfiguration = null) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.VariableMatrixWidth VariableMatrixWidth(int coalesce = 0, int minTileRow = 0, int maxTileRow = 0) { throw null; }
    }
    public partial class PlanetaryComputerOperation : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperation>
    {
        internal PlanetaryComputerOperation() { }
        public System.Collections.Generic.IDictionary<string, string> AdditionalInformation { get { throw null; } }
        public string CollectionId { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.PlanetaryComputerErrorInfo Error { get { throw null; } }
        public System.DateTimeOffset? FinishedOn { get { throw null; } }
        public System.Guid Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatusHistoryItem> StatusHistory { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperation (Azure.Response response) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperation System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperation System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlanetaryComputerOperationStatus : System.IEquatable<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlanetaryComputerOperationStatus(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus Canceled { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus Canceling { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus Failed { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus Pending { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus Running { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus left, Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus left, Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlanetaryComputerOperationStatusHistoryItem : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatusHistoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatusHistoryItem>
    {
        internal PlanetaryComputerOperationStatusHistoryItem() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public System.DateTimeOffset OccurredOn { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatus Status { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatusHistoryItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatusHistoryItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatusHistoryItem System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatusHistoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatusHistoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatusHistoryItem System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatusHistoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatusHistoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PlanetaryComputerOperationStatusHistoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlanetaryComputerProClient
    {
        protected PlanetaryComputerProClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public PlanetaryComputerProClient(Azure.Analytics.PlanetaryComputer.PlanetaryComputerProClientSettings settings) { }
        public PlanetaryComputerProClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public PlanetaryComputerProClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.PlanetaryComputer.PlanetaryComputerProClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Analytics.PlanetaryComputer.DataClient GetDataClient() { throw null; }
        public virtual Azure.Analytics.PlanetaryComputer.IngestionClient GetIngestionClient() { throw null; }
        public virtual Azure.Analytics.PlanetaryComputer.ManagedStorageSharedAccessSignatureClient GetManagedStorageSharedAccessSignatureClient() { throw null; }
        public virtual Azure.Analytics.PlanetaryComputer.StacClient GetStacClient() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public static partial class PlanetaryComputerProClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedPlanetaryComputerProClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedPlanetaryComputerProClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.Analytics.PlanetaryComputer.PlanetaryComputerProClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddPlanetaryComputerProClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddPlanetaryComputerProClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.Analytics.PlanetaryComputer.PlanetaryComputerProClientSettings> configureSettings) { throw null; }
    }
    public partial class PlanetaryComputerProClientOptions : Azure.Core.ClientOptions
    {
        public PlanetaryComputerProClientOptions(Azure.Analytics.PlanetaryComputer.PlanetaryComputerProClientOptions.ServiceVersion version = Azure.Analytics.PlanetaryComputer.PlanetaryComputerProClientOptions.ServiceVersion.V2026_04_15) { }
        public enum ServiceVersion
        {
            V2026_04_15 = 1,
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class PlanetaryComputerProClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public PlanetaryComputerProClientSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.PlanetaryComputerProClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public partial class PointGeometry : Azure.Analytics.PlanetaryComputer.GeoJsonGeometry, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.PointGeometry>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.PointGeometry>
    {
        public PointGeometry(System.Collections.Generic.IEnumerable<float> coordinates) { }
        public System.Collections.Generic.IList<float> Coordinates { get { throw null; } }
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
    public partial class QueryableDefinitionsResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.QueryableDefinitionsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.QueryableDefinitionsResult>
    {
        internal QueryableDefinitionsResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.QueryableDefinitionsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.QueryableDefinitionsResult (Azure.Response response) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.QueryableDefinitionsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.QueryableDefinitionsResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.QueryableDefinitionsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.QueryableDefinitionsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.QueryableDefinitionsResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.QueryableDefinitionsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.QueryableDefinitionsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.QueryableDefinitionsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegisterMosaic : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.RegisterMosaic>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RegisterMosaic>
    {
        public RegisterMosaic() { }
        public System.Collections.Generic.IList<float> BoundingBox { get { throw null; } }
        public System.Collections.Generic.IList<string> Collections { get { throw null; } }
        public string Datetime { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Filter { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.FilterLanguage? FilterLanguage { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Ids { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.GeoJsonGeometry Intersects { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.MosaicMetadata Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Query { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacSortExtension> SortBy { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.RegisterMosaic JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.RegisterMosaic PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.RegisterMosaic System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.RegisterMosaic>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.RegisterMosaic>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.RegisterMosaic System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RegisterMosaic>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RegisterMosaic>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RegisterMosaic>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RenderConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.RenderConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RenderConfiguration>
    {
        public RenderConfiguration(string id, string name) { }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.RenderOptionCondition> Conditions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.RenderOptionKind? Kind { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.RenderOptionLegend Legend { get { throw null; } set { } }
        public int? MinZoom { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Options { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.RenderOptionVectorOptions VectorOptions { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.RenderConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.RenderConfiguration (Azure.Response response) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RenderOptionKind : System.IEquatable<Azure.Analytics.PlanetaryComputer.RenderOptionKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RenderOptionKind(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.RenderOptionKind RasterTile { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.RenderOptionKind VtLine { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.RenderOptionKind VtPolygon { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.RenderOptionKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.RenderOptionKind left, Azure.Analytics.PlanetaryComputer.RenderOptionKind right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.RenderOptionKind (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.RenderOptionKind? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.RenderOptionKind left, Azure.Analytics.PlanetaryComputer.RenderOptionKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RenderOptionLegend : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.RenderOptionLegend>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RenderOptionLegend>
    {
        public RenderOptionLegend() { }
        public Azure.Analytics.PlanetaryComputer.LegendConfigKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        public float? ScaleFactor { get { throw null; } set { } }
        public int? TrimEnd { get { throw null; } set { } }
        public int? TrimStart { get { throw null; } set { } }
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
    public partial class RenderOptionVectorOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.RenderOptionVectorOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.RenderOptionVectorOptions>
    {
        public RenderOptionVectorOptions(string tileJsonKey, string sourceLayer) { }
        public string FillColor { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Filter { get { throw null; } }
        public string SourceLayer { get { throw null; } set { } }
        public string StrokeColor { get { throw null; } set { } }
        public int? StrokeWidth { get { throw null; } set { } }
        public string TileJsonKey { get { throw null; } set { } }
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
        public override bool Equals(object obj) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SelMethod : System.IEquatable<Azure.Analytics.PlanetaryComputer.SelMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SelMethod(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.SelMethod Area { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.SelMethod Bilinear { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.SelMethod Cubic { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.SelMethod CubicSpline { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.SelMethod Lanczos { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.SelMethod Linear { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.SelMethod Mode { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.SelMethod Nearest { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.SelMethod other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.SelMethod left, Azure.Analytics.PlanetaryComputer.SelMethod right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.SelMethod (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.SelMethod? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.SelMethod left, Azure.Analytics.PlanetaryComputer.SelMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SharedAccessSignatureSignedLink : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink>
    {
        internal SharedAccessSignatureSignedLink() { }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public System.Uri Href { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.SharedAccessSignatureSignedLink (Azure.Response response) { throw null; }
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
        public static explicit operator Azure.Analytics.PlanetaryComputer.SharedAccessSignatureToken (Azure.Response response) { throw null; }
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
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
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
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public float? Gsd { get { throw null; } set { } }
        public string Href { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Instruments { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public string Mission { get { throw null; } set { } }
        public string Platform { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacProvider> Providers { get { throw null; } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string Title { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
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
    public partial class StacAssetData
    {
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0004")]
        public StacAssetData(Azure.Analytics.PlanetaryComputer.AssetMetadata data, System.BinaryData file) { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0004")]
        public StacAssetData(Azure.Analytics.PlanetaryComputer.AssetMetadata data, System.ClientModel.FileBinaryContent file) { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0004")]
        public StacAssetData(Azure.Analytics.PlanetaryComputer.AssetMetadata data, System.IO.Stream file) { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0004")]
        public StacAssetData(Azure.Analytics.PlanetaryComputer.AssetMetadata data, string filePath) { }
        public Azure.Analytics.PlanetaryComputer.AssetMetadata Data { get { throw null; } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0004")]
        public System.ClientModel.FileBinaryContent File { get { throw null; } }
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
        public override bool Equals(object obj) { throw null; }
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
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacCollection> Collections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacLink> Links { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacCatalogCollections JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.StacCatalogCollections (Azure.Response response) { throw null; }
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
        public virtual Azure.Operation CreateCollection(Azure.WaitUntil waitUntil, Azure.Analytics.PlanetaryComputer.StacCollection body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CreateCollection(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0004")]
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacCollection> CreateCollectionAsset(string collectionId, Azure.Analytics.PlanetaryComputer.StacAssetData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateCollectionAsset(string collectionId, Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0004")]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacCollection>> CreateCollectionAssetAsync(string collectionId, Azure.Analytics.PlanetaryComputer.StacAssetData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateCollectionAssetAsync(string collectionId, Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateCollectionAsync(Azure.WaitUntil waitUntil, Azure.Analytics.PlanetaryComputer.StacCollection body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateCollectionAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation CreateItem(Azure.WaitUntil waitUntil, string collectionId, Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CreateItem(Azure.WaitUntil waitUntil, string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateItemAsync(Azure.WaitUntil waitUntil, string collectionId, Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateItemAsync(Azure.WaitUntil waitUntil, string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
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
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacCollection> DeleteCollectionAsset(string collectionId, string assetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteCollectionAssetAsync(string collectionId, string assetId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacCollection>> DeleteCollectionAssetAsync(string collectionId, string assetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacCollection> GetCollection(string collectionId, Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode? sign = default(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode?), int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCollection(string collectionId, string sign, int? durationInMinutes, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacCollection>> GetCollectionAsync(string collectionId, Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode? sign = default(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode?), int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionAsync(string collectionId, string sign, int? durationInMinutes, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetCollectionConfiguration(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.UserCollectionSettings> GetCollectionConfiguration(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionConfigurationAsync(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.UserCollectionSettings>> GetCollectionConfigurationAsync(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCollectionQueryables(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.QueryableDefinitionsResult> GetCollectionQueryables(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionQueryablesAsync(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.QueryableDefinitionsResult>> GetCollectionQueryablesAsync(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacCatalogCollections> GetCollections(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode? sign = default(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode?), int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCollections(string sign, int? durationInMinutes, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacCatalogCollections>> GetCollectionsAsync(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode? sign = default(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode?), int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionsAsync(string sign, int? durationInMinutes, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetCollectionThumbnail(Azure.Analytics.PlanetaryComputer.GetCollectionThumbnailOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionThumbnailAsync(Azure.Analytics.PlanetaryComputer.GetCollectionThumbnailOptions options, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetConformanceClasses(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacConformanceClasses> GetConformanceClasses(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConformanceClassesAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacConformanceClasses>> GetConformanceClassesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacItem> GetItem(string collectionId, string itemId, Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode? sign = default(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode?), int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetItem(string collectionId, string itemId, string sign, int? durationInMinutes, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacItem>> GetItemAsync(string collectionId, string itemId, Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode? sign = default(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode?), int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetItemAsync(string collectionId, string itemId, string sign, int? durationInMinutes, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetItemCollection(Azure.Analytics.PlanetaryComputer.GetItemCollectionOptions options, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacItemCollection> GetItemCollection(Azure.Analytics.PlanetaryComputer.GetItemCollectionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetItemCollectionAsync(Azure.Analytics.PlanetaryComputer.GetItemCollectionOptions options, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacItemCollection>> GetItemCollectionAsync(Azure.Analytics.PlanetaryComputer.GetItemCollectionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.PartitionKind> GetPartitionType(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPartitionTypeAsync(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.PartitionKind>> GetPartitionTypeAsync(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetQueryables(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.QueryableDefinitionsResult> GetQueryables(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetQueryablesAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.QueryableDefinitionsResult>> GetQueryablesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacCollection> ReplaceCollection(string collectionId, Azure.Analytics.PlanetaryComputer.StacCollection body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReplaceCollection(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0004")]
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacCollection> ReplaceCollectionAsset(string collectionId, string assetId, Azure.Analytics.PlanetaryComputer.StacAssetData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReplaceCollectionAsset(string collectionId, string assetId, Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0004")]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacCollection>> ReplaceCollectionAssetAsync(string collectionId, string assetId, Azure.Analytics.PlanetaryComputer.StacAssetData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplaceCollectionAssetAsync(string collectionId, string assetId, Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacCollection>> ReplaceCollectionAsync(string collectionId, Azure.Analytics.PlanetaryComputer.StacCollection body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplaceCollectionAsync(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation ReplaceItem(Azure.WaitUntil waitUntil, string collectionId, string itemId, Azure.Analytics.PlanetaryComputer.StacItem body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation ReplaceItem(Azure.WaitUntil waitUntil, string collectionId, string itemId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ReplaceItemAsync(Azure.WaitUntil waitUntil, string collectionId, string itemId, Azure.Analytics.PlanetaryComputer.StacItem body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ReplaceItemAsync(Azure.WaitUntil waitUntil, string collectionId, string itemId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacMosaic> ReplaceMosaic(string collectionId, string mosaicId, Azure.Analytics.PlanetaryComputer.StacMosaic body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReplaceMosaic(string collectionId, string mosaicId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacMosaic>> ReplaceMosaicAsync(string collectionId, string mosaicId, Azure.Analytics.PlanetaryComputer.StacMosaic body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplaceMosaicAsync(string collectionId, string mosaicId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response ReplacePartitionType(string collectionId, Azure.Analytics.PlanetaryComputer.PartitionKind body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReplacePartitionType(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplacePartitionTypeAsync(string collectionId, Azure.Analytics.PlanetaryComputer.PartitionKind body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.Analytics.PlanetaryComputer.StacItemCollection> Search(Azure.Analytics.PlanetaryComputer.StacSearchParameters body, Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode? sign = default(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode?), int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Search(Azure.Core.RequestContent content, string sign = null, int? durationInMinutes = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.PlanetaryComputer.StacItemCollection>> SearchAsync(Azure.Analytics.PlanetaryComputer.StacSearchParameters body, Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode? sign = default(Azure.Analytics.PlanetaryComputer.StacAssetUrlSigningMode?), int? durationInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SearchAsync(Azure.Core.RequestContent content, string sign = null, int? durationInMinutes = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation UpdateItem(Azure.WaitUntil waitUntil, string collectionId, string itemId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> UpdateItemAsync(Azure.WaitUntil waitUntil, string collectionId, string itemId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class StacCollection : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacCollection>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacCollection>
    {
        public StacCollection(string id, string description, System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacLink> links, string license, Azure.Analytics.PlanetaryComputer.StacExtensionExtent extent) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.StacAsset> Assets { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.StacExtensionExtent Extent { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.StacItemAsset> ItemAssets { get { throw null; } }
        public System.Collections.Generic.IList<string> Keywords { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public string License { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacLink> Links { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacProvider> Providers { get { throw null; } }
        public string ShortDescription { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> StacExtensions { get { throw null; } }
        public string StacVersion { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Summaries { get { throw null; } }
        public string Title { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacCollection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.StacCollection (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.PlanetaryComputer.StacCollection stacCollection) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.StacCollection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacCollection System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacCollection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacCollection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacCollection System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacCollection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacCollection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacCollection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static explicit operator Azure.Analytics.PlanetaryComputer.StacConformanceClasses (Azure.Response response) { throw null; }
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
    public partial class StacItem : Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItem>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItem>
    {
        public StacItem(Azure.Analytics.PlanetaryComputer.GeoJsonGeometry geometry, string id, System.Collections.Generic.IEnumerable<float> boundingBox, Azure.Analytics.PlanetaryComputer.StacItemProperties properties, System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.StacAsset> assets) { }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.StacAsset> Assets { get { throw null; } }
        public System.Collections.Generic.IList<float> BoundingBox { get { throw null; } }
        public string Collection { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.GeoJsonGeometry Geometry { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.StacItemProperties Properties { get { throw null; } set { } }
        public System.DateTimeOffset? RecordedOn { get { throw null; } set { } }
        protected override Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.StacItem (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.PlanetaryComputer.StacItem stacItem) { throw null; }
        protected override Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacItem System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacItem System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacItemAsset : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemAsset>
    {
        public StacItemAsset(string title, string kind) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Constellation { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public float? Gsd { get { throw null; } set { } }
        public string Href { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Instruments { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public string Mission { get { throw null; } set { } }
        public string Platform { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacProvider> Providers { get { throw null; } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string Title { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
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
        public static explicit operator Azure.Analytics.PlanetaryComputer.StacItemBounds (Azure.Response response) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.StacItemBounds PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacItemBounds System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemBounds>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemBounds>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacItemBounds System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemBounds>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemBounds>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemBounds>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StacItemCollection : Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemCollection>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemCollection>
    {
        public StacItemCollection(System.Collections.Generic.IEnumerable<Azure.Analytics.PlanetaryComputer.StacItem> features) { }
        public System.Collections.Generic.IList<float> BoundingBox { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.StacContextExtension Context { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacItem> Features { get { throw null; } }
        protected override Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.StacItemCollection (Azure.Response response) { throw null; }
        protected override Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.StacItemCollection System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemCollection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemCollection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.StacItemCollection System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemCollection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemCollection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemCollection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class StacItemOrStacItemCollection : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemOrStacItemCollection>
    {
        internal StacItemOrStacItemCollection() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacLink> Links { get { throw null; } }
        public string ShortDescription { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> StacExtensions { get { throw null; } }
        public string StacVersion { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
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
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Datetime { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndedOn { get { throw null; } set { } }
        public float? Gsd { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Instruments { get { throw null; } }
        public string Mission { get { throw null; } set { } }
        public string Platform { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacProvider> Providers { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
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
    public partial class StacItemStatisticsGeoJson : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson>
    {
        internal StacItemStatisticsGeoJson() { }
        public Azure.Analytics.PlanetaryComputer.GeoJsonGeometry Geometry { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJsonProperties Properties { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.FeatureKind Type { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.StacItemStatisticsGeoJson (Azure.Response response) { throw null; }
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
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacLink> Links { get { throw null; } }
        public string ShortDescription { get { throw null; } }
        public System.Collections.Generic.IList<string> StacExtensions { get { throw null; } }
        public string StacVersion { get { throw null; } }
        public string Title { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacLandingPage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.StacLandingPage (Azure.Response response) { throw null; }
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
        public Azure.Analytics.PlanetaryComputer.StacLinkKind? Kind { get { throw null; } set { } }
        public int? Length { get { throw null; } set { } }
        public bool? Merge { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.StacLinkMethod? Method { get { throw null; } set { } }
        public string Rel { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
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
    public readonly partial struct StacLinkKind : System.IEquatable<Azure.Analytics.PlanetaryComputer.StacLinkKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StacLinkKind(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacLinkKind ApplicationGeoJson { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkKind ApplicationJson { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkKind ApplicationXBinary { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkKind ApplicationXml { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkKind ApplicationXProtobuf { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkKind ImageJp2 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkKind ImageJpeg { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkKind ImageJpg { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkKind ImagePng { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkKind ImageTiffApplicationGeotiff { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkKind ImageWebp { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkKind TextHtml { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacLinkKind TextPlain { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.StacLinkKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.StacLinkKind left, Azure.Analytics.PlanetaryComputer.StacLinkKind right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.StacLinkKind (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.StacLinkKind? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.StacLinkKind left, Azure.Analytics.PlanetaryComputer.StacLinkKind right) { throw null; }
        public override string ToString() { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.StacLinkMethod left, Azure.Analytics.PlanetaryComputer.StacLinkMethod right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.StacLinkMethod (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.StacLinkMethod? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.StacLinkMethod left, Azure.Analytics.PlanetaryComputer.StacLinkMethod right) { throw null; }
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
        public static explicit operator Azure.Analytics.PlanetaryComputer.StacMosaic (Azure.Response response) { throw null; }
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
        public Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataKind? DataKind { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Definition { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.StacQueryable JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.StacQueryable (Azure.Response response) { throw null; }
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
    public readonly partial struct StacQueryableDefinitionDataKind : System.IEquatable<Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StacQueryableDefinitionDataKind(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataKind Boolean { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataKind Date { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataKind Number { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataKind String { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataKind Timestamp { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataKind left, Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataKind right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataKind (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataKind? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataKind left, Azure.Analytics.PlanetaryComputer.StacQueryableDefinitionDataKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StacSearchParameters : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.StacSearchParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.StacSearchParameters>
    {
        public StacSearchParameters() { }
        public System.Collections.Generic.IList<float> BoundingBox { get { throw null; } }
        public System.Collections.Generic.IList<string> Collections { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ConformanceClass { get { throw null; } }
        public string Datetime { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.SearchOptionsFields> Fields { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Filter { get { throw null; } }
        public string FilterCoordinateReferenceSystem { get { throw null; } set { } }
        public Azure.Analytics.PlanetaryComputer.FilterLanguage? FilterLang { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Ids { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.GeoJsonGeometry Intersects { get { throw null; } set { } }
        public int? Limit { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Query { get { throw null; } }
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
        public override bool Equals(object obj) { throw null; }
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
        public static Azure.Analytics.PlanetaryComputer.TerrainAlgorithm Cast { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TerrainAlgorithm Ceil { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TerrainAlgorithm Contours { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TerrainAlgorithm Floor { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TerrainAlgorithm Hillshade { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TerrainAlgorithm Max { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TerrainAlgorithm Mean { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TerrainAlgorithm Median { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TerrainAlgorithm Min { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TerrainAlgorithm NormalizedIndex { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TerrainAlgorithm Slope { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TerrainAlgorithm Std { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TerrainAlgorithm TerrainRgb { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TerrainAlgorithm Terrarium { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TerrainAlgorithm Var { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.TerrainAlgorithm other) { throw null; }
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public static explicit operator Azure.Analytics.PlanetaryComputer.TileJsonMetadata (Azure.Response response) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public static explicit operator Azure.Analytics.PlanetaryComputer.TileMatrixSet (Azure.Response response) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TileMatrixSetId : System.IEquatable<Azure.Analytics.PlanetaryComputer.TileMatrixSetId>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TileMatrixSetId(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.TileMatrixSetId CanadianNAD83LCC { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TileMatrixSetId EuropeanETRS89LAEAQuad { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TileMatrixSetId LINZAntarticaMapTilegrid { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TileMatrixSetId NZTM2000Quad { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TileMatrixSetId UPSAntarcticWGS84Quad { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TileMatrixSetId UPSArcticWGS84Quad { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TileMatrixSetId UTM31WGS84Quad { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TileMatrixSetId WebMercatorQuad { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TileMatrixSetId WGS1984Quad { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TileMatrixSetId WorldCRS84Quad { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.TileMatrixSetId WorldMercatorWGS84Quad { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.TileMatrixSetId other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.TileMatrixSetId left, Azure.Analytics.PlanetaryComputer.TileMatrixSetId right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.TileMatrixSetId (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.TileMatrixSetId? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.TileMatrixSetId left, Azure.Analytics.PlanetaryComputer.TileMatrixSetId right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TileMatrixSetLimitsEntry : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileMatrixSetLimitsEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileMatrixSetLimitsEntry>
    {
        internal TileMatrixSetLimitsEntry() { }
        public int MaxTileCol { get { throw null; } }
        public int MaxTileRow { get { throw null; } }
        public int MinTileCol { get { throw null; } }
        public int MinTileRow { get { throw null; } }
        public string TileMatrix { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TileMatrixSetLimitsEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.TileMatrixSetLimitsEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TileMatrixSetLimitsEntry System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileMatrixSetLimitsEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileMatrixSetLimitsEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TileMatrixSetLimitsEntry System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileMatrixSetLimitsEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileMatrixSetLimitsEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileMatrixSetLimitsEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TilerAssetGeoJson : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerAssetGeoJson>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerAssetGeoJson>
    {
        internal TilerAssetGeoJson() { }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.StacAsset> Assets { get { throw null; } }
        public System.Collections.Generic.IList<float> BoundingBox { get { throw null; } }
        public string Collection { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerAssetGeoJson JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerAssetGeoJson PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TilerAssetGeoJson System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerAssetGeoJson>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerAssetGeoJson>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TilerAssetGeoJson System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerAssetGeoJson>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerAssetGeoJson>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerAssetGeoJson>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TilerCoreModelsResponsesPoint : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint>
    {
        internal TilerCoreModelsResponsesPoint() { }
        public System.Collections.Generic.IList<string> BandNames { get { throw null; } }
        public System.Collections.Generic.IList<float> Coordinates { get { throw null; } }
        public System.Collections.Generic.IList<float> Values { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.TilerCoreModelsResponsesPoint (Azure.Response response) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> ColorMap { get { throw null; } }
        public string CoordinateReferenceSystem { get { throw null; } }
        public int? Count { get { throw null; } }
        public string DataType { get { throw null; } }
        public string Driver { get { throw null; } }
        public int? Height { get { throw null; } }
        public int? MaxZoom { get { throw null; } }
        public int? MinZoom { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.NoDataKind? NoDataType { get { throw null; } }
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
        public System.Collections.Generic.IList<float> BoundingBox { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.GeoJsonGeometry Geometry { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.PlanetaryComputer.TilerInfo> Properties { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.FeatureKind Type { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature (Azure.Response response) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerInfoGeoJsonFeature>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TilerInfoMapResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerInfoMapResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerInfoMapResult>
    {
        internal TilerInfoMapResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerInfoMapResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.TilerInfoMapResult (Azure.Response response) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerInfoMapResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TilerInfoMapResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerInfoMapResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerInfoMapResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TilerInfoMapResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerInfoMapResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerInfoMapResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerInfoMapResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TilerMosaicSearchRegistrationResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult>
    {
        internal TilerMosaicSearchRegistrationResult() { }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.StacLink> Links { get { throw null; } }
        public string SearchId { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.TilerMosaicSearchRegistrationResult (Azure.Response response) { throw null; }
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
        public static explicit operator Azure.Analytics.PlanetaryComputer.TilerStacItemStatistics (Azure.Response response) { throw null; }
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
        public System.DateTimeOffset LastUsedOn { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.MosaicMetadata Metadata { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Search { get { throw null; } }
        public int UseCount { get { throw null; } }
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
        public static explicit operator Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration (Azure.Response response) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TilerStacSearchRegistration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TileSetBoundingBox : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileSetBoundingBox>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSetBoundingBox>
    {
        internal TileSetBoundingBox() { }
        public string Crs { get { throw null; } }
        public System.Collections.Generic.IList<double> LowerLeft { get { throw null; } }
        public System.Collections.Generic.IList<double> UpperRight { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TileSetBoundingBox JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.TileSetBoundingBox PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TileSetBoundingBox System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileSetBoundingBox>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileSetBoundingBox>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TileSetBoundingBox System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSetBoundingBox>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSetBoundingBox>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSetBoundingBox>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TileSetEntry : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileSetEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSetEntry>
    {
        internal TileSetEntry() { }
        public string AccessConstraints { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.TileSetBoundingBox BoundingBox { get { throw null; } }
        public string Crs { get { throw null; } }
        public string DataType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.TileSetLink> Links { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TileSetEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.TileSetEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TileSetEntry System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileSetEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileSetEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TileSetEntry System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSetEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSetEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSetEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TileSetLink : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileSetLink>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSetLink>
    {
        internal TileSetLink() { }
        public string Href { get { throw null; } }
        public string Kind { get { throw null; } }
        public string Rel { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TileSetLink JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Analytics.PlanetaryComputer.TileSetLink PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TileSetLink System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileSetLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileSetLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TileSetLink System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSetLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSetLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSetLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TileSetList : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileSetList>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSetList>
    {
        internal TileSetList() { }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.TileSetEntry> Tilesets { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TileSetList JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.TileSetList (Azure.Response response) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.TileSetList PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TileSetList System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileSetList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileSetList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TileSetList System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSetList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSetList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSetList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TileSetMetadata : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileSetMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSetMetadata>
    {
        internal TileSetMetadata() { }
        public string AccessConstraints { get { throw null; } }
        public Azure.Analytics.PlanetaryComputer.TileSetBoundingBox BoundingBox { get { throw null; } }
        public string Crs { get { throw null; } }
        public string DataType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.TileSetLink> Links { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.PlanetaryComputer.TileMatrixSetLimitsEntry> TileMatrixSetLimits { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual Azure.Analytics.PlanetaryComputer.TileSetMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.TileSetMetadata (Azure.Response response) { throw null; }
        protected virtual Azure.Analytics.PlanetaryComputer.TileSetMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Analytics.PlanetaryComputer.TileSetMetadata System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileSetMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileSetMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.PlanetaryComputer.TileSetMetadata System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSetMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSetMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSetMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TileSettings : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.PlanetaryComputer.TileSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.PlanetaryComputer.TileSettings>
    {
        public TileSettings(int minZoom, int maxItemsPerTile) { }
        public Azure.Analytics.PlanetaryComputer.DefaultLocation DefaultLocation { get { throw null; } set { } }
        public int MaxItemsPerTile { get { throw null; } set { } }
        public int MinZoom { get { throw null; } set { } }
        protected virtual Azure.Analytics.PlanetaryComputer.TileSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Analytics.PlanetaryComputer.TileSettings (Azure.Response response) { throw null; }
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
        public static explicit operator Azure.Analytics.PlanetaryComputer.UserCollectionSettings (Azure.Response response) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WarpKernelResampling : System.IEquatable<Azure.Analytics.PlanetaryComputer.WarpKernelResampling>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WarpKernelResampling(string value) { throw null; }
        public static Azure.Analytics.PlanetaryComputer.WarpKernelResampling Average { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.WarpKernelResampling Bilinear { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.WarpKernelResampling Cubic { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.WarpKernelResampling CubicSpline { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.WarpKernelResampling Lanczos { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.WarpKernelResampling Max { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.WarpKernelResampling Med { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.WarpKernelResampling Min { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.WarpKernelResampling Mode { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.WarpKernelResampling Nearest { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.WarpKernelResampling Q1 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.WarpKernelResampling Q3 { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.WarpKernelResampling Rms { get { throw null; } }
        public static Azure.Analytics.PlanetaryComputer.WarpKernelResampling Sum { get { throw null; } }
        public bool Equals(Azure.Analytics.PlanetaryComputer.WarpKernelResampling other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.PlanetaryComputer.WarpKernelResampling left, Azure.Analytics.PlanetaryComputer.WarpKernelResampling right) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.WarpKernelResampling (string value) { throw null; }
        public static implicit operator Azure.Analytics.PlanetaryComputer.WarpKernelResampling? (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.PlanetaryComputer.WarpKernelResampling left, Azure.Analytics.PlanetaryComputer.WarpKernelResampling right) { throw null; }
        public override string ToString() { throw null; }
    }
}
