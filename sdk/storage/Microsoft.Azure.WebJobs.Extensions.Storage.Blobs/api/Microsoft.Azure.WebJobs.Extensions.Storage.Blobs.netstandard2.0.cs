namespace Microsoft.Azure.WebJobs
{
    [Microsoft.Azure.WebJobs.ConnectionProviderAttribute(typeof(Microsoft.Azure.WebJobs.StorageAccountAttribute))]
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter | System.AttributeTargets.ReturnValue)]
    [System.Diagnostics.DebuggerDisplayAttribute("{BlobPath,nq}")]
    public sealed partial class BlobAttribute : System.Attribute, Microsoft.Azure.WebJobs.IConnectionProvider
    {
        public BlobAttribute(string blobPath) { }
        public BlobAttribute(string blobPath, System.IO.FileAccess access) { }
        public System.IO.FileAccess? Access { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string BlobPath { get { throw null; } }
        public string Connection { get { throw null; } set { } }
    }
    [Microsoft.Azure.WebJobs.ConnectionProviderAttribute(typeof(Microsoft.Azure.WebJobs.StorageAccountAttribute))]
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter)]
    [System.Diagnostics.DebuggerDisplayAttribute("{BlobPath,nq}")]
    public sealed partial class BlobTriggerAttribute : System.Attribute, Microsoft.Azure.WebJobs.IConnectionProvider
    {
        public BlobTriggerAttribute(string blobPath) { }
        public string BlobPath { get { throw null; } }
        public string Connection { get { throw null; } set { } }
        public Microsoft.Azure.WebJobs.BlobTriggerSource Source { get { throw null; } set { } }
    }
    public enum BlobTriggerSource
    {
        LogsAndContainerScan = 0,
        EventGrid = 1,
    }
}
namespace Microsoft.Azure.WebJobs.Extensions.Storage
{
    public partial class AzureStorageBlobsWebJobsStartup : Microsoft.Azure.WebJobs.Hosting.IWebJobsStartup
    {
        public AzureStorageBlobsWebJobsStartup() { }
        public void Configure(Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { }
    }
}
namespace Microsoft.Azure.WebJobs.Host
{
    public partial class BlobsOptions : Microsoft.Azure.WebJobs.Hosting.IOptionsFormatter
    {
        public BlobsOptions() { }
        public int MaxDegreeOfParallelism { get { throw null; } set { } }
        public int PoisonBlobThreshold { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        string Microsoft.Azure.WebJobs.Hosting.IOptionsFormatter.Format() { throw null; }
    }
}
namespace Microsoft.Extensions.Hosting
{
    public static partial class StorageBlobsWebJobsBuilderExtensions
    {
        public static Microsoft.Azure.WebJobs.IWebJobsBuilder AddAzureStorageBlobs(this Microsoft.Azure.WebJobs.IWebJobsBuilder builder, System.Action<Microsoft.Azure.WebJobs.Host.BlobsOptions> configureBlobs = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Microsoft.Azure.WebJobs.IWebJobsBuilder AddAzureStorageBlobsScaleForTrigger(this Microsoft.Azure.WebJobs.IWebJobsBuilder builder, Microsoft.Azure.WebJobs.Host.Scale.TriggerMetadata triggerMetadata) { throw null; }
    }
}
