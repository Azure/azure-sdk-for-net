namespace Azure.Template
{
    public partial class ProductsClient
    {
        protected ProductsClient() { }
        public ProductsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ProductsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Template.ProductsClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Create(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetProduct(int id, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProductAsync(int id, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ProductsClientOptions : Azure.Core.ClientOptions
    {
        public ProductsClientOptions(Azure.Template.ProductsClientOptions.ServiceVersion version = Azure.Template.ProductsClientOptions.ServiceVersion.V2022_06_20) { }
        public enum ServiceVersion
        {
            V2022_06_20 = 1,
        }
    }
}
