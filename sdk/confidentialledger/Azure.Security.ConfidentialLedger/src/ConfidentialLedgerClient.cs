// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.ConfidentialLedger
{
    public partial class ConfidentialLedgerClient
    {
        internal TimeSpan DefaultPollingInterval { get; }
        internal readonly ClientDiagnostics clientDiagnostics;

        /// <summary> Initializes a new instance of ConfidentialLedgerClient. </summary>
        /// <param name="ledgerUri"> The Confidential Ledger URL, for example https://contoso.confidentialledger.azure.com. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public ConfidentialLedgerClient(Uri ledgerUri, TokenCredential credential, ConfidentialLedgerClientOptions options = null)
        {
            if (ledgerUri == null)
            {
                throw new ArgumentNullException(nameof(ledgerUri));
            }
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            options ??= new ConfidentialLedgerClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            clientDiagnostics = _clientDiagnostics;
            _tokenCredential = credential;
            var authPolicy = new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes);
            _pipeline = HttpPipelineBuilder.Build(
                options,
                new HttpPipelinePolicy[] { new LowLevelCallbackPolicy() },
                new HttpPipelinePolicy[] { authPolicy },
                new ResponseClassifier());
            _ledgerUri = ledgerUri;
            _apiVersion = options.Version;
            DefaultPollingInterval = options.OperationPollingInterval;
        }

        /// <summary> Posts a new entry to the ledger. A sub-ledger id may optionally be specified. </summary>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <list type="table">
        ///   <listheader>
        ///     <term>Name</term>
        ///     <term>Type</term>
        ///     <term>Required</term>
        ///     <term>Description</term>
        ///   </listheader>
        ///   <item>
        ///     <term>contents</term>
        ///     <term>string</term>
        ///     <term>Yes</term>
        ///     <term> Contents of the ledger entry. </term>
        ///   </item>
        ///   <item>
        ///     <term>subLedgerId</term>
        ///     <term>string</term>
        ///     <term></term>
        ///     <term> Identifier for sub-ledgers. </term>
        ///   </item>
        ///   <item>
        ///     <term>transactionId</term>
        ///     <term>string</term>
        ///     <term></term>
        ///     <term> A unique identifier for the state of the ledger. If returned as part of a LedgerEntry, it indicates the state from which the entry was read. </term>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="subLedgerId"> The sub-ledger id. </param>
        /// <param name="waitForCompletion"> If <c>true</c>, the <see cref="PostLedgerEntryOperation"/> will not be returned until the ledger entry is committed.
        /// If <c>false</c>,<see cref="Operation.WaitForCompletionResponse(System.Threading.CancellationToken)"/> must be called to ensure the operation has completed.</param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual PostLedgerEntryOperation PostLedgerEntry(
            RequestContent content,
            string subLedgerId = null,
            bool waitForCompletion = true,
            RequestOptions options = null)
#pragma warning restore AZC0002
        {
            var response = PostLedgerEntry(content, subLedgerId, options);
            response.Headers.TryGetValue(ConfidentialLedgerConstants.TransactionIdHeaderName, out string transactionId);

            var operation = new PostLedgerEntryOperation(this, transactionId);
            if (waitForCompletion)
            {
                operation.DefaultWaitForCompletionResponse(DefaultPollingInterval, options?.CancellationToken ?? default);
            }
            return operation;
        }

        /// <summary> Posts a new entry to the ledger. A sub-ledger id may optionally be specified. </summary>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <list type="table">
        ///   <listheader>
        ///     <term>Name</term>
        ///     <term>Type</term>
        ///     <term>Required</term>
        ///     <term>Description</term>
        ///   </listheader>
        ///   <item>
        ///     <term>contents</term>
        ///     <term>string</term>
        ///     <term>Yes</term>
        ///     <term> Contents of the ledger entry. </term>
        ///   </item>
        ///   <item>
        ///     <term>subLedgerId</term>
        ///     <term>string</term>
        ///     <term></term>
        ///     <term> Identifier for sub-ledgers. </term>
        ///   </item>
        ///   <item>
        ///     <term>transactionId</term>
        ///     <term>string</term>
        ///     <term></term>
        ///     <term> A unique identifier for the state of the ledger. If returned as part of a LedgerEntry, it indicates the state from which the entry was read. </term>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="subLedgerId"> The sub-ledger id. </param>
        /// <param name="waitForCompletion"> If <c>true</c>, the <see cref="PostLedgerEntryOperation"/>
        /// will automatically poll for status until the ledger entry is committed before it is returned.
        /// If <c>false</c>,<see cref="Operation.WaitForCompletionResponseAsync(System.Threading.CancellationToken)"/>
        /// must be called to ensure the operation has completed.</param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual async Task<PostLedgerEntryOperation> PostLedgerEntryAsync(
            RequestContent content,
            string subLedgerId = null,
            bool waitForCompletion = true,
            RequestOptions options = null)
#pragma warning restore AZC0002
        {
            var response = await PostLedgerEntryAsync(content, subLedgerId, options).ConfigureAwait(false);
            response.Headers.TryGetValue(ConfidentialLedgerConstants.TransactionIdHeaderName, out string transactionId);

            var operation = new PostLedgerEntryOperation(this, transactionId);
            if (waitForCompletion)
            {
                await operation.WaitForCompletionResponseAsync(DefaultPollingInterval, options?.CancellationToken ?? default).ConfigureAwait(false);
            }
            return operation;
        }

#pragma warning disable AZC0002
        internal virtual async Task<Response> PostLedgerEntryAsync(RequestContent content, string subLedgerId = null, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            HttpMessage message = CreatePostLedgerEntryRequest(content, subLedgerId);
            if (options.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", options.PerCallPolicy);
            }
            using var scope = _clientDiagnostics.CreateScope("ConfidentialLedgerClient.PostLedgerEntry");
            scope.Start();
            try
            {
                await Pipeline.SendAsync(message, options.CancellationToken).ConfigureAwait(false);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 200:
                            return message.Response;
                        default:
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

#pragma warning disable AZC0002
        internal virtual Response PostLedgerEntry(RequestContent content, string subLedgerId = null, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            HttpMessage message = CreatePostLedgerEntryRequest(content, subLedgerId);
            if (options.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", options.PerCallPolicy);
            }
            using var scope = _clientDiagnostics.CreateScope("ConfidentialLedgerClient.PostLedgerEntry");
            scope.Start();
            try
            {
                Pipeline.Send(message, options.CancellationToken);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 200:
                            return message.Response;
                        default:
                            throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
