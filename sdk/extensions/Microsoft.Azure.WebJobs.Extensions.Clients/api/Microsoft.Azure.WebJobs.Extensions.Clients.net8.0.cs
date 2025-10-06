namespace Microsoft.Azure.WebJobs
{
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter)]
    public partial class AzureClientAttribute : System.Attribute, Microsoft.Azure.WebJobs.IConnectionProvider
    {
        public AzureClientAttribute(string connection) { }
        public string Connection { get { throw null; } set { } }
    }
}
namespace Microsoft.Extensions.Hosting
{
    public static partial class AzureClientsWebJobsBuilderExtensions
    {
        public static Microsoft.Azure.WebJobs.IWebJobsBuilder AddAzureClients(this Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { throw null; }
    }
}
