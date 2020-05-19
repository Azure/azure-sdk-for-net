// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// This implements the ARM scenarios for LROs. It is highly recommended to read the ARM spec prior to modifying this code:
    /// https://github.com/Azure/azure-resource-manager-rpc/blob/master/v1.0/Addendum.md#asynchronous-operations
    /// Other reference documents include:
    /// https://github.com/Azure/autorest/blob/master/docs/extensions/readme.md#x-ms-long-running-operation
    /// https://github.com/Azure/adx-documentation-pr/blob/master/sdks/LRO/LRO_AzureSDK.md
    /// </summary>
    /// <typeparam name="T">The final result of the LRO.</typeparam>
    internal class ArmOperationHelpers<T>
    {
        public static TimeSpan DefaultPollingInterval { get; } = TimeSpan.FromSeconds(1);

        private static readonly string[] s_failureStates = {"failed", "canceled"};
        private static readonly string[] s_terminalStates = {"succeeded", "failed", "canceled"};

        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly string _scopeName;
        private readonly RequestMethod _requestMethod;
        private readonly string _originalUri;
        private readonly OperationFinalStateVia _finalStateVia;
        private HeaderFrom _headerFrom;
        private string _pollUri = default!;
        private bool _originalHasLocation;
        private string? _lastKnownLocation;

        private readonly IOperationSource<T> _source;
        private Response _rawResponse;
        private T _value = default!;
        private bool _hasValue;
        private bool _hasCompleted;
        private bool _shouldPoll;

        public ArmOperationHelpers(
            IOperationSource<T> source,
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            Request originalRequest,
            Response originalResponse,
            OperationFinalStateVia finalStateVia,
            string scopeName)
        {
            _source = source;
            _rawResponse = originalResponse;
            _requestMethod = originalRequest.Method;
            _originalUri = originalRequest.Uri.ToString();
            _finalStateVia = finalStateVia;
            InitializeScenarioInfo();

            _pipeline = pipeline;
            _clientDiagnostics = clientDiagnostics;
            _scopeName = scopeName;
            // When the original response has no headers, we do not start polling immediately.
            _shouldPoll = _headerFrom != HeaderFrom.None;
        }

        public Response GetRawResponse() => _rawResponse;

        public ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            return WaitForCompletionAsync(DefaultPollingInterval, cancellationToken);
        }

        public async ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            while (true)
            {
                await UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
                if (HasCompleted)
                {
                    return Response.FromValue(Value, GetRawResponse());
                }

                await Task.Delay(pollingInterval, cancellationToken).ConfigureAwait(false);
            }
        }

        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            if (_hasCompleted)
            {
                return GetRawResponse();
            }

            if (_shouldPoll)
            {
                UpdatePollUri();
                _rawResponse = async
                    ? await GetResponseAsync(_pollUri, cancellationToken).ConfigureAwait(false)
                    : GetResponse(_pollUri, cancellationToken);
            }

            _shouldPoll = true;
            _hasCompleted = IsTerminalState(out string state);
            if (_hasCompleted)
            {
                Response finalResponse = GetRawResponse();
                if (s_failureStates.Contains(state))
                {
                    throw _clientDiagnostics.CreateRequestFailedException(finalResponse);
                }

                string? finalUri = GetFinalUri();
                if (finalUri != null)
                {
                    finalResponse = async
                        ? await GetResponseAsync(finalUri, cancellationToken).ConfigureAwait(false)
                        : GetResponse(finalUri, cancellationToken);
                }

                switch (finalResponse.Status)
                {
                    case 200:
                    case 201 when _requestMethod == RequestMethod.Put:
                    case 204 when !(_requestMethod == RequestMethod.Put || _requestMethod == RequestMethod.Patch):
                    {
                        _value = async
                            ? await _source.CreateResultAsync(finalResponse, cancellationToken).ConfigureAwait(false)
                            : _source.CreateResult(finalResponse, cancellationToken);
                        _rawResponse = finalResponse;
                        _hasValue = true;
                        break;
                    }
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(finalResponse);
                }
            }

            return GetRawResponse();
        }

        public async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => await UpdateStatusAsync(async: true, cancellationToken).ConfigureAwait(false);

        public Response UpdateStatus(CancellationToken cancellationToken = default) => UpdateStatusAsync(async: false, cancellationToken).EnsureCompleted();

#pragma warning disable CA1822
        //TODO: This is currently unused.
        public string Id => throw new NotImplementedException();
