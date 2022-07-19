namespace Azure.Template
{
    public partial class ListPetToysResponseClient
    {
        protected ListPetToysResponseClient() { }
        public ListPetToysResponseClient(Azure.Core.TokenCredential credential, System.Uri endpoint = null, Azure.Template.PetStoreServiceClientOptions options = null) { }
        public virtual Azure.Response<Azure.Template.Models.ToyListResults> List(string petId, string nameFilter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Template.Models.ToyListResults>> ListAsync(string petId, string nameFilter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PetsClient
    {
        protected PetsClient() { }
        public PetsClient(int petId, Azure.Core.TokenCredential credential, System.Uri endpoint = null, Azure.Template.PetStoreServiceClientOptions options = null) { }
        public virtual Azure.Response<Azure.Template.Models.Pet> Create(Azure.Template.Models.Pet body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Template.Models.Pet>> CreateAsync(Azure.Template.Models.Pet body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Template.Models.PetListResults> List(string nextLink = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Template.Models.PetListResults>> ListAsync(string nextLink = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Template.Models.Pet> Read(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Template.Models.Pet>> ReadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
namespace Azure.Template.Models
{
    public partial class Pet
    {
        public Pet(string name, int age) { }
        public int Age { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
    }
    public partial class PetListResults
    {
        internal PetListResults() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Template.Models.Pet> Items { get { throw null; } }
        public string NextLink { get { throw null; } }
    }
    public static partial class PetStoreServiceModelFactory
    {
        public static Azure.Template.Models.PetListResults PetListResults(System.Collections.Generic.IEnumerable<Azure.Template.Models.Pet> items = null, string nextLink = null) { throw null; }
        public static Azure.Template.Models.Toy Toy(long id = (long)0, long petId = (long)0, string name = null) { throw null; }
        public static Azure.Template.Models.ToyListResults ToyListResults(System.Collections.Generic.IEnumerable<Azure.Template.Models.Toy> items = null, string nextLink = null) { throw null; }
    }
    public partial class Toy
    {
        internal Toy() { }
        public long Id { get { throw null; } }
        public string Name { get { throw null; } }
        public long PetId { get { throw null; } }
    }
    public partial class ToyListResults
    {
        internal ToyListResults() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Template.Models.Toy> Items { get { throw null; } }
        public string NextLink { get { throw null; } }
    }
}
