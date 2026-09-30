namespace Azure.Containers.Apps.Sandbox
{
    public partial class AzureContainersAppsSandboxContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureContainersAppsSandboxContext() { }
        public static Azure.Containers.Apps.Sandbox.AzureContainersAppsSandboxContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ConnectionResource
    {
        protected ConnectionResource() { }
        public virtual Azure.Containers.Apps.Sandbox.Models.SandboxConnection? Data { get { throw null; } }
        public virtual string Id { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxConnection> AuthorizeConnection(Azure.Containers.Apps.Sandbox.Models.AuthorizeConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AuthorizeConnection(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxConnection>> AuthorizeConnectionAsync(Azure.Containers.Apps.Sandbox.Models.AuthorizeConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AuthorizeConnectionAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteConnection(bool? force, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteConnection(bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteConnectionAsync(bool? force, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteConnectionAsync(bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkResult> GenerateConnectionConsentLink(Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkContent body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GenerateConnectionConsentLink(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkResult>> GenerateConnectionConsentLinkAsync(Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkContent body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GenerateConnectionConsentLinkAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.ConnectionResource> Get(bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.ConnectionResource>> GetAsync(bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetConnection(bool? includeSandboxIds, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxConnection> GetConnection(bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConnectionAsync(bool? includeSandboxIds, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxConnection>> GetConnectionAsync(bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RefreshConnection(bool? includeSandboxIds, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxConnection> RefreshConnection(bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RefreshConnectionAsync(bool? includeSandboxIds, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxConnection>> RefreshConnectionAsync(bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxConnection> UpdateConnectionPolicyRules(Azure.Containers.Apps.Sandbox.Models.UpdatePolicyRulesContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateConnectionPolicyRules(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxConnection>> UpdateConnectionPolicyRulesAsync(Azure.Containers.Apps.Sandbox.Models.UpdatePolicyRulesContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateConnectionPolicyRulesAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ConnectionsClient
    {
        protected ConnectionsClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxConnection> AuthorizeConnection(string id, Azure.Containers.Apps.Sandbox.Models.AuthorizeConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AuthorizeConnection(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxConnection>> AuthorizeConnectionAsync(string id, Azure.Containers.Apps.Sandbox.Models.AuthorizeConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AuthorizeConnectionAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxConnection> CreateConnection(Azure.Containers.Apps.Sandbox.Models.CreateConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateConnection(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxConnection>> CreateConnectionAsync(Azure.Containers.Apps.Sandbox.Models.CreateConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateConnectionAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteConnection(string id, bool? force, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteConnection(string id, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteConnectionAsync(string id, bool? force, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteConnectionAsync(string id, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkResult> GenerateConnectionConsentLink(string id, Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkContent body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GenerateConnectionConsentLink(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkResult>> GenerateConnectionConsentLinkAsync(string id, Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkContent body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GenerateConnectionConsentLinkAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetConnection(string id, bool? includeSandboxIds, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxConnection> GetConnection(string id, bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConnectionAsync(string id, bool? includeSandboxIds, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxConnection>> GetConnectionAsync(string id, bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetConnections(bool? includeSandboxIds, string labels, string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.Models.SandboxConnection> GetConnections(bool? includeSandboxIds = default(bool?), string labels = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetConnectionsAsync(bool? includeSandboxIds, string labels, string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.Models.SandboxConnection> GetConnectionsAsync(bool? includeSandboxIds = default(bool?), string labels = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RefreshConnection(string id, bool? includeSandboxIds, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxConnection> RefreshConnection(string id, bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RefreshConnectionAsync(string id, bool? includeSandboxIds, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxConnection>> RefreshConnectionAsync(string id, bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxConnection> UpdateConnectionPolicyRules(string id, Azure.Containers.Apps.Sandbox.Models.UpdatePolicyRulesContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateConnectionPolicyRules(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxConnection>> UpdateConnectionPolicyRulesAsync(string id, Azure.Containers.Apps.Sandbox.Models.UpdatePolicyRulesContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateConnectionPolicyRulesAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ContentPackageResource
    {
        protected ContentPackageResource() { }
        public virtual Azure.Containers.Apps.Sandbox.Models.ContentPackage? Data { get { throw null; } }
        public virtual string Id { get { throw null; } }
        public virtual Azure.Response DeleteContentPackage(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteContentPackage(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteContentPackageAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteContentPackageAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.ContentPackageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.ContentPackageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetContentPackage(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.ContentPackage> GetContentPackage(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetContentPackageAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.ContentPackage>> GetContentPackageAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContentPackagesClient
    {
        protected ContentPackagesClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteContentPackage(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteContentPackage(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteContentPackageAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteContentPackageAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetContentPackage(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.ContentPackage> GetContentPackage(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetContentPackageAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.ContentPackage>> GetContentPackageAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetContentPackages(string skipToken, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.Models.ContentPackage> GetContentPackages(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetContentPackagesAsync(string skipToken, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.Models.ContentPackage> GetContentPackagesAsync(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UploadContentPackage(Azure.Core.RequestContent content, string contentType = null, string labels = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.ContentPackage> UploadContentPackage(System.IO.Stream content, string contentType = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadContentPackageAsync(Azure.Core.RequestContent content, string contentType = null, string labels = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.ContentPackage>> UploadContentPackageAsync(System.IO.Stream content, string contentType = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CredentialResource
    {
        protected CredentialResource() { }
        public virtual Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential? Data { get { throw null; } }
        public virtual string Name { get { throw null; } }
        public virtual Azure.Response DeleteCredential(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteCredential(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteCredentialAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteCredentialAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.CredentialResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.CredentialResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCredential(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential> GetCredential(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCredentialAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential>> GetCredentialAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential> SetCredential(Azure.Containers.Apps.Sandbox.Models.CreateSandboxGroupCredentialContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetCredential(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential>> SetCredentialAsync(Azure.Containers.Apps.Sandbox.Models.CreateSandboxGroupCredentialContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetCredentialAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class CredentialsClient
    {
        protected CredentialsClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteCredential(string credentialName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteCredential(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteCredentialAsync(string credentialName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteCredentialAsync(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCredential(string credentialName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential> GetCredential(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCredentialAsync(string credentialName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential>> GetCredentialAsync(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetCredentials(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential> GetCredentials(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetCredentialsAsync(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential> GetCredentialsAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential> SetCredential(string credentialName, Azure.Containers.Apps.Sandbox.Models.CreateSandboxGroupCredentialContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetCredential(string credentialName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential>> SetCredentialAsync(string credentialName, Azure.Containers.Apps.Sandbox.Models.CreateSandboxGroupCredentialContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetCredentialAsync(string credentialName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class DiskImageResource
    {
        protected DiskImageResource() { }
        public virtual Azure.Containers.Apps.Sandbox.Models.DiskImage? Data { get { throw null; } }
        public virtual string Id { get { throw null; } }
        public virtual Azure.Response DeleteDiskImage(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteDiskImage(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDiskImageAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDiskImageAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.DiskImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.DiskImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDiskImage(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.DiskImage> GetDiskImage(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDiskImageAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.DiskImage>> GetDiskImageAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskImagesClient
    {
        protected DiskImagesClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.DiskImage> CreateDiskImage(Azure.Containers.Apps.Sandbox.Models.CreateDiskImageContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateDiskImage(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.DiskImage>> CreateDiskImageAsync(Azure.Containers.Apps.Sandbox.Models.CreateDiskImageContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateDiskImageAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteDiskImage(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteDiskImage(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDiskImageAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDiskImageAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDiskImage(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.DiskImage> GetDiskImage(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDiskImageAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.DiskImage>> GetDiskImageAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDiskImages(string skipToken, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.Models.DiskImage> GetDiskImages(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDiskImagesAsync(string skipToken, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.Models.DiskImage> GetDiskImagesAsync(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EgressPoliciesClient
    {
        protected EgressPoliciesClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteEgressPolicy(string policyId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteEgressPolicy(string policyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteEgressPolicyAsync(string policyId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteEgressPolicyAsync(string policyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEgressPolicies(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy> GetEgressPolicies(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEgressPoliciesAsync(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy> GetEgressPoliciesAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEgressPolicy(string policyId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy> GetEgressPolicy(string policyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEgressPolicyAsync(string policyId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy>> GetEgressPolicyAsync(string policyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy> SetEgressPolicy(string policyId, Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetEgressPolicy(string policyId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy>> SetEgressPolicyAsync(string policyId, Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetEgressPolicyAsync(string policyId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class EgressPolicyResource
    {
        protected EgressPolicyResource() { }
        public virtual Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy? Data { get { throw null; } }
        public virtual string Id { get { throw null; } }
        public virtual Azure.Response DeleteEgressPolicy(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteEgressPolicy(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteEgressPolicyAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteEgressPolicyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.EgressPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.EgressPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEgressPolicy(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy> GetEgressPolicy(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEgressPolicyAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy>> GetEgressPolicyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy> SetEgressPolicy(Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetEgressPolicy(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy>> SetEgressPolicyAsync(Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetEgressPolicyAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class PublicDiskImageResource
    {
        protected PublicDiskImageResource() { }
        public virtual Azure.Containers.Apps.Sandbox.Models.PublicDiskImage? Data { get { throw null; } }
        public virtual string Name { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.PublicDiskImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.PublicDiskImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPublicDiskImage(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.PublicDiskImage> GetPublicDiskImage(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPublicDiskImageAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.PublicDiskImage>> GetPublicDiskImageAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PublicDiskImagesClient
    {
        protected PublicDiskImagesClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetPublicDiskImage(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.PublicDiskImage> GetPublicDiskImage(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPublicDiskImageAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.PublicDiskImage>> GetPublicDiskImageAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetPublicDiskImages(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.Models.PublicDiskImage> GetPublicDiskImages(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetPublicDiskImagesAsync(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.Models.PublicDiskImage> GetPublicDiskImagesAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SandboxesClient
    {
        protected SandboxesClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.ConnectionsListResult> AddConnection(string id, Azure.Containers.Apps.Sandbox.Models.AddConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddConnection(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.ConnectionsListResult>> AddConnectionAsync(string id, Azure.Containers.Apps.Sandbox.Models.AddConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddConnectionAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddPodVolumeMounts(string id, Azure.Containers.Apps.Sandbox.Models.PodVolumeMountsContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddPodVolumeMounts(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddPodVolumeMountsAsync(string id, Azure.Containers.Apps.Sandbox.Models.PodVolumeMountsContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddPodVolumeMountsAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.PortsListResult> AddPort(string id, Azure.Containers.Apps.Sandbox.Models.CreateSandboxPortContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddPort(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.PortsListResult>> AddPortAsync(string id, Azure.Containers.Apps.Sandbox.Models.CreateSandboxPortContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddPortAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddVolumeMount(string id, Azure.Containers.Apps.Sandbox.Models.SandboxVolumeMountContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddVolumeMount(string id, Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddVolumeMountAsync(string id, Azure.Containers.Apps.Sandbox.Models.SandboxVolumeMountContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddVolumeMountAsync(string id, Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.CommitSandboxResult> Commit(string id, Azure.Containers.Apps.Sandbox.Models.CommitSandboxContent body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Commit(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.CommitSandboxResult>> CommitAsync(string id, Azure.Containers.Apps.Sandbox.Models.CommitSandboxContent body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CommitAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties> CreateSandbox(Azure.Containers.Apps.Sandbox.Models.CreateSandboxContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateSandbox(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties>> CreateSandboxAsync(Azure.Containers.Apps.Sandbox.Models.CreateSandboxContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateSandboxAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult> CreateSandboxDirectory(string id, Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateSandboxDirectory(string id, Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult>> CreateSandboxDirectoryAsync(string id, Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateSandboxDirectoryAsync(string id, Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot> CreateSnapshot(string id, Azure.Containers.Apps.Sandbox.Models.CreateSnapshotContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateSnapshot(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot>> CreateSnapshotAsync(string id, Azure.Containers.Apps.Sandbox.Models.CreateSnapshotContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateSnapshotAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response Delete(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteSandboxFile(string id, string path, bool? recursive, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult> DeleteSandboxFile(string id, string path, bool? recursive = default(bool?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSandboxFileAsync(string id, string path, bool? recursive, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult>> DeleteSandboxFileAsync(string id, string path, bool? recursive = default(bool?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Disable(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties> Disable(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties>> DisableAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadContentPackage(string id, Azure.Containers.Apps.Sandbox.Models.DownloadContentPackageToSandboxContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadContentPackage(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadContentPackageAsync(string id, Azure.Containers.Apps.Sandbox.Models.DownloadContentPackageToSandboxContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadContentPackageAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DownloadSandboxFile(string id, string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.IO.Stream> DownloadSandboxFile(string id, string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadSandboxFileAsync(string id, string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> DownloadSandboxFileAsync(string id, string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Enable(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties> Enable(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties>> EnableAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteCommandResult> ExecuteCommand(string id, Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxCommandContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ExecuteCommand(string id, Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteCommandResult>> ExecuteCommandAsync(string id, Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxCommandContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExecuteCommandAsync(string id, Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteShellCommandResult> ExecuteShellCommand(string id, Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxShellCommandContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ExecuteShellCommand(string id, Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteShellCommandResult>> ExecuteShellCommandAsync(string id, Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxShellCommandContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExecuteShellCommandAsync(string id, Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEgressDecisions(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.EgressDecisionsResult> GetEgressDecisions(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEgressDecisionsAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.EgressDecisionsResult>> GetEgressDecisionsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPorts(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.PortsListResult> GetPorts(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPortsAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.PortsListResult>> GetPortsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetProperties(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties> GetProperties(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPropertiesAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties>> GetPropertiesAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxCount(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxCountResult> GetSandboxCount(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxCountAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxCountResult>> GetSandboxCountAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSandboxes(string skipToken, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.Models.SandboxProperties> GetSandboxes(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSandboxesAsync(string skipToken, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.Models.SandboxProperties> GetSandboxesAsync(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxExecStream(string id, string containerName, string user, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetSandboxExecStream(string id, string containerName = null, string user = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxExecStreamAsync(string id, string containerName, string user, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxExecStreamAsync(string id, string containerName = null, string user = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxFileMetadata(string id, string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxFileInfo> GetSandboxFileMetadata(string id, string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxFileMetadataAsync(string id, string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxFileInfo>> GetSandboxFileMetadataAsync(string id, string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxFilesMetadata(string id, string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryListingResult> GetSandboxFilesMetadata(string id, string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxFilesMetadataAsync(string id, string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryListingResult>> GetSandboxFilesMetadataAsync(string id, string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxLogStream(string id, int? tailLines, int? logFormat, bool? follow, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetSandboxLogStream(string id, int? tailLines = default(int?), int? logFormat = default(int?), bool? follow = default(bool?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxLogStreamAsync(string id, int? tailLines, int? logFormat, bool? follow, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxLogStreamAsync(string id, int? tailLines = default(int?), int? logFormat = default(int?), bool? follow = default(bool?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxProcessesStream(string id, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetSandboxProcessesStream(string id, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxProcessesStreamAsync(string id, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxProcessesStreamAsync(string id, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetStats(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxStatsResult> GetStats(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetStatsAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxStatsResult>> GetStatsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.PortsListResult> RemovePort(string id, Azure.Containers.Apps.Sandbox.Models.RemovePortContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemovePort(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.PortsListResult>> RemovePortAsync(string id, Azure.Containers.Apps.Sandbox.Models.RemovePortContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemovePortAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Resume(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties> Resume(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties>> ResumeAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy> SetEgressPolicy(string id, Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetEgressPolicy(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy>> SetEgressPolicyAsync(string id, Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetEgressPolicyAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties> SetLifecyclePolicy(string id, Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetLifecyclePolicy(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties>> SetLifecyclePolicyAsync(string id, Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetLifecyclePolicyAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.PortsListResult> SetPorts(string id, Azure.Containers.Apps.Sandbox.Models.UpdatePortsContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetPorts(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.PortsListResult>> SetPortsAsync(string id, Azure.Containers.Apps.Sandbox.Models.UpdatePortsContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetPortsAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Stop(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot> Stop(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot>> StopAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdatePort(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdatePortAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UploadSandboxFile(string id, string path, Azure.Core.RequestContent content, bool? createDirs = default(bool?), int? mode = default(int?), string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.WriteFileResult> UploadSandboxFile(string id, string path, System.IO.Stream content, bool? createDirs = default(bool?), int? mode = default(int?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadSandboxFileAsync(string id, string path, Azure.Core.RequestContent content, bool? createDirs = default(bool?), int? mode = default(int?), string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.WriteFileResult>> UploadSandboxFileAsync(string id, string path, System.IO.Stream content, bool? createDirs = default(bool?), int? mode = default(int?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SandboxGroupClient
    {
        protected SandboxGroupClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public SandboxGroupClient(Azure.Containers.Apps.Sandbox.SandboxGroupClientSettings settings) { }
        public SandboxGroupClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string sandboxGroupName, Azure.Core.TokenCredential credential) { }
        public SandboxGroupClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string sandboxGroupName, Azure.Core.TokenCredential credential, Azure.Containers.Apps.Sandbox.SandboxGroupClientOptions options) { }
        public virtual Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public virtual string Name { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual string ResourceGroupName { get { throw null; } }
        public virtual string SubscriptionId { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.ConnectionResource> CreateConnection(Azure.Containers.Apps.Sandbox.Models.CreateConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.ConnectionResource>> CreateConnectionAsync(Azure.Containers.Apps.Sandbox.Models.CreateConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.DiskImageResource> CreateDiskImage(Azure.Containers.Apps.Sandbox.Models.CreateDiskImageContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.DiskImageResource>> CreateDiskImageAsync(Azure.Containers.Apps.Sandbox.Models.CreateDiskImageContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxResource> CreateSandbox(Azure.Containers.Apps.Sandbox.Models.CreateSandboxContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxResource>> CreateSandboxAsync(Azure.Containers.Apps.Sandbox.Models.CreateSandboxContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SnapshotResource> CreateSnapshot(string sandboxId, Azure.Containers.Apps.Sandbox.Models.CreateSnapshotContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SnapshotResource>> CreateSnapshotAsync(string sandboxId, Azure.Containers.Apps.Sandbox.Models.CreateSnapshotContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.VolumeResource> CreateVolume(string volumeName, Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.VolumeResource>> CreateVolumeAsync(string volumeName, Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.VolumeResource> ForkVolume(string volumeName, Azure.Containers.Apps.Sandbox.Models.ForkDataDiskVolumeContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.VolumeResource>> ForkVolumeAsync(string volumeName, Azure.Containers.Apps.Sandbox.Models.ForkDataDiskVolumeContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.ConnectionResource GetConnection(string id) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.ConnectionResource> GetConnections(bool? includeSandboxIds = default(bool?), string labels = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.ConnectionResource> GetConnectionsAsync(bool? includeSandboxIds = default(bool?), string labels = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.ConnectionsClient GetConnectionsClient() { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.ContentPackageResource GetContentPackage(string id) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.ContentPackageResource> GetContentPackages(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.ContentPackageResource> GetContentPackagesAsync(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.ContentPackagesClient GetContentPackagesClient() { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.CredentialResource GetCredential(string credentialName) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.CredentialResource> GetCredentials(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.CredentialResource> GetCredentialsAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.CredentialsClient GetCredentialsClient() { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.DiskImageResource GetDiskImage(string id) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.DiskImageResource> GetDiskImages(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.DiskImageResource> GetDiskImagesAsync(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.DiskImagesClient GetDiskImagesClient() { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.EgressPolicyResource> GetEgressPolicies(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.EgressPolicyResource> GetEgressPoliciesAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.EgressPoliciesClient GetEgressPoliciesClient() { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.EgressPolicyResource GetEgressPolicy(string policyId) { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.PublicDiskImageResource GetPublicDiskImage(string name) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.PublicDiskImageResource> GetPublicDiskImages(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.PublicDiskImageResource> GetPublicDiskImagesAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.PublicDiskImagesClient GetPublicDiskImagesClient() { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.SandboxResource GetSandbox(string id) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.SandboxResource> GetSandboxes(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.SandboxResource> GetSandboxesAsync(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.SandboxesClient GetSandboxesClient() { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.SecretResource GetSecret(string secretId) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.SecretResource> GetSecrets(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.SecretResource> GetSecretsAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.SecretsClient GetSecretsClient() { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.SnapshotResource GetSnapshot(string id) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.SnapshotResource> GetSnapshots(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.SnapshotResource> GetSnapshotsAsync(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.SnapshotsClient GetSnapshotsClient() { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.VolumeResource GetVolume(string volumeName) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.VolumeResource> GetVolumes(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.VolumeResource> GetVolumesAsync(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.VolumesClient GetVolumesClient() { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.CredentialResource> SetCredential(string credentialName, Azure.Containers.Apps.Sandbox.Models.CreateSandboxGroupCredentialContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.CredentialResource>> SetCredentialAsync(string credentialName, Azure.Containers.Apps.Sandbox.Models.CreateSandboxGroupCredentialContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.EgressPolicyResource> SetEgressPolicy(string policyId, Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.EgressPolicyResource>> SetEgressPolicyAsync(string policyId, Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SecretResource> SetSecret(string secretId, Azure.Containers.Apps.Sandbox.Models.SetSecretContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SecretResource>> SetSecretAsync(string secretId, Azure.Containers.Apps.Sandbox.Models.SetSecretContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.ContentPackageResource> UploadContentPackage(System.IO.Stream content, string contentType = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.ContentPackageResource>> UploadContentPackageAsync(System.IO.Stream content, string contentType = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public static partial class SandboxGroupClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedSandboxGroupClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedSandboxGroupClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.Containers.Apps.Sandbox.SandboxGroupClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddSandboxGroupClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddSandboxGroupClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.Containers.Apps.Sandbox.SandboxGroupClientSettings> configureSettings) { throw null; }
    }
    public partial class SandboxGroupClientOptions : Azure.Core.ClientOptions
    {
        public SandboxGroupClientOptions(Azure.Containers.Apps.Sandbox.SandboxGroupClientOptions.ServiceVersion version = Azure.Containers.Apps.Sandbox.SandboxGroupClientOptions.ServiceVersion.V2026_09_01_Preview) { }
        public enum ServiceVersion
        {
            V2026_09_01_Preview = 1,
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class SandboxGroupClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public SandboxGroupClientSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.SandboxGroupClientOptions Options { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public string SandboxGroupName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public partial class SandboxResource
    {
        protected SandboxResource() { }
        public virtual Azure.Containers.Apps.Sandbox.Models.SandboxProperties? Data { get { throw null; } }
        public virtual string Id { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.ConnectionsListResult> AddConnection(Azure.Containers.Apps.Sandbox.Models.AddConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddConnection(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.ConnectionsListResult>> AddConnectionAsync(Azure.Containers.Apps.Sandbox.Models.AddConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddConnectionAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddPodVolumeMounts(Azure.Containers.Apps.Sandbox.Models.PodVolumeMountsContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddPodVolumeMounts(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddPodVolumeMountsAsync(Azure.Containers.Apps.Sandbox.Models.PodVolumeMountsContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddPodVolumeMountsAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.PortsListResult> AddPort(Azure.Containers.Apps.Sandbox.Models.CreateSandboxPortContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddPort(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.PortsListResult>> AddPortAsync(Azure.Containers.Apps.Sandbox.Models.CreateSandboxPortContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddPortAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddVolumeMount(Azure.Containers.Apps.Sandbox.Models.SandboxVolumeMountContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddVolumeMount(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddVolumeMountAsync(Azure.Containers.Apps.Sandbox.Models.SandboxVolumeMountContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddVolumeMountAsync(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.CommitSandboxResult> Commit(Azure.Containers.Apps.Sandbox.Models.CommitSandboxContent body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Commit(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.CommitSandboxResult>> CommitAsync(Azure.Containers.Apps.Sandbox.Models.CommitSandboxContent body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CommitAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult> CreateSandboxDirectory(Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateSandboxDirectory(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult>> CreateSandboxDirectoryAsync(Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateSandboxDirectoryAsync(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot> CreateSnapshot(Azure.Containers.Apps.Sandbox.Models.CreateSnapshotContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateSnapshot(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot>> CreateSnapshotAsync(Azure.Containers.Apps.Sandbox.Models.CreateSnapshotContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateSnapshotAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteSandboxFile(string path, bool? recursive, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult> DeleteSandboxFile(string path, bool? recursive = default(bool?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSandboxFileAsync(string path, bool? recursive, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult>> DeleteSandboxFileAsync(string path, bool? recursive = default(bool?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Disable(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties> Disable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties>> DisableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadContentPackage(Azure.Containers.Apps.Sandbox.Models.DownloadContentPackageToSandboxContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadContentPackage(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadContentPackageAsync(Azure.Containers.Apps.Sandbox.Models.DownloadContentPackageToSandboxContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadContentPackageAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<System.IO.Stream> DownloadSandboxFile(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> DownloadSandboxFileAsync(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Enable(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties> Enable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties>> EnableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteCommandResult> ExecuteCommand(Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxCommandContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ExecuteCommand(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteCommandResult>> ExecuteCommandAsync(Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxCommandContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExecuteCommandAsync(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteShellCommandResult> ExecuteShellCommand(Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxShellCommandContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ExecuteShellCommand(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteShellCommandResult>> ExecuteShellCommandAsync(Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxShellCommandContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExecuteShellCommandAsync(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEgressDecisions(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.EgressDecisionsResult> GetEgressDecisions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEgressDecisionsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.EgressDecisionsResult>> GetEgressDecisionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPorts(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.PortsListResult> GetPorts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPortsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.PortsListResult>> GetPortsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetProperties(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPropertiesAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxExecStream(string containerName, string user, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetSandboxExecStream(string containerName = null, string user = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxExecStreamAsync(string containerName, string user, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxExecStreamAsync(string containerName = null, string user = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxFileMetadata(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxFileInfo> GetSandboxFileMetadata(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxFileMetadataAsync(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxFileInfo>> GetSandboxFileMetadataAsync(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxFilesMetadata(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryListingResult> GetSandboxFilesMetadata(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxFilesMetadataAsync(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryListingResult>> GetSandboxFilesMetadataAsync(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxLogStream(int? tailLines, int? logFormat, bool? follow, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetSandboxLogStream(int? tailLines = default(int?), int? logFormat = default(int?), bool? follow = default(bool?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxLogStreamAsync(int? tailLines, int? logFormat, bool? follow, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxLogStreamAsync(int? tailLines = default(int?), int? logFormat = default(int?), bool? follow = default(bool?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxProcessesStream(string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetSandboxProcessesStream(string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxProcessesStreamAsync(string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxProcessesStreamAsync(string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetStats(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxStatsResult> GetStats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetStatsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxStatsResult>> GetStatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.PortsListResult> RemovePort(Azure.Containers.Apps.Sandbox.Models.RemovePortContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemovePort(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.PortsListResult>> RemovePortAsync(Azure.Containers.Apps.Sandbox.Models.RemovePortContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemovePortAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Resume(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties> Resume(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties>> ResumeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy> SetEgressPolicy(Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetEgressPolicy(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy>> SetEgressPolicyAsync(Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetEgressPolicyAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties> SetLifecyclePolicy(Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetLifecyclePolicy(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxProperties>> SetLifecyclePolicyAsync(Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetLifecyclePolicyAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.PortsListResult> SetPorts(Azure.Containers.Apps.Sandbox.Models.UpdatePortsContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetPorts(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.PortsListResult>> SetPortsAsync(Azure.Containers.Apps.Sandbox.Models.UpdatePortsContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetPortsAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Stop(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot> Stop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot>> StopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdatePort(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdatePortAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.WriteFileResult> UploadSandboxFile(string path, System.IO.Stream content, bool? createDirs = default(bool?), int? mode = default(int?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.WriteFileResult>> UploadSandboxFileAsync(string path, System.IO.Stream content, bool? createDirs = default(bool?), int? mode = default(int?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecretResource
    {
        protected SecretResource() { }
        public virtual Azure.Containers.Apps.Sandbox.Models.SandboxSecret? Data { get { throw null; } }
        public virtual string Id { get { throw null; } }
        public virtual Azure.Response DeleteSecret(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteSecret(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSecretAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSecretAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSecretKeys(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SecretKeysResult> GetSecretKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSecretKeysAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SecretKeysResult>> GetSecretKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PeekSecret(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SecretPeekResult> PeekSecret(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PeekSecretAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SecretPeekResult>> PeekSecretAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxSecret> SetSecret(Azure.Containers.Apps.Sandbox.Models.SetSecretContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetSecret(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxSecret>> SetSecretAsync(Azure.Containers.Apps.Sandbox.Models.SetSecretContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetSecretAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class SecretsClient
    {
        protected SecretsClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteSecret(string secretId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteSecret(string secretId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSecretAsync(string secretId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSecretAsync(string secretId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSecretKeys(string secretId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SecretKeysResult> GetSecretKeys(string secretId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSecretKeysAsync(string secretId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SecretKeysResult>> GetSecretKeysAsync(string secretId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSecrets(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.Models.SandboxSecret> GetSecrets(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSecretsAsync(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.Models.SandboxSecret> GetSecretsAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PeekSecret(string secretId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SecretPeekResult> PeekSecret(string secretId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PeekSecretAsync(string secretId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SecretPeekResult>> PeekSecretAsync(string secretId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxSecret> SetSecret(string secretId, Azure.Containers.Apps.Sandbox.Models.SetSecretContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetSecret(string secretId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxSecret>> SetSecretAsync(string secretId, Azure.Containers.Apps.Sandbox.Models.SetSecretContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetSecretAsync(string secretId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class SnapshotResource
    {
        protected SnapshotResource() { }
        public virtual Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot? Data { get { throw null; } }
        public virtual string Id { get { throw null; } }
        public virtual Azure.Response DeleteSnapshot(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteSnapshot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSnapshotAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSnapshotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SnapshotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SnapshotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSnapshot(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot> GetSnapshot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSnapshotAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot>> GetSnapshotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SnapshotsClient
    {
        protected SnapshotsClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteSnapshot(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteSnapshot(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSnapshotAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSnapshotAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSnapshot(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot> GetSnapshot(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSnapshotAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot>> GetSnapshotAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSnapshotCount(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SnapshotCountResult> GetSnapshotCount(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSnapshotCountAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SnapshotCountResult>> GetSnapshotCountAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSnapshots(string skipToken, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot> GetSnapshots(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSnapshotsAsync(string skipToken, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot> GetSnapshotsAsync(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VolumeResource
    {
        protected VolumeResource() { }
        public virtual Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume? Data { get { throw null; } }
        public virtual string VolumeName { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume> CreateVolume(Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVolume(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume>> CreateVolumeAsync(Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVolumeAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateVolumeDirectory(string path, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.VolumePathItem> CreateVolumeDirectory(string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVolumeDirectoryAsync(string path, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.VolumePathItem>> CreateVolumeDirectoryAsync(string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVolume(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteVolume(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVolumeAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVolumeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVolumeFile(string path, bool? recursive, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteVolumeFile(string path, bool? recursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVolumeFileAsync(string path, bool? recursive, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVolumeFileAsync(string path, bool? recursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> DownloadVolumeFile(string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> DownloadVolumeFileAsync(string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume> ForkVolume(Azure.Containers.Apps.Sandbox.Models.ForkDataDiskVolumeContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ForkVolume(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume>> ForkVolumeAsync(Azure.Containers.Apps.Sandbox.Models.ForkDataDiskVolumeContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ForkVolumeAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.VolumeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.VolumeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVolume(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume> GetVolume(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVolumeAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume>> GetVolumeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVolumeFilesMetadata(string path, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.VolumeListDirectoryResult> GetVolumeFilesMetadata(string path = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVolumeFilesMetadataAsync(string path, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.VolumeListDirectoryResult>> GetVolumeFilesMetadataAsync(string path = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.VolumePathItem> UploadVolumeFile(string path, System.IO.Stream content, bool? overwrite = default(bool?), Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.VolumePathItem>> UploadVolumeFileAsync(string path, System.IO.Stream content, bool? overwrite = default(bool?), Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VolumesClient
    {
        protected VolumesClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume> CreateVolume(string volumeName, Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVolume(string volumeName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume>> CreateVolumeAsync(string volumeName, Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVolumeAsync(string volumeName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateVolumeDirectory(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.VolumePathItem> CreateVolumeDirectory(string volumeName, string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVolumeDirectoryAsync(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.VolumePathItem>> CreateVolumeDirectoryAsync(string volumeName, string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVolume(string volumeName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteVolume(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVolumeAsync(string volumeName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVolumeAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVolumeFile(string volumeName, string path, bool? recursive, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteVolumeFile(string volumeName, string path, bool? recursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVolumeFileAsync(string volumeName, string path, bool? recursive, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVolumeFileAsync(string volumeName, string path, bool? recursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadVolumeFile(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.IO.Stream> DownloadVolumeFile(string volumeName, string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadVolumeFileAsync(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> DownloadVolumeFileAsync(string volumeName, string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume> ForkVolume(string volumeName, Azure.Containers.Apps.Sandbox.Models.ForkDataDiskVolumeContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ForkVolume(string volumeName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume>> ForkVolumeAsync(string volumeName, Azure.Containers.Apps.Sandbox.Models.ForkDataDiskVolumeContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ForkVolumeAsync(string volumeName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetVolume(string volumeName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume> GetVolume(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVolumeAsync(string volumeName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume>> GetVolumeAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVolumeCounts(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.VolumeCountResult> GetVolumeCounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVolumeCountsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.VolumeCountResult>> GetVolumeCountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVolumeFilesMetadata(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.VolumeListDirectoryResult> GetVolumeFilesMetadata(string volumeName, string path = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVolumeFilesMetadataAsync(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.VolumeListDirectoryResult>> GetVolumeFilesMetadataAsync(string volumeName, string path = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetVolumes(string skipToken, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume> GetVolumes(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetVolumesAsync(string skipToken, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume> GetVolumesAsync(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UploadVolumeFile(string volumeName, string path, Azure.Core.RequestContent content, bool? overwrite = default(bool?), Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.Models.VolumePathItem> UploadVolumeFile(string volumeName, string path, System.IO.Stream content, bool? overwrite = default(bool?), Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadVolumeFileAsync(string volumeName, string path, Azure.Core.RequestContent content, bool? overwrite = default(bool?), Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.Models.VolumePathItem>> UploadVolumeFileAsync(string volumeName, string path, System.IO.Stream content, bool? overwrite = default(bool?), Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.Containers.Apps.Sandbox.Models
{
    public partial class AddConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.AddConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.AddConnectionContent>
    {
        public AddConnectionContent(string connectionId) { }
        public string ConnectionId { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.AddConnectionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.AddConnectionContent addConnectionContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.AddConnectionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.AddConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.AddConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.AddConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.AddConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.AddConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.AddConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.AddConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsTelemetryEndpoint : Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ApplicationInsightsTelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ApplicationInsightsTelemetryEndpoint>
    {
        public ApplicationInsightsTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.TelemetryData> data, Azure.Containers.Apps.Sandbox.Models.TelemetryApplicationInsightsAuthentication auth) { }
        public Azure.Containers.Apps.Sandbox.Models.TelemetryApplicationInsightsAuthentication Auth { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ApplicationInsightsTelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ApplicationInsightsTelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ApplicationInsightsTelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ApplicationInsightsTelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ApplicationInsightsTelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ApplicationInsightsTelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ApplicationInsightsTelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class AppsSandboxModelFactory
    {
        public static Azure.Containers.Apps.Sandbox.Models.AddConnectionContent AddConnectionContent(string connectionId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ApplicationInsightsTelemetryEndpoint ApplicationInsightsTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.TelemetryData> data = null, System.Collections.Generic.IDictionary<string, Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn> columns = null, bool? dynamicJsonColumns = default(bool?), Azure.Containers.Apps.Sandbox.Models.TelemetryApplicationInsightsAuthentication auth = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.AuthorizeConnectionContent AuthorizeConnectionContent(System.Collections.Generic.IDictionary<string, string> parameterValues = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.BlobDiskImageSource BlobDiskImageSource(System.Uri blobSourceUri = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.BlobVolumeAuthentication BlobVolumeAuthentication(string kind = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.BlobVolumeManagedIdentityAuthentication BlobVolumeManagedIdentityAuthentication(Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector identity = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.BlobVolumeUsage BlobVolumeUsage(long usedBytes = (long)0, long itemCount = (long)0, System.DateTimeOffset calculatedAtUtc = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.CommitSandboxContent CommitSandboxContent(System.Collections.Generic.IDictionary<string, string> labels = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.CommitSandboxResult CommitSandboxResult(Azure.Containers.Apps.Sandbox.Models.DiskImage diskImage = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ConnectionsListResult ConnectionsListResult(System.Collections.Generic.IEnumerable<string> connectionIds = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerProbe ContainerProbe(Azure.Containers.Apps.Sandbox.Models.ProbeHttpGetAction httpGet = null, Azure.Containers.Apps.Sandbox.Models.ProbeExecAction exec = null, Azure.Containers.Apps.Sandbox.Models.ProbeTcpSocketAction tcpSocket = null, int? initialDelaySeconds = default(int?), int? periodSeconds = default(int?), int? timeoutSeconds = default(int?), int? failureThreshold = default(int?), int? successThreshold = default(int?), int? terminationGracePeriodSeconds = default(int?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerProbeStatus ContainerProbeStatus(Azure.Containers.Apps.Sandbox.Models.ContainerProbeResult? lastResult = default(Azure.Containers.Apps.Sandbox.Models.ContainerProbeResult?), int? consecutiveFailures = default(int?), int? consecutiveSuccesses = default(int?), System.DateTimeOffset? lastCheckedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastTransitionOn = default(System.DateTimeOffset?), string message = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerResources ContainerResources(string cpu = null, string memory = null, string disk = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerSecurityContext ContainerSecurityContext(int? runAsUser = default(int?), int? runAsGroup = default(int?), bool? runAsNonRoot = default(bool?), bool? privileged = default(bool?), Azure.Containers.Apps.Sandbox.Models.LinuxCapabilities capabilities = null, bool? allowPrivilegeEscalation = default(bool?), bool? readOnlyRootFilesystem = default(bool?), Azure.Containers.Apps.Sandbox.Models.SeccompProfile seccompProfile = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerSpec ContainerSpec(string name = null, Azure.Containers.Apps.Sandbox.Models.SandboxSourceDiskImage diskImage = null, Azure.Containers.Apps.Sandbox.Models.SandboxSourceArtifactVersion artifactVersion = null, System.Collections.Generic.IEnumerable<string> command = null, System.Collections.Generic.IEnumerable<string> arguments = null, System.Collections.Generic.IDictionary<string, string> environment = null, Azure.Containers.Apps.Sandbox.Models.ContainerResources resources = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMount> volumeMounts = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.SandboxContentPackageDownload> contentPackageDownloads = null, Azure.Containers.Apps.Sandbox.Models.ContainerSecurityContext securityContext = null, Azure.Containers.Apps.Sandbox.Models.ContainerProbe startupProbe = null, Azure.Containers.Apps.Sandbox.Models.ContainerProbe livenessProbe = null, Azure.Containers.Apps.Sandbox.Models.ContainerProbe readinessProbe = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerStatus ContainerStatus(string name = null, Azure.Containers.Apps.Sandbox.Models.ContainerRuntimeState state = default(Azure.Containers.Apps.Sandbox.Models.ContainerRuntimeState), bool ready = false, bool started = false, int restartCount = 0, Azure.Containers.Apps.Sandbox.Models.ContainerStatusReason? reason = default(Azure.Containers.Apps.Sandbox.Models.ContainerStatusReason?), string message = null, int? lastExitCode = default(int?), System.DateTimeOffset? lastStartedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastFinishedOn = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, Azure.Containers.Apps.Sandbox.Models.ContainerProbeStatus> probes = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMount ContainerVolumeMount(string name = null, string mountPath = null, bool? readOnly = default(bool?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMounts ContainerVolumeMounts(string containerName = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMount> volumeMounts = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ContentPackage ContentPackage(string id = null, long size = (long)0, System.Collections.Generic.IDictionary<string, string> labels = null, string contentType = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.CpuStats CpuStats(long? user = default(long?), long? nice = default(long?), long? system = default(long?), long? idle = default(long?), long? iowait = default(long?), long? irq = default(long?), long? softirq = default(long?), long? steal = default(long?), double? loadAverage1Minute = default(double?), double? loadAverage5Minutes = default(double?), double? loadAverage15Minutes = default(double?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.CreateConnectionContent CreateConnectionContent(string name = null, string type = null, System.Collections.Generic.IDictionary<string, string> labels = null, string parameterValueSetName = null, System.Collections.Generic.IDictionary<string, string> parameterValueSetValues = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.McpPolicyRule> policyRules = null, System.Collections.Generic.IEnumerable<string> enabledToolGroups = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.CreateDiskImageContent CreateDiskImageContent(Azure.Containers.Apps.Sandbox.Models.DiskImageSource source = null, string name = null, System.Collections.Generic.IDictionary<string, string> labels = null, string vnetConnectionName = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.CreateSandboxContent CreateSandboxContent(System.Collections.Generic.IDictionary<string, string> labels = null, System.Collections.Generic.IEnumerable<string> entrypoint = null, System.Collections.Generic.IEnumerable<string> command = null, System.Collections.Generic.IDictionary<string, string> environment = null, Azure.Containers.Apps.Sandbox.Models.SandboxSource sourcesRef = null, Azure.Containers.Apps.Sandbox.Models.SandboxResources resources = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.CreateSandboxPortContent> ports = null, System.Collections.Generic.IEnumerable<string> connections = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.CreateSandboxGatewayConnectionContent> gatewayConnections = null, System.Collections.Generic.IEnumerable<string> credentialRefs = null, Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy egressPolicy = null, string egressPolicyId = null, string sandboxGroupId = null, Azure.Containers.Apps.Sandbox.Models.PresetSandboxType? presetSandboxType = default(Azure.Containers.Apps.Sandbox.Models.PresetSandboxType?), string anthropicApiKey = null, Azure.Containers.Apps.Sandbox.Models.SandboxPresetProperties presetProperties = null, Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy lifecycle = null, Azure.Containers.Apps.Sandbox.Models.SandboxAgentIdentityRef agentIdentity = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.SandboxVolume> volumes = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.SandboxContentPackageDownload> contentPackageDownloads = null, string vnetConnectionName = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.IdentitySetting> identitySettings = null, Azure.Containers.Apps.Sandbox.Models.TelemetryConfiguration telemetryConfig = null, string projectId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.CreateSandboxGatewayConnectionContent CreateSandboxGatewayConnectionContent(Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.CreateSandboxGroupCredentialContent CreateSandboxGroupCredentialContent(string displayName = null, Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialProvider provider = default(Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialProvider), Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSource source = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.CreateSandboxPortContent CreateSandboxPortContent(string name = null, int port = 0, Azure.Containers.Apps.Sandbox.Models.PortAuthConfig auth = null, Azure.Containers.Apps.Sandbox.Models.PortActivationMode? activationMode = default(Azure.Containers.Apps.Sandbox.Models.PortActivationMode?), Azure.Containers.Apps.Sandbox.Models.PortProtocol? protocol = default(Azure.Containers.Apps.Sandbox.Models.PortProtocol?), Azure.Containers.Apps.Sandbox.Models.IPAccessControl ipAccessControl = null, Azure.Containers.Apps.Sandbox.Models.PortCorsConfig cors = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.CreateSnapshotContent CreateSnapshotContent(System.Collections.Generic.IDictionary<string, string> labels = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.DataDiskPodVolume DataDiskPodVolume(string name = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.DataDiskVolume DataDiskVolume(string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.Containers.Apps.Sandbox.Models.VolumeProvisioningState provisioningState = default(Azure.Containers.Apps.Sandbox.Models.VolumeProvisioningState), string size = null, bool isAttached = false, string clusterId = null, string attachedSandboxId = null, Azure.Containers.Apps.Sandbox.Models.DataDiskVolumeUsage usage = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.DataDiskVolumeUsage DataDiskVolumeUsage(long compressedBlobSizeBytes = (long)0, long usedSizeBytes = (long)0, System.DateTimeOffset lastUploadedAtUtc = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.DiskImage DiskImage(string id = null, string name = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.Containers.Apps.Sandbox.Models.ImageMetadata image = null, Azure.Containers.Apps.Sandbox.Models.DiskImageStatus status = null, long? sizeInMb = default(long?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.DiskImageSource DiskImageSource(string kind = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.DiskImageStatus DiskImageStatus(Azure.Containers.Apps.Sandbox.Models.ResourceState state = default(Azure.Containers.Apps.Sandbox.Models.ResourceState), string errorMessage = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset updatedOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.DiskStatsEntry DiskStatsEntry(string mountPoint = null, string filesystem = null, long? totalBytes = default(long?), long? usedBytes = default(long?), long? availableBytes = default(long?), string label = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.DownloadContentPackageToSandboxContent DownloadContentPackageToSandboxContent(string contentPackageId = null, string targetPath = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressDecisionEntry EgressDecisionEntry(System.DateTimeOffset timestamp = default(System.DateTimeOffset), string host = null, string method = null, string path = null, string scheme = null, string connectionId = null, string connectionName = null, string matchedRule = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressDecisionsResult EgressDecisionsResult(Azure.Containers.Apps.Sandbox.Models.NetworkEgressDecisions http = null, Azure.Containers.Apps.Sandbox.Models.StatefulTcpEgress statefulTcp = null, System.DateTimeOffset lastUpdated = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressForwardProxy EgressForwardProxy(System.Uri url = null, string certificateAuthority = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressHostRule EgressHostRule(string pattern = null, Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction? action = default(Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderTransform EgressPolicyHeaderTransform(Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderOperation operation = default(Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderOperation), string name = null, string value = null, Azure.Containers.Apps.Sandbox.Models.EgressPolicyValueRef valueRef = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookRef EgressPolicyHookRef(System.Uri endpoint = null, Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookFailBehavior? failBehavior = default(Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookFailBehavior?), System.Collections.Generic.IEnumerable<string> requestHeaders = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderTransform> authHeaders = null, int? timeoutMs = default(int?), Azure.Containers.Apps.Sandbox.Models.EgressRuleRoutingMode? routingMode = default(Azure.Containers.Apps.Sandbox.Models.EgressRuleRoutingMode?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityRef EgressPolicyManagedIdentityRef(string resource = null, string format = null, Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityType? type = default(Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityType?), Azure.Core.ResourceIdentifier identityResourceId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyRule EgressPolicyRule(string name = null, Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleMatch match = null, Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleAction action = null, System.Collections.Generic.IEnumerable<string> proxyActions = null, string source = null, Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookRef hookRef = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleAction EgressPolicyRuleAction(Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType type = default(Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType), System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderTransform> headers = null, string scheme = null, string host = null, string path = null, Azure.Containers.Apps.Sandbox.Models.EgressRuleRoutingMode? routingMode = default(Azure.Containers.Apps.Sandbox.Models.EgressRuleRoutingMode?), Azure.Containers.Apps.Sandbox.Models.EgressForwardMode? forward = default(Azure.Containers.Apps.Sandbox.Models.EgressForwardMode?), Azure.Containers.Apps.Sandbox.Models.EgressForwardProxy forwardProxy = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleMatch EgressPolicyRuleMatch(string host = null, string path = null, System.Collections.Generic.IEnumerable<string> methods = null, Azure.Containers.Apps.Sandbox.Models.EgressPolicyMatchScheme? scheme = default(Azure.Containers.Apps.Sandbox.Models.EgressPolicyMatchScheme?), bool? normalizePath = default(bool?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicySecretRef EgressPolicySecretRef(string secretId = null, string secretKey = null, string format = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyValueRef EgressPolicyValueRef(Azure.Containers.Apps.Sandbox.Models.EgressPolicySecretRef secretRef = null, Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityRef managedIdentityRef = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxCommandContent ExecuteSandboxCommandContent(string command = null, System.Collections.Generic.IEnumerable<string> arguments = null, System.Collections.Generic.IDictionary<string, string> environment = null, string workingDirectory = null, string user = null, Azure.Containers.Apps.Sandbox.Models.PortActivationMode? activationMode = default(Azure.Containers.Apps.Sandbox.Models.PortActivationMode?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxShellCommandContent ExecuteSandboxShellCommandContent(string command = null, string shell = null, System.Collections.Generic.IDictionary<string, string> environment = null, string workingDirectory = null, string user = null, Azure.Containers.Apps.Sandbox.Models.PortActivationMode? activationMode = default(Azure.Containers.Apps.Sandbox.Models.PortActivationMode?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ForkDataDiskVolumeContent ForkDataDiskVolumeContent(string destinationVolumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.GatewayAuthentication GatewayAuthentication(Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthentication identity = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.GatewayConnection GatewayConnection(string resourceId = null, string name = null, System.Uri mcpRuntimeUri = null, System.Uri connectionRuntimeUri = null, Azure.Containers.Apps.Sandbox.Models.GatewayAuthentication authentication = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthRecord GatewayConnectionAuthRecord(Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthType type = default(Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthType), string identityResourceId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkContent GenerateConsentLinkContent(System.Uri redirectUri = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkResult GenerateConsentLinkResult(System.Uri consentLink = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.HttpEgressSection HttpEgressSection(Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction defaultAction = default(Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction), System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.EgressHostRule> hostRules = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRule> rules = null, Azure.Containers.Apps.Sandbox.Models.TrafficInspection? trafficInspection = default(Azure.Containers.Apps.Sandbox.Models.TrafficInspection?), Azure.Containers.Apps.Sandbox.Models.EgressPolicyEnforcementMode? enforcementMode = default(Azure.Containers.Apps.Sandbox.Models.EgressPolicyEnforcementMode?), Azure.Containers.Apps.Sandbox.Models.EgressForwardProxy defaultForward = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.IdentitySetting IdentitySetting(string identity = null, Azure.Containers.Apps.Sandbox.Models.IdentitySettingLifecycle? lifecycle = default(Azure.Containers.Apps.Sandbox.Models.IdentitySettingLifecycle?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ImageMetadata ImageMetadata(string baseImage = null, System.Collections.Generic.IEnumerable<string> entrypoint = null, System.Collections.Generic.IEnumerable<string> command = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.IPAccessControl IPAccessControl(Azure.Containers.Apps.Sandbox.Models.IPAccessControlAction defaultAction = default(Azure.Containers.Apps.Sandbox.Models.IPAccessControlAction), System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.IPAccessControlRule> rules = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.IPAccessControlRule IPAccessControlRule(string name = null, Azure.Containers.Apps.Sandbox.Models.IPAccessControlAction action = default(Azure.Containers.Apps.Sandbox.Models.IPAccessControlAction), int priority = 0, System.Collections.Generic.IEnumerable<string> sourceAddressPrefixes = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.LinuxCapabilities LinuxCapabilities(System.Collections.Generic.IEnumerable<string> add = null, System.Collections.Generic.IEnumerable<string> drop = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.LiteralTelemetryLogColumn LiteralTelemetryLogColumn(string value = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.LocalPodVolume LocalPodVolume(string name = null, string size = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.LogAnalyticsLegacyTelemetryEndpoint LogAnalyticsLegacyTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.TelemetryData> data = null, System.Collections.Generic.IDictionary<string, Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn> columns = null, bool? dynamicJsonColumns = default(bool?), string workspaceId = null, string tableName = null, Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference auth = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.LogAnalyticsTelemetryEndpoint LogAnalyticsTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.TelemetryData> data = null, System.Collections.Generic.IDictionary<string, Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn> columns = null, bool? dynamicJsonColumns = default(bool?), System.Uri dceEndpoint = null, string dcrImmutableId = null, string tableName = null, Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication auth = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthentication ManagedIdentityAuthentication(Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthenticationType type = default(Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthenticationType), string identityResourceId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.McpPolicyRule McpPolicyRule(string hookId = null, System.Collections.Generic.IEnumerable<string> patterns = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.MemoryStats MemoryStats(long? totalBytes = default(long?), long? availableBytes = default(long?), long? usedBytes = default(long?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy NamedEgressPolicy(string id = null, string name = null, string description = null, Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction defaultAction = default(Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction), Azure.Containers.Apps.Sandbox.Models.EgressPolicyEnforcementMode? enforcementMode = default(Azure.Containers.Apps.Sandbox.Models.EgressPolicyEnforcementMode?), System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRule> rules = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.NetworkEgressDecisions NetworkEgressDecisions(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.EgressDecisionEntry> allowed = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.EgressDecisionEntry> denied = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.NetworkStats NetworkStats(long? bytesReceived = default(long?), long? bytesSent = default(long?), long? packetsReceived = default(long?), long? packetsSent = default(long?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.OtlpTelemetryEndpoint OtlpTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.TelemetryData> data = null, System.Collections.Generic.IDictionary<string, Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn> columns = null, bool? dynamicJsonColumns = default(bool?), System.Uri endpoint = null, Azure.Containers.Apps.Sandbox.Models.TelemetryProtocol protocol = default(Azure.Containers.Apps.Sandbox.Models.TelemetryProtocol), Azure.Containers.Apps.Sandbox.Models.TelemetryHeaderAuthentication auth = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.PodContentPackage PodContentPackage(string contentPackageId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.PodSecurityContext PodSecurityContext(int? runAsUser = default(int?), int? runAsGroup = default(int?), bool? runAsNonRoot = default(bool?), System.Collections.Generic.IEnumerable<int> supplementalGroups = null, int? fsGroup = default(int?), Azure.Containers.Apps.Sandbox.Models.FsGroupChangePolicy? fsGroupChangePolicy = default(Azure.Containers.Apps.Sandbox.Models.FsGroupChangePolicy?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.PodVolume PodVolume(string kind = null, string name = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.PodVolumeMountsContent PodVolumeMountsContent(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.PodVolume> volumes = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMounts> containerMounts = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.PortAuthConfig PortAuthConfig(bool? anonymous = default(bool?), Azure.Containers.Apps.Sandbox.Models.PortAuthConfigGithub github = null, Azure.Containers.Apps.Sandbox.Models.PortAuthConfigEntraId entraId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.PortAuthConfigEntraId PortAuthConfigEntraId(bool? enabled = default(bool?), System.Collections.Generic.IEnumerable<string> emails = null, System.Collections.Generic.IEnumerable<string> emailSuffixes = null, System.Collections.Generic.IEnumerable<string> objectIds = null, System.Collections.Generic.IEnumerable<string> tenantIds = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.PortAuthConfigGithub PortAuthConfigGithub(bool? enabled = default(bool?), System.Collections.Generic.IEnumerable<string> emails = null, System.Collections.Generic.IEnumerable<string> emailSuffixes = null, System.Collections.Generic.IEnumerable<string> usernames = null, System.Collections.Generic.IEnumerable<string> usernameSuffixes = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.PortCorsConfig PortCorsConfig(System.Collections.Generic.IEnumerable<string> allowOrigins = null, System.Collections.Generic.IEnumerable<string> allowMethods = null, System.Collections.Generic.IEnumerable<string> allowHeaders = null, bool? allowCredentials = default(bool?), int? maxAge = default(int?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.PortsListResult PortsListResult(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.SandboxPort> ports = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ProbeExecAction ProbeExecAction(System.Collections.Generic.IEnumerable<string> command = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ProbeHttpGetAction ProbeHttpGetAction(int port = 0, string path = null, string host = null, string scheme = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.ProbeHttpHeader> httpHeaders = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ProbeHttpHeader ProbeHttpHeader(string name = null, string value = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ProbeTcpSocketAction ProbeTcpSocketAction(int port = 0, string host = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.PublicDiskImage PublicDiskImage(string name = null, Azure.Containers.Apps.Sandbox.Models.DiskImageStatus status = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ReferenceTelemetryLogColumn ReferenceTelemetryLogColumn(Azure.Containers.Apps.Sandbox.Models.LogColumnRef refName = default(Azure.Containers.Apps.Sandbox.Models.LogColumnRef)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.RegistryAuthentication RegistryAuthentication(Azure.Containers.Apps.Sandbox.Models.RegistryCredentials registryCredentials = null, Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthentication identity = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.RegistryCredentials RegistryCredentials(string username = null, string token = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.RegistryDiskImageSource RegistryDiskImageSource(string imageReference = null, Azure.Containers.Apps.Sandbox.Models.RegistryAuthentication authentication = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.RemovePortContent RemovePortContent(string name = null, int? port = default(int?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxAgentIdentityRef SandboxAgentIdentityRef(string tenantId = null, string agentId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxAutoDeletePolicy SandboxAutoDeletePolicy(bool enabled = false, int? deleteIntervalInDays = default(int?), long? deleteIntervalInSeconds = default(long?), Azure.Containers.Apps.Sandbox.Models.AutoDeleteTrigger? trigger = default(Azure.Containers.Apps.Sandbox.Models.AutoDeleteTrigger?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxAutoSuspendPolicy SandboxAutoSuspendPolicy(bool enabled = false, int? intervalSeconds = default(int?), Azure.Containers.Apps.Sandbox.Models.SandboxSuspendMode? mode = default(Azure.Containers.Apps.Sandbox.Models.SandboxSuspendMode?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxConnection SandboxConnection(string id = null, string name = null, string type = null, Azure.Containers.Apps.Sandbox.Models.ResourceState state = default(Azure.Containers.Apps.Sandbox.Models.ResourceState), System.Collections.Generic.IDictionary<string, string> labels = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), bool? deletable = default(bool?), System.Collections.Generic.IEnumerable<string> usedBySandboxIds = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.McpPolicyRule> policyRules = null, System.Collections.Generic.IEnumerable<string> enabledToolGroups = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxContentPackageDownload SandboxContentPackageDownload(string contentPackageId = null, string targetPath = null, Azure.Containers.Apps.Sandbox.Models.ContentPackageAction? action = default(Azure.Containers.Apps.Sandbox.Models.ContentPackageAction?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxCountResult SandboxCountResult(int count = 0) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryContent SandboxDirectoryContent(string path = null, bool? createParents = default(bool?), int? mode = default(int?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryListingResult SandboxDirectoryListingResult(string path = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.SandboxFileInfo> entries = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy SandboxEgressPolicy(Azure.Containers.Apps.Sandbox.Models.HttpEgressSection http = null, Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction? defaultAction = default(Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction?), System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.EgressHostRule> hostRules = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRule> rules = null, Azure.Containers.Apps.Sandbox.Models.TdsEgressSection tds = null, Azure.Containers.Apps.Sandbox.Models.TransportEgressSection transportRules = null, Azure.Containers.Apps.Sandbox.Models.TrafficInspection? trafficInspection = default(Azure.Containers.Apps.Sandbox.Models.TrafficInspection?), Azure.Containers.Apps.Sandbox.Models.EgressPolicyEnforcementMode? enforcementMode = default(Azure.Containers.Apps.Sandbox.Models.EgressPolicyEnforcementMode?), System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.ValidationWarning> validationWarnings = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxExecuteCommandResult SandboxExecuteCommandResult(int exitCode = 0, string standardOutput = null, string standardError = null, long executionTimeMs = (long)0) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxExecuteShellCommandResult SandboxExecuteShellCommandResult(int exitCode = 0, string standardOutput = null, string standardError = null, long executionTimeMs = (long)0) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxFileInfo SandboxFileInfo(string name = null, string path = null, long size = (long)0, int mode = 0, bool isDirectory = false, bool isSymbolicLink = false, string symbolicLinkTarget = null, long modifiedTime = (long)0) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult SandboxFileOperationResult(bool success = false, string error = null, string message = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential SandboxGroupCredential(string name = null, string displayName = null, Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialProvider provider = default(Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialProvider), Azure.Containers.Apps.Sandbox.Models.ResourceState state = default(Azure.Containers.Apps.Sandbox.Models.ResourceState), Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSource source = null, Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialOrigin origin = default(Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialOrigin)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialConnectionRefDetails SandboxGroupCredentialConnectionRefDetails(Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthRecord authentication = null, System.Uri tokenExchangeEndpoint = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSource SandboxGroupCredentialSource(Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSourceKind kind = default(Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSourceKind), string connectionResourceId = null, Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialConnectionRefDetails connectionRefDetails = null, System.Collections.Generic.IDictionary<string, string> parameterValues = null, string connectionId = null, string connectionType = null, string connectionName = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector SandboxGroupIdentitySelector(string kind = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume SandboxGroupVolume(string type = null, string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.Containers.Apps.Sandbox.Models.VolumeProvisioningState provisioningState = default(Azure.Containers.Apps.Sandbox.Models.VolumeProvisioningState)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy SandboxLifecyclePolicy(Azure.Containers.Apps.Sandbox.Models.SandboxAutoSuspendPolicy autoSuspendPolicy = null, Azure.Containers.Apps.Sandbox.Models.SandboxAutoDeletePolicy autoDeletePolicy = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxPort SandboxPort(string name = null, int port = 0, System.Uri url = null, Azure.Containers.Apps.Sandbox.Models.PortAuthConfig auth = null, Azure.Containers.Apps.Sandbox.Models.PortActivationMode? activationMode = default(Azure.Containers.Apps.Sandbox.Models.PortActivationMode?), Azure.Containers.Apps.Sandbox.Models.PortProtocol? protocol = default(Azure.Containers.Apps.Sandbox.Models.PortProtocol?), Azure.Containers.Apps.Sandbox.Models.IPAccessControl ipAccessControl = null, Azure.Containers.Apps.Sandbox.Models.PortCorsConfig cors = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxPortUpdate SandboxPortUpdate(string name = null, int port = 0, System.Uri url = null, Azure.Containers.Apps.Sandbox.Models.PortAuthConfig auth = null, Azure.Containers.Apps.Sandbox.Models.PortActivationMode? activationMode = default(Azure.Containers.Apps.Sandbox.Models.PortActivationMode?), Azure.Containers.Apps.Sandbox.Models.PortProtocol? protocol = default(Azure.Containers.Apps.Sandbox.Models.PortProtocol?), Azure.Containers.Apps.Sandbox.Models.IPAccessControl ipAccessControl = null, Azure.Containers.Apps.Sandbox.Models.PortCorsConfig cors = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxPresetProperties SandboxPresetProperties(bool? isWorkIqConnectionEnabled = default(bool?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxProperties SandboxProperties(string id = null, System.Collections.Generic.IDictionary<string, string> labels = null, System.Collections.Generic.IEnumerable<string> entrypoint = null, System.Collections.Generic.IEnumerable<string> command = null, Azure.Containers.Apps.Sandbox.Models.SandboxSource sourcesRef = null, Azure.Containers.Apps.Sandbox.Models.SandboxResources resources = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.Containers.Apps.Sandbox.Models.SandboxState? state = default(Azure.Containers.Apps.Sandbox.Models.SandboxState?), Azure.Containers.Apps.Sandbox.Models.SandboxStateDetails stateDetails = null, string snapshotId = null, long? coldStorageSizeInMb = default(long?), System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.SandboxPort> ports = null, System.Collections.Generic.IEnumerable<string> connections = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.GatewayConnection> gatewayConnections = null, System.Collections.Generic.IEnumerable<string> credentialRefs = null, Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy egressPolicy = null, Azure.Core.ResourceIdentifier sandboxGroupId = null, string region = null, Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy lifecycle = null, System.Uri appUri = null, System.Uri managementUri = null, Azure.Containers.Apps.Sandbox.Models.SandboxAgentIdentityRef agentIdentity = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.SandboxVolume> volumes = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.SandboxContentPackageDownload> contentPackageDownloads = null, string vnetConnectionName = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.IdentitySetting> identitySettings = null, System.Collections.Generic.IEnumerable<string> outboundIPAddresses = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.ContainerStatus> containerStatuses = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxResources SandboxResources(string cpu = null, string memory = null, string disk = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxSecret SandboxSecret(string id = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot SandboxSnapshot(string id = null, System.Collections.Generic.IDictionary<string, string> labels = null, string sandboxId = null, System.DateTimeOffset createdAtUtc = default(System.DateTimeOffset), Azure.Containers.Apps.Sandbox.Models.SnapshotResources resources = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.SnapshotPodContainer> sourcePodContainers = null, long? sizeInMb = default(long?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxSource SandboxSource(Azure.Containers.Apps.Sandbox.Models.SandboxSourceDiskImage diskImage = null, Azure.Containers.Apps.Sandbox.Models.SandboxSourceSnapshot snapshot = null, Azure.Containers.Apps.Sandbox.Models.SandboxSourcePod pod = null, Azure.Containers.Apps.Sandbox.Models.SandboxSourceArtifactVersion artifactVersion = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxSourceArtifactVersion SandboxSourceArtifactVersion(string id = null, Azure.Containers.Apps.Sandbox.Models.SandboxSourceAuth auth = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxSourceAuth SandboxSourceAuth(string identity = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxSourceDiskImage SandboxSourceDiskImage(string id = null, string name = null, bool? isPublic = default(bool?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxSourcePod SandboxSourcePod(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.ContainerSpec> containers = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.PodVolume> volumes = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.PodContentPackage> contentPackages = null, Azure.Containers.Apps.Sandbox.Models.PodSecurityContext securityContext = null, Azure.Containers.Apps.Sandbox.Models.ContainerRestartPolicy? restartPolicy = default(Azure.Containers.Apps.Sandbox.Models.ContainerRestartPolicy?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxSourceSnapshot SandboxSourceSnapshot(string id = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxStateDetails SandboxStateDetails(Azure.Containers.Apps.Sandbox.Models.StoppedReason stoppedReason = default(Azure.Containers.Apps.Sandbox.Models.StoppedReason), System.DateTimeOffset stoppedOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxStatsResult SandboxStatsResult(Azure.Containers.Apps.Sandbox.Models.TokenUsageStats tokenUsage = null, Azure.Containers.Apps.Sandbox.Models.CpuStats cpu = null, Azure.Containers.Apps.Sandbox.Models.MemoryStats memory = null, Azure.Containers.Apps.Sandbox.Models.NetworkStats network = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.DiskStatsEntry> disk = null, double? uptimeSecs = default(double?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxVolume SandboxVolume(string volumeName = null, string mountpoint = null, bool? readOnly = default(bool?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxVolumeMountContent SandboxVolumeMountContent(Azure.Containers.Apps.Sandbox.Models.SandboxVolume volumeMount = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SeccompProfile SeccompProfile(Azure.Containers.Apps.Sandbox.Models.SeccompProfileType type = default(Azure.Containers.Apps.Sandbox.Models.SeccompProfileType)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SecretKeysResult SecretKeysResult(System.Collections.Generic.IEnumerable<string> keys = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SecretPeekResult SecretPeekResult(System.Collections.Generic.IDictionary<string, string> values = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ServiceManagedBlobPodVolume ServiceManagedBlobPodVolume(string name = null, string fileCacheSizeLimit = null, bool? readOnly = default(bool?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ServiceManagedBlobVolume ServiceManagedBlobVolume(string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.Containers.Apps.Sandbox.Models.VolumeProvisioningState provisioningState = default(Azure.Containers.Apps.Sandbox.Models.VolumeProvisioningState), Azure.Containers.Apps.Sandbox.Models.BlobVolumeUsage usage = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SetSecretContent SetSecretContent(System.Collections.Generic.IDictionary<string, string> values = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SnapshotCountResult SnapshotCountResult(int count = 0) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SnapshotPodContainer SnapshotPodContainer(string name = null, string diskImageId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SnapshotResources SnapshotResources(string cpu = null, string memory = null, string disk = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.StatefulTcpEgress StatefulTcpEgress(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.StatefulTcpEntry> connections = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.StatefulTcpEntry StatefulTcpEntry(System.DateTimeOffset timestamp = default(System.DateTimeOffset), string phase = null, string outcome = null, string connectorType = null, string server = null, int? port = default(int?), string database = null, string proxyLoginName = null, string sourceIP = null, string correlationId = null, long? bytesIn = default(long?), long? bytesOut = default(long?), long? durationMs = default(long?), string failureReason = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SystemAssignedSandboxGroupIdentitySelector SystemAssignedSandboxGroupIdentitySelector() { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TdsCredential TdsCredential(string name = null, Azure.Containers.Apps.Sandbox.Models.TdsAuthKind kind = default(Azure.Containers.Apps.Sandbox.Models.TdsAuthKind), string username = null, Azure.Containers.Apps.Sandbox.Models.EgressPolicySecretRef secretRef = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TdsEgressAction TdsEgressAction(Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType type = default(Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType), string credential = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TdsEgressMatch TdsEgressMatch(string host = null, System.Collections.Generic.IEnumerable<string> databases = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TdsEgressRule TdsEgressRule(string name = null, Azure.Containers.Apps.Sandbox.Models.TdsEgressMatch match = null, Azure.Containers.Apps.Sandbox.Models.TdsEgressAction action = null, Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookRef hookRef = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TdsEgressSection TdsEgressSection(Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType defaultAction = default(Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType), System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.TdsCredential> credentials = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.TdsEgressRule> rules = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TelemetryApplicationInsightsAuthentication TelemetryApplicationInsightsAuthentication(string secretId = null, string secretKey = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TelemetryAppSecretRef TelemetryAppSecretRef(string secretRef = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication TelemetryAuthentication(string kind = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TelemetryConfiguration TelemetryConfiguration(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint> endpoints = null, int? metricsIntervalSeconds = default(int?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint TelemetryEndpoint(string kind = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.TelemetryData> data = null, System.Collections.Generic.IDictionary<string, Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn> columns = null, bool? dynamicJsonColumns = default(bool?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TelemetryHeaderAuthentication TelemetryHeaderAuthentication(string headerName = null, string secretId = null, string secretKey = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn TelemetryLogColumn(string kind = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TelemetryManagedIdentityAuthentication TelemetryManagedIdentityAuthentication(string identity = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TelemetrySandboxGroupSecretRef TelemetrySandboxGroupSecretRef(string secretId = null, string secretKey = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference TelemetrySecretReference(string kind = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TelemetrySystemAssignedManagedIdentityAuthentication TelemetrySystemAssignedManagedIdentityAuthentication() { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TokenUsageStats TokenUsageStats(long? totalInputTokens = default(long?), long? totalOutputTokens = default(long?), int? requestCount = default(int?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TransportEgressRule TransportEgressRule(Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType action = default(Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType), Azure.Containers.Apps.Sandbox.Models.TransportProtocol protocol = default(Azure.Containers.Apps.Sandbox.Models.TransportProtocol), string destination = null, int port = 0) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TransportEgressSection TransportEgressSection(Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType defaultAction = default(Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType), System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.TransportEgressRule> rules = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.UpdatePolicyRulesContent UpdatePolicyRulesContent(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.McpPolicyRule> policyRules = null, System.Collections.Generic.IEnumerable<string> enabledToolGroups = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.UpdatePortsContent UpdatePortsContent(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.SandboxPortUpdate> ports = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.UserAssignedSandboxGroupIdentitySelector UserAssignedSandboxGroupIdentitySelector(string resourceId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.UserProvidedBlobPodVolume UserProvidedBlobPodVolume(string name = null, string fileCacheSizeLimit = null, bool? readOnly = default(bool?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.UserProvidedBlobVolume UserProvidedBlobVolume(string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.Containers.Apps.Sandbox.Models.VolumeProvisioningState provisioningState = default(Azure.Containers.Apps.Sandbox.Models.VolumeProvisioningState), string storageContainerResourceId = null, Azure.Containers.Apps.Sandbox.Models.BlobVolumeAuthentication auth = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ValidationWarning ValidationWarning(string code = null, string message = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.VolumeCountResult VolumeCountResult(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.VolumeTypeCount> counts = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.VolumeListDirectoryResult VolumeListDirectoryResult(string path = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.VolumePathItem> items = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.VolumePathItem VolumePathItem(string itemName = null, string path = null, bool isDirectory = false, long? sizeBytes = default(long?), System.DateTimeOffset? lastModifiedUtc = default(System.DateTimeOffset?), string contentType = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.VolumeTypeCount VolumeTypeCount(Azure.Containers.Apps.Sandbox.Models.VolumeType type = default(Azure.Containers.Apps.Sandbox.Models.VolumeType), int count = 0) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.WriteFileResult WriteFileResult(bool success = false, string error = null, long? bytesWritten = default(long?)) { throw null; }
    }
    public partial class AuthorizeConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.AuthorizeConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.AuthorizeConnectionContent>
    {
        public AuthorizeConnectionContent(System.Collections.Generic.IDictionary<string, string> parameterValues) { }
        public System.Collections.Generic.IDictionary<string, string> ParameterValues { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.AuthorizeConnectionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.AuthorizeConnectionContent authorizeConnectionContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.AuthorizeConnectionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.AuthorizeConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.AuthorizeConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.AuthorizeConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.AuthorizeConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.AuthorizeConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.AuthorizeConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.AuthorizeConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoDeleteTrigger : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.AutoDeleteTrigger>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoDeleteTrigger(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.AutoDeleteTrigger AfterCreation { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.AutoDeleteTrigger AfterSuspend { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.AutoDeleteTrigger other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.AutoDeleteTrigger left, Azure.Containers.Apps.Sandbox.Models.AutoDeleteTrigger right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.AutoDeleteTrigger (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.AutoDeleteTrigger? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.AutoDeleteTrigger left, Azure.Containers.Apps.Sandbox.Models.AutoDeleteTrigger right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BlobDiskImageSource : Azure.Containers.Apps.Sandbox.Models.DiskImageSource, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.BlobDiskImageSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.BlobDiskImageSource>
    {
        public BlobDiskImageSource(System.Uri blobSourceUri) { }
        public System.Uri BlobSourceUri { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.Models.DiskImageSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.DiskImageSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.BlobDiskImageSource System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.BlobDiskImageSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.BlobDiskImageSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.BlobDiskImageSource System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.BlobDiskImageSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.BlobDiskImageSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.BlobDiskImageSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BlobVolumeAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeAuthentication>
    {
        internal BlobVolumeAuthentication() { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.BlobVolumeAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.BlobVolumeAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.BlobVolumeAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.BlobVolumeAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobVolumeManagedIdentityAuthentication : Azure.Containers.Apps.Sandbox.Models.BlobVolumeAuthentication, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeManagedIdentityAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeManagedIdentityAuthentication>
    {
        public BlobVolumeManagedIdentityAuthentication(Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector identity) { }
        public Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector Identity { get { throw null; } set { } }
        protected override Azure.Containers.Apps.Sandbox.Models.BlobVolumeAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.BlobVolumeAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.BlobVolumeManagedIdentityAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeManagedIdentityAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeManagedIdentityAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.BlobVolumeManagedIdentityAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeManagedIdentityAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeManagedIdentityAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeManagedIdentityAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobVolumeUsage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeUsage>
    {
        internal BlobVolumeUsage() { }
        public System.DateTimeOffset CalculatedAtUtc { get { throw null; } }
        public long ItemCount { get { throw null; } }
        public long UsedBytes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.BlobVolumeUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.BlobVolumeUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.BlobVolumeUsage System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.BlobVolumeUsage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.BlobVolumeUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommitSandboxContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CommitSandboxContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CommitSandboxContent>
    {
        public CommitSandboxContent() { }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.CommitSandboxContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.CommitSandboxContent commitSandboxContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.CommitSandboxContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.CommitSandboxContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CommitSandboxContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CommitSandboxContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.CommitSandboxContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CommitSandboxContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CommitSandboxContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CommitSandboxContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommitSandboxResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CommitSandboxResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CommitSandboxResult>
    {
        internal CommitSandboxResult() { }
        public Azure.Containers.Apps.Sandbox.Models.DiskImage DiskImage { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.CommitSandboxResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.CommitSandboxResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.CommitSandboxResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.CommitSandboxResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CommitSandboxResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CommitSandboxResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.CommitSandboxResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CommitSandboxResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CommitSandboxResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CommitSandboxResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectionsListResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ConnectionsListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ConnectionsListResult>
    {
        internal ConnectionsListResult() { }
        public System.Collections.Generic.IList<string> ConnectionIds { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ConnectionsListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.ConnectionsListResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ConnectionsListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ConnectionsListResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ConnectionsListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ConnectionsListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ConnectionsListResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ConnectionsListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ConnectionsListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ConnectionsListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerProbe : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerProbe>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerProbe>
    {
        public ContainerProbe() { }
        public Azure.Containers.Apps.Sandbox.Models.ProbeExecAction Exec { get { throw null; } set { } }
        public int? FailureThreshold { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.ProbeHttpGetAction HttpGet { get { throw null; } set { } }
        public int? InitialDelaySeconds { get { throw null; } set { } }
        public int? PeriodSeconds { get { throw null; } set { } }
        public int? SuccessThreshold { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.ProbeTcpSocketAction TcpSocket { get { throw null; } set { } }
        public int? TerminationGracePeriodSeconds { get { throw null; } set { } }
        public int? TimeoutSeconds { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ContainerProbe JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ContainerProbe PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ContainerProbe System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerProbe>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerProbe>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ContainerProbe System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerProbe>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerProbe>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerProbe>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerProbeResult : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.ContainerProbeResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerProbeResult(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerProbeResult Failure { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerProbeResult Success { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerProbeResult Unknown { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.ContainerProbeResult other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.ContainerProbeResult left, Azure.Containers.Apps.Sandbox.Models.ContainerProbeResult right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.ContainerProbeResult (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.ContainerProbeResult? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.ContainerProbeResult left, Azure.Containers.Apps.Sandbox.Models.ContainerProbeResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerProbeStatus : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerProbeStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerProbeStatus>
    {
        internal ContainerProbeStatus() { }
        public int? ConsecutiveFailures { get { throw null; } }
        public int? ConsecutiveSuccesses { get { throw null; } }
        public System.DateTimeOffset? LastCheckedOn { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.ContainerProbeResult? LastResult { get { throw null; } }
        public System.DateTimeOffset? LastTransitionOn { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ContainerProbeStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ContainerProbeStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ContainerProbeStatus System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerProbeStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerProbeStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ContainerProbeStatus System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerProbeStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerProbeStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerProbeStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerResources : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerResources>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerResources>
    {
        public ContainerResources() { }
        public string Cpu { get { throw null; } set { } }
        public string Disk { get { throw null; } set { } }
        public string Memory { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ContainerResources JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ContainerResources PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ContainerResources System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ContainerResources System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRestartPolicy : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.ContainerRestartPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRestartPolicy(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerRestartPolicy Always { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerRestartPolicy Never { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerRestartPolicy OnFailure { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.ContainerRestartPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.ContainerRestartPolicy left, Azure.Containers.Apps.Sandbox.Models.ContainerRestartPolicy right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.ContainerRestartPolicy (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.ContainerRestartPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.ContainerRestartPolicy left, Azure.Containers.Apps.Sandbox.Models.ContainerRestartPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRuntimeState : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.ContainerRuntimeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRuntimeState(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerRuntimeState Running { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerRuntimeState Terminated { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerRuntimeState Unknown { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerRuntimeState Waiting { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.ContainerRuntimeState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.ContainerRuntimeState left, Azure.Containers.Apps.Sandbox.Models.ContainerRuntimeState right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.ContainerRuntimeState (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.ContainerRuntimeState? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.ContainerRuntimeState left, Azure.Containers.Apps.Sandbox.Models.ContainerRuntimeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerSecurityContext : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerSecurityContext>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerSecurityContext>
    {
        public ContainerSecurityContext() { }
        public bool? AllowPrivilegeEscalation { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.LinuxCapabilities Capabilities { get { throw null; } set { } }
        public bool? Privileged { get { throw null; } set { } }
        public bool? ReadOnlyRootFilesystem { get { throw null; } set { } }
        public int? RunAsGroup { get { throw null; } set { } }
        public bool? RunAsNonRoot { get { throw null; } set { } }
        public int? RunAsUser { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.SeccompProfile SeccompProfile { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ContainerSecurityContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ContainerSecurityContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ContainerSecurityContext System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerSecurityContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerSecurityContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ContainerSecurityContext System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerSecurityContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerSecurityContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerSecurityContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerSpec : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerSpec>
    {
        public ContainerSpec(string name) { }
        public System.Collections.Generic.IList<string> Arguments { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxSourceArtifactVersion ArtifactVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.SandboxContentPackageDownload> ContentPackageDownloads { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxSourceDiskImage DiskImage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Environment { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.ContainerProbe LivenessProbe { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.ContainerProbe ReadinessProbe { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.ContainerResources Resources { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.ContainerSecurityContext SecurityContext { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.ContainerProbe StartupProbe { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMount> VolumeMounts { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ContainerSpec JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ContainerSpec PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ContainerSpec System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ContainerSpec System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerStatus : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerStatus>
    {
        internal ContainerStatus() { }
        public int? LastExitCode { get { throw null; } }
        public System.DateTimeOffset? LastFinishedOn { get { throw null; } }
        public System.DateTimeOffset? LastStartedOn { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Containers.Apps.Sandbox.Models.ContainerProbeStatus> Probes { get { throw null; } }
        public bool Ready { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.ContainerStatusReason? Reason { get { throw null; } }
        public int RestartCount { get { throw null; } }
        public bool Started { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.ContainerRuntimeState State { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ContainerStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ContainerStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ContainerStatus System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ContainerStatus System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerStatusReason : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.ContainerStatusReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerStatusReason(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerStatusReason Completed { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerStatusReason CrashLoopBackOff { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerStatusReason Error { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerStatusReason RootfsResetFailed { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.ContainerStatusReason RootfsResetPending { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.ContainerStatusReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.ContainerStatusReason left, Azure.Containers.Apps.Sandbox.Models.ContainerStatusReason right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.ContainerStatusReason (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.ContainerStatusReason? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.ContainerStatusReason left, Azure.Containers.Apps.Sandbox.Models.ContainerStatusReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerVolumeMount : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMount>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMount>
    {
        public ContainerVolumeMount(string name, string mountPath) { }
        public string MountPath { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? ReadOnly { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMount JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMount PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMount System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMount System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerVolumeMounts : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMounts>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMounts>
    {
        public ContainerVolumeMounts(string containerName, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMount> volumeMounts) { }
        public string ContainerName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMount> VolumeMounts { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMounts JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMounts PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMounts System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMounts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMounts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMounts System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMounts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMounts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMounts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentPackage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContentPackage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContentPackage>
    {
        internal ContentPackage() { }
        public string ContentType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public long Size { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ContentPackage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.ContentPackage (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ContentPackage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ContentPackage System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContentPackage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ContentPackage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ContentPackage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContentPackage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContentPackage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ContentPackage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentPackageAction : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.ContentPackageAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentPackageAction(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ContentPackageAction Download { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.ContentPackageAction Mount { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.ContentPackageAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.ContentPackageAction left, Azure.Containers.Apps.Sandbox.Models.ContentPackageAction right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.ContentPackageAction (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.ContentPackageAction? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.ContentPackageAction left, Azure.Containers.Apps.Sandbox.Models.ContentPackageAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CpuStats : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CpuStats>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CpuStats>
    {
        internal CpuStats() { }
        public long? Idle { get { throw null; } }
        public long? Iowait { get { throw null; } }
        public long? Irq { get { throw null; } }
        public double? LoadAverage15Minutes { get { throw null; } }
        public double? LoadAverage1Minute { get { throw null; } }
        public double? LoadAverage5Minutes { get { throw null; } }
        public long? Nice { get { throw null; } }
        public long? Softirq { get { throw null; } }
        public long? Steal { get { throw null; } }
        public long? System { get { throw null; } }
        public long? User { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.CpuStats JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.CpuStats PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.CpuStats System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CpuStats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CpuStats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.CpuStats System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CpuStats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CpuStats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CpuStats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateConnectionContent>
    {
        public CreateConnectionContent(string name, string type) { }
        public System.Collections.Generic.IList<string> EnabledToolGroups { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public string Name { get { throw null; } }
        public string ParameterValueSetName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ParameterValueSetValues { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.McpPolicyRule> PolicyRules { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.CreateConnectionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.CreateConnectionContent createConnectionContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.CreateConnectionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.CreateConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.CreateConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateDiskImageContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateDiskImageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateDiskImageContent>
    {
        public CreateDiskImageContent(Azure.Containers.Apps.Sandbox.Models.DiskImageSource source) { }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.DiskImageSource Source { get { throw null; } }
        public string VnetConnectionName { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.CreateDiskImageContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.CreateDiskImageContent createDiskImageContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.CreateDiskImageContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.CreateDiskImageContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateDiskImageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateDiskImageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.CreateDiskImageContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateDiskImageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateDiskImageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateDiskImageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSandboxContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxContent>
    {
        public CreateSandboxContent() { }
        public Azure.Containers.Apps.Sandbox.Models.SandboxAgentIdentityRef AgentIdentity { get { throw null; } set { } }
        public string AnthropicApiKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<string> Connections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.SandboxContentPackageDownload> ContentPackageDownloads { get { throw null; } }
        public System.Collections.Generic.IList<string> CredentialRefs { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy EgressPolicy { get { throw null; } set { } }
        public string EgressPolicyId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Entrypoint { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Environment { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.CreateSandboxGatewayConnectionContent> GatewayConnections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.IdentitySetting> IdentitySettings { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy Lifecycle { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.CreateSandboxPortContent> Ports { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxPresetProperties PresetProperties { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.PresetSandboxType? PresetSandboxType { get { throw null; } set { } }
        public string ProjectId { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxResources Resources { get { throw null; } set { } }
        public string SandboxGroupId { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxSource SourcesRef { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.TelemetryConfiguration TelemetryConfig { get { throw null; } set { } }
        public string VnetConnectionName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.SandboxVolume> Volumes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.CreateSandboxContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.CreateSandboxContent createSandboxContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.CreateSandboxContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.CreateSandboxContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.CreateSandboxContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSandboxGatewayConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxGatewayConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxGatewayConnectionContent>
    {
        public CreateSandboxGatewayConnectionContent(Azure.Core.ResourceIdentifier resourceId) { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.CreateSandboxGatewayConnectionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.CreateSandboxGatewayConnectionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.CreateSandboxGatewayConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxGatewayConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxGatewayConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.CreateSandboxGatewayConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxGatewayConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxGatewayConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxGatewayConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSandboxGroupCredentialContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxGroupCredentialContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxGroupCredentialContent>
    {
        public CreateSandboxGroupCredentialContent(Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialProvider provider, Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSource source) { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialProvider Provider { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSource Source { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.CreateSandboxGroupCredentialContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.CreateSandboxGroupCredentialContent createSandboxGroupCredentialContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.CreateSandboxGroupCredentialContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.CreateSandboxGroupCredentialContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxGroupCredentialContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxGroupCredentialContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.CreateSandboxGroupCredentialContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxGroupCredentialContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxGroupCredentialContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxGroupCredentialContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSandboxPortContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxPortContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxPortContent>
    {
        public CreateSandboxPortContent(int port) { }
        public Azure.Containers.Apps.Sandbox.Models.PortActivationMode? ActivationMode { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.PortAuthConfig Auth { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.PortCorsConfig Cors { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.IPAccessControl IPAccessControl { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int Port { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.PortProtocol? Protocol { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.CreateSandboxPortContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.CreateSandboxPortContent createSandboxPortContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.CreateSandboxPortContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.CreateSandboxPortContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxPortContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxPortContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.CreateSandboxPortContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxPortContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxPortContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateSandboxPortContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSnapshotContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateSnapshotContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateSnapshotContent>
    {
        public CreateSnapshotContent() { }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.CreateSnapshotContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.CreateSnapshotContent createSnapshotContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.CreateSnapshotContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.CreateSnapshotContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateSnapshotContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.CreateSnapshotContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.CreateSnapshotContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateSnapshotContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateSnapshotContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.CreateSnapshotContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataDiskPodVolume : Azure.Containers.Apps.Sandbox.Models.PodVolume, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DataDiskPodVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DataDiskPodVolume>
    {
        public DataDiskPodVolume(string name) { }
        protected override Azure.Containers.Apps.Sandbox.Models.PodVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.PodVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.DataDiskPodVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DataDiskPodVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DataDiskPodVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.DataDiskPodVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DataDiskPodVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DataDiskPodVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DataDiskPodVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataDiskVolume : Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DataDiskVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DataDiskVolume>
    {
        public DataDiskVolume(string size) { }
        public string AttachedSandboxId { get { throw null; } }
        public string ClusterId { get { throw null; } }
        public bool IsAttached { get { throw null; } }
        public string Size { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.DataDiskVolumeUsage Usage { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.DataDiskVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DataDiskVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DataDiskVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.DataDiskVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DataDiskVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DataDiskVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DataDiskVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataDiskVolumeUsage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DataDiskVolumeUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DataDiskVolumeUsage>
    {
        internal DataDiskVolumeUsage() { }
        public long CompressedBlobSizeBytes { get { throw null; } }
        public System.DateTimeOffset LastUploadedAtUtc { get { throw null; } }
        public long UsedSizeBytes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.DataDiskVolumeUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.DataDiskVolumeUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.DataDiskVolumeUsage System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DataDiskVolumeUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DataDiskVolumeUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.DataDiskVolumeUsage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DataDiskVolumeUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DataDiskVolumeUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DataDiskVolumeUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskImage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DiskImage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DiskImage>
    {
        internal DiskImage() { }
        public string Id { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.ImageMetadata Image { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public string Name { get { throw null; } }
        public long? SizeInMb { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.DiskImageStatus Status { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.DiskImage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.DiskImage (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.DiskImage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.DiskImage System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DiskImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DiskImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.DiskImage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DiskImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DiskImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DiskImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DiskImageSource : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DiskImageSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DiskImageSource>
    {
        internal DiskImageSource() { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.DiskImageSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.DiskImageSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.DiskImageSource System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DiskImageSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DiskImageSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.DiskImageSource System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DiskImageSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DiskImageSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DiskImageSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskImageStatus : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DiskImageStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DiskImageStatus>
    {
        internal DiskImageStatus() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.ResourceState State { get { throw null; } }
        public System.DateTimeOffset UpdatedOn { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.DiskImageStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.DiskImageStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.DiskImageStatus System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DiskImageStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DiskImageStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.DiskImageStatus System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DiskImageStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DiskImageStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DiskImageStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskStatsEntry : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DiskStatsEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DiskStatsEntry>
    {
        internal DiskStatsEntry() { }
        public long? AvailableBytes { get { throw null; } }
        public string Filesystem { get { throw null; } }
        public string Label { get { throw null; } }
        public string MountPoint { get { throw null; } }
        public long? TotalBytes { get { throw null; } }
        public long? UsedBytes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.DiskStatsEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.DiskStatsEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.DiskStatsEntry System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DiskStatsEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DiskStatsEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.DiskStatsEntry System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DiskStatsEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DiskStatsEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DiskStatsEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DownloadContentPackageToSandboxContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DownloadContentPackageToSandboxContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DownloadContentPackageToSandboxContent>
    {
        public DownloadContentPackageToSandboxContent(string contentPackageId, string targetPath) { }
        public string ContentPackageId { get { throw null; } }
        public string TargetPath { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.DownloadContentPackageToSandboxContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.DownloadContentPackageToSandboxContent downloadContentPackageToSandboxContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.DownloadContentPackageToSandboxContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.DownloadContentPackageToSandboxContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DownloadContentPackageToSandboxContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.DownloadContentPackageToSandboxContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.DownloadContentPackageToSandboxContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DownloadContentPackageToSandboxContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DownloadContentPackageToSandboxContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.DownloadContentPackageToSandboxContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressDecisionEntry : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressDecisionEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressDecisionEntry>
    {
        internal EgressDecisionEntry() { }
        public string ConnectionId { get { throw null; } }
        public string ConnectionName { get { throw null; } }
        public string Host { get { throw null; } }
        public string MatchedRule { get { throw null; } }
        public string Method { get { throw null; } }
        public string Path { get { throw null; } }
        public string Scheme { get { throw null; } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressDecisionEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressDecisionEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.EgressDecisionEntry System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressDecisionEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressDecisionEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.EgressDecisionEntry System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressDecisionEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressDecisionEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressDecisionEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressDecisionsResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressDecisionsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressDecisionsResult>
    {
        internal EgressDecisionsResult() { }
        public Azure.Containers.Apps.Sandbox.Models.NetworkEgressDecisions Http { get { throw null; } }
        public System.DateTimeOffset LastUpdated { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.StatefulTcpEgress StatefulTcp { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressDecisionsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.EgressDecisionsResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressDecisionsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.EgressDecisionsResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressDecisionsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressDecisionsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.EgressDecisionsResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressDecisionsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressDecisionsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressDecisionsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressForwardMode : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.EgressForwardMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressForwardMode(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressForwardMode Default { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.EgressForwardMode Direct { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.EgressForwardMode Proxy { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.EgressForwardMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.EgressForwardMode left, Azure.Containers.Apps.Sandbox.Models.EgressForwardMode right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.EgressForwardMode (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.EgressForwardMode? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.EgressForwardMode left, Azure.Containers.Apps.Sandbox.Models.EgressForwardMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EgressForwardProxy : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressForwardProxy>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressForwardProxy>
    {
        public EgressForwardProxy(System.Uri url) { }
        public string CertificateAuthority { get { throw null; } set { } }
        public System.Uri Url { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressForwardProxy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressForwardProxy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.EgressForwardProxy System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressForwardProxy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressForwardProxy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.EgressForwardProxy System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressForwardProxy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressForwardProxy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressForwardProxy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressHostRule : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressHostRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressHostRule>
    {
        public EgressHostRule(string pattern) { }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction? Action { get { throw null; } set { } }
        public string Pattern { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressHostRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressHostRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.EgressHostRule System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressHostRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressHostRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.EgressHostRule System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressHostRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressHostRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressHostRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyAction : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyAction(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction Allow { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction Deny { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction left, Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction left, Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyActionType : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyActionType(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType Allow { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType Deny { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType Rewrite { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType Transform { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType left, Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType left, Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyEnforcementMode : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.EgressPolicyEnforcementMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyEnforcementMode(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyEnforcementMode Audit { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyEnforcementMode Enforced { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.EgressPolicyEnforcementMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.EgressPolicyEnforcementMode left, Azure.Containers.Apps.Sandbox.Models.EgressPolicyEnforcementMode right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.EgressPolicyEnforcementMode (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.EgressPolicyEnforcementMode? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.EgressPolicyEnforcementMode left, Azure.Containers.Apps.Sandbox.Models.EgressPolicyEnforcementMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyHeaderOperation : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyHeaderOperation(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderOperation Insert { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderOperation Remove { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderOperation Set { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderOperation other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderOperation left, Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderOperation right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderOperation (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderOperation? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderOperation left, Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EgressPolicyHeaderTransform : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderTransform>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderTransform>
    {
        public EgressPolicyHeaderTransform(Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderOperation operation, string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderOperation Operation { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyValueRef ValueRef { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderTransform JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderTransform PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderTransform System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderTransform>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderTransform>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderTransform System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderTransform>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderTransform>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderTransform>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyHookFailBehavior : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookFailBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyHookFailBehavior(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookFailBehavior Allow { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookFailBehavior Deny { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookFailBehavior other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookFailBehavior left, Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookFailBehavior right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookFailBehavior (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookFailBehavior? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookFailBehavior left, Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookFailBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EgressPolicyHookRef : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookRef>
    {
        public EgressPolicyHookRef(System.Uri endpoint) { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderTransform> AuthHeaders { get { throw null; } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookFailBehavior? FailBehavior { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequestHeaders { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.EgressRuleRoutingMode? RoutingMode { get { throw null; } set { } }
        public int? TimeoutMs { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressPolicyManagedIdentityRef : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityRef>
    {
        public EgressPolicyManagedIdentityRef(string resource) { }
        public string Format { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier IdentityResourceId { get { throw null; } set { } }
        public string Resource { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityType? Type { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyManagedIdentityType : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyManagedIdentityType(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityType SystemAssigned { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityType left, Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityType right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityType (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityType left, Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyMatchScheme : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.EgressPolicyMatchScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyMatchScheme(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyMatchScheme Any { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyMatchScheme Http { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.EgressPolicyMatchScheme Https { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.EgressPolicyMatchScheme other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.EgressPolicyMatchScheme left, Azure.Containers.Apps.Sandbox.Models.EgressPolicyMatchScheme right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.EgressPolicyMatchScheme (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.EgressPolicyMatchScheme? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.EgressPolicyMatchScheme left, Azure.Containers.Apps.Sandbox.Models.EgressPolicyMatchScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EgressPolicyRule : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRule>
    {
        public EgressPolicyRule(string name, Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleMatch match) { }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleAction Action { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookRef HookRef { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleMatch Match { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProxyActions { get { throw null; } }
        public string Source { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressPolicyRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressPolicyRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.EgressPolicyRule System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.EgressPolicyRule System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressPolicyRuleAction : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleAction>
    {
        public EgressPolicyRuleAction(Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType type) { }
        public Azure.Containers.Apps.Sandbox.Models.EgressForwardMode? Forward { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.EgressForwardProxy ForwardProxy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.EgressPolicyHeaderTransform> Headers { get { throw null; } }
        public string Host { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.EgressRuleRoutingMode? RoutingMode { get { throw null; } set { } }
        public string Scheme { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType Type { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleAction System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleAction System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressPolicyRuleMatch : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleMatch>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleMatch>
    {
        public EgressPolicyRuleMatch(string host) { }
        public string Host { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Methods { get { throw null; } }
        public bool? NormalizePath { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyMatchScheme? Scheme { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleMatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleMatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleMatch System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleMatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleMatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleMatch System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleMatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleMatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRuleMatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressPolicySecretRef : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicySecretRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicySecretRef>
    {
        public EgressPolicySecretRef(string secretId) { }
        public string Format { get { throw null; } set { } }
        public string SecretId { get { throw null; } set { } }
        public string SecretKey { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressPolicySecretRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressPolicySecretRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.EgressPolicySecretRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicySecretRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicySecretRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.EgressPolicySecretRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicySecretRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicySecretRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicySecretRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressPolicyValueRef : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyValueRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyValueRef>
    {
        public EgressPolicyValueRef() { }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyManagedIdentityRef ManagedIdentityRef { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicySecretRef SecretRef { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressPolicyValueRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.EgressPolicyValueRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.EgressPolicyValueRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyValueRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyValueRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.EgressPolicyValueRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyValueRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyValueRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.EgressPolicyValueRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressRuleRoutingMode : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.EgressRuleRoutingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressRuleRoutingMode(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.EgressRuleRoutingMode Default { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.EgressRuleRoutingMode Platform { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.EgressRuleRoutingMode Vnet { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.EgressRuleRoutingMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.EgressRuleRoutingMode left, Azure.Containers.Apps.Sandbox.Models.EgressRuleRoutingMode right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.EgressRuleRoutingMode (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.EgressRuleRoutingMode? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.EgressRuleRoutingMode left, Azure.Containers.Apps.Sandbox.Models.EgressRuleRoutingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExecuteSandboxCommandContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxCommandContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxCommandContent>
    {
        public ExecuteSandboxCommandContent(string command) { }
        public Azure.Containers.Apps.Sandbox.Models.PortActivationMode? ActivationMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Arguments { get { throw null; } }
        public string Command { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Environment { get { throw null; } }
        public string User { get { throw null; } set { } }
        public string WorkingDirectory { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxCommandContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxCommandContent executeSandboxCommandContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxCommandContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxCommandContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxCommandContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxCommandContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxCommandContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxCommandContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxCommandContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxCommandContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteSandboxShellCommandContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxShellCommandContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxShellCommandContent>
    {
        public ExecuteSandboxShellCommandContent(string command) { }
        public Azure.Containers.Apps.Sandbox.Models.PortActivationMode? ActivationMode { get { throw null; } set { } }
        public string Command { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Environment { get { throw null; } }
        public string Shell { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
        public string WorkingDirectory { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxShellCommandContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxShellCommandContent executeSandboxShellCommandContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxShellCommandContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxShellCommandContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxShellCommandContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxShellCommandContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxShellCommandContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxShellCommandContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxShellCommandContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ExecuteSandboxShellCommandContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ForkDataDiskVolumeContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ForkDataDiskVolumeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ForkDataDiskVolumeContent>
    {
        public ForkDataDiskVolumeContent(string destinationVolumeName) { }
        public string DestinationVolumeName { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ForkDataDiskVolumeContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.ForkDataDiskVolumeContent forkDataDiskVolumeContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ForkDataDiskVolumeContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ForkDataDiskVolumeContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ForkDataDiskVolumeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ForkDataDiskVolumeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ForkDataDiskVolumeContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ForkDataDiskVolumeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ForkDataDiskVolumeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ForkDataDiskVolumeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FsGroupChangePolicy : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.FsGroupChangePolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FsGroupChangePolicy(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.FsGroupChangePolicy Always { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.FsGroupChangePolicy None { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.FsGroupChangePolicy OnRootMismatch { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.FsGroupChangePolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.FsGroupChangePolicy left, Azure.Containers.Apps.Sandbox.Models.FsGroupChangePolicy right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.FsGroupChangePolicy (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.FsGroupChangePolicy? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.FsGroupChangePolicy left, Azure.Containers.Apps.Sandbox.Models.FsGroupChangePolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GatewayAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.GatewayAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.GatewayAuthentication>
    {
        internal GatewayAuthentication() { }
        public Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthentication Identity { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.GatewayAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.GatewayAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.GatewayAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.GatewayAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.GatewayAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.GatewayAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.GatewayAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.GatewayAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.GatewayAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GatewayConnection : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.GatewayConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.GatewayConnection>
    {
        internal GatewayConnection() { }
        public Azure.Containers.Apps.Sandbox.Models.GatewayAuthentication Authentication { get { throw null; } }
        public System.Uri ConnectionRuntimeUri { get { throw null; } }
        public System.Uri McpRuntimeUri { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceId { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.GatewayConnection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.GatewayConnection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.GatewayConnection System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.GatewayConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.GatewayConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.GatewayConnection System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.GatewayConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.GatewayConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.GatewayConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GatewayConnectionAuthRecord : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthRecord>
    {
        public GatewayConnectionAuthRecord(Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthType type) { }
        public string IdentityResourceId { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthType Type { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthRecord System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthRecord System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GatewayConnectionAuthType : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GatewayConnectionAuthType(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthType SystemAssignedManagedIdentity { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthType UserAssignedManagedIdentity { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthType left, Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthType right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthType (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthType left, Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GenerateConsentLinkContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkContent>
    {
        public GenerateConsentLinkContent() { }
        public System.Uri RedirectUri { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkContent generateConsentLinkContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenerateConsentLinkResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkResult>
    {
        internal GenerateConsentLinkResult() { }
        public System.Uri ConsentLink { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.GenerateConsentLinkResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HttpEgressSection : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.HttpEgressSection>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.HttpEgressSection>
    {
        public HttpEgressSection(Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction defaultAction) { }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction DefaultAction { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.EgressForwardProxy DefaultForward { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyEnforcementMode? EnforcementMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.EgressHostRule> HostRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRule> Rules { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.TrafficInspection? TrafficInspection { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.HttpEgressSection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.HttpEgressSection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.HttpEgressSection System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.HttpEgressSection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.HttpEgressSection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.HttpEgressSection System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.HttpEgressSection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.HttpEgressSection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.HttpEgressSection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IdentitySetting : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.IdentitySetting>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.IdentitySetting>
    {
        public IdentitySetting(string identity) { }
        public string Identity { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.IdentitySettingLifecycle? Lifecycle { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.IdentitySetting JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.IdentitySetting PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.IdentitySetting System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.IdentitySetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.IdentitySetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.IdentitySetting System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.IdentitySetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.IdentitySetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.IdentitySetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentitySettingLifecycle : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.IdentitySettingLifecycle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentitySettingLifecycle(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.IdentitySettingLifecycle All { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.IdentitySettingLifecycle Main { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.IdentitySettingLifecycle None { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.IdentitySettingLifecycle other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.IdentitySettingLifecycle left, Azure.Containers.Apps.Sandbox.Models.IdentitySettingLifecycle right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.IdentitySettingLifecycle (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.IdentitySettingLifecycle? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.IdentitySettingLifecycle left, Azure.Containers.Apps.Sandbox.Models.IdentitySettingLifecycle right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageMetadata : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ImageMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ImageMetadata>
    {
        internal ImageMetadata() { }
        public string BaseImage { get { throw null; } }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<string> Entrypoint { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ImageMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ImageMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ImageMetadata System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ImageMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ImageMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ImageMetadata System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ImageMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ImageMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ImageMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IPAccessControl : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.IPAccessControl>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.IPAccessControl>
    {
        public IPAccessControl(Azure.Containers.Apps.Sandbox.Models.IPAccessControlAction defaultAction) { }
        public Azure.Containers.Apps.Sandbox.Models.IPAccessControlAction DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.IPAccessControlRule> Rules { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.IPAccessControl JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.IPAccessControl PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.IPAccessControl System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.IPAccessControl>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.IPAccessControl>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.IPAccessControl System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.IPAccessControl>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.IPAccessControl>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.IPAccessControl>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPAccessControlAction : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.IPAccessControlAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPAccessControlAction(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.IPAccessControlAction Allow { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.IPAccessControlAction Deny { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.IPAccessControlAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.IPAccessControlAction left, Azure.Containers.Apps.Sandbox.Models.IPAccessControlAction right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.IPAccessControlAction (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.IPAccessControlAction? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.IPAccessControlAction left, Azure.Containers.Apps.Sandbox.Models.IPAccessControlAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPAccessControlRule : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.IPAccessControlRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.IPAccessControlRule>
    {
        public IPAccessControlRule(string name, Azure.Containers.Apps.Sandbox.Models.IPAccessControlAction action, int priority, System.Collections.Generic.IEnumerable<string> sourceAddressPrefixes) { }
        public Azure.Containers.Apps.Sandbox.Models.IPAccessControlAction Action { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourceAddressPrefixes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.IPAccessControlRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.IPAccessControlRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.IPAccessControlRule System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.IPAccessControlRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.IPAccessControlRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.IPAccessControlRule System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.IPAccessControlRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.IPAccessControlRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.IPAccessControlRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinuxCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.LinuxCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.LinuxCapabilities>
    {
        public LinuxCapabilities() { }
        public System.Collections.Generic.IList<string> Add { get { throw null; } }
        public System.Collections.Generic.IList<string> Drop { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.LinuxCapabilities JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.LinuxCapabilities PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.LinuxCapabilities System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.LinuxCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.LinuxCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.LinuxCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.LinuxCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.LinuxCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.LinuxCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiteralTelemetryLogColumn : Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.LiteralTelemetryLogColumn>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.LiteralTelemetryLogColumn>
    {
        public LiteralTelemetryLogColumn(string value) { }
        public string Value { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.LiteralTelemetryLogColumn System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.LiteralTelemetryLogColumn>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.LiteralTelemetryLogColumn>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.LiteralTelemetryLogColumn System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.LiteralTelemetryLogColumn>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.LiteralTelemetryLogColumn>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.LiteralTelemetryLogColumn>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LocalPodVolume : Azure.Containers.Apps.Sandbox.Models.PodVolume, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.LocalPodVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.LocalPodVolume>
    {
        public LocalPodVolume(string name, string size) { }
        public string Size { get { throw null; } set { } }
        protected override Azure.Containers.Apps.Sandbox.Models.PodVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.PodVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.LocalPodVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.LocalPodVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.LocalPodVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.LocalPodVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.LocalPodVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.LocalPodVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.LocalPodVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAnalyticsLegacyTelemetryEndpoint : Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.LogAnalyticsLegacyTelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.LogAnalyticsLegacyTelemetryEndpoint>
    {
        public LogAnalyticsLegacyTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.TelemetryData> data, string workspaceId, string tableName, Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference auth) { }
        public Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference Auth { get { throw null; } }
        public string TableName { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.LogAnalyticsLegacyTelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.LogAnalyticsLegacyTelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.LogAnalyticsLegacyTelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.LogAnalyticsLegacyTelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.LogAnalyticsLegacyTelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.LogAnalyticsLegacyTelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.LogAnalyticsLegacyTelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAnalyticsTelemetryEndpoint : Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.LogAnalyticsTelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.LogAnalyticsTelemetryEndpoint>
    {
        public LogAnalyticsTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.TelemetryData> data, System.Uri dceEndpoint, string dcrImmutableId, string tableName, Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication auth) { }
        public Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication Auth { get { throw null; } }
        public System.Uri DceEndpoint { get { throw null; } }
        public string DcrImmutableId { get { throw null; } }
        public string TableName { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.LogAnalyticsTelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.LogAnalyticsTelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.LogAnalyticsTelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.LogAnalyticsTelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.LogAnalyticsTelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.LogAnalyticsTelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.LogAnalyticsTelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogColumnRef : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.LogColumnRef>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogColumnRef(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.LogColumnRef ContainerName { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.LogColumnRef LogContent { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.LogColumnRef LogStream { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.LogColumnRef Region { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.LogColumnRef SandboxId { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.LogColumnRef other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.LogColumnRef left, Azure.Containers.Apps.Sandbox.Models.LogColumnRef right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.LogColumnRef (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.LogColumnRef? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.LogColumnRef left, Azure.Containers.Apps.Sandbox.Models.LogColumnRef right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedIdentityAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthentication>
    {
        public ManagedIdentityAuthentication(Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthenticationType type) { }
        public string IdentityResourceId { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthenticationType Type { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedIdentityAuthenticationType : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedIdentityAuthenticationType(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthenticationType SystemAssigned { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthenticationType UserAssigned { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthenticationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthenticationType left, Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthenticationType right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthenticationType (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthenticationType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthenticationType left, Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class McpPolicyRule : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.McpPolicyRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.McpPolicyRule>
    {
        public McpPolicyRule(string hookId, System.Collections.Generic.IEnumerable<string> patterns) { }
        public string HookId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Patterns { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.McpPolicyRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.McpPolicyRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.McpPolicyRule System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.McpPolicyRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.McpPolicyRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.McpPolicyRule System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.McpPolicyRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.McpPolicyRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.McpPolicyRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryStats : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.MemoryStats>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.MemoryStats>
    {
        internal MemoryStats() { }
        public long? AvailableBytes { get { throw null; } }
        public long? TotalBytes { get { throw null; } }
        public long? UsedBytes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.MemoryStats JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.MemoryStats PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.MemoryStats System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.MemoryStats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.MemoryStats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.MemoryStats System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.MemoryStats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.MemoryStats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.MemoryStats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamedEgressPolicy : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy>
    {
        public NamedEgressPolicy(string name, Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction defaultAction) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction DefaultAction { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyEnforcementMode? EnforcementMode { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRule> Rules { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy namedEgressPolicy) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.NamedEgressPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkEgressDecisions : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.NetworkEgressDecisions>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.NetworkEgressDecisions>
    {
        internal NetworkEgressDecisions() { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.EgressDecisionEntry> Allowed { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.EgressDecisionEntry> Denied { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.NetworkEgressDecisions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.NetworkEgressDecisions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.NetworkEgressDecisions System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.NetworkEgressDecisions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.NetworkEgressDecisions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.NetworkEgressDecisions System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.NetworkEgressDecisions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.NetworkEgressDecisions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.NetworkEgressDecisions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkStats : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.NetworkStats>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.NetworkStats>
    {
        internal NetworkStats() { }
        public long? BytesReceived { get { throw null; } }
        public long? BytesSent { get { throw null; } }
        public long? PacketsReceived { get { throw null; } }
        public long? PacketsSent { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.NetworkStats JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.NetworkStats PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.NetworkStats System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.NetworkStats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.NetworkStats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.NetworkStats System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.NetworkStats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.NetworkStats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.NetworkStats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OtlpTelemetryEndpoint : Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.OtlpTelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.OtlpTelemetryEndpoint>
    {
        public OtlpTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.TelemetryData> data, System.Uri endpoint, Azure.Containers.Apps.Sandbox.Models.TelemetryProtocol protocol) { }
        public Azure.Containers.Apps.Sandbox.Models.TelemetryHeaderAuthentication Auth { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.TelemetryProtocol Protocol { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.OtlpTelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.OtlpTelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.OtlpTelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.OtlpTelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.OtlpTelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.OtlpTelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.OtlpTelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PodContentPackage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PodContentPackage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PodContentPackage>
    {
        public PodContentPackage(string contentPackageId) { }
        public string ContentPackageId { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.PodContentPackage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.PodContentPackage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.PodContentPackage System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PodContentPackage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PodContentPackage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.PodContentPackage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PodContentPackage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PodContentPackage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PodContentPackage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PodSecurityContext : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PodSecurityContext>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PodSecurityContext>
    {
        public PodSecurityContext() { }
        public int? FsGroup { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.FsGroupChangePolicy? FsGroupChangePolicy { get { throw null; } set { } }
        public int? RunAsGroup { get { throw null; } set { } }
        public bool? RunAsNonRoot { get { throw null; } set { } }
        public int? RunAsUser { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SupplementalGroups { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.PodSecurityContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.PodSecurityContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.PodSecurityContext System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PodSecurityContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PodSecurityContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.PodSecurityContext System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PodSecurityContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PodSecurityContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PodSecurityContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class PodVolume : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PodVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PodVolume>
    {
        internal PodVolume() { }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.PodVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.PodVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.PodVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PodVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PodVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.PodVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PodVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PodVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PodVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PodVolumeMountsContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PodVolumeMountsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PodVolumeMountsContent>
    {
        public PodVolumeMountsContent(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.PodVolume> volumes, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMounts> containerMounts) { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.ContainerVolumeMounts> ContainerMounts { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.PodVolume> Volumes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.PodVolumeMountsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.PodVolumeMountsContent podVolumeMountsContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.PodVolumeMountsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.PodVolumeMountsContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PodVolumeMountsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PodVolumeMountsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.PodVolumeMountsContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PodVolumeMountsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PodVolumeMountsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PodVolumeMountsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PortActivationMode : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.PortActivationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortActivationMode(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.PortActivationMode Manual { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.PortActivationMode OnDemand { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.PortActivationMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.PortActivationMode left, Azure.Containers.Apps.Sandbox.Models.PortActivationMode right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.PortActivationMode (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.PortActivationMode? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.PortActivationMode left, Azure.Containers.Apps.Sandbox.Models.PortActivationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PortAuthConfig : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfig>
    {
        public PortAuthConfig() { }
        public bool? Anonymous { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.PortAuthConfigEntraId EntraId { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.PortAuthConfigGithub Github { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.PortAuthConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.PortAuthConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.PortAuthConfig System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.PortAuthConfig System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PortAuthConfigEntraId : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfigEntraId>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfigEntraId>
    {
        public PortAuthConfigEntraId() { }
        public System.Collections.Generic.IList<string> Emails { get { throw null; } }
        public System.Collections.Generic.IList<string> EmailSuffixes { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ObjectIds { get { throw null; } }
        public System.Collections.Generic.IList<string> TenantIds { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.PortAuthConfigEntraId JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.PortAuthConfigEntraId PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.PortAuthConfigEntraId System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfigEntraId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfigEntraId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.PortAuthConfigEntraId System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfigEntraId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfigEntraId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfigEntraId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PortAuthConfigGithub : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfigGithub>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfigGithub>
    {
        public PortAuthConfigGithub() { }
        public System.Collections.Generic.IList<string> Emails { get { throw null; } }
        public System.Collections.Generic.IList<string> EmailSuffixes { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Usernames { get { throw null; } }
        public System.Collections.Generic.IList<string> UsernameSuffixes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.PortAuthConfigGithub JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.PortAuthConfigGithub PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.PortAuthConfigGithub System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfigGithub>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfigGithub>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.PortAuthConfigGithub System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfigGithub>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfigGithub>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PortAuthConfigGithub>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PortCorsConfig : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PortCorsConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PortCorsConfig>
    {
        public PortCorsConfig() { }
        public bool? AllowCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AllowHeaders { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowMethods { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowOrigins { get { throw null; } }
        public int? MaxAge { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.PortCorsConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.PortCorsConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.PortCorsConfig System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PortCorsConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PortCorsConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.PortCorsConfig System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PortCorsConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PortCorsConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PortCorsConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PortProtocol : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.PortProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortProtocol(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.PortProtocol Http { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.PortProtocol Http2 { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.PortProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.PortProtocol left, Azure.Containers.Apps.Sandbox.Models.PortProtocol right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.PortProtocol (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.PortProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.PortProtocol left, Azure.Containers.Apps.Sandbox.Models.PortProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PortsListResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PortsListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PortsListResult>
    {
        internal PortsListResult() { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.SandboxPort> Ports { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.PortsListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.PortsListResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.PortsListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.PortsListResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PortsListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PortsListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.PortsListResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PortsListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PortsListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PortsListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PresetSandboxType : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.PresetSandboxType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PresetSandboxType(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.PresetSandboxType Claude { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.PresetSandboxType GitHubCopilot { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.PresetSandboxType None { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.PresetSandboxType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.PresetSandboxType left, Azure.Containers.Apps.Sandbox.Models.PresetSandboxType right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.PresetSandboxType (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.PresetSandboxType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.PresetSandboxType left, Azure.Containers.Apps.Sandbox.Models.PresetSandboxType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProbeExecAction : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ProbeExecAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ProbeExecAction>
    {
        public ProbeExecAction(System.Collections.Generic.IEnumerable<string> command) { }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ProbeExecAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ProbeExecAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ProbeExecAction System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ProbeExecAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ProbeExecAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ProbeExecAction System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ProbeExecAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ProbeExecAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ProbeExecAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProbeHttpGetAction : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ProbeHttpGetAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ProbeHttpGetAction>
    {
        public ProbeHttpGetAction(int port) { }
        public string Host { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.ProbeHttpHeader> HttpHeaders { get { throw null; } }
        public string Path { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public string Scheme { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ProbeHttpGetAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ProbeHttpGetAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ProbeHttpGetAction System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ProbeHttpGetAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ProbeHttpGetAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ProbeHttpGetAction System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ProbeHttpGetAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ProbeHttpGetAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ProbeHttpGetAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProbeHttpHeader : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ProbeHttpHeader>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ProbeHttpHeader>
    {
        public ProbeHttpHeader(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ProbeHttpHeader JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ProbeHttpHeader PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ProbeHttpHeader System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ProbeHttpHeader>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ProbeHttpHeader>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ProbeHttpHeader System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ProbeHttpHeader>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ProbeHttpHeader>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ProbeHttpHeader>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProbeTcpSocketAction : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ProbeTcpSocketAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ProbeTcpSocketAction>
    {
        public ProbeTcpSocketAction(int port) { }
        public string Host { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ProbeTcpSocketAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ProbeTcpSocketAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ProbeTcpSocketAction System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ProbeTcpSocketAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ProbeTcpSocketAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ProbeTcpSocketAction System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ProbeTcpSocketAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ProbeTcpSocketAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ProbeTcpSocketAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicDiskImage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PublicDiskImage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PublicDiskImage>
    {
        internal PublicDiskImage() { }
        public string Name { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.DiskImageStatus Status { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.PublicDiskImage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.PublicDiskImage (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.PublicDiskImage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.PublicDiskImage System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PublicDiskImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.PublicDiskImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.PublicDiskImage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PublicDiskImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PublicDiskImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.PublicDiskImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReferenceTelemetryLogColumn : Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ReferenceTelemetryLogColumn>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ReferenceTelemetryLogColumn>
    {
        public ReferenceTelemetryLogColumn(Azure.Containers.Apps.Sandbox.Models.LogColumnRef refName) { }
        public Azure.Containers.Apps.Sandbox.Models.LogColumnRef RefName { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ReferenceTelemetryLogColumn System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ReferenceTelemetryLogColumn>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ReferenceTelemetryLogColumn>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ReferenceTelemetryLogColumn System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ReferenceTelemetryLogColumn>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ReferenceTelemetryLogColumn>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ReferenceTelemetryLogColumn>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegistryAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.RegistryAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.RegistryAuthentication>
    {
        public RegistryAuthentication() { }
        public Azure.Containers.Apps.Sandbox.Models.ManagedIdentityAuthentication Identity { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.RegistryCredentials RegistryCredentials { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.RegistryAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.RegistryAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.RegistryAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.RegistryAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.RegistryAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.RegistryAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.RegistryAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.RegistryAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.RegistryAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegistryCredentials : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.RegistryCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.RegistryCredentials>
    {
        public RegistryCredentials(string username, string token) { }
        public string Token { get { throw null; } }
        public string Username { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.RegistryCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.RegistryCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.RegistryCredentials System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.RegistryCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.RegistryCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.RegistryCredentials System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.RegistryCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.RegistryCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.RegistryCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegistryDiskImageSource : Azure.Containers.Apps.Sandbox.Models.DiskImageSource, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.RegistryDiskImageSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.RegistryDiskImageSource>
    {
        public RegistryDiskImageSource(string imageReference) { }
        public Azure.Containers.Apps.Sandbox.Models.RegistryAuthentication Authentication { get { throw null; } set { } }
        public string ImageReference { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.Models.DiskImageSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.DiskImageSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.RegistryDiskImageSource System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.RegistryDiskImageSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.RegistryDiskImageSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.RegistryDiskImageSource System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.RegistryDiskImageSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.RegistryDiskImageSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.RegistryDiskImageSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemovePortContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.RemovePortContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.RemovePortContent>
    {
        public RemovePortContent() { }
        public string Name { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.RemovePortContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.RemovePortContent removePortContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.RemovePortContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.RemovePortContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.RemovePortContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.RemovePortContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.RemovePortContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.RemovePortContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.RemovePortContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.RemovePortContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceState : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.ResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceState(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.ResourceState Creating { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.ResourceState Error { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.ResourceState Ready { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.ResourceState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.ResourceState left, Azure.Containers.Apps.Sandbox.Models.ResourceState right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.ResourceState (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.ResourceState? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.ResourceState left, Azure.Containers.Apps.Sandbox.Models.ResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SandboxAgentIdentityRef : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxAgentIdentityRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxAgentIdentityRef>
    {
        public SandboxAgentIdentityRef(string tenantId, string agentId) { }
        public string AgentId { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxAgentIdentityRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxAgentIdentityRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxAgentIdentityRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxAgentIdentityRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxAgentIdentityRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxAgentIdentityRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxAgentIdentityRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxAgentIdentityRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxAgentIdentityRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxAutoDeletePolicy : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxAutoDeletePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxAutoDeletePolicy>
    {
        public SandboxAutoDeletePolicy(bool enabled) { }
        public int? DeleteIntervalInDays { get { throw null; } set { } }
        public long? DeleteIntervalInSeconds { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.AutoDeleteTrigger? Trigger { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxAutoDeletePolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxAutoDeletePolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxAutoDeletePolicy System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxAutoDeletePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxAutoDeletePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxAutoDeletePolicy System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxAutoDeletePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxAutoDeletePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxAutoDeletePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxAutoSuspendPolicy : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxAutoSuspendPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxAutoSuspendPolicy>
    {
        public SandboxAutoSuspendPolicy(bool enabled) { }
        public bool Enabled { get { throw null; } set { } }
        public int? IntervalSeconds { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxSuspendMode? Mode { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxAutoSuspendPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxAutoSuspendPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxAutoSuspendPolicy System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxAutoSuspendPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxAutoSuspendPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxAutoSuspendPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxAutoSuspendPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxAutoSuspendPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxAutoSuspendPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxConnection : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxConnection>
    {
        internal SandboxConnection() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public bool? Deletable { get { throw null; } }
        public System.Collections.Generic.IList<string> EnabledToolGroups { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.McpPolicyRule> PolicyRules { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.ResourceState State { get { throw null; } }
        public string Type { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> UsedBySandboxIds { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxConnection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.SandboxConnection (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxConnection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxConnection System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxConnection System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxContentPackageDownload : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxContentPackageDownload>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxContentPackageDownload>
    {
        public SandboxContentPackageDownload(string contentPackageId, string targetPath) { }
        public Azure.Containers.Apps.Sandbox.Models.ContentPackageAction? Action { get { throw null; } set { } }
        public string ContentPackageId { get { throw null; } set { } }
        public string TargetPath { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxContentPackageDownload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxContentPackageDownload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxContentPackageDownload System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxContentPackageDownload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxContentPackageDownload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxContentPackageDownload System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxContentPackageDownload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxContentPackageDownload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxContentPackageDownload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxCountResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxCountResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxCountResult>
    {
        internal SandboxCountResult() { }
        public int Count { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxCountResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.SandboxCountResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxCountResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxCountResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxCountResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxCountResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxCountResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxCountResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxCountResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxCountResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxDirectoryContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryContent>
    {
        public SandboxDirectoryContent(string path) { }
        public bool? CreateParents { get { throw null; } set { } }
        public int? Mode { get { throw null; } set { } }
        public string Path { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryContent sandboxDirectoryContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxDirectoryListingResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryListingResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryListingResult>
    {
        internal SandboxDirectoryListingResult() { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.SandboxFileInfo> Entries { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryListingResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryListingResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryListingResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryListingResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryListingResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryListingResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryListingResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryListingResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryListingResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxDirectoryListingResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxEgressPolicy : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy>
    {
        public SandboxEgressPolicy() { }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyAction? DefaultAction { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyEnforcementMode? EnforcementMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.EgressHostRule> HostRules { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.HttpEgressSection Http { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.EgressPolicyRule> Rules { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.TdsEgressSection Tds { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.TrafficInspection? TrafficInspection { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.TransportEgressSection TransportRules { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.ValidationWarning> ValidationWarnings { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy sandboxEgressPolicy) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxExecuteCommandResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteCommandResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteCommandResult>
    {
        internal SandboxExecuteCommandResult() { }
        public long ExecutionTimeMs { get { throw null; } }
        public int ExitCode { get { throw null; } }
        public string StandardError { get { throw null; } }
        public string StandardOutput { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxExecuteCommandResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.SandboxExecuteCommandResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxExecuteCommandResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxExecuteCommandResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteCommandResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteCommandResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxExecuteCommandResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteCommandResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteCommandResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteCommandResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxExecuteShellCommandResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteShellCommandResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteShellCommandResult>
    {
        internal SandboxExecuteShellCommandResult() { }
        public long ExecutionTimeMs { get { throw null; } }
        public int ExitCode { get { throw null; } }
        public string StandardError { get { throw null; } }
        public string StandardOutput { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxExecuteShellCommandResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.SandboxExecuteShellCommandResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxExecuteShellCommandResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxExecuteShellCommandResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteShellCommandResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteShellCommandResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxExecuteShellCommandResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteShellCommandResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteShellCommandResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxExecuteShellCommandResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxFileInfo : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxFileInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxFileInfo>
    {
        internal SandboxFileInfo() { }
        public bool IsDirectory { get { throw null; } }
        public bool IsSymbolicLink { get { throw null; } }
        public int Mode { get { throw null; } }
        public long ModifiedTime { get { throw null; } }
        public string Name { get { throw null; } }
        public string Path { get { throw null; } }
        public long Size { get { throw null; } }
        public string SymbolicLinkTarget { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxFileInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.SandboxFileInfo (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxFileInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxFileInfo System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxFileInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxFileInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxFileInfo System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxFileInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxFileInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxFileInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxFileOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult>
    {
        internal SandboxFileOperationResult() { }
        public string Error { get { throw null; } }
        public string Message { get { throw null; } }
        public bool Success { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxFileOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxGroupCredential : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential>
    {
        internal SandboxGroupCredential() { }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialOrigin Origin { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialProvider Provider { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSource Source { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.ResourceState State { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxGroupCredentialConnectionRefDetails : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialConnectionRefDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialConnectionRefDetails>
    {
        public SandboxGroupCredentialConnectionRefDetails(Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthRecord authentication, System.Uri tokenExchangeEndpoint) { }
        public Azure.Containers.Apps.Sandbox.Models.GatewayConnectionAuthRecord Authentication { get { throw null; } set { } }
        public System.Uri TokenExchangeEndpoint { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialConnectionRefDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialConnectionRefDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialConnectionRefDetails System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialConnectionRefDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialConnectionRefDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialConnectionRefDetails System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialConnectionRefDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialConnectionRefDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialConnectionRefDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxGroupCredentialOrigin : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialOrigin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxGroupCredentialOrigin(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialOrigin Connections { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialOrigin Credentials { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialOrigin other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialOrigin left, Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialOrigin right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialOrigin (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialOrigin? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialOrigin left, Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialOrigin right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxGroupCredentialProvider : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialProvider>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxGroupCredentialProvider(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialProvider Claude { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialProvider GitHubCopilot { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialProvider other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialProvider left, Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialProvider right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialProvider (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialProvider? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialProvider left, Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialProvider right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SandboxGroupCredentialSource : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSource>
    {
        public SandboxGroupCredentialSource(Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSourceKind kind) { }
        public string ConnectionId { get { throw null; } set { } }
        public string ConnectionName { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialConnectionRefDetails ConnectionRefDetails { get { throw null; } set { } }
        public string ConnectionResourceId { get { throw null; } set { } }
        public string ConnectionType { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSourceKind Kind { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ParameterValues { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSource System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSource System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxGroupCredentialSourceKind : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxGroupCredentialSourceKind(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSourceKind ExistingAdcConnection { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSourceKind GatewayConnectionRef { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSourceKind Pat { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSourceKind SecretRef { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSourceKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSourceKind left, Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSourceKind right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSourceKind (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSourceKind? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSourceKind left, Azure.Containers.Apps.Sandbox.Models.SandboxGroupCredentialSourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class SandboxGroupIdentitySelector : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector>
    {
        internal SandboxGroupIdentitySelector() { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SandboxGroupVolume : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume>
    {
        internal SandboxGroupVolume() { }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.VolumeProvisioningState ProvisioningState { get { throw null; } }
        public string VolumeName { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume sandboxGroupVolume) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxLifecyclePolicy : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy>
    {
        public SandboxLifecyclePolicy(Azure.Containers.Apps.Sandbox.Models.SandboxAutoSuspendPolicy autoSuspendPolicy, Azure.Containers.Apps.Sandbox.Models.SandboxAutoDeletePolicy autoDeletePolicy) { }
        public Azure.Containers.Apps.Sandbox.Models.SandboxAutoDeletePolicy AutoDeletePolicy { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxAutoSuspendPolicy AutoSuspendPolicy { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy sandboxLifecyclePolicy) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxPort : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxPort>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxPort>
    {
        internal SandboxPort() { }
        public Azure.Containers.Apps.Sandbox.Models.PortActivationMode? ActivationMode { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.PortAuthConfig Auth { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.PortCorsConfig Cors { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.IPAccessControl IPAccessControl { get { throw null; } }
        public string Name { get { throw null; } }
        public int Port { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.PortProtocol? Protocol { get { throw null; } }
        public System.Uri Url { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxPort JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxPort PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxPort System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxPort>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxPort>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxPort System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxPort>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxPort>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxPort>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxPortUpdate : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxPortUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxPortUpdate>
    {
        public SandboxPortUpdate(int port, System.Uri url) { }
        public Azure.Containers.Apps.Sandbox.Models.PortActivationMode? ActivationMode { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.PortAuthConfig Auth { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.PortCorsConfig Cors { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.IPAccessControl IPAccessControl { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int Port { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.PortProtocol? Protocol { get { throw null; } set { } }
        public System.Uri Url { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxPortUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxPortUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxPortUpdate System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxPortUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxPortUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxPortUpdate System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxPortUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxPortUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxPortUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxPresetProperties : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxPresetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxPresetProperties>
    {
        public SandboxPresetProperties() { }
        public bool? IsWorkIqConnectionEnabled { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxPresetProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxPresetProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxPresetProperties System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxPresetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxPresetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxPresetProperties System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxPresetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxPresetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxPresetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxProperties : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxProperties>
    {
        internal SandboxProperties() { }
        public Azure.Containers.Apps.Sandbox.Models.SandboxAgentIdentityRef AgentIdentity { get { throw null; } }
        public System.Uri AppUri { get { throw null; } }
        public long? ColdStorageSizeInMb { get { throw null; } }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<string> Connections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.ContainerStatus> ContainerStatuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.SandboxContentPackageDownload> ContentPackageDownloads { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<string> CredentialRefs { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxEgressPolicy EgressPolicy { get { throw null; } }
        public System.Collections.Generic.IList<string> Entrypoint { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.GatewayConnection> GatewayConnections { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.IdentitySetting> IdentitySettings { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxLifecyclePolicy Lifecycle { get { throw null; } }
        public System.Uri ManagementUri { get { throw null; } }
        public System.Collections.Generic.IList<string> OutboundIPAddresses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.SandboxPort> Ports { get { throw null; } }
        public string Region { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxResources Resources { get { throw null; } }
        public Azure.Core.ResourceIdentifier SandboxGroupId { get { throw null; } }
        public string SnapshotId { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxSource SourcesRef { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxState? State { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxStateDetails StateDetails { get { throw null; } }
        public string VnetConnectionName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.SandboxVolume> Volumes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.SandboxProperties (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxProperties System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxProperties System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxResources : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxResources>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxResources>
    {
        public SandboxResources(string cpu, string memory) { }
        public string Cpu { get { throw null; } set { } }
        public string Disk { get { throw null; } set { } }
        public string Memory { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxResources JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxResources PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxResources System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxResources System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSecret : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSecret>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSecret>
    {
        internal SandboxSecret() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxSecret JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.SandboxSecret (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxSecret PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxSecret System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSecret>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSecret>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxSecret System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSecret>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSecret>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSecret>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSnapshot : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot>
    {
        internal SandboxSnapshot() { }
        public System.DateTimeOffset CreatedAtUtc { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.SnapshotResources Resources { get { throw null; } }
        public string SandboxId { get { throw null; } }
        public long? SizeInMb { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Containers.Apps.Sandbox.Models.SnapshotPodContainer> SourcePodContainers { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSnapshot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSource : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSource>
    {
        public SandboxSource() { }
        public Azure.Containers.Apps.Sandbox.Models.SandboxSourceArtifactVersion ArtifactVersion { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxSourceDiskImage DiskImage { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxSourcePod Pod { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.SandboxSourceSnapshot Snapshot { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxSource System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxSource System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSourceArtifactVersion : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceArtifactVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceArtifactVersion>
    {
        public SandboxSourceArtifactVersion(string id, Azure.Containers.Apps.Sandbox.Models.SandboxSourceAuth auth) { }
        public Azure.Containers.Apps.Sandbox.Models.SandboxSourceAuth Auth { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxSourceArtifactVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxSourceArtifactVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxSourceArtifactVersion System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceArtifactVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceArtifactVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxSourceArtifactVersion System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceArtifactVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceArtifactVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceArtifactVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSourceAuth : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceAuth>
    {
        public SandboxSourceAuth(string identity) { }
        public string Identity { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxSourceAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxSourceAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxSourceAuth System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxSourceAuth System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSourceDiskImage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceDiskImage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceDiskImage>
    {
        public SandboxSourceDiskImage() { }
        public string Id { get { throw null; } set { } }
        public bool? IsPublic { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxSourceDiskImage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxSourceDiskImage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxSourceDiskImage System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceDiskImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceDiskImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxSourceDiskImage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceDiskImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceDiskImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceDiskImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSourcePod : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourcePod>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourcePod>
    {
        public SandboxSourcePod(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.ContainerSpec> containers) { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.ContainerSpec> Containers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.PodContentPackage> ContentPackages { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.ContainerRestartPolicy? RestartPolicy { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.PodSecurityContext SecurityContext { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.PodVolume> Volumes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxSourcePod JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxSourcePod PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxSourcePod System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourcePod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourcePod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxSourcePod System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourcePod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourcePod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourcePod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSourceSnapshot : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceSnapshot>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceSnapshot>
    {
        public SandboxSourceSnapshot(string id) { }
        public string Id { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxSourceSnapshot JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxSourceSnapshot PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxSourceSnapshot System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceSnapshot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceSnapshot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxSourceSnapshot System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceSnapshot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceSnapshot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxSourceSnapshot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxState : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.SandboxState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxState(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxState Creating { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxState Idle { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxState Running { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxState StopFailed { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxState Stopped { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxState Stopping { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.SandboxState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.SandboxState left, Azure.Containers.Apps.Sandbox.Models.SandboxState right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.SandboxState (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.SandboxState? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.SandboxState left, Azure.Containers.Apps.Sandbox.Models.SandboxState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SandboxStateDetails : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxStateDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxStateDetails>
    {
        internal SandboxStateDetails() { }
        public System.DateTimeOffset StoppedOn { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.StoppedReason StoppedReason { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxStateDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxStateDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxStateDetails System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxStateDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxStateDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxStateDetails System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxStateDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxStateDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxStateDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxStatsResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxStatsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxStatsResult>
    {
        internal SandboxStatsResult() { }
        public Azure.Containers.Apps.Sandbox.Models.CpuStats Cpu { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.DiskStatsEntry> Disk { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.MemoryStats Memory { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.NetworkStats Network { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.TokenUsageStats TokenUsage { get { throw null; } }
        public double? UptimeSecs { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxStatsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.SandboxStatsResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxStatsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxStatsResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxStatsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxStatsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxStatsResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxStatsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxStatsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxStatsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxSuspendMode : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.SandboxSuspendMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxSuspendMode(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxSuspendMode Disk { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxSuspendMode Memory { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.SandboxSuspendMode None { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.SandboxSuspendMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.SandboxSuspendMode left, Azure.Containers.Apps.Sandbox.Models.SandboxSuspendMode right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.SandboxSuspendMode (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.SandboxSuspendMode? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.SandboxSuspendMode left, Azure.Containers.Apps.Sandbox.Models.SandboxSuspendMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SandboxVolume : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxVolume>
    {
        public SandboxVolume(string volumeName, string mountpoint) { }
        public string Mountpoint { get { throw null; } set { } }
        public bool? ReadOnly { get { throw null; } set { } }
        public string VolumeName { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxVolumeMountContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxVolumeMountContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxVolumeMountContent>
    {
        public SandboxVolumeMountContent(Azure.Containers.Apps.Sandbox.Models.SandboxVolume volumeMount) { }
        public Azure.Containers.Apps.Sandbox.Models.SandboxVolume VolumeMount { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxVolumeMountContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.SandboxVolumeMountContent sandboxVolumeMountContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SandboxVolumeMountContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SandboxVolumeMountContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxVolumeMountContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SandboxVolumeMountContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SandboxVolumeMountContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxVolumeMountContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxVolumeMountContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SandboxVolumeMountContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SeccompProfile : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SeccompProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SeccompProfile>
    {
        public SeccompProfile(Azure.Containers.Apps.Sandbox.Models.SeccompProfileType type) { }
        public Azure.Containers.Apps.Sandbox.Models.SeccompProfileType Type { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SeccompProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SeccompProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SeccompProfile System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SeccompProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SeccompProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SeccompProfile System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SeccompProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SeccompProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SeccompProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SeccompProfileType : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.SeccompProfileType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SeccompProfileType(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.SeccompProfileType RuntimeDefault { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.SeccompProfileType Unconfined { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.SeccompProfileType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.SeccompProfileType left, Azure.Containers.Apps.Sandbox.Models.SeccompProfileType right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.SeccompProfileType (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.SeccompProfileType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.SeccompProfileType left, Azure.Containers.Apps.Sandbox.Models.SeccompProfileType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecretKeysResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SecretKeysResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SecretKeysResult>
    {
        internal SecretKeysResult() { }
        public System.Collections.Generic.IList<string> Keys { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SecretKeysResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.SecretKeysResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SecretKeysResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SecretKeysResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SecretKeysResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SecretKeysResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SecretKeysResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SecretKeysResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SecretKeysResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SecretKeysResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretPeekResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SecretPeekResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SecretPeekResult>
    {
        internal SecretPeekResult() { }
        public System.Collections.Generic.IDictionary<string, string> Values { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SecretPeekResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.SecretPeekResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SecretPeekResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SecretPeekResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SecretPeekResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SecretPeekResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SecretPeekResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SecretPeekResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SecretPeekResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SecretPeekResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceManagedBlobPodVolume : Azure.Containers.Apps.Sandbox.Models.PodVolume, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ServiceManagedBlobPodVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ServiceManagedBlobPodVolume>
    {
        public ServiceManagedBlobPodVolume(string name, string fileCacheSizeLimit) { }
        public string FileCacheSizeLimit { get { throw null; } set { } }
        public bool? ReadOnly { get { throw null; } set { } }
        protected override Azure.Containers.Apps.Sandbox.Models.PodVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.PodVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ServiceManagedBlobPodVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ServiceManagedBlobPodVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ServiceManagedBlobPodVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ServiceManagedBlobPodVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ServiceManagedBlobPodVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ServiceManagedBlobPodVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ServiceManagedBlobPodVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceManagedBlobVolume : Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ServiceManagedBlobVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ServiceManagedBlobVolume>
    {
        public ServiceManagedBlobVolume() { }
        public Azure.Containers.Apps.Sandbox.Models.BlobVolumeUsage Usage { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ServiceManagedBlobVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ServiceManagedBlobVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ServiceManagedBlobVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ServiceManagedBlobVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ServiceManagedBlobVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ServiceManagedBlobVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ServiceManagedBlobVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SetSecretContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SetSecretContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SetSecretContent>
    {
        public SetSecretContent(System.Collections.Generic.IDictionary<string, string> values) { }
        public System.Collections.Generic.IDictionary<string, string> Values { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SetSecretContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.SetSecretContent setSecretContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SetSecretContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SetSecretContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SetSecretContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SetSecretContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SetSecretContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SetSecretContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SetSecretContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SetSecretContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotCountResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SnapshotCountResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SnapshotCountResult>
    {
        internal SnapshotCountResult() { }
        public int Count { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SnapshotCountResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.SnapshotCountResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SnapshotCountResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SnapshotCountResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SnapshotCountResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SnapshotCountResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SnapshotCountResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SnapshotCountResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SnapshotCountResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SnapshotCountResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotPodContainer : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SnapshotPodContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SnapshotPodContainer>
    {
        internal SnapshotPodContainer() { }
        public string DiskImageId { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SnapshotPodContainer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SnapshotPodContainer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SnapshotPodContainer System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SnapshotPodContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SnapshotPodContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SnapshotPodContainer System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SnapshotPodContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SnapshotPodContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SnapshotPodContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotResources : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SnapshotResources>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SnapshotResources>
    {
        internal SnapshotResources() { }
        public string Cpu { get { throw null; } }
        public string Disk { get { throw null; } }
        public string Memory { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SnapshotResources JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.SnapshotResources PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SnapshotResources System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SnapshotResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SnapshotResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SnapshotResources System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SnapshotResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SnapshotResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SnapshotResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StatefulTcpEgress : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.StatefulTcpEgress>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.StatefulTcpEgress>
    {
        internal StatefulTcpEgress() { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.StatefulTcpEntry> Connections { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.StatefulTcpEgress JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.StatefulTcpEgress PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.StatefulTcpEgress System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.StatefulTcpEgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.StatefulTcpEgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.StatefulTcpEgress System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.StatefulTcpEgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.StatefulTcpEgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.StatefulTcpEgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StatefulTcpEntry : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.StatefulTcpEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.StatefulTcpEntry>
    {
        internal StatefulTcpEntry() { }
        public long? BytesIn { get { throw null; } }
        public long? BytesOut { get { throw null; } }
        public string ConnectorType { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string Database { get { throw null; } }
        public long? DurationMs { get { throw null; } }
        public string FailureReason { get { throw null; } }
        public string Outcome { get { throw null; } }
        public string Phase { get { throw null; } }
        public int? Port { get { throw null; } }
        public string ProxyLoginName { get { throw null; } }
        public string Server { get { throw null; } }
        public string SourceIP { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.StatefulTcpEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.StatefulTcpEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.StatefulTcpEntry System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.StatefulTcpEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.StatefulTcpEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.StatefulTcpEntry System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.StatefulTcpEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.StatefulTcpEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.StatefulTcpEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StoppedReason : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.StoppedReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StoppedReason(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.StoppedReason Disabled { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.StoppedReason Idle { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.StoppedReason UserStopped { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.StoppedReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.StoppedReason left, Azure.Containers.Apps.Sandbox.Models.StoppedReason right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.StoppedReason (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.StoppedReason? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.StoppedReason left, Azure.Containers.Apps.Sandbox.Models.StoppedReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SystemAssignedSandboxGroupIdentitySelector : Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SystemAssignedSandboxGroupIdentitySelector>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SystemAssignedSandboxGroupIdentitySelector>
    {
        public SystemAssignedSandboxGroupIdentitySelector() { }
        protected override Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.SystemAssignedSandboxGroupIdentitySelector System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SystemAssignedSandboxGroupIdentitySelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.SystemAssignedSandboxGroupIdentitySelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.SystemAssignedSandboxGroupIdentitySelector System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SystemAssignedSandboxGroupIdentitySelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SystemAssignedSandboxGroupIdentitySelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.SystemAssignedSandboxGroupIdentitySelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TdsAuthKind : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.TdsAuthKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TdsAuthKind(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TdsAuthKind EntraToken { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.TdsAuthKind SqlPassword { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.TdsAuthKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.TdsAuthKind left, Azure.Containers.Apps.Sandbox.Models.TdsAuthKind right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.TdsAuthKind (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.TdsAuthKind? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.TdsAuthKind left, Azure.Containers.Apps.Sandbox.Models.TdsAuthKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TdsCredential : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TdsCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TdsCredential>
    {
        public TdsCredential(string name, Azure.Containers.Apps.Sandbox.Models.TdsAuthKind kind) { }
        public Azure.Containers.Apps.Sandbox.Models.TdsAuthKind Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicySecretRef SecretRef { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TdsCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TdsCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.TdsCredential System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TdsCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TdsCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.TdsCredential System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TdsCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TdsCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TdsCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TdsEgressAction : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressAction>
    {
        public TdsEgressAction(Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType type) { }
        public string Credential { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType Type { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TdsEgressAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TdsEgressAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.TdsEgressAction System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.TdsEgressAction System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TdsEgressMatch : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressMatch>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressMatch>
    {
        public TdsEgressMatch(string host) { }
        public System.Collections.Generic.IList<string> Databases { get { throw null; } }
        public string Host { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TdsEgressMatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TdsEgressMatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.TdsEgressMatch System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressMatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressMatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.TdsEgressMatch System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressMatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressMatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressMatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TdsEgressRule : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressRule>
    {
        public TdsEgressRule(string name, Azure.Containers.Apps.Sandbox.Models.TdsEgressMatch match) { }
        public Azure.Containers.Apps.Sandbox.Models.TdsEgressAction Action { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyHookRef HookRef { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.TdsEgressMatch Match { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TdsEgressRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TdsEgressRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.TdsEgressRule System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.TdsEgressRule System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TdsEgressSection : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressSection>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressSection>
    {
        public TdsEgressSection(Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType defaultAction, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.TdsCredential> credentials, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.TdsEgressRule> rules) { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.TdsCredential> Credentials { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.TdsEgressRule> Rules { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TdsEgressSection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TdsEgressSection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.TdsEgressSection System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressSection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressSection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.TdsEgressSection System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressSection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressSection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TdsEgressSection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryApplicationInsightsAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryApplicationInsightsAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryApplicationInsightsAuthentication>
    {
        public TelemetryApplicationInsightsAuthentication(string secretId, string secretKey) { }
        public string SecretId { get { throw null; } }
        public string SecretKey { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TelemetryApplicationInsightsAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TelemetryApplicationInsightsAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.TelemetryApplicationInsightsAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryApplicationInsightsAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryApplicationInsightsAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.TelemetryApplicationInsightsAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryApplicationInsightsAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryApplicationInsightsAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryApplicationInsightsAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryAppSecretRef : Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryAppSecretRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryAppSecretRef>
    {
        public TelemetryAppSecretRef(string secretRef) { }
        public string SecretRef { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.TelemetryAppSecretRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryAppSecretRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryAppSecretRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.TelemetryAppSecretRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryAppSecretRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryAppSecretRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryAppSecretRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TelemetryAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication>
    {
        internal TelemetryAuthentication() { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryConfiguration>
    {
        public TelemetryConfiguration(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint> endpoints) { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint> Endpoints { get { throw null; } }
        public int? MetricsIntervalSeconds { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TelemetryConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TelemetryConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.TelemetryConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.TelemetryConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelemetryData : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.TelemetryData>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelemetryData(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TelemetryData ContainerOtel { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.TelemetryData ContainerStdoutStderr { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.TelemetryData Metrics { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.TelemetryData NetworkEgressDecisions { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.TelemetryData other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.TelemetryData left, Azure.Containers.Apps.Sandbox.Models.TelemetryData right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.TelemetryData (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.TelemetryData? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.TelemetryData left, Azure.Containers.Apps.Sandbox.Models.TelemetryData right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class TelemetryEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint>
    {
        internal TelemetryEndpoint() { }
        public System.Collections.Generic.IDictionary<string, Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn> Columns { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.TelemetryData> Data { get { throw null; } }
        public bool? DynamicJsonColumns { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryHeaderAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryHeaderAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryHeaderAuthentication>
    {
        public TelemetryHeaderAuthentication(string headerName, string secretId, string secretKey) { }
        public string HeaderName { get { throw null; } }
        public string SecretId { get { throw null; } }
        public string SecretKey { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TelemetryHeaderAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TelemetryHeaderAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.TelemetryHeaderAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryHeaderAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryHeaderAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.TelemetryHeaderAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryHeaderAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryHeaderAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryHeaderAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TelemetryLogColumn : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn>
    {
        internal TelemetryLogColumn() { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryLogColumn>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryManagedIdentityAuthentication : Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryManagedIdentityAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryManagedIdentityAuthentication>
    {
        public TelemetryManagedIdentityAuthentication(string identity) { }
        public string Identity { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.TelemetryManagedIdentityAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryManagedIdentityAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetryManagedIdentityAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.TelemetryManagedIdentityAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryManagedIdentityAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryManagedIdentityAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetryManagedIdentityAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelemetryProtocol : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.TelemetryProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelemetryProtocol(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TelemetryProtocol Grpc { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.TelemetryProtocol Http { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.TelemetryProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.TelemetryProtocol left, Azure.Containers.Apps.Sandbox.Models.TelemetryProtocol right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.TelemetryProtocol (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.TelemetryProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.TelemetryProtocol left, Azure.Containers.Apps.Sandbox.Models.TelemetryProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TelemetrySandboxGroupSecretRef : Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySandboxGroupSecretRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySandboxGroupSecretRef>
    {
        public TelemetrySandboxGroupSecretRef(string secretId, string secretKey) { }
        public string SecretId { get { throw null; } }
        public string SecretKey { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.TelemetrySandboxGroupSecretRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySandboxGroupSecretRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySandboxGroupSecretRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.TelemetrySandboxGroupSecretRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySandboxGroupSecretRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySandboxGroupSecretRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySandboxGroupSecretRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TelemetrySecretReference : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference>
    {
        internal TelemetrySecretReference() { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySecretReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetrySystemAssignedManagedIdentityAuthentication : Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySystemAssignedManagedIdentityAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySystemAssignedManagedIdentityAuthentication>
    {
        public TelemetrySystemAssignedManagedIdentityAuthentication() { }
        protected override Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.TelemetryAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.TelemetrySystemAssignedManagedIdentityAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySystemAssignedManagedIdentityAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySystemAssignedManagedIdentityAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.TelemetrySystemAssignedManagedIdentityAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySystemAssignedManagedIdentityAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySystemAssignedManagedIdentityAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TelemetrySystemAssignedManagedIdentityAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TokenUsageStats : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TokenUsageStats>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TokenUsageStats>
    {
        internal TokenUsageStats() { }
        public int? RequestCount { get { throw null; } }
        public long? TotalInputTokens { get { throw null; } }
        public long? TotalOutputTokens { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TokenUsageStats JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TokenUsageStats PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.TokenUsageStats System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TokenUsageStats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TokenUsageStats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.TokenUsageStats System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TokenUsageStats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TokenUsageStats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TokenUsageStats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficInspection : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.TrafficInspection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficInspection(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TrafficInspection Full { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.TrafficInspection Legacy { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.TrafficInspection None { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.TrafficInspection Partial { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.TrafficInspection other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.TrafficInspection left, Azure.Containers.Apps.Sandbox.Models.TrafficInspection right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.TrafficInspection (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.TrafficInspection? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.TrafficInspection left, Azure.Containers.Apps.Sandbox.Models.TrafficInspection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TransportEgressRule : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TransportEgressRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TransportEgressRule>
    {
        public TransportEgressRule(Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType action, Azure.Containers.Apps.Sandbox.Models.TransportProtocol protocol, string destination, int port) { }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType Action { get { throw null; } set { } }
        public string Destination { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.Models.TransportProtocol Protocol { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TransportEgressRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TransportEgressRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.TransportEgressRule System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TransportEgressRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TransportEgressRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.TransportEgressRule System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TransportEgressRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TransportEgressRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TransportEgressRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TransportEgressSection : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TransportEgressSection>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TransportEgressSection>
    {
        public TransportEgressSection(Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType defaultAction, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.TransportEgressRule> rules) { }
        public Azure.Containers.Apps.Sandbox.Models.EgressPolicyActionType DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.TransportEgressRule> Rules { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TransportEgressSection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.TransportEgressSection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.TransportEgressSection System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TransportEgressSection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.TransportEgressSection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.TransportEgressSection System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TransportEgressSection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TransportEgressSection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.TransportEgressSection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransportProtocol : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.TransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransportProtocol(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.TransportProtocol Tcp { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.TransportProtocol Udp { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.TransportProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.TransportProtocol left, Azure.Containers.Apps.Sandbox.Models.TransportProtocol right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.TransportProtocol (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.TransportProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.TransportProtocol left, Azure.Containers.Apps.Sandbox.Models.TransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdatePolicyRulesContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.UpdatePolicyRulesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.UpdatePolicyRulesContent>
    {
        public UpdatePolicyRulesContent(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.McpPolicyRule> policyRules) { }
        public System.Collections.Generic.IList<string> EnabledToolGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.McpPolicyRule> PolicyRules { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.UpdatePolicyRulesContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.UpdatePolicyRulesContent updatePolicyRulesContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.UpdatePolicyRulesContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.UpdatePolicyRulesContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.UpdatePolicyRulesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.UpdatePolicyRulesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.UpdatePolicyRulesContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.UpdatePolicyRulesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.UpdatePolicyRulesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.UpdatePolicyRulesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdatePortsContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.UpdatePortsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.UpdatePortsContent>
    {
        public UpdatePortsContent(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.Models.SandboxPortUpdate> ports) { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.SandboxPortUpdate> Ports { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.UpdatePortsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.Models.UpdatePortsContent updatePortsContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.UpdatePortsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.UpdatePortsContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.UpdatePortsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.UpdatePortsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.UpdatePortsContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.UpdatePortsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.UpdatePortsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.UpdatePortsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserAssignedSandboxGroupIdentitySelector : Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.UserAssignedSandboxGroupIdentitySelector>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.UserAssignedSandboxGroupIdentitySelector>
    {
        public UserAssignedSandboxGroupIdentitySelector(string resourceId) { }
        public string ResourceId { get { throw null; } set { } }
        protected override Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.SandboxGroupIdentitySelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.UserAssignedSandboxGroupIdentitySelector System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.UserAssignedSandboxGroupIdentitySelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.UserAssignedSandboxGroupIdentitySelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.UserAssignedSandboxGroupIdentitySelector System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.UserAssignedSandboxGroupIdentitySelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.UserAssignedSandboxGroupIdentitySelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.UserAssignedSandboxGroupIdentitySelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserProvidedBlobPodVolume : Azure.Containers.Apps.Sandbox.Models.PodVolume, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.UserProvidedBlobPodVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.UserProvidedBlobPodVolume>
    {
        public UserProvidedBlobPodVolume(string name, string fileCacheSizeLimit) { }
        public string FileCacheSizeLimit { get { throw null; } set { } }
        public bool? ReadOnly { get { throw null; } set { } }
        protected override Azure.Containers.Apps.Sandbox.Models.PodVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.PodVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.UserProvidedBlobPodVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.UserProvidedBlobPodVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.UserProvidedBlobPodVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.UserProvidedBlobPodVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.UserProvidedBlobPodVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.UserProvidedBlobPodVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.UserProvidedBlobPodVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserProvidedBlobVolume : Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.UserProvidedBlobVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.UserProvidedBlobVolume>
    {
        public UserProvidedBlobVolume(string storageContainerResourceId, Azure.Containers.Apps.Sandbox.Models.BlobVolumeAuthentication auth) { }
        public Azure.Containers.Apps.Sandbox.Models.BlobVolumeAuthentication Auth { get { throw null; } set { } }
        public string StorageContainerResourceId { get { throw null; } set { } }
        protected override Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.Models.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.UserProvidedBlobVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.UserProvidedBlobVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.UserProvidedBlobVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.UserProvidedBlobVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.UserProvidedBlobVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.UserProvidedBlobVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.UserProvidedBlobVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationWarning : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ValidationWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ValidationWarning>
    {
        public ValidationWarning(string code, string message) { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ValidationWarning JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.ValidationWarning PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.ValidationWarning System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ValidationWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.ValidationWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.ValidationWarning System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ValidationWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ValidationWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.ValidationWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeCountResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.VolumeCountResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.VolumeCountResult>
    {
        internal VolumeCountResult() { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.VolumeTypeCount> Counts { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.VolumeCountResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.VolumeCountResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.VolumeCountResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.VolumeCountResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.VolumeCountResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.VolumeCountResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.VolumeCountResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.VolumeCountResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.VolumeCountResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.VolumeCountResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeListDirectoryResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.VolumeListDirectoryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.VolumeListDirectoryResult>
    {
        internal VolumeListDirectoryResult() { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.Models.VolumePathItem> Items { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.VolumeListDirectoryResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.VolumeListDirectoryResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.VolumeListDirectoryResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.VolumeListDirectoryResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.VolumeListDirectoryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.VolumeListDirectoryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.VolumeListDirectoryResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.VolumeListDirectoryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.VolumeListDirectoryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.VolumeListDirectoryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumePathItem : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.VolumePathItem>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.VolumePathItem>
    {
        internal VolumePathItem() { }
        public string ContentType { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public bool IsDirectory { get { throw null; } }
        public string ItemName { get { throw null; } }
        public System.DateTimeOffset? LastModifiedUtc { get { throw null; } }
        public string Path { get { throw null; } }
        public long? SizeBytes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.VolumePathItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.VolumePathItem (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.VolumePathItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.VolumePathItem System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.VolumePathItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.VolumePathItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.VolumePathItem System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.VolumePathItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.VolumePathItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.VolumePathItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeProvisioningState : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.VolumeProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeProvisioningState(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.VolumeProvisioningState Provisioning { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.VolumeProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.VolumeProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.VolumeProvisioningState left, Azure.Containers.Apps.Sandbox.Models.VolumeProvisioningState right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.VolumeProvisioningState (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.VolumeProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.VolumeProvisioningState left, Azure.Containers.Apps.Sandbox.Models.VolumeProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeType : System.IEquatable<Azure.Containers.Apps.Sandbox.Models.VolumeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeType(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.Models.VolumeType AzureBlob { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.VolumeType AzureBlobByo { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.Models.VolumeType DataDisk { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.Models.VolumeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.Models.VolumeType left, Azure.Containers.Apps.Sandbox.Models.VolumeType right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.VolumeType (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.Models.VolumeType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.Models.VolumeType left, Azure.Containers.Apps.Sandbox.Models.VolumeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VolumeTypeCount : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.VolumeTypeCount>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.VolumeTypeCount>
    {
        internal VolumeTypeCount() { }
        public int Count { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.Models.VolumeType Type { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.VolumeTypeCount JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.Models.VolumeTypeCount PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.VolumeTypeCount System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.VolumeTypeCount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.VolumeTypeCount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.VolumeTypeCount System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.VolumeTypeCount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.VolumeTypeCount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.VolumeTypeCount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WriteFileResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.WriteFileResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.WriteFileResult>
    {
        internal WriteFileResult() { }
        public long? BytesWritten { get { throw null; } }
        public string Error { get { throw null; } }
        public bool Success { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.Models.WriteFileResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.Models.WriteFileResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.Models.WriteFileResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.Models.WriteFileResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.WriteFileResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.Models.WriteFileResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.Models.WriteFileResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.WriteFileResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.WriteFileResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.Models.WriteFileResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
