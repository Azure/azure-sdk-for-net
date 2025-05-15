namespace Azure.Communication.AlphaIds
{
    public partial class AlphaIdsClient
    {
        protected AlphaIdsClient() { }
        public AlphaIdsClient(string connectionString) { }
        public AlphaIdsClient(string connectionString, Azure.Communication.AlphaIds.AlphaIdsClientOptions options) { }
        public AlphaIdsClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.AlphaIds.AlphaIdsClientOptions options = null) { }
        public AlphaIdsClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.AlphaIds.AlphaIdsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.AlphaIds.Models.AlphaIdConfiguration> GetConfiguration(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.AlphaIds.Models.AlphaIdConfiguration>> GetConfigurationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.AlphaIds.Models.AlphaIdConfiguration> UpsertConfiguration(bool enabled, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.AlphaIds.Models.AlphaIdConfiguration>> UpsertConfigurationAsync(bool enabled, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AlphaIdsClientOptions : Azure.Core.ClientOptions
    {
        public AlphaIdsClientOptions(Azure.Communication.AlphaIds.AlphaIdsClientOptions.ServiceVersion version = Azure.Communication.AlphaIds.AlphaIdsClientOptions.ServiceVersion.V2022_09_26_Preview) { }
        public enum ServiceVersion
        {
            V2022_09_26_Preview = 1,
        }
    }
    public partial class AzureCommunicationAlphaIdsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureCommunicationAlphaIdsContext() { }
        public static Azure.Communication.AlphaIds.AzureCommunicationAlphaIdsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
}
namespace Azure.Communication.AlphaIds.Models
{
    public partial class AlphaIdConfiguration
    {
        public AlphaIdConfiguration(bool enabled) { }
        public bool Enabled { get { throw null; } set { } }
    }
}
