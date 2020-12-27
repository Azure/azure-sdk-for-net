// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
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
            string query = message.Request.Uri.Query;
            string signature = _credential.Signature;
            if (signature.StartsWith("?", StringComparison.InvariantCulture))
            {
                signature = signature.AsSpan().Slice(1).ToString();
            }
            if (!query.Contains(signature))
            {
                var newQuery = new StringBuilder(query, query.Length + signature.Length + 1);
                newQuery.Append(string.IsNullOrEmpty(query) ? '?' : '&');
                newQuery.Append(signature);
                message.Request.Uri.Query = newQuery.ToString();
            }

            base.OnSendingRequest(message);
        }
    }
}
