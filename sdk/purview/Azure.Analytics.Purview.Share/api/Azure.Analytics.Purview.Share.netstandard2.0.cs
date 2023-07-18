namespace Azure.Analytics.Purview.Share
{
    public partial class AcceptedSentSharesClient
    {
        protected AcceptedSentSharesClient() { }
        public AcceptedSentSharesClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public AcceptedSentSharesClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetAcceptedSentShare(string sentShareName, string acceptedSentShareName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAcceptedSentShareAsync(string sentShareName, string acceptedSentShareName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAcceptedSentShares(string sentShareName, string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAcceptedSentSharesAsync(string sentShareName, string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Reinstate(Azure.WaitUntil waitUntil, string sentShareName, string acceptedSentShareName, Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ReinstateAsync(Azure.WaitUntil waitUntil, string sentShareName, string acceptedSentShareName, Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Revoke(Azure.WaitUntil waitUntil, string sentShareName, string acceptedSentShareName, string repeatabilityRequestId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> RevokeAsync(Azure.WaitUntil waitUntil, string sentShareName, string acceptedSentShareName, string repeatabilityRequestId, Azure.RequestContext context) { throw null; }
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
        public virtual Azure.Response GetAssetMapping(string receivedShareName, string assetMappingName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAssetMappingAsync(string receivedShareName, string assetMappingName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAssetMappings(string receivedShareName, string skipToken, string filter, string orderby, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAssetMappingsAsync(string receivedShareName, string skipToken, string filter, string orderby, Azure.RequestContext context) { throw null; }
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
        public virtual Azure.Response GetAsset(string sentShareName, string assetName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAssetAsync(string sentShareName, string assetName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAssets(string sentShareName, string skipToken, string filter, string orderby, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAssetsAsync(string sentShareName, string skipToken, string filter, string orderby, Azure.RequestContext context) { throw null; }
    }
    public partial class EmailRegistrationClient
    {
        protected EmailRegistrationClient() { }
        public EmailRegistrationClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public EmailRegistrationClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Activate(Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ActivateAsync(Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Register(string repeatabilityRequestId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegisterAsync(string repeatabilityRequestId, Azure.RequestContext context) { throw null; }
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
        public virtual Azure.Pageable<System.BinaryData> GetReceivedAssets(string receivedShareName, string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetReceivedAssetsAsync(string receivedShareName, string skipToken, Azure.RequestContext context) { throw null; }
    }
    public partial class ReceivedInvitationsClient
    {
        protected ReceivedInvitationsClient() { }
        public ReceivedInvitationsClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public ReceivedInvitationsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetReceivedInvitation(string receivedInvitationName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetReceivedInvitationAsync(string receivedInvitationName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetReceivedInvitations(string skipToken, string filter, string orderby, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetReceivedInvitationsAsync(string skipToken, string filter, string orderby, Azure.RequestContext context) { throw null; }
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
        public virtual Azure.Response GetReceivedShare(string receivedShareName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetReceivedShareAsync(string receivedShareName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetReceivedShares(string skipToken, string filter, string orderby, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetReceivedSharesAsync(string skipToken, string filter, string orderby, Azure.RequestContext context) { throw null; }
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
        public virtual Azure.Response GetSentShareInvitation(string sentShareName, string sentShareInvitationName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSentShareInvitationAsync(string sentShareName, string sentShareInvitationName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSentShareInvitations(string sentShareName, string skipToken, string filter, string orderby, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSentShareInvitationsAsync(string sentShareName, string skipToken, string filter, string orderby, Azure.RequestContext context) { throw null; }
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
        public virtual Azure.Response GetSentShare(string sentShareName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSentShareAsync(string sentShareName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSentShares(string skipToken, string filter, string orderby, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSentSharesAsync(string skipToken, string filter, string orderby, Azure.RequestContext context) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AnalyticsPurviewShareClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Share.AcceptedSentSharesClient, Azure.Analytics.Purview.Share.PurviewShareClientOptions> AddAcceptedSentSharesClient<TBuilder>(this TBuilder builder, string endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Share.AcceptedSentSharesClient, Azure.Analytics.Purview.Share.PurviewShareClientOptions> AddAcceptedSentSharesClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Share.AssetMappingsClient, Azure.Analytics.Purview.Share.PurviewShareClientOptions> AddAssetMappingsClient<TBuilder>(this TBuilder builder, string endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Share.AssetMappingsClient, Azure.Analytics.Purview.Share.PurviewShareClientOptions> AddAssetMappingsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Share.AssetsClient, Azure.Analytics.Purview.Share.PurviewShareClientOptions> AddAssetsClient<TBuilder>(this TBuilder builder, string endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Share.AssetsClient, Azure.Analytics.Purview.Share.PurviewShareClientOptions> AddAssetsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Share.EmailRegistrationClient, Azure.Analytics.Purview.Share.PurviewShareClientOptions> AddEmailRegistrationClient<TBuilder>(this TBuilder builder, string endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Share.EmailRegistrationClient, Azure.Analytics.Purview.Share.PurviewShareClientOptions> AddEmailRegistrationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Share.ReceivedAssetsClient, Azure.Analytics.Purview.Share.PurviewShareClientOptions> AddReceivedAssetsClient<TBuilder>(this TBuilder builder, string endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Share.ReceivedAssetsClient, Azure.Analytics.Purview.Share.PurviewShareClientOptions> AddReceivedAssetsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Share.ReceivedInvitationsClient, Azure.Analytics.Purview.Share.PurviewShareClientOptions> AddReceivedInvitationsClient<TBuilder>(this TBuilder builder, string endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Share.ReceivedInvitationsClient, Azure.Analytics.Purview.Share.PurviewShareClientOptions> AddReceivedInvitationsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Share.ReceivedSharesClient, Azure.Analytics.Purview.Share.PurviewShareClientOptions> AddReceivedSharesClient<TBuilder>(this TBuilder builder, string endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Share.ReceivedSharesClient, Azure.Analytics.Purview.Share.PurviewShareClientOptions> AddReceivedSharesClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Share.SentShareInvitationsClient, Azure.Analytics.Purview.Share.PurviewShareClientOptions> AddSentShareInvitationsClient<TBuilder>(this TBuilder builder, string endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Share.SentShareInvitationsClient, Azure.Analytics.Purview.Share.PurviewShareClientOptions> AddSentShareInvitationsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Share.SentSharesClient, Azure.Analytics.Purview.Share.PurviewShareClientOptions> AddSentSharesClient<TBuilder>(this TBuilder builder, string endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Share.SentSharesClient, Azure.Analytics.Purview.Share.PurviewShareClientOptions> AddSentSharesClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
