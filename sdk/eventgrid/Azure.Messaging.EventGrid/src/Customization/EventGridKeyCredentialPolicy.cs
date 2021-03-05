// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.EventGrid
{
    internal class EventGridKeyCredentialPolicy : AzureKeyCredentialPolicy
    {
        private readonly string _name;
        private readonly AzureKeyCredential _credential;

        public EventGridKeyCredentialPolicy(AzureKeyCredential credential, string name) : base(credential, name)
        {
            _credential = credential;
            _name = name;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            base.OnSendingRequest(message);

            // AzureSystemPublisher is the key that internal partners will use
            // when authenticating with a certificate. So we don't need to include the key
            // in the request in this case.
            if (_credential.Key != "AzureSystemPublisher")
            {
                message.Request.Headers.SetValue(_name, _credential.Key);
            }
        }
    }
}
