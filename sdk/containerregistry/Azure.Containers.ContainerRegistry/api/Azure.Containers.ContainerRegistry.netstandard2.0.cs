namespace Azure.Containers.ContainerRegistry
{
    public partial class AcrAccessToken
    {
        internal AcrAccessToken() { }
        public string AccessToken { get { throw null; } }
    }
    public partial class AcrRefreshToken
    {
        internal AcrRefreshToken() { }
        public string RefreshToken { get { throw null; } }
    }
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
    public enum ArtifactManifestOrder
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
        public long? SizeInBytes { get { throw null; } }
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
    public enum ArtifactTagOrder
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
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
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteRepository(string repositoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRepositoryAsync(string repositoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.AcrRefreshToken> ExchangeAadAccessTokenForAcrRefreshToken(string service, string tenant = null, string refreshToken = null, string accessToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.AcrRefreshToken>> ExchangeAadAccessTokenForAcrRefreshTokenAsync(string service, string tenant = null, string refreshToken = null, string accessToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.AcrAccessToken> ExchangeAcrRefreshTokenForAcrAccessToken(string service, string scope, string refreshToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.AcrAccessToken>> ExchangeAcrRefreshTokenForAcrAccessTokenAsync(string service, string scope, string refreshToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ContainerRegistryContentClient
    {
        protected ContainerRegistryContentClient() { }
        public ContainerRegistryContentClient(System.Uri endpoint, string repositoryName) { }
        public ContainerRegistryContentClient(System.Uri endpoint, string repositoryName, Azure.Containers.ContainerRegistry.ContainerRegistryClientOptions options) { }
        public ContainerRegistryContentClient(System.Uri endpoint, string repositoryName, Azure.Core.TokenCredential credential) { }
        public ContainerRegistryContentClient(System.Uri endpoint, string repositoryName, Azure.Core.TokenCredential credential, Azure.Containers.ContainerRegistry.ContainerRegistryClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual string RepositoryName { get { throw null; } }
        public virtual Azure.Response DeleteBlob(string digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteBlobAsync(string digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteManifest(string digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteManifestAsync(string digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.DownloadRegistryBlobResult> DownloadBlobContent(string digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.DownloadRegistryBlobResult>> DownloadBlobContentAsync(string digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.DownloadRegistryBlobStreamingResult> DownloadBlobStreaming(string digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.DownloadRegistryBlobStreamingResult>> DownloadBlobStreamingAsync(string digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadBlobTo(string digest, System.IO.Stream destination, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadBlobTo(string digest, string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadBlobToAsync(string digest, System.IO.Stream destination, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadBlobToAsync(string digest, string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.GetManifestResult> GetManifest(string tagOrDigest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.GetManifestResult>> GetManifestAsync(string tagOrDigest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.SetManifestResult> SetManifest(Azure.Containers.ContainerRegistry.OciImageManifest manifest, string tag = null, Azure.Containers.ContainerRegistry.ManifestMediaType? mediaType = default(Azure.Containers.ContainerRegistry.ManifestMediaType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.SetManifestResult> SetManifest(System.BinaryData manifest, string tag = null, Azure.Containers.ContainerRegistry.ManifestMediaType? mediaType = default(Azure.Containers.ContainerRegistry.ManifestMediaType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.SetManifestResult>> SetManifestAsync(Azure.Containers.ContainerRegistry.OciImageManifest manifest, string tag = null, Azure.Containers.ContainerRegistry.ManifestMediaType? mediaType = default(Azure.Containers.ContainerRegistry.ManifestMediaType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.SetManifestResult>> SetManifestAsync(System.BinaryData manifest, string tag = null, Azure.Containers.ContainerRegistry.ManifestMediaType? mediaType = default(Azure.Containers.ContainerRegistry.ManifestMediaType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.UploadRegistryBlobResult> UploadBlob(System.BinaryData content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.UploadRegistryBlobResult> UploadBlob(System.IO.Stream content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.UploadRegistryBlobResult>> UploadBlobAsync(System.BinaryData content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.UploadRegistryBlobResult>> UploadBlobAsync(System.IO.Stream content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ContainerRegistryModelFactory
    {
        public static Azure.Containers.ContainerRegistry.AcrAccessToken AcrAccessToken(string accessToken = null) { throw null; }
        public static Azure.Containers.ContainerRegistry.AcrRefreshToken AcrRefreshToken(string refreshToken = null) { throw null; }
        public static Azure.Containers.ContainerRegistry.ArtifactManifestPlatform ArtifactManifestPlatform(string digest = null, Azure.Containers.ContainerRegistry.ArtifactArchitecture? architecture = default(Azure.Containers.ContainerRegistry.ArtifactArchitecture?), Azure.Containers.ContainerRegistry.ArtifactOperatingSystem? operatingSystem = default(Azure.Containers.ContainerRegistry.ArtifactOperatingSystem?)) { throw null; }
        public static Azure.Containers.ContainerRegistry.ArtifactManifestProperties ArtifactManifestProperties(string registryLoginServer = null, string repositoryName = null, string digest = null, long? sizeInBytes = default(long?), System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), Azure.Containers.ContainerRegistry.ArtifactArchitecture? architecture = default(Azure.Containers.ContainerRegistry.ArtifactArchitecture?), Azure.Containers.ContainerRegistry.ArtifactOperatingSystem? operatingSystem = default(Azure.Containers.ContainerRegistry.ArtifactOperatingSystem?), System.Collections.Generic.IEnumerable<Azure.Containers.ContainerRegistry.ArtifactManifestPlatform> relatedArtifacts = null, System.Collections.Generic.IEnumerable<string> tags = null, bool? canDelete = default(bool?), bool? canWrite = default(bool?), bool? canList = default(bool?), bool? canRead = default(bool?)) { throw null; }
        public static Azure.Containers.ContainerRegistry.ArtifactTagProperties ArtifactTagProperties(string registryLoginServer = null, string repositoryName = null, string name = null, string digest = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), bool? canDelete = default(bool?), bool? canWrite = default(bool?), bool? canList = default(bool?), bool? canRead = default(bool?)) { throw null; }
        public static Azure.Containers.ContainerRegistry.ContainerRepositoryProperties ContainerRepositoryProperties(string registryLoginServer = null, string name = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), int manifestCount = 0, int tagCount = 0, bool? canDelete = default(bool?), bool? canWrite = default(bool?), bool? canList = default(bool?), bool? canRead = default(bool?)) { throw null; }
        public static Azure.Containers.ContainerRegistry.DownloadRegistryBlobResult DownloadRegistryBlobResult(string digest = null, System.BinaryData content = null) { throw null; }
        public static Azure.Containers.ContainerRegistry.GetManifestResult GetManifestResult(string digest = null, string mediaType = null, System.BinaryData manifest = null) { throw null; }
        public static Azure.Containers.ContainerRegistry.SetManifestResult SetManifestResult(string digest = null) { throw null; }
        public static Azure.Containers.ContainerRegistry.UploadRegistryBlobResult UploadRegistryBlobResult(string digest, long sizeInBytes) { throw null; }
    }
    public partial class ContainerRepository
    {
        protected ContainerRepository() { }
        public virtual string Name { get { throw null; } }
        public virtual System.Uri RegistryEndpoint { get { throw null; } }
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.ContainerRegistry.ArtifactManifestProperties> GetAllManifestProperties(Azure.Containers.ContainerRegistry.ArtifactManifestOrder manifestOrder = Azure.Containers.ContainerRegistry.ArtifactManifestOrder.None, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.ContainerRegistry.ArtifactManifestProperties> GetAllManifestPropertiesAsync(Azure.Containers.ContainerRegistry.ArtifactManifestOrder manifestOrder = Azure.Containers.ContainerRegistry.ArtifactManifestOrder.None, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Containers.ContainerRegistry.RegistryArtifact GetArtifact(string tagOrDigest) { throw null; }
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
    public partial class DownloadRegistryBlobResult
    {
        internal DownloadRegistryBlobResult() { }
        public System.BinaryData Content { get { throw null; } }
        public string Digest { get { throw null; } }
    }
    public partial class DownloadRegistryBlobStreamingResult : System.IDisposable
    {
        internal DownloadRegistryBlobStreamingResult() { }
        public System.IO.Stream Content { get { throw null; } }
        public string Digest { get { throw null; } }
        public void Dispose() { }
    }
    public partial class GetManifestResult
    {
        internal GetManifestResult() { }
        public string Digest { get { throw null; } }
        public System.BinaryData Manifest { get { throw null; } }
        public Azure.Containers.ContainerRegistry.ManifestMediaType MediaType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManifestMediaType : System.IEquatable<Azure.Containers.ContainerRegistry.ManifestMediaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public static readonly Azure.Containers.ContainerRegistry.ManifestMediaType DockerManifest;
        public static readonly Azure.Containers.ContainerRegistry.ManifestMediaType OciImageManifest;
        public bool Equals(Azure.Containers.ContainerRegistry.ManifestMediaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerRegistry.ManifestMediaType left, Azure.Containers.ContainerRegistry.ManifestMediaType right) { throw null; }
        public static explicit operator string (Azure.Containers.ContainerRegistry.ManifestMediaType mediaType) { throw null; }
        public static implicit operator Azure.Containers.ContainerRegistry.ManifestMediaType (string mediaType) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerRegistry.ManifestMediaType left, Azure.Containers.ContainerRegistry.ManifestMediaType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OciAnnotations
    {
        public OciAnnotations() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public string Authors { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Uri Documentation { get { throw null; } set { } }
        public string Licenses { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Revision { get { throw null; } set { } }
        public System.Uri Source { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public System.Uri Url { get { throw null; } set { } }
        public string Vendor { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class OciDescriptor
    {
        public OciDescriptor() { }
        public Azure.Containers.ContainerRegistry.OciAnnotations Annotations { get { throw null; } set { } }
        public string Digest { get { throw null; } set { } }
        public string MediaType { get { throw null; } set { } }
        public long? SizeInBytes { get { throw null; } set { } }
    }
    public partial class OciImageManifest
    {
        public OciImageManifest(int schemaVersion) { }
        public Azure.Containers.ContainerRegistry.OciAnnotations Annotations { get { throw null; } set { } }
        public Azure.Containers.ContainerRegistry.OciDescriptor Configuration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerRegistry.OciDescriptor> Layers { get { throw null; } }
        public int SchemaVersion { get { throw null; } set { } }
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
        public virtual Azure.Pageable<Azure.Containers.ContainerRegistry.ArtifactTagProperties> GetAllTagProperties(Azure.Containers.ContainerRegistry.ArtifactTagOrder tagOrder = Azure.Containers.ContainerRegistry.ArtifactTagOrder.None, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.ContainerRegistry.ArtifactTagProperties> GetAllTagPropertiesAsync(Azure.Containers.ContainerRegistry.ArtifactTagOrder tagOrder = Azure.Containers.ContainerRegistry.ArtifactTagOrder.None, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.ArtifactManifestProperties> GetManifestProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.ArtifactManifestProperties>> GetManifestPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.ArtifactTagProperties> GetTagProperties(string tag, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.ArtifactTagProperties>> GetTagPropertiesAsync(string tag, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.Containers.ContainerRegistry.ArtifactTagProperties> GetTagPropertiesCollection(Azure.Containers.ContainerRegistry.ArtifactTagOrder orderBy = Azure.Containers.ContainerRegistry.ArtifactTagOrder.None, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.Containers.ContainerRegistry.ArtifactTagProperties> GetTagPropertiesCollectionAsync(Azure.Containers.ContainerRegistry.ArtifactTagOrder orderBy = Azure.Containers.ContainerRegistry.ArtifactTagOrder.None, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.ArtifactManifestProperties> UpdateManifestProperties(Azure.Containers.ContainerRegistry.ArtifactManifestProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.ArtifactManifestProperties>> UpdateManifestPropertiesAsync(Azure.Containers.ContainerRegistry.ArtifactManifestProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.ArtifactTagProperties> UpdateTagProperties(string tag, Azure.Containers.ContainerRegistry.ArtifactTagProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.ArtifactTagProperties>> UpdateTagPropertiesAsync(string tag, Azure.Containers.ContainerRegistry.ArtifactTagProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SetManifestResult
    {
        internal SetManifestResult() { }
        public string Digest { get { throw null; } }
    }
    public partial class UploadRegistryBlobResult
    {
        internal UploadRegistryBlobResult() { }
        public string Digest { get { throw null; } }
        public long SizeInBytes { get { throw null; } }
    }
}
