// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Messaging.EventGrid
{
    internal class SharedAccessSignatureCredentialPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly SharedAccessSignatureCredential _credential;

        /// <summary>
        /// Initializes a new instance of the <see cref="SharedAccessSignatureCredentialPolicy"/> class.
        /// </summary>
        /// <param name="credential">The <see cref="SharedAccessSignatureCredential"/> used to authenticate requests.</param>
        public SharedAccessSignatureCredentialPolicy(SharedAccessSignatureCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            _credential = credential;
        }

        /// <inheritdoc/>
        public override void OnSendingRequest(HttpMessage message)
        {
            base.OnSendingRequest(message);
            message.Request.Headers.SetValue(Constants.SasTokenName, _credential.Signature);
        }
    }
}
