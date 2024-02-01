// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class NextLinkOperationImplementation : IOperation
    {
        private const string ApiVersionParam = "api-version";
        private static readonly string[] FailureStates = { "failed", "canceled" };
        private static readonly string[] SuccessStates = { "succeeded" };

        private readonly HeaderSource _headerSource;
        private readonly Uri _startRequestUri;
        private readonly OperationFinalStateVia _finalStateVia;
        private readonly RequestMethod _requestMethod;
        private readonly HttpPipeline _pipeline;
        private readonly string? _apiVersion;

        private string? _lastKnownLocation;
        private string _nextRequestUri;

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
            var headerSource = GetHeaderSource(requestMethod, startRequestUri, response, apiVersionStr, out var nextRequestUri);
            if (headerSource == HeaderSource.None && IsFinalState(response, headerSource, out var failureState, out _))
            {
                return new CompletedOperation(failureState ?? GetOperationStateFromFinalResponse(requestMethod, response));
            }
            response.Headers.TryGetValue("Location", out var lastKnownLocation);
            return new NextLinkOperationImplementation(pipeline, requestMethod, startRequestUri, nextRequestUri, headerSource, lastKnownLocation, finalStateVia, apiVersionStr);
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

        private NextLinkOperationImplementation(
            HttpPipeline pipeline,
            RequestMethod requestMethod,
            Uri startRequestUri,
            string nextRequestUri,
            HeaderSource headerSource,
            string? lastKnownLocation,
            OperationFinalStateVia finalStateVia,
            string? apiVersion)
        {
            _requestMethod = requestMethod;
            _headerSource = headerSource;
            _startRequestUri = startRequestUri;
            _nextRequestUri = nextRequestUri;
            _lastKnownLocation = lastKnownLocation;
            _finalStateVia = finalStateVia;
            _pipeline = pipeline;
            _apiVersion = apiVersion;
        }

        public async ValueTask<OperationState> UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            Response response = await GetResponseAsync(async, _nextRequestUri, cancellationToken).ConfigureAwait(false);

            var hasCompleted = IsFinalState(response, _headerSource, out var failureState, out var resourceLocation);
            if (failureState != null)
            {
                return failureState.Value;
            }

            if (hasCompleted)
            {
                string? finalUri = GetFinalUri(resourceLocation);
                var finalResponse = finalUri != null
                    ? await GetResponseAsync(async, finalUri, cancellationToken).ConfigureAwait(false)
                    : response;

                return GetOperationStateFromFinalResponse(_requestMethod, finalResponse);
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
                    return;
                case HeaderSource.AzureAsyncOperation when headers.TryGetValue("Azure-AsyncOperation", out string? azureAsyncOperation):
                    _nextRequestUri = AppendOrReplaceApiVersion(azureAsyncOperation, _apiVersion);
                    return;
                case HeaderSource.Location when hasLocation:
                    _nextRequestUri = AppendOrReplaceApiVersion(location!, _apiVersion);
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
            if (_requestMethod == RequestMethod.Delete)
            {
                return null;
            }

            // Handle final-state-via options: https://github.com/Azure/autorest/blob/main/docs/extensions/readme.md#x-ms-long-running-operation-options
            switch (_finalStateVia)
            {
                case OperationFinalStateVia.LocationOverride when !string.IsNullOrEmpty(_lastKnownLocation):
                    return _lastKnownLocation;
                case OperationFinalStateVia.OperationLocation or OperationFinalStateVia.AzureAsyncOperation when _requestMethod == RequestMethod.Post:
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
            if (_requestMethod == RequestMethod.Put || _requestMethod == RequestMethod.Patch)
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

        private async ValueTask<Response> GetResponseAsync(bool async, string uri, CancellationToken cancellationToken)
        {
            using HttpMessage message = CreateRequest(uri);
            if (async)
            {
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                _pipeline.Send(message, cancellationToken);
            }
            return message.Response;
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
                if (response.ContentStream is {Length: > 0})
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
                                var state = property.GetRequiredString().ToLowerInvariant();
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

        private static bool ShouldIgnoreHeader(RequestMethod method, Response response)
            => method.Method == RequestMethod.Patch.Method && response.Status == 200;

        private static HeaderSource GetHeaderSource(RequestMethod requestMethod, Uri requestUri, Response response, string? apiVersion, out string nextRequestUri)
        {
            if (ShouldIgnoreHeader(requestMethod, response))
            {
                nextRequestUri = requestUri.AbsoluteUri;
                return HeaderSource.None;
            }

            var headers = response.Headers;
            if (headers.TryGetValue("Operation-Location", out var operationLocationUri))
            {
                nextRequestUri = AppendOrReplaceApiVersion(operationLocationUri, apiVersion);
                return HeaderSource.OperationLocation;
            }

            if (headers.TryGetValue("Azure-AsyncOperation", out var azureAsyncOperationUri))
            {
                nextRequestUri = AppendOrReplaceApiVersion(azureAsyncOperationUri, apiVersion);
                return HeaderSource.AzureAsyncOperation;
            }

            if (headers.TryGetValue("Location", out var locationUri))
            {
                nextRequestUri = AppendOrReplaceApiVersion(locationUri, apiVersion);
                return HeaderSource.Location;
            }

            nextRequestUri = requestUri.AbsoluteUri;
            return HeaderSource.None;
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

            public CompletedOperation(OperationState operationState)
            {
                _operationState = operationState;
            }

            public ValueTask<OperationState> UpdateStateAsync(bool async, CancellationToken cancellationToken) => new(_operationState);
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
        }
    }
}
