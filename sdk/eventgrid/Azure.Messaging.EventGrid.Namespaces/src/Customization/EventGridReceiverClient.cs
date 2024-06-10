// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Messaging.EventGrid.Namespaces
{
    [CodeGenSuppress("EventGridReceiverClient", typeof(Uri), typeof(AzureKeyCredential))]
    [CodeGenSuppress("EventGridReceiverClient", typeof(Uri), typeof(TokenCredential))]
    [CodeGenSuppress("EventGridReceiverClient", typeof(Uri), typeof(AzureKeyCredential), typeof(AzureMessagingEventGridNamespacesClientOptions))]
    [CodeGenSuppress("EventGridReceiverClient", typeof(Uri), typeof(TokenCredential), typeof(AzureMessagingEventGridNamespacesClientOptions))]
    public partial class EventGridReceiverClient
    {
        /// <summary> Initializes a new instance of EventGridReceiverClient. </summary>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public EventGridReceiverClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, new EventGridReceiverClientOptions())
        {
        }

        /// <summary> Initializes a new instance of EventGridReceiverClient. </summary>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public EventGridReceiverClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new EventGridReceiverClientOptions())
        {
        }

        /// <summary> Initializes a new instance of EventGridReceiverClient. </summary>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public EventGridReceiverClient(Uri endpoint, AzureKeyCredential credential, EventGridReceiverClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new EventGridReceiverClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader, AuthorizationApiKeyPrefix) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Initializes a new instance of EventGridReceiverClient. </summary>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public EventGridReceiverClient(Uri endpoint, TokenCredential credential, EventGridReceiverClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new EventGridReceiverClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }
    }
}
