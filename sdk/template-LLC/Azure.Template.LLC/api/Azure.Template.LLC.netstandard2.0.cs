namespace Azure.Template.LLC
{
    public partial class TemplateServiceClient
    {
        protected TemplateServiceClient() { }
        public TemplateServiceClient(Azure.Core.TokenCredential credential, System.Uri endpoint = null, Azure.Template.LLC.TemplateServiceClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Create(string resourceId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(string resourceId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(string resourceId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Get(string resourceId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(string resourceId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetResources(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetResourcesAsync(Azure.RequestContext context = null) { throw null; }
    }
    public partial class TemplateServiceClientOptions : Azure.Core.ClientOptions
    {
        public TemplateServiceClientOptions(Azure.Template.LLC.TemplateServiceClientOptions.ServiceVersion version = Azure.Template.LLC.TemplateServiceClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}
