// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Messaging.ServiceBus.Authorization
{
    /// <summary>
    ///   Provides a credential based on a shared access signature for a given
    ///   Service Bus entity.
    /// </summary>
    ///
    /// <seealso cref="SharedAccessSignature" />
    /// <seealso cref="Azure.Core.TokenCredential" />
    /// <seealso cref="Azure.AzureNamedKeyCredential" />
    /// <seealso cref="Azure.AzureSasCredential"/>
    ///
    internal class SharedAccessCredential : TokenCredential
    {
        /// <summary>The buffer to apply when considering refreshing; signatures that expire less than this duration will be refreshed.</summary>
        private static readonly TimeSpan SignatureRefreshBuffer = TimeSpan.FromMinutes(10);

        /// <summary>The length of time extend signature validity, if a token was requested.</summary>
        private static readonly TimeSpan SignatureExtensionDuration = TimeSpan.FromMinutes(30);

        /// <summary>The named key credential used to provide the attributes for this security token.</summary>
        private readonly AzureNamedKeyCredential _sourceKeyCredential;

        /// <summary>The SAS credential used to provide the attributes for this security token.</summary>
        private readonly AzureSasCredential _sourceSasCredential;

        /// <summary>The shared access signature that forms the basis of this security token.</summary>
        private SharedAccessSignature _sharedAccessSignature;

        /// <summary>
        ///   Initializes a new instance of the <see cref="SharedAccessCredential" /> class.
        /// </summary>
        ///
        /// <param name="signature">The shared access signature on which to base the token.</param>
        ///
        public SharedAccessCredential(SharedAccessSignature signature)
        {
            Argument.AssertNotNull(signature, nameof(signature));

            _sharedAccessSignature = signature;
            _sourceKeyCredential = null;
            _sourceSasCredential = null;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="SharedAccessCredential" /> class.
        /// </summary>
        ///
        /// <param name="sourceCredential">The <see cref="AzureSasCredential"/> to base signatures on.</param>
        ///
        public SharedAccessCredential(AzureSasCredential sourceCredential)
        {
            Argument.AssertNotNull(sourceCredential, nameof(sourceCredential));

            _sourceSasCredential = sourceCredential;
            _sourceKeyCredential = null;

            _sharedAccessSignature = new SharedAccessSignature(_sourceSasCredential.Signature);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="SharedAccessCredential" /> class.
        /// </summary>
        ///
        /// <param name="sourceCredential">The <see cref="AzureNamedKeyCredential"/> to base signatures on.</param>
        /// <param name="signatureResource">The fully-qualified identifier for the resource to which this credential is intended to serve as authorization for.  This is also known as the "token audience" in some contexts.</param>
        ///
        public SharedAccessCredential(AzureNamedKeyCredential sourceCredential, string signatureResource)
        {
            Argument.AssertNotNull(sourceCredential, nameof(sourceCredential));
            Argument.AssertNotNullOrEmpty(signatureResource, nameof(signatureResource));

            _sourceKeyCredential = sourceCredential;
            _sourceSasCredential = null;

            var (name, key) = sourceCredential;
            _sharedAccessSignature = new SharedAccessSignature(signatureResource, name, key);
        }

        /// <summary>
        ///   Retrieves the token that represents the shared access signature credential, for
        ///   use in authorization against a Service Bus entity.
        /// </summary>
        ///
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">The token used to request cancellation of the operation.</param>
        ///
        /// <returns>The token representing the shared access signature for this credential.</returns>
        ///
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            var signature = Volatile.Read(ref _sharedAccessSignature);

            // If the signature was derived from a precomputed shared access signature,
            // it should not be extended.  Bypass expiration checks and generate the
            // token.

            if (string.IsNullOrEmpty(signature.SharedAccessKey))
            {
                // Before forming the token, regenerate the signature if the source
                // credential has been updated.

                if ((_sourceSasCredential != null) && (!string.Equals(signature.Value, _sourceSasCredential.Signature, StringComparison.Ordinal)))
                {
                    signature = new SharedAccessSignature(_sourceSasCredential.Signature);
                    Volatile.Write(ref _sharedAccessSignature, signature);
                }

                return new AccessToken(signature.Value, signature.SignatureExpiration);
            }

            // If the signature was derived from a shared key that has been updated, regenerate
            // the signature.

            if (_sourceKeyCredential != null)
            {
                var (name, key) = _sourceKeyCredential;

                if ((!string.Equals(signature.SharedAccessKeyName, name, StringComparison.Ordinal))
                    || (!string.Equals(signature.SharedAccessKey, key, StringComparison.Ordinal)))
                {
                    var updatedSignature = new SharedAccessSignature(signature.Resource, name, key);
                    signature = SafeUpdateSharedAccessSignature(signature, updatedSignature);
                }
            }

            // If the key-based signature is approaching expiration, extend it.

            if  (signature.SignatureExpiration <= DateTimeOffset.UtcNow.Add(SignatureRefreshBuffer))
            {
                var updatedSignature = signature.CloneWithNewExpiration(SignatureExtensionDuration);
                signature = SafeUpdateSharedAccessSignature(signature, updatedSignature);
            }

            return new AccessToken(signature.Value, signature.SignatureExpiration);
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
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
            new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));

        /// <summary>
        ///   Attempts to update the current shared access signature reference of the credential while respecting concurrent updates.
        /// </summary>
        ///
        /// <param name="cachedSignature">The cached signature that had been previously read.  If this value is not the current <c>_sharedAccessSignature</c>, the update will not be performed.</param>
        /// <param name="updatedSignature">The signature that was locally updated and intended to replace the <paramref name="cachedSignature"/>.</param>
        ///
        /// <returns>The current value of the <see cref="SharedAccessSignature" /> of the credential, after the attempted update.  This will be the <paramref name="updatedSignature"/> if the update was performed.</returns>
        ///
        /// <remarks>
        ///   The class field "_sharedAccessSignature" may be mutated when calling this method.
        /// </remarks>
        ///
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private SharedAccessSignature SafeUpdateSharedAccessSignature(SharedAccessSignature cachedSignature, SharedAccessSignature updatedSignature)
        {
            var signature = Interlocked.CompareExchange(ref _sharedAccessSignature, updatedSignature, cachedSignature);

            // If the cached signature doesn't match the active one then the signature was not replaced because it had
            // already been updated by another caller; assume that active signature is correct and should be used.

            return ReferenceEquals(signature, cachedSignature)
                ? updatedSignature
                : signature;
        }
    }
}
