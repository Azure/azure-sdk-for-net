namespace Azure.Quantum
{
    public partial class QuantumJobClientOptions : Azure.Core.ClientOptions
    {
        public const Azure.Quantum.QuantumJobClientOptions.ServiceVersion LatestVersion = Azure.Quantum.QuantumJobClientOptions.ServiceVersion.V1Preview;
        public QuantumJobClientOptions(Azure.Quantum.QuantumJobClientOptions.ServiceVersion version = Azure.Quantum.QuantumJobClientOptions.ServiceVersion.V1Preview) { }
        public enum ServiceVersion
        {
            V1Preview = 1,
        }
    }
}
namespace Azure.Quantum.Jobs
{
    public partial class QuantumJobClient
    {
        protected QuantumJobClient() { }
        public QuantumJobClient(string subscriptionId, string resourceGroupName, string workspaceName, string location, Azure.Core.TokenCredential credential = null, Azure.Quantum.QuantumJobClientOptions options = null) { }
        public virtual Azure.Response CancelJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Quantum.Jobs.Models.JobDetails> CreateJob(string jobId, Azure.Quantum.Jobs.Models.JobDetails job, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Quantum.Jobs.Models.JobDetails>> CreateJobAsync(string jobId, Azure.Quantum.Jobs.Models.JobDetails job, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Quantum.Jobs.Models.JobDetails> GetJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Quantum.Jobs.Models.JobDetails>> GetJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Quantum.Jobs.Models.JobDetails> GetJobs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Quantum.Jobs.Models.JobDetails> GetJobsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Quantum.Jobs.Models.ProviderStatus> GetProviderStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Quantum.Jobs.Models.ProviderStatus> GetProviderStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Quantum.Jobs.Models.QuantumJobQuota> GetQuotas(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Quantum.Jobs.Models.QuantumJobQuota> GetQuotasAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Quantum.Jobs.Models.SasUriResponse> GetStorageSasUri(Azure.Quantum.Jobs.Models.BlobDetails blobDetails, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Quantum.Jobs.Models.SasUriResponse>> GetStorageSasUriAsync(Azure.Quantum.Jobs.Models.BlobDetails blobDetails, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.Quantum.Jobs.Models
{
    public partial class BlobDetails
    {
        public BlobDetails(string containerName) { }
        public string BlobName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DimensionScope : System.IEquatable<Azure.Quantum.Jobs.Models.DimensionScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DimensionScope(string value) { throw null; }
        public static Azure.Quantum.Jobs.Models.DimensionScope Subscription { get { throw null; } }
        public static Azure.Quantum.Jobs.Models.DimensionScope Workspace { get { throw null; } }
        public bool Equals(Azure.Quantum.Jobs.Models.DimensionScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Quantum.Jobs.Models.DimensionScope left, Azure.Quantum.Jobs.Models.DimensionScope right) { throw null; }
        public static implicit operator Azure.Quantum.Jobs.Models.DimensionScope (string value) { throw null; }
        public static bool operator !=(Azure.Quantum.Jobs.Models.DimensionScope left, Azure.Quantum.Jobs.Models.DimensionScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ErrorData
    {
        internal ErrorData() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class JobDetails
    {
        public JobDetails(string containerUri, string inputDataFormat, string providerId, string target) { }
        public System.DateTimeOffset? BeginExecutionTime { get { throw null; } }
        public System.DateTimeOffset? CancellationTime { get { throw null; } }
        public string ContainerUri { get { throw null; } set { } }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public System.DateTimeOffset? EndExecutionTime { get { throw null; } }
        public Azure.Quantum.Jobs.Models.ErrorData ErrorData { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public string InputDataFormat { get { throw null; } set { } }
        public string InputDataUri { get { throw null; } set { } }
        public object InputParams { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string OutputDataFormat { get { throw null; } set { } }
        public string OutputDataUri { get { throw null; } set { } }
        public string ProviderId { get { throw null; } set { } }
        public Azure.Quantum.Jobs.Models.JobStatus? Status { get { throw null; } }
        public string Target { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.Quantum.Jobs.Models.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.Quantum.Jobs.Models.JobStatus Cancelled { get { throw null; } }
        public static Azure.Quantum.Jobs.Models.JobStatus Executing { get { throw null; } }
        public static Azure.Quantum.Jobs.Models.JobStatus Failed { get { throw null; } }
        public static Azure.Quantum.Jobs.Models.JobStatus Succeeded { get { throw null; } }
        public static Azure.Quantum.Jobs.Models.JobStatus Waiting { get { throw null; } }
        public bool Equals(Azure.Quantum.Jobs.Models.JobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Quantum.Jobs.Models.JobStatus left, Azure.Quantum.Jobs.Models.JobStatus right) { throw null; }
        public static implicit operator Azure.Quantum.Jobs.Models.JobStatus (string value) { throw null; }
        public static bool operator !=(Azure.Quantum.Jobs.Models.JobStatus left, Azure.Quantum.Jobs.Models.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MeterPeriod : System.IEquatable<Azure.Quantum.Jobs.Models.MeterPeriod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MeterPeriod(string value) { throw null; }
        public static Azure.Quantum.Jobs.Models.MeterPeriod Monthly { get { throw null; } }
        public static Azure.Quantum.Jobs.Models.MeterPeriod None { get { throw null; } }
        public bool Equals(Azure.Quantum.Jobs.Models.MeterPeriod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Quantum.Jobs.Models.MeterPeriod left, Azure.Quantum.Jobs.Models.MeterPeriod right) { throw null; }
        public static implicit operator Azure.Quantum.Jobs.Models.MeterPeriod (string value) { throw null; }
        public static bool operator !=(Azure.Quantum.Jobs.Models.MeterPeriod left, Azure.Quantum.Jobs.Models.MeterPeriod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderAvailability : System.IEquatable<Azure.Quantum.Jobs.Models.ProviderAvailability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderAvailability(string value) { throw null; }
        public static Azure.Quantum.Jobs.Models.ProviderAvailability Available { get { throw null; } }
        public static Azure.Quantum.Jobs.Models.ProviderAvailability Degraded { get { throw null; } }
        public static Azure.Quantum.Jobs.Models.ProviderAvailability Unavailable { get { throw null; } }
        public bool Equals(Azure.Quantum.Jobs.Models.ProviderAvailability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Quantum.Jobs.Models.ProviderAvailability left, Azure.Quantum.Jobs.Models.ProviderAvailability right) { throw null; }
        public static implicit operator Azure.Quantum.Jobs.Models.ProviderAvailability (string value) { throw null; }
        public static bool operator !=(Azure.Quantum.Jobs.Models.ProviderAvailability left, Azure.Quantum.Jobs.Models.ProviderAvailability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProviderStatus
    {
        internal ProviderStatus() { }
        public Azure.Quantum.Jobs.Models.ProviderAvailability? CurrentAvailability { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Quantum.Jobs.Models.TargetStatus> Targets { get { throw null; } }
    }
    public partial class QuantumJobQuota
    {
        internal QuantumJobQuota() { }
        public string Dimension { get { throw null; } }
        public float? Holds { get { throw null; } }
        public float? Limit { get { throw null; } }
        public Azure.Quantum.Jobs.Models.MeterPeriod? Period { get { throw null; } }
        public string ProviderId { get { throw null; } }
        public Azure.Quantum.Jobs.Models.DimensionScope? Scope { get { throw null; } }
        public float? Utilization { get { throw null; } }
    }
    public partial class SasUriResponse
    {
        internal SasUriResponse() { }
        public string SasUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TargetAvailability : System.IEquatable<Azure.Quantum.Jobs.Models.TargetAvailability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TargetAvailability(string value) { throw null; }
        public static Azure.Quantum.Jobs.Models.TargetAvailability Available { get { throw null; } }
        public static Azure.Quantum.Jobs.Models.TargetAvailability Degraded { get { throw null; } }
        public static Azure.Quantum.Jobs.Models.TargetAvailability Unavailable { get { throw null; } }
        public bool Equals(Azure.Quantum.Jobs.Models.TargetAvailability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Quantum.Jobs.Models.TargetAvailability left, Azure.Quantum.Jobs.Models.TargetAvailability right) { throw null; }
        public static implicit operator Azure.Quantum.Jobs.Models.TargetAvailability (string value) { throw null; }
        public static bool operator !=(Azure.Quantum.Jobs.Models.TargetAvailability left, Azure.Quantum.Jobs.Models.TargetAvailability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TargetStatus
    {
        internal TargetStatus() { }
        public long? AverageQueueTime { get { throw null; } }
        public Azure.Quantum.Jobs.Models.TargetAvailability? CurrentAvailability { get { throw null; } }
        public string Id { get { throw null; } }
        public string StatusPage { get { throw null; } }
    }
}
