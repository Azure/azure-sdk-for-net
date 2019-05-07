// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Authorization
{
    /// <summary>
    ///   A shared access signature token that can be used to authorize the bearer
    ///   against a given Event Hubs namespace and Event Hub path.
    /// </summary>
    ///
    public sealed class SharedAccessSignatureCredential : TokenCredential

    {
        /// <summary>The shared access signature key.</summary>
        private readonly string _sharedAccessSignatureKey;

        /// <summary>The shared access signature key as a construct meant to be returned for asynchronous token retrieval.</summary>
        private readonly ValueTask<string> _sharedAccessSignatureKeyAsyncResult;

        /// <summary>
        ///   Initializes a new instance of the <see cref="SharedAccessSignatureCredential"/> class.
        /// </summary>
        ///
        /// <param name="sharedAccessSignatureKey">The shared access signature (SAS) key to use for authorization with an Event Hub.</param>
        ///
        public SharedAccessSignatureCredential(string sharedAccessSignatureKey)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(sharedAccessSignatureKey), sharedAccessSignatureKey);

            _sharedAccessSignatureKey = sharedAccessSignatureKey;
            _sharedAccessSignatureKeyAsyncResult = new ValueTask<string>(_sharedAccessSignatureKey);
        }

        /// <summary>
        ///   Retrieves the shared access signature token for this credential.
        /// </summary>
        ///
        /// <param name="scopes">The scopes for which the token should be valid; this parameter is not relevant to SAS credentisl and is ignored.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        /// <returns>The token corresponding to the shared access signature.</returns>
        ///
        public override string GetToken(string[]          scopes,
                                        CancellationToken cancellationToken = default) => _sharedAccessSignatureKey;

        /// <summary>
        ///   Retrieves the shared access signature token for this credential.
        /// </summary>
        ///
        /// <param name="scopes">The scopes for which the token should be valid; this parameter is not relevant to SAS credentisl and is ignored.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        /// <returns>The token corresponding to the shared access signature.</returns>
        ///
        public override ValueTask<string> GetTokenAsync(string[]          scopes,
                                                        CancellationToken cancellationToken = default) => _sharedAccessSignatureKeyAsyncResult;
    }

    //TODO: Try to replace this with a better implementation from Core or reframe to Internal for interop with the connection string.
}
