using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Security.ConfidentialLedger
{
    /// <summary>
    ///
    /// </summary>
    public class PostLedgerEntryOperation : Operation
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="client"></param>
        /// <param name="transactionId"></param>
        public PostLedgerEntryOperation(ConfidentialLedgerClient client, string transactionId)
        { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="content"></param>
        /// <param name="subLedgerId"></param>
        /// <param name="options"></param>
        public PostLedgerEntryOperation(RequestContent content, string subLedgerId = null, RequestOptions options = null)
        { }

        /// <inheritdoc />
        public override Response GetRawResponse() { throw new NotImplementedException(); }

        /// <inheritdoc />
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Response UpdateStatus(CancellationToken cancellationToken = new CancellationToken()) { throw new NotImplementedException(); }

        /// <inheritdoc />
        public override async ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override async ValueTask<Response> WaitForCompletionResponseAsync(
            TimeSpan pollingInterval,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///
        /// </summary>
        public override string Id { get; }

        /// <inheritdoc />
        public override bool HasCompleted { get; }
    }
}
