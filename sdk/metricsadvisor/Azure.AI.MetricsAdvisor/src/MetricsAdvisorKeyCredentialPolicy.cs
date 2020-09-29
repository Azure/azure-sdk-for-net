// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.MetricsAdvisor
{
    internal class MetricsAdvisorKeyCredentialPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly MetricsAdvisorKeyCredential _credential;

        public MetricsAdvisorKeyCredentialPolicy(MetricsAdvisorKeyCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            _credential = credential;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            base.OnSendingRequest(message);

            message.Request.Headers.SetValue(Constants.SubscriptionAuthorizationHeader, _credential.SubscriptionKey);
            message.Request.Headers.SetValue(Constants.ApiAuthorizationHeader, _credential.ApiKey);
        }
    }
}
