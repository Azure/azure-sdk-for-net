// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
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
        private static readonly string[] ChatClientRoles = new[]
        {
            "webpubsub.getGroupState",
            "webpubsub.setGroupState"
        };

        private readonly WebPubSubServiceClient _webPubSubServiceClient;

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
            _webPubSubServiceClient = CreateWebPubSubServiceClient(endpoint, hub, credential, options);
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
            _webPubSubServiceClient = CreateWebPubSubServiceClient(endpoint, hub, credential, options);
        }

        private WebPubSubChatServiceClient((Uri Endpoint, AzureKeyCredential Credential) parsed, string hub, WebPubSubChatServiceClientOptions options)
            : this(parsed.Endpoint, hub, parsed.Credential, options)
        {
        }

        /// <summary>
        /// Generates a client access URI that a client can use to connect to the Web PubSub Chat service.
        /// The URI includes a JWT access token as a query parameter.
        /// </summary>
        /// <param name="options">Options controlling the generated token. Pass <c>null</c> to use defaults.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Uri"/> that a client can use to connect, with the access token included.</returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Uri GetClientAccessUri(
            GetClientAccessTokenOptions options = null,
            CancellationToken cancellationToken = default)
        {
            var client = _webPubSubServiceClient
                ?? throw new InvalidOperationException("GetClientAccessUri requires the client to be constructed with credentials.");

            options ??= new GetClientAccessTokenOptions();

            return client.GetClientAccessUri(
                expiresAfter: options.ExpiresAfter == default ? TimeSpan.FromHours(1) : options.ExpiresAfter,
                userId: options.UserId,
                roles: ChatClientRoles,
                cancellationToken: cancellationToken);
        }
#pragma warning restore AZC0015

        /// <summary>
        /// Generates a client access URI that a client can use to connect to the Web PubSub Chat service.
        /// The URI includes a JWT access token as a query parameter.
        /// </summary>
        /// <param name="options">Options controlling the generated token. Pass <c>null</c> to use defaults.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Uri"/> that a client can use to connect, with the access token included.</returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Uri> GetClientAccessUriAsync(
            GetClientAccessTokenOptions options = null,
            CancellationToken cancellationToken = default)
        {
            var client = _webPubSubServiceClient
                ?? throw new InvalidOperationException("GetClientAccessUri requires the client to be constructed with credentials.");

            options ??= new GetClientAccessTokenOptions();

            return await client.GetClientAccessUriAsync(
                expiresAfter: options.ExpiresAfter == default ? TimeSpan.FromHours(1) : options.ExpiresAfter,
                userId: options.UserId,
                roles: ChatClientRoles,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }
#pragma warning restore AZC0015

        private static WebPubSubServiceClient CreateWebPubSubServiceClient(Uri endpoint, string hub, AzureKeyCredential credential, WebPubSubChatServiceClientOptions chatOptions)
            => new WebPubSubServiceClient(endpoint, hub, credential, CreateServiceOptions(chatOptions));

        private static WebPubSubServiceClient CreateWebPubSubServiceClient(Uri endpoint, string hub, TokenCredential credential, WebPubSubChatServiceClientOptions chatOptions)
            => new WebPubSubServiceClient(endpoint, hub, credential, CreateServiceOptions(chatOptions));

        /// <summary>
        /// Builds the <see cref="WebPubSubServiceClientOptions"/> for the underlying client.
        /// </summary>
        /// <remarks>
        /// <see cref="WebPubSubChatServiceClientOptions.ReverseProxyEndpoint"/> and the transport are propagated.
        /// Propagating the remaining base <see cref="Azure.Core.ClientOptions"/> members (retry,
        /// diagnostics, custom policies) needs more design and is deferred to a future version.
        /// </remarks>
        private static WebPubSubServiceClientOptions CreateServiceOptions(WebPubSubChatServiceClientOptions chatOptions)
        {
            var serviceOptions = new WebPubSubServiceClientOptions();
            if (chatOptions != null)
            {
                serviceOptions.ReverseProxyEndpoint = chatOptions.ReverseProxyEndpoint;
                serviceOptions.Transport = chatOptions.Transport;

                // TODO: Propagate the remaining base ClientOptions members (RetryPolicy, Retry,
                // Diagnostics, and custom AddPolicy policies) from chatOptions to serviceOptions so the
                // underlying WebPubSubServiceClient behaves identically to this client. This matters because
                // GetClientAccessUri when using a TokenCredential calls the service over the inner client's
                // pipeline.
                // Deferred: needs design (custom policies aren't readable from ClientOptions, and the inner
                // client's service/api-version must not be overwritten). See earlier discussion.
            }

            return serviceOptions;
        }
    }
}
