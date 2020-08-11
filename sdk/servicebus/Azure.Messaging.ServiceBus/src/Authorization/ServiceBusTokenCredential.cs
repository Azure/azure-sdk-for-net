// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus;

namespace Azure.Messaging.ServiceBus.Authorization
{
    /// <summary>
    ///   Provides a generic token-based credential for a given Service Bus entity instance.
    /// </summary>
    ///
    /// <seealso cref="Azure.Core.TokenCredential" />
    ///
    internal class ServiceBusTokenCredential : TokenCredential
    {
        /// <summary>
        ///   The Service Bus resource to which the token is intended to serve as authorization.
        /// </summary>
        ///
        public string Resource { get; }

        /// <summary>
        ///   Indicates whether the credential is based on an Service Bus
        ///   shared access signature.
        /// </summary>
        ///
        /// <value><c>true</c> if the credential should be considered a SAS credential; otherwise, <c>false</c>.</value>
        ///
        public bool IsSharedAccessSignatureCredential { get; }

        /// <summary>
        ///   The <see cref="TokenCredential" /> that forms the basis of this security token.
        /// </summary>
        ///
        private TokenCredential Credential { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusTokenCredential"/> class.
        /// </summary>
        ///
        /// <param name="tokenCredential">The <see cref="TokenCredential" /> on which to base the token.</param>
        /// <param name="serviceBusResource">The Service Bus resource to which the token is intended to serve as authorization.</param>
        ///
        public ServiceBusTokenCredential(
            TokenCredential tokenCredential,
            string serviceBusResource)
        {
            Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));
            Argument.AssertNotNullOrEmpty(serviceBusResource, nameof(serviceBusResource));

            Credential = tokenCredential;
            Resource = serviceBusResource;

            IsSharedAccessSignatureCredential =
                (tokenCredential is ServiceBusSharedKeyCredential)
                || (tokenCredential is SharedAccessSignatureCredential)
                || ((tokenCredential as ServiceBusTokenCredential)?.IsSharedAccessSignatureCredential == true);
        }

        /// <summary>
        ///   Retrieves the token that represents the shared access signature credential, for
        ///   use in authorization against an Service Bus entity.
        /// </summary>
        ///
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">The token used to request cancellation of the operation.</param>
        ///
        /// <returns>The token representing the shared access signature for this credential.</returns>
        ///
        public override AccessToken GetToken(
            TokenRequestContext requestContext,
            CancellationToken cancellationToken) =>
            Credential.GetToken(requestContext, cancellationToken);

        /// <summary>
        ///   Retrieves the token that represents the shared access signature credential, for
        ///   use in authorization against an Service Bus entity.
        /// </summary>
        ///
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">The token used to request cancellation of the operation.</param>
        ///
        /// <returns>The token representing the shared access signature for this credential.</returns>
        ///
        public override ValueTask<AccessToken> GetTokenAsync(
            TokenRequestContext requestContext,
            CancellationToken cancellationToken) =>
            Credential.GetTokenAsync(requestContext, cancellationToken);

        /// <summary>
        ///   Retrieves the token that represents the shared access signature credential, for
        ///   use in authorization against an Service Bus entity. It provides a default value for the Token Request Context.
        /// </summary>
        ///
        /// <param name="cancellationToken">The token used to request cancellation of the operation.</param>
        ///
        /// <returns>The token representing the shared access signature for this credential.</returns>
        ///
        public ValueTask<AccessToken> GetTokenUsingDefaultScopeAsync(CancellationToken cancellationToken) =>
            GetTokenAsync(new TokenRequestContext(new string[] { Constants.DefaultScope }), cancellationToken);
    }
}
