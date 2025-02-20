namespace Azure.Analytics.Purview.Sharing
{
    public partial class PurviewShareClientOptions : Azure.Core.ClientOptions
    {
        public PurviewShareClientOptions(Azure.Analytics.Purview.Sharing.PurviewShareClientOptions.ServiceVersion version = Azure.Analytics.Purview.Sharing.PurviewShareClientOptions.ServiceVersion.V2023_05_30_Preview) { }
        public enum ServiceVersion
        {
            V2023_05_30_Preview = 1,
        }
    }
    public partial class ReceivedSharesClient
    {
        protected ReceivedSharesClient() { }
        public ReceivedSharesClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ReceivedSharesClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Sharing.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response ActivateTenantEmailRegistration(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ActivateTenantEmailRegistrationAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> CreateOrReplaceReceivedShare(Azure.WaitUntil waitUntil, string receivedShareId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateOrReplaceReceivedShareAsync(Azure.WaitUntil waitUntil, string receivedShareId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeleteReceivedShare(Azure.WaitUntil waitUntil, string receivedShareId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteReceivedShareAsync(Azure.WaitUntil waitUntil, string receivedShareId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAllAttachedReceivedShares(string referenceName, string filter, string orderby, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllAttachedReceivedSharesAsync(string referenceName, string filter, string orderby, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAllDetachedReceivedShares(string filter, string orderby, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllDetachedReceivedSharesAsync(string filter, string orderby, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetReceivedShare(string receivedShareId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetReceivedShareAsync(string receivedShareId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response RegisterTenantEmailRegistration(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegisterTenantEmailRegistrationAsync(Azure.RequestContext context) { throw null; }
    }
    public partial class SentSharesClient
    {
        protected SentSharesClient() { }
        public SentSharesClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public SentSharesClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Sharing.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> CreateOrReplaceSentShare(Azure.WaitUntil waitUntil, string sentShareId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateOrReplaceSentShareAsync(Azure.WaitUntil waitUntil, string sentShareId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateSentShareInvitation(string sentShareId, string sentShareInvitationId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateSentShareInvitationAsync(string sentShareId, string sentShareInvitationId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeleteSentShare(Azure.WaitUntil waitUntil, string sentShareId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteSentShareAsync(Azure.WaitUntil waitUntil, string sentShareId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeleteSentShareInvitation(Azure.WaitUntil waitUntil, string sentShareId, string sentShareInvitationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteSentShareInvitationAsync(Azure.WaitUntil waitUntil, string sentShareId, string sentShareInvitationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAllSentShareInvitations(string sentShareId, string filter, string orderby, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllSentShareInvitationsAsync(string sentShareId, string filter, string orderby, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAllSentShares(string referenceName, string filter, string orderby, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllSentSharesAsync(string referenceName, string filter, string orderby, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetSentShare(string sentShareId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSentShareAsync(string sentShareId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetSentShareInvitation(string sentShareId, string sentShareInvitationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSentShareInvitationAsync(string sentShareId, string sentShareInvitationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response NotifyUserSentShareInvitation(string sentShareId, string sentShareInvitationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> NotifyUserSentShareInvitationAsync(string sentShareId, string sentShareInvitationId, Azure.RequestContext context) { throw null; }
    }
    public partial class ShareResourcesClient
    {
        protected ShareResourcesClient() { }
        public ShareResourcesClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ShareResourcesClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Sharing.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Pageable<System.BinaryData> GetAllShareResources(string filter, string orderby, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllShareResourcesAsync(string filter, string orderby, Azure.RequestContext context) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AnalyticsPurviewSharingClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Sharing.ReceivedSharesClient, Azure.Analytics.Purview.Sharing.PurviewShareClientOptions> AddReceivedSharesClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Sharing.ReceivedSharesClient, Azure.Analytics.Purview.Sharing.PurviewShareClientOptions> AddReceivedSharesClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Sharing.SentSharesClient, Azure.Analytics.Purview.Sharing.PurviewShareClientOptions> AddSentSharesClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Sharing.SentSharesClient, Azure.Analytics.Purview.Sharing.PurviewShareClientOptions> AddSentSharesClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Sharing.ShareResourcesClient, Azure.Analytics.Purview.Sharing.PurviewShareClientOptions> AddShareResourcesClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Sharing.ShareResourcesClient, Azure.Analytics.Purview.Sharing.PurviewShareClientOptions> AddShareResourcesClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
