// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

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
                using HttpMessage message = CreateSendToAllRequest(content, contentType, excluded, null, context);
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
                using HttpMessage message = CreateSendToAllRequest(content, contentType, excluded, null, context);
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
                using HttpMessage message = CreateSendToGroupRequest(group, content, contentType, excluded, null, context);
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
                using HttpMessage message = CreateSendToGroupRequest(group, content, contentType, excluded, null, context);
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
                using HttpMessage message = CreateSendToUserRequest(userId, content, contentType, null, context);
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
                using HttpMessage message = CreateSendToUserRequest(userId, content, contentType, null, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
