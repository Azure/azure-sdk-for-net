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
        [Microsoft.Azure.WebJobs.Description.BlobNameValidationAttribute]
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
    }
}
namespace Microsoft.Azure.WebJobs.Description
{
    public partial class BlobNameValidationAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        public BlobNameValidationAttribute() { }
        protected override System.ComponentModel.DataAnnotations.ValidationResult IsValid(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext) { throw null; }
        public static bool IsValidBlobName(string blobName, out string errorMessage) { throw null; }
        public static bool IsValidContainerName(string containerName) { throw null; }
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
        public bool CentralizedPoisonQueue { get { throw null; } set { } }
        public string Format() { throw null; }
    }
}
namespace Microsoft.Extensions.Hosting
{
    public static partial class StorageBlobsWebJobsBuilderExtensions
    {
        public static Microsoft.Azure.WebJobs.IWebJobsBuilder AddAzureStorageBlobs(this Microsoft.Azure.WebJobs.IWebJobsBuilder builder, System.Action<Microsoft.Azure.WebJobs.Host.BlobsOptions> configureBlobs = null) { throw null; }
    }
}
