// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Autorest.CSharp.Core;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Messages
{
    /// <summary>
    /// The Azure Communication Services Message Template client.
    /// </summary>
    [CodeGenSuppress("MessageTemplateClient", typeof(Uri))]
    [CodeGenSuppress("MessageTemplateClient", typeof(Uri), typeof(CommunicationMessagesClientOptions))]

    public partial class MessageTemplateClient
    {
        #region public constructors

        /// <summary>
        /// Initializes a new instance of <see cref="MessageTemplateClient"/>.
        /// </summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public MessageTemplateClient(string connectionString)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                new CommunicationMessagesClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="MessageTemplateClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client options exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public MessageTemplateClient(string connectionString, CommunicationMessagesClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new CommunicationMessagesClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="MessageTemplateClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="credential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client options exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public MessageTemplateClient(Uri endpoint, AzureKeyCredential credential, CommunicationMessagesClientOptions options = default)
             : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(credential, nameof(credential)),
                options ?? new CommunicationMessagesClientOptions())
        {
        }

        #endregion

        #region private constructors
        private MessageTemplateClient(ConnectionString connectionString, CommunicationMessagesClientOptions options)
           : this(new Uri(connectionString.GetRequired("endpoint")), options.BuildHttpPipeline(connectionString), options)
        { }

        private MessageTemplateClient(string endpoint, TokenCredential tokenCredential, CommunicationMessagesClientOptions options)
            : this(new Uri(endpoint), options.BuildHttpPipeline(tokenCredential), options)
        { }

        private MessageTemplateClient(string endpoint, AzureKeyCredential keyCredential, CommunicationMessagesClientOptions options)
            : this(new Uri(endpoint), options.BuildHttpPipeline(keyCredential), options)
        { }

        private MessageTemplateClient(Uri endpoint, HttpPipeline httpPipeline, CommunicationMessagesClientOptions options)
        {
            ClientDiagnostics = new ClientDiagnostics(options);
            _pipeline = httpPipeline;
            _endpoint = endpoint;
            _apiVersion = options.ApiVersion;
        }

        #endregion

        /// <summary> Initializes a new instance of MessageTemplateClient. </summary>
        /// <param name="endpoint"> The communication resource, for example https://my-resource.communication.azure.com. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        internal MessageTemplateClient(Uri endpoint) : this(endpoint, new CommunicationMessagesClientOptions())
        {
        }

        /// <summary> Initializes a new instance of MessageTemplateClient. </summary>
        /// <param name="endpoint"> The communication resource, for example https://my-resource.communication.azure.com. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        internal MessageTemplateClient(Uri endpoint, CommunicationMessagesClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new CommunicationMessagesClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary>Initializes a new instance of <see cref="MessageTemplateClient"/> for mocking.</summary>
        protected MessageTemplateClient()
        {
            ClientDiagnostics = null!;
        }

        #region List Templates Operations
        /// <summary> List all templates for given ACS channel asynchronously. </summary>
        /// <param name="channelRegistrationId"> The registration ID of the channel. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<MessageTemplateItem> GetTemplatesAsync(string channelRegistrationId, CancellationToken cancellationToken = default)
        {
            _ = channelRegistrationId ?? throw new ArgumentNullException(nameof(channelRegistrationId));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTemplatesRequest(channelRegistrationId, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTemplatesNextPageRequest(nextLink, channelRegistrationId, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, MessageTemplateItem.DeserializeMessageTemplateResponse, ClientDiagnostics, _pipeline, "MessageTemplateClient.GetTemplates", "value", "nextLink", context);
        }

        /// <summary> List all templates for given ACS channel. </summary>
        /// <param name="channelRegistrationId"> The registration ID of the channel. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<MessageTemplateItem> GetTemplates(string channelRegistrationId, CancellationToken cancellationToken = default)
        {
            _ = channelRegistrationId ?? throw new ArgumentNullException(nameof(channelRegistrationId));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTemplatesRequest(channelRegistrationId, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTemplatesNextPageRequest(nextLink, channelRegistrationId, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, MessageTemplateItem.DeserializeMessageTemplateResponse, ClientDiagnostics, _pipeline, "MessageTemplateClient.GetTemplates", "value", "nextLink", context);
        }
        #endregion

        private static HttpPipeline CreatePipelineFromOptions(ConnectionString connectionString, CommunicationMessagesClientOptions options)
        {
            return options.BuildHttpPipeline(connectionString);
        }
    }
}
