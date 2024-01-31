// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Maps
{
    /// <summary> The MapsSasCredentialPolicy used for SAS authentication. </summary>
    internal sealed class MapsSasCredentialPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly string _sasAuthenticationHeader = "Authorization";
        private readonly string _sasPrefix = "jwt-sas";
        private readonly AzureSasCredential _credential;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapsSasCredentialPolicy"/> class.
        /// </summary>
        /// <param name="credential">The <see cref="AzureSasCredential"/> used to authenticate requests.</param>
        public MapsSasCredentialPolicy(AzureSasCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            _credential = credential;
        }

        /// <inheritdoc/>
        public override void OnSendingRequest(HttpMessage message)
        {
            base.OnSendingRequest(message);
            message.Request.Headers.SetValue(_sasAuthenticationHeader, _sasPrefix + " " + _credential.Signature);
        }
    }
}
