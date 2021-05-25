namespace Azure.Containers.ContainerRegistry
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArtifactArchitecture : System.IEquatable<Azure.Containers.ContainerRegistry.ArtifactArchitecture>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArtifactArchitecture(string value) { throw null; }
        public static Azure.Containers.ContainerRegistry.ArtifactArchitecture Amd64 { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactArchitecture Arm { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactArchitecture Arm64 { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactArchitecture I386 { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactArchitecture Mips { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactArchitecture Mips64 { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactArchitecture Mips64Le { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactArchitecture MipsLe { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactArchitecture Ppc64 { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactArchitecture Ppc64Le { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactArchitecture RiscV64 { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactArchitecture S390X { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactArchitecture Wasm { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerRegistry.ArtifactArchitecture other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerRegistry.ArtifactArchitecture left, Azure.Containers.ContainerRegistry.ArtifactArchitecture right) { throw null; }
        public static implicit operator Azure.Containers.ContainerRegistry.ArtifactArchitecture (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerRegistry.ArtifactArchitecture left, Azure.Containers.ContainerRegistry.ArtifactArchitecture right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArtifactManifestProperties
    {
        public ArtifactManifestProperties() { }
        public Azure.Containers.ContainerRegistry.ArtifactArchitecture? Architecture { get { throw null; } }
        public bool? CanDelete { get { throw null; } set { } }
        public bool? CanList { get { throw null; } set { } }
        public bool? CanRead { get { throw null; } set { } }
        public bool? CanWrite { get { throw null; } set { } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Digest { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Containers.ContainerRegistry.ArtifactManifestReference> ManifestReferences { get { throw null; } }
        public Azure.Containers.ContainerRegistry.ArtifactOperatingSystem? OperatingSystem { get { throw null; } }
        public string RegistryLoginServer { get { throw null; } }
        public string RepositoryName { get { throw null; } }
        public long? Size { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Tags { get { throw null; } }
    }
    public partial class ArtifactManifestReference
    {
        internal ArtifactManifestReference() { }
        public Azure.Containers.ContainerRegistry.ArtifactArchitecture Architecture { get { throw null; } }
        public string Digest { get { throw null; } }
        public Azure.Containers.ContainerRegistry.ArtifactOperatingSystem OperatingSystem { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArtifactOperatingSystem : System.IEquatable<Azure.Containers.ContainerRegistry.ArtifactOperatingSystem>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArtifactOperatingSystem(string value) { throw null; }
        public static Azure.Containers.ContainerRegistry.ArtifactOperatingSystem Aix { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactOperatingSystem Android { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactOperatingSystem Darwin { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactOperatingSystem Dragonfly { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactOperatingSystem FreeBsd { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactOperatingSystem Illumos { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactOperatingSystem iOS { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactOperatingSystem JS { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactOperatingSystem Linux { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactOperatingSystem NetBsd { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactOperatingSystem OpenBsd { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactOperatingSystem Plan9 { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactOperatingSystem Solaris { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ArtifactOperatingSystem Windows { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerRegistry.ArtifactOperatingSystem other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerRegistry.ArtifactOperatingSystem left, Azure.Containers.ContainerRegistry.ArtifactOperatingSystem right) { throw null; }
        public static implicit operator Azure.Containers.ContainerRegistry.ArtifactOperatingSystem (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerRegistry.ArtifactOperatingSystem left, Azure.Containers.ContainerRegistry.ArtifactOperatingSystem right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArtifactTagProperties
    {
        public ArtifactTagProperties() { }
        public bool? CanDelete { get { throw null; } set { } }
        public bool? CanList { get { throw null; } set { } }
        public bool? CanRead { get { throw null; } set { } }
        public bool? CanWrite { get { throw null; } set { } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Digest { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public string RegistryLoginServer { get { throw null; } }
        public string RepositoryName { get { throw null; } }
    }
    public partial class ContainerRegistryClient
    {
        protected ContainerRegistryClient() { }
        public ContainerRegistryClient(System.Uri endpoint) { }
        public ContainerRegistryClient(System.Uri endpoint, Azure.Containers.ContainerRegistry.ContainerRegistryClientOptions options) { }
        public ContainerRegistryClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ContainerRegistryClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Containers.ContainerRegistry.ContainerRegistryClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual string LoginServer { get { throw null; } }
        public virtual string Name { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.DeleteRepositoryResult> DeleteRepository(string repositoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.DeleteRepositoryResult>> DeleteRepositoryAsync(string repositoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Containers.ContainerRegistry.RegistryArtifact GetArtifact(string repositoryName, string tagOrDigest) { throw null; }
        public virtual Azure.Containers.ContainerRegistry.ContainerRepository GetRepository(string repositoryName) { throw null; }
        public virtual Azure.Pageable<string> GetRepositoryNames(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetRepositoryNamesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryClientOptions : Azure.Core.ClientOptions
    {
        public ContainerRegistryClientOptions(Azure.Containers.ContainerRegistry.ContainerRegistryClientOptions.ServiceVersion version = Azure.Containers.ContainerRegistry.ContainerRegistryClientOptions.ServiceVersion.V1_0) { }
        public enum ServiceVersion
        {
            V1_0 = 1,
        }
    }
    public partial class ContainerRepository
    {
        protected ContainerRepository() { }
        public virtual string Name { get { throw null; } }
        public virtual System.Uri RegistryEndpoint { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.DeleteRepositoryResult> Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.DeleteRepositoryResult>> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Containers.ContainerRegistry.RegistryArtifact GetArtifact(string tagOrDigest) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.ContainerRegistry.ArtifactManifestProperties> GetManifests(Azure.Containers.ContainerRegistry.ManifestOrderBy orderBy = Azure.Containers.ContainerRegistry.ManifestOrderBy.None, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.ContainerRegistry.ArtifactManifestProperties> GetManifestsAsync(Azure.Containers.ContainerRegistry.ManifestOrderBy orderBy = Azure.Containers.ContainerRegistry.ManifestOrderBy.None, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.RepositoryProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.RepositoryProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.RepositoryProperties> SetProperties(Azure.Containers.ContainerRegistry.RepositoryProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.RepositoryProperties>> SetPropertiesAsync(Azure.Containers.ContainerRegistry.RepositoryProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeleteRepositoryResult
    {
        internal DeleteRepositoryResult() { }
        public System.Collections.Generic.IReadOnlyList<string> DeletedManifests { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DeletedTags { get { throw null; } }
    }
    public enum ManifestOrderBy
    {
        None = 0,
        LastUpdatedOnDescending = 1,
        LastUpdatedOnAscending = 2,
    }
    public partial class RegistryArtifact
    {
        protected RegistryArtifact() { }
        public virtual string FullyQualifiedName { get { throw null; } }
        public virtual System.Uri RegistryEndpoint { get { throw null; } }
        public virtual string RepositoryName { get { throw null; } }
        public virtual string TagOrDigest { get { throw null; } }
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteTag(string tag, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTagAsync(string tag, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.ArtifactManifestProperties> GetManifestProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.ArtifactManifestProperties>> GetManifestPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.ArtifactTagProperties> GetTagProperties(string tag, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.ArtifactTagProperties>> GetTagPropertiesAsync(string tag, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.ContainerRegistry.ArtifactTagProperties> GetTags(Azure.Containers.ContainerRegistry.TagOrderBy orderBy = Azure.Containers.ContainerRegistry.TagOrderBy.None, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.ContainerRegistry.ArtifactTagProperties> GetTagsAsync(Azure.Containers.ContainerRegistry.TagOrderBy orderBy = Azure.Containers.ContainerRegistry.TagOrderBy.None, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.ArtifactManifestProperties> SetManifestProperties(Azure.Containers.ContainerRegistry.ArtifactManifestProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.ArtifactManifestProperties>> SetManifestPropertiesAsync(Azure.Containers.ContainerRegistry.ArtifactManifestProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.ArtifactTagProperties> SetTagProperties(string tag, Azure.Containers.ContainerRegistry.ArtifactTagProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.ArtifactTagProperties>> SetTagPropertiesAsync(string tag, Azure.Containers.ContainerRegistry.ArtifactTagProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RepositoryProperties
    {
        public RepositoryProperties() { }
        public bool? CanDelete { get { throw null; } set { } }
        public bool? CanList { get { throw null; } set { } }
        public bool? CanRead { get { throw null; } set { } }
        public bool? CanWrite { get { throw null; } set { } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public int ManifestCount { get { throw null; } }
        public string Name { get { throw null; } }
        public string RegistryLoginServer { get { throw null; } }
        public int TagCount { get { throw null; } }
        public bool? TeleportEnabled { get { throw null; } set { } }
    }
    public enum TagOrderBy
    {
        None = 0,
        LastUpdatedOnDescending = 1,
        LastUpdatedOnAscending = 2,
    }
}
