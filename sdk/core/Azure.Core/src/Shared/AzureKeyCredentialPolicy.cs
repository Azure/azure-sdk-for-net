// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class AzureKeyCredentialPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly string _keyHeader;
        private readonly AzureKeyCredential _credential;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureKeyCredentialPolicy"/> class.
        /// </summary>
        /// <param name="credential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="keyHeader">The name of the API key header used for signing requests.</param>
        public AzureKeyCredentialPolicy(AzureKeyCredential credential, string keyHeader)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNullOrEmpty(keyHeader, nameof(keyHeader));
            _credential = credential;
            _keyHeader = keyHeader;
        }

        /// <inheritdoc/>
        public override void OnSendingRequest(HttpMessage message)
        {
            base.OnSendingRequest(message);
            message.Request.Headers.SetValue(_keyHeader, _credential.Key);
        }
    }
}
