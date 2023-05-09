namespace Azure.Microsoft.Azure.Data.Extensions.Microsoft.Azure.Data.Extensions.Common
{
    public partial class Microsoft.Azure.Data.Extensions.CommonClient
    {
        protected Microsoft.Azure.Data.Extensions.CommonClient() { }
        public Microsoft.Azure.Data.Extensions.CommonClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Microsoft.Azure.Data.Extensions.Microsoft.Azure.Data.Extensions.Common.Microsoft.Azure.Data.Extensions.CommonClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class Microsoft.Azure.Data.Extensions.CommonClientOptions : Azure.Core.ClientOptions
    {
        public Microsoft.Azure.Data.Extensions.CommonClientOptions(Azure.Microsoft.Azure.Data.Extensions.Microsoft.Azure.Data.Extensions.Common.Generated.Microsoft.Azure.Data.Extensions.CommonClientOptions.ServiceVersion version = Azure.Microsoft.Azure.Data.Extensions.Microsoft.Azure.Data.Extensions.Common.Generated.Microsoft.Azure.Data.Extensions.CommonClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}