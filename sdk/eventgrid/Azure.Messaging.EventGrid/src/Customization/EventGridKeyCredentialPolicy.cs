// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Messaging.EventGrid
{
    internal class EventGridKeyCredentialPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly string _name;
        private readonly AzureKeyCredential _credential;
        public const string SystemPublisherKey = "AzureSystemPublisher";

        public EventGridKeyCredentialPolicy(AzureKeyCredential credential, string name)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            _credential = credential;
            _name = name;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            base.OnSendingRequest(message);

            // AzureSystemPublisher is the key that internal partners will use
            // when authenticating with a certificate. So we don't need to include the key
            // in the request in this case.
            if (_credential.Key != SystemPublisherKey)
            {
                message.Request.Headers.SetValue(_name, _credential.Key);
            }
        }
    }
}
