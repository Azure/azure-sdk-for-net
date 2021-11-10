namespace Azure.Template.LLC
{
    public partial class TemplateLLCClient
    {
        protected TemplateLLCClient() { }
        public TemplateLLCClient(Azure.Core.TokenCredential credential, System.Uri endpoint = null, Azure.Template.LLC.TemplateLLCClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response NoRequestBodyNoResponseBody(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> NoRequestBodyNoResponseBodyAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response NoRequestBodyResponseBody(int id, int? top = default(int?), int skip = 12, string status = "start", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> NoRequestBodyResponseBodyAsync(int id, int? top = default(int?), int skip = 12, string status = "start", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RequestBodyNoResponseBody(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RequestBodyNoResponseBodyAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RequestBodyResponseBody(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RequestBodyResponseBodyAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class TemplateLLCClientOptions : Azure.Core.ClientOptions
    {
        public TemplateLLCClientOptions(Azure.Template.LLC.TemplateLLCClientOptions.ServiceVersion version = Azure.Template.LLC.TemplateLLCClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}
