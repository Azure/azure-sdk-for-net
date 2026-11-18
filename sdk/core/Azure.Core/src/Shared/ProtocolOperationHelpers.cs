// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using ModelReaderWriter = System.ClientModel.Primitives.ModelReaderWriter;
using ModelReaderWriterOptions = System.ClientModel.Primitives.ModelReaderWriterOptions;

namespace Azure.Core
{
    internal static class ProtocolOperationHelpers
    {
        public static TOperation ConvertWithMetadata<TFrom, TTo, TOperation>(
            Operation<TFrom> operation, Func<Response, TTo> convertFunc,
            ClientDiagnostics diagnostics, string scopeName,
            Func<Operation<TTo>, Func<Response?>, TOperation> createOperation)
            where TFrom : notnull
            where TTo : notnull
            where TOperation : Operation
            => createOperation(
                Convert(operation, convertFunc, diagnostics, scopeName),
                operation is IStatusMonitorOperation monitor
                    ? monitor.GetStatusMonitorResponse
                    : operation.GetRawResponse);

        public static async ValueTask<TOperation> ProcessMessageWithMetadataAsync<T, TOperation>(
            HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics,
            string scopeName, OperationFinalStateVia finalStateVia, RequestContext? requestContext,
            WaitUntil waitUntil, Func<Response, T> resultSelector,
            Func<Operation<T>, Func<Response?>, TOperation> createOperation)
            where T : notnull
            where TOperation : Operation
        {
            var response = await pipeline.ProcessMessageAsync(message, requestContext).ConfigureAwait(false);
            Response? monitorResponse = response;
            var innerOperation = new ProtocolOperation<T>(
                clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName,
                resultSelector, received => monitorResponse = received);
            var operation = createOperation(innerOperation, () => monitorResponse);
            if (waitUntil == WaitUntil.Completed)
            {
                await operation.WaitForCompletionResponseAsync(requestContext?.CancellationToken ?? default).ConfigureAwait(false);
            }
            return operation;
        }

        public static TOperation ProcessMessageWithMetadata<T, TOperation>(
            HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics,
            string scopeName, OperationFinalStateVia finalStateVia, RequestContext? requestContext,
            WaitUntil waitUntil, Func<Response, T> resultSelector,
            Func<Operation<T>, Func<Response?>, TOperation> createOperation)
            where T : notnull
            where TOperation : Operation
        {
            var response = pipeline.ProcessMessage(message, requestContext);
            Response? monitorResponse = response;
            var innerOperation = new ProtocolOperation<T>(
                clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName,
                resultSelector, received => monitorResponse = received);
            var operation = createOperation(innerOperation, () => monitorResponse);
            if (waitUntil == WaitUntil.Completed)
            {
                operation.WaitForCompletionResponse(requestContext?.CancellationToken ?? default);
            }
            return operation;
        }

        public static TOperation RehydrateWithMetadata<T, TOperation>(
            HttpPipeline pipeline, RehydrationToken rehydrationToken, ClientOptions? options,
            string scopeName, Func<Response, T> resultSelector,
            Func<Operation<T>, Func<Response?>, TOperation> createOperation)
            where T : notnull
            where TOperation : Operation
        {
            Response? monitorResponse = null;
            var innerOperation = new ProtocolOperation<T>(
                new ClientDiagnostics(options ?? ClientOptions.Default), pipeline, rehydrationToken, scopeName,
                resultSelector, received => monitorResponse = received);
            return createOperation(innerOperation, () => monitorResponse);
        }

        // Monitor responses are immutable once received, so parse each one at most once and share the
        // result across all metadata and operation ID getters instead of reparsing on every access.
        private static readonly ConditionalWeakTable<Response, ParsedMonitorResponse> s_parsedResponses = new();
        private static readonly ConcurrentDictionary<string, Regex> s_pollingPathPatterns = new();

        public static JsonElement? GetStatusMetadata(Response? response, params string[] propertySegments)
        {
            if (response is null || GetParsedResponse(response).Root is not { } root)
            {
                return null;
            }

            var element = root;
            foreach (var segment in propertySegments)
            {
                if (element.ValueKind != JsonValueKind.Object || !element.TryGetProperty(segment, out element))
                {
                    return null;
                }
            }
            return element.ValueKind is JsonValueKind.Null ? null : element;
        }

