namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common
{
    public partial class StorageAccount
    {
        public StorageAccount(string connectionString) { }
        public virtual string Name { get { throw null; } }
        public virtual Azure.Storage.Blobs.BlobServiceClient CreateBlobServiceClient() { throw null; }
        public virtual Azure.Storage.Queues.QueueServiceClient CreateQueueServiceClient() { throw null; }
        public virtual bool IsDevelopmentStorageAccount() { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.Storage.Common.StorageAccount NewFromConnectionString(string accountConnectionString) { throw null; }
    }
    public partial class StorageAccountProvider
    {
        public StorageAccountProvider(Microsoft.Extensions.Configuration.IConfiguration configuration) { }
        public virtual Microsoft.Azure.WebJobs.Extensions.Storage.Common.StorageAccount Get(string name) { throw null; }
        public Microsoft.Azure.WebJobs.Extensions.Storage.Common.StorageAccount Get(string name, Microsoft.Azure.WebJobs.INameResolver resolver) { throw null; }
        public virtual Microsoft.Azure.WebJobs.Extensions.Storage.Common.StorageAccount GetHost() { throw null; }
    }
}
