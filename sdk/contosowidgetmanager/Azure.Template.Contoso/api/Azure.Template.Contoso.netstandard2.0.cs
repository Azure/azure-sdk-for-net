namespace Azure.Template.Contoso
{
    public partial class ContosoClient
    {
        protected ContosoClient() { }
        public ContosoClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Template.Contoso.ContosoClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class ContosoClientOptions : Azure.Core.ClientOptions
    {
        public ContosoClientOptions(Azure.Template.Contoso.Generated.ContosoClientOptions.ServiceVersion version = Azure.Template.Contoso.Generated.ContosoClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}