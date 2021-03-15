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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostContentSchemaGrantType : System.IEquatable<Azure.Containers.ContainerRegistry.PostContentSchemaGrantType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostContentSchemaGrantType(string value) { throw null; }
        public static Azure.Containers.ContainerRegistry.PostContentSchemaGrantType AccessToken { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.PostContentSchemaGrantType AccessTokenRefreshToken { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.PostContentSchemaGrantType RefreshToken { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerRegistry.PostContentSchemaGrantType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerRegistry.PostContentSchemaGrantType left, Azure.Containers.ContainerRegistry.PostContentSchemaGrantType right) { throw null; }
        public static implicit operator Azure.Containers.ContainerRegistry.PostContentSchemaGrantType (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerRegistry.PostContentSchemaGrantType left, Azure.Containers.ContainerRegistry.PostContentSchemaGrantType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
