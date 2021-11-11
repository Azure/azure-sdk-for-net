// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.ConfidentialLedger
{
    public partial class ConfidentialLedgerClient
    {
        internal ClientDiagnostics clientDiagnostics => _clientDiagnostics;

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

            var actualOptions = options ?? new ConfidentialLedgerClientOptions();
            var transportOptions = GetIdentityServerTlsCertAndTrust(ledgerUri, actualOptions);
            _clientDiagnostics = new ClientDiagnostics(actualOptions);
            _tokenCredential = credential;
            var authPolicy = new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes);
            _pipeline = HttpPipelineBuilder.Build(
                actualOptions,
                new HttpPipelinePolicy[] { new LowLevelCallbackPolicy() },
                new HttpPipelinePolicy[] { authPolicy },
                new ResponseClassifier(),
                transportOptions);
            _ledgerUri = ledgerUri;
            _apiVersion = actualOptions.Version;
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
        /// <param name="context"> The request context. </param>
#pragma warning disable AZC0002
        public virtual PostLedgerEntryOperation PostLedgerEntry(
            RequestContent content,
            string subLedgerId = null,
            bool waitForCompletion = true,
            RequestContext context = null)
#pragma warning restore AZC0002
        {
            var response = PostLedgerEntry(content, subLedgerId, context);
            response.Headers.TryGetValue(ConfidentialLedgerConstants.TransactionIdHeaderName, out string transactionId);

            var operation = new PostLedgerEntryOperation(this, transactionId);
            if (waitForCompletion)
            {
                operation.WaitForCompletionResponse(context?.CancellationToken ?? default);
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
        /// <param name="context"> The request context. </param>
#pragma warning disable AZC0002
        public virtual async Task<PostLedgerEntryOperation> PostLedgerEntryAsync(
            RequestContent content,
            string subLedgerId = null,
            bool waitForCompletion = true,
            RequestContext context = null)
#pragma warning restore AZC0002
        {
            var response = await PostLedgerEntryAsync(content, subLedgerId, context).ConfigureAwait(false);
            response.Headers.TryGetValue(ConfidentialLedgerConstants.TransactionIdHeaderName, out string transactionId);

            var operation = new PostLedgerEntryOperation(this, transactionId);
            if (waitForCompletion)
            {
                await operation.WaitForCompletionResponseAsync(context?.CancellationToken ?? default).ConfigureAwait(false);
            }
            return operation;
        }

        internal static HttpPipelineTransportOptions GetIdentityServerTlsCertAndTrust(Uri ledgerUri, ConfidentialLedgerClientOptions options)
        {
            var identityClient = new ConfidentialLedgerIdentityServiceClient(new Uri("https://identity.accledger.azure.com"), options);

            // Get the ledger's  TLS certificate for our ledger.
            var ledgerId = ledgerUri.Host.Substring(0, ledgerUri.Host.IndexOf('.'));
            Response response = identityClient.GetLedgerIdentity(ledgerId, new());

            // extract the ECC PEM value from the response.
            var eccPem = JsonDocument.Parse(response.Content)
                .RootElement
                .GetProperty("ledgerTlsCertificate")
                .GetString();

            // construct an X509Certificate2 with the ECC PEM value.
            var span = new ReadOnlySpan<char>(eccPem.ToCharArray());
            var ledgerTlsCert = PemReader.LoadCertificate(span, null, PemReader.KeyType.Auto, true);

            X509Chain certificateChain = new();
            certificateChain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            certificateChain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
            certificateChain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
            certificateChain.ChainPolicy.VerificationTime = DateTime.Now;
            certificateChain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 0, 0);
            certificateChain.ChainPolicy.ExtraStore.Add(ledgerTlsCert);

            // Define a validation function to ensure that the ledger certificate is trusted by the ledger identity TLS certificate.
            bool CertValidationCheck(X509Certificate2 cert)
            {
                bool isChainValid = certificateChain.Build(cert);
                if (!isChainValid) return false;

                var isCertSignedByTheTlsCert = certificateChain.ChainElements.Cast<X509ChainElement>()
                    .Any(x => x.Certificate.Thumbprint == ledgerTlsCert.Thumbprint);
                return isCertSignedByTheTlsCert;
            }

            return new HttpPipelineTransportOptions { ServerCertificateCustomValidationCallback = args => CertValidationCheck(args.Certificate) };
        }
    }
}
