namespace Azure.Template
{
    public partial class ListPetToysResponseClient
    {
        protected ListPetToysResponseClient() { }
        public ListPetToysResponseClient(Azure.Core.TokenCredential credential) { }
        public ListPetToysResponseClient(Azure.Core.TokenCredential credential, System.Uri endpoint, Azure.Template.PetStoreServiceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetListPetToysResponses(string petId, string nameFilter, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetListPetToysResponsesAsync(string petId, string nameFilter, Azure.RequestContext context = null) { throw null; }
    }
    public partial class PetsClient
    {
        protected PetsClient() { }
        public PetsClient(int petId, Azure.Core.TokenCredential credential) { }
        public PetsClient(int petId, Azure.Core.TokenCredential credential, System.Uri endpoint, Azure.Template.PetStoreServiceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Create(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetPets(string nextLink = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPetsAsync(string nextLink = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Read(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReadAsync(Azure.RequestContext context = null) { throw null; }
    }
    public partial class PetStoreServiceClientOptions : Azure.Core.ClientOptions
    {
        public PetStoreServiceClientOptions(Azure.Template.PetStoreServiceClientOptions.ServiceVersion version = Azure.Template.PetStoreServiceClientOptions.ServiceVersion.V2021_03_25) { }
        public enum ServiceVersion
        {
            V2021_03_25 = 1,
        }
    }
}
