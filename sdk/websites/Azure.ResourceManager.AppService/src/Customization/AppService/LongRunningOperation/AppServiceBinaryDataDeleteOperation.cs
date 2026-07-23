// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.AppService
{
    internal static class AppServiceBinaryDataDeleteOperation
    {
        public static async Task<ArmOperation<BinaryData>> DeleteWithLocationAsync(ClientDiagnostics diagnostics, HttpPipeline pipeline, Func<RequestContext, HttpMessage> createMessage, string scopeName, WaitUntil waitUntil, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = diagnostics.CreateScope(scopeName);
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = createMessage(context);
                Response response = await pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                AppServiceArmOperation<BinaryData> operation = new AppServiceArmOperation<BinaryData>(
                    new BinaryDataOperationSource(),
                    diagnostics,
                    pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public static ArmOperation<BinaryData> DeleteWithLocation(ClientDiagnostics diagnostics, HttpPipeline pipeline, Func<RequestContext, HttpMessage> createMessage, string scopeName, WaitUntil waitUntil, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = diagnostics.CreateScope(scopeName);
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = createMessage(context);
                Response response = pipeline.ProcessMessage(message, context);
                AppServiceArmOperation<BinaryData> operation = new AppServiceArmOperation<BinaryData>(
                    new BinaryDataOperationSource(),
                    diagnostics,
                    pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public static async Task<ArmOperation<BinaryData>> DeleteWithOriginalUriAsync(ClientDiagnostics diagnostics, HttpPipeline pipeline, Func<RequestContext, HttpMessage> createMessage, string scopeName, WaitUntil waitUntil, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = diagnostics.CreateScope(scopeName);
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = createMessage(context);
                Response result = await pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<BinaryData> response = Response.FromValue(result.Content, result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                AppServiceArmOperation<BinaryData> operation = new AppServiceArmOperation<BinaryData>(response, rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public static ArmOperation<BinaryData> DeleteWithOriginalUri(ClientDiagnostics diagnostics, HttpPipeline pipeline, Func<RequestContext, HttpMessage> createMessage, string scopeName, WaitUntil waitUntil, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = diagnostics.CreateScope(scopeName);
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = createMessage(context);
                Response result = pipeline.ProcessMessage(message, context);
                Response<BinaryData> response = Response.FromValue(result.Content, result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                AppServiceArmOperation<BinaryData> operation = new AppServiceArmOperation<BinaryData>(response, rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}