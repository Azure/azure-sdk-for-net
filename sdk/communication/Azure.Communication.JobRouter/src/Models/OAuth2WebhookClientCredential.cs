// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class OAuth2WebhookClientCredential
    {
        /// <summary> Initializes a new instance of OAuth2WebhookClientCredential. </summary>
        /// <param name="clientId"> ClientId for Contoso Authorization server. </param>
        /// <param name="clientSecret"> Client secret for Contoso Authorization server. </param>
        public OAuth2WebhookClientCredential(string clientId, string clientSecret)
        {
            Argument.AssertNotNullOrWhiteSpace(clientId, nameof(clientId));
            Argument.AssertNotNullOrWhiteSpace(clientSecret, nameof(clientSecret));

            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary> ClientId for Contoso Authorization server. </summary>
        internal string ClientId { get; }

        /// <summary> Client secret for Contoso Authorization server. </summary>
        internal string ClientSecret { get; }
    }
}
