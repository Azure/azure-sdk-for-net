// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Messaging.EventHubs.Authorization
{
    /// <summary>
    ///   Provides a credential based on a shared access signature for a given
    ///   Event Hub instance.
    /// </summary>
    ///
    /// <seealso cref="Azure.Core.TokenCredential" />
    ///
    public sealed class EventHubSharedKeyCredential : TokenCredential
    {
        /// <summary>
        ///   The name of the shared access key to be used for authorization, as
        ///   reported by the Azure portal.
        /// </summary>
        ///
        public string SharedAccessKeyName { get; }

        /// <summary>
        ///   The value of the shared access key to be used for authorization, as
        ///   reported by the Azure portal.
        /// </summary>
        ///
        private string SharedAccessKey { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubSharedKeyCredential"/> class.
        /// </summary>
        ///
        /// <param name="sharedAccessKeyName">The name of the shared access key to be used for authorization, as reported by the Azure portal.</param>
        /// <param name="sharedAccessKey">The value of the shared access key to be used for authorization, as reported by the Azure portal.</param>
        ///
        public EventHubSharedKeyCredential(string sharedAccessKeyName,
                                           string sharedAccessKey)
        {
            Argument.AssertNotNullOrEmpty(sharedAccessKeyName, nameof(sharedAccessKeyName));
            Argument.AssertNotNullOrEmpty(sharedAccessKey, nameof(sharedAccessKey));

            SharedAccessKeyName = sharedAccessKeyName;
            SharedAccessKey = sharedAccessKey;
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
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) => throw new InvalidOperationException(Resources.SharedKeyCredentialCannotGenerateTokens);

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
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) => throw new InvalidOperationException(Resources.SharedKeyCredentialCannotGenerateTokens);

        /// <summary>
        /// Coverts to shared access signature credential.
        /// </summary>
        ///
        /// <param name="eventHubResource">The Event Hubs resource to which the token is intended to serve as authorization.</param>
        /// <param name="signatureValidityDuration">The duration that the signature should be considered valid; if not specified, a default will be assumed.</param>
        ///
        /// <returns>A <see cref="SharedAccessSignatureCredential" /> based on the requested shared access key.</returns>
        ///
        internal SharedAccessSignatureCredential ConvertToSharedAccessSignatureCredential(string eventHubResource,
                                                                                          TimeSpan? signatureValidityDuration = default) =>
            new SharedAccessSignatureCredential(new SharedAccessSignature(eventHubResource, SharedAccessKeyName, SharedAccessKey, signatureValidityDuration));

    }
}
