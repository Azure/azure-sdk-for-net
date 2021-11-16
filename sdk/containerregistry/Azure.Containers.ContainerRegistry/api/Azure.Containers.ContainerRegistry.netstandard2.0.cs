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
    public enum ArtifactManifestOrderBy
    {
        None = 0,
        LastUpdatedOnDescending = 1,
        LastUpdatedOnAscending = 2,
    }
    public partial class ArtifactManifestPlatform
    {
        internal ArtifactManifestPlatform() { }
        public Azure.Containers.ContainerRegistry.ArtifactArchitecture? Architecture { get { throw null; } }
        public string Digest { get { throw null; } }
        public Azure.Containers.ContainerRegistry.ArtifactOperatingSystem? OperatingSystem { get { throw null; } }
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
        public Azure.Containers.ContainerRegistry.ArtifactOperatingSystem? OperatingSystem { get { throw null; } }
        public string RegistryLoginServer { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Containers.ContainerRegistry.ArtifactManifestPlatform> RelatedArtifacts { get { throw null; } }
        public string RepositoryName { get { throw null; } }
        public long? Size { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Tags { get { throw null; } }
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
    public enum ArtifactTagOrderBy
    {
        None = 0,
        LastUpdatedOnDescending = 1,
        LastUpdatedOnAscending = 2,
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryAudience : System.IEquatable<Azure.Containers.ContainerRegistry.ContainerRegistryAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryAudience(string value) { throw null; }
        public static Azure.Containers.ContainerRegistry.ContainerRegistryAudience AzureResourceManagerChina { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ContainerRegistryAudience AzureResourceManagerGermany { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ContainerRegistryAudience AzureResourceManagerGovernment { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.ContainerRegistryAudience AzureResourceManagerPublicCloud { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerRegistry.ContainerRegistryAudience other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerRegistry.ContainerRegistryAudience left, Azure.Containers.ContainerRegistry.ContainerRegistryAudience right) { throw null; }
        public static implicit operator Azure.Containers.ContainerRegistry.ContainerRegistryAudience (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerRegistry.ContainerRegistryAudience left, Azure.Containers.ContainerRegistry.ContainerRegistryAudience right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryClient
    {
        protected ContainerRegistryClient() { }
        public ContainerRegistryClient(System.Uri endpoint) { }
        public ContainerRegistryClient(System.Uri endpoint, Azure.Containers.ContainerRegistry.ContainerRegistryClientOptions options) { }
        public ContainerRegistryClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ContainerRegistryClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Containers.ContainerRegistry.ContainerRegistryClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Response DeleteRepository(string repositoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRepositoryAsync(string repositoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Containers.ContainerRegistry.RegistryArtifact GetArtifact(string repositoryName, string tagOrDigest) { throw null; }
        public virtual Azure.Containers.ContainerRegistry.ContainerRepository GetRepository(string repositoryName) { throw null; }
        public virtual Azure.Pageable<string> GetRepositoryNames(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetRepositoryNamesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryClientOptions : Azure.Core.ClientOptions
    {
        public ContainerRegistryClientOptions(Azure.Containers.ContainerRegistry.ContainerRegistryClientOptions.ServiceVersion version = Azure.Containers.ContainerRegistry.ContainerRegistryClientOptions.ServiceVersion.V2021_07_01) { }
        public Azure.Containers.ContainerRegistry.ContainerRegistryAudience? Audience { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2021_07_01 = 1,
        }
    }
    public static partial class ContainerRegistryModelFactory
    {
        public static Azure.Containers.ContainerRegistry.ArtifactManifestPlatform ArtifactManifestPlatform(string digest = null, Azure.Containers.ContainerRegistry.ArtifactArchitecture? architecture = default(Azure.Containers.ContainerRegistry.ArtifactArchitecture?), Azure.Containers.ContainerRegistry.ArtifactOperatingSystem? operatingSystem = default(Azure.Containers.ContainerRegistry.ArtifactOperatingSystem?)) { throw null; }
        public static Azure.Containers.ContainerRegistry.ArtifactManifestProperties ArtifactManifestProperties(string registryLoginServer = null, string repositoryName = null, string digest = null, long? size = default(long?), System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), Azure.Containers.ContainerRegistry.ArtifactArchitecture? architecture = default(Azure.Containers.ContainerRegistry.ArtifactArchitecture?), Azure.Containers.ContainerRegistry.ArtifactOperatingSystem? operatingSystem = default(Azure.Containers.ContainerRegistry.ArtifactOperatingSystem?), System.Collections.Generic.IEnumerable<Azure.Containers.ContainerRegistry.ArtifactManifestPlatform> relatedArtifacts = null, System.Collections.Generic.IEnumerable<string> tags = null, bool? canDelete = default(bool?), bool? canWrite = default(bool?), bool? canList = default(bool?), bool? canRead = default(bool?)) { throw null; }
        public static Azure.Containers.ContainerRegistry.ArtifactTagProperties ArtifactTagProperties(string registryLoginServer = null, string repositoryName = null, string name = null, string digest = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), bool? canDelete = default(bool?), bool? canWrite = default(bool?), bool? canList = default(bool?), bool? canRead = default(bool?)) { throw null; }
        public static Azure.Containers.ContainerRegistry.ContainerRepositoryProperties ContainerRepositoryProperties(string registryLoginServer = null, string name = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), int manifestCount = 0, int tagCount = 0, bool? canDelete = default(bool?), bool? canWrite = default(bool?), bool? canList = default(bool?), bool? canRead = default(bool?)) { throw null; }
    }
    public partial class ContainerRepository
    {
        protected ContainerRepository() { }
        public virtual string Name { get { throw null; } }
        public virtual System.Uri RegistryEndpoint { get { throw null; } }
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Containers.ContainerRegistry.RegistryArtifact GetArtifact(string tagOrDigest) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.ContainerRegistry.ArtifactManifestProperties> GetManifestPropertiesCollection(Azure.Containers.ContainerRegistry.ArtifactManifestOrderBy orderBy = Azure.Containers.ContainerRegistry.ArtifactManifestOrderBy.None, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.ContainerRegistry.ArtifactManifestProperties> GetManifestPropertiesCollectionAsync(Azure.Containers.ContainerRegistry.ArtifactManifestOrderBy orderBy = Azure.Containers.ContainerRegistry.ArtifactManifestOrderBy.None, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.ContainerRepositoryProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.ContainerRepositoryProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.ContainerRepositoryProperties> UpdateProperties(Azure.Containers.ContainerRegistry.ContainerRepositoryProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.ContainerRepositoryProperties>> UpdatePropertiesAsync(Azure.Containers.ContainerRegistry.ContainerRepositoryProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRepositoryProperties
    {
        public ContainerRepositoryProperties() { }
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
    }
    public partial class RegistryArtifact
    {
        protected RegistryArtifact() { }
        public virtual string FullyQualifiedReference { get { throw null; } }
        public virtual System.Uri RegistryEndpoint { get { throw null; } }
        public virtual string RepositoryName { get { throw null; } }
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteTag(string tag, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTagAsync(string tag, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.ArtifactManifestProperties> GetManifestProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.ArtifactManifestProperties>> GetManifestPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.ArtifactTagProperties> GetTagProperties(string tag, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.ArtifactTagProperties>> GetTagPropertiesAsync(string tag, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.ContainerRegistry.ArtifactTagProperties> GetTagPropertiesCollection(Azure.Containers.ContainerRegistry.ArtifactTagOrderBy orderBy = Azure.Containers.ContainerRegistry.ArtifactTagOrderBy.None, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.ContainerRegistry.ArtifactTagProperties> GetTagPropertiesCollectionAsync(Azure.Containers.ContainerRegistry.ArtifactTagOrderBy orderBy = Azure.Containers.ContainerRegistry.ArtifactTagOrderBy.None, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.ArtifactManifestProperties> UpdateManifestProperties(Azure.Containers.ContainerRegistry.ArtifactManifestProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.ArtifactManifestProperties>> UpdateManifestPropertiesAsync(Azure.Containers.ContainerRegistry.ArtifactManifestProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.ArtifactTagProperties> UpdateTagProperties(string tag, Azure.Containers.ContainerRegistry.ArtifactTagProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.ArtifactTagProperties>> UpdateTagPropertiesAsync(string tag, Azure.Containers.ContainerRegistry.ArtifactTagProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
