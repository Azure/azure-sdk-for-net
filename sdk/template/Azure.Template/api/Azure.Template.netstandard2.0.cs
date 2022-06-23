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
    }
    public partial class ProductsClientOptions : Azure.Core.ClientOptions
    {
        public ProductsClientOptions(Azure.Template.ProductsClientOptions.ServiceVersion version = Azure.Template.ProductsClientOptions.ServiceVersion.V0000_00_00) { }
        public enum ServiceVersion
        {
            V0000_00_00 = 1,
        }
    }
}
namespace Azure.Template.Models
{
    public partial class SecretBundle
    {
        internal SecretBundle() { }
        public string ContentType { get { throw null; } }
        public string Id { get { throw null; } }
        public string Kid { get { throw null; } }
        public bool? Managed { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public string Value { get { throw null; } }
    }
}
