// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class NextLinkOperationImplementation : IOperation
    {
        internal const string NotSet = "NOT_SET";
        internal const string RehydrationTokenVersion = "1.0.0";
        private const string ApiVersionParam = "api-version";
        private static readonly string[] FailureStates = { "failed", "canceled" };
        private static readonly string[] SuccessStates = { "succeeded" };

        private readonly HeaderSource _headerSource;
        private readonly Uri _startRequestUri;
        private readonly OperationFinalStateVia _finalStateVia;
        private readonly HttpPipeline _pipeline;
        private readonly string? _apiVersion;

        private string? _lastKnownLocation;
        private string _nextRequestUri;

        // We can only get OperationId when
        // - The operation is still in progress and nextRequestUri contains it
        // - During rehydration, rehydrationToken.Id is the operation id
        public string OperationId { get; private set; } = NotSet;
        public RequestMethod RequestMethod { get; }

        public static IOperation Create(
            HttpPipeline pipeline,
            RequestMethod requestMethod,
            Uri startRequestUri,
            Response response,
            OperationFinalStateVia finalStateVia,
            bool skipApiVersionOverride = false,
            string? apiVersionOverrideValue = null)
        {
            string? apiVersionStr = null;
            if (apiVersionOverrideValue is not null)
            {
                apiVersionStr = apiVersionOverrideValue;
            }
            else
            {
                apiVersionStr = !skipApiVersionOverride && TryGetApiVersion(startRequestUri, out ReadOnlySpan<char> apiVersion) ? apiVersion.ToString() : null;
            }
            var headerSource = GetHeaderSource(requestMethod, startRequestUri, response, apiVersionStr, out string nextRequestUri, out bool isNextRequestPolling);

            string? lastKnownLocation;
            if (!response.Headers.TryGetValue("Location", out lastKnownLocation))
            {
                lastKnownLocation = null;
            }

            NextLinkOperationImplementation operation = new(pipeline, requestMethod, startRequestUri, nextRequestUri, headerSource, lastKnownLocation, finalStateVia, apiVersionStr, isNextRequestPolling: isNextRequestPolling);

            if (headerSource == HeaderSource.None && IsFinalState(response, headerSource, out var failureState, out _))
            {
                return new CompletedOperation(failureState ?? GetOperationStateFromFinalResponse(requestMethod, response), operation);
            }

            return operation;
        }

        public static IOperation<T> Create<T>(
            IOperationSource<T> operationSource,
            HttpPipeline pipeline,
            RequestMethod requestMethod,
            Uri startRequestUri,
            Response response,
            OperationFinalStateVia finalStateVia,
            bool skipApiVersionOverride = false,
            string? apiVersionOverrideValue = null)
        {
            var operation = Create(pipeline, requestMethod, startRequestUri, response, finalStateVia, skipApiVersionOverride, apiVersionOverrideValue);
            return new OperationToOperationOfT<T>(operationSource, operation);
        }

        public static IOperation<T> Create<T>(
            IOperationSource<T> operationSource,
            IOperation operation)
            => new OperationToOperationOfT<T>(operationSource, operation);

        public static IOperation Create(
            HttpPipeline pipeline,
            RehydrationToken rehydrationToken)
        {
            AssertNotNull(rehydrationToken, nameof(rehydrationToken));
            AssertNotNull(pipeline, nameof(pipeline));

            // TODO: Once we remove NextLinkOperationImplementation from internal shared and make it internal to Azure.Core only in https://github.com/Azure/azure-sdk-for-net/issues/43260
            // We can access the internal members from RehydrationToken directly
            var data = ModelReaderWriter.Write(rehydrationToken!, ModelReaderWriterOptions.Json, AzureCoreContext.Default);
            using var document = JsonDocument.Parse(data);
            var lroDetails = document.RootElement;

            // We are sure that the following properties exists in the serialized rehydrationToken
            var initialUri = lroDetails.GetProperty("initialUri").GetString();
            if (!Uri.TryCreate(initialUri, UriKind.Absolute, out var startRequestUri))
            {
                throw new ArgumentException($"\"initialUri\" property on \"rehydrationToken\" is an invalid Uri", nameof(rehydrationToken));
            }

            // We are sure that the following properties(apart from nullable lastKnownLocation) are not null as they are required in the rehydrationToken
            string nextRequestUri = lroDetails.GetProperty("nextRequestUri").GetString()!;
            string requestMethodStr = lroDetails.GetProperty("requestMethod").GetString()!;
            RequestMethod requestMethod = new RequestMethod(requestMethodStr)!;
            string? lastKnownLocation = lroDetails.GetProperty("lastKnownLocation").GetString();

            string finalStateViaStr = lroDetails.GetProperty("finalStateVia").GetString()!;
            OperationFinalStateVia finalStateVia;
            if (Enum.IsDefined(typeof(OperationFinalStateVia), finalStateViaStr))
            {
                finalStateVia = (OperationFinalStateVia)Enum.Parse(typeof(OperationFinalStateVia), finalStateViaStr);
            }
            else
            {
                finalStateVia = OperationFinalStateVia.Location;
            }

            string headerSourceStr = lroDetails.GetProperty("headerSource").GetString()!;
            HeaderSource headerSource;
            if (Enum.IsDefined(typeof(HeaderSource), headerSourceStr))
            {
                headerSource = (HeaderSource)Enum.Parse(typeof(HeaderSource), headerSourceStr);
            }
            else
            {
                headerSource = HeaderSource.None;
            }

            return new NextLinkOperationImplementation(pipeline, requestMethod, startRequestUri, nextRequestUri, headerSource, lastKnownLocation, finalStateVia, null, rehydrationToken.Id);
        }

        private NextLinkOperationImplementation(
            HttpPipeline pipeline,
            RequestMethod requestMethod,
            Uri startRequestUri,
            string nextRequestUri,
            HeaderSource headerSource,
            string? lastKnownLocation,
            OperationFinalStateVia finalStateVia,
            string? apiVersion,
            string? operationId = null,
            bool isNextRequestPolling = false)
        {
            AssertNotNull(pipeline, nameof(pipeline));
            AssertNotNull(requestMethod, nameof(requestMethod));
            AssertNotNull(startRequestUri, nameof(startRequestUri));
            AssertNotNull(nextRequestUri, nameof(nextRequestUri));
            AssertNotNull(headerSource, nameof(headerSource));
            AssertNotNull(finalStateVia, nameof(finalStateVia));

            RequestMethod = requestMethod;
            _headerSource = headerSource;
            _startRequestUri = startRequestUri;
            _nextRequestUri = nextRequestUri;
            _lastKnownLocation = lastKnownLocation;
            _finalStateVia = finalStateVia;
            _pipeline = pipeline;
            _apiVersion = apiVersion;
            if (operationId is not null)
            {
                OperationId = operationId;
            }
            else if (isNextRequestPolling)
            {
                OperationId = ParseOperationId(startRequestUri, nextRequestUri);
            }
        }

        private static string ParseOperationId(Uri startRequestUri, string nextRequestUri)
        {
            if (Uri.TryCreate(nextRequestUri, UriKind.Absolute, out var nextLink) && nextLink.Scheme != "file")
            {
                return nextLink.Segments.Last();
            }
            else
            {
                return new Uri(startRequestUri, nextRequestUri).Segments.Last();
            }
        }

        public RehydrationToken GetRehydrationToken()
            => GetRehydrationToken(RequestMethod, _startRequestUri, _nextRequestUri, _headerSource.ToString(), _lastKnownLocation, _finalStateVia.ToString(), OperationId);

        public static RehydrationToken GetRehydrationToken(
            RequestMethod requestMethod,
            Uri startRequestUri,
            Response response,
            OperationFinalStateVia finalStateVia)
        {
            AssertNotNull(requestMethod, nameof(requestMethod));
            AssertNotNull(startRequestUri, nameof(startRequestUri));
            AssertNotNull(response, nameof(response));
            AssertNotNull(finalStateVia, nameof(finalStateVia));

            var headerSource = GetHeaderSource(requestMethod, startRequestUri, response, null, out string nextRequestUri, out bool isNextRequestPolling);
            string? lastKnownLocation;
            if (!response.Headers.TryGetValue("Location", out lastKnownLocation))
            {
                lastKnownLocation = null;
            }
            return GetRehydrationToken(requestMethod, startRequestUri, nextRequestUri, headerSource.ToString(), lastKnownLocation, finalStateVia.ToString(), isNextRequestPolling ? ParseOperationId(startRequestUri, nextRequestUri) : null);
        }

        public static RehydrationToken GetRehydrationToken(
            RequestMethod requestMethod,
            Uri startRequestUri,
            string nextRequestUri,
            string headerSource,
            string? lastKnownLocation,
            string finalStateVia,
            string? operationId = null)
        {
            // TODO: Once we remove NextLinkOperationImplementation from internal shared and make it internal to Azure.Core only in https://github.com/Azure/azure-sdk-for-net/issues/43260
            // We can access the internal members from RehydrationToken directly
            var json = $$"""
            {"version":"{{RehydrationTokenVersion}}","id":{{ConstructStringValue(operationId)}},"requestMethod":"{{requestMethod}}","initialUri":"{{startRequestUri.AbsoluteUri}}","nextRequestUri":"{{nextRequestUri}}","headerSource":"{{headerSource}}","finalStateVia":"{{finalStateVia}}","lastKnownLocation":{{ConstructStringValue(lastKnownLocation)}}}
            """;
            var data = new BinaryData(json);
            return ModelReaderWriter.Read<RehydrationToken>(data, ModelReaderWriterOptions.Json, AzureCoreContext.Default);
        }

        private static string? ConstructStringValue(string? value) => value is null ? "null" : $"\"{value}\"";

        public async ValueTask<OperationState> UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            Response response = async
                ? await GetResponseAsync(_nextRequestUri, cancellationToken).ConfigureAwait(false)
                : GetResponse(_nextRequestUri, cancellationToken);

            var hasCompleted = IsFinalState(response, _headerSource, out var failureState, out var resourceLocation);
            if (failureState != null)
            {
                return failureState.Value;
            }

            if (hasCompleted)
            {
                string? finalUri = GetFinalUri(resourceLocation);
                Response finalResponse;
                if (finalUri != null)
                {
                    finalResponse = async
                        ? await GetResponseAsync(finalUri, cancellationToken).ConfigureAwait(false)
                        : GetResponse(finalUri, cancellationToken);
                }
                else
                {
                    finalResponse = response;
                }
                return GetOperationStateFromFinalResponse(RequestMethod, finalResponse);
            }

            UpdateNextRequestUri(response.Headers);
            return OperationState.Pending(response);
        }

        private static OperationState GetOperationStateFromFinalResponse(RequestMethod requestMethod, Response response)
        {
            switch (response.Status)
            {
                case 200:
                case 201 when requestMethod == RequestMethod.Put:
                case 204 when requestMethod != RequestMethod.Put && requestMethod != RequestMethod.Patch:
                    return OperationState.Success(response);
                default:
                    return OperationState.Failure(response);
            }
        }

        private void UpdateNextRequestUri(ResponseHeaders headers)
        {
            var hasLocation = headers.TryGetValue("Location", out string? location);
            if (hasLocation)
            {
                _lastKnownLocation = location;
            }

            switch (_headerSource)
            {
                case HeaderSource.OperationLocation when headers.TryGetValue("Operation-Location", out string? operationLocation):
                    _nextRequestUri = AppendOrReplaceApiVersion(operationLocation, _apiVersion);
                    OperationId = ParseOperationId(_startRequestUri, _nextRequestUri);
                    return;
                case HeaderSource.AzureAsyncOperation when headers.TryGetValue("Azure-AsyncOperation", out string? azureAsyncOperation):
                    _nextRequestUri = AppendOrReplaceApiVersion(azureAsyncOperation, _apiVersion);
                    OperationId = ParseOperationId(_startRequestUri, _nextRequestUri);
                    return;
                case HeaderSource.Location when hasLocation:
                    _nextRequestUri = AppendOrReplaceApiVersion(location!, _apiVersion);
                    OperationId = ParseOperationId(_startRequestUri, _nextRequestUri);
                    return;
            }
        }

        internal static string AppendOrReplaceApiVersion(string uri, string? apiVersion)
        {
            if (!string.IsNullOrEmpty(apiVersion))
            {
                var uriSpan = uri.AsSpan();
                var apiVersionParamSpan = ApiVersionParam.AsSpan();
                var apiVersionIndex = uriSpan.IndexOf(apiVersionParamSpan);
                if (apiVersionIndex == -1)
                {
                    var concatSymbol = uriSpan.IndexOf('?') > -1 ? "&" : "?";
                    return $"{uri}{concatSymbol}api-version={apiVersion}";
                }
                else
                {
                    var lengthToEndOfApiVersionParam = apiVersionIndex + ApiVersionParam.Length;
                    ReadOnlySpan<char> remaining = uriSpan.Slice(lengthToEndOfApiVersionParam);
                    bool apiVersionHasEqualSign = false;
                    if (remaining.IndexOf('=') == 0)
                    {
                        remaining = remaining.Slice(1);
                        lengthToEndOfApiVersionParam += 1;
                        apiVersionHasEqualSign = true;
                    }
                    var indexOfFirstSignAfterApiVersion = remaining.IndexOf('&');
                    ReadOnlySpan<char> uriBeforeApiVersion = uriSpan.Slice(0, lengthToEndOfApiVersionParam);
                    if (indexOfFirstSignAfterApiVersion == -1)
                    {
                        return string.Concat(uriBeforeApiVersion.ToString(), apiVersionHasEqualSign ? string.Empty : "=", apiVersion);
                    }
                    else
                    {
                        ReadOnlySpan<char> uriAfterApiVersion = uriSpan.Slice(indexOfFirstSignAfterApiVersion + lengthToEndOfApiVersionParam);
                        return string.Concat(uriBeforeApiVersion.ToString(), apiVersionHasEqualSign ? string.Empty : "=", apiVersion, uriAfterApiVersion.ToString());
                    }
                }
            }
            return uri;
        }

        internal static bool TryGetApiVersion(Uri startRequestUri, out ReadOnlySpan<char> apiVersion)
        {
            apiVersion = default;
            ReadOnlySpan<char> uriSpan = startRequestUri.Query.AsSpan();
            int startIndex = uriSpan.IndexOf(ApiVersionParam.AsSpan());
            if (startIndex == -1)
            {
                return false;
            }
            startIndex += ApiVersionParam.Length;
            ReadOnlySpan<char> remaining = uriSpan.Slice(startIndex);
            if (remaining.IndexOf('=') == 0)
            {
                remaining = remaining.Slice(1);
                startIndex += 1;
            }
            else
            {
                return false;
            }
            int endIndex = remaining.IndexOf('&');
            int length = endIndex == -1 ? uriSpan.Length - startIndex : endIndex;
            apiVersion = uriSpan.Slice(startIndex, length);
            return true;
        }

        /// <summary>
        /// This function is used to get the final request uri after the lro has completed.
        /// </summary>
        private string? GetFinalUri(string? resourceLocation)
        {
            // Set final uri as null if the response for initial request doesn't contain header "Operation-Location" or "Azure-AsyncOperation".
            if (_headerSource is not (HeaderSource.OperationLocation or HeaderSource.AzureAsyncOperation))
            {
                return null;
            }

            // Set final uri as null if initial request is a delete method.
            if (RequestMethod == RequestMethod.Delete)
            {
                return null;
            }

            // Handle final-state-via options: https://github.com/Azure/autorest/blob/main/docs/extensions/readme.md#x-ms-long-running-operation-options
            switch (_finalStateVia)
            {
                case OperationFinalStateVia.LocationOverride when !string.IsNullOrEmpty(_lastKnownLocation):
                    return _lastKnownLocation;
                case OperationFinalStateVia.OperationLocation or OperationFinalStateVia.AzureAsyncOperation when RequestMethod == RequestMethod.Post:
                    return null;
                case OperationFinalStateVia.OriginalUri:
                    return _startRequestUri.AbsoluteUri;
            }

            // If response body contains resourceLocation, use it: https://github.com/microsoft/api-guidelines/blob/vNext/Guidelines.md#target-resource-location
            if (resourceLocation != null)
            {
                return resourceLocation;
            }

            // If initial request is PUT or PATCH, return initial request Uri
            if (RequestMethod == RequestMethod.Put || RequestMethod == RequestMethod.Patch)
            {
                return _startRequestUri.AbsoluteUri;
            }

            // If response for initial request contains header "Location", return last known location
            if (!string.IsNullOrEmpty(_lastKnownLocation))
            {
                return _lastKnownLocation;
            }

            return null;
        }

        private Response GetResponse(string uri, CancellationToken cancellationToken)
        {
            using HttpMessage message = CreateRequest(uri);
            _pipeline.Send(message, cancellationToken);

            // If we are doing final get for a delete LRO with 404, just return empty response with 204
            if (message.Response.Status == 404 && RequestMethod == RequestMethod.Delete)
            {
                return new EmptyResponse(HttpStatusCode.NoContent, message.Response.ClientRequestId);
            }
            return message.Response;
        }

        private async ValueTask<Response> GetResponseAsync(string uri, CancellationToken cancellationToken)
        {
            using HttpMessage message = CreateRequest(uri);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);

            // If we are doing final get for a delete LRO with 404, just return empty response with 204
            if (message.Response.Status == 404 && RequestMethod == RequestMethod.Delete)
            {
                return new EmptyResponse(HttpStatusCode.NoContent, message.Response.ClientRequestId);
            }
            return message.Response;
        }

        /// <summary>
        /// This is only used for final get of the delete LRO, we just want to return an empty response with 204 to the user for this case.
        /// </summary>
        private sealed class EmptyResponse : Response
        {
            public EmptyResponse(HttpStatusCode status, string clientRequestId)
            {
                Status = (int)status;
                ReasonPhrase = status.ToString();
                ClientRequestId = clientRequestId;
            }

            public override int Status { get; }

            public override string ReasonPhrase { get; }

            public override Stream? ContentStream { get => null; set => throw new InvalidOperationException("Should not set ContentStream for an empty response."); }
            public override string ClientRequestId { get; set; }

            public override void Dispose()
            {
            }

            /// <inheritdoc />
#if HAS_INTERNALS_VISIBLE_CORE
            internal
#endif
            protected override bool ContainsHeader(string name) => false;

            /// <inheritdoc />
#if HAS_INTERNALS_VISIBLE_CORE
            internal
#endif
            protected override IEnumerable<HttpHeader> EnumerateHeaders() => Array.Empty<HttpHeader>();

            /// <inheritdoc />
#if HAS_INTERNALS_VISIBLE_CORE
            internal
#endif
            protected override bool TryGetHeader(string name, out string value)
            {
                value = string.Empty;
                return false;
            }

            /// <inheritdoc />
#if HAS_INTERNALS_VISIBLE_CORE
            internal
#endif
            protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values)
            {
                values = Array.Empty<string>();
                return false;
            }
        }

        private HttpMessage CreateRequest(string uri)
        {
            HttpMessage message = _pipeline.CreateMessage();
            Request request = message.Request;
            request.Method = RequestMethod.Get;

            if (Uri.TryCreate(uri, UriKind.Absolute, out var nextLink) && nextLink.Scheme != "file")
            {
                request.Uri.Reset(nextLink);
            }
            else
            {
                request.Uri.Reset(new Uri(_startRequestUri, uri));
            }

            return message;
        }

        private static bool IsFinalState(Response response, HeaderSource headerSource, out OperationState? failureState, out string? resourceLocation)
        {
            failureState = null;
            resourceLocation = null;

            if (headerSource == HeaderSource.Location)
            {
                return response.Status != 202;
            }

            if (response.Status is >= 200 and <= 204)
            {
                if (response.ContentStream is { Length: > 0 })
                {
                    try
                    {
                        using JsonDocument document = JsonDocument.Parse(response.ContentStream);
                        var root = document.RootElement;
                        switch (headerSource)
                        {
                            case HeaderSource.None when root.TryGetProperty("properties", out var properties) && properties.TryGetProperty("provisioningState", out JsonElement property):
                            case HeaderSource.OperationLocation when root.TryGetProperty("status", out property):
                            case HeaderSource.AzureAsyncOperation when root.TryGetProperty("status", out property):
                                var state = GetRequiredString(property).ToLowerInvariant();
                                if (FailureStates.Contains(state))
                                {
                                    failureState = OperationState.Failure(response);
                                    return true;
                                }
                                else if (!SuccessStates.Contains(state))
                                {
                                    return false;
                                }
                                else
                                {
                                    if (headerSource is HeaderSource.OperationLocation or HeaderSource.AzureAsyncOperation && root.TryGetProperty("resourceLocation", out var resourceLocationProperty))
                                    {
                                        resourceLocation = resourceLocationProperty.GetString();
                                    }
                                    return true;
                                }
                        }
                    }
                    finally
                    {
                        // It is required to reset the position of the content after reading as this response may be used for deserialization.
                        response.ContentStream.Position = 0;
                    }
                }

                // If headerSource is None and provisioningState was not found, it defaults to Succeeded.
                if (headerSource == HeaderSource.None)
                {
                    return true;
                }
            }

            failureState = OperationState.Failure(response);
            return true;
        }

        private static string GetRequiredString(in JsonElement element)
        {
            var value = element.GetString();
            if (value == null)
                throw new InvalidOperationException($"The requested operation requires an element of type 'String', but the target element has type '{element.ValueKind}'.");

            return value;
        }

        private static bool ShouldIgnoreHeader(RequestMethod method, Response response)
            => method.Method == RequestMethod.Patch.Method && response.Status == 200;

        // Since this method is static, we can't manipulate the instance property OperationId of the class. We need to return isRequestPolling to update the OperationId after creaing the instance.
        private static HeaderSource GetHeaderSource(RequestMethod requestMethod, Uri requestUri, Response response, string? apiVersion, out string nextRequestUri, out bool isNextRequestPolling)
        {
            isNextRequestPolling = false;
            if (ShouldIgnoreHeader(requestMethod, response))
            {
                nextRequestUri = requestUri.AbsoluteUri;
                return HeaderSource.None;
            }

            var headers = response.Headers;
            if (headers.TryGetValue("Operation-Location", out var operationLocationUri))
            {
                nextRequestUri = AppendOrReplaceApiVersion(operationLocationUri, apiVersion);
                isNextRequestPolling = true;
                return HeaderSource.OperationLocation;
            }

            if (headers.TryGetValue("Azure-AsyncOperation", out var azureAsyncOperationUri))
            {
                nextRequestUri = AppendOrReplaceApiVersion(azureAsyncOperationUri, apiVersion);
                isNextRequestPolling = true;
                return HeaderSource.AzureAsyncOperation;
            }

            if (headers.TryGetValue("Location", out var locationUri))
            {
                nextRequestUri = AppendOrReplaceApiVersion(locationUri, apiVersion);
                isNextRequestPolling = true;
                return HeaderSource.Location;
            }

            nextRequestUri = requestUri.AbsoluteUri;
            return HeaderSource.None;
        }

        private static void AssertNotNull<T>(T value, string name)
        {
            if (value is null)
            {
                throw new ArgumentNullException(name);
            }
        }

        private enum HeaderSource
        {
            None,
            OperationLocation,
            AzureAsyncOperation,
            Location
        }

        private class CompletedOperation : IOperation
        {
            private readonly OperationState _operationState;

            private readonly NextLinkOperationImplementation _operation;

            public CompletedOperation(OperationState operationState, NextLinkOperationImplementation operation)
            {
                _operationState = operationState;
                _operation = operation;
            }

            public ValueTask<OperationState> UpdateStateAsync(bool async, CancellationToken cancellationToken) => new(_operationState);

            public RehydrationToken GetRehydrationToken() => _operation.GetRehydrationToken();
        }

        private sealed class OperationToOperationOfT<T> : IOperation<T>
        {
            private readonly IOperationSource<T> _operationSource;
            private readonly IOperation _operation;

            public OperationToOperationOfT(IOperationSource<T> operationSource, IOperation operation)
            {
                _operationSource = operationSource;
                _operation = operation;
            }

            public async ValueTask<OperationState<T>> UpdateStateAsync(bool async, CancellationToken cancellationToken)
            {
                var state = await _operation.UpdateStateAsync(async, cancellationToken).ConfigureAwait(false);
                if (state.HasSucceeded)
                {
                    var result = async
                        ? await _operationSource.CreateResultAsync(state.RawResponse, cancellationToken).ConfigureAwait(false)
                        : _operationSource.CreateResult(state.RawResponse, cancellationToken);

                    return OperationState<T>.Success(state.RawResponse, result);
                }

                if (state.HasCompleted)
                {
                    return OperationState<T>.Failure(state.RawResponse, state.OperationFailedException);
                }

                return OperationState<T>.Pending(state.RawResponse);
            }

            public RehydrationToken GetRehydrationToken() => _operation.GetRehydrationToken();
        }
    }
}
