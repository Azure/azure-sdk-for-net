namespace Microsoft.Azure.WebJobs
{
    public partial class StorageAccount
    {
        public StorageAccount() { }
        public StorageAccount(Microsoft.Azure.WebJobs.Extensions.Storage.IDelegatingHandlerProvider delegatingHandlerProvider) { }
        public virtual System.Uri BlobEndpoint { get { throw null; } }
        public virtual string Name { get { throw null; } }
        public Microsoft.Azure.Storage.CloudStorageAccount SdkObject { get { throw null; } protected set { } }
        public Microsoft.Azure.Cosmos.Table.CloudStorageAccount TableSdkObject { get { throw null; } protected set { } }
        public virtual Microsoft.Azure.Storage.Queue.CloudQueueClient CreateCloudQueueClient() { throw null; }
        public virtual Microsoft.Azure.Cosmos.Table.CloudTableClient CreateCloudTableClient() { throw null; }
        public virtual bool IsDevelopmentStorageAccount() { throw null; }
        public static Microsoft.Azure.WebJobs.StorageAccount New(Microsoft.Azure.Storage.CloudStorageAccount account, Microsoft.Azure.Cosmos.Table.CloudStorageAccount tableAccount = null, Microsoft.Azure.WebJobs.Extensions.Storage.IDelegatingHandlerProvider delegatingHandlerProvider = null) { throw null; }
        public static Microsoft.Azure.WebJobs.StorageAccount NewFromConnectionString(string accountConnectionString) { throw null; }
    }
    public partial class StorageAccountProvider
    {
        public StorageAccountProvider(Microsoft.Extensions.Configuration.IConfiguration configuration) { }
        public StorageAccountProvider(Microsoft.Extensions.Configuration.IConfiguration configuration, Microsoft.Azure.WebJobs.Extensions.Storage.IDelegatingHandlerProvider delegatingHandlerProvider) { }
        public virtual Microsoft.Azure.WebJobs.StorageAccount Get(string name) { throw null; }
        public Microsoft.Azure.WebJobs.StorageAccount Get(string name, Microsoft.Azure.WebJobs.INameResolver resolver) { throw null; }
        public virtual Microsoft.Azure.WebJobs.StorageAccount GetHost() { throw null; }
    }
    [Microsoft.Azure.WebJobs.ConnectionProviderAttribute(typeof(Microsoft.Azure.WebJobs.StorageAccountAttribute))]
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter | System.AttributeTargets.ReturnValue)]
    [System.Diagnostics.DebuggerDisplayAttribute("{DebuggerDisplay,nq}")]
    public partial class TableAttribute : System.Attribute, Microsoft.Azure.WebJobs.IConnectionProvider
    {
        public TableAttribute(string tableName) { }
        public TableAttribute(string tableName, string partitionKey) { }
        public TableAttribute(string tableName, string partitionKey, string rowKey) { }
        public string Connection { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute(ResolutionPolicyType=typeof(Microsoft.Azure.WebJobs.Host.Bindings.ODataFilterResolutionPolicy))]
        public string Filter { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string PartitionKey { get { throw null; } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string RowKey { get { throw null; } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        [System.ComponentModel.DataAnnotations.RegularExpressionAttribute("^[A-Za-z][A-Za-z0-9]{2,62}$")]
        public string TableName { get { throw null; } }
        public int Take { get { throw null; } set { } }
    }
}
namespace Microsoft.Azure.WebJobs.Extensions.Storage
{
    public partial class AzureStorageWebJobsStartup : Microsoft.Azure.WebJobs.Hosting.IWebJobsStartup
    {
        public AzureStorageWebJobsStartup() { }
        public void Configure(Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { }
    }
    public partial interface IDelegatingHandlerProvider
    {
        System.Net.Http.DelegatingHandler Create();
    }
}
namespace Microsoft.Azure.WebJobs.Host.Protocols
{
    public partial class TableEntityParameterDescriptor : Microsoft.Azure.WebJobs.Host.Protocols.ParameterDescriptor
    {
        public TableEntityParameterDescriptor() { }
        public string AccountName { get { throw null; } set { } }
        public string PartitionKey { get { throw null; } set { } }
        public string RowKey { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    public partial class TableParameterDescriptor : Microsoft.Azure.WebJobs.Host.Protocols.ParameterDescriptor
    {
        public TableParameterDescriptor() { }
        [Newtonsoft.Json.JsonConverterAttribute(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public System.IO.FileAccess Access { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
}
namespace Microsoft.Extensions.Hosting
{
    public static partial class StorageWebJobsBuilderExtensions
    {
        public static Microsoft.Azure.WebJobs.IWebJobsBuilder AddAzureStorage(this Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { throw null; }
    }
}
