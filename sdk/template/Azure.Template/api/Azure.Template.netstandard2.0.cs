namespace Azure.Template
{
    public partial class MultiClientServiceClientOptions : Azure.Core.ClientOptions
    {
        public MultiClientServiceClientOptions(Azure.Template.MultiClientServiceClientOptions.ServiceVersion version = Azure.Template.MultiClientServiceClientOptions.ServiceVersion.V2022_06_25) { }
        public enum ServiceVersion
        {
            V2022_06_25 = 1,
        }
    }
    public partial class ProductsClient
    {
        protected ProductsClient() { }
        public ProductsClient(Azure.Core.TokenCredential credential) { }
        public ProductsClient(Azure.Core.TokenCredential credential, System.Uri endpoint, Azure.Template.MultiClientServiceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetProduct(int id, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProductAsync(int id, Azure.RequestContext context = null) { throw null; }
    }
    public partial class SpecialProductsClient
    {
        protected SpecialProductsClient() { }
        public SpecialProductsClient(Azure.Core.TokenCredential credential) { }
        public SpecialProductsClient(Azure.Core.TokenCredential credential, System.Uri endpoint, Azure.Template.MultiClientServiceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetSpecialProduct(int id, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSpecialProductAsync(int id, Azure.RequestContext context = null) { throw null; }
    }
}
