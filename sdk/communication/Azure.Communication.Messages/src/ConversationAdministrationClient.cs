// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Threading;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Messages
{
    /// <summary>
    /// The Azure Communication Services Conversation Adminstration client.
    /// </summary>

    public partial class ConversationAdministrationClient
    {
        #region public constructors

        /// <summary>
        /// Initializes a new instance of <see cref="ConversationAdministrationClient"/>.
        /// </summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public ConversationAdministrationClient(string connectionString)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                new CommunicationMessagesClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="ConversationAdministrationClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client options exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public ConversationAdministrationClient(string connectionString, CommunicationMessagesClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new CommunicationMessagesClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="ConversationAdministrationClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="credential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client options exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public ConversationAdministrationClient(Uri endpoint, AzureKeyCredential credential, CommunicationMessagesClientOptions options = default)
             : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(credential, nameof(credential)),
                options ?? new CommunicationMessagesClientOptions())
        {
            _keyCredential = credential;
        }

        /// <summary> Initializes a new instance of ConversationManagementClient. </summary>
        /// <param name="endpoint"> The communication resource, for example https://my-resource.communication.azure.com. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ConversationAdministrationClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new CommunicationMessagesClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ConversationManagementClient. </summary>
        /// <param name="endpoint"> The communication resource, for example https://my-resource.communication.azure.com. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ConversationAdministrationClient(Uri endpoint, TokenCredential credential, CommunicationMessagesClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new CommunicationMessagesClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        #endregion

        #region private constructors
        private ConversationAdministrationClient(ConnectionString connectionString, CommunicationMessagesClientOptions options)
           : this(new Uri(connectionString.GetRequired("endpoint")), options.BuildHttpPipeline(connectionString), options)
        { }

        private ConversationAdministrationClient(string endpoint, AzureKeyCredential keyCredential, CommunicationMessagesClientOptions options)
            : this(new Uri(endpoint), options.BuildHttpPipeline(keyCredential), options)
        { }

        private ConversationAdministrationClient(Uri endpoint, HttpPipeline httpPipeline, CommunicationMessagesClientOptions options)
        {
            ClientDiagnostics = new ClientDiagnostics(options);
            _pipeline = httpPipeline;
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        #endregion

        /// <summary> Initializes a new instance of ConversationManagementClient. </summary>
        /// <param name="endpoint"> The communication resource, for example https://my-resource.communication.azure.com. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        internal ConversationAdministrationClient(Uri endpoint) : this(endpoint, new CommunicationMessagesClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ConversationManagementClient. </summary>
        /// <param name="endpoint"> The communication resource, for example https://my-resource.communication.azure.com. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        internal ConversationAdministrationClient(Uri endpoint, CommunicationMessagesClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new CommunicationMessagesClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary>Initializes a new instance of <see cref="ConversationAdministrationClient"/> for mocking.</summary>
        protected ConversationAdministrationClient()
        {
            ClientDiagnostics = null!;
        }
    }
}
