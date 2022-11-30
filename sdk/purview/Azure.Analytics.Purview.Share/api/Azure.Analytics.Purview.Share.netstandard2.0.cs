namespace Azure.Analytics.Purview.Share
{
    public partial class AcceptedSentSharesClient
    {
        protected AcceptedSentSharesClient() { }
        public AcceptedSentSharesClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public AcceptedSentSharesClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetAcceptedSentShare(string sentShareName, string acceptedSentShareName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAcceptedSentShareAsync(string sentShareName, string acceptedSentShareName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAcceptedSentShares(string sentShareName, string skipToken = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAcceptedSentSharesAsync(string sentShareName, string skipToken = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Reinstate(Azure.WaitUntil waitUntil, string sentShareName, string acceptedSentShareName, Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ReinstateAsync(Azure.WaitUntil waitUntil, string sentShareName, string acceptedSentShareName, Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Revoke(Azure.WaitUntil waitUntil, string sentShareName, string acceptedSentShareName, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> RevokeAsync(Azure.WaitUntil waitUntil, string sentShareName, string acceptedSentShareName, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> UpdateExpiration(Azure.WaitUntil waitUntil, string sentShareName, string acceptedSentShareName, Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> UpdateExpirationAsync(Azure.WaitUntil waitUntil, string sentShareName, string acceptedSentShareName, Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class AssetMappingsClient
    {
        protected AssetMappingsClient() { }
        public AssetMappingsClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public AssetMappingsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> Create(Azure.WaitUntil waitUntil, string receivedShareName, string assetMappingName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateAsync(Azure.WaitUntil waitUntil, string receivedShareName, string assetMappingName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation Delete(Azure.WaitUntil waitUntil, string receivedShareName, string assetMappingName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteAsync(Azure.WaitUntil waitUntil, string receivedShareName, string assetMappingName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAssetMapping(string receivedShareName, string assetMappingName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAssetMappingAsync(string receivedShareName, string assetMappingName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAssetMappings(string receivedShareName, string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAssetMappingsAsync(string receivedShareName, string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class AssetsClient
    {
        protected AssetsClient() { }
        public AssetsClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public AssetsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> Create(Azure.WaitUntil waitUntil, string sentShareName, string assetName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateAsync(Azure.WaitUntil waitUntil, string sentShareName, string assetName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation Delete(Azure.WaitUntil waitUntil, string sentShareName, string assetName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteAsync(Azure.WaitUntil waitUntil, string sentShareName, string assetName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAsset(string sentShareName, string assetName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAssetAsync(string sentShareName, string assetName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAssets(string sentShareName, string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAssetsAsync(string sentShareName, string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class EmailRegistrationClient
    {
        protected EmailRegistrationClient() { }
        public EmailRegistrationClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public EmailRegistrationClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Activate(Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ActivateAsync(Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Register(string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegisterAsync(string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class PurviewShareClientOptions : Azure.Core.ClientOptions
    {
        public PurviewShareClientOptions(Azure.Analytics.Purview.Share.PurviewShareClientOptions.ServiceVersion version = Azure.Analytics.Purview.Share.PurviewShareClientOptions.ServiceVersion.V2021_09_01_Preview) { }
        public enum ServiceVersion
        {
            V2021_09_01_Preview = 1,
        }
    }
    public partial class ReceivedAssetsClient
    {
        protected ReceivedAssetsClient() { }
        public ReceivedAssetsClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public ReceivedAssetsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Pageable<System.BinaryData> GetReceivedAssets(string receivedShareName, string skipToken = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetReceivedAssetsAsync(string receivedShareName, string skipToken = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ReceivedInvitationsClient
    {
        protected ReceivedInvitationsClient() { }
        public ReceivedInvitationsClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public ReceivedInvitationsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetReceivedInvitation(string receivedInvitationName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetReceivedInvitationAsync(string receivedInvitationName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetReceivedInvitations(string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetReceivedInvitationsAsync(string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Reject(string receivedInvitationName, Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RejectAsync(string receivedInvitationName, Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ReceivedSharesClient
    {
        protected ReceivedSharesClient() { }
        public ReceivedSharesClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public ReceivedSharesClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Create(string receivedShareName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(string receivedShareName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation Delete(Azure.WaitUntil waitUntil, string receivedShareName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteAsync(Azure.WaitUntil waitUntil, string receivedShareName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetReceivedShare(string receivedShareName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetReceivedShareAsync(string receivedShareName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetReceivedShares(string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetReceivedSharesAsync(string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class SentShareInvitationsClient
    {
        protected SentShareInvitationsClient() { }
        public SentShareInvitationsClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public SentShareInvitationsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdate(string sentShareName, string sentShareInvitationName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(string sentShareName, string sentShareInvitationName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(string sentShareName, string sentShareInvitationName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string sentShareName, string sentShareInvitationName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSentShareInvitation(string sentShareName, string sentShareInvitationName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSentShareInvitationAsync(string sentShareName, string sentShareInvitationName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSentShareInvitations(string sentShareName, string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSentShareInvitationsAsync(string sentShareName, string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class SentSharesClient
    {
        protected SentSharesClient() { }
        public SentSharesClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public SentSharesClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdate(string sentShareName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(string sentShareName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation Delete(Azure.WaitUntil waitUntil, string sentShareName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteAsync(Azure.WaitUntil waitUntil, string sentShareName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSentShare(string sentShareName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSentShareAsync(string sentShareName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSentShares(string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSentSharesAsync(string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
    }
}