        public static string GetOperationId(
            RehydrationToken? rehydrationToken, Response? monitorResponse,
            string? pollingPath, string? pathParameter, string[]? propertySegments)
        {
            if (monitorResponse is null)
            {
                return ComputeOperationId(rehydrationToken, null, pollingPath, pathParameter, propertySegments);
            }

            // The rehydration token only changes when a poll produces a new monitor response, so the derived
            // ID can be cached per response rather than reserializing the token and matching the URI per access.
            var parsed = GetParsedResponse(monitorResponse);
            var id = parsed.OperationId;
            if (id is null)
            {
                id = ComputeOperationId(rehydrationToken, monitorResponse, pollingPath, pathParameter, propertySegments);
                parsed.OperationId = id;
            }
            return id;
        }

        private static ParsedMonitorResponse GetParsedResponse(Response response)
            => s_parsedResponses.GetValue(response, static r => new ParsedMonitorResponse(Parse(r)));

        private static JsonElement? Parse(Response response)
        {
            if (response.Content is not { } content || content.ToMemory().IsEmpty)
            {
                return null;
            }

            try
            {
                using var document = JsonDocument.Parse(content);
                return document.RootElement.Clone();
            }
            catch (JsonException)
            {
                return null;
            }
        }

        private static string ComputeOperationId(
            RehydrationToken? rehydrationToken, Response? monitorResponse,
            string? pollingPath, string? pathParameter, string[]? propertySegments)
        {
            if (propertySegments is not null &&
                GetStatusMetadata(monitorResponse, propertySegments) is { ValueKind: JsonValueKind.String } property)
            {
                return property.GetString() ?? NextLinkOperationImplementation.NotSet;
            }
            if (rehydrationToken is null || pollingPath is null || pathParameter is null)
            {
                return NextLinkOperationImplementation.NotSet;
            }

            var data = ModelReaderWriter.Write(rehydrationToken.Value, ModelReaderWriterOptions.Json, AzureCoreContext.Default);
            using var document = JsonDocument.Parse(data);
            var nextUri = document.RootElement.GetProperty("nextRequestUri").GetString();
            var initialUri = document.RootElement.GetProperty("initialUri").GetString();
            var pollingUri = new Uri(new Uri(initialUri!), nextUri);
            string path = pollingPath;
            string parameterName = pathParameter;
            var pattern = s_pollingPathPatterns.GetOrAdd($"{parameterName}\n{path}", _ => CreatePollingPathPattern(path, parameterName));
            var match = pattern.Match(pollingUri.AbsolutePath);
            return match.Success && match.Groups["operationId"].Success
                ? Uri.UnescapeDataString(match.Groups["operationId"].Value)
                : NextLinkOperationImplementation.NotSet;
        }

        private static Regex CreatePollingPathPattern(string pollingPath, string pathParameter)
        {
            var pattern = new StringBuilder();
            int position = 0;
            foreach (Match parameter in Regex.Matches(pollingPath, @"\{(\+?)([^}]+)\}"))
            {
                pattern.Append(Regex.Escape(pollingPath.Substring(position, parameter.Index - position)));
                var capture = parameter.Groups[2].Value == pathParameter;
                pattern.Append(capture ? "(?<operationId>" : "(?:");
                pattern.Append(parameter.Groups[1].Success && parameter.Groups[1].Length > 0 ? ".+?" : "[^/]+");
                pattern.Append(')');
                position = parameter.Index + parameter.Length;
            }
            pattern.Append(Regex.Escape(pollingPath.Substring(position)));
            pattern.Append('$');
            return new Regex(pattern.ToString(), RegexOptions.CultureInvariant);
        }

        private sealed class ParsedMonitorResponse
        {
            public ParsedMonitorResponse(JsonElement? root) => Root = root;
            public JsonElement? Root { get; }
            public string? OperationId { get; set; }
        }

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

        private class ConvertOperation<TFrom, TTo> : Operation<TTo>
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

    internal interface IStatusMonitorOperation
    {
        Response? GetStatusMonitorResponse();
    }
}
