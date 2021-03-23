// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Messaging.EventHubs.Authorization
{
    /// <summary>
    ///   Provides a generic token-based credential for a given Event Hub instance.
    /// </summary>
    ///
    /// <seealso cref="Azure.Core.TokenCredential" />
    ///
    internal class EventHubTokenCredential : TokenCredential
    {
        /// <summary>The default scope used for token authentication with EventHubs.</summary>
        private const string DefaultScope = "https://eventhubs.azure.net/.default";

        /// <summary>
        ///   The Event Hubs resource to which the token is intended to serve as authorization.
        /// </summary>
        ///
        public string Resource { get; }

        /// <summary>
        ///   Indicates whether the credential is based on an Event Hubs
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
        ///   Initializes a new instance of the <see cref="EventHubTokenCredential" /> class.
        /// </summary>
        ///
        /// <param name="tokenCredential">The <see cref="TokenCredential" /> on which to base the token.</param>
        /// <param name="eventHubResource">The Event Hubs resource to which the token is intended to serve as authorization.</param>
        ///
        public EventHubTokenCredential(TokenCredential tokenCredential,
                                       string eventHubResource)
        {
            Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));
            Argument.AssertNotNullOrEmpty(eventHubResource, nameof(eventHubResource));

            Credential = tokenCredential;
            Resource = eventHubResource;

            IsSharedAccessSignatureCredential =
                (tokenCredential is SharedAccessSignatureCredential)
                || ((tokenCredential as EventHubTokenCredential)?.IsSharedAccessSignatureCredential == true);
        }

        /// <summary>
        ///   Retrieves the token that represents the shared access signature credential, for
        ///   use in authorization against an Event Hub.
        /// </summary>
        ///
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">The token used to request cancellation of the operation.</param>
        ///
        /// <returns>The token representing the shared access signature for this credential.</returns>
        ///
        public override AccessToken GetToken(TokenRequestContext requestContext,
                                             CancellationToken cancellationToken) => Credential.GetToken(requestContext, cancellationToken);

        /// <summary>
        ///   Retrieves the token that represents the shared access signature credential, for
        ///   use in authorization against an Event Hub.
        /// </summary>
        ///
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">The token used to request cancellation of the operation.</param>
        ///
        /// <returns>The token representing the shared access signature for this credential.</returns>
        ///
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext,
                                                             CancellationToken cancellationToken) => Credential.GetTokenAsync(requestContext, cancellationToken);

        /// <summary>
        ///   Retrieves the token that represents the shared access signature credential, for
        ///   use in authorization against an Event Hub. It provides a default value for the Token Request Context.
        /// </summary>
        ///
        /// <param name="cancellationToken">The token used to request cancellation of the operation.</param>
        ///
        /// <returns>The token representing the shared access signature for this credential.</returns>
        ///
        public ValueTask<AccessToken> GetTokenUsingDefaultScopeAsync(CancellationToken cancellationToken) => GetTokenAsync(new TokenRequestContext(new string[] { DefaultScope }), cancellationToken);
    }
}
