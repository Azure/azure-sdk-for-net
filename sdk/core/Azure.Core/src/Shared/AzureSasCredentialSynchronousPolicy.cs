// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
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
            var querySpan = query.AsSpan();
            string signature = _credential.Signature;
            bool hasLeadingQuestionMark = signature.StartsWith("?", StringComparison.InvariantCulture);
            var signatureSpan = signature.AsSpan(hasLeadingQuestionMark ? 1 : 0);
            if (!querySpan.Contains(signatureSpan, StringComparison.InvariantCulture))
            {
                var finalQuery = new StringBuilder(query.Length + signatureSpan.Length + 1);
                if (string.IsNullOrEmpty(query))
                {
                    finalQuery.Append('?');
                }
                else
                {
                    finalQuery.Append(query);
                    finalQuery.Append('&');
                }
                finalQuery.Append(signature, hasLeadingQuestionMark ? 1 : 0, hasLeadingQuestionMark ? signature.Length - 1 : signature.Length);
                message.Request.Uri.Query = finalQuery.ToString();
            }

            base.OnSendingRequest(message);
        }
    }
}
