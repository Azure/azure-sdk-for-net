// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Personalizer.Models
{
    internal class ClientConfigurationRestClient
    {
        private string endpoint;
        private ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;

        /// <summary> Initializes a new instance of ClientConfigurationRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public ClientConfigurationRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint)
        {
            this.endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }
        internal HttpMessage CreatePostRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendRaw("/personalizer/v1.1-preview.1", false);
            uri.AppendPath("/configurations/client", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get the Personalizer service configuration. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<PersonalizerClientProperties>> PostAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePostRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PersonalizerClientProperties value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = PersonalizerClientProperties.DeserializePersonalizerServiceProperties(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Get the Personalizer service configuration. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<PersonalizerClientProperties> Post(CancellationToken cancellationToken = default)
        {
            using var message = CreatePostRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PersonalizerClientProperties value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = PersonalizerClientProperties.DeserializePersonalizerServiceProperties(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
