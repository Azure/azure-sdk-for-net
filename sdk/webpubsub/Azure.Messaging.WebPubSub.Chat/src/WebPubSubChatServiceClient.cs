// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Messaging.WebPubSub.Chat
{
    [CodeGenSuppress("WebPubSubChatServiceClient", typeof(Uri), typeof(string), typeof(TokenCredential))]
    [CodeGenSuppress("WebPubSubChatServiceClient", typeof(Uri), typeof(string), typeof(TokenCredential), typeof(WebPubSubChatServiceClientOptions))]
    [CodeGenSuppress("WebPubSubChatServiceClient", typeof(HttpPipelinePolicy), typeof(Uri), typeof(string), typeof(WebPubSubChatServiceClientOptions))]
    public partial class WebPubSubChatServiceClient
    {
        /// <summary>
        /// The hub name this client is connected to.
        /// </summary>
        public virtual string Hub => _hub;

        internal WebPubSubChatServiceClient(HttpPipelinePolicy authenticationPolicy, Uri endpoint, string hub, WebPubSubChatServiceClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNullOrEmpty(hub, nameof(hub));

            options ??= new WebPubSubChatServiceClientOptions();

            _endpoint = endpoint;
            _hub = hub;

            HttpPipelinePolicy[] perCallPolicies = options.ReverseProxyEndpoint == null
                ? Array.Empty<HttpPipelinePolicy>()
                : new HttpPipelinePolicy[] { new ReverseProxyPolicy(options.ReverseProxyEndpoint) };
            HttpPipelinePolicy[] perRetryPolicies = authenticationPolicy == null
                ? Array.Empty<HttpPipelinePolicy>()
                : new HttpPipelinePolicy[] { authenticationPolicy };
            Pipeline = HttpPipelineBuilder.Build(options, perCallPolicies, perRetryPolicies, new ResponseClassifier());

            _apiVersion = options.Version;
            ClientDiagnostics = new ClientDiagnostics(options, true);
        }

        /// <summary> Initializes a new instance of WebPubSubChatServiceClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="hub"> Target hub name. </param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, <paramref name="hub"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="hub"/> is an empty string, and was expected to be non-empty. </exception>
        public WebPubSubChatServiceClient(Uri endpoint, string hub, TokenCredential credential)
            : this(endpoint, hub, credential, new WebPubSubChatServiceClientOptions())
        {
        }

        /// <summary> Initializes a new instance of WebPubSubChatServiceClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="hub"> Target hub name. </param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, <paramref name="hub"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="hub"/> is an empty string, and was expected to be non-empty. </exception>
        public WebPubSubChatServiceClient(Uri endpoint, string hub, TokenCredential credential, WebPubSubChatServiceClientOptions options)
            : this(new BearerTokenAuthenticationPolicy(credential, AuthorizationScopes), endpoint, hub, options)
        {
            _tokenCredential = credential;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="WebPubSubChatServiceClient"/> using a connection string.
        /// </summary>
        /// <param name="connectionString">Connection string containing Endpoint and AccessKey.</param>
        /// <param name="hub">Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore.</param>
        public WebPubSubChatServiceClient(string connectionString, string hub)
            : this(connectionString, hub, new WebPubSubChatServiceClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="WebPubSubChatServiceClient"/> using a connection string.
        /// </summary>
        /// <param name="connectionString">Connection string containing Endpoint and AccessKey.</param>
        /// <param name="hub">Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore.</param>
        /// <param name="options">The options for configuring the client.</param>
        public WebPubSubChatServiceClient(string connectionString, string hub, WebPubSubChatServiceClientOptions options)
            : this(ConnectionStringParser.Parse(connectionString), hub, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="WebPubSubChatServiceClient"/> using an endpoint and <see cref="AzureKeyCredential"/>.
        /// </summary>
        /// <param name="endpoint">Service endpoint.</param>
        /// <param name="hub">Target hub name.</param>
        /// <param name="credential">An <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        public WebPubSubChatServiceClient(Uri endpoint, string hub, AzureKeyCredential credential)
            : this(endpoint, hub, credential, new WebPubSubChatServiceClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="WebPubSubChatServiceClient"/> using an endpoint and <see cref="AzureKeyCredential"/>.
        /// </summary>
        /// <param name="endpoint">Service endpoint.</param>
        /// <param name="hub">Target hub name.</param>
        /// <param name="credential">An <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">The options for configuring the client.</param>
        public WebPubSubChatServiceClient(Uri endpoint, string hub, AzureKeyCredential credential, WebPubSubChatServiceClientOptions options)
            : this(new WebPubSubAuthenticationPolicy(credential ?? throw new ArgumentNullException(nameof(credential))), endpoint, hub, options ?? new WebPubSubChatServiceClientOptions())
        {
            _keyCredential = credential;
        }

        private WebPubSubChatServiceClient((Uri Endpoint, AzureKeyCredential Credential) parsed, string hub, WebPubSubChatServiceClientOptions options)
            : this(parsed.Endpoint, hub, parsed.Credential, options)
        {
        }
    }
}
