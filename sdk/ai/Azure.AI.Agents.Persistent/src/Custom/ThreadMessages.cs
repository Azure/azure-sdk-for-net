// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.AI.Agents.Persistent.Telemetry;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Agents.Persistent
{
    [CodeGenModel("Messages")]
    public partial class ThreadMessages
    {
        /*
        * CUSTOM CODE DESCRIPTION:
        *
        * These convenience helpers bring additive capabilities to address client methods more ergonomically:
        *  - Use response value instances of types like PersistentAgentThread and ThreadRun instead of raw IDs from those instances
        *     a la thread.Id and run.Id.
        *  - Allow direct file-path-based file upload (with inferred filename parameter placement) in lieu of requiring
        *     manual I/O prior to getting a byte array
        */
        /// <summary>
        /// [Protocol Method] Creates a new message on a specified thread.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateMessageAsync(string,MessageRole,BinaryData,IEnumerable{MessageAttachment},IReadOnlyDictionary{string,string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> CreateMessageAsync(string threadId, RequestContent content, RequestContext context = null)
        {
            using var otelScope = OpenTelemetryScope.StartCreateMessage(threadId, content, _endpoint);
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
            Argument.AssertNotNull(content, nameof(content));

            try
            {
                using HttpMessage message = CreateCreateMessageRequest(threadId, content, context);
                var response = await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                otelScope?.RecordCreateMessageResponse(response);
                return response;
            }
            catch (Exception e)
            {
                otelScope?.RecordError(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a new message on a specified thread.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateMessage(string,MessageRole,BinaryData,IEnumerable{MessageAttachment},IReadOnlyDictionary{string,string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response CreateMessage(string threadId, RequestContent content, RequestContext context = null)
        {
            using var otelScope = OpenTelemetryScope.StartCreateMessage(threadId, content, _endpoint);
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
            Argument.AssertNotNull(content, nameof(content));

            try
            {
                using HttpMessage message = CreateCreateMessageRequest(threadId, content, context);
                var response = _pipeline.ProcessMessage(message, context);
                otelScope?.RecordCreateMessageResponse(response);
                return response;
            }
            catch (Exception e)
            {
                otelScope?.RecordError(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a new message on a specified thread, accepting a simple textual content string.
        /// This API overload matches the original user experience of providing a plain string.
        /// </summary>
        /// <param name="threadId">Identifier of the thread.</param>
        /// <param name="role">
        /// The role of the entity that is creating the message. Allowed values include:
        /// - <c>user</c>: Indicates the message is sent by an actual user.
        /// - <c>assistant</c>: Indicates the message is generated by the agent.
        /// </param>
        /// <param name="content">The plain text content of the message.</param>
        /// <param name="attachments">An optional list of files attached to the message.</param>
        /// <param name="metadata">Optional metadata as key/value pairs.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The newly created <see cref="PersistentThreadMessage"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="threadId"/> or <paramref name="content"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="threadId"/> is empty.</exception>
        public virtual async Task<Response<PersistentThreadMessage>> CreateMessageAsync(
            string threadId,
            MessageRole role,
            string content,
            IEnumerable<MessageAttachment> attachments = null,
            IReadOnlyDictionary<string, string> metadata = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
            Argument.AssertNotNull(content, nameof(content));

            // Serialize the plain text into JSON so that the underlying generated code
            // sees a properly quoted/escaped string instead of raw text.
            var jsonString = JsonSerializer.Serialize(content, StringSerializerContext.Default.String);
            BinaryData contentJson = BinaryData.FromString(jsonString);

            return await CreateMessageAsync(
                threadId,
                role,
                contentJson,
                attachments,
                metadata,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous variant of <see cref="CreateMessageAsync(string, MessageRole, string, IEnumerable{MessageAttachment}, IReadOnlyDictionary{string, string}, CancellationToken)"/>.
        /// </summary>
        /// <param name="threadId">Identifier of the thread.</param>
        /// <param name="role">
        /// The role of the entity that is creating the message. Allowed values include:
        /// - <c>user</c>: Indicates the message is sent by an actual user.
        /// - <c>assistant</c>: Indicates the message is generated by the agent.
        /// </param>
        /// <param name="content">The plain text content of the message.</param>
        /// <param name="attachments">An optional list of files attached to the message.</param>
        /// <param name="metadata">Optional metadata as key/value pairs.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The newly created <see cref="PersistentThreadMessage"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="threadId"/> or <paramref name="content"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="threadId"/> is empty.</exception>
        public virtual Response<PersistentThreadMessage> CreateMessage(
            string threadId,
            MessageRole role,
            string content,
            IEnumerable<MessageAttachment> attachments = null,
            IReadOnlyDictionary<string, string> metadata = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
            Argument.AssertNotNull(content, nameof(content));

            // Serialize the plain text into JSON so that the underlying generated code
            // sees a properly quoted/escaped string instead of raw text.
            var jsonString = JsonSerializer.Serialize(content, StringSerializerContext.Default.String);
            BinaryData contentJson = BinaryData.FromString(jsonString);

            // Reuse the existing generated method internally by converting the string to BinaryData.
            return CreateMessage(
                threadId,
                role,
                contentJson,
                attachments,
                metadata,
                cancellationToken
            );
        }

        /// <summary>
        /// Creates a new message on a specified thread using a collection of content blocks,
        /// such as text or image references.
        /// </summary>
        /// <param name="threadId">Identifier of the thread.</param>
        /// <param name="role">
        /// The role of the entity creating the message. For instance:
        /// - <c>MessageRole.User</c>: an actual user message
        /// - <c>MessageRole.Agent</c>: an agent-generated response
        /// </param>
        /// <param name="contentBlocks">
        /// A collection of specialized content blocks (e.g. <see cref="MessageInputTextBlock"/>,
        /// <see cref="MessageInputImageUriBlock"/>, <see cref="MessageInputImageFileBlock"/>, etc.).
        /// </param>
        /// <param name="attachments">An optional list of files attached to the message.</param>
        /// <param name="metadata">Optional metadata as key/value pairs.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="PersistentThreadMessage"/> encapsulating the newly created message.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threadId"/> is null or empty, or if <paramref name="contentBlocks"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="threadId"/> is empty.</exception>
        public virtual async Task<Response<PersistentThreadMessage>> CreateMessageAsync(
            string threadId,
            MessageRole role,
            IEnumerable<MessageInputContentBlock> contentBlocks,
            IEnumerable<MessageAttachment> attachments = null,
            IReadOnlyDictionary<string, string> metadata = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
            Argument.AssertNotNull(contentBlocks, nameof(contentBlocks));

            // Convert blocks to a JSON array stored as BinaryData
            BinaryData serializedBlocks = ConvertMessageInputContentBlocksToJson(contentBlocks);

            return await CreateMessageAsync(
                threadId,
                role,
                serializedBlocks,
                attachments,
                metadata,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous variant of <see cref="CreateMessageAsync(string, MessageRole, IEnumerable{MessageInputContentBlock}, IEnumerable{MessageAttachment}, IReadOnlyDictionary{string, string}, CancellationToken)"/>.
        /// Creates a new message using multiple structured content blocks.
        /// </summary>
        /// <param name="threadId">Identifier of the thread.</param>
        /// <param name="role">
        /// The role of the entity creating the message. For instance:
        /// - <c>MessageRole.User</c>: an actual user message
        /// - <c>MessageRole.Agent</c>: an agent-generated response.
        /// </param>
        /// <param name="contentBlocks">
        /// A collection of specialized content blocks (e.g. <see cref="MessageInputTextBlock"/>,
        /// <see cref="MessageInputImageUriBlock"/>, <see cref="MessageInputImageFileBlock"/>, etc.).
        /// </param>
        /// <param name="attachments">An optional list of files attached to the message.</param>
        /// <param name="metadata">Optional metadata as key/value pairs.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="PersistentThreadMessage"/> encapsulating the newly created message.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threadId"/> is null or empty, or if <paramref name="contentBlocks"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="threadId"/> is empty.</exception>
        public virtual Response<PersistentThreadMessage> CreateMessage(
            string threadId,
            MessageRole role,
            IEnumerable<MessageInputContentBlock> contentBlocks,
            IEnumerable<MessageAttachment> attachments = null,
            IReadOnlyDictionary<string, string> metadata = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
            Argument.AssertNotNull(contentBlocks, nameof(contentBlocks));

            // Convert blocks to a JSON array stored as BinaryData
            BinaryData serializedBlocks = ConvertMessageInputContentBlocksToJson(contentBlocks);

            return CreateMessage(
                threadId,
                role,
                serializedBlocks,
                attachments,
                metadata,
                cancellationToken
            );
        }

        private static BinaryData ConvertMessageInputContentBlocksToJson(IEnumerable<MessageInputContentBlock> contentBlocks)
        {
            // Convert blocks to a JSON array stored as BinaryData
            var jsonElements = new List<JsonElement>();
            foreach (MessageInputContentBlock block in contentBlocks)
            {
                // Write the content into a MemoryStream.
                using var memStream = new MemoryStream();

                // Write the RequestContent into the MemoryStream
                block.ToRequestContent().WriteTo(memStream, default);

                // Reset stream position to the beginning
                memStream.Position = 0;

                // Parse to a JsonDocument, then clone the root element so we can reuse it
                using var tempDoc = JsonDocument.Parse(memStream);
                jsonElements.Add(tempDoc.RootElement.Clone());
            }

            // Now serialize the array of JsonElements into a single BinaryData for the request:
            var jsonString = JsonSerializer.Serialize(jsonElements, JsonElementSerializer.Default.ListJsonElement);
            return BinaryData.FromString(jsonString);
        }

        /// <summary> Gets a list of messages that exist on a thread. </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="runId"> Filter messages by the run ID that generated them. </param>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual AsyncPageable<PersistentThreadMessage> GetMessagesAsync(string threadId, string runId = null, int? limit = null, ListSortOrder? order = null, string after = null, string before = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage PageRequest(int? pageSizeHint, string continuationToken) => CreateGetMessagesRequest(
                threadId: threadId,
                runId: runId,
                limit: limit,
                order: order?.ToString(),
                after: continuationToken,
                before: before,
                context: context);
            var asyncPageable = new ContinuationTokenPageableAsync<PersistentThreadMessage>(
                createPageRequest: PageRequest,
                valueFactory: e => PersistentThreadMessage.DeserializePersistentThreadMessage(e),
                pipeline: _pipeline,
                clientDiagnostics: ClientDiagnostics,
                scopeName: "ThreadMessagesClient.GetMessages",
                requestContext: context,
                itemType: ContinuationItemType.ThreadMessage,
                threadId: threadId,
                runId: runId,
                endpoint: _endpoint,
                after: after
            );

            return asyncPageable;
        }

        /// <summary> Gets a list of messages that exist on a thread. </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="runId"> Filter messages by the run ID that generated them. </param>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Pageable<PersistentThreadMessage> GetMessages(string threadId, string runId = null, int? limit = null, ListSortOrder? order = null, string after = null, string before = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage PageRequest(int? pageSizeHint, string continuationToken) => CreateGetMessagesRequest(
                threadId: threadId,
                runId: runId,
                limit: limit,
                order: order?.ToString(),
                after: continuationToken,
                before: before,
                context: context);
            var pageable = new ContinuationTokenPageable<PersistentThreadMessage>(
                createPageRequest: PageRequest,
                valueFactory: e => PersistentThreadMessage.DeserializePersistentThreadMessage(e),
                pipeline: _pipeline,
                clientDiagnostics: ClientDiagnostics,
                scopeName: "ThreadMessagesClient.GetMessages",
                requestContext: context,
                itemType: ContinuationItemType.ThreadMessage,
                threadId: threadId,
                runId: runId,
                endpoint: _endpoint,
                after: after
            );

            return pageable;
        }

        /// <summary>
        /// [Protocol Method] Gets a list of messages that exist on a thread.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetMessagesAsync(string,string,int?,ListSortOrder?,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="runId"> Filter messages by the run ID that generated them. </param>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. Allowed values: "asc" | "desc". </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        internal virtual AsyncPageable<BinaryData> GetMessagesAsync(string threadId, string runId, int? limit, string order, string after, string before, RequestContext context)
        {
            // This method is not yet supported, because it is using generated implementation of parser,
            // which is currently do not support next token.
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMessagesRequest(
                threadId: threadId,
                runId: runId,
                limit: limit,
                order: order,
                after: after,
                before: before,
                context:context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "ThreadMessagesClient.GetMessages", "data", null, context);
        }

        /// <summary>
        /// [Protocol Method] Gets a list of messages that exist on a thread.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetMessages(string,string,int?,ListSortOrder?,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="runId"> Filter messages by the run ID that generated them. </param>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. Allowed values: "asc" | "desc". </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        internal virtual Pageable<BinaryData> GetMessages(string threadId, string runId, int? limit, string order, string after, string before, RequestContext context)
        {
            // This method is not yet supported, because it is using generated implementation of parser,
            // which is currently do not support next token.
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMessagesRequest(
                threadId: threadId,
                runId: runId,
                limit: limit,
                order: order,
                after: after,
                before: before,
                context: context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "ThreadMessagesClient.GetMessages", "data", null, context);
        }

        /// <summary> Deletes a thread message. </summary>
        /// <param name="threadId"> The ID of the thread to delete. </param>
        /// <param name="messageId">The ID of the message to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<bool> DeleteMessage(
            string threadId,
            string messageId,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("PersistentAgentsClient.DeleteThread");
            scope.Start();
            Response<MessageDeletionStatus> baseResponse
                = InternalDeleteMessage(
                    threadId:threadId,
                    messageId: messageId,
                    cancellationToken: cancellationToken);
            bool simplifiedValue =
                baseResponse.GetRawResponse() != null
                && !baseResponse.GetRawResponse().IsError
                && baseResponse.Value != null
                && baseResponse.Value.Deleted;
            return Response.FromValue(simplifiedValue, baseResponse.GetRawResponse());
        }

        /// <summary> Deletes a thread message. </summary>
        /// <param name="threadId"> The ID of the thread to delete. </param>
        /// <param name="messageId">The ID of the message to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<bool>> DeleteMessageAsync(
            string threadId,
            string messageId,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("PersistentAgentsClient.DeleteThread");
            scope.Start();
            Response<MessageDeletionStatus> baseResponse
                = await InternalDeleteMessageAsync(
                    threadId: threadId,
                    messageId: messageId,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            bool simplifiedValue =
                baseResponse.GetRawResponse() != null
                && !baseResponse.GetRawResponse().IsError
                && baseResponse.Value != null
                && baseResponse.Value.Deleted;
            return Response.FromValue(simplifiedValue, baseResponse.GetRawResponse());
        }
    }
}
