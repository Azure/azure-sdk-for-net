// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

#nullable enable

namespace Azure.Core
{
    internal class AzureSasCredentialSynchronousPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly AzureSasCredential _credential;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureSasCredentialSynchronousPolicy"/> class.
        /// </summary>
        /// <param name="credential">The <see cref="AzureSasCredentialSynchronousPolicy"/> used to authenticate requests.</param>
        public AzureSasCredentialSynchronousPolicy(AzureSasCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            _credential = credential;
        }

        /// <inheritdoc/>
        public override void OnSendingRequest(HttpMessage message)
        {
            string query = message.Request.Uri.Query;
            string signature = _credential.Signature;
            if (signature.StartsWith("?", StringComparison.InvariantCulture))
            {
                signature = signature.Substring(1);
            }

            if (!query.Contains(signature))
            {
                // Get the signature history so we know which string to replace in the query if it was previously set.
                if (message.TryGetProperty(typeof(AzureSasSignatureHistory), out object? previousSignature) &&
                    previousSignature is string previousSignatureString &&
                    query.Contains(previousSignatureString))
                {
                    query = query.Replace(previousSignatureString, signature);
                }
                else
                {
                    // This is the first time we're setting the signature, so we need to add it to the query.
                    query = string.IsNullOrEmpty(query) ? '?' + signature : query + '&' + signature;
                }
                message.Request.Uri.Query = query;
                // Store the signature in the message property bag so we can replace it if it changes.
                message.SetProperty(typeof(AzureSasSignatureHistory), signature);

                base.OnSendingRequest(message);
            }
        }

        /// <summary>
        /// A marker class used to represent AzureSasCredential signature history on the <see cref="HttpMessage"/> property bag.
        /// </summary>
        private class AzureSasSignatureHistory { }
    }
}
