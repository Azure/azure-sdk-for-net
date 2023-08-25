// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;

#nullable enable

namespace Azure.Core
{
    internal class AzureKeyCredentialPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly string _name;
        private readonly AzureKeyCredential _credential;
        private readonly string? _prefix;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureKeyCredentialPolicy"/> class.
        /// </summary>
        /// <param name="credential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="name">The name of the key header used for the credential.</param>
        /// <param name="prefix">The prefix to apply before the credential key. For example, a prefix of "SharedAccessKey" would result in
        /// a value of "SharedAccessKey {credential.Key}" being stamped on the request header with header key of <paramref name="name"/>.</param>
        public AzureKeyCredentialPolicy(AzureKeyCredential credential, string name, string? prefix = null)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            _credential = credential;
            _name = name;
            _prefix = prefix;
        }

        /// <inheritdoc/>
        public override void OnSendingRequest(HttpMessage message)
        {
            base.OnSendingRequest(message);
            message.Request.Headers.SetValue(_name, _prefix != null ? $"{_prefix} {_credential.Key}" :  _credential.Key);
        }
    }
}
