// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.PhoneNumbers
{
    internal sealed class PhoneNumbersEndpointValidationPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly Uri _endpoint;

        public PhoneNumbersEndpointValidationPolicy(string endpoint)
        {
            _endpoint = new Uri(endpoint);
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            Uri requestUri = message.Request.Uri.ToUri();
            if (!string.Equals(requestUri.Scheme, _endpoint.Scheme, StringComparison.OrdinalIgnoreCase) ||
                !string.Equals(requestUri.Host, _endpoint.Host, StringComparison.OrdinalIgnoreCase) ||
                requestUri.Port != _endpoint.Port)
            {
                throw new InvalidOperationException("The request URI must have the same scheme, host, and port as the configured endpoint.");
            }
        }
    }
}
