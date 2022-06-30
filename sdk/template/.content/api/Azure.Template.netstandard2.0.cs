namespace Azure.Template
{
    public partial class TemplateClient
    {
        protected TemplateClient() { }
        public TemplateClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Template.TemplateClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class TemplateClientOptions : Azure.Core.ClientOptions
    {
        public TemplateClientOptions(Azure.Template.Generated.TemplateClientOptions.ServiceVersion version = Azure.Template.Generated.TemplateClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}