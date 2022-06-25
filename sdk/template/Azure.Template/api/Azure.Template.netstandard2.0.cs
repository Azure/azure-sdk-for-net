namespace Azure.Template
{
    public partial class ProductsClient
    {
        protected ProductsClient() { }
        public ProductsClient(Azure.Core.TokenCredential credential) { }
        public ProductsClient(Azure.Core.TokenCredential credential, System.Uri endpoint, Azure.Template.ProductsClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetProduct(int id, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProductAsync(int id, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSpecialProduct(int id, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSpecialProductAsync(int id, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ProductsClientOptions : Azure.Core.ClientOptions
    {
        public ProductsClientOptions(Azure.Template.ProductsClientOptions.ServiceVersion version = Azure.Template.ProductsClientOptions.ServiceVersion.V2022_06_25) { }
        public enum ServiceVersion
        {
            V2022_06_25 = 1,
        }
    }
}
