namespace Azure.SustainabilityServices
{
    public partial class ActivityEmissionOutput : System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.ActivityEmissionOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.ActivityEmissionOutput>
    {
        internal ActivityEmissionOutput() { }
        public System.Collections.Generic.IReadOnlyList<Azure.SustainabilityServices.GhgEmissions> Emissions { get { throw null; } }
        public System.Guid Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.ActivityEmissionOutput System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.ActivityEmissionOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.ActivityEmissionOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.ActivityEmissionOutput System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.ActivityEmissionOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.ActivityEmissionOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.ActivityEmissionOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArVersions : System.IEquatable<Azure.SustainabilityServices.ArVersions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArVersions(string value) { throw null; }
        public static Azure.SustainabilityServices.ArVersions AR4 { get { throw null; } }
        public static Azure.SustainabilityServices.ArVersions AR5 { get { throw null; } }
        public static Azure.SustainabilityServices.ArVersions AR6 { get { throw null; } }
        public static Azure.SustainabilityServices.ArVersions Custom { get { throw null; } }
        public bool Equals(Azure.SustainabilityServices.ArVersions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.SustainabilityServices.ArVersions left, Azure.SustainabilityServices.ArVersions right) { throw null; }
        public static implicit operator Azure.SustainabilityServices.ArVersions (string value) { throw null; }
        public static bool operator !=(Azure.SustainabilityServices.ArVersions left, Azure.SustainabilityServices.ArVersions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CalculationErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.CalculationErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.CalculationErrorDetails>
    {
        internal CalculationErrorDetails() { }
        public System.Guid ActivityId { get { throw null; } }
        public string ActivityName { get { throw null; } }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.CalculationErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.CalculationErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.CalculationErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.CalculationErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.CalculationErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.CalculationErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.CalculationErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CalculationModel : System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.CalculationModel>, System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.CalculationModel>
    {
        internal CalculationModel() { }
        public string CalculationFlowJson { get { throw null; } }
        public string CalculationMethod { get { throw null; } }
        public System.Guid CalculationModelId { get { throw null; } }
        public Azure.SustainabilityServices.LookupField DataDefinitionId { get { throw null; } }
        public string DocumentationReference { get { throw null; } }
        public System.Guid EmissionCalculationId { get { throw null; } }
        public Azure.SustainabilityServices.LookupField EmissionSource { get { throw null; } }
        public string EntityName { get { throw null; } }
        public string ModelJsonVersion { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.SustainabilityServices.LookupField Sustainabilitymodule { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.CalculationModel System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.CalculationModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.CalculationModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.CalculationModel System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.CalculationModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.CalculationModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.CalculationModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CalculationStatusEnum : System.IEquatable<Azure.SustainabilityServices.CalculationStatusEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CalculationStatusEnum(string value) { throw null; }
        public static Azure.SustainabilityServices.CalculationStatusEnum CompletedWithErrors { get { throw null; } }
        public static Azure.SustainabilityServices.CalculationStatusEnum Failed { get { throw null; } }
        public static Azure.SustainabilityServices.CalculationStatusEnum Succeeded { get { throw null; } }
        public bool Equals(Azure.SustainabilityServices.CalculationStatusEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.SustainabilityServices.CalculationStatusEnum left, Azure.SustainabilityServices.CalculationStatusEnum right) { throw null; }
        public static implicit operator Azure.SustainabilityServices.CalculationStatusEnum (string value) { throw null; }
        public static bool operator !=(Azure.SustainabilityServices.CalculationStatusEnum left, Azure.SustainabilityServices.CalculationStatusEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CalculationSummary : System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.CalculationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.CalculationSummary>
    {
        internal CalculationSummary() { }
        public long ExcludedActivities { get { throw null; } }
        public long FailedActivities { get { throw null; } }
        public long ProcessedActivities { get { throw null; } }
        public Azure.SustainabilityServices.CalculationStatusEnum Status { get { throw null; } }
        public long SuccessfulActivities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.CalculationSummary System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.CalculationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.CalculationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.CalculationSummary System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.CalculationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.CalculationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.CalculationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmissionActivity : System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.EmissionActivity>, System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.EmissionActivity>
    {
        public EmissionActivity(System.Guid id, System.Collections.Generic.IDictionary<string, System.BinaryData> activityData) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ActivityData { get { throw null; } }
        public System.Guid Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.EmissionActivity System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.EmissionActivity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.EmissionActivity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.EmissionActivity System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.EmissionActivity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.EmissionActivity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.EmissionActivity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmissionCalculationResult : System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.EmissionCalculationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.EmissionCalculationResult>
    {
        internal EmissionCalculationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.SustainabilityServices.ActivityEmissionOutput> ActivityEmissionOutput { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.SustainabilityServices.CalculationErrorDetails> ErrorDetails { get { throw null; } }
        public Azure.SustainabilityServices.CalculationSummary Summary { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.EmissionCalculationResult System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.EmissionCalculationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.EmissionCalculationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.EmissionCalculationResult System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.EmissionCalculationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.EmissionCalculationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.EmissionCalculationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmissionFactor : System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.EmissionFactor>, System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.EmissionFactor>
    {
        internal EmissionFactor() { }
        public double? Ch4 { get { throw null; } }
        public Azure.SustainabilityServices.LookupField Ch4Unit { get { throw null; } }
        public double? Co2 { get { throw null; } }
        public double? Co2e { get { throw null; } }
        public Azure.SustainabilityServices.LookupField Co2eUnit { get { throw null; } }
        public Azure.SustainabilityServices.LookupField Co2Unit { get { throw null; } }
        public string DocumentationReference { get { throw null; } }
        public System.Guid EmissionFactorId { get { throw null; } }
        public string EntityName { get { throw null; } }
        public Azure.SustainabilityServices.LookupField FactorLibrary { get { throw null; } }
        public double? Hfcs { get { throw null; } }
        public Azure.SustainabilityServices.LookupField HfcsUnit { get { throw null; } }
        public System.Guid Id { get { throw null; } }
        public bool? IsBiofuel { get { throw null; } }
        public double? N2o { get { throw null; } }
        public Azure.SustainabilityServices.LookupField N2oUnit { get { throw null; } }
        public string Name { get { throw null; } }
        public double? Nf3 { get { throw null; } }
        public Azure.SustainabilityServices.LookupField Nf3Unit { get { throw null; } }
        public double? OtherGhgs { get { throw null; } }
        public Azure.SustainabilityServices.LookupField OtherGhgsUnit { get { throw null; } }
        public double? Pfcs { get { throw null; } }
        public Azure.SustainabilityServices.LookupField PfcsUnit { get { throw null; } }
        public double? Sf6 { get { throw null; } }
        public Azure.SustainabilityServices.LookupField Sf6Unit { get { throw null; } }
        public string Subtype { get { throw null; } }
        public string Type { get { throw null; } }
        public Azure.SustainabilityServices.LookupField Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.EmissionFactor System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.EmissionFactor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.EmissionFactor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.EmissionFactor System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.EmissionFactor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.EmissionFactor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.EmissionFactor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityRecord : System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.EntityRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.EntityRecord>
    {
        internal EntityRecord() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Data { get { throw null; } }
        public System.Guid Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.EntityRecord System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.EntityRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.EntityRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.EntityRecord System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.EntityRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.EntityRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.EntityRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EstimationFactor : System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.EstimationFactor>, System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.EstimationFactor>
    {
        internal EstimationFactor() { }
        public string DocumentationReference { get { throw null; } }
        public string EntityName { get { throw null; } }
        public System.Guid EstimationFactorId { get { throw null; } }
        public Azure.SustainabilityServices.LookupField FactorLibrary { get { throw null; } }
        public double FactorValue { get { throw null; } }
        public Azure.SustainabilityServices.LookupField FactorValueUnit { get { throw null; } }
        public System.Guid Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Subtype { get { throw null; } }
        public string Type { get { throw null; } }
        public Azure.SustainabilityServices.LookupField Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.EstimationFactor System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.EstimationFactor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.EstimationFactor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.EstimationFactor System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.EstimationFactor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.EstimationFactor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.EstimationFactor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FactorLibrary : System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.FactorLibrary>, System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.FactorLibrary>
    {
        internal FactorLibrary() { }
        public string Attribution { get { throw null; } }
        public string DatePublished { get { throw null; } }
        public string Description { get { throw null; } }
        public string DocumentationReference { get { throw null; } }
        public System.Guid FactorLibraryId { get { throw null; } }
        public string LibraryType { get { throw null; } }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.FactorLibrary System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.FactorLibrary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.FactorLibrary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.FactorLibrary System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.FactorLibrary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.FactorLibrary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.FactorLibrary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FactorMapping : System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.FactorMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.FactorMapping>
    {
        internal FactorMapping() { }
        public Azure.SustainabilityServices.LookupField Factor { get { throw null; } }
        public Azure.SustainabilityServices.LookupField FactorLibrary { get { throw null; } }
        public System.Guid FactorMappingId { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.SustainabilityServices.LookupField ReferenceData1 { get { throw null; } }
        public Azure.SustainabilityServices.LookupField ReferenceData2 { get { throw null; } }
        public Azure.SustainabilityServices.LookupField ReferenceData3 { get { throw null; } }
        public Azure.SustainabilityServices.LookupField ReferenceData4 { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.FactorMapping System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.FactorMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.FactorMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.FactorMapping System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.FactorMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.FactorMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.FactorMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GhgEmissions : System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.GhgEmissions>, System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.GhgEmissions>
    {
        internal GhgEmissions() { }
        public string AdjustedActualQuantity { get { throw null; } }
        public string AdjustedActualQuantityUnit { get { throw null; } }
        public string CalculationLibrary { get { throw null; } }
        public float? Ch4 { get { throw null; } }
        public string Ch4Unit { get { throw null; } }
        public float? Co2 { get { throw null; } }
        public float? Co2e { get { throw null; } }
        public float? Co2emt { get { throw null; } }
        public string Co2eUnit { get { throw null; } }
        public string Co2Unit { get { throw null; } }
        public string EmissionCalculationModel { get { throw null; } }
        public string EmissionFactor { get { throw null; } }
        public float? Hfcs { get { throw null; } }
        public string HfcsUnit { get { throw null; } }
        public bool? IsBiogenic { get { throw null; } }
        public bool? IsMarketBased { get { throw null; } }
        public float? N2o { get { throw null; } }
        public string N2oUnit { get { throw null; } }
        public float? Nf3 { get { throw null; } }
        public string Nf3Unit { get { throw null; } }
        public float? OtherGhgs { get { throw null; } }
        public string OtherGhgsUnit { get { throw null; } }
        public float? Pfcs { get { throw null; } }
        public string PfcsUnit { get { throw null; } }
        public float? Sf6 { get { throw null; } }
        public string Sf6Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.GhgEmissions System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.GhgEmissions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.GhgEmissions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.GhgEmissions System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.GhgEmissions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.GhgEmissions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.GhgEmissions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LookupField : System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.LookupField>, System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.LookupField>
    {
        internal LookupField() { }
        public System.Guid Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> KeyAttributes { get { throw null; } }
        public string LogicalName { get { throw null; } }
        public string Name { get { throw null; } }
        public string RowVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.LookupField System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.LookupField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.LookupField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.LookupField System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.LookupField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.LookupField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.LookupField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReferenceDataEntities : System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.ReferenceDataEntities>, System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.ReferenceDataEntities>
    {
        internal ReferenceDataEntities() { }
        public string DisplayName { get { throw null; } }
        public string EntityName { get { throw null; } }
        public string SchemaName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.ReferenceDataEntities System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.ReferenceDataEntities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.SustainabilityServices.ReferenceDataEntities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.SustainabilityServices.ReferenceDataEntities System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.ReferenceDataEntities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.ReferenceDataEntities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.SustainabilityServices.ReferenceDataEntities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SustainabilityServiceClient
    {
        protected SustainabilityServiceClient() { }
        public SustainabilityServiceClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public SustainabilityServiceClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.SustainabilityServices.SustainabilityServiceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Calculate(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.SustainabilityServices.EmissionCalculationResult> Calculate(System.Guid calculationModelId, System.Collections.Generic.IEnumerable<Azure.SustainabilityServices.EmissionActivity> activities, System.DateTimeOffset? timeStamp = default(System.DateTimeOffset?), Azure.SustainabilityServices.ArVersions? arVersion = default(Azure.SustainabilityServices.ArVersions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CalculateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.SustainabilityServices.EmissionCalculationResult>> CalculateAsync(System.Guid calculationModelId, System.Collections.Generic.IEnumerable<Azure.SustainabilityServices.EmissionActivity> activities, System.DateTimeOffset? timeStamp = default(System.DateTimeOffset?), Azure.SustainabilityServices.ArVersions? arVersion = default(Azure.SustainabilityServices.ArVersions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAllReferenceEntityData(string entityName, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.SustainabilityServices.EntityRecord> GetAllReferenceEntityData(string entityName, int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllReferenceEntityDataAsync(string entityName, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.SustainabilityServices.EntityRecord> GetAllReferenceEntityDataAsync(string entityName, int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCalculationModel(System.Guid calculationModelId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.SustainabilityServices.CalculationModel> GetCalculationModel(System.Guid calculationModelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCalculationModelAsync(System.Guid calculationModelId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.SustainabilityServices.CalculationModel>> GetCalculationModelAsync(System.Guid calculationModelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetCalculationModels(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.SustainabilityServices.CalculationModel> GetCalculationModels(int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetCalculationModelsAsync(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.SustainabilityServices.CalculationModel> GetCalculationModelsAsync(int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEmissionFactor(System.Guid factorLibraryId, System.Guid emissionFactorId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.SustainabilityServices.EmissionFactor> GetEmissionFactor(System.Guid factorLibraryId, System.Guid emissionFactorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEmissionFactorAsync(System.Guid factorLibraryId, System.Guid emissionFactorId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.SustainabilityServices.EmissionFactor>> GetEmissionFactorAsync(System.Guid factorLibraryId, System.Guid emissionFactorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEmissionFactorsByFactorLibrary(System.Guid factorLibraryId, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.SustainabilityServices.EmissionFactor> GetEmissionFactorsByFactorLibrary(System.Guid factorLibraryId, int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEmissionFactorsByFactorLibraryAsync(System.Guid factorLibraryId, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.SustainabilityServices.EmissionFactor> GetEmissionFactorsByFactorLibraryAsync(System.Guid factorLibraryId, int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEstimationFactor(System.Guid factorLibraryId, System.Guid estimationFactorId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.SustainabilityServices.EstimationFactor> GetEstimationFactor(System.Guid factorLibraryId, System.Guid estimationFactorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEstimationFactorAsync(System.Guid factorLibraryId, System.Guid estimationFactorId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.SustainabilityServices.EstimationFactor>> GetEstimationFactorAsync(System.Guid factorLibraryId, System.Guid estimationFactorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEstimationFactorsByFactorLibrary(System.Guid factorLibraryId, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.SustainabilityServices.EstimationFactor> GetEstimationFactorsByFactorLibrary(System.Guid factorLibraryId, int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEstimationFactorsByFactorLibraryAsync(System.Guid factorLibraryId, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.SustainabilityServices.EstimationFactor> GetEstimationFactorsByFactorLibraryAsync(System.Guid factorLibraryId, int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetFactorLibraries(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.SustainabilityServices.FactorLibrary> GetFactorLibraries(int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetFactorLibrariesAsync(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.SustainabilityServices.FactorLibrary> GetFactorLibrariesAsync(int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetFactorLibrary(System.Guid factorLibraryId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.SustainabilityServices.FactorLibrary> GetFactorLibrary(System.Guid factorLibraryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFactorLibraryAsync(System.Guid factorLibraryId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.SustainabilityServices.FactorLibrary>> GetFactorLibraryAsync(System.Guid factorLibraryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetFactorMapping(System.Guid factorLibraryId, System.Guid factorMappingId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.SustainabilityServices.FactorMapping> GetFactorMapping(System.Guid factorLibraryId, System.Guid factorMappingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFactorMappingAsync(System.Guid factorLibraryId, System.Guid factorMappingId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.SustainabilityServices.FactorMapping>> GetFactorMappingAsync(System.Guid factorLibraryId, System.Guid factorMappingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetFactorMappings(System.Guid factorLibraryId, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.SustainabilityServices.FactorMapping> GetFactorMappings(System.Guid factorLibraryId, int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetFactorMappingsAsync(System.Guid factorLibraryId, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.SustainabilityServices.FactorMapping> GetFactorMappingsAsync(System.Guid factorLibraryId, int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetReferenceEntities(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.SustainabilityServices.ReferenceDataEntities> GetReferenceEntities(int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetReferenceEntitiesAsync(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.SustainabilityServices.ReferenceDataEntities> GetReferenceEntitiesAsync(int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetReferenceEntityData(string entityName, System.Guid id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.SustainabilityServices.EntityRecord> GetReferenceEntityData(string entityName, System.Guid id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetReferenceEntityDataAsync(string entityName, System.Guid id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.SustainabilityServices.EntityRecord>> GetReferenceEntityDataAsync(string entityName, System.Guid id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SustainabilityServiceClientOptions : Azure.Core.ClientOptions
    {
        public SustainabilityServiceClientOptions(Azure.SustainabilityServices.SustainabilityServiceClientOptions.ServiceVersion version = Azure.SustainabilityServices.SustainabilityServiceClientOptions.ServiceVersion.V2025_01_01_Preview) { }
        public enum ServiceVersion
        {
            V2025_01_01_Preview = 1,
        }
    }
    public static partial class SustainabilityServicesModelFactory
    {
        public static Azure.SustainabilityServices.ActivityEmissionOutput ActivityEmissionOutput(System.Guid id = default(System.Guid), System.Collections.Generic.IEnumerable<Azure.SustainabilityServices.GhgEmissions> emissions = null) { throw null; }
        public static Azure.SustainabilityServices.CalculationErrorDetails CalculationErrorDetails(System.Guid activityId = default(System.Guid), string activityName = null, string message = null, string code = null) { throw null; }
        public static Azure.SustainabilityServices.CalculationModel CalculationModel(string entityName = null, System.Guid calculationModelId = default(System.Guid), string calculationFlowJson = null, string calculationMethod = null, Azure.SustainabilityServices.LookupField dataDefinitionId = null, string documentationReference = null, System.Guid emissionCalculationId = default(System.Guid), Azure.SustainabilityServices.LookupField emissionSource = null, string modelJsonVersion = null, string name = null, Azure.SustainabilityServices.LookupField sustainabilitymodule = null, string type = null) { throw null; }
        public static Azure.SustainabilityServices.CalculationSummary CalculationSummary(Azure.SustainabilityServices.CalculationStatusEnum status = default(Azure.SustainabilityServices.CalculationStatusEnum), long successfulActivities = (long)0, long failedActivities = (long)0, long excludedActivities = (long)0, long processedActivities = (long)0) { throw null; }
        public static Azure.SustainabilityServices.EmissionCalculationResult EmissionCalculationResult(Azure.SustainabilityServices.CalculationSummary summary = null, System.Collections.Generic.IEnumerable<Azure.SustainabilityServices.CalculationErrorDetails> errorDetails = null, System.Collections.Generic.IEnumerable<Azure.SustainabilityServices.ActivityEmissionOutput> activityEmissionOutput = null) { throw null; }
        public static Azure.SustainabilityServices.EmissionFactor EmissionFactor(string entityName = null, Azure.SustainabilityServices.LookupField factorLibrary = null, double? ch4 = default(double?), Azure.SustainabilityServices.LookupField ch4Unit = null, double? co2 = default(double?), Azure.SustainabilityServices.LookupField co2Unit = null, double? co2e = default(double?), Azure.SustainabilityServices.LookupField co2eUnit = null, string documentationReference = null, System.Guid emissionFactorId = default(System.Guid), System.Guid id = default(System.Guid), double? hfcs = default(double?), Azure.SustainabilityServices.LookupField hfcsUnit = null, bool? isBiofuel = default(bool?), string name = null, double? nf3 = default(double?), Azure.SustainabilityServices.LookupField nf3Unit = null, double? n2o = default(double?), Azure.SustainabilityServices.LookupField n2oUnit = null, double? otherGhgs = default(double?), Azure.SustainabilityServices.LookupField otherGhgsUnit = null, double? pfcs = default(double?), Azure.SustainabilityServices.LookupField pfcsUnit = null, double? sf6 = default(double?), Azure.SustainabilityServices.LookupField sf6Unit = null, string subtype = null, string type = null, Azure.SustainabilityServices.LookupField unit = null) { throw null; }
        public static Azure.SustainabilityServices.EntityRecord EntityRecord(System.Guid id = default(System.Guid), System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> data = null) { throw null; }
        public static Azure.SustainabilityServices.EstimationFactor EstimationFactor(string entityName = null, System.Guid id = default(System.Guid), string documentationReference = null, System.Guid estimationFactorId = default(System.Guid), Azure.SustainabilityServices.LookupField factorLibrary = null, double factorValue = 0, Azure.SustainabilityServices.LookupField factorValueUnit = null, string name = null, string subtype = null, string type = null, Azure.SustainabilityServices.LookupField unit = null) { throw null; }
        public static Azure.SustainabilityServices.FactorLibrary FactorLibrary(System.Guid factorLibraryId = default(System.Guid), string name = null, string libraryType = null, string attribution = null, string version = null, string description = null, string datePublished = null, string documentationReference = null) { throw null; }
        public static Azure.SustainabilityServices.FactorMapping FactorMapping(System.Guid factorMappingId = default(System.Guid), Azure.SustainabilityServices.LookupField factorLibrary = null, string name = null, Azure.SustainabilityServices.LookupField factor = null, Azure.SustainabilityServices.LookupField referenceData1 = null, Azure.SustainabilityServices.LookupField referenceData2 = null, Azure.SustainabilityServices.LookupField referenceData3 = null, Azure.SustainabilityServices.LookupField referenceData4 = null) { throw null; }
        public static Azure.SustainabilityServices.GhgEmissions GhgEmissions(float? ch4 = default(float?), string ch4Unit = null, float? co2 = default(float?), string co2Unit = null, float? co2e = default(float?), string co2eUnit = null, float? co2emt = default(float?), float? hfcs = default(float?), string hfcsUnit = null, float? n2o = default(float?), string n2oUnit = null, float? nf3 = default(float?), string nf3Unit = null, float? pfcs = default(float?), string pfcsUnit = null, float? otherGhgs = default(float?), string otherGhgsUnit = null, float? sf6 = default(float?), string sf6Unit = null, bool? isMarketBased = default(bool?), bool? isBiogenic = default(bool?), string emissionCalculationModel = null, string calculationLibrary = null, string emissionFactor = null, string adjustedActualQuantity = null, string adjustedActualQuantityUnit = null) { throw null; }
        public static Azure.SustainabilityServices.LookupField LookupField(System.Guid id = default(System.Guid), string logicalName = null, string name = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> keyAttributes = null, string rowVersion = null) { throw null; }
        public static Azure.SustainabilityServices.ReferenceDataEntities ReferenceDataEntities(string entityName = null, string displayName = null, string schemaName = null) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class SustainabilityServicesClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.SustainabilityServices.SustainabilityServiceClient, Azure.SustainabilityServices.SustainabilityServiceClientOptions> AddSustainabilityServiceClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.SustainabilityServices.SustainabilityServiceClient, Azure.SustainabilityServices.SustainabilityServiceClientOptions> AddSustainabilityServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
