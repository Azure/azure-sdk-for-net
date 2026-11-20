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

namespace Azure.Core
{
    internal static class ProtocolOperationHelpers
    {
        /// <summary>
        /// Starts a long-running operation and wraps it with <paramref name="createOperation"/>, which receives a
        /// function returning the latest successful status-monitor response.
        /// </summary>
        public static async ValueTask<TOperation> ProcessMessageWithMonitorAsync<T, TOperation>(
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

        /// <inheritdoc cref="ProcessMessageWithMonitorAsync{T, TOperation}"/>
        public static TOperation ProcessMessageWithMonitor<T, TOperation>(
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

        // Monitor responses are immutable once received, so parse each one at most once instead of on every Id access.
        private static readonly ConditionalWeakTable<Response, ParsedMonitorResponse> s_parsedResponses = new();
        private static readonly ConcurrentDictionary<string, Regex> s_pollingPathPatterns = new();

        /// <summary>
        /// Gets the operation ID selected with <c>@lroOperationId</c>. A string monitor-body property takes precedence;
        /// otherwise the path parameter is extracted from the polling URI when that URI came from the selected link.
        /// Returns <c>NOT_SET</c> when neither is available.
        /// </summary>
        public static string GetOperationId(
            Operation operation, Response? monitorResponse, string[]? propertySegments,
            string? pollingLinkHeader, string? pollingPath, string? pathParameter, string? pathStyle)
        {
            if (propertySegments is not null &&
                GetMonitorProperty(monitorResponse, propertySegments) is { ValueKind: JsonValueKind.String } property)
            {
                return property.GetString() ?? NextLinkOperationImplementation.NotSet;
            }
            if (pollingPath is null || pathParameter is null ||
                GetPollingUri(operation, pollingLinkHeader) is not { } pollingUri)
            {
                return NextLinkOperationImplementation.NotSet;
            }
            var style = NormalizePathStyle(pathStyle);
            var pattern = s_pollingPathPatterns.GetOrAdd($"{style}\n{pathParameter}\n{pollingPath}", _ => CreatePollingPathPattern(pollingPath, pathParameter, style));
            var target = style == "fragment" ? pollingUri.AbsolutePath + pollingUri.Fragment : pollingUri.AbsolutePath;
            var match = pattern.Match(target);
            if (!match.Success || !match.Groups["operationId"].Success)
            {
                return NextLinkOperationImplementation.NotSet;
            }
            return ExpandedValue(match.Groups["operationId"].Value, pathParameter, style) is { } value
                ? Uri.UnescapeDataString(value)
                : NextLinkOperationImplementation.NotSet;
        }

        public static Uri? GetPollingUri(Operation operation, string? pollingLinkHeader)
            => (operation as IPollingUriOperation)?.GetPollingUri(pollingLinkHeader);

        private static JsonElement? GetMonitorProperty(Response? response, string[] propertySegments)
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

        // PollingPath normalizes RFC 6570 operators away (for example `{.id}` and `{;id}` both become `{id}`),
        // so the path parameter's expansion style determines the prefix that precedes the captured value.
        private static string NormalizePathStyle(string? pathStyle)
            => pathStyle?.ToLowerInvariant() switch
            {
                "label" => "label",
                "matrix" => "matrix",
                "fragment" => "fragment",
                "path" => "path",
                _ => "simple"
            };

        private static string StyleCapturePattern(string style, bool allowReserved)
            => style switch
            {
                "label" => @"\.[^/]*",
                "matrix" => ";[^/;]*",
                "path" => "/[^/]*",
                "fragment" => "#.*",
                _ => allowReserved ? ".+?" : "[^/]+"
            };

        private static string? ExpandedValue(string captured, string parameterName, string style)
        {
            switch (style)
            {
                case "label":
                case "path":
                case "fragment":
                    return captured.Substring(1);
                case "matrix":
                    var name = ";" + parameterName;
                    if (!captured.StartsWith(name, StringComparison.Ordinal))
                    {
                        return null;
                    }
                    if (captured.Length == name.Length)
                    {
                        return string.Empty;
                    }
                    return captured[name.Length] == '=' ? captured.Substring(name.Length + 1) : null;
                default:
                    return captured;
            }
        }

        private static Regex CreatePollingPathPattern(string pollingPath, string pathParameter, string style)
        {
            var pattern = new StringBuilder();
            int position = 0;
            foreach (Match parameter in Regex.Matches(pollingPath, @"\{(\+?)([^}]+)\}"))
            {
                pattern.Append(Regex.Escape(pollingPath.Substring(position, parameter.Index - position)));
                var capture = parameter.Groups[2].Value == pathParameter;
                var allowReserved = parameter.Groups[1].Success && parameter.Groups[1].Length > 0;
                pattern.Append(capture ? "(?<operationId>" : "(?:");
                // Only the ID parameter's expansion style is known, so any other placeholder may carry a
                // path-style ("/value"), label (".value"), matrix (";name=value") or simple expansion.
                pattern.Append(capture ? StyleCapturePattern(style, allowReserved) : allowReserved ? ".+?" : "/?[^/]*");
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

        private class ConvertOperation<TFrom, TTo> : Operation<TTo>, IStatusMonitorOperation, IPollingUriOperation
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
            Response? IStatusMonitorOperation.GetStatusMonitorResponse()
                => _operation is IStatusMonitorOperation monitor ? monitor.GetStatusMonitorResponse() : _operation.GetRawResponse();
            Uri? IPollingUriOperation.GetPollingUri(string? pollingLinkHeader) => (_operation as IPollingUriOperation)?.GetPollingUri(pollingLinkHeader);

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

    /// <summary>Exposes the URI a long-running operation polls.</summary>
    internal interface IPollingUriOperation
    {
        /// <summary>Gets the polling URI when it was obtained from <paramref name="pollingLinkHeader"/>, or from the initial request when null.</summary>
        Uri? GetPollingUri(string? pollingLinkHeader);
    }
}
