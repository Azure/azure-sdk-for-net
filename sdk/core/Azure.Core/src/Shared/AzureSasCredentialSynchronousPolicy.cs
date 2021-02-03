// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

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
                query = string.IsNullOrEmpty(query) ? '?' + signature : query + '&' + signature;
                message.Request.Uri.Query = query;
            }

            base.OnSendingRequest(message);
        }
    }
}
