namespace Azure.Template
{
    public partial class MultiVersionClient
    {
        protected MultiVersionClient() { }
        public MultiVersionClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public MultiVersionClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Template.MultiVersionClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response SetEvolvingModel(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetEvolvingModelAsync(Azure.RequestContext context = null) { throw null; }
    }
    public partial class MultiVersionClientOptions : Azure.Core.ClientOptions
    {
        public MultiVersionClientOptions(Azure.Template.MultiVersionClientOptions.ServiceVersion version = Azure.Template.MultiVersionClientOptions.ServiceVersion.V2022_02_02) { }
        public enum ServiceVersion
        {
            V2022_01_01 = 1,
            V2022_02_02 = 2,
        }
    }
}
