namespace Microsoft.Azure.WebJobs
{
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
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute(ResolutionPolicyType=typeof(Microsoft.Azure.WebJobs.Extensions.Tables.ODataFilterResolutionPolicy))]
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
namespace Microsoft.Extensions.Hosting
{
    public static partial class TablesWebJobsBuilderExtensions
    {
        public static Microsoft.Azure.WebJobs.IWebJobsBuilder AddTables(this Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { throw null; }
    }
}
