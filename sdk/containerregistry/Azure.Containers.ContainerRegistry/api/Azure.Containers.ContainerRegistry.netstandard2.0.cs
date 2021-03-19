namespace Azure.Containers.ContainerRegistry
{
    public partial class ContainerRegistryClient
    {
        protected ContainerRegistryClient() { }
        public ContainerRegistryClient(System.Uri endpoint, string username, string password) { }
        public ContainerRegistryClient(System.Uri endpoint, string username, string password, Azure.Containers.ContainerRegistry.ContainerRegistryClientOptions options) { }
        public virtual Azure.Pageable<string> GetRepositories(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetRepositoriesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryClientOptions : Azure.Core.ClientOptions
    {
        public ContainerRegistryClientOptions(Azure.Containers.ContainerRegistry.ContainerRegistryClientOptions.ServiceVersion version = Azure.Containers.ContainerRegistry.ContainerRegistryClientOptions.ServiceVersion.V1_0) { }
        public enum ServiceVersion
        {
            V1_0 = 1,
        }
    }
    public partial class ContainerRepositoryClient
    {
        protected ContainerRepositoryClient() { }
        public ContainerRepositoryClient(System.Uri endpoint, string repository, string username, string password) { }
        public ContainerRepositoryClient(System.Uri endpoint, string repository, string username, string password, Azure.Containers.ContainerRegistry.ContainerRegistryClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.RepositoryProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.RepositoryProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.TagProperties> GetTagProperties(string tag, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.TagProperties>> GetTagPropertiesAsync(string tag, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetProperties(Azure.Containers.ContainerRegistry.ContentProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetPropertiesAsync(Azure.Containers.ContainerRegistry.ContentProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetTagProperties(string tag, Azure.Containers.ContainerRegistry.ContentProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetTagPropertiesAsync(string tag, Azure.Containers.ContainerRegistry.ContentProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContentProperties
    {
        public ContentProperties() { }
        public bool? CanDelete { get { throw null; } set { } }
        public bool? CanList { get { throw null; } set { } }
        public bool? CanRead { get { throw null; } set { } }
        public bool? CanWrite { get { throw null; } set { } }
    }
    public partial class RepositoryProperties
    {
        internal RepositoryProperties() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public string Registry { get { throw null; } }
        public int? RegistryArtifactCount { get { throw null; } }
        public int? TagCount { get { throw null; } }
        public Azure.Containers.ContainerRegistry.ContentProperties WriteableProperties { get { throw null; } }
    }
    public partial class TagProperties
    {
        internal TagProperties() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Digest { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.Containers.ContainerRegistry.ContentProperties ModifiableProperties { get { throw null; } }
        public string Name { get { throw null; } }
        public string Registry { get { throw null; } }
        public string Repository { get { throw null; } }
    }
}