#pragma warning restore CA1822

        public T Value
        {
            get
            {
                if (!HasValue)
                {
                    throw new InvalidOperationException("The operation has not completed yet.");
                }

                return _value;
            }
        }

        public bool HasCompleted => _hasCompleted;
        public bool HasValue => _hasValue;

        private HttpMessage CreateRequest(string link)
        {
            HttpMessage message = _pipeline.CreateMessage();
            Request request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(link));
            return message;
        }

        private async ValueTask<Response> GetResponseAsync(string link, CancellationToken cancellationToken = default)
        {
            if (link == null)
            {
                throw new ArgumentNullException(nameof(link));
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope(_scopeName);
            scope.Start();
            try
            {
                using HttpMessage message = CreateRequest(link);
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                return message.Response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response GetResponse(string link, CancellationToken cancellationToken = default)
        {
            if (link == null)
            {
                throw new ArgumentNullException(nameof(link));
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope(_scopeName);
            scope.Start();
            try
            {
                using HttpMessage message = CreateRequest(link);
                _pipeline.Send(message, cancellationToken);
                return message.Response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private bool IsTerminalState(out string state)
        {
            Response response = GetRawResponse();
            state = string.Empty;
            if (_headerFrom == HeaderFrom.Location)
            {
                return response.Status != 202;
            }

            if (response.Status >= 200 && response.Status <= 204)
            {
                if (response.ContentStream?.Length > 0)
                {
                    try
                    {
                        using JsonDocument document = JsonDocument.Parse(response.ContentStream);
                        foreach (JsonProperty property in document.RootElement.EnumerateObject())
                        {
                            if ((_headerFrom == HeaderFrom.OperationLocation ||
                                 _headerFrom == HeaderFrom.AzureAsyncOperation) &&
                                property.NameEquals("status"))
                            {
                                state = property.Value.GetString().ToLowerInvariant();
                                return s_terminalStates.Contains(state);
                            }

                            if (_headerFrom == HeaderFrom.None && property.NameEquals("properties"))
                            {
                                foreach (JsonProperty innerProperty in property.Value.EnumerateObject())
                                {
                                    if (innerProperty.NameEquals("provisioningState"))
                                    {
                                        state = innerProperty.Value.GetString().ToLowerInvariant();
                                        return s_terminalStates.Contains(state);
                                    }
                                }
                            }
                        }
                    }
                    finally
                    {
                        // It is required to reset the position of the content after reading as this response may be used for deserialization.
                        response.ContentStream.Position = 0;
                    }
                }

                // If provisioningState was not found, it defaults to Succeeded.
                if (_headerFrom == HeaderFrom.None)
                {
                    return true;
                }
            }

            throw _clientDiagnostics.CreateRequestFailedException(response);
        }

        private enum HeaderFrom
        {
            None,
            OperationLocation,
            AzureAsyncOperation,
            Location
        }

        private void InitializeScenarioInfo()
        {
            _originalHasLocation = _rawResponse.Headers.Contains("Location");

            if (_rawResponse.Headers.Contains("Operation-Location"))
            {
                _headerFrom = HeaderFrom.OperationLocation;
                return;
            }

            if (_rawResponse.Headers.Contains("Azure-AsyncOperation"))
            {
                _headerFrom = HeaderFrom.AzureAsyncOperation;
                return;
            }

            if (_originalHasLocation)
            {
                _headerFrom = HeaderFrom.Location;
                return;
            }

            _pollUri = _originalUri;
            _headerFrom = HeaderFrom.None;
        }

        private void UpdatePollUri()
        {
            var hasLocation = _rawResponse.Headers.TryGetValue("Location", out string? location);
            if (hasLocation)
            {
                _lastKnownLocation = location;
            }

            switch (_headerFrom)
            {
                case HeaderFrom.OperationLocation when _rawResponse.Headers.TryGetValue("Operation-Location", out string? operationLocation):
                    _pollUri = operationLocation;
                    return;
                case HeaderFrom.AzureAsyncOperation when _rawResponse.Headers.TryGetValue("Azure-AsyncOperation", out string? azureAsyncOperation):
                    _pollUri = azureAsyncOperation;
                    return;
                case HeaderFrom.Location when hasLocation:
                    _pollUri = location!;
                    return;
            }
        }

        private string? GetFinalUri()
        {
            if (_headerFrom == HeaderFrom.OperationLocation || _headerFrom == HeaderFrom.AzureAsyncOperation)
            {
                if (_requestMethod == RequestMethod.Delete)
                {
                    return null;
                }

                if (_requestMethod == RequestMethod.Put || (_originalHasLocation && _finalStateVia == OperationFinalStateVia.OriginalUri))
                {
                    return _originalUri;
                }

                if (_originalHasLocation && _finalStateVia == OperationFinalStateVia.Location)
                {
                    return _lastKnownLocation;
                }
            }

            return null;
        }
    }
}
