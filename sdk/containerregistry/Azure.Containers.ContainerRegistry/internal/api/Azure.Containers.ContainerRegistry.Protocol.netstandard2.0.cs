namespace Azure.Containers.ContainerRegistry.Protocol
{
    public partial class AuthenticationClient
    {
        protected AuthenticationClient() { }
        protected Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        protected Azure.Core.Request CreateExchangeAadAccessTokenForAcrRefreshTokenRequest(Azure.Core.RequestContent requestBody) { throw null; }
        protected Azure.Core.Request CreateExchangeAcrRefreshTokenForAcrAccessTokenRequest(Azure.Core.RequestContent requestBody) { throw null; }
        public virtual Azure.Response ExchangeAadAccessTokenForAcrRefreshToken(Azure.Core.RequestContent requestBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExchangeAadAccessTokenForAcrRefreshTokenAsync(Azure.Core.RequestContent requestBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ExchangeAcrRefreshTokenForAcrAccessToken(Azure.Core.RequestContent requestBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExchangeAcrRefreshTokenForAcrAccessTokenAsync(Azure.Core.RequestContent requestBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
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
    public partial class ContainerRegistryClient
    {
        protected ContainerRegistryClient() { }
        protected Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CheckDockerV2Support(Azure.Core.RequestContent requestBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckDockerV2SupportAsync(Azure.Core.RequestContent requestBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected Azure.Core.Request CreateCheckDockerV2SupportRequest(Azure.Core.RequestContent requestBody) { throw null; }
        protected Azure.Core.Request CreateDeleteRepositoryRequest(Azure.Core.RequestContent requestBody, string name) { throw null; }
        protected Azure.Core.Request CreateGetRepositoriesRequest(Azure.Core.RequestContent requestBody, string last = null, int? n = default(int?)) { throw null; }
        public virtual Azure.Response DeleteRepository(Azure.Core.RequestContent requestBody, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRepositoryAsync(Azure.Core.RequestContent requestBody, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRepositories(Azure.Core.RequestContent requestBody, string last = null, int? n = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRepositoriesAsync(Azure.Core.RequestContent requestBody, string last = null, int? n = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryProtocolClientOptions : Azure.Core.ClientOptions
    {
        public ContainerRegistryProtocolClientOptions(Azure.Containers.ContainerRegistry.Protocol.ContainerRegistryProtocolClientOptions.ServiceVersion version = Azure.Containers.ContainerRegistry.Protocol.ContainerRegistryProtocolClientOptions.ServiceVersion.V2019_08_15_preview) { }
        public enum ServiceVersion
        {
            V2019_08_15_preview = 1,
        }
    }
    public partial class ContainerRegistryRepositoryClient
    {
        protected ContainerRegistryRepositoryClient() { }
        protected Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        protected Azure.Core.Request CreateCreateManifestRequest(Azure.Core.RequestContent requestBody, string name, string reference) { throw null; }
        protected Azure.Core.Request CreateDeleteManifestRequest(Azure.Core.RequestContent requestBody, string name, string reference) { throw null; }
        protected Azure.Core.Request CreateDeleteTagRequest(Azure.Core.RequestContent requestBody, string name, string reference) { throw null; }
        protected Azure.Core.Request CreateGetManifestRequest(Azure.Core.RequestContent requestBody, string name, string reference, string accept = null) { throw null; }
        protected Azure.Core.Request CreateGetManifestsRequest(Azure.Core.RequestContent requestBody, string name, string last = null, int? n = default(int?), string orderby = null) { throw null; }
        protected Azure.Core.Request CreateGetPropertiesRequest(Azure.Core.RequestContent requestBody, string name) { throw null; }
        protected Azure.Core.Request CreateGetRegistryArtifactPropertiesRequest(Azure.Core.RequestContent requestBody, string name, string digest) { throw null; }
        protected Azure.Core.Request CreateGetTagPropertiesRequest(Azure.Core.RequestContent requestBody, string name, string reference) { throw null; }
        protected Azure.Core.Request CreateGetTagsRequest(Azure.Core.RequestContent requestBody, string name, string last = null, int? n = default(int?), string orderby = null, string digest = null) { throw null; }
        public virtual Azure.Response CreateManifest(Azure.Core.RequestContent requestBody, string name, string reference, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateManifestAsync(Azure.Core.RequestContent requestBody, string name, string reference, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected Azure.Core.Request CreateSetPropertiesRequest(Azure.Core.RequestContent requestBody, string name) { throw null; }
        protected Azure.Core.Request CreateUpdateManifestAttributesRequest(Azure.Core.RequestContent requestBody, string name, string digest) { throw null; }
        protected Azure.Core.Request CreateUpdateTagAttributesRequest(Azure.Core.RequestContent requestBody, string name, string reference) { throw null; }
        public virtual Azure.Response DeleteManifest(Azure.Core.RequestContent requestBody, string name, string reference, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteManifestAsync(Azure.Core.RequestContent requestBody, string name, string reference, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteTag(Azure.Core.RequestContent requestBody, string name, string reference, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTagAsync(Azure.Core.RequestContent requestBody, string name, string reference, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetManifest(Azure.Core.RequestContent requestBody, string name, string reference, string accept = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetManifestAsync(Azure.Core.RequestContent requestBody, string name, string reference, string accept = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetManifests(Azure.Core.RequestContent requestBody, string name, string last = null, int? n = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetManifestsAsync(Azure.Core.RequestContent requestBody, string name, string last = null, int? n = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetProperties(Azure.Core.RequestContent requestBody, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPropertiesAsync(Azure.Core.RequestContent requestBody, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRegistryArtifactProperties(Azure.Core.RequestContent requestBody, string name, string digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRegistryArtifactPropertiesAsync(Azure.Core.RequestContent requestBody, string name, string digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTagProperties(Azure.Core.RequestContent requestBody, string name, string reference, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTagPropertiesAsync(Azure.Core.RequestContent requestBody, string name, string reference, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTags(Azure.Core.RequestContent requestBody, string name, string last = null, int? n = default(int?), string orderby = null, string digest = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTagsAsync(Azure.Core.RequestContent requestBody, string name, string last = null, int? n = default(int?), string orderby = null, string digest = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetProperties(Azure.Core.RequestContent requestBody, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetPropertiesAsync(Azure.Core.RequestContent requestBody, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateManifestAttributes(Azure.Core.RequestContent requestBody, string name, string digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateManifestAttributesAsync(Azure.Core.RequestContent requestBody, string name, string digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateTagAttributes(Azure.Core.RequestContent requestBody, string name, string reference, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateTagAttributesAsync(Azure.Core.RequestContent requestBody, string name, string reference, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
