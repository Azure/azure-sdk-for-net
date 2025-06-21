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
    [CodeGenSuppress("CreateChatThreadAsync", typeof(string), typeof(IEnumerable<ChatParticipantInternal>), typeof(IDictionary<string, string>), typeof(CancellationToken))]
    [CodeGenSuppress("CreateChatThread", typeof(string), typeof(IEnumerable<ChatParticipantInternal>), typeof(IDictionary<string, string>), typeof(CancellationToken))]
    internal partial class ChatRestClient
    {
        internal HttpMessage CreateCreateChatThreadRequest(CreateChatThreadOptions options)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/chat/threads", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("repeatability-request-id", options.IdempotencyToken ?? Guid.NewGuid().ToString());
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            CreateChatThreadRequest createChatThreadRequest = new CreateChatThreadRequest(options.Topic);
            if (options.Participants != null)
            {
                foreach (var value in options.Participants)
                {
                    createChatThreadRequest.Participants.Add(value.ToChatParticipantInternal());
                }
            }

            if (options.Metadata != null)
            {
                foreach (var value in options.Metadata)
                {
                    createChatThreadRequest.Metadata.Add(value);
                }
            }

            if (options.RetentionPolicy != null)
            {
                createChatThreadRequest.RetentionPolicy = ChatRetentionPolicyConverter.ConvertBack(options.RetentionPolicy);
            }

            var model = createChatThreadRequest;
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(model);
            request.Content = content;
            return message;
        }

        /// <summary> Creates a chat thread. </summary>
        /// <param name="options">The options to use for creating the chat thread.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options.Topic"/> is null. </exception>
        public async Task<Response<CreateChatThreadResultInternal>> CreateChatThreadAsync(CreateChatThreadOptions options, CancellationToken cancellationToken = default)
        {
            if (options?.Topic == null)
            {
                throw new ArgumentNullException(nameof(options.Topic));
            }

            using var message = CreateCreateChatThreadRequest(options);
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
        /// <param name="options">The options to use for creating the chat thread.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options.Topic"/> is null. </exception>
        public Response<CreateChatThreadResultInternal> CreateChatThread(CreateChatThreadOptions options, CancellationToken cancellationToken = default)
        {
            if (options.Topic == null)
            {
                throw new ArgumentNullException(nameof(options.Topic));
            }

            using var message = CreateCreateChatThreadRequest(options);
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
