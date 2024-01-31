// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Chat
{
    // for backward compatibility, keep the previous method signature which will accept `repeatability-request-id` as a parameter
    [CodeGenSuppress("CreateCreateChatThreadRequest", typeof(string), typeof(IEnumerable<ChatParticipantInternal>))]
    [CodeGenSuppress("CreateChatThreadAsync", typeof(string), typeof(IEnumerable<ChatParticipantInternal>), typeof(CancellationToken))]
    [CodeGenSuppress("CreateChatThread", typeof(string), typeof(IEnumerable<ChatParticipantInternal>), typeof(CancellationToken))]
    internal partial class ChatRestClient
    {
        internal HttpMessage CreateCreateChatThreadRequest(string topic, string repeatabilityRequestId, IEnumerable<ChatParticipantInternal> participants)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/chat/threads", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("repeatability-request-id", repeatabilityRequestId ?? Guid.NewGuid().ToString());
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            CreateChatThreadRequest createChatThreadRequest = new CreateChatThreadRequest(topic);
            if (participants != null)
            {
                foreach (var value in participants)
                {
                    createChatThreadRequest.Participants.Add(value);
                }
            }
            var model = createChatThreadRequest;
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(model);
            request.Content = content;
            return message;
        }

        /// <summary> Creates a chat thread. </summary>
        /// <param name="topic"> The chat thread topic. </param>
        /// <param name="repeatabilityRequestId"> If specified, the client directs that the request is repeatable; that is, that the client can make the request multiple times with the same Repeatability-Request-Id and get back an appropriate response without the server executing the request multiple times. The value of the Repeatability-Request-Id is an opaque string representing a client-generated, globally unique for all time, identifier for the request. It is recommended to use version 4 (random) UUIDs. </param>
        /// <param name="participants"> Participants to be added to the chat thread. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topic"/> is null. </exception>
        public async Task<Response<CreateChatThreadResultInternal>> CreateChatThreadAsync(string topic, string repeatabilityRequestId = null, IEnumerable<ChatParticipantInternal> participants = null, CancellationToken cancellationToken = default)
        {
            if (topic == null)
            {
                throw new ArgumentNullException(nameof(topic));
            }

            using var message = CreateCreateChatThreadRequest(topic, repeatabilityRequestId, participants);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    {
                        CreateChatThreadResultInternal value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = CreateChatThreadResultInternal.DeserializeCreateChatThreadResultInternal(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates a chat thread. </summary>
        /// <param name="topic"> The chat thread topic. </param>
        /// <param name="repeatabilityRequestId"> If specified, the client directs that the request is repeatable; that is, that the client can make the request multiple times with the same Repeatability-Request-Id and get back an appropriate response without the server executing the request multiple times. The value of the Repeatability-Request-Id is an opaque string representing a client-generated, globally unique for all time, identifier for the request. It is recommended to use version 4 (random) UUIDs. </param>
        /// <param name="participants"> Participants to be added to the chat thread. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topic"/> is null. </exception>
        public Response<CreateChatThreadResultInternal> CreateChatThread(string topic, string repeatabilityRequestId = null, IEnumerable<ChatParticipantInternal> participants = null, CancellationToken cancellationToken = default)
        {
            if (topic == null)
            {
                throw new ArgumentNullException(nameof(topic));
            }

            using var message = CreateCreateChatThreadRequest(topic, repeatabilityRequestId, participants);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    {
                        CreateChatThreadResultInternal value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = CreateChatThreadResultInternal.DeserializeCreateChatThreadResultInternal(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
