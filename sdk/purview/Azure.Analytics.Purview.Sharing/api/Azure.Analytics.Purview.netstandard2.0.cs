namespace Azure.Analytics.Purview
{
    public partial class PurviewShareClientOptions : Azure.Core.ClientOptions
    {
        public PurviewShareClientOptions(Azure.Analytics.Purview.PurviewShareClientOptions.ServiceVersion version = Azure.Analytics.Purview.PurviewShareClientOptions.ServiceVersion.V2023_02_15_Preview) { }
        public enum ServiceVersion
        {
            V2023_02_15_Preview = 1,
        }
    }
    public partial class ReceivedSharesClient
    {
        protected ReceivedSharesClient() { }
        public ReceivedSharesClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public ReceivedSharesClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response ActivateTenantEmailRegistration(Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ActivateTenantEmailRegistrationAsync(Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> CreateOrReplace(Azure.WaitUntil waitUntil, string receivedShareId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateOrReplaceAsync(Azure.WaitUntil waitUntil, string receivedShareId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Delete(Azure.WaitUntil waitUntil, string receivedShareId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteAsync(Azure.WaitUntil waitUntil, string receivedShareId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAttacheds(string referenceName, string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAttachedsAsync(string referenceName, string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDetacheds(string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDetachedsAsync(string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetReceivedShare(string receivedShareId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetReceivedShareAsync(string receivedShareId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RegisterTenantEmailRegistration(string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegisterTenantEmailRegistrationAsync(string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class SentSharesClient
    {
        protected SentSharesClient() { }
        public SentSharesClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public SentSharesClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateInvitation(string sentShareId, string sentShareInvitationId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateInvitationAsync(string sentShareId, string sentShareInvitationId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> CreateOrReplace(Azure.WaitUntil waitUntil, string sentShareId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateOrReplaceAsync(Azure.WaitUntil waitUntil, string sentShareId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Delete(Azure.WaitUntil waitUntil, string sentShareId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteAsync(Azure.WaitUntil waitUntil, string sentShareId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeleteInvitation(Azure.WaitUntil waitUntil, string sentShareId, string sentShareInvitationId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteInvitationAsync(Azure.WaitUntil waitUntil, string sentShareId, string sentShareInvitationId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetInvitation(string sentShareId, string sentShareInvitationId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetInvitationAsync(string sentShareId, string sentShareInvitationId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetInvitations(string sentShareId, string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetInvitationsAsync(string sentShareId, string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSentShare(string sentShareId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSentShareAsync(string sentShareId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSentShares(string referenceName, string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSentSharesAsync(string referenceName, string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response NotifyUserInvitation(string sentShareId, string sentShareInvitationId, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> NotifyUserInvitationAsync(string sentShareId, string sentShareInvitationId, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
    }
}
