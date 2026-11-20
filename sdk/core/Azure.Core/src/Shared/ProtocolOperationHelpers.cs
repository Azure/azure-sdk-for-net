// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal static class ProtocolOperationHelpers
    {
        /// <summary>
        /// Gets the latest status-monitor response of <paramref name="operation"/>, or its raw response when the operation does not track one.
        /// </summary>
        public static Response? GetStatusMonitorResponse(Operation operation)
            => operation is IStatusMonitorOperation monitor ? monitor.GetStatusMonitorResponse() : operation.GetRawResponse();

        public static TOperation WrapWithMetadata<TOperation>(Operation operation, Func<Operation, Func<Response?>, TOperation> createOperation)
            where TOperation : Operation
            => createOperation(operation, () => GetStatusMonitorResponse(operation));

        public static TOperation ConvertWithMetadata<TFrom, TTo, TOperation>(Operation<TFrom> operation, Func<Response, TTo> convertFunc, ClientDiagnostics diagnostics, string scopeName,
            Func<Operation<TTo>, Func<Response?>, TOperation> createOperation)
            where TFrom : notnull
            where TTo : notnull
            where TOperation : Operation
            => createOperation(Convert(operation, convertFunc, diagnostics, scopeName), () => GetStatusMonitorResponse(operation));

        public static Operation<TTo> Convert<TFrom, TTo>(Operation<TFrom> operation, Func<Response, TTo> convertFunc, ClientDiagnostics diagnostics, string scopeName)
            where TFrom : notnull
            where TTo : notnull
            => new ConvertOperation<TFrom, TTo>(operation, diagnostics, scopeName, convertFunc);

        public static ValueTask<Operation<VoidValue>> ProcessMessageWithoutResponseValueAsync(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, RequestContext? requestContext, WaitUntil waitUntil)
            => ProcessMessageAsync(pipeline, message, clientDiagnostics, scopeName, finalStateVia, requestContext, waitUntil, _ => new VoidValue());

        public static Operation<VoidValue> ProcessMessageWithoutResponseValue(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, RequestContext? requestContext, WaitUntil waitUntil)
            => ProcessMessage(pipeline, message, clientDiagnostics, scopeName, finalStateVia, requestContext, waitUntil, _ => new VoidValue());

        public static ValueTask<Operation<BinaryData>> ProcessMessageAsync(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, RequestContext? requestContext, WaitUntil waitUntil)
            => ProcessMessageAsync(pipeline, message, clientDiagnostics, scopeName, finalStateVia, requestContext, waitUntil, r => r.Content);

        public static Operation<BinaryData> ProcessMessage(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, RequestContext? requestContext, WaitUntil waitUntil)
            => ProcessMessage(pipeline, message, clientDiagnostics, scopeName, finalStateVia, requestContext, waitUntil, r => r.Content);

        public static async ValueTask<Operation<T>> ProcessMessageAsync<T>(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, RequestContext? requestContext, WaitUntil waitUntil, Func<Response, T> resultSelector) where T : notnull
        {
            var response = await pipeline.ProcessMessageAsync(message, requestContext).ConfigureAwait(false);
            var operation = new ProtocolOperation<T>(clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName, resultSelector);
            if (waitUntil == WaitUntil.Completed)
            {
                await operation.WaitForCompletionAsync(requestContext?.CancellationToken ?? default).ConfigureAwait(false);
            }
            return operation;
        }

        public static Operation<T> ProcessMessage<T>(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, RequestContext? requestContext, WaitUntil waitUntil, Func<Response, T> resultSelector) where T : notnull
        {
            var response = pipeline.ProcessMessage(message, requestContext);
            var operation = new ProtocolOperation<T>(clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName, resultSelector);
            if (waitUntil == WaitUntil.Completed)
            {
                operation.WaitForCompletion(requestContext?.CancellationToken ?? default);
            }
            return operation;
        }

        private class ConvertOperation<TFrom, TTo> : Operation<TTo>, IStatusMonitorOperation
            where TFrom : notnull
            where TTo : notnull
        {
            private readonly Operation<TFrom> _operation;
            private readonly ClientDiagnostics _diagnostics;
            private readonly string _waitForCompletionScopeName;
            private readonly string _updateStatusScopeName;
            private readonly Func<Response, TTo> _convertFunc;
            private Response<TTo>? _response;

            public ConvertOperation(Operation<TFrom> operation, ClientDiagnostics diagnostics, string operationName, Func<Response, TTo> convertFunc)
            {
                _operation = operation;
                _diagnostics = diagnostics;
                _waitForCompletionScopeName = $"{operationName}.{nameof(WaitForCompletion)}";
                _updateStatusScopeName = $"{operationName}.{nameof(UpdateStatus)}";
                _convertFunc = convertFunc;
                _response = null;
            }

            public override string Id => _operation.Id;
            public override TTo Value => GetOrCreateValue();
            public override bool HasValue => _operation.HasValue;
            public override bool HasCompleted => _operation.HasCompleted;
            public override RehydrationToken? GetRehydrationToken() => _operation.GetRehydrationToken();
            public override Response GetRawResponse() => _operation.GetRawResponse();
            Response? IStatusMonitorOperation.GetStatusMonitorResponse() => GetStatusMonitorResponse(_operation);

            public override Response UpdateStatus(CancellationToken cancellationToken = default)
            {
                if (HasCompleted)
                {
                    return GetRawResponse();
                }

                using var scope = CreateScope(_updateStatusScopeName);
                try
                {
                    return _operation.UpdateStatus(cancellationToken);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
            {
                if (HasCompleted)
                {
                    return GetRawResponse();
                }

                using var scope = CreateScope(_updateStatusScopeName);
                try
                {
                    return await _operation.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            public override Response<TTo> WaitForCompletion(CancellationToken cancellationToken = default)
            {
                if (_response != null)
                {
                    return _response;
                }

                using var scope = CreateScope(_waitForCompletionScopeName);
                try
                {
                    var result = _operation.WaitForCompletion(cancellationToken);
                    return CreateResponseOfTTo(result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            public override Response<TTo> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken)
            {
                if (_response != null)
                {
                    return _response;
                }

                using var scope = CreateScope(_waitForCompletionScopeName);
                try
                {
                    var result = _operation.WaitForCompletion(pollingInterval, cancellationToken);
                    return CreateResponseOfTTo(result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            public override async ValueTask<Response<TTo>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
            {
                if (_response != null)
                {
                    return _response;
                }

                using var scope = CreateScope(_waitForCompletionScopeName);
                try
                {
                    var result = await _operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                    return CreateResponseOfTTo(result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            public override async ValueTask<Response<TTo>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
            {
                if (_response != null)
                {
                    return _response;
                }

                using var scope = CreateScope(_waitForCompletionScopeName);
                try
                {
                    var result = await _operation.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
                    return CreateResponseOfTTo(result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            private TTo GetOrCreateValue()
                => _response != null ? _response.Value : CreateResponseOfTTo(GetRawResponse()).Value;

            private Response<TTo> CreateResponseOfTTo(Response<TFrom> responseTFrom)
                => CreateResponseOfTTo(responseTFrom.GetRawResponse());

            private Response<TTo> CreateResponseOfTTo(Response rawResponse)
            {
                var value = _convertFunc(rawResponse);
                var response = Response.FromValue(value, rawResponse);
                Interlocked.CompareExchange(ref _response, response, null);
                return _response;
            }

            private DiagnosticScope CreateScope(string name)
            {
                var scope = _diagnostics.CreateScope(name);
                scope.Start();
                return scope;
            }
        }
    }

    /// <summary>Exposes the latest successful status-monitor response of a long-running operation.</summary>
    internal interface IStatusMonitorOperation
    {
        Response? GetStatusMonitorResponse();
    }
}
