// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.ApiManagement
{
    internal static class CollectionExistsCompatibility
    {
        internal static async Task<Response<bool>> SendAsync(ClientDiagnostics diagnostics, HttpPipeline pipeline, string scopeName, Func<RequestContext, HttpMessage> createMessage, bool isHead, Func<Response, object> deserialize, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = diagnostics.CreateScope(scopeName);
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = createMessage(context);
                await pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                return ToExistsResponse(message.Response, isHead, deserialize);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal static Response<bool> Send(ClientDiagnostics diagnostics, HttpPipeline pipeline, string scopeName, Func<RequestContext, HttpMessage> createMessage, bool isHead, Func<Response, object> deserialize, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = diagnostics.CreateScope(scopeName);
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = createMessage(context);
                pipeline.Send(message, context.CancellationToken);
                return ToExistsResponse(message.Response, isHead, deserialize);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static Response<bool> ToExistsResponse(Response response, bool isHead, Func<Response, object> deserialize)
        {
            if (response.Status == 404)
            {
                return Response.FromValue(false, response);
            }
            if (isHead && response.Status >= 200 && response.Status < 300)
            {
                return Response.FromValue(true, response);
            }
            if (!isHead && response.Status == 200)
            {
                return Response.FromValue(deserialize(response) != null, response);
            }
            throw new RequestFailedException(response);
        }
    }
}
