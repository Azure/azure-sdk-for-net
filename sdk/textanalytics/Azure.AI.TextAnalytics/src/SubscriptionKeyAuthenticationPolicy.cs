﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.TextAnalytics
{
    internal class SubscriptionKeyAuthenticationPolicy : HttpPipelineSynchronousPolicy
    {
        private const string AuthorizationHeader = "Ocp-Apim-Subscription-Key";
        private TextAnalyticsSubscriptionKeyCredential _credential;

        public SubscriptionKeyAuthenticationPolicy(TextAnalyticsSubscriptionKeyCredential credential)
        {
            _credential = credential;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            message.Request.Headers.Add(AuthorizationHeader, _credential.SubscriptionKey);
        }
    }
}
