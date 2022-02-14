namespace Azure.ServiceTemplate.Template
{
    public partial class TemplateClient
    {
        protected TemplateClient() { }
        public TemplateClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Template.Generated.TemplateServiceClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class TemplateClientOptions : Azure.Core.ClientOptions
    {
        public TemplateClientOptions(Azure.Template.Generated.TemplateServiceClientOptions.ServiceVersion version = Azure.Template.Generated.TemplateServiceClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}
