// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Messaging.WebPubSub
{
    public partial class WebPubSubServiceClient
    {
        /// <summary> Broadcast content inside request body to all the connected client connections. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="contentType"> Upload file type. Allowed values: &quot;application/json&quot; | &quot;application/octet-stream&quot; | &quot;text/plain&quot;. </param>
        /// <param name="excluded"> Excluded connection Ids. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> SendToAllAsync(RequestContent content, ContentType contentType, IEnumerable<string> excluded, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("WebPubSubServiceClient.SendToAll");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendToAllRequest(content, contentType, excluded, null, default, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Broadcast content inside request body to all the connected client connections. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="contentType"> Upload file type. Allowed values: &quot;application/json&quot; | &quot;application/octet-stream&quot; | &quot;text/plain&quot;. </param>
        /// <param name="excluded"> Excluded connection Ids. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response SendToAll(RequestContent content, ContentType contentType, IEnumerable<string> excluded, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("WebPubSubServiceClient.SendToAll");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendToAllRequest(content, contentType, excluded, null, default, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send content inside request body to a group of connections. </summary>
        /// <param name="group"> Target group name, which length should be greater than 0 and less than 1025. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="contentType"> Upload file type. Allowed values: &quot;application/json&quot; | &quot;application/octet-stream&quot; | &quot;text/plain&quot;. </param>
        /// <param name="excluded"> Excluded connection Ids. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="group"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="group"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> SendToGroupAsync(string group, RequestContent content, ContentType contentType, IEnumerable<string> excluded, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("WebPubSubServiceClient.SendToGroup");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendToGroupRequest(group, content, contentType, excluded, null, default, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send content inside request body to a group of connections. </summary>
        /// <param name="group"> Target group name, which length should be greater than 0 and less than 1025. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="contentType"> Upload file type. Allowed values: &quot;application/json&quot; | &quot;application/octet-stream&quot; | &quot;text/plain&quot;. </param>
        /// <param name="excluded"> Excluded connection Ids. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="group"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="group"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response SendToGroup(string group, RequestContent content, ContentType contentType, IEnumerable<string> excluded, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("WebPubSubServiceClient.SendToGroup");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendToGroupRequest(group, content, contentType, excluded, null, default, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send content inside request body to the specific user. </summary>
        /// <param name="userId"> The user Id. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="contentType"> Upload file type. Allowed values: &quot;application/json&quot; | &quot;application/octet-stream&quot; | &quot;text/plain&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="userId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> SendToUserAsync(string userId, RequestContent content, ContentType contentType, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("WebPubSubServiceClient.SendToUser");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendToUserRequest(userId, content, contentType, null, default, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send content inside request body to the specific user. </summary>
        /// <param name="userId"> The user Id. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="contentType"> Upload file type. Allowed values: &quot;application/json&quot; | &quot;application/octet-stream&quot; | &quot;text/plain&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="userId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response SendToUser(string userId, RequestContent content, ContentType contentType, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("WebPubSubServiceClient.SendToUser");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendToUserRequest(userId, content, contentType, null, default, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #region The overloads here are to avoid breaking change after new parameters are added to the generated methods.

        /// <summary>
        /// [Protocol Method] Broadcast content inside request body to all the connected client connections.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: "application/json" | "application/octet-stream" | "text/plain". </param>
        /// <param name="excluded"> Excluded connection Ids. </param>
        /// <param name="filter"> Following OData filter syntax to filter out the subscribers receiving the messages. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Task<Response> SendToAllAsync(RequestContent content, ContentType contentType, IEnumerable<string> excluded, string filter, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            return SendToAllAsync(content, contentType, excluded, filter, messageTtlSeconds: null, context);
        }

        /// <summary>
        /// [Protocol Method] Broadcast content inside request body to all the connected client connections.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: "application/json" | "application/octet-stream" | "text/plain". </param>
        /// <param name="excluded"> Excluded connection Ids. </param>
        /// <param name="filter"> Following OData filter syntax to filter out the subscribers receiving the messages. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response SendToAll(RequestContent content, ContentType contentType, IEnumerable<string> excluded, string filter, RequestContext context)
        {
            Argument.AssertNotNull(content, nameof(content));

            return SendToAll(content, contentType, excluded, filter, messageTtlSeconds: null, context);
        }

        /// <summary>
        /// [Protocol Method] Send content inside request body to the specific user.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="userId"> The user Id. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: "application/json" | "application/octet-stream" | "text/plain". </param>
        /// <param name="filter"> Following OData filter syntax to filter out the subscribers receiving the messages. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="userId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Task<Response> SendToUserAsync(string userId, RequestContent content, ContentType contentType, string filter, RequestContext context)
        {
            return SendToUserAsync(userId, content, contentType, filter, messageTtlSeconds: null, context);
        }

        /// <summary>
        /// [Protocol Method] Send content inside request body to the specific user.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="userId"> The user Id. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: "application/json" | "application/octet-stream" | "text/plain". </param>
        /// <param name="filter"> Following OData filter syntax to filter out the subscribers receiving the messages. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="userId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response SendToUser(string userId, RequestContent content, ContentType contentType, string filter, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(userId, nameof(userId));
            Argument.AssertNotNull(content, nameof(content));

            return SendToUser(userId, content, contentType, filter, messageTtlSeconds: default, context);
        }

        /// <summary>
        /// [Protocol Method] Send content inside request body to the specific connection.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="connectionId"> The connection Id. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: "application/json" | "application/octet-stream" | "text/plain". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Task<Response> SendToConnectionAsync(string connectionId, RequestContent content, ContentType contentType, RequestContext context)
        {
            return SendToConnectionAsync(connectionId, content, contentType, messageTtlSeconds: null, context);
        }

        /// <summary>
        /// [Protocol Method] Send content inside request body to the specific connection.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="connectionId"> The connection Id. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: "application/json" | "application/octet-stream" | "text/plain". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response SendToConnection(string connectionId, RequestContent content, ContentType contentType, RequestContext context)
        {
            return SendToConnection(connectionId, content, contentType, messageTtlSeconds: null, context);
        }

        /// <summary>
        /// [Protocol Method] Send content inside request body to a group of connections.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="group"> Target group name, which length should be greater than 0 and less than 1025. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: "application/json" | "application/octet-stream" | "text/plain". </param>
        /// <param name="excluded"> Excluded connection Ids. </param>
        /// <param name="filter"> Following OData filter syntax to filter out the subscribers receiving the messages. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="group"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="group"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Task<Response> SendToGroupAsync(string group, RequestContent content, ContentType contentType, IEnumerable<string> excluded, string filter, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(group, nameof(group));
            Argument.AssertNotNull(content, nameof(content));

            return SendToGroupAsync(group, content, contentType, excluded, filter, messageTtlSeconds: null, context);
        }

        /// <summary>
        /// [Protocol Method] Send content inside request body to a group of connections.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="group"> Target group name, which length should be greater than 0 and less than 1025. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: "application/json" | "application/octet-stream" | "text/plain". </param>
        /// <param name="excluded"> Excluded connection Ids. </param>
        /// <param name="filter"> Following OData filter syntax to filter out the subscribers receiving the messages. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="group"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="group"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response SendToGroup(string group, RequestContent content, ContentType contentType, IEnumerable<string> excluded, string filter, RequestContext context = null)
        {
            return SendToGroup(group, content, contentType, excluded, filter, messageTtlSeconds: default, context);
        }

        #endregion
    }
}
