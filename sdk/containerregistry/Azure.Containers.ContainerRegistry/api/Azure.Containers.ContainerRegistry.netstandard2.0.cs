namespace Azure.Containers.ContainerRegistry
{
    public partial class ContainerRegistryClient
    {
        protected ContainerRegistryClient() { }
        public ContainerRegistryClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ContainerRegistryClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Containers.ContainerRegistry.ContainerRegistryClientOptions options) { }
        public System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.DeleteRepositoryResult> DeleteRepository(string repository, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.DeleteRepositoryResult>> DeleteRepositoryAsync(string repository, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public ContainerRepositoryClient(System.Uri endpoint, string repository, Azure.Core.TokenCredential credential) { }
        public ContainerRepositoryClient(System.Uri endpoint, string repository, Azure.Core.TokenCredential credential, Azure.Containers.ContainerRegistry.ContainerRegistryClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.DeleteRepositoryResult> Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.DeleteRepositoryResult>> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRegistryArtifact(string digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRegistryArtifactAsync(string digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteTag(string tag, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTagAsync(string tag, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.RepositoryProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.RepositoryProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.RegistryArtifactProperties> GetRegistryArtifactProperties(string tagOrDigest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.RegistryArtifactProperties>> GetRegistryArtifactPropertiesAsync(string tagOrDigest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.ContainerRegistry.RegistryArtifactProperties> GetRegistryArtifacts(Azure.Containers.ContainerRegistry.GetRegistryArtifactOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.ContainerRegistry.RegistryArtifactProperties> GetRegistryArtifactsAsync(Azure.Containers.ContainerRegistry.GetRegistryArtifactOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.TagProperties> GetTagProperties(string tag, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.TagProperties>> GetTagPropertiesAsync(string tag, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.ContainerRegistry.TagProperties> GetTags(Azure.Containers.ContainerRegistry.GetTagOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.ContainerRegistry.TagProperties> GetTagsAsync(Azure.Containers.ContainerRegistry.GetTagOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetManifestProperties(string digest, Azure.Containers.ContainerRegistry.ContentProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetManifestPropertiesAsync(string digest, Azure.Containers.ContainerRegistry.ContentProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DeleteRepositoryResult
    {
        internal DeleteRepositoryResult() { }
        public System.Collections.Generic.IReadOnlyList<string> DeletedRegistryArtifactDigests { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DeletedTags { get { throw null; } }
    }
    public partial class GetRegistryArtifactOptions
    {
        public GetRegistryArtifactOptions(Azure.Containers.ContainerRegistry.RegistryArtifactOrderBy orderBy) { }
        public Azure.Containers.ContainerRegistry.RegistryArtifactOrderBy OrderBy { get { throw null; } }
    }
    public partial class GetTagOptions
    {
        public GetTagOptions(Azure.Containers.ContainerRegistry.TagOrderBy orderBy) { }
        public Azure.Containers.ContainerRegistry.TagOrderBy OrderBy { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegistryArtifactOrderBy : System.IEquatable<Azure.Containers.ContainerRegistry.RegistryArtifactOrderBy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegistryArtifactOrderBy(string value) { throw null; }
        public static Azure.Containers.ContainerRegistry.RegistryArtifactOrderBy LastUpdatedOnAscending { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.RegistryArtifactOrderBy LastUpdatedOnDescending { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerRegistry.RegistryArtifactOrderBy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerRegistry.RegistryArtifactOrderBy left, Azure.Containers.ContainerRegistry.RegistryArtifactOrderBy right) { throw null; }
        public static implicit operator Azure.Containers.ContainerRegistry.RegistryArtifactOrderBy (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerRegistry.RegistryArtifactOrderBy left, Azure.Containers.ContainerRegistry.RegistryArtifactOrderBy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegistryArtifactProperties
    {
        internal RegistryArtifactProperties() { }
        public string CpuArchitecture { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Digest { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public string OperatingSystem { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Containers.ContainerRegistry.RegistryArtifactProperties> RegistryArtifacts { get { throw null; } }
        public string Repository { get { throw null; } }
        public long? Size { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Tags { get { throw null; } }
        public Azure.Containers.ContainerRegistry.ContentProperties WriteableProperties { get { throw null; } }
    }
    public partial class RepositoryProperties
    {
        internal RepositoryProperties() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public int RegistryArtifactCount { get { throw null; } }
        public int TagCount { get { throw null; } }
        public Azure.Containers.ContainerRegistry.ContentProperties WriteableProperties { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TagOrderBy : System.IEquatable<Azure.Containers.ContainerRegistry.TagOrderBy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TagOrderBy(string value) { throw null; }
        public static Azure.Containers.ContainerRegistry.TagOrderBy LastUpdatedOnAscending { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.TagOrderBy LastUpdatedOnDescending { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerRegistry.TagOrderBy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerRegistry.TagOrderBy left, Azure.Containers.ContainerRegistry.TagOrderBy right) { throw null; }
        public static implicit operator Azure.Containers.ContainerRegistry.TagOrderBy (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerRegistry.TagOrderBy left, Azure.Containers.ContainerRegistry.TagOrderBy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TagProperties
    {
        internal TagProperties() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Digest { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public string Repository { get { throw null; } }
        public Azure.Containers.ContainerRegistry.ContentProperties WriteableProperties { get { throw null; } }
    }
}
