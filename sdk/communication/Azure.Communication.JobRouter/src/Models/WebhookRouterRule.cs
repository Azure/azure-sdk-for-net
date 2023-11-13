// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class WebhookRouterRule : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of WebhookRouterRule. </summary>
        public WebhookRouterRule(Uri authorizationServerUri, OAuth2WebhookClientCredential clientCredential, Uri webhookUri)
            : this("webhook-rule", authorizationServerUri, clientCredential, webhookUri)
        {
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(AuthorizationServerUri))
            {
                writer.WritePropertyName("authorizationServerUri"u8);
                writer.WriteStringValue(AuthorizationServerUri.AbsoluteUri);
            }
            if (Optional.IsDefined(ClientCredential))
            {
                writer.WritePropertyName("clientCredential"u8);
                writer.WriteObjectValue(ClientCredential);
            }
            if (Optional.IsDefined(WebhookUri))
            {
                writer.WritePropertyName("webhookUri"u8);
                writer.WriteStringValue(WebhookUri.AbsoluteUri);
            }
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            writer.WriteEndObject();
        }
    }
}
