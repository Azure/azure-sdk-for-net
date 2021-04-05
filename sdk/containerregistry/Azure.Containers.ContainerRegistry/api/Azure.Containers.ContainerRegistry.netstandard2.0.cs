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
        public virtual Azure.Containers.ContainerRegistry.ContainerRepositoryClient GetRepositoryClient(string repository) { throw null; }
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
        public virtual string Registry { get { throw null; } }
        public virtual string Repository { get { throw null; } }
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
        public virtual Azure.Pageable<Azure.Containers.ContainerRegistry.RegistryArtifactProperties> GetRegistryArtifacts(Azure.Containers.ContainerRegistry.GetRegistryArtifactsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.ContainerRegistry.RegistryArtifactProperties> GetRegistryArtifactsAsync(Azure.Containers.ContainerRegistry.GetRegistryArtifactsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.TagProperties> GetTagProperties(string tag, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.TagProperties>> GetTagPropertiesAsync(string tag, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.ContainerRegistry.TagProperties> GetTags(Azure.Containers.ContainerRegistry.GetTagsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.ContainerRegistry.TagProperties> GetTagsAsync(Azure.Containers.ContainerRegistry.GetTagsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.RegistryArtifactProperties> SetManifestProperties(string digest, Azure.Containers.ContainerRegistry.ContentProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.RegistryArtifactProperties>> SetManifestPropertiesAsync(string digest, Azure.Containers.ContainerRegistry.ContentProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.RepositoryProperties> SetProperties(Azure.Containers.ContainerRegistry.ContentProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.RepositoryProperties>> SetPropertiesAsync(Azure.Containers.ContainerRegistry.ContentProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerRegistry.TagProperties> SetTagProperties(string tag, Azure.Containers.ContainerRegistry.ContentProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerRegistry.TagProperties>> SetTagPropertiesAsync(string tag, Azure.Containers.ContainerRegistry.ContentProperties value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class GetRegistryArtifactsOptions
    {
        public GetRegistryArtifactsOptions(Azure.Containers.ContainerRegistry.RegistryArtifactOrderBy orderBy) { }
        public Azure.Containers.ContainerRegistry.RegistryArtifactOrderBy OrderBy { get { throw null; } }
    }
    public partial class GetTagsOptions
    {
        public GetTagsOptions(Azure.Containers.ContainerRegistry.TagOrderBy orderBy) { }
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
namespace Azure.Containers.ContainerRegistry.Protocol
{
    public partial class ContainerRegistryBlobProtocolClient
    {
        protected ContainerRegistryBlobProtocolClient() { }
        protected Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelUpload(Azure.Core.RequestContent requestBody, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelUploadAsync(Azure.Core.RequestContent requestBody, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckBlobExists(Azure.Core.RequestContent requestBody, string name, string digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckBlobExistsAsync(Azure.Core.RequestContent requestBody, string name, string digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckChunkExists(Azure.Core.RequestContent requestBody, string name, string digest, string range, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckChunkExistsAsync(Azure.Core.RequestContent requestBody, string name, string digest, string range, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CompleteUpload(Azure.Core.RequestContent requestBody, string digest, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CompleteUploadAsync(Azure.Core.RequestContent requestBody, string digest, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected Azure.Core.Request CreateCancelUploadRequest(Azure.Core.RequestContent requestBody, string location) { throw null; }
        protected Azure.Core.Request CreateCheckBlobExistsRequest(Azure.Core.RequestContent requestBody, string name, string digest) { throw null; }
        protected Azure.Core.Request CreateCheckChunkExistsRequest(Azure.Core.RequestContent requestBody, string name, string digest, string range) { throw null; }
        protected Azure.Core.Request CreateCompleteUploadRequest(Azure.Core.RequestContent requestBody, string digest, string location) { throw null; }
        protected Azure.Core.Request CreateDeleteBlobRequest(Azure.Core.RequestContent requestBody, string name, string digest) { throw null; }
        protected Azure.Core.Request CreateGetBlobRequest(Azure.Core.RequestContent requestBody, string name, string digest) { throw null; }
        protected Azure.Core.Request CreateGetChunkRequest(Azure.Core.RequestContent requestBody, string name, string digest, string range) { throw null; }
        protected Azure.Core.Request CreateGetUploadStatusRequest(Azure.Core.RequestContent requestBody, string location) { throw null; }
        protected Azure.Core.Request CreateMountBlobRequest(Azure.Core.RequestContent requestBody, string name, string from, string mount) { throw null; }
        protected Azure.Core.Request CreateStartUploadRequest(Azure.Core.RequestContent requestBody, string name) { throw null; }
        protected Azure.Core.Request CreateUploadChunkRequest(Azure.Core.RequestContent requestBody, string location) { throw null; }
        public virtual Azure.Response DeleteBlob(Azure.Core.RequestContent requestBody, string name, string digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteBlobAsync(Azure.Core.RequestContent requestBody, string name, string digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetBlob(Azure.Core.RequestContent requestBody, string name, string digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetBlobAsync(Azure.Core.RequestContent requestBody, string name, string digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetChunk(Azure.Core.RequestContent requestBody, string name, string digest, string range, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetChunkAsync(Azure.Core.RequestContent requestBody, string name, string digest, string range, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUploadStatus(Azure.Core.RequestContent requestBody, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUploadStatusAsync(Azure.Core.RequestContent requestBody, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response MountBlob(Azure.Core.RequestContent requestBody, string name, string from, string mount, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> MountBlobAsync(Azure.Core.RequestContent requestBody, string name, string from, string mount, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StartUpload(Azure.Core.RequestContent requestBody, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartUploadAsync(Azure.Core.RequestContent requestBody, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UploadChunk(Azure.Core.RequestContent requestBody, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadChunkAsync(Azure.Core.RequestContent requestBody, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryProtocolClientOptions : Azure.Core.ClientOptions
    {
        public ContainerRegistryProtocolClientOptions(Azure.Containers.ContainerRegistry.Protocol.ContainerRegistryProtocolClientOptions.ServiceVersion version = Azure.Containers.ContainerRegistry.Protocol.ContainerRegistryProtocolClientOptions.ServiceVersion.V2019_08_15_preview) { }
        public enum ServiceVersion
        {
            V2019_08_15_preview = 1,
        }
    }
}
