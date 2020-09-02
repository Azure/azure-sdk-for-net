// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class AzureKeyCredentialPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly string _name;
        private readonly AzureKeyCredential _credential;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureKeyCredentialPolicy"/> class.
        /// </summary>
        /// <param name="credential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="name">The name of the key header used for the credential.</param>
        public AzureKeyCredentialPolicy(AzureKeyCredential credential, string name)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            _credential = credential;
            _name = name;
        }

        /// <inheritdoc/>
        public override void OnSendingRequest(HttpMessage message)
        {
            base.OnSendingRequest(message);
            message.Request.Headers.SetValue(_name, _credential.Key);
        }
    }
}
