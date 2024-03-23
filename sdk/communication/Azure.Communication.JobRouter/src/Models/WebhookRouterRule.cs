// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.JobRouter
{
    public partial class WebhookRouterRule
    {
        /// <summary> Initializes a new instance of WebhookRouterRule. </summary>
        public WebhookRouterRule(Uri authorizationServerUri, OAuth2WebhookClientCredential clientCredential, Uri webhookUri)
        {
            Kind = RouterRuleKind.Webhook;
            AuthorizationServerUri = authorizationServerUri;
            ClientCredential = clientCredential;
            WebhookUri = webhookUri;
        }
    }
}
