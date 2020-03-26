// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Authorization;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///   Provides a credential based on a shared access signature for a given
    ///   Service Bus entity.
    /// </summary>
    ///
    /// <seealso cref="Azure.Core.TokenCredential" />
    ///
    internal sealed class ServiceBusSharedKeyCredential : TokenCredential
    {
        /// <summary>
        ///   The name of the shared access key to be used for authorization, as
        ///   reported by the Azure portal.
        /// </summary>
        ///
        private string SharedAccessKeyName { get; set; }

        /// <summary>
        ///   The value of the shared access key to be used for authorization, as
        ///   reported by the Azure portal.
        /// </summary>
        ///
        private string SharedAccessKey { get; set; }

        /// <summary>
        ///   A reference to a corresponding SharedAccessSignatureCredential.
        /// </summary>
        ///
        private SharedAccessSignatureCredential SharedAccessSignatureCredential { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSharedKeyCredential"/> class.
        /// </summary>
        ///
        /// <param name="sharedAccessKeyName">The name of the shared access key to be used for authorization, as reported by the Azure portal.</param>
        /// <param name="sharedAccessKey">The value of the shared access key to be used for authorization, as reported by the Azure portal.</param>
        ///
        public ServiceBusSharedKeyCredential(
            string sharedAccessKeyName,
            string sharedAccessKey)
        {
            Argument.AssertNotNullOrEmpty(sharedAccessKeyName, nameof(sharedAccessKeyName));
            Argument.AssertNotNullOrEmpty(sharedAccessKey, nameof(sharedAccessKey));

            SharedAccessKeyName = sharedAccessKeyName;
            SharedAccessKey = sharedAccessKey;
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
            throw new InvalidOperationException(Resources1.SharedKeyCredentialCannotGenerateTokens);

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
            throw new InvalidOperationException(Resources1.SharedKeyCredentialCannotGenerateTokens);

        /// <summary>
        ///   Allows the rotation of Shared Access Signatures.
        /// </summary>
        ///
        /// <param name="keyName">The name of the shared access key that the signature should be based on.</param>
        /// <param name="keyValue">The value of the shared access key for the signature.</param>
        ///
        public void UpdateSharedAccessKey(
            string keyName,
            string keyValue)
        {
            Argument.AssertNotNullOrEmpty(keyName, nameof(keyName));
            Argument.AssertNotNullOrEmpty(keyValue, nameof(keyValue));

            SharedAccessKeyName = keyName;
            SharedAccessKey = keyValue;

            SharedAccessSignatureCredential?.UpdateSharedAccessKey(keyName, keyValue);
        }

        /// <summary>
        ///   Coverts to shared access signature credential.
        ///   It retains a reference to the generated SharedAccessSignatureCredential.
        /// </summary>
        ///
        /// <param name="serviceBusResource">The Service Bus resource to which the token is intended to serve as authorization.</param>
        /// <param name="signatureValidityDuration">The duration that the signature should be considered valid; if not specified, a default will be assumed.</param>
        ///
        /// <returns>A new <see cref="SharedAccessSignatureCredential" /> based on the requested shared access key.</returns>
        ///
        internal SharedAccessSignatureCredential AsSharedAccessSignatureCredential(
            string serviceBusResource,
            TimeSpan? signatureValidityDuration = default)
        {
            SharedAccessSignatureCredential = new SharedAccessSignatureCredential(new SharedAccessSignature(serviceBusResource, SharedAccessKeyName, SharedAccessKey, signatureValidityDuration));

            return SharedAccessSignatureCredential;
        }
    }
}
