namespace Azure.Developer.LoadTesting
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AggregationType : System.IEquatable<Azure.Developer.LoadTesting.AggregationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AggregationType(string value) { throw null; }
        public static Azure.Developer.LoadTesting.AggregationType Average { get { throw null; } }
        public static Azure.Developer.LoadTesting.AggregationType Count { get { throw null; } }
        public static Azure.Developer.LoadTesting.AggregationType None { get { throw null; } }
        public static Azure.Developer.LoadTesting.AggregationType Percentile75 { get { throw null; } }
        public static Azure.Developer.LoadTesting.AggregationType Percentile90 { get { throw null; } }
        public static Azure.Developer.LoadTesting.AggregationType Percentile95 { get { throw null; } }
        public static Azure.Developer.LoadTesting.AggregationType Percentile96 { get { throw null; } }
        public static Azure.Developer.LoadTesting.AggregationType Percentile97 { get { throw null; } }
        public static Azure.Developer.LoadTesting.AggregationType Percentile98 { get { throw null; } }
        public static Azure.Developer.LoadTesting.AggregationType Percentile99 { get { throw null; } }
        public static Azure.Developer.LoadTesting.AggregationType Percentile999 { get { throw null; } }
        public static Azure.Developer.LoadTesting.AggregationType Percentile9999 { get { throw null; } }
        public static Azure.Developer.LoadTesting.AggregationType Total { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.AggregationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.AggregationType left, Azure.Developer.LoadTesting.AggregationType right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.AggregationType (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.AggregationType left, Azure.Developer.LoadTesting.AggregationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArtifactsContainerInfo : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.ArtifactsContainerInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.ArtifactsContainerInfo>
    {
        internal ArtifactsContainerInfo() { }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.ArtifactsContainerInfo System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.ArtifactsContainerInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.ArtifactsContainerInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.ArtifactsContainerInfo System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.ArtifactsContainerInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.ArtifactsContainerInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.ArtifactsContainerInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutoStopCriteria : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.AutoStopCriteria>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.AutoStopCriteria>
    {
        public AutoStopCriteria() { }
        public bool? AutoStopDisabled { get { throw null; } set { } }
        public float? ErrorRate { get { throw null; } set { } }
        public System.TimeSpan? ErrorRateTimeWindow { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.AutoStopCriteria System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.AutoStopCriteria>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.AutoStopCriteria>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.AutoStopCriteria System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.AutoStopCriteria>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.AutoStopCriteria>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.AutoStopCriteria>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureDeveloperLoadTestingContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureDeveloperLoadTestingContext() { }
        public static Azure.Developer.LoadTesting.AzureDeveloperLoadTestingContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateType : System.IEquatable<Azure.Developer.LoadTesting.CertificateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateType(string value) { throw null; }
        public static Azure.Developer.LoadTesting.CertificateType KeyVaultCertificateUri { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.CertificateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.CertificateType left, Azure.Developer.LoadTesting.CertificateType right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.CertificateType (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.CertificateType left, Azure.Developer.LoadTesting.CertificateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.Developer.LoadTesting.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.Developer.LoadTesting.CreatedByType ScheduledTrigger { get { throw null; } }
        public static Azure.Developer.LoadTesting.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.CreatedByType left, Azure.Developer.LoadTesting.CreatedByType right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.CreatedByType left, Azure.Developer.LoadTesting.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DimensionFilter : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.DimensionFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.DimensionFilter>
    {
        public DimensionFilter() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.DimensionFilter System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.DimensionFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.DimensionFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.DimensionFilter System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.DimensionFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.DimensionFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.DimensionFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DimensionValue : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.DimensionValue>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.DimensionValue>
    {
        internal DimensionValue() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.DimensionValue System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.DimensionValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.DimensionValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.DimensionValue System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.DimensionValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.DimensionValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.DimensionValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.ErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.ErrorDetails>
    {
        internal ErrorDetails() { }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.ErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.ErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.ErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.ErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.ErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.ErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.ErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileUploadResultOperation : Azure.Operation<System.BinaryData>
    {
        protected FileUploadResultOperation() { }
        public FileUploadResultOperation(string testId, string fileName, Azure.Developer.LoadTesting.LoadTestAdministrationClient client, Azure.Response initialResponse = null) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override System.BinaryData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileValidationStatus : System.IEquatable<Azure.Developer.LoadTesting.FileValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileValidationStatus(string value) { throw null; }
        public static Azure.Developer.LoadTesting.FileValidationStatus NotValidated { get { throw null; } }
        public static Azure.Developer.LoadTesting.FileValidationStatus ValidationFailure { get { throw null; } }
        public static Azure.Developer.LoadTesting.FileValidationStatus ValidationInitiated { get { throw null; } }
        public static Azure.Developer.LoadTesting.FileValidationStatus ValidationNotRequired { get { throw null; } }
        public static Azure.Developer.LoadTesting.FileValidationStatus ValidationSuccess { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.FileValidationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.FileValidationStatus left, Azure.Developer.LoadTesting.FileValidationStatus right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.FileValidationStatus (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.FileValidationStatus left, Azure.Developer.LoadTesting.FileValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FunctionFlexConsumptionResourceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.FunctionFlexConsumptionResourceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.FunctionFlexConsumptionResourceConfiguration>
    {
        public FunctionFlexConsumptionResourceConfiguration(long instanceMemoryMB) { }
        public long? HttpConcurrency { get { throw null; } set { } }
        public long InstanceMemoryMB { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.FunctionFlexConsumptionResourceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.FunctionFlexConsumptionResourceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.FunctionFlexConsumptionResourceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.FunctionFlexConsumptionResourceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.FunctionFlexConsumptionResourceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.FunctionFlexConsumptionResourceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.FunctionFlexConsumptionResourceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionFlexConsumptionTargetResourceConfigurations : Azure.Developer.LoadTesting.TargetResourceConfigurations, System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.FunctionFlexConsumptionTargetResourceConfigurations>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.FunctionFlexConsumptionTargetResourceConfigurations>
    {
        public FunctionFlexConsumptionTargetResourceConfigurations() { }
        public System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.FunctionFlexConsumptionResourceConfiguration> Configurations { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.FunctionFlexConsumptionTargetResourceConfigurations System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.FunctionFlexConsumptionTargetResourceConfigurations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.FunctionFlexConsumptionTargetResourceConfigurations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.FunctionFlexConsumptionTargetResourceConfigurations System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.FunctionFlexConsumptionTargetResourceConfigurations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.FunctionFlexConsumptionTargetResourceConfigurations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.FunctionFlexConsumptionTargetResourceConfigurations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTest : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.LoadTest>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.LoadTest>
    {
        public LoadTest() { }
        public Azure.Developer.LoadTesting.AutoStopCriteria AutoStopCriteria { get { throw null; } set { } }
        public string BaselineTestRunId { get { throw null; } set { } }
        public Azure.Developer.LoadTesting.TestCertificate Certificate { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EngineBuiltInIdentityIds { get { throw null; } }
        public Azure.Developer.LoadTesting.LoadTestingManagedIdentityType? EngineBuiltInIdentityType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } }
        public Azure.Developer.LoadTesting.TestInputArtifacts InputArtifacts { get { throw null; } }
        public string KeyvaultReferenceIdentityId { get { throw null; } set { } }
        public string KeyvaultReferenceIdentityType { get { throw null; } set { } }
        public Azure.Developer.LoadTesting.LoadTestKind? Kind { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedDateTime { get { throw null; } }
        public Azure.Developer.LoadTesting.LoadTestConfiguration LoadTestConfiguration { get { throw null; } set { } }
        public string MetricsReferenceIdentityId { get { throw null; } set { } }
        public Azure.Developer.LoadTesting.LoadTestingManagedIdentityType? MetricsReferenceIdentityType { get { throw null; } set { } }
        public Azure.Developer.LoadTesting.PassFailCriteria PassFailCriteria { get { throw null; } set { } }
        public bool? PublicIpDisabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.TestSecret> Secrets { get { throw null; } }
        public string SubnetId { get { throw null; } set { } }
        public string TestId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.LoadTest System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.LoadTest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.LoadTest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.LoadTest System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.LoadTest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.LoadTest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.LoadTest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestAdministrationClient
    {
        protected LoadTestAdministrationClient() { }
        public LoadTestAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public LoadTestAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Developer.LoadTesting.LoadTestingClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateAppComponents(string testId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAppComponentsAsync(string testId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateServerMetricsConfig(string testId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateServerMetricsConfigAsync(string testId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateTest(string testId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateTestAsync(string testId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateTestProfile(string testProfileId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateTestProfileAsync(string testProfileId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTest(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTestAsync(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTestFile(string testId, string fileName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTestFileAsync(string testId, string fileName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTestProfile(string testProfileId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTestProfileAsync(string testProfileId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAppComponents(string testId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.LoadTesting.TestAppComponents> GetAppComponents(string testId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAppComponentsAsync(string testId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.LoadTesting.TestAppComponents>> GetAppComponentsAsync(string testId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetServerMetricsConfig(string testId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.LoadTesting.TestServerMetricsConfiguration> GetServerMetricsConfig(string testId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetServerMetricsConfigAsync(string testId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.LoadTesting.TestServerMetricsConfiguration>> GetServerMetricsConfigAsync(string testId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTest(string testId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.LoadTesting.LoadTest> GetTest(string testId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTestAsync(string testId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.LoadTesting.LoadTest>> GetTestAsync(string testId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTestFile(string testId, string fileName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.LoadTesting.TestFileInfo> GetTestFile(string testId, string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTestFileAsync(string testId, string fileName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.LoadTesting.TestFileInfo>> GetTestFileAsync(string testId, string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTestFiles(string testId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.LoadTesting.TestFileInfo> GetTestFiles(string testId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTestFilesAsync(string testId, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.LoadTesting.TestFileInfo> GetTestFilesAsync(string testId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTestProfile(string testProfileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.LoadTesting.TestProfile> GetTestProfile(string testProfileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTestProfileAsync(string testProfileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.LoadTesting.TestProfile>> GetTestProfileAsync(string testProfileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTestProfiles(System.DateTimeOffset? lastModifiedStartTime, System.DateTimeOffset? lastModifiedEndTime, System.Collections.Generic.IEnumerable<string> testProfileIds, System.Collections.Generic.IEnumerable<string> testIds, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.LoadTesting.TestProfile> GetTestProfiles(System.DateTimeOffset? lastModifiedStartTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedEndTime = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> testProfileIds = null, System.Collections.Generic.IEnumerable<string> testIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTestProfilesAsync(System.DateTimeOffset? lastModifiedStartTime, System.DateTimeOffset? lastModifiedEndTime, System.Collections.Generic.IEnumerable<string> testProfileIds, System.Collections.Generic.IEnumerable<string> testIds, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.LoadTesting.TestProfile> GetTestProfilesAsync(System.DateTimeOffset? lastModifiedStartTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedEndTime = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> testProfileIds = null, System.Collections.Generic.IEnumerable<string> testIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTests(string orderby, string search, System.DateTimeOffset? lastModifiedStartTime, System.DateTimeOffset? lastModifiedEndTime, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.LoadTesting.LoadTest> GetTests(string orderby = null, string search = null, System.DateTimeOffset? lastModifiedStartTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedEndTime = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTestsAsync(string orderby, string search, System.DateTimeOffset? lastModifiedStartTime, System.DateTimeOffset? lastModifiedEndTime, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.LoadTesting.LoadTest> GetTestsAsync(string orderby = null, string search = null, System.DateTimeOffset? lastModifiedStartTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedEndTime = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Developer.LoadTesting.FileUploadResultOperation UploadTestFile(Azure.WaitUntil waitUntil, string testId, string fileName, Azure.Core.RequestContent content, System.TimeSpan? timeSpan = default(System.TimeSpan?), string fileType = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Developer.LoadTesting.FileUploadResultOperation> UploadTestFileAsync(Azure.WaitUntil waitUntil, string testId, string fileName, Azure.Core.RequestContent content, System.TimeSpan? timeSpan = default(System.TimeSpan?), string fileType = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class LoadTestConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.LoadTestConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.LoadTestConfiguration>
    {
        public LoadTestConfiguration() { }
        public int? EngineInstances { get { throw null; } set { } }
        public Azure.Developer.LoadTesting.OptionalLoadTestConfiguration OptionalLoadTestConfiguration { get { throw null; } set { } }
        public bool? QuickStartTest { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Developer.LoadTesting.RegionalConfiguration> RegionalLoadTestConfiguration { get { throw null; } }
        public bool? SplitAllCsvs { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.LoadTestConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.LoadTestConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.LoadTestConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.LoadTestConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.LoadTestConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.LoadTestConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.LoadTestConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestingAppComponent : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.LoadTestingAppComponent>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.LoadTestingAppComponent>
    {
        public LoadTestingAppComponent(string resourceName, string resourceType) { }
        public string DisplayName { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string ResourceName { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.LoadTestingAppComponent System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.LoadTestingAppComponent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.LoadTestingAppComponent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.LoadTestingAppComponent System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.LoadTestingAppComponent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.LoadTestingAppComponent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.LoadTestingAppComponent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestingClientOptions : Azure.Core.ClientOptions
    {
        public LoadTestingClientOptions(Azure.Developer.LoadTesting.LoadTestingClientOptions.ServiceVersion version = Azure.Developer.LoadTesting.LoadTestingClientOptions.ServiceVersion.V2024_12_01_Preview) { }
        public enum ServiceVersion
        {
            V2022_11_01 = 1,
            V2023_04_01_Preview = 2,
            V2024_03_01_Preview = 3,
            V2024_05_01_Preview = 4,
            V2024_07_01_Preview = 5,
            V2024_12_01_Preview = 6,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoadTestingFileType : System.IEquatable<Azure.Developer.LoadTesting.LoadTestingFileType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoadTestingFileType(string value) { throw null; }
        public static Azure.Developer.LoadTesting.LoadTestingFileType AdditionalArtifacts { get { throw null; } }
        public static Azure.Developer.LoadTesting.LoadTestingFileType JmxFile { get { throw null; } }
        public static Azure.Developer.LoadTesting.LoadTestingFileType TestScript { get { throw null; } }
        public static Azure.Developer.LoadTesting.LoadTestingFileType UrlTestConfig { get { throw null; } }
        public static Azure.Developer.LoadTesting.LoadTestingFileType UserProperties { get { throw null; } }
        public static Azure.Developer.LoadTesting.LoadTestingFileType ZippedArtifacts { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.LoadTestingFileType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.LoadTestingFileType left, Azure.Developer.LoadTesting.LoadTestingFileType right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.LoadTestingFileType (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.LoadTestingFileType left, Azure.Developer.LoadTesting.LoadTestingFileType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoadTestingManagedIdentityType : System.IEquatable<Azure.Developer.LoadTesting.LoadTestingManagedIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoadTestingManagedIdentityType(string value) { throw null; }
        public static Azure.Developer.LoadTesting.LoadTestingManagedIdentityType SystemAssigned { get { throw null; } }
        public static Azure.Developer.LoadTesting.LoadTestingManagedIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.LoadTestingManagedIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.LoadTestingManagedIdentityType left, Azure.Developer.LoadTesting.LoadTestingManagedIdentityType right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.LoadTestingManagedIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.LoadTestingManagedIdentityType left, Azure.Developer.LoadTesting.LoadTestingManagedIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class LoadTestingModelFactory
    {
        public static Azure.Developer.LoadTesting.ArtifactsContainerInfo ArtifactsContainerInfo(System.Uri uri = null, System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Developer.LoadTesting.DimensionValue DimensionValue(string name = null, string value = null) { throw null; }
        public static Azure.Developer.LoadTesting.ErrorDetails ErrorDetails(string message = null) { throw null; }
        public static Azure.Developer.LoadTesting.LoadTest LoadTest(Azure.Developer.LoadTesting.PassFailCriteria passFailCriteria = null, Azure.Developer.LoadTesting.AutoStopCriteria autoStopCriteria = null, System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.TestSecret> secrets = null, Azure.Developer.LoadTesting.TestCertificate certificate = null, System.Collections.Generic.IDictionary<string, string> environmentVariables = null, Azure.Developer.LoadTesting.LoadTestConfiguration loadTestConfiguration = null, string baselineTestRunId = null, Azure.Developer.LoadTesting.TestInputArtifacts inputArtifacts = null, string testId = null, string description = null, string displayName = null, string subnetId = null, Azure.Developer.LoadTesting.LoadTestKind? kind = default(Azure.Developer.LoadTesting.LoadTestKind?), bool? publicIpDisabled = default(bool?), string keyvaultReferenceIdentityType = null, string keyvaultReferenceIdentityId = null, Azure.Developer.LoadTesting.LoadTestingManagedIdentityType? metricsReferenceIdentityType = default(Azure.Developer.LoadTesting.LoadTestingManagedIdentityType?), string metricsReferenceIdentityId = null, Azure.Developer.LoadTesting.LoadTestingManagedIdentityType? engineBuiltInIdentityType = default(Azure.Developer.LoadTesting.LoadTestingManagedIdentityType?), System.Collections.Generic.IEnumerable<string> engineBuiltInIdentityIds = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), string createdBy = null, System.DateTimeOffset? lastModifiedDateTime = default(System.DateTimeOffset?), string lastModifiedBy = null) { throw null; }
        public static Azure.Developer.LoadTesting.LoadTestingAppComponent LoadTestingAppComponent(Azure.Core.ResourceIdentifier resourceId = null, string resourceName = null, string resourceType = null, string displayName = null, string resourceGroup = null, string subscriptionId = null, string kind = null) { throw null; }
        public static Azure.Developer.LoadTesting.LoadTestRun LoadTestRun(string testRunId = null, Azure.Developer.LoadTesting.PassFailCriteria passFailCriteria = null, Azure.Developer.LoadTesting.AutoStopCriteria autoStopCriteria = null, System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.TestSecret> secrets = null, Azure.Developer.LoadTesting.TestCertificate certificate = null, System.Collections.Generic.IDictionary<string, string> environmentVariables = null, System.Collections.Generic.IEnumerable<Azure.Developer.LoadTesting.ErrorDetails> errorDetails = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.Developer.LoadTesting.TestRunStatistics> testRunStatistics = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.Developer.LoadTesting.TestRunStatistics> regionalStatistics = null, Azure.Developer.LoadTesting.LoadTestConfiguration loadTestConfiguration = null, Azure.Developer.LoadTesting.TestRunArtifacts testArtifacts = null, Azure.Developer.LoadTesting.PassFailTestResult? testResult = default(Azure.Developer.LoadTesting.PassFailTestResult?), int? virtualUsers = default(int?), string displayName = null, string testId = null, string description = null, Azure.Developer.LoadTesting.TestRunStatus? status = default(Azure.Developer.LoadTesting.TestRunStatus?), System.DateTimeOffset? startDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? endDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? executedDateTime = default(System.DateTimeOffset?), System.Uri portalUri = null, long? duration = default(long?), double? virtualUserHours = default(double?), string subnetId = null, Azure.Developer.LoadTesting.LoadTestKind? kind = default(Azure.Developer.LoadTesting.LoadTestKind?), Azure.Developer.LoadTesting.RequestDataLevel? requestDataLevel = default(Azure.Developer.LoadTesting.RequestDataLevel?), bool? debugLogsEnabled = default(bool?), bool? publicIpDisabled = default(bool?), Azure.Developer.LoadTesting.CreatedByType? createdByType = default(Azure.Developer.LoadTesting.CreatedByType?), System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), string createdBy = null, System.DateTimeOffset? lastModifiedDateTime = default(System.DateTimeOffset?), string lastModifiedBy = null) { throw null; }
        public static Azure.Developer.LoadTesting.MetricAvailability MetricAvailability(Azure.Developer.LoadTesting.TimeGrain? timeGrain = default(Azure.Developer.LoadTesting.TimeGrain?)) { throw null; }
        public static Azure.Developer.LoadTesting.MetricDefinition MetricDefinition(System.Collections.Generic.IEnumerable<Azure.Developer.LoadTesting.NameAndDescription> dimensions = null, string description = null, string name = null, string @namespace = null, Azure.Developer.LoadTesting.AggregationType? primaryAggregationType = default(Azure.Developer.LoadTesting.AggregationType?), System.Collections.Generic.IEnumerable<string> supportedAggregationTypes = null, Azure.Developer.LoadTesting.MetricUnit? unit = default(Azure.Developer.LoadTesting.MetricUnit?), System.Collections.Generic.IEnumerable<Azure.Developer.LoadTesting.MetricAvailability> metricAvailabilities = null) { throw null; }
        public static Azure.Developer.LoadTesting.MetricDefinitions MetricDefinitions(System.Collections.Generic.IEnumerable<Azure.Developer.LoadTesting.MetricDefinition> value = null) { throw null; }
        public static Azure.Developer.LoadTesting.MetricNamespace MetricNamespace(string description = null, string name = null) { throw null; }
        public static Azure.Developer.LoadTesting.MetricNamespaces MetricNamespaces(System.Collections.Generic.IEnumerable<Azure.Developer.LoadTesting.MetricNamespace> value = null) { throw null; }
        public static Azure.Developer.LoadTesting.MetricValue MetricValue(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), double? value = default(double?)) { throw null; }
        public static Azure.Developer.LoadTesting.NameAndDescription NameAndDescription(string description = null, string name = null) { throw null; }
        public static Azure.Developer.LoadTesting.PassFailMetric PassFailMetric(Azure.Developer.LoadTesting.PfMetrics? clientMetric = default(Azure.Developer.LoadTesting.PfMetrics?), Azure.Developer.LoadTesting.PassFailAggregationFunction? aggregate = default(Azure.Developer.LoadTesting.PassFailAggregationFunction?), string condition = null, string requestName = null, double? value = default(double?), Azure.Developer.LoadTesting.PassFailAction? action = default(Azure.Developer.LoadTesting.PassFailAction?), double? actualValue = default(double?), Azure.Developer.LoadTesting.PassFailResult? result = default(Azure.Developer.LoadTesting.PassFailResult?)) { throw null; }
        public static Azure.Developer.LoadTesting.PassFailServerMetric PassFailServerMetric(Azure.Core.ResourceIdentifier resourceId = null, string metricNamespace = null, string metricName = null, string aggregation = null, string condition = null, double value = 0, Azure.Developer.LoadTesting.PassFailAction? action = default(Azure.Developer.LoadTesting.PassFailAction?), double? actualValue = default(double?), Azure.Developer.LoadTesting.PassFailResult? result = default(Azure.Developer.LoadTesting.PassFailResult?)) { throw null; }
        public static Azure.Developer.LoadTesting.ResourceMetric ResourceMetric(string id = null, Azure.Core.ResourceIdentifier resourceId = null, string metricNamespace = null, string displayDescription = null, string name = null, string aggregation = null, string unit = null, string resourceType = null) { throw null; }
        public static Azure.Developer.LoadTesting.TestAppComponents TestAppComponents(System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.LoadTestingAppComponent> components = null, string testId = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), string createdBy = null, System.DateTimeOffset? lastModifiedDateTime = default(System.DateTimeOffset?), string lastModifiedBy = null) { throw null; }
        public static Azure.Developer.LoadTesting.TestFileInfo TestFileInfo(string fileName = null, System.Uri uri = null, Azure.Developer.LoadTesting.LoadTestingFileType? fileType = default(Azure.Developer.LoadTesting.LoadTestingFileType?), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.Developer.LoadTesting.FileValidationStatus? validationStatus = default(Azure.Developer.LoadTesting.FileValidationStatus?), string validationFailureDetails = null) { throw null; }
        public static Azure.Developer.LoadTesting.TestInputArtifacts TestInputArtifacts(Azure.Developer.LoadTesting.TestFileInfo configFileInfo = null, Azure.Developer.LoadTesting.TestFileInfo testScriptFileInfo = null, Azure.Developer.LoadTesting.TestFileInfo userPropertyFileInfo = null, Azure.Developer.LoadTesting.TestFileInfo inputArtifactsZipFileInfo = null, Azure.Developer.LoadTesting.TestFileInfo urlTestConfigFileInfo = null, System.Collections.Generic.IEnumerable<Azure.Developer.LoadTesting.TestFileInfo> additionalFileInfo = null) { throw null; }
        public static Azure.Developer.LoadTesting.TestProfile TestProfile(string testProfileId = null, string displayName = null, string description = null, string testId = null, Azure.Core.ResourceIdentifier targetResourceId = null, Azure.Developer.LoadTesting.TargetResourceConfigurations targetResourceConfigurations = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), string createdBy = null, System.DateTimeOffset? lastModifiedDateTime = default(System.DateTimeOffset?), string lastModifiedBy = null) { throw null; }
        public static Azure.Developer.LoadTesting.TestProfileRun TestProfileRun(string testProfileRunId = null, string displayName = null, string description = null, string testProfileId = null, Azure.Core.ResourceIdentifier targetResourceId = null, Azure.Developer.LoadTesting.TargetResourceConfigurations targetResourceConfigurations = null, Azure.Developer.LoadTesting.TestProfileRunStatus? status = default(Azure.Developer.LoadTesting.TestProfileRunStatus?), System.Collections.Generic.IEnumerable<Azure.Developer.LoadTesting.ErrorDetails> errorDetails = null, System.DateTimeOffset? startDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? endDateTime = default(System.DateTimeOffset?), long? durationInSeconds = default(long?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.Developer.LoadTesting.TestRunDetail> testRunDetails = null, System.Collections.Generic.IEnumerable<Azure.Developer.LoadTesting.TestProfileRunRecommendation> recommendations = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), string createdBy = null, System.DateTimeOffset? lastModifiedDateTime = default(System.DateTimeOffset?), string lastModifiedBy = null) { throw null; }
        public static Azure.Developer.LoadTesting.TestProfileRunRecommendation TestProfileRunRecommendation(Azure.Developer.LoadTesting.RecommendationCategory category = default(Azure.Developer.LoadTesting.RecommendationCategory), System.Collections.Generic.IEnumerable<string> configurations = null) { throw null; }
        public static Azure.Developer.LoadTesting.TestRunAppComponents TestRunAppComponents(System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.LoadTestingAppComponent> components = null, string testRunId = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), string createdBy = null, System.DateTimeOffset? lastModifiedDateTime = default(System.DateTimeOffset?), string lastModifiedBy = null) { throw null; }
        public static Azure.Developer.LoadTesting.TestRunArtifacts TestRunArtifacts(Azure.Developer.LoadTesting.TestRunInputArtifacts inputArtifacts = null, Azure.Developer.LoadTesting.TestRunOutputArtifacts outputArtifacts = null) { throw null; }
        public static Azure.Developer.LoadTesting.TestRunDetail TestRunDetail(Azure.Developer.LoadTesting.TestRunStatus status = default(Azure.Developer.LoadTesting.TestRunStatus), string configurationId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> properties = null) { throw null; }
        public static Azure.Developer.LoadTesting.TestRunFileInfo TestRunFileInfo(string fileName = null, System.Uri uri = null, Azure.Developer.LoadTesting.LoadTestingFileType? fileType = default(Azure.Developer.LoadTesting.LoadTestingFileType?), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.Developer.LoadTesting.FileValidationStatus? validationStatus = default(Azure.Developer.LoadTesting.FileValidationStatus?), string validationFailureDetails = null) { throw null; }
        public static Azure.Developer.LoadTesting.TestRunInputArtifacts TestRunInputArtifacts(Azure.Developer.LoadTesting.TestRunFileInfo configFileInfo = null, Azure.Developer.LoadTesting.TestRunFileInfo testScriptFileInfo = null, Azure.Developer.LoadTesting.TestRunFileInfo userPropertyFileInfo = null, Azure.Developer.LoadTesting.TestRunFileInfo inputArtifactsZipFileInfo = null, Azure.Developer.LoadTesting.TestRunFileInfo urlTestConfigFileInfo = null, System.Collections.Generic.IEnumerable<Azure.Developer.LoadTesting.TestRunFileInfo> additionalFileInfo = null) { throw null; }
        public static Azure.Developer.LoadTesting.TestRunOutputArtifacts TestRunOutputArtifacts(Azure.Developer.LoadTesting.TestRunFileInfo resultFileInfo = null, Azure.Developer.LoadTesting.TestRunFileInfo logsFileInfo = null, Azure.Developer.LoadTesting.ArtifactsContainerInfo artifactsContainerInfo = null, Azure.Developer.LoadTesting.TestRunFileInfo reportFileInfo = null) { throw null; }
        public static Azure.Developer.LoadTesting.TestRunServerMetricsConfiguration TestRunServerMetricsConfiguration(string testRunId = null, System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.ResourceMetric> metrics = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), string createdBy = null, System.DateTimeOffset? lastModifiedDateTime = default(System.DateTimeOffset?), string lastModifiedBy = null) { throw null; }
        public static Azure.Developer.LoadTesting.TestRunStatistics TestRunStatistics(string transaction = null, double? sampleCount = default(double?), double? errorCount = default(double?), double? errorPercentage = default(double?), double? meanResponseTime = default(double?), double? medianResponseTime = default(double?), double? maxResponseTime = default(double?), double? minResponseTime = default(double?), double? percentile90ResponseTime = default(double?), double? percentile95ResponseTime = default(double?), double? percentile99ResponseTime = default(double?), double? percentile75ResponseTime = default(double?), double? percentile96ResponseTime = default(double?), double? percentile97ResponseTime = default(double?), double? percentile98ResponseTime = default(double?), double? percentile999ResponseTime = default(double?), double? percentile9999ResponseTime = default(double?), double? throughput = default(double?), double? receivedKBytesPerSec = default(double?), double? sentKBytesPerSec = default(double?)) { throw null; }
        public static Azure.Developer.LoadTesting.TestServerMetricsConfiguration TestServerMetricsConfiguration(string testId = null, System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.ResourceMetric> metrics = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), string createdBy = null, System.DateTimeOffset? lastModifiedDateTime = default(System.DateTimeOffset?), string lastModifiedBy = null) { throw null; }
        public static Azure.Developer.LoadTesting.TimeSeriesElement TimeSeriesElement(System.Collections.Generic.IEnumerable<Azure.Developer.LoadTesting.MetricValue> data = null, System.Collections.Generic.IEnumerable<Azure.Developer.LoadTesting.DimensionValue> dimensionValues = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoadTestKind : System.IEquatable<Azure.Developer.LoadTesting.LoadTestKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoadTestKind(string value) { throw null; }
        public static Azure.Developer.LoadTesting.LoadTestKind Jmx { get { throw null; } }
        public static Azure.Developer.LoadTesting.LoadTestKind Locust { get { throw null; } }
        public static Azure.Developer.LoadTesting.LoadTestKind Url { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.LoadTestKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.LoadTestKind left, Azure.Developer.LoadTesting.LoadTestKind right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.LoadTestKind (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.LoadTestKind left, Azure.Developer.LoadTesting.LoadTestKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoadTestRun : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.LoadTestRun>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.LoadTestRun>
    {
        public LoadTestRun() { }
        public Azure.Developer.LoadTesting.AutoStopCriteria AutoStopCriteria { get { throw null; } set { } }
        public Azure.Developer.LoadTesting.TestCertificate Certificate { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } }
        public Azure.Developer.LoadTesting.CreatedByType? CreatedByType { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public bool? DebugLogsEnabled { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public long? Duration { get { throw null; } }
        public System.DateTimeOffset? EndDateTime { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.LoadTesting.ErrorDetails> ErrorDetails { get { throw null; } }
        public System.DateTimeOffset? ExecutedDateTime { get { throw null; } }
        public Azure.Developer.LoadTesting.LoadTestKind? Kind { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedDateTime { get { throw null; } }
        public Azure.Developer.LoadTesting.LoadTestConfiguration LoadTestConfiguration { get { throw null; } }
        public Azure.Developer.LoadTesting.PassFailCriteria PassFailCriteria { get { throw null; } set { } }
        public System.Uri PortalUri { get { throw null; } }
        public bool? PublicIpDisabled { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.Developer.LoadTesting.TestRunStatistics> RegionalStatistics { get { throw null; } }
        public Azure.Developer.LoadTesting.RequestDataLevel? RequestDataLevel { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.TestSecret> Secrets { get { throw null; } }
        public System.DateTimeOffset? StartDateTime { get { throw null; } }
        public Azure.Developer.LoadTesting.TestRunStatus? Status { get { throw null; } }
        public string SubnetId { get { throw null; } }
        public Azure.Developer.LoadTesting.TestRunArtifacts TestArtifacts { get { throw null; } }
        public string TestId { get { throw null; } set { } }
        public Azure.Developer.LoadTesting.PassFailTestResult? TestResult { get { throw null; } }
        public string TestRunId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.Developer.LoadTesting.TestRunStatistics> TestRunStatistics { get { throw null; } }
        public double? VirtualUserHours { get { throw null; } }
        public int? VirtualUsers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.LoadTestRun System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.LoadTestRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.LoadTestRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.LoadTestRun System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.LoadTestRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.LoadTestRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.LoadTestRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadTestRunClient
    {
        protected LoadTestRunClient() { }
        public LoadTestRunClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public LoadTestRunClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Developer.LoadTesting.LoadTestingClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> BeginTestProfileRun(Azure.WaitUntil waitUntil, string testProfileRunId, Azure.Core.RequestContent content, System.TimeSpan? timeSpan = default(System.TimeSpan?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> BeginTestProfileRunAsync(Azure.WaitUntil waitUntil, string testProfileRunId, Azure.Core.RequestContent content, System.TimeSpan? timeSpan = default(System.TimeSpan?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Developer.LoadTesting.TestRunResultOperation BeginTestRun(Azure.WaitUntil waitUntil, string testRunId, Azure.Core.RequestContent content, System.TimeSpan? timeSpan = default(System.TimeSpan?), string oldTestRunId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Developer.LoadTesting.TestRunResultOperation> BeginTestRunAsync(Azure.WaitUntil waitUntil, string testRunId, Azure.Core.RequestContent content, System.TimeSpan? timeSpan = default(System.TimeSpan?), string oldTestRunId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateAppComponents(string testRunId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAppComponentsAsync(string testRunId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateServerMetricsConfig(string testRunId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateServerMetricsConfigAsync(string testRunId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTestProfileRun(string testProfileRunId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTestProfileRunAsync(string testProfileRunId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTestRun(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTestRunAsync(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAppComponents(string testRunId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.LoadTesting.TestRunAppComponents> GetAppComponents(string testRunId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAppComponentsAsync(string testRunId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.LoadTesting.TestRunAppComponents>> GetAppComponentsAsync(string testRunId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetMetricDefinitions(string testRunId, string metricNamespace, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.LoadTesting.MetricDefinitions> GetMetricDefinitions(string testRunId, string metricNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMetricDefinitionsAsync(string testRunId, string metricNamespace, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.LoadTesting.MetricDefinitions>> GetMetricDefinitionsAsync(string testRunId, string metricNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetMetricDimensionValues(string testRunId, string name, string metricname, string metricNamespace, string timespan, Azure.Developer.LoadTesting.TimeGrain? interval = default(Azure.Developer.LoadTesting.TimeGrain?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetMetricDimensionValues(string testRunId, string name, string metricname, string metricNamespace, string timespan, string interval, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<string> GetMetricDimensionValuesAsync(string testRunId, string name, string metricname, string metricNamespace, string timespan, Azure.Developer.LoadTesting.TimeGrain? interval = default(Azure.Developer.LoadTesting.TimeGrain?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetMetricDimensionValuesAsync(string testRunId, string name, string metricname, string metricNamespace, string timespan, string interval, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetMetricNamespaces(string testRunId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.LoadTesting.MetricNamespaces> GetMetricNamespaces(string testRunId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMetricNamespacesAsync(string testRunId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.LoadTesting.MetricNamespaces>> GetMetricNamespacesAsync(string testRunId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetMetrics(string testRunId, string metricName, string metricNamespace, string timespan, Azure.Core.RequestContent content, string aggregation, string interval, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.LoadTesting.TimeSeriesElement> GetMetrics(string testRunId, string metricname, string metricNamespace, string timespan, Azure.Developer.LoadTesting.MetricsFilters body = null, string aggregation = null, Azure.Developer.LoadTesting.TimeGrain? interval = default(Azure.Developer.LoadTesting.TimeGrain?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetMetricsAsync(string testRunId, string metricName, string metricNamespace, string timespan, Azure.Core.RequestContent content, string aggregation, string interval, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.LoadTesting.TimeSeriesElement> GetMetricsAsync(string testRunId, string metricname, string metricNamespace, string timespan, Azure.Developer.LoadTesting.MetricsFilters body = null, string aggregation = null, Azure.Developer.LoadTesting.TimeGrain? interval = default(Azure.Developer.LoadTesting.TimeGrain?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetServerMetricsConfig(string testRunId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.LoadTesting.TestRunServerMetricsConfiguration> GetServerMetricsConfig(string testRunId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetServerMetricsConfigAsync(string testRunId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.LoadTesting.TestRunServerMetricsConfiguration>> GetServerMetricsConfigAsync(string testRunId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTestProfileRun(string testProfileRunId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.LoadTesting.TestProfileRun> GetTestProfileRun(string testProfileRunId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTestProfileRunAsync(string testProfileRunId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.LoadTesting.TestProfileRun>> GetTestProfileRunAsync(string testProfileRunId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTestProfileRuns(System.DateTimeOffset? minStartDateTime, System.DateTimeOffset? maxStartDateTime, System.DateTimeOffset? minEndDateTime, System.DateTimeOffset? maxEndDateTime, System.DateTimeOffset? createdDateStartTime, System.DateTimeOffset? createdDateEndTime, System.Collections.Generic.IEnumerable<string> testProfileRunIds, System.Collections.Generic.IEnumerable<string> testProfileIds, System.Collections.Generic.IEnumerable<string> statuses, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.LoadTesting.TestProfileRun> GetTestProfileRuns(System.DateTimeOffset? minStartDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? maxStartDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? minEndDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? maxEndDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? createdDateStartTime = default(System.DateTimeOffset?), System.DateTimeOffset? createdDateEndTime = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> testProfileRunIds = null, System.Collections.Generic.IEnumerable<string> testProfileIds = null, System.Collections.Generic.IEnumerable<string> statuses = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTestProfileRunsAsync(System.DateTimeOffset? minStartDateTime, System.DateTimeOffset? maxStartDateTime, System.DateTimeOffset? minEndDateTime, System.DateTimeOffset? maxEndDateTime, System.DateTimeOffset? createdDateStartTime, System.DateTimeOffset? createdDateEndTime, System.Collections.Generic.IEnumerable<string> testProfileRunIds, System.Collections.Generic.IEnumerable<string> testProfileIds, System.Collections.Generic.IEnumerable<string> statuses, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.LoadTesting.TestProfileRun> GetTestProfileRunsAsync(System.DateTimeOffset? minStartDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? maxStartDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? minEndDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? maxEndDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? createdDateStartTime = default(System.DateTimeOffset?), System.DateTimeOffset? createdDateEndTime = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> testProfileRunIds = null, System.Collections.Generic.IEnumerable<string> testProfileIds = null, System.Collections.Generic.IEnumerable<string> statuses = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTestRun(string testRunId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.LoadTesting.LoadTestRun> GetTestRun(string testRunId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTestRunAsync(string testRunId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.LoadTesting.LoadTestRun>> GetTestRunAsync(string testRunId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTestRunFile(string testRunId, string fileName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.LoadTesting.TestRunFileInfo> GetTestRunFile(string testRunId, string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTestRunFileAsync(string testRunId, string fileName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.LoadTesting.TestRunFileInfo>> GetTestRunFileAsync(string testRunId, string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTestRuns(string orderby, string search, string testId, System.DateTimeOffset? executionFrom, System.DateTimeOffset? executionTo, string status, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.LoadTesting.LoadTestRun> GetTestRuns(string orderby = null, string search = null, string testId = null, System.DateTimeOffset? executionFrom = default(System.DateTimeOffset?), System.DateTimeOffset? executionTo = default(System.DateTimeOffset?), string status = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTestRunsAsync(string orderby, string search, string testId, System.DateTimeOffset? executionFrom, System.DateTimeOffset? executionTo, string status, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.LoadTesting.LoadTestRun> GetTestRunsAsync(string orderby = null, string search = null, string testId = null, System.DateTimeOffset? executionFrom = default(System.DateTimeOffset?), System.DateTimeOffset? executionTo = default(System.DateTimeOffset?), string status = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopTestProfileRun(string testProfileRunId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.LoadTesting.TestProfileRun> StopTestProfileRun(string testProfileRunId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopTestProfileRunAsync(string testProfileRunId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.LoadTesting.TestProfileRun>> StopTestProfileRunAsync(string testProfileRunId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopTestRun(string testRunId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.LoadTesting.LoadTestRun> StopTestRun(string testRunId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopTestRunAsync(string testRunId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.LoadTesting.LoadTestRun>> StopTestRunAsync(string testRunId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetricAvailability : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricAvailability>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricAvailability>
    {
        internal MetricAvailability() { }
        public Azure.Developer.LoadTesting.TimeGrain? TimeGrain { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.MetricAvailability System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricAvailability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricAvailability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.MetricAvailability System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricAvailability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricAvailability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricAvailability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetricDefinition : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricDefinition>
    {
        internal MetricDefinition() { }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.LoadTesting.NameAndDescription> Dimensions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.LoadTesting.MetricAvailability> MetricAvailabilities { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public Azure.Developer.LoadTesting.AggregationType? PrimaryAggregationType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedAggregationTypes { get { throw null; } }
        public Azure.Developer.LoadTesting.MetricUnit? Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.MetricDefinition System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.MetricDefinition System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetricDefinitions : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricDefinitions>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricDefinitions>
    {
        internal MetricDefinitions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.LoadTesting.MetricDefinition> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.MetricDefinitions System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricDefinitions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricDefinitions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.MetricDefinitions System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricDefinitions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricDefinitions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricDefinitions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetricNamespace : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricNamespace>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricNamespace>
    {
        internal MetricNamespace() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.MetricNamespace System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricNamespace>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricNamespace>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.MetricNamespace System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricNamespace>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricNamespace>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricNamespace>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetricNamespaces : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricNamespaces>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricNamespaces>
    {
        internal MetricNamespaces() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.LoadTesting.MetricNamespace> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.MetricNamespaces System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricNamespaces>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricNamespaces>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.MetricNamespaces System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricNamespaces>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricNamespaces>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricNamespaces>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetricsFilters : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricsFilters>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricsFilters>
    {
        public MetricsFilters() { }
        public System.Collections.Generic.IList<Azure.Developer.LoadTesting.DimensionFilter> Filters { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.MetricsFilters System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricsFilters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricsFilters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.MetricsFilters System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricsFilters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricsFilters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricsFilters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricUnit : System.IEquatable<Azure.Developer.LoadTesting.MetricUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricUnit(string value) { throw null; }
        public static Azure.Developer.LoadTesting.MetricUnit Bytes { get { throw null; } }
        public static Azure.Developer.LoadTesting.MetricUnit BytesPerSecond { get { throw null; } }
        public static Azure.Developer.LoadTesting.MetricUnit Count { get { throw null; } }
        public static Azure.Developer.LoadTesting.MetricUnit CountPerSecond { get { throw null; } }
        public static Azure.Developer.LoadTesting.MetricUnit Milliseconds { get { throw null; } }
        public static Azure.Developer.LoadTesting.MetricUnit NotSpecified { get { throw null; } }
        public static Azure.Developer.LoadTesting.MetricUnit Percent { get { throw null; } }
        public static Azure.Developer.LoadTesting.MetricUnit Seconds { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.MetricUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.MetricUnit left, Azure.Developer.LoadTesting.MetricUnit right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.MetricUnit (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.MetricUnit left, Azure.Developer.LoadTesting.MetricUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricValue : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricValue>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricValue>
    {
        internal MetricValue() { }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public double? Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.MetricValue System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.MetricValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.MetricValue System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.MetricValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NameAndDescription : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.NameAndDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.NameAndDescription>
    {
        internal NameAndDescription() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.NameAndDescription System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.NameAndDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.NameAndDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.NameAndDescription System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.NameAndDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.NameAndDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.NameAndDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OptionalLoadTestConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.OptionalLoadTestConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.OptionalLoadTestConfiguration>
    {
        public OptionalLoadTestConfiguration() { }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Uri EndpointUri { get { throw null; } set { } }
        public int? MaxResponseTimeInMs { get { throw null; } set { } }
        public int? RampUpTime { get { throw null; } set { } }
        public int? RequestsPerSecond { get { throw null; } set { } }
        public int? VirtualUsers { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.OptionalLoadTestConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.OptionalLoadTestConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.OptionalLoadTestConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.OptionalLoadTestConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.OptionalLoadTestConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.OptionalLoadTestConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.OptionalLoadTestConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PassFailAction : System.IEquatable<Azure.Developer.LoadTesting.PassFailAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PassFailAction(string value) { throw null; }
        public static Azure.Developer.LoadTesting.PassFailAction Continue { get { throw null; } }
        public static Azure.Developer.LoadTesting.PassFailAction Stop { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.PassFailAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.PassFailAction left, Azure.Developer.LoadTesting.PassFailAction right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.PassFailAction (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.PassFailAction left, Azure.Developer.LoadTesting.PassFailAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PassFailAggregationFunction : System.IEquatable<Azure.Developer.LoadTesting.PassFailAggregationFunction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PassFailAggregationFunction(string value) { throw null; }
        public static Azure.Developer.LoadTesting.PassFailAggregationFunction Average { get { throw null; } }
        public static Azure.Developer.LoadTesting.PassFailAggregationFunction Count { get { throw null; } }
        public static Azure.Developer.LoadTesting.PassFailAggregationFunction Maximum { get { throw null; } }
        public static Azure.Developer.LoadTesting.PassFailAggregationFunction Minimum { get { throw null; } }
        public static Azure.Developer.LoadTesting.PassFailAggregationFunction Percentage { get { throw null; } }
        public static Azure.Developer.LoadTesting.PassFailAggregationFunction Percentile50 { get { throw null; } }
        public static Azure.Developer.LoadTesting.PassFailAggregationFunction Percentile75 { get { throw null; } }
        public static Azure.Developer.LoadTesting.PassFailAggregationFunction Percentile90 { get { throw null; } }
        public static Azure.Developer.LoadTesting.PassFailAggregationFunction Percentile95 { get { throw null; } }
        public static Azure.Developer.LoadTesting.PassFailAggregationFunction Percentile96 { get { throw null; } }
        public static Azure.Developer.LoadTesting.PassFailAggregationFunction Percentile97 { get { throw null; } }
        public static Azure.Developer.LoadTesting.PassFailAggregationFunction Percentile98 { get { throw null; } }
        public static Azure.Developer.LoadTesting.PassFailAggregationFunction Percentile99 { get { throw null; } }
        public static Azure.Developer.LoadTesting.PassFailAggregationFunction Percentile999 { get { throw null; } }
        public static Azure.Developer.LoadTesting.PassFailAggregationFunction Percentile9999 { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.PassFailAggregationFunction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.PassFailAggregationFunction left, Azure.Developer.LoadTesting.PassFailAggregationFunction right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.PassFailAggregationFunction (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.PassFailAggregationFunction left, Azure.Developer.LoadTesting.PassFailAggregationFunction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PassFailCriteria : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.PassFailCriteria>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.PassFailCriteria>
    {
        public PassFailCriteria() { }
        public System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.PassFailMetric> PassFailMetrics { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.PassFailServerMetric> PassFailServerMetrics { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.PassFailCriteria System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.PassFailCriteria>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.PassFailCriteria>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.PassFailCriteria System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.PassFailCriteria>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.PassFailCriteria>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.PassFailCriteria>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PassFailMetric : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.PassFailMetric>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.PassFailMetric>
    {
        public PassFailMetric() { }
        public Azure.Developer.LoadTesting.PassFailAction? Action { get { throw null; } set { } }
        public double? ActualValue { get { throw null; } }
        public Azure.Developer.LoadTesting.PassFailAggregationFunction? Aggregate { get { throw null; } set { } }
        public Azure.Developer.LoadTesting.PfMetrics? ClientMetric { get { throw null; } set { } }
        public string Condition { get { throw null; } set { } }
        public string RequestName { get { throw null; } set { } }
        public Azure.Developer.LoadTesting.PassFailResult? Result { get { throw null; } }
        public double? Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.PassFailMetric System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.PassFailMetric>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.PassFailMetric>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.PassFailMetric System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.PassFailMetric>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.PassFailMetric>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.PassFailMetric>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PassFailResult : System.IEquatable<Azure.Developer.LoadTesting.PassFailResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PassFailResult(string value) { throw null; }
        public static Azure.Developer.LoadTesting.PassFailResult Failed { get { throw null; } }
        public static Azure.Developer.LoadTesting.PassFailResult Passed { get { throw null; } }
        public static Azure.Developer.LoadTesting.PassFailResult Undetermined { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.PassFailResult other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.PassFailResult left, Azure.Developer.LoadTesting.PassFailResult right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.PassFailResult (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.PassFailResult left, Azure.Developer.LoadTesting.PassFailResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PassFailServerMetric : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.PassFailServerMetric>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.PassFailServerMetric>
    {
        public PassFailServerMetric(Azure.Core.ResourceIdentifier resourceId, string metricNamespace, string metricName, string aggregation, string condition, double value) { }
        public Azure.Developer.LoadTesting.PassFailAction? Action { get { throw null; } set { } }
        public double? ActualValue { get { throw null; } }
        public string Aggregation { get { throw null; } set { } }
        public string Condition { get { throw null; } set { } }
        public string MetricName { get { throw null; } set { } }
        public string MetricNamespace { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.Developer.LoadTesting.PassFailResult? Result { get { throw null; } }
        public double Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.PassFailServerMetric System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.PassFailServerMetric>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.PassFailServerMetric>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.PassFailServerMetric System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.PassFailServerMetric>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.PassFailServerMetric>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.PassFailServerMetric>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PassFailTestResult : System.IEquatable<Azure.Developer.LoadTesting.PassFailTestResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PassFailTestResult(string value) { throw null; }
        public static Azure.Developer.LoadTesting.PassFailTestResult FAILED { get { throw null; } }
        public static Azure.Developer.LoadTesting.PassFailTestResult NOTAPPLICABLE { get { throw null; } }
        public static Azure.Developer.LoadTesting.PassFailTestResult PASSED { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.PassFailTestResult other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.PassFailTestResult left, Azure.Developer.LoadTesting.PassFailTestResult right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.PassFailTestResult (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.PassFailTestResult left, Azure.Developer.LoadTesting.PassFailTestResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PfMetrics : System.IEquatable<Azure.Developer.LoadTesting.PfMetrics>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PfMetrics(string value) { throw null; }
        public static Azure.Developer.LoadTesting.PfMetrics Error { get { throw null; } }
        public static Azure.Developer.LoadTesting.PfMetrics Latency { get { throw null; } }
        public static Azure.Developer.LoadTesting.PfMetrics Requests { get { throw null; } }
        public static Azure.Developer.LoadTesting.PfMetrics RequestsPerSecond { get { throw null; } }
        public static Azure.Developer.LoadTesting.PfMetrics ResponseTimeInMilliseconds { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.PfMetrics other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.PfMetrics left, Azure.Developer.LoadTesting.PfMetrics right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.PfMetrics (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.PfMetrics left, Azure.Developer.LoadTesting.PfMetrics right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendationCategory : System.IEquatable<Azure.Developer.LoadTesting.RecommendationCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationCategory(string value) { throw null; }
        public static Azure.Developer.LoadTesting.RecommendationCategory CostOptimized { get { throw null; } }
        public static Azure.Developer.LoadTesting.RecommendationCategory ThroughputOptimized { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.RecommendationCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.RecommendationCategory left, Azure.Developer.LoadTesting.RecommendationCategory right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.RecommendationCategory (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.RecommendationCategory left, Azure.Developer.LoadTesting.RecommendationCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegionalConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.RegionalConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.RegionalConfiguration>
    {
        public RegionalConfiguration(int engineInstances, Azure.Core.AzureLocation region) { }
        public int EngineInstances { get { throw null; } set { } }
        public Azure.Core.AzureLocation Region { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.RegionalConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.RegionalConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.RegionalConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.RegionalConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.RegionalConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.RegionalConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.RegionalConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestDataLevel : System.IEquatable<Azure.Developer.LoadTesting.RequestDataLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestDataLevel(string value) { throw null; }
        public static Azure.Developer.LoadTesting.RequestDataLevel ERRORS { get { throw null; } }
        public static Azure.Developer.LoadTesting.RequestDataLevel NONE { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.RequestDataLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.RequestDataLevel left, Azure.Developer.LoadTesting.RequestDataLevel right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.RequestDataLevel (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.RequestDataLevel left, Azure.Developer.LoadTesting.RequestDataLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceMetric : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.ResourceMetric>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.ResourceMetric>
    {
        public ResourceMetric(Azure.Core.ResourceIdentifier resourceId, string metricNamespace, string name, string aggregation, string resourceType) { }
        public string Aggregation { get { throw null; } set { } }
        public string DisplayDescription { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string MetricNamespace { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        public string Unit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.ResourceMetric System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.ResourceMetric>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.ResourceMetric>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.ResourceMetric System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.ResourceMetric>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.ResourceMetric>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.ResourceMetric>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecretType : System.IEquatable<Azure.Developer.LoadTesting.SecretType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecretType(string value) { throw null; }
        public static Azure.Developer.LoadTesting.SecretType KeyVaultSecretUri { get { throw null; } }
        public static Azure.Developer.LoadTesting.SecretType SecretValue { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.SecretType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.SecretType left, Azure.Developer.LoadTesting.SecretType right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.SecretType (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.SecretType left, Azure.Developer.LoadTesting.SecretType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class TargetResourceConfigurations : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TargetResourceConfigurations>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TargetResourceConfigurations>
    {
        protected TargetResourceConfigurations() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TargetResourceConfigurations System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TargetResourceConfigurations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TargetResourceConfigurations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TargetResourceConfigurations System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TargetResourceConfigurations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TargetResourceConfigurations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TargetResourceConfigurations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestAppComponents : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestAppComponents>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestAppComponents>
    {
        public TestAppComponents(System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.LoadTestingAppComponent> components) { }
        public System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.LoadTestingAppComponent> Components { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedDateTime { get { throw null; } }
        public string TestId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestAppComponents System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestAppComponents>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestAppComponents>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestAppComponents System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestAppComponents>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestAppComponents>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestAppComponents>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestCertificate : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestCertificate>
    {
        public TestCertificate() { }
        public Azure.Developer.LoadTesting.CertificateType? CertificateKind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestCertificate System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestCertificate System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestFileInfo : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestFileInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestFileInfo>
    {
        internal TestFileInfo() { }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string FileName { get { throw null; } }
        public Azure.Developer.LoadTesting.LoadTestingFileType? FileType { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public string ValidationFailureDetails { get { throw null; } }
        public Azure.Developer.LoadTesting.FileValidationStatus? ValidationStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestFileInfo System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestFileInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestFileInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestFileInfo System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestFileInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestFileInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestFileInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestInputArtifacts : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestInputArtifacts>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestInputArtifacts>
    {
        internal TestInputArtifacts() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.LoadTesting.TestFileInfo> AdditionalFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.TestFileInfo ConfigFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.TestFileInfo InputArtifactsZipFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.TestFileInfo TestScriptFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.TestFileInfo UrlTestConfigFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.TestFileInfo UserPropertyFileInfo { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestInputArtifacts System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestInputArtifacts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestInputArtifacts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestInputArtifacts System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestInputArtifacts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestInputArtifacts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestInputArtifacts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestProfile : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestProfile>
    {
        public TestProfile() { }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedDateTime { get { throw null; } }
        public Azure.Developer.LoadTesting.TargetResourceConfigurations TargetResourceConfigurations { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public string TestId { get { throw null; } set { } }
        public string TestProfileId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestProfile System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestProfile System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestProfileRun : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestProfileRun>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestProfileRun>
    {
        public TestProfileRun() { }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public long? DurationInSeconds { get { throw null; } }
        public System.DateTimeOffset? EndDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.LoadTesting.ErrorDetails> ErrorDetails { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.LoadTesting.TestProfileRunRecommendation> Recommendations { get { throw null; } }
        public System.DateTimeOffset? StartDateTime { get { throw null; } }
        public Azure.Developer.LoadTesting.TestProfileRunStatus? Status { get { throw null; } }
        public Azure.Developer.LoadTesting.TargetResourceConfigurations TargetResourceConfigurations { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } }
        public string TestProfileId { get { throw null; } set { } }
        public string TestProfileRunId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.Developer.LoadTesting.TestRunDetail> TestRunDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestProfileRun System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestProfileRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestProfileRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestProfileRun System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestProfileRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestProfileRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestProfileRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestProfileRunRecommendation : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestProfileRunRecommendation>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestProfileRunRecommendation>
    {
        internal TestProfileRunRecommendation() { }
        public Azure.Developer.LoadTesting.RecommendationCategory Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Configurations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestProfileRunRecommendation System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestProfileRunRecommendation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestProfileRunRecommendation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestProfileRunRecommendation System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestProfileRunRecommendation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestProfileRunRecommendation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestProfileRunRecommendation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestProfileRunResultOperation : Azure.Operation<System.BinaryData>
    {
        protected TestProfileRunResultOperation() { }
        public TestProfileRunResultOperation(string testProfileRunId, Azure.Developer.LoadTesting.LoadTestRunClient client, Azure.Response initialResponse = null) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override System.BinaryData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TestProfileRunStatus : System.IEquatable<Azure.Developer.LoadTesting.TestProfileRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TestProfileRunStatus(string value) { throw null; }
        public static Azure.Developer.LoadTesting.TestProfileRunStatus Accepted { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestProfileRunStatus Cancelled { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestProfileRunStatus Cancelling { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestProfileRunStatus Done { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestProfileRunStatus Executing { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestProfileRunStatus Failed { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestProfileRunStatus NotStarted { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.TestProfileRunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.TestProfileRunStatus left, Azure.Developer.LoadTesting.TestProfileRunStatus right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.TestProfileRunStatus (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.TestProfileRunStatus left, Azure.Developer.LoadTesting.TestProfileRunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TestRunAppComponents : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunAppComponents>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunAppComponents>
    {
        public TestRunAppComponents(System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.LoadTestingAppComponent> components) { }
        public System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.LoadTestingAppComponent> Components { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedDateTime { get { throw null; } }
        public string TestRunId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestRunAppComponents System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunAppComponents>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunAppComponents>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestRunAppComponents System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunAppComponents>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunAppComponents>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunAppComponents>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestRunArtifacts : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunArtifacts>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunArtifacts>
    {
        internal TestRunArtifacts() { }
        public Azure.Developer.LoadTesting.TestRunInputArtifacts InputArtifacts { get { throw null; } }
        public Azure.Developer.LoadTesting.TestRunOutputArtifacts OutputArtifacts { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestRunArtifacts System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunArtifacts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunArtifacts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestRunArtifacts System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunArtifacts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunArtifacts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunArtifacts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestRunDetail : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunDetail>
    {
        internal TestRunDetail() { }
        public string ConfigurationId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public Azure.Developer.LoadTesting.TestRunStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestRunDetail System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestRunDetail System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestRunFileInfo : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunFileInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunFileInfo>
    {
        internal TestRunFileInfo() { }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string FileName { get { throw null; } }
        public Azure.Developer.LoadTesting.LoadTestingFileType? FileType { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public string ValidationFailureDetails { get { throw null; } }
        public Azure.Developer.LoadTesting.FileValidationStatus? ValidationStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestRunFileInfo System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunFileInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunFileInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestRunFileInfo System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunFileInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunFileInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunFileInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestRunInputArtifacts : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunInputArtifacts>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunInputArtifacts>
    {
        internal TestRunInputArtifacts() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.LoadTesting.TestRunFileInfo> AdditionalFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.TestRunFileInfo ConfigFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.TestRunFileInfo InputArtifactsZipFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.TestRunFileInfo TestScriptFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.TestRunFileInfo UrlTestConfigFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.TestRunFileInfo UserPropertyFileInfo { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestRunInputArtifacts System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunInputArtifacts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunInputArtifacts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestRunInputArtifacts System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunInputArtifacts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunInputArtifacts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunInputArtifacts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestRunOutputArtifacts : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunOutputArtifacts>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunOutputArtifacts>
    {
        internal TestRunOutputArtifacts() { }
        public Azure.Developer.LoadTesting.ArtifactsContainerInfo ArtifactsContainerInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.TestRunFileInfo LogsFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.TestRunFileInfo ReportFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.TestRunFileInfo ResultFileInfo { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestRunOutputArtifacts System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunOutputArtifacts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunOutputArtifacts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestRunOutputArtifacts System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunOutputArtifacts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunOutputArtifacts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunOutputArtifacts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestRunResultOperation : Azure.Operation<System.BinaryData>
    {
        protected TestRunResultOperation() { }
        public TestRunResultOperation(string testRunId, Azure.Developer.LoadTesting.LoadTestRunClient client, Azure.Response initialResponse = null) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override System.BinaryData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TestRunServerMetricsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunServerMetricsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunServerMetricsConfiguration>
    {
        public TestRunServerMetricsConfiguration() { }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedDateTime { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.ResourceMetric> Metrics { get { throw null; } }
        public string TestRunId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestRunServerMetricsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunServerMetricsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunServerMetricsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestRunServerMetricsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunServerMetricsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunServerMetricsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunServerMetricsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestRunStatistics : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunStatistics>
    {
        internal TestRunStatistics() { }
        public double? ErrorCount { get { throw null; } }
        public double? ErrorPercentage { get { throw null; } }
        public double? MaxResponseTime { get { throw null; } }
        public double? MeanResponseTime { get { throw null; } }
        public double? MedianResponseTime { get { throw null; } }
        public double? MinResponseTime { get { throw null; } }
        public double? Percentile75ResponseTime { get { throw null; } }
        public double? Percentile90ResponseTime { get { throw null; } }
        public double? Percentile95ResponseTime { get { throw null; } }
        public double? Percentile96ResponseTime { get { throw null; } }
        public double? Percentile97ResponseTime { get { throw null; } }
        public double? Percentile98ResponseTime { get { throw null; } }
        public double? Percentile9999ResponseTime { get { throw null; } }
        public double? Percentile999ResponseTime { get { throw null; } }
        public double? Percentile99ResponseTime { get { throw null; } }
        public double? ReceivedKBytesPerSec { get { throw null; } }
        public double? SampleCount { get { throw null; } }
        public double? SentKBytesPerSec { get { throw null; } }
        public double? Throughput { get { throw null; } }
        public string Transaction { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestRunStatistics System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestRunStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestRunStatistics System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestRunStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TestRunStatus : System.IEquatable<Azure.Developer.LoadTesting.TestRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TestRunStatus(string value) { throw null; }
        public static Azure.Developer.LoadTesting.TestRunStatus Accepted { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestRunStatus Cancelled { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestRunStatus Cancelling { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestRunStatus Configured { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestRunStatus Configuring { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestRunStatus Deprovisioned { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestRunStatus Deprovisioning { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestRunStatus Done { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestRunStatus Executed { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestRunStatus Executing { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestRunStatus Failed { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestRunStatus NotStarted { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestRunStatus Provisioned { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestRunStatus Provisioning { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestRunStatus ValidationFailure { get { throw null; } }
        public static Azure.Developer.LoadTesting.TestRunStatus ValidationSuccess { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.TestRunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.TestRunStatus left, Azure.Developer.LoadTesting.TestRunStatus right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.TestRunStatus (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.TestRunStatus left, Azure.Developer.LoadTesting.TestRunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TestSecret : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestSecret>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestSecret>
    {
        public TestSecret() { }
        public Azure.Developer.LoadTesting.SecretType? SecretKind { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestSecret System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestSecret>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestSecret>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestSecret System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestSecret>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestSecret>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestSecret>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestServerMetricsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestServerMetricsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestServerMetricsConfiguration>
    {
        public TestServerMetricsConfiguration(System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.ResourceMetric> metrics) { }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedDateTime { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.ResourceMetric> Metrics { get { throw null; } }
        public string TestId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestServerMetricsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestServerMetricsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TestServerMetricsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TestServerMetricsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestServerMetricsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestServerMetricsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TestServerMetricsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimeGrain : System.IEquatable<Azure.Developer.LoadTesting.TimeGrain>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeGrain(string value) { throw null; }
        public static Azure.Developer.LoadTesting.TimeGrain FiveMinutes { get { throw null; } }
        public static Azure.Developer.LoadTesting.TimeGrain FiveSeconds { get { throw null; } }
        public static Azure.Developer.LoadTesting.TimeGrain OneHour { get { throw null; } }
        public static Azure.Developer.LoadTesting.TimeGrain OneMinute { get { throw null; } }
        public static Azure.Developer.LoadTesting.TimeGrain TenSeconds { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.TimeGrain other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.TimeGrain left, Azure.Developer.LoadTesting.TimeGrain right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.TimeGrain (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.TimeGrain left, Azure.Developer.LoadTesting.TimeGrain right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TimeSeriesElement : System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TimeSeriesElement>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TimeSeriesElement>
    {
        internal TimeSeriesElement() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.LoadTesting.MetricValue> Data { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.LoadTesting.DimensionValue> DimensionValues { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TimeSeriesElement System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TimeSeriesElement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.LoadTesting.TimeSeriesElement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.LoadTesting.TimeSeriesElement System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TimeSeriesElement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TimeSeriesElement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.LoadTesting.TimeSeriesElement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AzureLoadTestingClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.LoadTesting.LoadTestAdministrationClient, Azure.Developer.LoadTesting.LoadTestingClientOptions> AddLoadTestAdministrationClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.LoadTesting.LoadTestAdministrationClient, Azure.Developer.LoadTesting.LoadTestingClientOptions> AddLoadTestAdministrationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.LoadTesting.LoadTestRunClient, Azure.Developer.LoadTesting.LoadTestingClientOptions> AddLoadTestRunClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.LoadTesting.LoadTestRunClient, Azure.Developer.LoadTesting.LoadTestingClientOptions> AddLoadTestRunClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
