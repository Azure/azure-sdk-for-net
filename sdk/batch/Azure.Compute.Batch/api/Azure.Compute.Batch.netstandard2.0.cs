namespace Azure.Compute.Batch
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessScope : System.IEquatable<Azure.Compute.Batch.AccessScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessScope(string value) { throw null; }
        public static Azure.Compute.Batch.AccessScope Job { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.AccessScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.AccessScope left, Azure.Compute.Batch.AccessScope right) { throw null; }
        public static implicit operator Azure.Compute.Batch.AccessScope (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.AccessScope left, Azure.Compute.Batch.AccessScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AddTaskCollectionTerminatedException : Azure.Compute.Batch.BatchClientException
    {
        internal AddTaskCollectionTerminatedException() { }
        public Azure.Compute.Batch.CreateTaskResult AddTaskResult { get { throw null; } }
    }
    public partial class AffinityInfo : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AffinityInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AffinityInfo>
    {
        public AffinityInfo(string affinityId) { }
        public string AffinityId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.AffinityInfo System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AffinityInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AffinityInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.AffinityInfo System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AffinityInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AffinityInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AffinityInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllocationState : System.IEquatable<Azure.Compute.Batch.AllocationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllocationState(string value) { throw null; }
        public static Azure.Compute.Batch.AllocationState Resizing { get { throw null; } }
        public static Azure.Compute.Batch.AllocationState Steady { get { throw null; } }
        public static Azure.Compute.Batch.AllocationState Stopping { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.AllocationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.AllocationState left, Azure.Compute.Batch.AllocationState right) { throw null; }
        public static implicit operator Azure.Compute.Batch.AllocationState (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.AllocationState left, Azure.Compute.Batch.AllocationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AuthenticationTokenSettings : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AuthenticationTokenSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AuthenticationTokenSettings>
    {
        public AuthenticationTokenSettings() { }
        public System.Collections.Generic.IList<Azure.Compute.Batch.AccessScope> Access { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.AuthenticationTokenSettings System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AuthenticationTokenSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AuthenticationTokenSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.AuthenticationTokenSettings System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AuthenticationTokenSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AuthenticationTokenSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AuthenticationTokenSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutomaticOsUpgradePolicy : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AutomaticOsUpgradePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AutomaticOsUpgradePolicy>
    {
        public AutomaticOsUpgradePolicy() { }
        public bool? DisableAutomaticRollback { get { throw null; } set { } }
        public bool? EnableAutomaticOsUpgrade { get { throw null; } set { } }
        public bool? OsRollingUpgradeDeferral { get { throw null; } set { } }
        public bool? UseRollingUpgradePolicy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.AutomaticOsUpgradePolicy System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AutomaticOsUpgradePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AutomaticOsUpgradePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.AutomaticOsUpgradePolicy System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AutomaticOsUpgradePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AutomaticOsUpgradePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AutomaticOsUpgradePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutoScaleRun : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AutoScaleRun>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AutoScaleRun>
    {
        internal AutoScaleRun() { }
        public Azure.Compute.Batch.AutoScaleRunError Error { get { throw null; } }
        public string Results { get { throw null; } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.AutoScaleRun System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AutoScaleRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AutoScaleRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.AutoScaleRun System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AutoScaleRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AutoScaleRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AutoScaleRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutoScaleRunError : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AutoScaleRunError>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AutoScaleRunError>
    {
        internal AutoScaleRunError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.NameValuePair> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.AutoScaleRunError System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AutoScaleRunError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AutoScaleRunError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.AutoScaleRunError System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AutoScaleRunError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AutoScaleRunError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AutoScaleRunError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoUserScope : System.IEquatable<Azure.Compute.Batch.AutoUserScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoUserScope(string value) { throw null; }
        public static Azure.Compute.Batch.AutoUserScope Pool { get { throw null; } }
        public static Azure.Compute.Batch.AutoUserScope Task { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.AutoUserScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.AutoUserScope left, Azure.Compute.Batch.AutoUserScope right) { throw null; }
        public static implicit operator Azure.Compute.Batch.AutoUserScope (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.AutoUserScope left, Azure.Compute.Batch.AutoUserScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutoUserSpecification : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AutoUserSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AutoUserSpecification>
    {
        public AutoUserSpecification() { }
        public Azure.Compute.Batch.ElevationLevel? ElevationLevel { get { throw null; } set { } }
        public Azure.Compute.Batch.AutoUserScope? Scope { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.AutoUserSpecification System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AutoUserSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AutoUserSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.AutoUserSpecification System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AutoUserSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AutoUserSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AutoUserSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureBlobFileSystemConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AzureBlobFileSystemConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AzureBlobFileSystemConfiguration>
    {
        public AzureBlobFileSystemConfiguration(string accountName, string containerName, string relativeMountPath) { }
        public string AccountKey { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public string BlobfuseOptions { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchNodeIdentityReference IdentityReference { get { throw null; } set { } }
        public string RelativeMountPath { get { throw null; } set { } }
        public string SasKey { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.AzureBlobFileSystemConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AzureBlobFileSystemConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AzureBlobFileSystemConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.AzureBlobFileSystemConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AzureBlobFileSystemConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AzureBlobFileSystemConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AzureBlobFileSystemConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureComputeBatchContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureComputeBatchContext() { }
        public static Azure.Compute.Batch.AzureComputeBatchContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class AzureFileShareConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AzureFileShareConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AzureFileShareConfiguration>
    {
        public AzureFileShareConfiguration(string accountName, string azureFileUrl, string accountKey, string relativeMountPath) { }
        public string AccountKey { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public string AzureFileUrl { get { throw null; } set { } }
        public string MountOptions { get { throw null; } set { } }
        public string RelativeMountPath { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.AzureFileShareConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AzureFileShareConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.AzureFileShareConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.AzureFileShareConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AzureFileShareConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AzureFileShareConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.AzureFileShareConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchApplication : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchApplication>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchApplication>
    {
        internal BatchApplication() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Versions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchApplication System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchApplication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchApplication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchApplication System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchApplication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchApplication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchApplication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchApplicationPackageReference : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchApplicationPackageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchApplicationPackageReference>
    {
        public BatchApplicationPackageReference(string applicationId) { }
        public string ApplicationId { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchApplicationPackageReference System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchApplicationPackageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchApplicationPackageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchApplicationPackageReference System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchApplicationPackageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchApplicationPackageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchApplicationPackageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchAutoPoolSpecification : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchAutoPoolSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchAutoPoolSpecification>
    {
        public BatchAutoPoolSpecification(Azure.Compute.Batch.BatchPoolLifetimeOption poolLifetimeOption) { }
        public string AutoPoolIdPrefix { get { throw null; } set { } }
        public bool? KeepAlive { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchPoolSpecification Pool { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchPoolLifetimeOption PoolLifetimeOption { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchAutoPoolSpecification System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchAutoPoolSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchAutoPoolSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchAutoPoolSpecification System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchAutoPoolSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchAutoPoolSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchAutoPoolSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchCertificate : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchCertificate>
    {
        public BatchCertificate(string thumbprint, string thumbprintAlgorithm, string data) { }
        public Azure.Compute.Batch.BatchCertificateFormat? CertificateFormat { get { throw null; } set { } }
        public string Data { get { throw null; } set { } }
        public Azure.Compute.Batch.DeleteBatchCertificateError DeleteCertificateError { get { throw null; } }
        public string Password { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchCertificateState? PreviousState { get { throw null; } }
        public System.DateTimeOffset? PreviousStateTransitionTime { get { throw null; } }
        public string PublicData { get { throw null; } }
        public Azure.Compute.Batch.BatchCertificateState? State { get { throw null; } }
        public System.DateTimeOffset? StateTransitionTime { get { throw null; } }
        public string Thumbprint { get { throw null; } set { } }
        public string ThumbprintAlgorithm { get { throw null; } set { } }
        public string Url { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchCertificate System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchCertificate System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchCertificateFormat : System.IEquatable<Azure.Compute.Batch.BatchCertificateFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchCertificateFormat(string value) { throw null; }
        public static Azure.Compute.Batch.BatchCertificateFormat Cer { get { throw null; } }
        public static Azure.Compute.Batch.BatchCertificateFormat Pfx { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchCertificateFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchCertificateFormat left, Azure.Compute.Batch.BatchCertificateFormat right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchCertificateFormat (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchCertificateFormat left, Azure.Compute.Batch.BatchCertificateFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchCertificateReference : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchCertificateReference>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchCertificateReference>
    {
        public BatchCertificateReference(string thumbprint, string thumbprintAlgorithm) { }
        public Azure.Compute.Batch.BatchCertificateStoreLocation? StoreLocation { get { throw null; } set { } }
        public string StoreName { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
        public string ThumbprintAlgorithm { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.BatchCertificateVisibility> Visibility { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchCertificateReference System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchCertificateReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchCertificateReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchCertificateReference System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchCertificateReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchCertificateReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchCertificateReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchCertificateState : System.IEquatable<Azure.Compute.Batch.BatchCertificateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchCertificateState(string value) { throw null; }
        public static Azure.Compute.Batch.BatchCertificateState Active { get { throw null; } }
        public static Azure.Compute.Batch.BatchCertificateState DeleteFailed { get { throw null; } }
        public static Azure.Compute.Batch.BatchCertificateState Deleting { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchCertificateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchCertificateState left, Azure.Compute.Batch.BatchCertificateState right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchCertificateState (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchCertificateState left, Azure.Compute.Batch.BatchCertificateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchCertificateStoreLocation : System.IEquatable<Azure.Compute.Batch.BatchCertificateStoreLocation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchCertificateStoreLocation(string value) { throw null; }
        public static Azure.Compute.Batch.BatchCertificateStoreLocation CurrentUser { get { throw null; } }
        public static Azure.Compute.Batch.BatchCertificateStoreLocation LocalMachine { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchCertificateStoreLocation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchCertificateStoreLocation left, Azure.Compute.Batch.BatchCertificateStoreLocation right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchCertificateStoreLocation (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchCertificateStoreLocation left, Azure.Compute.Batch.BatchCertificateStoreLocation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchCertificateVisibility : System.IEquatable<Azure.Compute.Batch.BatchCertificateVisibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchCertificateVisibility(string value) { throw null; }
        public static Azure.Compute.Batch.BatchCertificateVisibility RemoteUser { get { throw null; } }
        public static Azure.Compute.Batch.BatchCertificateVisibility StartTask { get { throw null; } }
        public static Azure.Compute.Batch.BatchCertificateVisibility Task { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchCertificateVisibility other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchCertificateVisibility left, Azure.Compute.Batch.BatchCertificateVisibility right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchCertificateVisibility (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchCertificateVisibility left, Azure.Compute.Batch.BatchCertificateVisibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchClient
    {
        protected BatchClient() { }
        public BatchClient(System.Uri endpoint, Azure.AzureNamedKeyCredential credential) { }
        public BatchClient(System.Uri endpoint, Azure.AzureNamedKeyCredential credential, Azure.Compute.Batch.BatchClientOptions options) { }
        public BatchClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public BatchClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Compute.Batch.BatchClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelCertificateDeletion(string thumbprintAlgorithm, string thumbprint, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelCertificateDeletionAsync(string thumbprintAlgorithm, string thumbprint, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateCertificate(Azure.Compute.Batch.BatchCertificate certificate, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateCertificate(Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateCertificateAsync(Azure.Compute.Batch.BatchCertificate certificate, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateCertificateAsync(Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateJob(Azure.Compute.Batch.BatchJobCreateContent job, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateJob(Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateJobAsync(Azure.Compute.Batch.BatchJobCreateContent job, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateJobAsync(Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateJobSchedule(Azure.Compute.Batch.BatchJobScheduleCreateContent jobSchedule, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateJobSchedule(Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateJobScheduleAsync(Azure.Compute.Batch.BatchJobScheduleCreateContent jobSchedule, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateJobScheduleAsync(Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateNodeUser(string poolId, string nodeId, Azure.Compute.Batch.BatchNodeUserCreateContent user, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateNodeUser(string poolId, string nodeId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateNodeUserAsync(string poolId, string nodeId, Azure.Compute.Batch.BatchNodeUserCreateContent user, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateNodeUserAsync(string poolId, string nodeId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreatePool(Azure.Compute.Batch.BatchPoolCreateContent pool, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreatePool(Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreatePoolAsync(Azure.Compute.Batch.BatchPoolCreateContent pool, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreatePoolAsync(Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateTask(string jobId, Azure.Compute.Batch.BatchTaskCreateContent task, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateTask(string jobId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateTaskAsync(string jobId, Azure.Compute.Batch.BatchTaskCreateContent task, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateTaskAsync(string jobId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Compute.Batch.BatchTaskAddCollectionResult> CreateTaskCollection(string jobId, Azure.Compute.Batch.BatchTaskGroup taskCollection, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateTaskCollection(string jobId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Compute.Batch.BatchTaskAddCollectionResult>> CreateTaskCollectionAsync(string jobId, Azure.Compute.Batch.BatchTaskGroup taskCollection, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateTaskCollectionAsync(string jobId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Compute.Batch.CreateTasksResult CreateTasks(string jobId, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.BatchTaskCreateContent> tasksToAdd, Azure.Compute.Batch.CreateTasksOptions createTasksOptions = null, System.TimeSpan? timeOutInSeconds = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Compute.Batch.CreateTasksResult> CreateTasksAsync(string jobId, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.BatchTaskCreateContent> tasksToAdd, Azure.Compute.Batch.CreateTasksOptions createTasksOptions = null, System.TimeSpan? timeOutInSeconds = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeallocateNode(string poolId, string nodeId, Azure.Compute.Batch.BatchNodeDeallocateContent parameters = null, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeallocateNode(string poolId, string nodeId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeallocateNodeAsync(string poolId, string nodeId, Azure.Compute.Batch.BatchNodeDeallocateContent parameters = null, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeallocateNodeAsync(string poolId, string nodeId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteCertificate(string thumbprintAlgorithm, string thumbprint, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteCertificateAsync(string thumbprintAlgorithm, string thumbprint, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteJob(string jobId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), bool? force = default(bool?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteJobAsync(string jobId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), bool? force = default(bool?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteJobSchedule(string jobScheduleId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), bool? force = default(bool?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteJobScheduleAsync(string jobScheduleId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), bool? force = default(bool?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteNodeFile(string poolId, string nodeId, string filePath, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), bool? recursive = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteNodeFileAsync(string poolId, string nodeId, string filePath, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), bool? recursive = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteNodeUser(string poolId, string nodeId, string userName, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteNodeUserAsync(string poolId, string nodeId, string userName, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeletePool(string poolId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeletePoolAsync(string poolId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTask(string jobId, string taskId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTaskAsync(string jobId, string taskId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTaskFile(string jobId, string taskId, string filePath, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), bool? recursive = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTaskFileAsync(string jobId, string taskId, string filePath, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), bool? recursive = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DisableJob(string jobId, Azure.Compute.Batch.BatchJobDisableContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DisableJob(string jobId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableJobAsync(string jobId, Azure.Compute.Batch.BatchJobDisableContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableJobAsync(string jobId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DisableJobSchedule(string jobScheduleId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableJobScheduleAsync(string jobScheduleId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DisableNodeScheduling(string poolId, string nodeId, Azure.Compute.Batch.BatchNodeDisableSchedulingContent parameters = null, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DisableNodeScheduling(string poolId, string nodeId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableNodeSchedulingAsync(string poolId, string nodeId, Azure.Compute.Batch.BatchNodeDisableSchedulingContent parameters = null, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableNodeSchedulingAsync(string poolId, string nodeId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DisablePoolAutoScale(string poolId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisablePoolAutoScaleAsync(string poolId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response EnableJob(string jobId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableJobAsync(string jobId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response EnableJobSchedule(string jobScheduleId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableJobScheduleAsync(string jobScheduleId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response EnableNodeScheduling(string poolId, string nodeId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableNodeSchedulingAsync(string poolId, string nodeId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response EnablePoolAutoScale(string poolId, Azure.Compute.Batch.BatchPoolEnableAutoScaleContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response EnablePoolAutoScale(string poolId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnablePoolAutoScaleAsync(string poolId, Azure.Compute.Batch.BatchPoolEnableAutoScaleContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnablePoolAutoScaleAsync(string poolId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Compute.Batch.AutoScaleRun> EvaluatePoolAutoScale(string poolId, Azure.Compute.Batch.BatchPoolEvaluateAutoScaleContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response EvaluatePoolAutoScale(string poolId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Compute.Batch.AutoScaleRun>> EvaluatePoolAutoScaleAsync(string poolId, Azure.Compute.Batch.BatchPoolEvaluateAutoScaleContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EvaluatePoolAutoScaleAsync(string poolId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetApplication(string applicationId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Compute.Batch.BatchApplication> GetApplication(string applicationId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetApplicationAsync(string applicationId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Compute.Batch.BatchApplication>> GetApplicationAsync(string applicationId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetApplications(int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Compute.Batch.BatchApplication> GetApplications(int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetApplicationsAsync(int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Compute.Batch.BatchApplication> GetApplicationsAsync(int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCertificate(string thumbprintAlgorithm, string thumbprint, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, System.Collections.Generic.IEnumerable<string> select, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Compute.Batch.BatchCertificate> GetCertificate(string thumbprintAlgorithm, string thumbprint, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCertificateAsync(string thumbprintAlgorithm, string thumbprint, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, System.Collections.Generic.IEnumerable<string> select, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Compute.Batch.BatchCertificate>> GetCertificateAsync(string thumbprintAlgorithm, string thumbprint, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetCertificates(int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, System.Collections.Generic.IEnumerable<string> select, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Compute.Batch.BatchCertificate> GetCertificates(int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetCertificatesAsync(int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, System.Collections.Generic.IEnumerable<string> select, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Compute.Batch.BatchCertificate> GetCertificatesAsync(int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetJob(string jobId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, System.Collections.Generic.IEnumerable<string> select, System.Collections.Generic.IEnumerable<string> expand, Azure.RequestConditions requestConditions, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Compute.Batch.BatchJob> GetJob(string jobId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> select = null, System.Collections.Generic.IEnumerable<string> expand = null, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetJobAsync(string jobId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, System.Collections.Generic.IEnumerable<string> select, System.Collections.Generic.IEnumerable<string> expand, Azure.RequestConditions requestConditions, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Compute.Batch.BatchJob>> GetJobAsync(string jobId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> select = null, System.Collections.Generic.IEnumerable<string> expand = null, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetJobPreparationAndReleaseTaskStatuses(string jobId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, System.Collections.Generic.IEnumerable<string> select, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Compute.Batch.BatchJobPreparationAndReleaseTaskStatus> GetJobPreparationAndReleaseTaskStatuses(string jobId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetJobPreparationAndReleaseTaskStatusesAsync(string jobId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, System.Collections.Generic.IEnumerable<string> select, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Compute.Batch.BatchJobPreparationAndReleaseTaskStatus> GetJobPreparationAndReleaseTaskStatusesAsync(string jobId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetJobs(int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, System.Collections.Generic.IEnumerable<string> select, System.Collections.Generic.IEnumerable<string> expand, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Compute.Batch.BatchJob> GetJobs(int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, System.Collections.Generic.IEnumerable<string> select = null, System.Collections.Generic.IEnumerable<string> expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetJobsAsync(int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, System.Collections.Generic.IEnumerable<string> select, System.Collections.Generic.IEnumerable<string> expand, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Compute.Batch.BatchJob> GetJobsAsync(int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, System.Collections.Generic.IEnumerable<string> select = null, System.Collections.Generic.IEnumerable<string> expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetJobSchedule(string jobScheduleId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, System.Collections.Generic.IEnumerable<string> select, System.Collections.Generic.IEnumerable<string> expand, Azure.RequestConditions requestConditions, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Compute.Batch.BatchJobSchedule> GetJobSchedule(string jobScheduleId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> select = null, System.Collections.Generic.IEnumerable<string> expand = null, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetJobScheduleAsync(string jobScheduleId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, System.Collections.Generic.IEnumerable<string> select, System.Collections.Generic.IEnumerable<string> expand, Azure.RequestConditions requestConditions, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Compute.Batch.BatchJobSchedule>> GetJobScheduleAsync(string jobScheduleId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> select = null, System.Collections.Generic.IEnumerable<string> expand = null, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetJobSchedules(int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, System.Collections.Generic.IEnumerable<string> select, System.Collections.Generic.IEnumerable<string> expand, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Compute.Batch.BatchJobSchedule> GetJobSchedules(int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, System.Collections.Generic.IEnumerable<string> select = null, System.Collections.Generic.IEnumerable<string> expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetJobSchedulesAsync(int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, System.Collections.Generic.IEnumerable<string> select, System.Collections.Generic.IEnumerable<string> expand, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Compute.Batch.BatchJobSchedule> GetJobSchedulesAsync(int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, System.Collections.Generic.IEnumerable<string> select = null, System.Collections.Generic.IEnumerable<string> expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetJobsFromSchedules(string jobScheduleId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, System.Collections.Generic.IEnumerable<string> select, System.Collections.Generic.IEnumerable<string> expand, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Compute.Batch.BatchJob> GetJobsFromSchedules(string jobScheduleId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, System.Collections.Generic.IEnumerable<string> select = null, System.Collections.Generic.IEnumerable<string> expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetJobsFromSchedulesAsync(string jobScheduleId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, System.Collections.Generic.IEnumerable<string> select, System.Collections.Generic.IEnumerable<string> expand, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Compute.Batch.BatchJob> GetJobsFromSchedulesAsync(string jobScheduleId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, System.Collections.Generic.IEnumerable<string> select = null, System.Collections.Generic.IEnumerable<string> expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetJobTaskCounts(string jobId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Compute.Batch.BatchTaskCountsResult> GetJobTaskCounts(string jobId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetJobTaskCountsAsync(string jobId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Compute.Batch.BatchTaskCountsResult>> GetJobTaskCountsAsync(string jobId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetNode(string poolId, string nodeId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, System.Collections.Generic.IEnumerable<string> select, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Compute.Batch.BatchNode> GetNode(string poolId, string nodeId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetNodeAsync(string poolId, string nodeId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, System.Collections.Generic.IEnumerable<string> select, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Compute.Batch.BatchNode>> GetNodeAsync(string poolId, string nodeId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetNodeExtension(string poolId, string nodeId, string extensionName, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, System.Collections.Generic.IEnumerable<string> select, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Compute.Batch.BatchNodeVMExtension> GetNodeExtension(string poolId, string nodeId, string extensionName, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetNodeExtensionAsync(string poolId, string nodeId, string extensionName, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, System.Collections.Generic.IEnumerable<string> select, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Compute.Batch.BatchNodeVMExtension>> GetNodeExtensionAsync(string poolId, string nodeId, string extensionName, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetNodeExtensions(string poolId, string nodeId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, System.Collections.Generic.IEnumerable<string> select, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Compute.Batch.BatchNodeVMExtension> GetNodeExtensions(string poolId, string nodeId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetNodeExtensionsAsync(string poolId, string nodeId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, System.Collections.Generic.IEnumerable<string> select, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Compute.Batch.BatchNodeVMExtension> GetNodeExtensionsAsync(string poolId, string nodeId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetNodeFile(string poolId, string nodeId, string filePath, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, string ocpRange, Azure.RequestConditions requestConditions, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetNodeFile(string poolId, string nodeId, string filePath, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), string ocpRange = null, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetNodeFileAsync(string poolId, string nodeId, string filePath, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, string ocpRange, Azure.RequestConditions requestConditions, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetNodeFileAsync(string poolId, string nodeId, string filePath, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), string ocpRange = null, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Compute.Batch.BatchFileProperties> GetNodeFileProperties(string poolId, string nodeId, string filePath, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Compute.Batch.BatchFileProperties>> GetNodeFilePropertiesAsync(string poolId, string nodeId, string filePath, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetNodeFiles(string poolId, string nodeId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, bool? recursive, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Compute.Batch.BatchNodeFile> GetNodeFiles(string poolId, string nodeId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, bool? recursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetNodeFilesAsync(string poolId, string nodeId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, bool? recursive, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Compute.Batch.BatchNodeFile> GetNodeFilesAsync(string poolId, string nodeId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, bool? recursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetNodeRemoteLoginSettings(string poolId, string nodeId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Compute.Batch.BatchNodeRemoteLoginSettings> GetNodeRemoteLoginSettings(string poolId, string nodeId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetNodeRemoteLoginSettingsAsync(string poolId, string nodeId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Compute.Batch.BatchNodeRemoteLoginSettings>> GetNodeRemoteLoginSettingsAsync(string poolId, string nodeId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetNodes(string poolId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, System.Collections.Generic.IEnumerable<string> select, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Compute.Batch.BatchNode> GetNodes(string poolId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetNodesAsync(string poolId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, System.Collections.Generic.IEnumerable<string> select, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Compute.Batch.BatchNode> GetNodesAsync(string poolId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPool(string poolId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, System.Collections.Generic.IEnumerable<string> select, System.Collections.Generic.IEnumerable<string> expand, Azure.RequestConditions requestConditions, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Compute.Batch.BatchPool> GetPool(string poolId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> select = null, System.Collections.Generic.IEnumerable<string> expand = null, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPoolAsync(string poolId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, System.Collections.Generic.IEnumerable<string> select, System.Collections.Generic.IEnumerable<string> expand, Azure.RequestConditions requestConditions, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Compute.Batch.BatchPool>> GetPoolAsync(string poolId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> select = null, System.Collections.Generic.IEnumerable<string> expand = null, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetPoolNodeCounts(int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Compute.Batch.BatchPoolNodeCounts> GetPoolNodeCounts(int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetPoolNodeCountsAsync(int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Compute.Batch.BatchPoolNodeCounts> GetPoolNodeCountsAsync(int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetPools(int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, System.Collections.Generic.IEnumerable<string> select, System.Collections.Generic.IEnumerable<string> expand, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Compute.Batch.BatchPool> GetPools(int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, System.Collections.Generic.IEnumerable<string> select = null, System.Collections.Generic.IEnumerable<string> expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetPoolsAsync(int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, System.Collections.Generic.IEnumerable<string> select, System.Collections.Generic.IEnumerable<string> expand, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Compute.Batch.BatchPool> GetPoolsAsync(int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, System.Collections.Generic.IEnumerable<string> select = null, System.Collections.Generic.IEnumerable<string> expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetPoolUsageMetrics(int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, System.DateTimeOffset? starttime, System.DateTimeOffset? endtime, string filter, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Compute.Batch.BatchPoolUsageMetrics> GetPoolUsageMetrics(int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), System.DateTimeOffset? starttime = default(System.DateTimeOffset?), System.DateTimeOffset? endtime = default(System.DateTimeOffset?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetPoolUsageMetricsAsync(int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, System.DateTimeOffset? starttime, System.DateTimeOffset? endtime, string filter, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Compute.Batch.BatchPoolUsageMetrics> GetPoolUsageMetricsAsync(int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), System.DateTimeOffset? starttime = default(System.DateTimeOffset?), System.DateTimeOffset? endtime = default(System.DateTimeOffset?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSubTasks(string jobId, string taskId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, System.Collections.Generic.IEnumerable<string> select, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Compute.Batch.BatchSubtask> GetSubTasks(string jobId, string taskId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSubTasksAsync(string jobId, string taskId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, System.Collections.Generic.IEnumerable<string> select, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Compute.Batch.BatchSubtask> GetSubTasksAsync(string jobId, string taskId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSupportedImages(int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Compute.Batch.BatchSupportedImage> GetSupportedImages(int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSupportedImagesAsync(int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Compute.Batch.BatchSupportedImage> GetSupportedImagesAsync(int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTask(string jobId, string taskId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, System.Collections.Generic.IEnumerable<string> select, System.Collections.Generic.IEnumerable<string> expand, Azure.RequestConditions requestConditions, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Compute.Batch.BatchTask> GetTask(string jobId, string taskId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> select = null, System.Collections.Generic.IEnumerable<string> expand = null, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTaskAsync(string jobId, string taskId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, System.Collections.Generic.IEnumerable<string> select, System.Collections.Generic.IEnumerable<string> expand, Azure.RequestConditions requestConditions, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Compute.Batch.BatchTask>> GetTaskAsync(string jobId, string taskId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> select = null, System.Collections.Generic.IEnumerable<string> expand = null, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTaskFile(string jobId, string taskId, string filePath, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, string ocpRange, Azure.RequestConditions requestConditions, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetTaskFile(string jobId, string taskId, string filePath, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), string ocpRange = null, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTaskFileAsync(string jobId, string taskId, string filePath, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, string ocpRange, Azure.RequestConditions requestConditions, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetTaskFileAsync(string jobId, string taskId, string filePath, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), string ocpRange = null, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Compute.Batch.BatchFileProperties> GetTaskFileProperties(string jobId, string taskId, string filePath, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Compute.Batch.BatchFileProperties>> GetTaskFilePropertiesAsync(string jobId, string taskId, string filePath, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTaskFiles(string jobId, string taskId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, bool? recursive, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Compute.Batch.BatchNodeFile> GetTaskFiles(string jobId, string taskId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, bool? recursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTaskFilesAsync(string jobId, string taskId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, bool? recursive, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Compute.Batch.BatchNodeFile> GetTaskFilesAsync(string jobId, string taskId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, bool? recursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTasks(string jobId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, System.Collections.Generic.IEnumerable<string> select, System.Collections.Generic.IEnumerable<string> expand, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Compute.Batch.BatchTask> GetTasks(string jobId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, System.Collections.Generic.IEnumerable<string> select = null, System.Collections.Generic.IEnumerable<string> expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTasksAsync(string jobId, int? timeOutInSeconds, System.DateTimeOffset? ocpdate, int? maxresults, string filter, System.Collections.Generic.IEnumerable<string> select, System.Collections.Generic.IEnumerable<string> expand, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Compute.Batch.BatchTask> GetTasksAsync(string jobId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), int? maxresults = default(int?), string filter = null, System.Collections.Generic.IEnumerable<string> select = null, System.Collections.Generic.IEnumerable<string> expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> JobScheduleExists(string jobScheduleId, int? timeOut = default(int?), System.DateTimeOffset? ocpDate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> JobScheduleExistsAsync(string jobScheduleId, int? timeOut = default(int?), System.DateTimeOffset? ocpDate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<bool> PoolExists(string poolId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> PoolExistsAsync(string poolId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response ReactivateTask(string jobId, string taskId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReactivateTaskAsync(string jobId, string taskId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RebootNode(string poolId, string nodeId, Azure.Compute.Batch.BatchNodeRebootContent parameters = null, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RebootNode(string poolId, string nodeId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RebootNodeAsync(string poolId, string nodeId, Azure.Compute.Batch.BatchNodeRebootContent parameters = null, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RebootNodeAsync(string poolId, string nodeId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response ReimageNode(string poolId, string nodeId, Azure.Compute.Batch.BatchNodeReimageContent parameters = null, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReimageNode(string poolId, string nodeId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReimageNodeAsync(string poolId, string nodeId, Azure.Compute.Batch.BatchNodeReimageContent parameters = null, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReimageNodeAsync(string poolId, string nodeId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RemoveNodes(string poolId, Azure.Compute.Batch.BatchNodeRemoveContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveNodes(string poolId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveNodesAsync(string poolId, Azure.Compute.Batch.BatchNodeRemoveContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveNodesAsync(string poolId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response ReplaceJob(string jobId, Azure.Compute.Batch.BatchJob job, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReplaceJob(string jobId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplaceJobAsync(string jobId, Azure.Compute.Batch.BatchJob job, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplaceJobAsync(string jobId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response ReplaceJobSchedule(string jobScheduleId, Azure.Compute.Batch.BatchJobSchedule jobSchedule, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReplaceJobSchedule(string jobScheduleId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplaceJobScheduleAsync(string jobScheduleId, Azure.Compute.Batch.BatchJobSchedule jobSchedule, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplaceJobScheduleAsync(string jobScheduleId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response ReplaceNodeUser(string poolId, string nodeId, string userName, Azure.Compute.Batch.BatchNodeUserUpdateContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReplaceNodeUser(string poolId, string nodeId, string userName, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplaceNodeUserAsync(string poolId, string nodeId, string userName, Azure.Compute.Batch.BatchNodeUserUpdateContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplaceNodeUserAsync(string poolId, string nodeId, string userName, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response ReplacePoolProperties(string poolId, Azure.Compute.Batch.BatchPoolReplaceContent pool, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReplacePoolProperties(string poolId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplacePoolPropertiesAsync(string poolId, Azure.Compute.Batch.BatchPoolReplaceContent pool, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplacePoolPropertiesAsync(string poolId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response ReplaceTask(string jobId, string taskId, Azure.Compute.Batch.BatchTask task, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReplaceTask(string jobId, string taskId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplaceTaskAsync(string jobId, string taskId, Azure.Compute.Batch.BatchTask task, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReplaceTaskAsync(string jobId, string taskId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response ResizePool(string poolId, Azure.Compute.Batch.BatchPoolResizeContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResizePool(string poolId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResizePoolAsync(string poolId, Azure.Compute.Batch.BatchPoolResizeContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResizePoolAsync(string poolId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response StartNode(string poolId, string nodeId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartNodeAsync(string poolId, string nodeId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response StopPoolResize(string poolId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopPoolResizeAsync(string poolId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response TerminateJob(string jobId, Azure.Compute.Batch.BatchJobTerminateContent parameters = null, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), bool? force = default(bool?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response TerminateJob(string jobId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), bool? force = default(bool?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TerminateJobAsync(string jobId, Azure.Compute.Batch.BatchJobTerminateContent parameters = null, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), bool? force = default(bool?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TerminateJobAsync(string jobId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), bool? force = default(bool?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response TerminateJobSchedule(string jobScheduleId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), bool? force = default(bool?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TerminateJobScheduleAsync(string jobScheduleId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), bool? force = default(bool?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response TerminateTask(string jobId, string taskId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TerminateTaskAsync(string jobId, string taskId, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateJob(string jobId, Azure.Compute.Batch.BatchJobUpdateContent job, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateJob(string jobId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateJobAsync(string jobId, Azure.Compute.Batch.BatchJobUpdateContent job, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateJobAsync(string jobId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateJobSchedule(string jobScheduleId, Azure.Compute.Batch.BatchJobScheduleUpdateContent jobSchedule, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateJobSchedule(string jobScheduleId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateJobScheduleAsync(string jobScheduleId, Azure.Compute.Batch.BatchJobScheduleUpdateContent jobSchedule, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateJobScheduleAsync(string jobScheduleId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdatePool(string poolId, Azure.Compute.Batch.BatchPoolUpdateContent pool, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdatePool(string poolId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdatePoolAsync(string poolId, Azure.Compute.Batch.BatchPoolUpdateContent pool, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdatePoolAsync(string poolId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Compute.Batch.UploadBatchServiceLogsResult> UploadNodeLogs(string poolId, string nodeId, Azure.Compute.Batch.UploadBatchServiceLogsContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UploadNodeLogs(string poolId, string nodeId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Compute.Batch.UploadBatchServiceLogsResult>> UploadNodeLogsAsync(string poolId, string nodeId, Azure.Compute.Batch.UploadBatchServiceLogsContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadNodeLogsAsync(string poolId, string nodeId, Azure.Core.RequestContent content, int? timeOutInSeconds = default(int?), System.DateTimeOffset? ocpdate = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
    }
    public partial class BatchClientException : Azure.Compute.Batch.Custom.BatchException
    {
        internal BatchClientException() : base (default(Azure.Compute.Batch.Custom.RequestInformation), default(string), default(System.Exception)) { }
    }
    public partial class BatchClientOptions : Azure.Core.ClientOptions
    {
        public BatchClientOptions(Azure.Compute.Batch.BatchClientOptions.ServiceVersion version = Azure.Compute.Batch.BatchClientOptions.ServiceVersion.V2024_07_01_20_0) { }
        public enum ServiceVersion
        {
            V2024_07_01_20_0 = 1,
        }
    }
    public partial class BatchError : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchError>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchError>
    {
        internal BatchError() { }
        public string Code { get { throw null; } }
        public Azure.Compute.Batch.BatchErrorMessage Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.BatchErrorDetail> Values { get { throw null; } }
        public static Azure.Compute.Batch.BatchError FromException(Azure.RequestFailedException e) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchError System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchError System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class BatchErrorCodeStrings
    {
        public const string AccountIsDisabled = "AccountIsDisabled";
        public const string ActiveJobAndScheduleQuotaReached = "ActiveJobAndScheduleQuotaReached";
        public const string AddTaskCollectionTerminated = "Addition of a task failed with unexpected status code.Details: {0}";
        public const string ApplicationNotFound = "ApplicationNotFound";
        public const string AuthenticationFailed = "AuthenticationFailed";
        public const string AutoScaleFormulaTooLong = "AutoScaleFormulaTooLong";
        public const string AutoScaleTooManyRequestsToEnable = "TooManyEnableAutoScaleRequests";
        public const string AutoScalingFormulaSyntaxError = "AutoScalingFormulaSyntaxError";
        public const string CanOnlyBeRunOnceFailure = "{0} can only be run once.";
        public const string CertificateBeingDeleted = "CertificateBeingDeleted";
        public const string CertificateExists = "CertificateExists";
        public const string CertificateNotFound = "CertificateNotFound";
        public const string CertificateStateActive = "CertificateStateActive";
        public const string CertificateStateDeleteFailed = "CertificateDeleteFailed";
        public const string ConditionNotMet = "ConditionNotMet";
        public const string EmptyMetadataKey = "EmptyMetadataKey";
        public const string FileNotFound = "FileNotFound";
        public const string HostInformationNotPresent = "HostInformationNotPresent";
        public const string InsufficientAccountPermissions = "InsufficientAccountPermissions";
        public const string InternalError = "InternalError";
        public const string InvalidApplicationPackageReferences = "InvalidApplicationPackageReferences";
        public const string InvalidAuthenticationInfo = "InvalidAuthenticationInfo";
        public const string InvalidAutoScalingSettings = "InvalidAutoScalingSettings";
        public const string InvalidCertificateReferences = "InvalidCertificateReferences";
        public const string InvalidConstraintValue = "InvalidConstraintValue";
        public const string InvalidHeaderValue = "InvalidHeaderValue";
        public const string InvalidHttpVerb = "InvalidHttpVerb";
        public const string InvalidInput = "InvalidInput";
        public const string InvalidMetadata = "InvalidMetadata";
        public const string InvalidPropertyValue = "InvalidPropertyValue";
        public const string InvalidQueryParameterValue = "InvalidQueryParameterValue";
        public const string InvalidRange = "InvalidRange";
        public const string InvalidRequestBody = "InvalidRequestBody";
        public const string InvalidRestAPIForAccountSetting = "InvalidRestAPIForAccountSetting";
        public const string InvalidUri = "InvalidUri";
        public const string IOError = "IOError";
        public const string JobBeingDeleted = "JobBeingDeleted";
        public const string JobBeingTerminated = "JobBeingTerminated";
        public const string JobCompleted = "JobCompleted";
        public const string JobDisabled = "JobDisabled";
        public const string JobExists = "JobExists";
        public const string JobNotActive = "JobNotActive";
        public const string JobNotFound = "JobNotFound";
        public const string JobPreparationTaskNotRunOnNode = "JobPreparationTaskNotRunOnNode";
        public const string JobPreparationTaskNotSpecified = "JobPreparationTaskNotSpecified";
        public const string JobReleaseTaskNotRunOnNode = "JobReleaseTaskNotRunOnNode";
        public const string JobReleaseTaskNotSpecified = "JobReleaseTaskNotSpecified";
        public const string JobScheduleBeingDeleted = "JobScheduleBeingDeleted";
        public const string JobScheduleBeingTerminated = "JobScheduleBeingTerminated";
        public const string JobScheduleCompleted = "JobScheduleCompleted";
        public const string JobScheduleDisabled = "JobScheduleDisabled";
        public const string JobScheduleExists = "JobScheduleExists";
        public const string JobScheduleNotFound = "JobScheduleNotFound";
        public const string JobScheduleWithSameIdExists = "JobScheduleWithSameIdExists";
        public const string JobWithSameIdExists = "JobWithSameIdExists";
        public const string MetadataTooLarge = "MetadataTooLarge";
        public const string MissingContentLengthHeader = "MissingContentLengthHeader";
        public const string MissingRequiredHeader = "MissingRequiredHeader";
        public const string MissingRequiredProperty = "MissingRequiredProperty";
        public const string MissingRequiredQueryParameter = "MissingRequiredQueryParameter";
        public const string MultipleConditionHeadersNotSupported = "MultipleConditionHeadersNotSupported";
        public const string MultipleParallelRequestsHitUnexpectedErrors = "One or more requests to the Azure Batch service failed.";
        public const string NodeAlreadyInTargetSchedulingState = "NodeAlreadyInTargetSchedulingState";
        public const string NodeBeingCreated = "NodeBeingCreated";
        public const string NodeBeingRebooted = "NodeBeingRebooted";
        public const string NodeBeingReimaged = "NodeBeingReimaged";
        public const string NodeBeingStarted = "NodeBeingStarted";
        public const string NodeCountsMismatch = "NodeCountsMismatch";
        public const string NodeNotFound = "NodeNotFound";
        public const string NodeStateUnusable = "NodeStateUnusable";
        public const string NodeUserExists = "NodeUserExists";
        public const string NodeUserNotFound = "NodeUserNotFound";
        public const string NotImplemented = "NotImplemented";
        public const string OperationInvalidForCurrentState = "OperationInvalidForCurrentState";
        public const string OperationTimedOut = "OperationTimedOut";
        public const string OSVersionDisabled = "OSVersionDisabled";
        public const string OSVersionExpired = "OSVersionExpired";
        public const string OSVersionNotFound = "OSVersionNotFound";
        public const string OutOfRangeInput = "OutOfRangeInput";
        public const string OutOfRangePriority = "OutOfRangePriority";
        public const string OutOfRangeQueryParameterValue = "OutOfRangeQueryParameterValue";
        public const string PathNotFound = "PathNotFound";
        public const string PoolBeingCreated = "PoolBeingCreated";
        public const string PoolBeingDeleted = "PoolBeingDeleted";
        public const string PoolBeingResized = "PoolBeingResized";
        public const string PoolExists = "PoolExists";
        public const string PoolNotEligibleForOSVersionUpgrade = "PoolNotEligibleForOSVersionUpgrade";
        public const string PoolNotFound = "PoolNotFound";
        public const string PoolQuotaReached = "PoolQuotaReached";
        public const string PoolVersionEqualsUpgradeVersion = "PoolVersionEqualsUpgradeVersion";
        public const string RequestBodyTooLarge = "RequestBodyTooLarge";
        public const string RequestUrlFailedToParse = "RequestUrlFailedToParse";
        public const string ResourceAlreadyExists = "ResourceAlreadyExists";
        public const string ResourceNotFound = "ResourceNotFound";
        public const string ResourceTypeMismatch = "ResourceTypeMismatch";
        public const string ServerBusy = "ServerBusy";
        public const string StorageAccountNotFound = "StorageAccountNotFound";
        public const string TaskCompleted = "TaskCompleted";
        public const string TaskDependenciesNotSpecifiedOnJob = "TaskDependenciesNotSpecifiedOnJob";
        public const string TaskDependencyListTooLong = "TaskDependencyListTooLong";
        public const string TaskDependencyRangesTooLong = "TaskDependencyRangesTooLong";
        public const string TaskExists = "TaskExists";
        public const string TaskFilesCleanedup = "TaskFilesCleanedup";
        public const string TaskFilesUnavailable = "TaskFilesUnavailable";
        public const string TaskIdSameAsJobPreparationTask = "TaskIdSameAsJobPreparationTask";
        public const string TaskIdSameAsJobReleaseTask = "TaskIdSameAsJobReleaseTask";
        public const string TaskNotFound = "TaskNotFound";
        public const string TooManyRequests = "TooManyRequests";
        public const string UnsupportedConstraint = "UnsupportedConstraint";
        public const string UnsupportedHeader = "UnsupportedHeader";
        public const string UnsupportedHttpVerb = "UnsupportedHttpVerb";
        public const string UnsupportedHttpVersion = "UnsupportedHttpVersion";
        public const string UnsupportedProperty = "UnsupportedProperty";
        public const string UnsupportedQueryParameter = "UnsupportedQueryParameter";
        public const string UnsupportedRequestVersion = "UnsupportedRequestVersion";
    }
    public partial class BatchErrorDetail : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchErrorDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchErrorDetail>
    {
        internal BatchErrorDetail() { }
        public string Key { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchErrorDetail System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchErrorDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchErrorDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchErrorDetail System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchErrorDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchErrorDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchErrorDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchErrorMessage : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchErrorMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchErrorMessage>
    {
        internal BatchErrorMessage() { }
        public string Lang { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchErrorMessage System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchErrorMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchErrorMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchErrorMessage System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchErrorMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchErrorMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchErrorMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchFileProperties
    {
        internal BatchFileProperties() { }
        public System.DateTime CreationTime { get { throw null; } }
        public string FileUrl { get { throw null; } }
        public bool IsDirectory { get { throw null; } }
        public string Mode { get { throw null; } }
    }
    public partial class BatchJob : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJob>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJob>
    {
        public BatchJob(Azure.Compute.Batch.BatchPoolInfo poolInfo) { }
        public bool? AllowTaskPreemption { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.EnvironmentSetting> CommonEnvironmentSettings { get { throw null; } }
        public Azure.Compute.Batch.BatchJobConstraints Constraints { get { throw null; } set { } }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string ETag { get { throw null; } }
        public Azure.Compute.Batch.BatchJobExecutionInfo ExecutionInfo { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Compute.Batch.BatchJobManagerTask JobManagerTask { get { throw null; } }
        public Azure.Compute.Batch.BatchJobPreparationTask JobPreparationTask { get { throw null; } }
        public Azure.Compute.Batch.BatchJobReleaseTask JobReleaseTask { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public int? MaxParallelTasks { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.MetadataItem> Metadata { get { throw null; } }
        public Azure.Compute.Batch.BatchJobNetworkConfiguration NetworkConfiguration { get { throw null; } }
        public Azure.Compute.Batch.OnAllBatchTasksComplete? OnAllTasksComplete { get { throw null; } set { } }
        public Azure.Compute.Batch.OnBatchTaskFailure? OnTaskFailure { get { throw null; } }
        public Azure.Compute.Batch.BatchPoolInfo PoolInfo { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchJobState? PreviousState { get { throw null; } }
        public System.DateTimeOffset? PreviousStateTransitionTime { get { throw null; } }
        public int? Priority { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchJobState? State { get { throw null; } }
        public System.DateTimeOffset? StateTransitionTime { get { throw null; } }
        public Azure.Compute.Batch.BatchJobStatistics Stats { get { throw null; } }
        public string Url { get { throw null; } }
        public bool? UsesTaskDependencies { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJob System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJob System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchJobAction : System.IEquatable<Azure.Compute.Batch.BatchJobAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchJobAction(string value) { throw null; }
        public static Azure.Compute.Batch.BatchJobAction Disable { get { throw null; } }
        public static Azure.Compute.Batch.BatchJobAction None { get { throw null; } }
        public static Azure.Compute.Batch.BatchJobAction Terminate { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchJobAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchJobAction left, Azure.Compute.Batch.BatchJobAction right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchJobAction (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchJobAction left, Azure.Compute.Batch.BatchJobAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchJobConstraints : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobConstraints>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobConstraints>
    {
        public BatchJobConstraints() { }
        public int? MaxTaskRetryCount { get { throw null; } set { } }
        public System.TimeSpan? MaxWallClockTime { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobConstraints System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobConstraints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobConstraints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobConstraints System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobConstraints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobConstraints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobConstraints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchJobCreateContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobCreateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobCreateContent>
    {
        public BatchJobCreateContent(string id, Azure.Compute.Batch.BatchPoolInfo poolInfo) { }
        public bool? AllowTaskPreemption { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.EnvironmentSetting> CommonEnvironmentSettings { get { throw null; } }
        public Azure.Compute.Batch.BatchJobConstraints Constraints { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public Azure.Compute.Batch.BatchJobManagerTask JobManagerTask { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchJobPreparationTask JobPreparationTask { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchJobReleaseTask JobReleaseTask { get { throw null; } set { } }
        public int? MaxParallelTasks { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.MetadataItem> Metadata { get { throw null; } }
        public Azure.Compute.Batch.BatchJobNetworkConfiguration NetworkConfiguration { get { throw null; } set { } }
        public Azure.Compute.Batch.OnAllBatchTasksComplete? OnAllTasksComplete { get { throw null; } set { } }
        public Azure.Compute.Batch.OnBatchTaskFailure? OnTaskFailure { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchPoolInfo PoolInfo { get { throw null; } }
        public int? Priority { get { throw null; } set { } }
        public bool? UsesTaskDependencies { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobCreateContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobCreateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobCreateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobCreateContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobCreateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobCreateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobCreateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchJobDisableContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobDisableContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobDisableContent>
    {
        public BatchJobDisableContent(Azure.Compute.Batch.DisableBatchJobOption disableTasks) { }
        public Azure.Compute.Batch.DisableBatchJobOption DisableTasks { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobDisableContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobDisableContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobDisableContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobDisableContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobDisableContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobDisableContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobDisableContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchJobExecutionInfo : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobExecutionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobExecutionInfo>
    {
        internal BatchJobExecutionInfo() { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public string PoolId { get { throw null; } }
        public Azure.Compute.Batch.BatchJobSchedulingError SchedulingError { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public string TerminationReason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobExecutionInfo System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobExecutionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobExecutionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobExecutionInfo System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobExecutionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobExecutionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobExecutionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchJobManagerTask : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobManagerTask>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobManagerTask>
    {
        public BatchJobManagerTask(string id, string commandLine) { }
        public bool? AllowLowPriorityNode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.BatchApplicationPackageReference> ApplicationPackageReferences { get { throw null; } }
        public Azure.Compute.Batch.AuthenticationTokenSettings AuthenticationTokenSettings { get { throw null; } set { } }
        public string CommandLine { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchTaskConstraints Constraints { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchTaskContainerSettings ContainerSettings { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.EnvironmentSetting> EnvironmentSettings { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public bool? KillJobOnCompletion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.OutputFile> OutputFiles { get { throw null; } }
        public int? RequiredSlots { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.ResourceFile> ResourceFiles { get { throw null; } }
        public bool? RunExclusive { get { throw null; } set { } }
        public Azure.Compute.Batch.UserIdentity UserIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobManagerTask System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobManagerTask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobManagerTask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobManagerTask System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobManagerTask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobManagerTask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobManagerTask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchJobNetworkConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobNetworkConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobNetworkConfiguration>
    {
        public BatchJobNetworkConfiguration(string subnetId, bool skipWithdrawFromVNet) { }
        public bool SkipWithdrawFromVNet { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobNetworkConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobNetworkConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobNetworkConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobNetworkConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobNetworkConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobNetworkConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobNetworkConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchJobPreparationAndReleaseTaskStatus : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobPreparationAndReleaseTaskStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobPreparationAndReleaseTaskStatus>
    {
        internal BatchJobPreparationAndReleaseTaskStatus() { }
        public Azure.Compute.Batch.BatchJobPreparationTaskExecutionInfo JobPreparationTaskExecutionInfo { get { throw null; } }
        public Azure.Compute.Batch.BatchJobReleaseTaskExecutionInfo JobReleaseTaskExecutionInfo { get { throw null; } }
        public string NodeId { get { throw null; } }
        public string NodeUrl { get { throw null; } }
        public string PoolId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobPreparationAndReleaseTaskStatus System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobPreparationAndReleaseTaskStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobPreparationAndReleaseTaskStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobPreparationAndReleaseTaskStatus System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobPreparationAndReleaseTaskStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobPreparationAndReleaseTaskStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobPreparationAndReleaseTaskStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchJobPreparationTask : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobPreparationTask>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobPreparationTask>
    {
        public BatchJobPreparationTask(string commandLine) { }
        public string CommandLine { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchTaskConstraints Constraints { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchTaskContainerSettings ContainerSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.EnvironmentSetting> EnvironmentSettings { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public bool? RerunOnNodeRebootAfterSuccess { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.ResourceFile> ResourceFiles { get { throw null; } }
        public Azure.Compute.Batch.UserIdentity UserIdentity { get { throw null; } set { } }
        public bool? WaitForSuccess { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobPreparationTask System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobPreparationTask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobPreparationTask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobPreparationTask System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobPreparationTask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobPreparationTask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobPreparationTask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchJobPreparationTaskExecutionInfo : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobPreparationTaskExecutionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobPreparationTaskExecutionInfo>
    {
        internal BatchJobPreparationTaskExecutionInfo() { }
        public Azure.Compute.Batch.BatchTaskContainerExecutionInfo ContainerInfo { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public int? ExitCode { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskFailureInfo FailureInfo { get { throw null; } }
        public System.DateTimeOffset? LastRetryTime { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskExecutionResult? Result { get { throw null; } }
        public int RetryCount { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public Azure.Compute.Batch.BatchJobPreparationTaskState State { get { throw null; } }
        public string TaskRootDirectory { get { throw null; } }
        public string TaskRootDirectoryUrl { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobPreparationTaskExecutionInfo System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobPreparationTaskExecutionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobPreparationTaskExecutionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobPreparationTaskExecutionInfo System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobPreparationTaskExecutionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobPreparationTaskExecutionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobPreparationTaskExecutionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchJobPreparationTaskState : System.IEquatable<Azure.Compute.Batch.BatchJobPreparationTaskState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchJobPreparationTaskState(string value) { throw null; }
        public static Azure.Compute.Batch.BatchJobPreparationTaskState Completed { get { throw null; } }
        public static Azure.Compute.Batch.BatchJobPreparationTaskState Running { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchJobPreparationTaskState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchJobPreparationTaskState left, Azure.Compute.Batch.BatchJobPreparationTaskState right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchJobPreparationTaskState (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchJobPreparationTaskState left, Azure.Compute.Batch.BatchJobPreparationTaskState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchJobReleaseTask : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobReleaseTask>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobReleaseTask>
    {
        public BatchJobReleaseTask(string commandLine) { }
        public string CommandLine { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchTaskContainerSettings ContainerSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.EnvironmentSetting> EnvironmentSettings { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public System.TimeSpan? MaxWallClockTime { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.ResourceFile> ResourceFiles { get { throw null; } }
        public System.TimeSpan? RetentionTime { get { throw null; } set { } }
        public Azure.Compute.Batch.UserIdentity UserIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobReleaseTask System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobReleaseTask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobReleaseTask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobReleaseTask System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobReleaseTask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobReleaseTask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobReleaseTask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchJobReleaseTaskExecutionInfo : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobReleaseTaskExecutionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobReleaseTaskExecutionInfo>
    {
        internal BatchJobReleaseTaskExecutionInfo() { }
        public Azure.Compute.Batch.BatchTaskContainerExecutionInfo ContainerInfo { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public int? ExitCode { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskFailureInfo FailureInfo { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskExecutionResult? Result { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public Azure.Compute.Batch.BatchJobReleaseTaskState State { get { throw null; } }
        public string TaskRootDirectory { get { throw null; } }
        public string TaskRootDirectoryUrl { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobReleaseTaskExecutionInfo System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobReleaseTaskExecutionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobReleaseTaskExecutionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobReleaseTaskExecutionInfo System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobReleaseTaskExecutionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobReleaseTaskExecutionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobReleaseTaskExecutionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchJobReleaseTaskState : System.IEquatable<Azure.Compute.Batch.BatchJobReleaseTaskState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchJobReleaseTaskState(string value) { throw null; }
        public static Azure.Compute.Batch.BatchJobReleaseTaskState Completed { get { throw null; } }
        public static Azure.Compute.Batch.BatchJobReleaseTaskState Running { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchJobReleaseTaskState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchJobReleaseTaskState left, Azure.Compute.Batch.BatchJobReleaseTaskState right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchJobReleaseTaskState (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchJobReleaseTaskState left, Azure.Compute.Batch.BatchJobReleaseTaskState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchJobSchedule : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobSchedule>
    {
        public BatchJobSchedule(Azure.Compute.Batch.BatchJobSpecification jobSpecification) { }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string ETag { get { throw null; } }
        public Azure.Compute.Batch.BatchJobScheduleExecutionInfo ExecutionInfo { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Compute.Batch.BatchJobSpecification JobSpecification { get { throw null; } set { } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.MetadataItem> Metadata { get { throw null; } }
        public Azure.Compute.Batch.BatchJobScheduleState? PreviousState { get { throw null; } }
        public System.DateTimeOffset? PreviousStateTransitionTime { get { throw null; } }
        public Azure.Compute.Batch.BatchJobScheduleConfiguration Schedule { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchJobScheduleState? State { get { throw null; } }
        public System.DateTimeOffset? StateTransitionTime { get { throw null; } }
        public Azure.Compute.Batch.BatchJobScheduleStatistics Stats { get { throw null; } }
        public string Url { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobSchedule System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobSchedule System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchJobScheduleConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobScheduleConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobScheduleConfiguration>
    {
        public BatchJobScheduleConfiguration() { }
        public System.DateTimeOffset? DoNotRunAfter { get { throw null; } set { } }
        public System.DateTimeOffset? DoNotRunUntil { get { throw null; } set { } }
        public System.TimeSpan? RecurrenceInterval { get { throw null; } set { } }
        public System.TimeSpan? StartWindow { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobScheduleConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobScheduleConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobScheduleConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobScheduleConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobScheduleConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobScheduleConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobScheduleConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchJobScheduleCreateContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobScheduleCreateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobScheduleCreateContent>
    {
        public BatchJobScheduleCreateContent(string id, Azure.Compute.Batch.BatchJobScheduleConfiguration schedule, Azure.Compute.Batch.BatchJobSpecification jobSpecification) { }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public Azure.Compute.Batch.BatchJobSpecification JobSpecification { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.MetadataItem> Metadata { get { throw null; } }
        public Azure.Compute.Batch.BatchJobScheduleConfiguration Schedule { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobScheduleCreateContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobScheduleCreateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobScheduleCreateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobScheduleCreateContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobScheduleCreateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobScheduleCreateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobScheduleCreateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchJobScheduleExecutionInfo : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobScheduleExecutionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobScheduleExecutionInfo>
    {
        internal BatchJobScheduleExecutionInfo() { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public System.DateTimeOffset? NextRunTime { get { throw null; } }
        public Azure.Compute.Batch.RecentBatchJob RecentJob { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobScheduleExecutionInfo System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobScheduleExecutionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobScheduleExecutionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobScheduleExecutionInfo System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobScheduleExecutionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobScheduleExecutionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobScheduleExecutionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchJobScheduleState : System.IEquatable<Azure.Compute.Batch.BatchJobScheduleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchJobScheduleState(string value) { throw null; }
        public static Azure.Compute.Batch.BatchJobScheduleState Active { get { throw null; } }
        public static Azure.Compute.Batch.BatchJobScheduleState Completed { get { throw null; } }
        public static Azure.Compute.Batch.BatchJobScheduleState Deleting { get { throw null; } }
        public static Azure.Compute.Batch.BatchJobScheduleState Disabled { get { throw null; } }
        public static Azure.Compute.Batch.BatchJobScheduleState Terminating { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchJobScheduleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchJobScheduleState left, Azure.Compute.Batch.BatchJobScheduleState right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchJobScheduleState (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchJobScheduleState left, Azure.Compute.Batch.BatchJobScheduleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchJobScheduleStatistics : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobScheduleStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobScheduleStatistics>
    {
        internal BatchJobScheduleStatistics() { }
        public System.TimeSpan KernelCpuTime { get { throw null; } }
        public System.DateTimeOffset LastUpdateTime { get { throw null; } }
        public long NumFailedTasks { get { throw null; } }
        public long NumSucceededTasks { get { throw null; } }
        public long NumTaskRetries { get { throw null; } }
        public float ReadIOGiB { get { throw null; } }
        public long ReadIOps { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public string Url { get { throw null; } }
        public System.TimeSpan UserCpuTime { get { throw null; } }
        public System.TimeSpan WaitTime { get { throw null; } }
        public System.TimeSpan WallClockTime { get { throw null; } }
        public float WriteIOGiB { get { throw null; } }
        public long WriteIOps { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobScheduleStatistics System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobScheduleStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobScheduleStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobScheduleStatistics System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobScheduleStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobScheduleStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobScheduleStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchJobScheduleUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobScheduleUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobScheduleUpdateContent>
    {
        public BatchJobScheduleUpdateContent() { }
        public Azure.Compute.Batch.BatchJobSpecification JobSpecification { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.MetadataItem> Metadata { get { throw null; } }
        public Azure.Compute.Batch.BatchJobScheduleConfiguration Schedule { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobScheduleUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobScheduleUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobScheduleUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobScheduleUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobScheduleUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobScheduleUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobScheduleUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchJobSchedulingError : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobSchedulingError>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobSchedulingError>
    {
        internal BatchJobSchedulingError() { }
        public Azure.Compute.Batch.ErrorCategory Category { get { throw null; } }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.NameValuePair> Details { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobSchedulingError System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobSchedulingError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobSchedulingError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobSchedulingError System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobSchedulingError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobSchedulingError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobSchedulingError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchJobSpecification : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobSpecification>
    {
        public BatchJobSpecification(Azure.Compute.Batch.BatchPoolInfo poolInfo) { }
        public bool? AllowTaskPreemption { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.EnvironmentSetting> CommonEnvironmentSettings { get { throw null; } }
        public Azure.Compute.Batch.BatchJobConstraints Constraints { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchJobManagerTask JobManagerTask { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchJobPreparationTask JobPreparationTask { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchJobReleaseTask JobReleaseTask { get { throw null; } set { } }
        public int? MaxParallelTasks { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.MetadataItem> Metadata { get { throw null; } }
        public Azure.Compute.Batch.BatchJobNetworkConfiguration NetworkConfiguration { get { throw null; } set { } }
        public Azure.Compute.Batch.OnAllBatchTasksComplete? OnAllTasksComplete { get { throw null; } set { } }
        public Azure.Compute.Batch.OnBatchTaskFailure? OnTaskFailure { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchPoolInfo PoolInfo { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public bool? UsesTaskDependencies { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobSpecification System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobSpecification System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchJobState : System.IEquatable<Azure.Compute.Batch.BatchJobState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchJobState(string value) { throw null; }
        public static Azure.Compute.Batch.BatchJobState Active { get { throw null; } }
        public static Azure.Compute.Batch.BatchJobState Completed { get { throw null; } }
        public static Azure.Compute.Batch.BatchJobState Deleting { get { throw null; } }
        public static Azure.Compute.Batch.BatchJobState Disabled { get { throw null; } }
        public static Azure.Compute.Batch.BatchJobState Disabling { get { throw null; } }
        public static Azure.Compute.Batch.BatchJobState Enabling { get { throw null; } }
        public static Azure.Compute.Batch.BatchJobState Terminating { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchJobState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchJobState left, Azure.Compute.Batch.BatchJobState right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchJobState (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchJobState left, Azure.Compute.Batch.BatchJobState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchJobStatistics : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobStatistics>
    {
        internal BatchJobStatistics() { }
        public System.TimeSpan KernelCpuTime { get { throw null; } }
        public System.DateTimeOffset LastUpdateTime { get { throw null; } }
        public long NumFailedTasks { get { throw null; } }
        public long NumSucceededTasks { get { throw null; } }
        public long NumTaskRetries { get { throw null; } }
        public float ReadIOGiB { get { throw null; } }
        public long ReadIOps { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public string Url { get { throw null; } }
        public System.TimeSpan UserCpuTime { get { throw null; } }
        public System.TimeSpan WaitTime { get { throw null; } }
        public System.TimeSpan WallClockTime { get { throw null; } }
        public float WriteIOGiB { get { throw null; } }
        public long WriteIOps { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobStatistics System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobStatistics System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchJobTerminateContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobTerminateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobTerminateContent>
    {
        public BatchJobTerminateContent() { }
        public string TerminationReason { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobTerminateContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobTerminateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobTerminateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobTerminateContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobTerminateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobTerminateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobTerminateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchJobUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobUpdateContent>
    {
        public BatchJobUpdateContent() { }
        public bool? AllowTaskPreemption { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchJobConstraints Constraints { get { throw null; } set { } }
        public int? MaxParallelTasks { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.MetadataItem> Metadata { get { throw null; } }
        public Azure.Compute.Batch.BatchJobNetworkConfiguration NetworkConfiguration { get { throw null; } set { } }
        public Azure.Compute.Batch.OnAllBatchTasksComplete? OnAllTasksComplete { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchPoolInfo PoolInfo { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchJobUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchJobUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchJobUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchNode : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNode>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNode>
    {
        internal BatchNode() { }
        public string AffinityId { get { throw null; } }
        public System.DateTimeOffset? AllocationTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.BatchCertificateReference> CertificateReferences { get { throw null; } }
        public Azure.Compute.Batch.BatchNodeEndpointConfiguration EndpointConfiguration { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.BatchNodeError> Errors { get { throw null; } }
        public string Id { get { throw null; } }
        public string IpAddress { get { throw null; } }
        public bool? IsDedicated { get { throw null; } }
        public System.DateTimeOffset? LastBootTime { get { throw null; } }
        public Azure.Compute.Batch.BatchNodeAgentInfo NodeAgentInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.BatchTaskInfo> RecentTasks { get { throw null; } }
        public int? RunningTasksCount { get { throw null; } }
        public int? RunningTaskSlotsCount { get { throw null; } }
        public Azure.Compute.Batch.SchedulingState? SchedulingState { get { throw null; } }
        public Azure.Compute.Batch.BatchStartTask StartTask { get { throw null; } }
        public Azure.Compute.Batch.BatchStartTaskInfo StartTaskInfo { get { throw null; } }
        public Azure.Compute.Batch.BatchNodeState? State { get { throw null; } }
        public System.DateTimeOffset? StateTransitionTime { get { throw null; } }
        public int? TotalTasksRun { get { throw null; } }
        public int? TotalTasksSucceeded { get { throw null; } }
        public string Url { get { throw null; } }
        public Azure.Compute.Batch.VirtualMachineInfo VirtualMachineInfo { get { throw null; } }
        public string VmSize { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNode System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNode System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchNodeAgentInfo : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeAgentInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeAgentInfo>
    {
        internal BatchNodeAgentInfo() { }
        public System.DateTimeOffset LastUpdateTime { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeAgentInfo System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeAgentInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeAgentInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeAgentInfo System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeAgentInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeAgentInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeAgentInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchNodeCommunicationMode : System.IEquatable<Azure.Compute.Batch.BatchNodeCommunicationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchNodeCommunicationMode(string value) { throw null; }
        public static Azure.Compute.Batch.BatchNodeCommunicationMode Classic { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeCommunicationMode Default { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeCommunicationMode Simplified { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchNodeCommunicationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchNodeCommunicationMode left, Azure.Compute.Batch.BatchNodeCommunicationMode right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchNodeCommunicationMode (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchNodeCommunicationMode left, Azure.Compute.Batch.BatchNodeCommunicationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchNodeCounts : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeCounts>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeCounts>
    {
        internal BatchNodeCounts() { }
        public int Creating { get { throw null; } }
        public int Deallocated { get { throw null; } }
        public int Deallocating { get { throw null; } }
        public int Idle { get { throw null; } }
        public int LeavingPool { get { throw null; } }
        public int Offline { get { throw null; } }
        public int Preempted { get { throw null; } }
        public int Rebooting { get { throw null; } }
        public int Reimaging { get { throw null; } }
        public int Running { get { throw null; } }
        public int Starting { get { throw null; } }
        public int StartTaskFailed { get { throw null; } }
        public int Total { get { throw null; } }
        public int Unknown { get { throw null; } }
        public int Unusable { get { throw null; } }
        public int UpgradingOs { get { throw null; } }
        public int WaitingForStartTask { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeCounts System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeCounts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeCounts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeCounts System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeCounts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeCounts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeCounts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchNodeDeallocateContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeDeallocateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeDeallocateContent>
    {
        public BatchNodeDeallocateContent() { }
        public Azure.Compute.Batch.BatchNodeDeallocateOption? NodeDeallocateOption { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeDeallocateContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeDeallocateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeDeallocateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeDeallocateContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeDeallocateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeDeallocateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeDeallocateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchNodeDeallocateOption : System.IEquatable<Azure.Compute.Batch.BatchNodeDeallocateOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchNodeDeallocateOption(string value) { throw null; }
        public static Azure.Compute.Batch.BatchNodeDeallocateOption Requeue { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeDeallocateOption RetainedData { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeDeallocateOption TaskCompletion { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeDeallocateOption Terminate { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchNodeDeallocateOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchNodeDeallocateOption left, Azure.Compute.Batch.BatchNodeDeallocateOption right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchNodeDeallocateOption (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchNodeDeallocateOption left, Azure.Compute.Batch.BatchNodeDeallocateOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchNodeDeallocationOption : System.IEquatable<Azure.Compute.Batch.BatchNodeDeallocationOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchNodeDeallocationOption(string value) { throw null; }
        public static Azure.Compute.Batch.BatchNodeDeallocationOption Requeue { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeDeallocationOption RetainedData { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeDeallocationOption TaskCompletion { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeDeallocationOption Terminate { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchNodeDeallocationOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchNodeDeallocationOption left, Azure.Compute.Batch.BatchNodeDeallocationOption right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchNodeDeallocationOption (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchNodeDeallocationOption left, Azure.Compute.Batch.BatchNodeDeallocationOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchNodeDisableSchedulingContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeDisableSchedulingContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeDisableSchedulingContent>
    {
        public BatchNodeDisableSchedulingContent() { }
        public Azure.Compute.Batch.BatchNodeDisableSchedulingOption? NodeDisableSchedulingOption { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeDisableSchedulingContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeDisableSchedulingContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeDisableSchedulingContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeDisableSchedulingContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeDisableSchedulingContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeDisableSchedulingContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeDisableSchedulingContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchNodeDisableSchedulingOption : System.IEquatable<Azure.Compute.Batch.BatchNodeDisableSchedulingOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchNodeDisableSchedulingOption(string value) { throw null; }
        public static Azure.Compute.Batch.BatchNodeDisableSchedulingOption Requeue { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeDisableSchedulingOption TaskCompletion { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeDisableSchedulingOption Terminate { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchNodeDisableSchedulingOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchNodeDisableSchedulingOption left, Azure.Compute.Batch.BatchNodeDisableSchedulingOption right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchNodeDisableSchedulingOption (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchNodeDisableSchedulingOption left, Azure.Compute.Batch.BatchNodeDisableSchedulingOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchNodeEndpointConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeEndpointConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeEndpointConfiguration>
    {
        internal BatchNodeEndpointConfiguration() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.InboundEndpoint> InboundEndpoints { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeEndpointConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeEndpointConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeEndpointConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeEndpointConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeEndpointConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeEndpointConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeEndpointConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchNodeError : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeError>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeError>
    {
        internal BatchNodeError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.NameValuePair> ErrorDetails { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeError System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeError System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchNodeFile : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeFile>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeFile>
    {
        internal BatchNodeFile() { }
        public bool? IsDirectory { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Compute.Batch.FileProperties Properties { get { throw null; } }
        public string Url { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeFile System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeFile System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchNodeFillType : System.IEquatable<Azure.Compute.Batch.BatchNodeFillType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchNodeFillType(string value) { throw null; }
        public static Azure.Compute.Batch.BatchNodeFillType Pack { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeFillType Spread { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchNodeFillType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchNodeFillType left, Azure.Compute.Batch.BatchNodeFillType right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchNodeFillType (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchNodeFillType left, Azure.Compute.Batch.BatchNodeFillType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchNodeIdentityReference : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeIdentityReference>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeIdentityReference>
    {
        public BatchNodeIdentityReference() { }
        public string ResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeIdentityReference System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeIdentityReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeIdentityReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeIdentityReference System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeIdentityReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeIdentityReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeIdentityReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchNodeInfo : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeInfo>
    {
        internal BatchNodeInfo() { }
        public string AffinityId { get { throw null; } }
        public string NodeId { get { throw null; } }
        public string NodeUrl { get { throw null; } }
        public string PoolId { get { throw null; } }
        public string TaskRootDirectory { get { throw null; } }
        public string TaskRootDirectoryUrl { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeInfo System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeInfo System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchNodePlacementConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodePlacementConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodePlacementConfiguration>
    {
        public BatchNodePlacementConfiguration() { }
        public Azure.Compute.Batch.BatchNodePlacementPolicyType? Policy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodePlacementConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodePlacementConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodePlacementConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodePlacementConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodePlacementConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodePlacementConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodePlacementConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchNodePlacementPolicyType : System.IEquatable<Azure.Compute.Batch.BatchNodePlacementPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchNodePlacementPolicyType(string value) { throw null; }
        public static Azure.Compute.Batch.BatchNodePlacementPolicyType Regional { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodePlacementPolicyType Zonal { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchNodePlacementPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchNodePlacementPolicyType left, Azure.Compute.Batch.BatchNodePlacementPolicyType right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchNodePlacementPolicyType (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchNodePlacementPolicyType left, Azure.Compute.Batch.BatchNodePlacementPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchNodeRebootContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeRebootContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeRebootContent>
    {
        public BatchNodeRebootContent() { }
        public Azure.Compute.Batch.BatchNodeRebootOption? NodeRebootOption { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeRebootContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeRebootContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeRebootContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeRebootContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeRebootContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeRebootContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeRebootContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchNodeRebootOption : System.IEquatable<Azure.Compute.Batch.BatchNodeRebootOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchNodeRebootOption(string value) { throw null; }
        public static Azure.Compute.Batch.BatchNodeRebootOption Requeue { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeRebootOption RetainedData { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeRebootOption TaskCompletion { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeRebootOption Terminate { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchNodeRebootOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchNodeRebootOption left, Azure.Compute.Batch.BatchNodeRebootOption right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchNodeRebootOption (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchNodeRebootOption left, Azure.Compute.Batch.BatchNodeRebootOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchNodeReimageContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeReimageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeReimageContent>
    {
        public BatchNodeReimageContent() { }
        public Azure.Compute.Batch.BatchNodeReimageOption? NodeReimageOption { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeReimageContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeReimageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeReimageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeReimageContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeReimageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeReimageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeReimageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchNodeReimageOption : System.IEquatable<Azure.Compute.Batch.BatchNodeReimageOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchNodeReimageOption(string value) { throw null; }
        public static Azure.Compute.Batch.BatchNodeReimageOption Requeue { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeReimageOption RetainedData { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeReimageOption TaskCompletion { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeReimageOption Terminate { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchNodeReimageOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchNodeReimageOption left, Azure.Compute.Batch.BatchNodeReimageOption right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchNodeReimageOption (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchNodeReimageOption left, Azure.Compute.Batch.BatchNodeReimageOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchNodeRemoteLoginSettings : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeRemoteLoginSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeRemoteLoginSettings>
    {
        internal BatchNodeRemoteLoginSettings() { }
        public string RemoteLoginIpAddress { get { throw null; } }
        public int RemoteLoginPort { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeRemoteLoginSettings System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeRemoteLoginSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeRemoteLoginSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeRemoteLoginSettings System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeRemoteLoginSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeRemoteLoginSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeRemoteLoginSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchNodeRemoveContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeRemoveContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeRemoveContent>
    {
        public BatchNodeRemoveContent(System.Collections.Generic.IEnumerable<string> nodeList) { }
        public Azure.Compute.Batch.BatchNodeDeallocationOption? NodeDeallocationOption { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NodeList { get { throw null; } }
        public System.TimeSpan? ResizeTimeout { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeRemoveContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeRemoveContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeRemoveContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeRemoveContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeRemoveContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeRemoveContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeRemoveContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchNodeState : System.IEquatable<Azure.Compute.Batch.BatchNodeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchNodeState(string value) { throw null; }
        public static Azure.Compute.Batch.BatchNodeState Creating { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeState Deallocated { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeState Deallocating { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeState Idle { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeState LeavingPool { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeState Offline { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeState Preempted { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeState Rebooting { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeState Reimaging { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeState Running { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeState Starting { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeState StartTaskFailed { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeState Unknown { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeState Unusable { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeState UpgradingOS { get { throw null; } }
        public static Azure.Compute.Batch.BatchNodeState WaitingForStartTask { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchNodeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchNodeState left, Azure.Compute.Batch.BatchNodeState right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchNodeState (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchNodeState left, Azure.Compute.Batch.BatchNodeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchNodeUserCreateContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeUserCreateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeUserCreateContent>
    {
        public BatchNodeUserCreateContent(string name) { }
        public System.DateTimeOffset? ExpiryTime { get { throw null; } set { } }
        public bool? IsAdmin { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Password { get { throw null; } set { } }
        public string SshPublicKey { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeUserCreateContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeUserCreateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeUserCreateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeUserCreateContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeUserCreateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeUserCreateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeUserCreateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchNodeUserUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeUserUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeUserUpdateContent>
    {
        public BatchNodeUserUpdateContent() { }
        public System.DateTimeOffset? ExpiryTime { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string SshPublicKey { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeUserUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeUserUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeUserUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeUserUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeUserUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeUserUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeUserUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchNodeVMExtension : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeVMExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeVMExtension>
    {
        internal BatchNodeVMExtension() { }
        public Azure.Compute.Batch.VMExtensionInstanceView InstanceView { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Compute.Batch.VMExtension VmExtension { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeVMExtension System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeVMExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchNodeVMExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchNodeVMExtension System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeVMExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeVMExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchNodeVMExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchPool : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPool>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPool>
    {
        internal BatchPool() { }
        public Azure.Compute.Batch.AllocationState? AllocationState { get { throw null; } }
        public System.DateTimeOffset? AllocationStateTransitionTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.BatchApplicationPackageReference> ApplicationPackageReferences { get { throw null; } }
        public System.TimeSpan? AutoScaleEvaluationInterval { get { throw null; } }
        public string AutoScaleFormula { get { throw null; } }
        public Azure.Compute.Batch.AutoScaleRun AutoScaleRun { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.BatchCertificateReference> CertificateReferences { get { throw null; } }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public int? CurrentDedicatedNodes { get { throw null; } }
        public int? CurrentLowPriorityNodes { get { throw null; } }
        public Azure.Compute.Batch.BatchNodeCommunicationMode? CurrentNodeCommunicationMode { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? EnableAutoScale { get { throw null; } }
        public bool? EnableInterNodeCommunication { get { throw null; } }
        public string ETag { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Compute.Batch.BatchPoolIdentity Identity { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.MetadataItem> Metadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.MountConfiguration> MountConfiguration { get { throw null; } }
        public Azure.Compute.Batch.NetworkConfiguration NetworkConfiguration { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.ResizeError> ResizeErrors { get { throw null; } }
        public System.TimeSpan? ResizeTimeout { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ResourceTags { get { throw null; } }
        public Azure.Compute.Batch.BatchStartTask StartTask { get { throw null; } }
        public Azure.Compute.Batch.BatchPoolState? State { get { throw null; } }
        public System.DateTimeOffset? StateTransitionTime { get { throw null; } }
        public Azure.Compute.Batch.BatchPoolStatistics Stats { get { throw null; } }
        public int? TargetDedicatedNodes { get { throw null; } }
        public int? TargetLowPriorityNodes { get { throw null; } }
        public Azure.Compute.Batch.BatchNodeCommunicationMode? TargetNodeCommunicationMode { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskSchedulingPolicy TaskSchedulingPolicy { get { throw null; } }
        public int? TaskSlotsPerNode { get { throw null; } }
        public Azure.Compute.Batch.UpgradePolicy UpgradePolicy { get { throw null; } }
        public string Url { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.UserAccount> UserAccounts { get { throw null; } }
        public Azure.Compute.Batch.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } }
        public string VmSize { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPool System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPool System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchPoolCreateContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolCreateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolCreateContent>
    {
        public BatchPoolCreateContent(string id, string vmSize) { }
        public System.Collections.Generic.IList<Azure.Compute.Batch.BatchApplicationPackageReference> ApplicationPackageReferences { get { throw null; } }
        public System.TimeSpan? AutoScaleEvaluationInterval { get { throw null; } set { } }
        public string AutoScaleFormula { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.BatchCertificateReference> CertificateReferences { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public bool? EnableAutoScale { get { throw null; } set { } }
        public bool? EnableInterNodeCommunication { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.MetadataItem> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.MountConfiguration> MountConfiguration { get { throw null; } }
        public Azure.Compute.Batch.NetworkConfiguration NetworkConfiguration { get { throw null; } set { } }
        public System.TimeSpan? ResizeTimeout { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ResourceTags { get { throw null; } }
        public Azure.Compute.Batch.BatchStartTask StartTask { get { throw null; } set { } }
        public int? TargetDedicatedNodes { get { throw null; } set { } }
        public int? TargetLowPriorityNodes { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchNodeCommunicationMode? TargetNodeCommunicationMode { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchTaskSchedulingPolicy TaskSchedulingPolicy { get { throw null; } set { } }
        public int? TaskSlotsPerNode { get { throw null; } set { } }
        public Azure.Compute.Batch.UpgradePolicy UpgradePolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.UserAccount> UserAccounts { get { throw null; } }
        public Azure.Compute.Batch.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
        public string VmSize { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolCreateContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolCreateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolCreateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolCreateContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolCreateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolCreateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolCreateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchPoolEnableAutoScaleContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolEnableAutoScaleContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolEnableAutoScaleContent>
    {
        public BatchPoolEnableAutoScaleContent() { }
        public System.TimeSpan? AutoScaleEvaluationInterval { get { throw null; } set { } }
        public string AutoScaleFormula { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolEnableAutoScaleContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolEnableAutoScaleContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolEnableAutoScaleContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolEnableAutoScaleContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolEnableAutoScaleContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolEnableAutoScaleContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolEnableAutoScaleContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchPoolEndpointConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolEndpointConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolEndpointConfiguration>
    {
        public BatchPoolEndpointConfiguration(System.Collections.Generic.IEnumerable<Azure.Compute.Batch.InboundNatPool> inboundNatPools) { }
        public System.Collections.Generic.IList<Azure.Compute.Batch.InboundNatPool> InboundNatPools { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolEndpointConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolEndpointConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolEndpointConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolEndpointConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolEndpointConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolEndpointConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolEndpointConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchPoolEvaluateAutoScaleContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolEvaluateAutoScaleContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolEvaluateAutoScaleContent>
    {
        public BatchPoolEvaluateAutoScaleContent(string autoScaleFormula) { }
        public string AutoScaleFormula { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolEvaluateAutoScaleContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolEvaluateAutoScaleContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolEvaluateAutoScaleContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolEvaluateAutoScaleContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolEvaluateAutoScaleContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolEvaluateAutoScaleContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolEvaluateAutoScaleContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchPoolIdentity : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolIdentity>
    {
        internal BatchPoolIdentity() { }
        public Azure.Compute.Batch.BatchPoolIdentityType Type { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolIdentity System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolIdentity System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchPoolIdentityType : System.IEquatable<Azure.Compute.Batch.BatchPoolIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchPoolIdentityType(string value) { throw null; }
        public static Azure.Compute.Batch.BatchPoolIdentityType None { get { throw null; } }
        public static Azure.Compute.Batch.BatchPoolIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchPoolIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchPoolIdentityType left, Azure.Compute.Batch.BatchPoolIdentityType right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchPoolIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchPoolIdentityType left, Azure.Compute.Batch.BatchPoolIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchPoolInfo : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolInfo>
    {
        public BatchPoolInfo() { }
        public Azure.Compute.Batch.BatchAutoPoolSpecification AutoPoolSpecification { get { throw null; } set { } }
        public string PoolId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolInfo System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolInfo System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchPoolLifetimeOption : System.IEquatable<Azure.Compute.Batch.BatchPoolLifetimeOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchPoolLifetimeOption(string value) { throw null; }
        public static Azure.Compute.Batch.BatchPoolLifetimeOption Job { get { throw null; } }
        public static Azure.Compute.Batch.BatchPoolLifetimeOption JobSchedule { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchPoolLifetimeOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchPoolLifetimeOption left, Azure.Compute.Batch.BatchPoolLifetimeOption right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchPoolLifetimeOption (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchPoolLifetimeOption left, Azure.Compute.Batch.BatchPoolLifetimeOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchPoolNodeCounts : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolNodeCounts>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolNodeCounts>
    {
        internal BatchPoolNodeCounts() { }
        public Azure.Compute.Batch.BatchNodeCounts Dedicated { get { throw null; } }
        public Azure.Compute.Batch.BatchNodeCounts LowPriority { get { throw null; } }
        public string PoolId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolNodeCounts System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolNodeCounts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolNodeCounts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolNodeCounts System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolNodeCounts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolNodeCounts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolNodeCounts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchPoolReplaceContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolReplaceContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolReplaceContent>
    {
        public BatchPoolReplaceContent(System.Collections.Generic.IEnumerable<Azure.Compute.Batch.BatchCertificateReference> certificateReferences, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.BatchApplicationPackageReference> applicationPackageReferences, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.MetadataItem> metadata) { }
        public System.Collections.Generic.IList<Azure.Compute.Batch.BatchApplicationPackageReference> ApplicationPackageReferences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.BatchCertificateReference> CertificateReferences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.MetadataItem> Metadata { get { throw null; } }
        public Azure.Compute.Batch.BatchStartTask StartTask { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchNodeCommunicationMode? TargetNodeCommunicationMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolReplaceContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolReplaceContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolReplaceContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolReplaceContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolReplaceContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolReplaceContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolReplaceContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchPoolResizeContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolResizeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolResizeContent>
    {
        public BatchPoolResizeContent() { }
        public Azure.Compute.Batch.BatchNodeDeallocationOption? NodeDeallocationOption { get { throw null; } set { } }
        public System.TimeSpan? ResizeTimeout { get { throw null; } set { } }
        public int? TargetDedicatedNodes { get { throw null; } set { } }
        public int? TargetLowPriorityNodes { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolResizeContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolResizeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolResizeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolResizeContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolResizeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolResizeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolResizeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchPoolResourceStatistics : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolResourceStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolResourceStatistics>
    {
        internal BatchPoolResourceStatistics() { }
        public float AvgCpuPercentage { get { throw null; } }
        public float AvgDiskGiB { get { throw null; } }
        public float AvgMemoryGiB { get { throw null; } }
        public float DiskReadGiB { get { throw null; } }
        public long DiskReadIOps { get { throw null; } }
        public float DiskWriteGiB { get { throw null; } }
        public long DiskWriteIOps { get { throw null; } }
        public System.DateTimeOffset LastUpdateTime { get { throw null; } }
        public float NetworkReadGiB { get { throw null; } }
        public float NetworkWriteGiB { get { throw null; } }
        public float PeakDiskGiB { get { throw null; } }
        public float PeakMemoryGiB { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolResourceStatistics System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolResourceStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolResourceStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolResourceStatistics System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolResourceStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolResourceStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolResourceStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchPoolSpecification : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolSpecification>
    {
        public BatchPoolSpecification(string vmSize) { }
        public System.Collections.Generic.IList<Azure.Compute.Batch.BatchApplicationPackageReference> ApplicationPackageReferences { get { throw null; } }
        public System.TimeSpan? AutoScaleEvaluationInterval { get { throw null; } set { } }
        public string AutoScaleFormula { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.BatchCertificateReference> CertificateReferences { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public bool? EnableAutoScale { get { throw null; } set { } }
        public bool? EnableInterNodeCommunication { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.MetadataItem> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.MountConfiguration> MountConfiguration { get { throw null; } }
        public Azure.Compute.Batch.NetworkConfiguration NetworkConfiguration { get { throw null; } set { } }
        public System.TimeSpan? ResizeTimeout { get { throw null; } set { } }
        public string ResourceTags { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchStartTask StartTask { get { throw null; } set { } }
        public int? TargetDedicatedNodes { get { throw null; } set { } }
        public int? TargetLowPriorityNodes { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchNodeCommunicationMode? TargetNodeCommunicationMode { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchTaskSchedulingPolicy TaskSchedulingPolicy { get { throw null; } set { } }
        public int? TaskSlotsPerNode { get { throw null; } set { } }
        public Azure.Compute.Batch.UpgradePolicy UpgradePolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.UserAccount> UserAccounts { get { throw null; } }
        public Azure.Compute.Batch.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolSpecification System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolSpecification System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchPoolState : System.IEquatable<Azure.Compute.Batch.BatchPoolState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchPoolState(string value) { throw null; }
        public static Azure.Compute.Batch.BatchPoolState Active { get { throw null; } }
        public static Azure.Compute.Batch.BatchPoolState Deleting { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchPoolState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchPoolState left, Azure.Compute.Batch.BatchPoolState right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchPoolState (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchPoolState left, Azure.Compute.Batch.BatchPoolState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchPoolStatistics : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolStatistics>
    {
        internal BatchPoolStatistics() { }
        public System.DateTimeOffset LastUpdateTime { get { throw null; } }
        public Azure.Compute.Batch.BatchPoolResourceStatistics ResourceStats { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public string Url { get { throw null; } }
        public Azure.Compute.Batch.BatchPoolUsageStatistics UsageStats { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolStatistics System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolStatistics System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchPoolUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolUpdateContent>
    {
        public BatchPoolUpdateContent() { }
        public System.Collections.Generic.IList<Azure.Compute.Batch.BatchApplicationPackageReference> ApplicationPackageReferences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.BatchCertificateReference> CertificateReferences { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public bool? EnableInterNodeCommunication { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.MetadataItem> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.MountConfiguration> MountConfiguration { get { throw null; } }
        public Azure.Compute.Batch.NetworkConfiguration NetworkConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ResourceTags { get { throw null; } }
        public Azure.Compute.Batch.BatchStartTask StartTask { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchNodeCommunicationMode? TargetNodeCommunicationMode { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchTaskSchedulingPolicy TaskSchedulingPolicy { get { throw null; } set { } }
        public int? TaskSlotsPerNode { get { throw null; } set { } }
        public Azure.Compute.Batch.UpgradePolicy UpgradePolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.UserAccount> UserAccounts { get { throw null; } }
        public Azure.Compute.Batch.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchPoolUsageMetrics : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolUsageMetrics>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolUsageMetrics>
    {
        internal BatchPoolUsageMetrics() { }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public string PoolId { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public float TotalCoreHours { get { throw null; } }
        public string VmSize { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolUsageMetrics System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolUsageMetrics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolUsageMetrics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolUsageMetrics System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolUsageMetrics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolUsageMetrics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolUsageMetrics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchPoolUsageStatistics : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolUsageStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolUsageStatistics>
    {
        internal BatchPoolUsageStatistics() { }
        public System.TimeSpan DedicatedCoreTime { get { throw null; } }
        public System.DateTimeOffset LastUpdateTime { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolUsageStatistics System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolUsageStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchPoolUsageStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchPoolUsageStatistics System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolUsageStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolUsageStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchPoolUsageStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchStartTask : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchStartTask>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchStartTask>
    {
        public BatchStartTask(string commandLine) { }
        public string CommandLine { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchTaskContainerSettings ContainerSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.EnvironmentSetting> EnvironmentSettings { get { throw null; } }
        public int? MaxTaskRetryCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.ResourceFile> ResourceFiles { get { throw null; } }
        public Azure.Compute.Batch.UserIdentity UserIdentity { get { throw null; } set { } }
        public bool? WaitForSuccess { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchStartTask System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchStartTask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchStartTask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchStartTask System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchStartTask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchStartTask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchStartTask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchStartTaskInfo : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchStartTaskInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchStartTaskInfo>
    {
        internal BatchStartTaskInfo() { }
        public Azure.Compute.Batch.BatchTaskContainerExecutionInfo ContainerInfo { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public int? ExitCode { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskFailureInfo FailureInfo { get { throw null; } }
        public System.DateTimeOffset? LastRetryTime { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskExecutionResult? Result { get { throw null; } }
        public int RetryCount { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public Azure.Compute.Batch.BatchStartTaskState State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchStartTaskInfo System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchStartTaskInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchStartTaskInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchStartTaskInfo System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchStartTaskInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchStartTaskInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchStartTaskInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchStartTaskState : System.IEquatable<Azure.Compute.Batch.BatchStartTaskState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchStartTaskState(string value) { throw null; }
        public static Azure.Compute.Batch.BatchStartTaskState Completed { get { throw null; } }
        public static Azure.Compute.Batch.BatchStartTaskState Running { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchStartTaskState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchStartTaskState left, Azure.Compute.Batch.BatchStartTaskState right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchStartTaskState (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchStartTaskState left, Azure.Compute.Batch.BatchStartTaskState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchSubtask : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchSubtask>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchSubtask>
    {
        internal BatchSubtask() { }
        public Azure.Compute.Batch.BatchTaskContainerExecutionInfo ContainerInfo { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public int? ExitCode { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskFailureInfo FailureInfo { get { throw null; } }
        public int? Id { get { throw null; } }
        public Azure.Compute.Batch.BatchNodeInfo NodeInfo { get { throw null; } }
        public Azure.Compute.Batch.BatchSubtaskState? PreviousState { get { throw null; } }
        public System.DateTimeOffset? PreviousStateTransitionTime { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskExecutionResult? Result { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public Azure.Compute.Batch.BatchSubtaskState? State { get { throw null; } }
        public System.DateTimeOffset? StateTransitionTime { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchSubtask System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchSubtask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchSubtask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchSubtask System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchSubtask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchSubtask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchSubtask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchSubtaskState : System.IEquatable<Azure.Compute.Batch.BatchSubtaskState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchSubtaskState(string value) { throw null; }
        public static Azure.Compute.Batch.BatchSubtaskState Completed { get { throw null; } }
        public static Azure.Compute.Batch.BatchSubtaskState Preparing { get { throw null; } }
        public static Azure.Compute.Batch.BatchSubtaskState Running { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchSubtaskState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchSubtaskState left, Azure.Compute.Batch.BatchSubtaskState right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchSubtaskState (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchSubtaskState left, Azure.Compute.Batch.BatchSubtaskState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchSupportedImage : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchSupportedImage>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchSupportedImage>
    {
        internal BatchSupportedImage() { }
        public System.DateTimeOffset? BatchSupportEndOfLife { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Capabilities { get { throw null; } }
        public Azure.Compute.Batch.ImageReference ImageReference { get { throw null; } }
        public string NodeAgentSkuId { get { throw null; } }
        public Azure.Compute.Batch.OSType OsType { get { throw null; } }
        public Azure.Compute.Batch.ImageVerificationType VerificationType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchSupportedImage System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchSupportedImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchSupportedImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchSupportedImage System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchSupportedImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchSupportedImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchSupportedImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchTask : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTask>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTask>
    {
        public BatchTask() { }
        public Azure.Compute.Batch.AffinityInfo AffinityInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.BatchApplicationPackageReference> ApplicationPackageReferences { get { throw null; } }
        public Azure.Compute.Batch.AuthenticationTokenSettings AuthenticationTokenSettings { get { throw null; } }
        public string CommandLine { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskConstraints Constraints { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchTaskContainerSettings ContainerSettings { get { throw null; } }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskDependencies DependsOn { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.EnvironmentSetting> EnvironmentSettings { get { throw null; } }
        public string ETag { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskExecutionInfo ExecutionInfo { get { throw null; } }
        public Azure.Compute.Batch.ExitConditions ExitConditions { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public Azure.Compute.Batch.MultiInstanceSettings MultiInstanceSettings { get { throw null; } }
        public Azure.Compute.Batch.BatchNodeInfo NodeInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.OutputFile> OutputFiles { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskState? PreviousState { get { throw null; } }
        public System.DateTimeOffset? PreviousStateTransitionTime { get { throw null; } }
        public int? RequiredSlots { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.ResourceFile> ResourceFiles { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskState? State { get { throw null; } }
        public System.DateTimeOffset? StateTransitionTime { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskStatistics Stats { get { throw null; } }
        public string Url { get { throw null; } }
        public Azure.Compute.Batch.UserIdentity UserIdentity { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTask System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTask System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchTaskAddCollectionResult : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskAddCollectionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskAddCollectionResult>
    {
        internal BatchTaskAddCollectionResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.BatchTaskAddResult> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskAddCollectionResult System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskAddCollectionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskAddCollectionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskAddCollectionResult System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskAddCollectionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskAddCollectionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskAddCollectionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchTaskAddResult : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskAddResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskAddResult>
    {
        internal BatchTaskAddResult() { }
        public Azure.Compute.Batch.BatchError Error { get { throw null; } }
        public string ETag { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public string Location { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskAddStatus Status { get { throw null; } }
        public string TaskId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskAddResult System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskAddResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskAddResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskAddResult System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskAddResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskAddResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskAddResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchTaskAddStatus : System.IEquatable<Azure.Compute.Batch.BatchTaskAddStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchTaskAddStatus(string value) { throw null; }
        public static Azure.Compute.Batch.BatchTaskAddStatus ClientError { get { throw null; } }
        public static Azure.Compute.Batch.BatchTaskAddStatus ServerError { get { throw null; } }
        public static Azure.Compute.Batch.BatchTaskAddStatus Success { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchTaskAddStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchTaskAddStatus left, Azure.Compute.Batch.BatchTaskAddStatus right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchTaskAddStatus (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchTaskAddStatus left, Azure.Compute.Batch.BatchTaskAddStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchTaskConstraints : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskConstraints>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskConstraints>
    {
        public BatchTaskConstraints() { }
        public int? MaxTaskRetryCount { get { throw null; } set { } }
        public System.TimeSpan? MaxWallClockTime { get { throw null; } set { } }
        public System.TimeSpan? RetentionTime { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskConstraints System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskConstraints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskConstraints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskConstraints System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskConstraints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskConstraints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskConstraints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchTaskContainerExecutionInfo : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskContainerExecutionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskContainerExecutionInfo>
    {
        internal BatchTaskContainerExecutionInfo() { }
        public string ContainerId { get { throw null; } }
        public string Error { get { throw null; } }
        public string State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskContainerExecutionInfo System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskContainerExecutionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskContainerExecutionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskContainerExecutionInfo System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskContainerExecutionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskContainerExecutionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskContainerExecutionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchTaskContainerSettings : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskContainerSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskContainerSettings>
    {
        public BatchTaskContainerSettings(string imageName) { }
        public System.Collections.Generic.IList<Azure.Compute.Batch.ContainerHostBatchBindMountEntry> ContainerHostBatchBindMounts { get { throw null; } }
        public string ContainerRunOptions { get { throw null; } set { } }
        public string ImageName { get { throw null; } set { } }
        public Azure.Compute.Batch.ContainerRegistryReference Registry { get { throw null; } set { } }
        public Azure.Compute.Batch.ContainerWorkingDirectory? WorkingDirectory { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskContainerSettings System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskContainerSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskContainerSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskContainerSettings System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskContainerSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskContainerSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskContainerSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchTaskCounts : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskCounts>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskCounts>
    {
        internal BatchTaskCounts() { }
        public int Active { get { throw null; } }
        public int Completed { get { throw null; } }
        public int Failed { get { throw null; } }
        public int Running { get { throw null; } }
        public int Succeeded { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskCounts System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskCounts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskCounts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskCounts System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskCounts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskCounts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskCounts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchTaskCountsResult : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskCountsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskCountsResult>
    {
        internal BatchTaskCountsResult() { }
        public Azure.Compute.Batch.BatchTaskCounts TaskCounts { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskSlotCounts TaskSlotCounts { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskCountsResult System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskCountsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskCountsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskCountsResult System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskCountsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskCountsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskCountsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchTaskCreateContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskCreateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskCreateContent>
    {
        public BatchTaskCreateContent(string id, string commandLine) { }
        public Azure.Compute.Batch.AffinityInfo AffinityInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.BatchApplicationPackageReference> ApplicationPackageReferences { get { throw null; } }
        public Azure.Compute.Batch.AuthenticationTokenSettings AuthenticationTokenSettings { get { throw null; } set { } }
        public string CommandLine { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskConstraints Constraints { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchTaskContainerSettings ContainerSettings { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchTaskDependencies DependsOn { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.EnvironmentSetting> EnvironmentSettings { get { throw null; } }
        public Azure.Compute.Batch.ExitConditions ExitConditions { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public Azure.Compute.Batch.MultiInstanceSettings MultiInstanceSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.OutputFile> OutputFiles { get { throw null; } }
        public int? RequiredSlots { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.ResourceFile> ResourceFiles { get { throw null; } }
        public Azure.Compute.Batch.UserIdentity UserIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskCreateContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskCreateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskCreateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskCreateContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskCreateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskCreateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskCreateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchTaskDependencies : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskDependencies>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskDependencies>
    {
        public BatchTaskDependencies() { }
        public System.Collections.Generic.IList<Azure.Compute.Batch.BatchTaskIdRange> TaskIdRanges { get { throw null; } }
        public System.Collections.Generic.IList<string> TaskIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskDependencies System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskDependencies>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskDependencies>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskDependencies System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskDependencies>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskDependencies>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskDependencies>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchTaskExecutionInfo : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskExecutionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskExecutionInfo>
    {
        internal BatchTaskExecutionInfo() { }
        public Azure.Compute.Batch.BatchTaskContainerExecutionInfo ContainerInfo { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public int? ExitCode { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskFailureInfo FailureInfo { get { throw null; } }
        public System.DateTimeOffset? LastRequeueTime { get { throw null; } }
        public System.DateTimeOffset? LastRetryTime { get { throw null; } }
        public int RequeueCount { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskExecutionResult? Result { get { throw null; } }
        public int RetryCount { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskExecutionInfo System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskExecutionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskExecutionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskExecutionInfo System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskExecutionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskExecutionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskExecutionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchTaskExecutionResult : System.IEquatable<Azure.Compute.Batch.BatchTaskExecutionResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchTaskExecutionResult(string value) { throw null; }
        public static Azure.Compute.Batch.BatchTaskExecutionResult Failure { get { throw null; } }
        public static Azure.Compute.Batch.BatchTaskExecutionResult Success { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchTaskExecutionResult other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchTaskExecutionResult left, Azure.Compute.Batch.BatchTaskExecutionResult right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchTaskExecutionResult (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchTaskExecutionResult left, Azure.Compute.Batch.BatchTaskExecutionResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchTaskFailureInfo : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskFailureInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskFailureInfo>
    {
        internal BatchTaskFailureInfo() { }
        public Azure.Compute.Batch.ErrorCategory Category { get { throw null; } }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.NameValuePair> Details { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskFailureInfo System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskFailureInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskFailureInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskFailureInfo System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskFailureInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskFailureInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskFailureInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchTaskGroup : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskGroup>
    {
        public BatchTaskGroup(System.Collections.Generic.IEnumerable<Azure.Compute.Batch.BatchTaskCreateContent> value) { }
        public System.Collections.Generic.IList<Azure.Compute.Batch.BatchTaskCreateContent> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskGroup System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskGroup System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchTaskIdRange : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskIdRange>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskIdRange>
    {
        public BatchTaskIdRange(int start, int end) { }
        public int End { get { throw null; } set { } }
        public int Start { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskIdRange System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskIdRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskIdRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskIdRange System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskIdRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskIdRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskIdRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchTaskInfo : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskInfo>
    {
        internal BatchTaskInfo() { }
        public Azure.Compute.Batch.BatchTaskExecutionInfo ExecutionInfo { get { throw null; } }
        public string JobId { get { throw null; } }
        public int? SubtaskId { get { throw null; } }
        public string TaskId { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskState TaskState { get { throw null; } }
        public string TaskUrl { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskInfo System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskInfo System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchTaskSchedulingPolicy : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskSchedulingPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskSchedulingPolicy>
    {
        public BatchTaskSchedulingPolicy(Azure.Compute.Batch.BatchNodeFillType nodeFillType) { }
        public Azure.Compute.Batch.BatchNodeFillType NodeFillType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskSchedulingPolicy System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskSchedulingPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskSchedulingPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskSchedulingPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskSchedulingPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskSchedulingPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskSchedulingPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchTaskSlotCounts : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskSlotCounts>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskSlotCounts>
    {
        internal BatchTaskSlotCounts() { }
        public int Active { get { throw null; } }
        public int Completed { get { throw null; } }
        public int Failed { get { throw null; } }
        public int Running { get { throw null; } }
        public int Succeeded { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskSlotCounts System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskSlotCounts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskSlotCounts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskSlotCounts System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskSlotCounts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskSlotCounts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskSlotCounts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchTaskState : System.IEquatable<Azure.Compute.Batch.BatchTaskState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchTaskState(string value) { throw null; }
        public static Azure.Compute.Batch.BatchTaskState Active { get { throw null; } }
        public static Azure.Compute.Batch.BatchTaskState Completed { get { throw null; } }
        public static Azure.Compute.Batch.BatchTaskState Preparing { get { throw null; } }
        public static Azure.Compute.Batch.BatchTaskState Running { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.BatchTaskState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.BatchTaskState left, Azure.Compute.Batch.BatchTaskState right) { throw null; }
        public static implicit operator Azure.Compute.Batch.BatchTaskState (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.BatchTaskState left, Azure.Compute.Batch.BatchTaskState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchTaskStatistics : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskStatistics>
    {
        internal BatchTaskStatistics() { }
        public System.TimeSpan KernelCpuTime { get { throw null; } }
        public System.DateTimeOffset LastUpdateTime { get { throw null; } }
        public float ReadIOGiB { get { throw null; } }
        public long ReadIOps { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public string Url { get { throw null; } }
        public System.TimeSpan UserCpuTime { get { throw null; } }
        public System.TimeSpan WaitTime { get { throw null; } }
        public System.TimeSpan WallClockTime { get { throw null; } }
        public float WriteIOGiB { get { throw null; } }
        public long WriteIOps { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskStatistics System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.BatchTaskStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.BatchTaskStatistics System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.BatchTaskStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CachingType : System.IEquatable<Azure.Compute.Batch.CachingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CachingType(string value) { throw null; }
        public static Azure.Compute.Batch.CachingType None { get { throw null; } }
        public static Azure.Compute.Batch.CachingType ReadOnly { get { throw null; } }
        public static Azure.Compute.Batch.CachingType ReadWrite { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.CachingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.CachingType left, Azure.Compute.Batch.CachingType right) { throw null; }
        public static implicit operator Azure.Compute.Batch.CachingType (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.CachingType left, Azure.Compute.Batch.CachingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CifsMountConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.CifsMountConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.CifsMountConfiguration>
    {
        public CifsMountConfiguration(string username, string source, string relativeMountPath, string password) { }
        public string MountOptions { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string RelativeMountPath { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.CifsMountConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.CifsMountConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.CifsMountConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.CifsMountConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.CifsMountConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.CifsMountConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.CifsMountConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ComputeBatchModelFactory
    {
        public static Azure.Compute.Batch.AutoScaleRun AutoScaleRun(System.DateTimeOffset timestamp = default(System.DateTimeOffset), string results = null, Azure.Compute.Batch.AutoScaleRunError error = null) { throw null; }
        public static Azure.Compute.Batch.AutoScaleRunError AutoScaleRunError(string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.NameValuePair> values = null) { throw null; }
        public static Azure.Compute.Batch.BatchApplication BatchApplication(string id = null, string displayName = null, System.Collections.Generic.IEnumerable<string> versions = null) { throw null; }
        public static Azure.Compute.Batch.BatchCertificate BatchCertificate(string thumbprint = null, string thumbprintAlgorithm = null, string url = null, Azure.Compute.Batch.BatchCertificateState? state = default(Azure.Compute.Batch.BatchCertificateState?), System.DateTimeOffset? stateTransitionTime = default(System.DateTimeOffset?), Azure.Compute.Batch.BatchCertificateState? previousState = default(Azure.Compute.Batch.BatchCertificateState?), System.DateTimeOffset? previousStateTransitionTime = default(System.DateTimeOffset?), string publicData = null, Azure.Compute.Batch.DeleteBatchCertificateError deleteCertificateError = null, string data = null, Azure.Compute.Batch.BatchCertificateFormat? certificateFormat = default(Azure.Compute.Batch.BatchCertificateFormat?), string password = null) { throw null; }
        public static Azure.Compute.Batch.BatchError BatchError(string code = null, Azure.Compute.Batch.BatchErrorMessage message = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.BatchErrorDetail> values = null) { throw null; }
        public static Azure.Compute.Batch.BatchErrorDetail BatchErrorDetail(string key = null, string value = null) { throw null; }
        public static Azure.Compute.Batch.BatchErrorMessage BatchErrorMessage(string lang = null, string value = null) { throw null; }
        public static Azure.Compute.Batch.BatchJob BatchJob(string id = null, string displayName = null, bool? usesTaskDependencies = default(bool?), string url = null, string eTag = null, System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), System.DateTimeOffset? creationTime = default(System.DateTimeOffset?), Azure.Compute.Batch.BatchJobState? state = default(Azure.Compute.Batch.BatchJobState?), System.DateTimeOffset? stateTransitionTime = default(System.DateTimeOffset?), Azure.Compute.Batch.BatchJobState? previousState = default(Azure.Compute.Batch.BatchJobState?), System.DateTimeOffset? previousStateTransitionTime = default(System.DateTimeOffset?), int? priority = default(int?), bool? allowTaskPreemption = default(bool?), int? maxParallelTasks = default(int?), Azure.Compute.Batch.BatchJobConstraints constraints = null, Azure.Compute.Batch.BatchJobManagerTask jobManagerTask = null, Azure.Compute.Batch.BatchJobPreparationTask jobPreparationTask = null, Azure.Compute.Batch.BatchJobReleaseTask jobReleaseTask = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.EnvironmentSetting> commonEnvironmentSettings = null, Azure.Compute.Batch.BatchPoolInfo poolInfo = null, Azure.Compute.Batch.OnAllBatchTasksComplete? onAllTasksComplete = default(Azure.Compute.Batch.OnAllBatchTasksComplete?), Azure.Compute.Batch.OnBatchTaskFailure? onTaskFailure = default(Azure.Compute.Batch.OnBatchTaskFailure?), Azure.Compute.Batch.BatchJobNetworkConfiguration networkConfiguration = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.MetadataItem> metadata = null, Azure.Compute.Batch.BatchJobExecutionInfo executionInfo = null, Azure.Compute.Batch.BatchJobStatistics stats = null) { throw null; }
        public static Azure.Compute.Batch.BatchJobCreateContent BatchJobCreateContent(string id = null, string displayName = null, bool? usesTaskDependencies = default(bool?), int? priority = default(int?), bool? allowTaskPreemption = default(bool?), int? maxParallelTasks = default(int?), Azure.Compute.Batch.BatchJobConstraints constraints = null, Azure.Compute.Batch.BatchJobManagerTask jobManagerTask = null, Azure.Compute.Batch.BatchJobPreparationTask jobPreparationTask = null, Azure.Compute.Batch.BatchJobReleaseTask jobReleaseTask = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.EnvironmentSetting> commonEnvironmentSettings = null, Azure.Compute.Batch.BatchPoolInfo poolInfo = null, Azure.Compute.Batch.OnAllBatchTasksComplete? onAllTasksComplete = default(Azure.Compute.Batch.OnAllBatchTasksComplete?), Azure.Compute.Batch.OnBatchTaskFailure? onTaskFailure = default(Azure.Compute.Batch.OnBatchTaskFailure?), Azure.Compute.Batch.BatchJobNetworkConfiguration networkConfiguration = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.MetadataItem> metadata = null) { throw null; }
        public static Azure.Compute.Batch.BatchJobExecutionInfo BatchJobExecutionInfo(System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string poolId = null, Azure.Compute.Batch.BatchJobSchedulingError schedulingError = null, string terminationReason = null) { throw null; }
        public static Azure.Compute.Batch.BatchJobPreparationAndReleaseTaskStatus BatchJobPreparationAndReleaseTaskStatus(string poolId = null, string nodeId = null, string nodeUrl = null, Azure.Compute.Batch.BatchJobPreparationTaskExecutionInfo jobPreparationTaskExecutionInfo = null, Azure.Compute.Batch.BatchJobReleaseTaskExecutionInfo jobReleaseTaskExecutionInfo = null) { throw null; }
        public static Azure.Compute.Batch.BatchJobPreparationTaskExecutionInfo BatchJobPreparationTaskExecutionInfo(System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), Azure.Compute.Batch.BatchJobPreparationTaskState state = default(Azure.Compute.Batch.BatchJobPreparationTaskState), string taskRootDirectory = null, string taskRootDirectoryUrl = null, int? exitCode = default(int?), Azure.Compute.Batch.BatchTaskContainerExecutionInfo containerInfo = null, Azure.Compute.Batch.BatchTaskFailureInfo failureInfo = null, int retryCount = 0, System.DateTimeOffset? lastRetryTime = default(System.DateTimeOffset?), Azure.Compute.Batch.BatchTaskExecutionResult? result = default(Azure.Compute.Batch.BatchTaskExecutionResult?)) { throw null; }
        public static Azure.Compute.Batch.BatchJobReleaseTaskExecutionInfo BatchJobReleaseTaskExecutionInfo(System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), Azure.Compute.Batch.BatchJobReleaseTaskState state = default(Azure.Compute.Batch.BatchJobReleaseTaskState), string taskRootDirectory = null, string taskRootDirectoryUrl = null, int? exitCode = default(int?), Azure.Compute.Batch.BatchTaskContainerExecutionInfo containerInfo = null, Azure.Compute.Batch.BatchTaskFailureInfo failureInfo = null, Azure.Compute.Batch.BatchTaskExecutionResult? result = default(Azure.Compute.Batch.BatchTaskExecutionResult?)) { throw null; }
        public static Azure.Compute.Batch.BatchJobSchedule BatchJobSchedule(string id = null, string displayName = null, string url = null, string eTag = null, System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), System.DateTimeOffset? creationTime = default(System.DateTimeOffset?), Azure.Compute.Batch.BatchJobScheduleState? state = default(Azure.Compute.Batch.BatchJobScheduleState?), System.DateTimeOffset? stateTransitionTime = default(System.DateTimeOffset?), Azure.Compute.Batch.BatchJobScheduleState? previousState = default(Azure.Compute.Batch.BatchJobScheduleState?), System.DateTimeOffset? previousStateTransitionTime = default(System.DateTimeOffset?), Azure.Compute.Batch.BatchJobScheduleConfiguration schedule = null, Azure.Compute.Batch.BatchJobSpecification jobSpecification = null, Azure.Compute.Batch.BatchJobScheduleExecutionInfo executionInfo = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.MetadataItem> metadata = null, Azure.Compute.Batch.BatchJobScheduleStatistics stats = null) { throw null; }
        public static Azure.Compute.Batch.BatchJobScheduleCreateContent BatchJobScheduleCreateContent(string id = null, string displayName = null, Azure.Compute.Batch.BatchJobScheduleConfiguration schedule = null, Azure.Compute.Batch.BatchJobSpecification jobSpecification = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.MetadataItem> metadata = null) { throw null; }
        public static Azure.Compute.Batch.BatchJobScheduleExecutionInfo BatchJobScheduleExecutionInfo(System.DateTimeOffset? nextRunTime = default(System.DateTimeOffset?), Azure.Compute.Batch.RecentBatchJob recentJob = null, System.DateTimeOffset? endTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Compute.Batch.BatchJobScheduleStatistics BatchJobScheduleStatistics(string url = null, System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdateTime = default(System.DateTimeOffset), System.TimeSpan userCpuTime = default(System.TimeSpan), System.TimeSpan kernelCpuTime = default(System.TimeSpan), System.TimeSpan wallClockTime = default(System.TimeSpan), long readIOps = (long)0, long writeIOps = (long)0, float readIOGiB = 0f, float writeIOGiB = 0f, long numSucceededTasks = (long)0, long numFailedTasks = (long)0, long numTaskRetries = (long)0, System.TimeSpan waitTime = default(System.TimeSpan)) { throw null; }
        public static Azure.Compute.Batch.BatchJobSchedulingError BatchJobSchedulingError(Azure.Compute.Batch.ErrorCategory category = default(Azure.Compute.Batch.ErrorCategory), string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.NameValuePair> details = null) { throw null; }
        public static Azure.Compute.Batch.BatchJobStatistics BatchJobStatistics(string url = null, System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdateTime = default(System.DateTimeOffset), System.TimeSpan userCpuTime = default(System.TimeSpan), System.TimeSpan kernelCpuTime = default(System.TimeSpan), System.TimeSpan wallClockTime = default(System.TimeSpan), long readIOps = (long)0, long writeIOps = (long)0, float readIOGiB = 0f, float writeIOGiB = 0f, long numSucceededTasks = (long)0, long numFailedTasks = (long)0, long numTaskRetries = (long)0, System.TimeSpan waitTime = default(System.TimeSpan)) { throw null; }
        public static Azure.Compute.Batch.BatchNode BatchNode(string id = null, string url = null, Azure.Compute.Batch.BatchNodeState? state = default(Azure.Compute.Batch.BatchNodeState?), Azure.Compute.Batch.SchedulingState? schedulingState = default(Azure.Compute.Batch.SchedulingState?), System.DateTimeOffset? stateTransitionTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastBootTime = default(System.DateTimeOffset?), System.DateTimeOffset? allocationTime = default(System.DateTimeOffset?), string ipAddress = null, string affinityId = null, string vmSize = null, int? totalTasksRun = default(int?), int? runningTasksCount = default(int?), int? runningTaskSlotsCount = default(int?), int? totalTasksSucceeded = default(int?), System.Collections.Generic.IEnumerable<Azure.Compute.Batch.BatchTaskInfo> recentTasks = null, Azure.Compute.Batch.BatchStartTask startTask = null, Azure.Compute.Batch.BatchStartTaskInfo startTaskInfo = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.BatchCertificateReference> certificateReferences = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.BatchNodeError> errors = null, bool? isDedicated = default(bool?), Azure.Compute.Batch.BatchNodeEndpointConfiguration endpointConfiguration = null, Azure.Compute.Batch.BatchNodeAgentInfo nodeAgentInfo = null, Azure.Compute.Batch.VirtualMachineInfo virtualMachineInfo = null) { throw null; }
        public static Azure.Compute.Batch.BatchNodeAgentInfo BatchNodeAgentInfo(string version = null, System.DateTimeOffset lastUpdateTime = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Compute.Batch.BatchNodeCounts BatchNodeCounts(int creating = 0, int idle = 0, int offline = 0, int preempted = 0, int rebooting = 0, int reimaging = 0, int running = 0, int starting = 0, int startTaskFailed = 0, int leavingPool = 0, int unknown = 0, int unusable = 0, int waitingForStartTask = 0, int deallocated = 0, int deallocating = 0, int total = 0, int upgradingOs = 0) { throw null; }
        public static Azure.Compute.Batch.BatchNodeEndpointConfiguration BatchNodeEndpointConfiguration(System.Collections.Generic.IEnumerable<Azure.Compute.Batch.InboundEndpoint> inboundEndpoints = null) { throw null; }
        public static Azure.Compute.Batch.BatchNodeError BatchNodeError(string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.NameValuePair> errorDetails = null) { throw null; }
        public static Azure.Compute.Batch.BatchNodeFile BatchNodeFile(string name = null, string url = null, bool? isDirectory = default(bool?), Azure.Compute.Batch.FileProperties properties = null) { throw null; }
        public static Azure.Compute.Batch.BatchNodeInfo BatchNodeInfo(string affinityId = null, string nodeUrl = null, string poolId = null, string nodeId = null, string taskRootDirectory = null, string taskRootDirectoryUrl = null) { throw null; }
        public static Azure.Compute.Batch.BatchNodeRemoteLoginSettings BatchNodeRemoteLoginSettings(string remoteLoginIpAddress = null, int remoteLoginPort = 0) { throw null; }
        public static Azure.Compute.Batch.BatchNodeUserCreateContent BatchNodeUserCreateContent(string name = null, bool? isAdmin = default(bool?), System.DateTimeOffset? expiryTime = default(System.DateTimeOffset?), string password = null, string sshPublicKey = null) { throw null; }
        public static Azure.Compute.Batch.BatchNodeVMExtension BatchNodeVMExtension(string provisioningState = null, Azure.Compute.Batch.VMExtension vmExtension = null, Azure.Compute.Batch.VMExtensionInstanceView instanceView = null) { throw null; }
        public static Azure.Compute.Batch.BatchPool BatchPool(string id = null, string displayName = null, string url = null, string eTag = null, System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), System.DateTimeOffset? creationTime = default(System.DateTimeOffset?), Azure.Compute.Batch.BatchPoolState? state = default(Azure.Compute.Batch.BatchPoolState?), System.DateTimeOffset? stateTransitionTime = default(System.DateTimeOffset?), Azure.Compute.Batch.AllocationState? allocationState = default(Azure.Compute.Batch.AllocationState?), System.DateTimeOffset? allocationStateTransitionTime = default(System.DateTimeOffset?), string vmSize = null, Azure.Compute.Batch.VirtualMachineConfiguration virtualMachineConfiguration = null, System.TimeSpan? resizeTimeout = default(System.TimeSpan?), System.Collections.Generic.IEnumerable<Azure.Compute.Batch.ResizeError> resizeErrors = null, System.Collections.Generic.IReadOnlyDictionary<string, string> resourceTags = null, int? currentDedicatedNodes = default(int?), int? currentLowPriorityNodes = default(int?), int? targetDedicatedNodes = default(int?), int? targetLowPriorityNodes = default(int?), bool? enableAutoScale = default(bool?), string autoScaleFormula = null, System.TimeSpan? autoScaleEvaluationInterval = default(System.TimeSpan?), Azure.Compute.Batch.AutoScaleRun autoScaleRun = null, bool? enableInterNodeCommunication = default(bool?), Azure.Compute.Batch.NetworkConfiguration networkConfiguration = null, Azure.Compute.Batch.BatchStartTask startTask = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.BatchCertificateReference> certificateReferences = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.BatchApplicationPackageReference> applicationPackageReferences = null, int? taskSlotsPerNode = default(int?), Azure.Compute.Batch.BatchTaskSchedulingPolicy taskSchedulingPolicy = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.UserAccount> userAccounts = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.MetadataItem> metadata = null, Azure.Compute.Batch.BatchPoolStatistics stats = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.MountConfiguration> mountConfiguration = null, Azure.Compute.Batch.BatchPoolIdentity identity = null, Azure.Compute.Batch.BatchNodeCommunicationMode? targetNodeCommunicationMode = default(Azure.Compute.Batch.BatchNodeCommunicationMode?), Azure.Compute.Batch.BatchNodeCommunicationMode? currentNodeCommunicationMode = default(Azure.Compute.Batch.BatchNodeCommunicationMode?), Azure.Compute.Batch.UpgradePolicy upgradePolicy = null) { throw null; }
        public static Azure.Compute.Batch.BatchPoolCreateContent BatchPoolCreateContent(string id = null, string displayName = null, string vmSize = null, Azure.Compute.Batch.VirtualMachineConfiguration virtualMachineConfiguration = null, System.TimeSpan? resizeTimeout = default(System.TimeSpan?), System.Collections.Generic.IDictionary<string, string> resourceTags = null, int? targetDedicatedNodes = default(int?), int? targetLowPriorityNodes = default(int?), bool? enableAutoScale = default(bool?), string autoScaleFormula = null, System.TimeSpan? autoScaleEvaluationInterval = default(System.TimeSpan?), bool? enableInterNodeCommunication = default(bool?), Azure.Compute.Batch.NetworkConfiguration networkConfiguration = null, Azure.Compute.Batch.BatchStartTask startTask = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.BatchCertificateReference> certificateReferences = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.BatchApplicationPackageReference> applicationPackageReferences = null, int? taskSlotsPerNode = default(int?), Azure.Compute.Batch.BatchTaskSchedulingPolicy taskSchedulingPolicy = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.UserAccount> userAccounts = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.MetadataItem> metadata = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.MountConfiguration> mountConfiguration = null, Azure.Compute.Batch.BatchNodeCommunicationMode? targetNodeCommunicationMode = default(Azure.Compute.Batch.BatchNodeCommunicationMode?), Azure.Compute.Batch.UpgradePolicy upgradePolicy = null) { throw null; }
        public static Azure.Compute.Batch.BatchPoolIdentity BatchPoolIdentity(Azure.Compute.Batch.BatchPoolIdentityType type = default(Azure.Compute.Batch.BatchPoolIdentityType), System.Collections.Generic.IEnumerable<Azure.Compute.Batch.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.Compute.Batch.BatchPoolNodeCounts BatchPoolNodeCounts(string poolId = null, Azure.Compute.Batch.BatchNodeCounts dedicated = null, Azure.Compute.Batch.BatchNodeCounts lowPriority = null) { throw null; }
        public static Azure.Compute.Batch.BatchPoolResourceStatistics BatchPoolResourceStatistics(System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdateTime = default(System.DateTimeOffset), float avgCpuPercentage = 0f, float avgMemoryGiB = 0f, float peakMemoryGiB = 0f, float avgDiskGiB = 0f, float peakDiskGiB = 0f, long diskReadIOps = (long)0, long diskWriteIOps = (long)0, float diskReadGiB = 0f, float diskWriteGiB = 0f, float networkReadGiB = 0f, float networkWriteGiB = 0f) { throw null; }
        public static Azure.Compute.Batch.BatchPoolStatistics BatchPoolStatistics(string url = null, System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdateTime = default(System.DateTimeOffset), Azure.Compute.Batch.BatchPoolUsageStatistics usageStats = null, Azure.Compute.Batch.BatchPoolResourceStatistics resourceStats = null) { throw null; }
        public static Azure.Compute.Batch.BatchPoolUsageMetrics BatchPoolUsageMetrics(string poolId = null, System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset endTime = default(System.DateTimeOffset), string vmSize = null, float totalCoreHours = 0f) { throw null; }
        public static Azure.Compute.Batch.BatchPoolUsageStatistics BatchPoolUsageStatistics(System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdateTime = default(System.DateTimeOffset), System.TimeSpan dedicatedCoreTime = default(System.TimeSpan)) { throw null; }
        public static Azure.Compute.Batch.BatchStartTaskInfo BatchStartTaskInfo(Azure.Compute.Batch.BatchStartTaskState state = default(Azure.Compute.Batch.BatchStartTaskState), System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), int? exitCode = default(int?), Azure.Compute.Batch.BatchTaskContainerExecutionInfo containerInfo = null, Azure.Compute.Batch.BatchTaskFailureInfo failureInfo = null, int retryCount = 0, System.DateTimeOffset? lastRetryTime = default(System.DateTimeOffset?), Azure.Compute.Batch.BatchTaskExecutionResult? result = default(Azure.Compute.Batch.BatchTaskExecutionResult?)) { throw null; }
        public static Azure.Compute.Batch.BatchSubtask BatchSubtask(int? id = default(int?), Azure.Compute.Batch.BatchNodeInfo nodeInfo = null, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), int? exitCode = default(int?), Azure.Compute.Batch.BatchTaskContainerExecutionInfo containerInfo = null, Azure.Compute.Batch.BatchTaskFailureInfo failureInfo = null, Azure.Compute.Batch.BatchSubtaskState? state = default(Azure.Compute.Batch.BatchSubtaskState?), System.DateTimeOffset? stateTransitionTime = default(System.DateTimeOffset?), Azure.Compute.Batch.BatchSubtaskState? previousState = default(Azure.Compute.Batch.BatchSubtaskState?), System.DateTimeOffset? previousStateTransitionTime = default(System.DateTimeOffset?), Azure.Compute.Batch.BatchTaskExecutionResult? result = default(Azure.Compute.Batch.BatchTaskExecutionResult?)) { throw null; }
        public static Azure.Compute.Batch.BatchSupportedImage BatchSupportedImage(string nodeAgentSkuId = null, Azure.Compute.Batch.ImageReference imageReference = null, Azure.Compute.Batch.OSType osType = default(Azure.Compute.Batch.OSType), System.Collections.Generic.IEnumerable<string> capabilities = null, System.DateTimeOffset? batchSupportEndOfLife = default(System.DateTimeOffset?), Azure.Compute.Batch.ImageVerificationType verificationType = default(Azure.Compute.Batch.ImageVerificationType)) { throw null; }
        public static Azure.Compute.Batch.BatchTask BatchTask(string id = null, string displayName = null, string url = null, string eTag = null, System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), System.DateTimeOffset? creationTime = default(System.DateTimeOffset?), Azure.Compute.Batch.ExitConditions exitConditions = null, Azure.Compute.Batch.BatchTaskState? state = default(Azure.Compute.Batch.BatchTaskState?), System.DateTimeOffset? stateTransitionTime = default(System.DateTimeOffset?), Azure.Compute.Batch.BatchTaskState? previousState = default(Azure.Compute.Batch.BatchTaskState?), System.DateTimeOffset? previousStateTransitionTime = default(System.DateTimeOffset?), string commandLine = null, Azure.Compute.Batch.BatchTaskContainerSettings containerSettings = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.ResourceFile> resourceFiles = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.OutputFile> outputFiles = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.EnvironmentSetting> environmentSettings = null, Azure.Compute.Batch.AffinityInfo affinityInfo = null, Azure.Compute.Batch.BatchTaskConstraints constraints = null, int? requiredSlots = default(int?), Azure.Compute.Batch.UserIdentity userIdentity = null, Azure.Compute.Batch.BatchTaskExecutionInfo executionInfo = null, Azure.Compute.Batch.BatchNodeInfo nodeInfo = null, Azure.Compute.Batch.MultiInstanceSettings multiInstanceSettings = null, Azure.Compute.Batch.BatchTaskStatistics stats = null, Azure.Compute.Batch.BatchTaskDependencies dependsOn = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.BatchApplicationPackageReference> applicationPackageReferences = null, Azure.Compute.Batch.AuthenticationTokenSettings authenticationTokenSettings = null) { throw null; }
        public static Azure.Compute.Batch.BatchTaskAddCollectionResult BatchTaskAddCollectionResult(System.Collections.Generic.IEnumerable<Azure.Compute.Batch.BatchTaskAddResult> value = null) { throw null; }
        public static Azure.Compute.Batch.BatchTaskAddResult BatchTaskAddResult(Azure.Compute.Batch.BatchTaskAddStatus status = default(Azure.Compute.Batch.BatchTaskAddStatus), string taskId = null, string eTag = null, System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), string location = null, Azure.Compute.Batch.BatchError error = null) { throw null; }
        public static Azure.Compute.Batch.BatchTaskContainerExecutionInfo BatchTaskContainerExecutionInfo(string containerId = null, string state = null, string error = null) { throw null; }
        public static Azure.Compute.Batch.BatchTaskCounts BatchTaskCounts(int active = 0, int running = 0, int completed = 0, int succeeded = 0, int failed = 0) { throw null; }
        public static Azure.Compute.Batch.BatchTaskCountsResult BatchTaskCountsResult(Azure.Compute.Batch.BatchTaskCounts taskCounts = null, Azure.Compute.Batch.BatchTaskSlotCounts taskSlotCounts = null) { throw null; }
        public static Azure.Compute.Batch.BatchTaskCreateContent BatchTaskCreateContent(string id = null, string displayName = null, Azure.Compute.Batch.ExitConditions exitConditions = null, string commandLine = null, Azure.Compute.Batch.BatchTaskContainerSettings containerSettings = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.ResourceFile> resourceFiles = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.OutputFile> outputFiles = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.EnvironmentSetting> environmentSettings = null, Azure.Compute.Batch.AffinityInfo affinityInfo = null, Azure.Compute.Batch.BatchTaskConstraints constraints = null, int? requiredSlots = default(int?), Azure.Compute.Batch.UserIdentity userIdentity = null, Azure.Compute.Batch.MultiInstanceSettings multiInstanceSettings = null, Azure.Compute.Batch.BatchTaskDependencies dependsOn = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.BatchApplicationPackageReference> applicationPackageReferences = null, Azure.Compute.Batch.AuthenticationTokenSettings authenticationTokenSettings = null) { throw null; }
        public static Azure.Compute.Batch.BatchTaskExecutionInfo BatchTaskExecutionInfo(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), int? exitCode = default(int?), Azure.Compute.Batch.BatchTaskContainerExecutionInfo containerInfo = null, Azure.Compute.Batch.BatchTaskFailureInfo failureInfo = null, int retryCount = 0, System.DateTimeOffset? lastRetryTime = default(System.DateTimeOffset?), int requeueCount = 0, System.DateTimeOffset? lastRequeueTime = default(System.DateTimeOffset?), Azure.Compute.Batch.BatchTaskExecutionResult? result = default(Azure.Compute.Batch.BatchTaskExecutionResult?)) { throw null; }
        public static Azure.Compute.Batch.BatchTaskFailureInfo BatchTaskFailureInfo(Azure.Compute.Batch.ErrorCategory category = default(Azure.Compute.Batch.ErrorCategory), string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.NameValuePair> details = null) { throw null; }
        public static Azure.Compute.Batch.BatchTaskInfo BatchTaskInfo(string taskUrl = null, string jobId = null, string taskId = null, int? subtaskId = default(int?), Azure.Compute.Batch.BatchTaskState taskState = default(Azure.Compute.Batch.BatchTaskState), Azure.Compute.Batch.BatchTaskExecutionInfo executionInfo = null) { throw null; }
        public static Azure.Compute.Batch.BatchTaskSlotCounts BatchTaskSlotCounts(int active = 0, int running = 0, int completed = 0, int succeeded = 0, int failed = 0) { throw null; }
        public static Azure.Compute.Batch.BatchTaskStatistics BatchTaskStatistics(string url = null, System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdateTime = default(System.DateTimeOffset), System.TimeSpan userCpuTime = default(System.TimeSpan), System.TimeSpan kernelCpuTime = default(System.TimeSpan), System.TimeSpan wallClockTime = default(System.TimeSpan), long readIOps = (long)0, long writeIOps = (long)0, float readIOGiB = 0f, float writeIOGiB = 0f, System.TimeSpan waitTime = default(System.TimeSpan)) { throw null; }
        public static Azure.Compute.Batch.DeleteBatchCertificateError DeleteBatchCertificateError(string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.NameValuePair> values = null) { throw null; }
        public static Azure.Compute.Batch.FileProperties FileProperties(System.DateTimeOffset? creationTime = default(System.DateTimeOffset?), System.DateTimeOffset lastModified = default(System.DateTimeOffset), long contentLength = (long)0, string contentType = null, string fileMode = null) { throw null; }
        public static Azure.Compute.Batch.ImageReference ImageReference(string publisher = null, string offer = null, string sku = null, string version = null, string virtualMachineImageId = null, string exactVersion = null, string sharedGalleryImageId = null, string communityGalleryImageId = null) { throw null; }
        public static Azure.Compute.Batch.InboundEndpoint InboundEndpoint(string name = null, Azure.Compute.Batch.InboundEndpointProtocol protocol = default(Azure.Compute.Batch.InboundEndpointProtocol), string publicIpAddress = null, string publicFQDN = null, int frontendPort = 0, int backendPort = 0) { throw null; }
        public static Azure.Compute.Batch.InstanceViewStatus InstanceViewStatus(string code = null, string displayStatus = null, Azure.Compute.Batch.StatusLevelTypes? level = default(Azure.Compute.Batch.StatusLevelTypes?), string message = null, System.DateTimeOffset? time = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Compute.Batch.NameValuePair NameValuePair(string name = null, string value = null) { throw null; }
        public static Azure.Compute.Batch.RecentBatchJob RecentBatchJob(string id = null, string url = null) { throw null; }
        public static Azure.Compute.Batch.ResizeError ResizeError(string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.NameValuePair> values = null) { throw null; }
        public static Azure.Compute.Batch.UploadBatchServiceLogsContent UploadBatchServiceLogsContent(string containerUrl = null, System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), Azure.Compute.Batch.BatchNodeIdentityReference identityReference = null) { throw null; }
        public static Azure.Compute.Batch.UploadBatchServiceLogsResult UploadBatchServiceLogsResult(string virtualDirectoryName = null, int numberOfFilesUploaded = 0) { throw null; }
        public static Azure.Compute.Batch.UserAssignedIdentity UserAssignedIdentity(string resourceId = null, string clientId = null, string principalId = null) { throw null; }
        public static Azure.Compute.Batch.VirtualMachineInfo VirtualMachineInfo(Azure.Compute.Batch.ImageReference imageReference = null, string scaleSetVmResourceId = null) { throw null; }
        public static Azure.Compute.Batch.VMExtensionInstanceView VMExtensionInstanceView(string name = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.InstanceViewStatus> statuses = null, System.Collections.Generic.IEnumerable<Azure.Compute.Batch.InstanceViewStatus> subStatuses = null) { throw null; }
    }
    public partial class ContainerConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ContainerConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ContainerConfiguration>
    {
        public ContainerConfiguration(Azure.Compute.Batch.ContainerType type) { }
        public System.Collections.Generic.IList<string> ContainerImageNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.ContainerRegistryReference> ContainerRegistries { get { throw null; } }
        public Azure.Compute.Batch.ContainerType Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ContainerConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ContainerConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ContainerConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ContainerConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ContainerConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ContainerConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ContainerConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerHostBatchBindMountEntry : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ContainerHostBatchBindMountEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ContainerHostBatchBindMountEntry>
    {
        public ContainerHostBatchBindMountEntry() { }
        public bool? IsReadOnly { get { throw null; } set { } }
        public Azure.Compute.Batch.ContainerHostDataPath? Source { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ContainerHostBatchBindMountEntry System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ContainerHostBatchBindMountEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ContainerHostBatchBindMountEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ContainerHostBatchBindMountEntry System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ContainerHostBatchBindMountEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ContainerHostBatchBindMountEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ContainerHostBatchBindMountEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerHostDataPath : System.IEquatable<Azure.Compute.Batch.ContainerHostDataPath>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerHostDataPath(string value) { throw null; }
        public static Azure.Compute.Batch.ContainerHostDataPath Applications { get { throw null; } }
        public static Azure.Compute.Batch.ContainerHostDataPath JobPrep { get { throw null; } }
        public static Azure.Compute.Batch.ContainerHostDataPath Shared { get { throw null; } }
        public static Azure.Compute.Batch.ContainerHostDataPath Startup { get { throw null; } }
        public static Azure.Compute.Batch.ContainerHostDataPath Task { get { throw null; } }
        public static Azure.Compute.Batch.ContainerHostDataPath VfsMounts { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.ContainerHostDataPath other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.ContainerHostDataPath left, Azure.Compute.Batch.ContainerHostDataPath right) { throw null; }
        public static implicit operator Azure.Compute.Batch.ContainerHostDataPath (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.ContainerHostDataPath left, Azure.Compute.Batch.ContainerHostDataPath right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryReference : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ContainerRegistryReference>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ContainerRegistryReference>
    {
        public ContainerRegistryReference() { }
        public Azure.Compute.Batch.BatchNodeIdentityReference IdentityReference { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string RegistryServer { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ContainerRegistryReference System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ContainerRegistryReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ContainerRegistryReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ContainerRegistryReference System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ContainerRegistryReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ContainerRegistryReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ContainerRegistryReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerType : System.IEquatable<Azure.Compute.Batch.ContainerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerType(string value) { throw null; }
        public static Azure.Compute.Batch.ContainerType CriCompatible { get { throw null; } }
        public static Azure.Compute.Batch.ContainerType DockerCompatible { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.ContainerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.ContainerType left, Azure.Compute.Batch.ContainerType right) { throw null; }
        public static implicit operator Azure.Compute.Batch.ContainerType (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.ContainerType left, Azure.Compute.Batch.ContainerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerWorkingDirectory : System.IEquatable<Azure.Compute.Batch.ContainerWorkingDirectory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerWorkingDirectory(string value) { throw null; }
        public static Azure.Compute.Batch.ContainerWorkingDirectory ContainerImageDefault { get { throw null; } }
        public static Azure.Compute.Batch.ContainerWorkingDirectory TaskWorkingDirectory { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.ContainerWorkingDirectory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.ContainerWorkingDirectory left, Azure.Compute.Batch.ContainerWorkingDirectory right) { throw null; }
        public static implicit operator Azure.Compute.Batch.ContainerWorkingDirectory (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.ContainerWorkingDirectory left, Azure.Compute.Batch.ContainerWorkingDirectory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CreateTaskResult
    {
        internal CreateTaskResult() { }
        public Azure.Compute.Batch.BatchTaskAddResult BatchTaskResult { get { throw null; } }
        public int RetryCount { get { throw null; } }
        public Azure.Compute.Batch.BatchTaskCreateContent Task { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public enum CreateTaskResultStatus
    {
        Success = 0,
        Failure = 1,
        Retry = 2,
    }
    public partial class CreateTasksOptions
    {
        public CreateTasksOptions(int maxDegreeOfParallelism = 1, int maxTimeBetweenCallsInSeconds = 30, Azure.Compute.Batch.ICreateTaskResultHandler createTaskResultHandler = null, bool returnBatchTaskAddResults = false) { }
        public Azure.Compute.Batch.ICreateTaskResultHandler CreateTaskResultHandler { get { throw null; } set { } }
        public int MaxDegreeOfParallelism { get { throw null; } set { } }
        public int MaxTimeBetweenCallsInSeconds { get { throw null; } set { } }
        public bool ReturnBatchTaskAddResults { get { throw null; } set { } }
    }
    public partial class CreateTasksResult
    {
        public CreateTasksResult(System.Collections.Generic.List<Azure.Compute.Batch.BatchTaskAddResult> batchTaskAddResults) { }
        public System.Collections.Generic.List<Azure.Compute.Batch.BatchTaskAddResult> BatchTaskAddResults { get { throw null; } }
        public int Fail { get { throw null; } set { } }
        public int Pass { get { throw null; } set { } }
    }
    public partial class DataDisk : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.DataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.DataDisk>
    {
        public DataDisk(int logicalUnitNumber, int diskSizeGb) { }
        public Azure.Compute.Batch.CachingType? Caching { get { throw null; } set { } }
        public int DiskSizeGb { get { throw null; } set { } }
        public int LogicalUnitNumber { get { throw null; } set { } }
        public Azure.Compute.Batch.StorageAccountType? StorageAccountType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.DataDisk System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.DataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.DataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.DataDisk System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.DataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.DataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.DataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DefaultCreateTaskResultHandler : Azure.Compute.Batch.ICreateTaskResultHandler
    {
        public DefaultCreateTaskResultHandler() { }
        public Azure.Compute.Batch.CreateTaskResultStatus CreateTaskResultHandler(Azure.Compute.Batch.CreateTaskResult addTaskResult, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class DeleteBatchCertificateError : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.DeleteBatchCertificateError>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.DeleteBatchCertificateError>
    {
        internal DeleteBatchCertificateError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.NameValuePair> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.DeleteBatchCertificateError System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.DeleteBatchCertificateError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.DeleteBatchCertificateError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.DeleteBatchCertificateError System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.DeleteBatchCertificateError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.DeleteBatchCertificateError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.DeleteBatchCertificateError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DependencyAction : System.IEquatable<Azure.Compute.Batch.DependencyAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DependencyAction(string value) { throw null; }
        public static Azure.Compute.Batch.DependencyAction Block { get { throw null; } }
        public static Azure.Compute.Batch.DependencyAction Satisfy { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.DependencyAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.DependencyAction left, Azure.Compute.Batch.DependencyAction right) { throw null; }
        public static implicit operator Azure.Compute.Batch.DependencyAction (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.DependencyAction left, Azure.Compute.Batch.DependencyAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffDiskPlacement : System.IEquatable<Azure.Compute.Batch.DiffDiskPlacement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskPlacement(string value) { throw null; }
        public static Azure.Compute.Batch.DiffDiskPlacement CacheDisk { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.DiffDiskPlacement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.DiffDiskPlacement left, Azure.Compute.Batch.DiffDiskPlacement right) { throw null; }
        public static implicit operator Azure.Compute.Batch.DiffDiskPlacement (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.DiffDiskPlacement left, Azure.Compute.Batch.DiffDiskPlacement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiffDiskSettings : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.DiffDiskSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.DiffDiskSettings>
    {
        public DiffDiskSettings() { }
        public Azure.Compute.Batch.DiffDiskPlacement? Placement { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.DiffDiskSettings System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.DiffDiskSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.DiffDiskSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.DiffDiskSettings System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.DiffDiskSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.DiffDiskSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.DiffDiskSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DisableBatchJobOption : System.IEquatable<Azure.Compute.Batch.DisableBatchJobOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DisableBatchJobOption(string value) { throw null; }
        public static Azure.Compute.Batch.DisableBatchJobOption Requeue { get { throw null; } }
        public static Azure.Compute.Batch.DisableBatchJobOption Terminate { get { throw null; } }
        public static Azure.Compute.Batch.DisableBatchJobOption Wait { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.DisableBatchJobOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.DisableBatchJobOption left, Azure.Compute.Batch.DisableBatchJobOption right) { throw null; }
        public static implicit operator Azure.Compute.Batch.DisableBatchJobOption (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.DisableBatchJobOption left, Azure.Compute.Batch.DisableBatchJobOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskEncryptionConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.DiskEncryptionConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.DiskEncryptionConfiguration>
    {
        public DiskEncryptionConfiguration() { }
        public System.Collections.Generic.IList<Azure.Compute.Batch.DiskEncryptionTarget> Targets { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.DiskEncryptionConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.DiskEncryptionConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.DiskEncryptionConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.DiskEncryptionConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.DiskEncryptionConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.DiskEncryptionConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.DiskEncryptionConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskEncryptionTarget : System.IEquatable<Azure.Compute.Batch.DiskEncryptionTarget>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskEncryptionTarget(string value) { throw null; }
        public static Azure.Compute.Batch.DiskEncryptionTarget OsDisk { get { throw null; } }
        public static Azure.Compute.Batch.DiskEncryptionTarget TemporaryDisk { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.DiskEncryptionTarget other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.DiskEncryptionTarget left, Azure.Compute.Batch.DiskEncryptionTarget right) { throw null; }
        public static implicit operator Azure.Compute.Batch.DiskEncryptionTarget (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.DiskEncryptionTarget left, Azure.Compute.Batch.DiskEncryptionTarget right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynamicVNetAssignmentScope : System.IEquatable<Azure.Compute.Batch.DynamicVNetAssignmentScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynamicVNetAssignmentScope(string value) { throw null; }
        public static Azure.Compute.Batch.DynamicVNetAssignmentScope Job { get { throw null; } }
        public static Azure.Compute.Batch.DynamicVNetAssignmentScope None { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.DynamicVNetAssignmentScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.DynamicVNetAssignmentScope left, Azure.Compute.Batch.DynamicVNetAssignmentScope right) { throw null; }
        public static implicit operator Azure.Compute.Batch.DynamicVNetAssignmentScope (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.DynamicVNetAssignmentScope left, Azure.Compute.Batch.DynamicVNetAssignmentScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElevationLevel : System.IEquatable<Azure.Compute.Batch.ElevationLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElevationLevel(string value) { throw null; }
        public static Azure.Compute.Batch.ElevationLevel Admin { get { throw null; } }
        public static Azure.Compute.Batch.ElevationLevel NonAdmin { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.ElevationLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.ElevationLevel left, Azure.Compute.Batch.ElevationLevel right) { throw null; }
        public static implicit operator Azure.Compute.Batch.ElevationLevel (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.ElevationLevel left, Azure.Compute.Batch.ElevationLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnvironmentSetting : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.EnvironmentSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.EnvironmentSetting>
    {
        public EnvironmentSetting(string name) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.EnvironmentSetting System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.EnvironmentSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.EnvironmentSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.EnvironmentSetting System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.EnvironmentSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.EnvironmentSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.EnvironmentSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ErrorCategory : System.IEquatable<Azure.Compute.Batch.ErrorCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ErrorCategory(string value) { throw null; }
        public static Azure.Compute.Batch.ErrorCategory ServerError { get { throw null; } }
        public static Azure.Compute.Batch.ErrorCategory UserError { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.ErrorCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.ErrorCategory left, Azure.Compute.Batch.ErrorCategory right) { throw null; }
        public static implicit operator Azure.Compute.Batch.ErrorCategory (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.ErrorCategory left, Azure.Compute.Batch.ErrorCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExitCodeMapping : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ExitCodeMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ExitCodeMapping>
    {
        public ExitCodeMapping(int code, Azure.Compute.Batch.ExitOptions exitOptions) { }
        public int Code { get { throw null; } set { } }
        public Azure.Compute.Batch.ExitOptions ExitOptions { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ExitCodeMapping System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ExitCodeMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ExitCodeMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ExitCodeMapping System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ExitCodeMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ExitCodeMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ExitCodeMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExitCodeRangeMapping : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ExitCodeRangeMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ExitCodeRangeMapping>
    {
        public ExitCodeRangeMapping(int start, int end, Azure.Compute.Batch.ExitOptions exitOptions) { }
        public int End { get { throw null; } set { } }
        public Azure.Compute.Batch.ExitOptions ExitOptions { get { throw null; } set { } }
        public int Start { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ExitCodeRangeMapping System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ExitCodeRangeMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ExitCodeRangeMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ExitCodeRangeMapping System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ExitCodeRangeMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ExitCodeRangeMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ExitCodeRangeMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExitConditions : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ExitConditions>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ExitConditions>
    {
        public ExitConditions() { }
        public Azure.Compute.Batch.ExitOptions Default { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.ExitCodeRangeMapping> ExitCodeRanges { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.ExitCodeMapping> ExitCodes { get { throw null; } }
        public Azure.Compute.Batch.ExitOptions FileUploadError { get { throw null; } set { } }
        public Azure.Compute.Batch.ExitOptions PreProcessingError { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ExitConditions System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ExitConditions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ExitConditions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ExitConditions System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ExitConditions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ExitConditions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ExitConditions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExitOptions : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ExitOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ExitOptions>
    {
        public ExitOptions() { }
        public Azure.Compute.Batch.DependencyAction? DependencyAction { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchJobAction? JobAction { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ExitOptions System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ExitOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ExitOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ExitOptions System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ExitOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ExitOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ExitOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileProperties : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.FileProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.FileProperties>
    {
        internal FileProperties() { }
        public long ContentLength { get { throw null; } }
        public string ContentType { get { throw null; } }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public string FileMode { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.FileProperties System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.FileProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.FileProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.FileProperties System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.FileProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.FileProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.FileProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HttpHeader : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.HttpHeader>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.HttpHeader>
    {
        public HttpHeader(string name) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.HttpHeader System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.HttpHeader>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.HttpHeader>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.HttpHeader System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.HttpHeader>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.HttpHeader>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.HttpHeader>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial interface ICreateTaskResultHandler
    {
        Azure.Compute.Batch.CreateTaskResultStatus CreateTaskResultHandler(Azure.Compute.Batch.CreateTaskResult addTaskResult, System.Threading.CancellationToken cancellationToken);
    }
    public partial class ImageReference : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ImageReference>
    {
        public ImageReference() { }
        public string CommunityGalleryImageId { get { throw null; } set { } }
        public string ExactVersion { get { throw null; } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string SharedGalleryImageId { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        public string VirtualMachineImageId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ImageReference System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ImageReference System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageVerificationType : System.IEquatable<Azure.Compute.Batch.ImageVerificationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageVerificationType(string value) { throw null; }
        public static Azure.Compute.Batch.ImageVerificationType Unverified { get { throw null; } }
        public static Azure.Compute.Batch.ImageVerificationType Verified { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.ImageVerificationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.ImageVerificationType left, Azure.Compute.Batch.ImageVerificationType right) { throw null; }
        public static implicit operator Azure.Compute.Batch.ImageVerificationType (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.ImageVerificationType left, Azure.Compute.Batch.ImageVerificationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InboundEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.InboundEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.InboundEndpoint>
    {
        internal InboundEndpoint() { }
        public int BackendPort { get { throw null; } }
        public int FrontendPort { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Compute.Batch.InboundEndpointProtocol Protocol { get { throw null; } }
        public string PublicFQDN { get { throw null; } }
        public string PublicIpAddress { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.InboundEndpoint System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.InboundEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.InboundEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.InboundEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.InboundEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.InboundEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.InboundEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InboundEndpointProtocol : System.IEquatable<Azure.Compute.Batch.InboundEndpointProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InboundEndpointProtocol(string value) { throw null; }
        public static Azure.Compute.Batch.InboundEndpointProtocol Tcp { get { throw null; } }
        public static Azure.Compute.Batch.InboundEndpointProtocol Udp { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.InboundEndpointProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.InboundEndpointProtocol left, Azure.Compute.Batch.InboundEndpointProtocol right) { throw null; }
        public static implicit operator Azure.Compute.Batch.InboundEndpointProtocol (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.InboundEndpointProtocol left, Azure.Compute.Batch.InboundEndpointProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InboundNatPool : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.InboundNatPool>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.InboundNatPool>
    {
        public InboundNatPool(string name, Azure.Compute.Batch.InboundEndpointProtocol protocol, int backendPort, int frontendPortRangeStart, int frontendPortRangeEnd) { }
        public int BackendPort { get { throw null; } set { } }
        public int FrontendPortRangeEnd { get { throw null; } set { } }
        public int FrontendPortRangeStart { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.NetworkSecurityGroupRule> NetworkSecurityGroupRules { get { throw null; } }
        public Azure.Compute.Batch.InboundEndpointProtocol Protocol { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.InboundNatPool System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.InboundNatPool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.InboundNatPool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.InboundNatPool System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.InboundNatPool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.InboundNatPool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.InboundNatPool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstanceViewStatus : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.InstanceViewStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.InstanceViewStatus>
    {
        internal InstanceViewStatus() { }
        public string Code { get { throw null; } }
        public string DisplayStatus { get { throw null; } }
        public Azure.Compute.Batch.StatusLevelTypes? Level { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.InstanceViewStatus System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.InstanceViewStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.InstanceViewStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.InstanceViewStatus System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.InstanceViewStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.InstanceViewStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.InstanceViewStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IpAddressProvisioningType : System.IEquatable<Azure.Compute.Batch.IpAddressProvisioningType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IpAddressProvisioningType(string value) { throw null; }
        public static Azure.Compute.Batch.IpAddressProvisioningType BatchManaged { get { throw null; } }
        public static Azure.Compute.Batch.IpAddressProvisioningType NoPublicIpAddresses { get { throw null; } }
        public static Azure.Compute.Batch.IpAddressProvisioningType UserManaged { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.IpAddressProvisioningType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.IpAddressProvisioningType left, Azure.Compute.Batch.IpAddressProvisioningType right) { throw null; }
        public static implicit operator Azure.Compute.Batch.IpAddressProvisioningType (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.IpAddressProvisioningType left, Azure.Compute.Batch.IpAddressProvisioningType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinuxUserConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.LinuxUserConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.LinuxUserConfiguration>
    {
        public LinuxUserConfiguration() { }
        public int? Gid { get { throw null; } set { } }
        public string SshPrivateKey { get { throw null; } set { } }
        public int? Uid { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.LinuxUserConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.LinuxUserConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.LinuxUserConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.LinuxUserConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.LinuxUserConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.LinuxUserConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.LinuxUserConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoginMode : System.IEquatable<Azure.Compute.Batch.LoginMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoginMode(string value) { throw null; }
        public static Azure.Compute.Batch.LoginMode Batch { get { throw null; } }
        public static Azure.Compute.Batch.LoginMode Interactive { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.LoginMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.LoginMode left, Azure.Compute.Batch.LoginMode right) { throw null; }
        public static implicit operator Azure.Compute.Batch.LoginMode (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.LoginMode left, Azure.Compute.Batch.LoginMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedDisk : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ManagedDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ManagedDisk>
    {
        public ManagedDisk() { }
        public Azure.Compute.Batch.VMDiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Compute.Batch.StorageAccountType? StorageAccountType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ManagedDisk System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ManagedDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ManagedDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ManagedDisk System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ManagedDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ManagedDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ManagedDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetadataItem : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.MetadataItem>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.MetadataItem>
    {
        public MetadataItem(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.MetadataItem System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.MetadataItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.MetadataItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.MetadataItem System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.MetadataItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.MetadataItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.MetadataItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MountConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.MountConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.MountConfiguration>
    {
        public MountConfiguration() { }
        public Azure.Compute.Batch.AzureBlobFileSystemConfiguration AzureBlobFileSystemConfiguration { get { throw null; } set { } }
        public Azure.Compute.Batch.AzureFileShareConfiguration AzureFileShareConfiguration { get { throw null; } set { } }
        public Azure.Compute.Batch.CifsMountConfiguration CifsMountConfiguration { get { throw null; } set { } }
        public Azure.Compute.Batch.NfsMountConfiguration NfsMountConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.MountConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.MountConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.MountConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.MountConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.MountConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.MountConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.MountConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultiInstanceSettings : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.MultiInstanceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.MultiInstanceSettings>
    {
        public MultiInstanceSettings(string coordinationCommandLine) { }
        public System.Collections.Generic.IList<Azure.Compute.Batch.ResourceFile> CommonResourceFiles { get { throw null; } }
        public string CoordinationCommandLine { get { throw null; } set { } }
        public int? NumberOfInstances { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.MultiInstanceSettings System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.MultiInstanceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.MultiInstanceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.MultiInstanceSettings System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.MultiInstanceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.MultiInstanceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.MultiInstanceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NameValuePair : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.NameValuePair>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.NameValuePair>
    {
        internal NameValuePair() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.NameValuePair System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.NameValuePair>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.NameValuePair>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.NameValuePair System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.NameValuePair>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.NameValuePair>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.NameValuePair>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.NetworkConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.NetworkConfiguration>
    {
        public NetworkConfiguration() { }
        public Azure.Compute.Batch.DynamicVNetAssignmentScope? DynamicVNetAssignmentScope { get { throw null; } set { } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchPoolEndpointConfiguration EndpointConfiguration { get { throw null; } set { } }
        public Azure.Compute.Batch.PublicIpAddressConfiguration PublicIpAddressConfiguration { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.NetworkConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.NetworkConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.NetworkConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.NetworkConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.NetworkConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.NetworkConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.NetworkConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityGroupRule : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.NetworkSecurityGroupRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.NetworkSecurityGroupRule>
    {
        public NetworkSecurityGroupRule(int priority, Azure.Compute.Batch.NetworkSecurityGroupRuleAccess access, string sourceAddressPrefix) { }
        public Azure.Compute.Batch.NetworkSecurityGroupRuleAccess Access { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
        public string SourceAddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourcePortRanges { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.NetworkSecurityGroupRule System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.NetworkSecurityGroupRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.NetworkSecurityGroupRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.NetworkSecurityGroupRule System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.NetworkSecurityGroupRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.NetworkSecurityGroupRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.NetworkSecurityGroupRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkSecurityGroupRuleAccess : System.IEquatable<Azure.Compute.Batch.NetworkSecurityGroupRuleAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkSecurityGroupRuleAccess(string value) { throw null; }
        public static Azure.Compute.Batch.NetworkSecurityGroupRuleAccess Allow { get { throw null; } }
        public static Azure.Compute.Batch.NetworkSecurityGroupRuleAccess Deny { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.NetworkSecurityGroupRuleAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.NetworkSecurityGroupRuleAccess left, Azure.Compute.Batch.NetworkSecurityGroupRuleAccess right) { throw null; }
        public static implicit operator Azure.Compute.Batch.NetworkSecurityGroupRuleAccess (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.NetworkSecurityGroupRuleAccess left, Azure.Compute.Batch.NetworkSecurityGroupRuleAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NfsMountConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.NfsMountConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.NfsMountConfiguration>
    {
        public NfsMountConfiguration(string source, string relativeMountPath) { }
        public string MountOptions { get { throw null; } set { } }
        public string RelativeMountPath { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.NfsMountConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.NfsMountConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.NfsMountConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.NfsMountConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.NfsMountConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.NfsMountConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.NfsMountConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnAllBatchTasksComplete : System.IEquatable<Azure.Compute.Batch.OnAllBatchTasksComplete>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnAllBatchTasksComplete(string value) { throw null; }
        public static Azure.Compute.Batch.OnAllBatchTasksComplete NoAction { get { throw null; } }
        public static Azure.Compute.Batch.OnAllBatchTasksComplete TerminateJob { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.OnAllBatchTasksComplete other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.OnAllBatchTasksComplete left, Azure.Compute.Batch.OnAllBatchTasksComplete right) { throw null; }
        public static implicit operator Azure.Compute.Batch.OnAllBatchTasksComplete (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.OnAllBatchTasksComplete left, Azure.Compute.Batch.OnAllBatchTasksComplete right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnBatchTaskFailure : System.IEquatable<Azure.Compute.Batch.OnBatchTaskFailure>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnBatchTaskFailure(string value) { throw null; }
        public static Azure.Compute.Batch.OnBatchTaskFailure NoAction { get { throw null; } }
        public static Azure.Compute.Batch.OnBatchTaskFailure PerformExitOptionsJobAction { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.OnBatchTaskFailure other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.OnBatchTaskFailure left, Azure.Compute.Batch.OnBatchTaskFailure right) { throw null; }
        public static implicit operator Azure.Compute.Batch.OnBatchTaskFailure (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.OnBatchTaskFailure left, Azure.Compute.Batch.OnBatchTaskFailure right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OSDisk : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.OSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.OSDisk>
    {
        public OSDisk() { }
        public Azure.Compute.Batch.CachingType? Caching { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.Compute.Batch.DiffDiskSettings EphemeralOSDiskSettings { get { throw null; } set { } }
        public Azure.Compute.Batch.ManagedDisk ManagedDisk { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.OSDisk System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.OSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.OSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.OSDisk System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.OSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.OSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.OSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSType : System.IEquatable<Azure.Compute.Batch.OSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSType(string value) { throw null; }
        public static Azure.Compute.Batch.OSType Linux { get { throw null; } }
        public static Azure.Compute.Batch.OSType Windows { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.OSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.OSType left, Azure.Compute.Batch.OSType right) { throw null; }
        public static implicit operator Azure.Compute.Batch.OSType (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.OSType left, Azure.Compute.Batch.OSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OutputFile : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.OutputFile>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.OutputFile>
    {
        public OutputFile(string filePattern, Azure.Compute.Batch.OutputFileDestination destination, Azure.Compute.Batch.OutputFileUploadConfig uploadOptions) { }
        public Azure.Compute.Batch.OutputFileDestination Destination { get { throw null; } set { } }
        public string FilePattern { get { throw null; } set { } }
        public Azure.Compute.Batch.OutputFileUploadConfig UploadOptions { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.OutputFile System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.OutputFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.OutputFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.OutputFile System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.OutputFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.OutputFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.OutputFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OutputFileBlobContainerDestination : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.OutputFileBlobContainerDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.OutputFileBlobContainerDestination>
    {
        public OutputFileBlobContainerDestination(string containerUrl) { }
        public string ContainerUrl { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchNodeIdentityReference IdentityReference { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.HttpHeader> UploadHeaders { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.OutputFileBlobContainerDestination System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.OutputFileBlobContainerDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.OutputFileBlobContainerDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.OutputFileBlobContainerDestination System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.OutputFileBlobContainerDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.OutputFileBlobContainerDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.OutputFileBlobContainerDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OutputFileDestination : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.OutputFileDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.OutputFileDestination>
    {
        public OutputFileDestination() { }
        public Azure.Compute.Batch.OutputFileBlobContainerDestination Container { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.OutputFileDestination System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.OutputFileDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.OutputFileDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.OutputFileDestination System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.OutputFileDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.OutputFileDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.OutputFileDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OutputFileUploadCondition : System.IEquatable<Azure.Compute.Batch.OutputFileUploadCondition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OutputFileUploadCondition(string value) { throw null; }
        public static Azure.Compute.Batch.OutputFileUploadCondition TaskCompletion { get { throw null; } }
        public static Azure.Compute.Batch.OutputFileUploadCondition TaskFailure { get { throw null; } }
        public static Azure.Compute.Batch.OutputFileUploadCondition TaskSuccess { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.OutputFileUploadCondition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.OutputFileUploadCondition left, Azure.Compute.Batch.OutputFileUploadCondition right) { throw null; }
        public static implicit operator Azure.Compute.Batch.OutputFileUploadCondition (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.OutputFileUploadCondition left, Azure.Compute.Batch.OutputFileUploadCondition right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OutputFileUploadConfig : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.OutputFileUploadConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.OutputFileUploadConfig>
    {
        public OutputFileUploadConfig(Azure.Compute.Batch.OutputFileUploadCondition uploadCondition) { }
        public Azure.Compute.Batch.OutputFileUploadCondition UploadCondition { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.OutputFileUploadConfig System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.OutputFileUploadConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.OutputFileUploadConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.OutputFileUploadConfig System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.OutputFileUploadConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.OutputFileUploadConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.OutputFileUploadConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ParallelOperationsException : System.AggregateException
    {
        internal ParallelOperationsException() { }
        public override string ToString() { throw null; }
    }
    public partial class PublicIpAddressConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.PublicIpAddressConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.PublicIpAddressConfiguration>
    {
        public PublicIpAddressConfiguration() { }
        public System.Collections.Generic.IList<string> IpAddressIds { get { throw null; } }
        public Azure.Compute.Batch.IpAddressProvisioningType? IpAddressProvisioningType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.PublicIpAddressConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.PublicIpAddressConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.PublicIpAddressConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.PublicIpAddressConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.PublicIpAddressConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.PublicIpAddressConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.PublicIpAddressConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecentBatchJob : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.RecentBatchJob>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.RecentBatchJob>
    {
        internal RecentBatchJob() { }
        public string Id { get { throw null; } }
        public string Url { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.RecentBatchJob System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.RecentBatchJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.RecentBatchJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.RecentBatchJob System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.RecentBatchJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.RecentBatchJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.RecentBatchJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResizeError : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ResizeError>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ResizeError>
    {
        internal ResizeError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.NameValuePair> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ResizeError System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ResizeError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ResizeError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ResizeError System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ResizeError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ResizeError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ResizeError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceFile : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ResourceFile>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ResourceFile>
    {
        public ResourceFile() { }
        public string AutoStorageContainerName { get { throw null; } set { } }
        public string BlobPrefix { get { throw null; } set { } }
        public string FileMode { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public string HttpUrl { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchNodeIdentityReference IdentityReference { get { throw null; } set { } }
        public string StorageContainerUrl { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ResourceFile System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ResourceFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ResourceFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ResourceFile System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ResourceFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ResourceFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ResourceFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RollingUpgradePolicy : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.RollingUpgradePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.RollingUpgradePolicy>
    {
        public RollingUpgradePolicy() { }
        public bool? EnableCrossZoneUpgrade { get { throw null; } set { } }
        public int? MaxBatchInstancePercent { get { throw null; } set { } }
        public int? MaxUnhealthyInstancePercent { get { throw null; } set { } }
        public int? MaxUnhealthyUpgradedInstancePercent { get { throw null; } set { } }
        public System.TimeSpan? PauseTimeBetweenBatches { get { throw null; } set { } }
        public bool? PrioritizeUnhealthyInstances { get { throw null; } set { } }
        public bool? RollbackFailedInstancesOnPolicyBreach { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.RollingUpgradePolicy System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.RollingUpgradePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.RollingUpgradePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.RollingUpgradePolicy System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.RollingUpgradePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.RollingUpgradePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.RollingUpgradePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SchedulingState : System.IEquatable<Azure.Compute.Batch.SchedulingState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SchedulingState(string value) { throw null; }
        public static Azure.Compute.Batch.SchedulingState Disabled { get { throw null; } }
        public static Azure.Compute.Batch.SchedulingState Enabled { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.SchedulingState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.SchedulingState left, Azure.Compute.Batch.SchedulingState right) { throw null; }
        public static implicit operator Azure.Compute.Batch.SchedulingState (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.SchedulingState left, Azure.Compute.Batch.SchedulingState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityEncryptionTypes : System.IEquatable<Azure.Compute.Batch.SecurityEncryptionTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityEncryptionTypes(string value) { throw null; }
        public static Azure.Compute.Batch.SecurityEncryptionTypes NonPersistedTPM { get { throw null; } }
        public static Azure.Compute.Batch.SecurityEncryptionTypes VMGuestStateOnly { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.SecurityEncryptionTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.SecurityEncryptionTypes left, Azure.Compute.Batch.SecurityEncryptionTypes right) { throw null; }
        public static implicit operator Azure.Compute.Batch.SecurityEncryptionTypes (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.SecurityEncryptionTypes left, Azure.Compute.Batch.SecurityEncryptionTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.SecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.SecurityProfile>
    {
        public SecurityProfile(bool encryptionAtHost, Azure.Compute.Batch.SecurityTypes securityType, Azure.Compute.Batch.UefiSettings uefiSettings) { }
        public bool EncryptionAtHost { get { throw null; } set { } }
        public Azure.Compute.Batch.SecurityTypes SecurityType { get { throw null; } set { } }
        public Azure.Compute.Batch.UefiSettings UefiSettings { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.SecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.SecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.SecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.SecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.SecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.SecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.SecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityTypes : System.IEquatable<Azure.Compute.Batch.SecurityTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityTypes(string value) { throw null; }
        public static Azure.Compute.Batch.SecurityTypes ConfidentialVM { get { throw null; } }
        public static Azure.Compute.Batch.SecurityTypes TrustedLaunch { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.SecurityTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.SecurityTypes left, Azure.Compute.Batch.SecurityTypes right) { throw null; }
        public static implicit operator Azure.Compute.Batch.SecurityTypes (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.SecurityTypes left, Azure.Compute.Batch.SecurityTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceArtifactReference : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ServiceArtifactReference>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ServiceArtifactReference>
    {
        public ServiceArtifactReference(string id) { }
        public string Id { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ServiceArtifactReference System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ServiceArtifactReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.ServiceArtifactReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.ServiceArtifactReference System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ServiceArtifactReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ServiceArtifactReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.ServiceArtifactReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StatusLevelTypes : System.IEquatable<Azure.Compute.Batch.StatusLevelTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StatusLevelTypes(string value) { throw null; }
        public static Azure.Compute.Batch.StatusLevelTypes Error { get { throw null; } }
        public static Azure.Compute.Batch.StatusLevelTypes Info { get { throw null; } }
        public static Azure.Compute.Batch.StatusLevelTypes Warning { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.StatusLevelTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.StatusLevelTypes left, Azure.Compute.Batch.StatusLevelTypes right) { throw null; }
        public static implicit operator Azure.Compute.Batch.StatusLevelTypes (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.StatusLevelTypes left, Azure.Compute.Batch.StatusLevelTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountType : System.IEquatable<Azure.Compute.Batch.StorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountType(string value) { throw null; }
        public static Azure.Compute.Batch.StorageAccountType PremiumLRS { get { throw null; } }
        public static Azure.Compute.Batch.StorageAccountType StandardLRS { get { throw null; } }
        public static Azure.Compute.Batch.StorageAccountType StandardSSDLRS { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.StorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.StorageAccountType left, Azure.Compute.Batch.StorageAccountType right) { throw null; }
        public static implicit operator Azure.Compute.Batch.StorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.StorageAccountType left, Azure.Compute.Batch.StorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UefiSettings : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UefiSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UefiSettings>
    {
        public UefiSettings() { }
        public bool? SecureBootEnabled { get { throw null; } set { } }
        public bool? VTpmEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.UefiSettings System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UefiSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UefiSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.UefiSettings System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UefiSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UefiSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UefiSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpgradeMode : System.IEquatable<Azure.Compute.Batch.UpgradeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpgradeMode(string value) { throw null; }
        public static Azure.Compute.Batch.UpgradeMode Automatic { get { throw null; } }
        public static Azure.Compute.Batch.UpgradeMode Manual { get { throw null; } }
        public static Azure.Compute.Batch.UpgradeMode Rolling { get { throw null; } }
        public bool Equals(Azure.Compute.Batch.UpgradeMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Compute.Batch.UpgradeMode left, Azure.Compute.Batch.UpgradeMode right) { throw null; }
        public static implicit operator Azure.Compute.Batch.UpgradeMode (string value) { throw null; }
        public static bool operator !=(Azure.Compute.Batch.UpgradeMode left, Azure.Compute.Batch.UpgradeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpgradePolicy : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UpgradePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UpgradePolicy>
    {
        public UpgradePolicy(Azure.Compute.Batch.UpgradeMode mode) { }
        public Azure.Compute.Batch.AutomaticOsUpgradePolicy AutomaticOsUpgradePolicy { get { throw null; } set { } }
        public Azure.Compute.Batch.UpgradeMode Mode { get { throw null; } set { } }
        public Azure.Compute.Batch.RollingUpgradePolicy RollingUpgradePolicy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.UpgradePolicy System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UpgradePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UpgradePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.UpgradePolicy System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UpgradePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UpgradePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UpgradePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UploadBatchServiceLogsContent : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UploadBatchServiceLogsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UploadBatchServiceLogsContent>
    {
        public UploadBatchServiceLogsContent(string containerUrl, System.DateTimeOffset startTime) { }
        public string ContainerUrl { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchNodeIdentityReference IdentityReference { get { throw null; } set { } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.UploadBatchServiceLogsContent System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UploadBatchServiceLogsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UploadBatchServiceLogsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.UploadBatchServiceLogsContent System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UploadBatchServiceLogsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UploadBatchServiceLogsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UploadBatchServiceLogsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UploadBatchServiceLogsResult : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UploadBatchServiceLogsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UploadBatchServiceLogsResult>
    {
        internal UploadBatchServiceLogsResult() { }
        public int NumberOfFilesUploaded { get { throw null; } }
        public string VirtualDirectoryName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.UploadBatchServiceLogsResult System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UploadBatchServiceLogsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UploadBatchServiceLogsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.UploadBatchServiceLogsResult System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UploadBatchServiceLogsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UploadBatchServiceLogsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UploadBatchServiceLogsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserAccount : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UserAccount>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UserAccount>
    {
        public UserAccount(string name, string password) { }
        public Azure.Compute.Batch.ElevationLevel? ElevationLevel { get { throw null; } set { } }
        public Azure.Compute.Batch.LinuxUserConfiguration LinuxUserConfiguration { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public Azure.Compute.Batch.WindowsUserConfiguration WindowsUserConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.UserAccount System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UserAccount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UserAccount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.UserAccount System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UserAccount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UserAccount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UserAccount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserAssignedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UserAssignedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UserAssignedIdentity>
    {
        internal UserAssignedIdentity() { }
        public string ClientId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public string ResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.UserAssignedIdentity System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UserAssignedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UserAssignedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.UserAssignedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UserAssignedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UserAssignedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UserAssignedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserIdentity : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UserIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UserIdentity>
    {
        public UserIdentity() { }
        public Azure.Compute.Batch.AutoUserSpecification AutoUser { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.UserIdentity System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UserIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.UserIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.UserIdentity System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UserIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UserIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.UserIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.VirtualMachineConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.VirtualMachineConfiguration>
    {
        public VirtualMachineConfiguration(Azure.Compute.Batch.ImageReference imageReference, string nodeAgentSkuId) { }
        public Azure.Compute.Batch.ContainerConfiguration ContainerConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.DataDisk> DataDisks { get { throw null; } }
        public Azure.Compute.Batch.DiskEncryptionConfiguration DiskEncryptionConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Compute.Batch.VMExtension> Extensions { get { throw null; } }
        public Azure.Compute.Batch.ImageReference ImageReference { get { throw null; } set { } }
        public string LicenseType { get { throw null; } set { } }
        public string NodeAgentSkuId { get { throw null; } set { } }
        public Azure.Compute.Batch.BatchNodePlacementConfiguration NodePlacementConfiguration { get { throw null; } set { } }
        public Azure.Compute.Batch.OSDisk OsDisk { get { throw null; } set { } }
        public Azure.Compute.Batch.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Compute.Batch.ServiceArtifactReference ServiceArtifactReference { get { throw null; } set { } }
        public Azure.Compute.Batch.WindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.VirtualMachineConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.VirtualMachineConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.VirtualMachineConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.VirtualMachineConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.VirtualMachineConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.VirtualMachineConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.VirtualMachineConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInfo : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.VirtualMachineInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.VirtualMachineInfo>
    {
        internal VirtualMachineInfo() { }
        public Azure.Compute.Batch.ImageReference ImageReference { get { throw null; } }
        public string ScaleSetVmResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.VirtualMachineInfo System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.VirtualMachineInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.VirtualMachineInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.VirtualMachineInfo System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.VirtualMachineInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.VirtualMachineInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.VirtualMachineInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMDiskSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.VMDiskSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.VMDiskSecurityProfile>
    {
        public VMDiskSecurityProfile() { }
        public Azure.Compute.Batch.SecurityEncryptionTypes? SecurityEncryptionType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.VMDiskSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.VMDiskSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.VMDiskSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.VMDiskSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.VMDiskSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.VMDiskSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.VMDiskSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMExtension : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.VMExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.VMExtension>
    {
        public VMExtension(string name, string publisher, string type) { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ProtectedSettings { get { throw null; } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Settings { get { throw null; } }
        public string Type { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.VMExtension System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.VMExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.VMExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.VMExtension System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.VMExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.VMExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.VMExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMExtensionInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.VMExtensionInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.VMExtensionInstanceView>
    {
        internal VMExtensionInstanceView() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Compute.Batch.InstanceViewStatus> SubStatuses { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.VMExtensionInstanceView System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.VMExtensionInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.VMExtensionInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.VMExtensionInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.VMExtensionInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.VMExtensionInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.VMExtensionInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WindowsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.WindowsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.WindowsConfiguration>
    {
        public WindowsConfiguration() { }
        public bool? EnableAutomaticUpdates { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.WindowsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.WindowsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.WindowsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.WindowsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.WindowsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.WindowsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.WindowsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WindowsUserConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.WindowsUserConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.WindowsUserConfiguration>
    {
        public WindowsUserConfiguration() { }
        public Azure.Compute.Batch.LoginMode? LoginMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.WindowsUserConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.WindowsUserConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Compute.Batch.WindowsUserConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Compute.Batch.WindowsUserConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.WindowsUserConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.WindowsUserConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Compute.Batch.WindowsUserConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.Compute.Batch.Custom
{
    public partial class BatchException : System.Exception
    {
        public BatchException(Azure.Compute.Batch.Custom.RequestInformation requestInformation, string message, System.Exception inner) { }
        public Azure.Compute.Batch.Custom.RequestInformation RequestInformation { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public partial class RequestInformation
    {
        public RequestInformation() { }
        public Azure.Compute.Batch.BatchError BatchError { get { throw null; } protected internal set { } }
        public System.Guid? ClientRequestId { get { throw null; } protected internal set { } }
        public System.Net.HttpStatusCode? HttpStatusCode { get { throw null; } protected internal set { } }
        public string HttpStatusMessage { get { throw null; } protected internal set { } }
        public System.TimeSpan? RetryAfter { get { throw null; } protected internal set { } }
        public string ServiceRequestId { get { throw null; } protected internal set { } }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class ComputeBatchClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Compute.Batch.BatchClient, Azure.Compute.Batch.BatchClientOptions> AddBatchClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Compute.Batch.BatchClient, Azure.Compute.Batch.BatchClientOptions> AddBatchClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
