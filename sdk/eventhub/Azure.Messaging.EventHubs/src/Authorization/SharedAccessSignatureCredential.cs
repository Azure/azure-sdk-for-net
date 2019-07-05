// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Authorization
{
    /// <summary>
    ///   Provides a credential based on a shared access signature for a given
    ///   Event Hub instance.
    /// </summary>
    ///
    /// <seealso cref="SharedAccessSignature" />
    /// <seealso cref="Azure.Core.TokenCredential" />
    ///
    internal class SharedAccessSignatureCredential : TokenCredential
    {
        /// <summary>
        ///   The shared access signature that forms the basis of this security token.
        /// </summary>
        ///
        public SharedAccessSignature SharedAccessSignature { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="SharedAccessSignatureCredential"/> class.
        /// </summary>
        ///
        /// <param name="signature">The shared access signature on which to base the token.</param>
        ///
        public SharedAccessSignatureCredential(SharedAccessSignature signature)
        {
            Guard.ArgumentNotNull(nameof(signature), signature);
            SharedAccessSignature = signature;
        }

        /// <summary>
        ///   Retrieves the token that represents the shared access signature credential, for
        ///   use in authorization against an Event Hub.
        /// </summary>
        ///
        /// <param name="scopes">The access scopes to request a token for.</param>
        /// <param name="cancellationToken">The token used to request cancellation of the operation.</param>
        ///
        /// <returns>The token representating the shared access signature for this credential.</returns>
        ///
        public override AccessToken GetToken(string[] scopes, CancellationToken cancellationToken) => new AccessToken(SharedAccessSignature.Value, SharedAccessSignature.ExpirationTime);

        /// <summary>
        ///   Retrieves the token that represents the shared access signature credential, for
        ///   use in authorization against an Event Hub.
        /// </summary>
        ///
        /// <param name="scopes">The access scopes to request a token for.</param>
        /// <param name="cancellationToken">The token used to request cancellation of the operation.</param>
        ///
        /// <returns>The token representating the shared access signature for this credential.</returns>
        ///
        public override Task<AccessToken> GetTokenAsync(string[] scopes, CancellationToken cancellationToken) => Task.FromResult(new AccessToken(SharedAccessSignature.Value, SharedAccessSignature.ExpirationTime));
    }
}
