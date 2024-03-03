// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            if (clientId == null)
            {
                throw new ArgumentNullException(nameof(clientId));
            }
            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentException("Value cannot be empty or contain only white-space characters.", nameof(clientId));
            }
            if (clientSecret == null)
            {
                throw new ArgumentNullException(nameof(clientSecret));
            }
            if (string.IsNullOrWhiteSpace(clientSecret))
            {
                throw new ArgumentException("Value cannot be empty or contain only white-space characters.", nameof(clientSecret));
            }

            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary> ClientId for Contoso Authorization server. </summary>
        internal string ClientId { get; }

        /// <summary> Client secret for Contoso Authorization server. </summary>
        internal string ClientSecret { get; }
    }
}
