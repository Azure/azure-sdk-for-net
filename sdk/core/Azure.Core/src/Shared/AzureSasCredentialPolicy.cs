// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class AzureSasCredentialPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly AzureSasCredential _credential;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureSasCredentialPolicy"/> class.
        /// </summary>
        /// <param name="credential">The <see cref="AzureSasCredentialPolicy"/> used to authenticate requests.</param>
        public AzureSasCredentialPolicy(AzureSasCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            _credential = credential;
        }

        /// <inheritdoc/>
        public override void OnSendingRequest(HttpMessage message)
        {
            base.OnSendingRequest(message);
            string query = message.Request.Uri.Query;
            if (!query.Contains(_credential.Signature))
            {
                string signature = _credential.Signature;
                if (signature.StartsWith("?", StringComparison.InvariantCulture))
                {
                    signature = signature.Substring(1);
                }
                query = string.IsNullOrEmpty(query) ? '?' + signature : query + '&' + signature;
                message.Request.Uri.Query = query;
            }
        }
    }
}
