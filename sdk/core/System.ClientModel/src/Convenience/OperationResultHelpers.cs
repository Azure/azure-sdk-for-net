// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Globalization;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace System.ClientModel.Primitives;

internal enum OperationFinalStateVia
{
    AzureAsyncOperation,
    Location,
    OriginalUri,
    OperationLocation,
    LocationOverride,
}

internal static class OperationResultHelpers
{
    internal static ClientResult ToClientResult(OperationResult operation) =>
        ClientResult.FromResponse(operation.GetRawResponse());

    internal static async Task<ClientResult> ToClientResultAsync(Task<OperationResult> operation) =>
        ToClientResult(await operation.ConfigureAwait(false));

    public static OperationResult ProcessMessage(
        ClientPipeline pipeline,
        PipelineMessage message,
        RequestOptions? options,
        OperationFinalStateVia finalStateVia,
        bool waitUntilCompleted)
    {
        Uri requestUri = message.Request.Uri
            ?? throw new InvalidOperationException("The long-running operation request URI was not set.");
        string requestMethod = message.Request.Method;
        message.BufferResponse = true;
        PipelineResponse response = ProcessMessage(pipeline, message, options);
        PipelineOperationResult operation = new(
            pipeline,
            requestMethod,
            requestUri,
            response,
            finalStateVia);

        if (waitUntilCompleted)
        {
            operation.WaitForCompletion(options);
        }

        return operation;
    }

    public static async Task<OperationResult> ProcessMessageAsync(
        ClientPipeline pipeline,
        PipelineMessage message,
        RequestOptions? options,
        OperationFinalStateVia finalStateVia,
        bool waitUntilCompleted)
    {
        Uri requestUri = message.Request.Uri
            ?? throw new InvalidOperationException("The long-running operation request URI was not set.");
        string requestMethod = message.Request.Method;
        message.BufferResponse = true;
        PipelineResponse response = await ProcessMessageAsync(pipeline, message, options).ConfigureAwait(false);
        PipelineOperationResult operation = new(
            pipeline,
            requestMethod,
            requestUri,
            response,
            finalStateVia);

        if (waitUntilCompleted)
        {
            await operation.WaitForCompletionAsync(options).ConfigureAwait(false);
        }

        return operation;
    }

    private sealed class PipelineOperationResult : OperationResult
    {
        private static readonly TimeSpan DefaultPollingInterval = TimeSpan.FromSeconds(1);

        private readonly ClientPipeline _pipeline;
        private readonly string _requestMethod;
        private readonly Uri _requestUri;
        private readonly HeaderSource _headerSource;
        private readonly OperationFinalStateVia _finalStateVia;
        private Uri? _pollingUri;
        private Uri? _lastKnownLocation;
        private Uri? _finalUri;

        public PipelineOperationResult(
            ClientPipeline pipeline,
            string requestMethod,
            Uri requestUri,
            PipelineResponse response,
            OperationFinalStateVia finalStateVia)
            : base(response)
        {
            _pipeline = pipeline;
            _requestMethod = requestMethod;
            _requestUri = requestUri;
            _finalStateVia = finalStateVia;
            _headerSource = GetPollingUri(requestUri, response, out _pollingUri);
            UpdateLastKnownLocation(response);
            if (_headerSource == HeaderSource.None)
            {
                UpdateState(response, isFinalGet: false);
            }
        }

        public override ContinuationToken? RehydrationToken { get; protected set; }

        public override async ValueTask<ClientResult> UpdateStatusAsync(RequestOptions? options = default)
        {
            if (HasCompleted)
            {
                return ClientResult.FromResponse(GetRawResponse());
            }

            PipelineResponse response = await GetResponseAsync(
                _finalUri ?? _pollingUri ?? _requestUri,
                options).ConfigureAwait(false);
            return ClientResult.FromResponse(await ApplyUpdateAsync(response, options).ConfigureAwait(false));
        }

        public override ClientResult UpdateStatus(RequestOptions? options = default)
        {
            if (HasCompleted || _pollingUri is null)
            {
                return ClientResult.FromResponse(GetRawResponse());
            }

            PipelineResponse response = GetResponse(
                _finalUri ?? _pollingUri ?? _requestUri,
                options);
            return ClientResult.FromResponse(ApplyUpdate(response, options));
        }

        public override async ValueTask WaitForCompletionAsync(CancellationToken cancellationToken = default)
            => await WaitForCompletionAsync(CreateRequestOptions(cancellationToken)).ConfigureAwait(false);

        public override void WaitForCompletion(CancellationToken cancellationToken = default)
            => WaitForCompletion(CreateRequestOptions(cancellationToken));

        internal async ValueTask WaitForCompletionAsync(RequestOptions? options)
        {
            CancellationToken cancellationToken = options?.CancellationToken ?? default;
            while (!HasCompleted)
            {
                await Task.Delay(GetPollingDelay(GetRawResponse()), cancellationToken).ConfigureAwait(false);
                PipelineResponse response = await GetResponseAsync(
                    _finalUri ?? _pollingUri ?? _requestUri,
                    options).ConfigureAwait(false);
                await ApplyUpdateAsync(response, options).ConfigureAwait(false);
            }
        }

        internal void WaitForCompletion(RequestOptions? options)
        {
            CancellationToken cancellationToken = options?.CancellationToken ?? default;
            while (!HasCompleted)
            {
                Wait(GetPollingDelay(GetRawResponse()), cancellationToken);
                PipelineResponse response = GetResponse(
                    _finalUri ?? _pollingUri ?? _requestUri,
                    options);
                ApplyUpdate(response, options);
            }
        }

        private async ValueTask<PipelineResponse> ApplyUpdateAsync(
            PipelineResponse response,
            RequestOptions? options)
        {
            bool isFinalGet = _finalUri is not null;
            UpdateState(response, isFinalGet);
            if (_finalUri is not null && !isFinalGet)
            {
                PipelineResponse pollingResponse = response;
                try
                {
                    response = await GetResponseAsync(
                        _finalUri,
                        options).ConfigureAwait(false);
                }
                finally
                {
                    pollingResponse.Dispose();
                }
                UpdateState(response, isFinalGet: true);
            }

            SetRawResponse(response);
            return response;
        }

        private PipelineResponse ApplyUpdate(PipelineResponse response, RequestOptions? options)
        {
            bool isFinalGet = _finalUri is not null;
            UpdateState(response, isFinalGet);
            if (_finalUri is not null && !isFinalGet)
            {
                PipelineResponse pollingResponse = response;
                try
                {
                    response = GetResponse(
                        _finalUri,
                        options);
                }
                finally
                {
                    pollingResponse.Dispose();
                }
                UpdateState(response, isFinalGet: true);
            }

            SetRawResponse(response);
            return response;
        }

        private void UpdateState(PipelineResponse response, bool isFinalGet)
        {
            if (isFinalGet)
            {
                HasCompleted = true;
                _finalUri = null;
                return;
            }

            UpdateLastKnownLocation(response);
            UpdatePollingUri(response);
            OperationState state = GetOperationState(response, _headerSource, out Uri? resourceLocation);
            if (state == OperationState.InProgress)
            {
                HasCompleted = false;
                return;
            }

            _finalUri = state == OperationState.Succeeded
                ? GetFinalUri(resourceLocation)
                : null;
            HasCompleted = _finalUri is null;
        }

        private Uri? GetFinalUri(Uri? resourceLocation)
        {
            if (_headerSource is not (HeaderSource.OperationLocation or HeaderSource.AzureAsyncOperation) ||
                string.Equals(_requestMethod, "DELETE", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            switch (_finalStateVia)
            {
                case OperationFinalStateVia.LocationOverride when _lastKnownLocation is not null:
                    return _lastKnownLocation;
                case OperationFinalStateVia.OperationLocation or OperationFinalStateVia.AzureAsyncOperation
                    when string.Equals(_requestMethod, "POST", StringComparison.OrdinalIgnoreCase):
                    return null;
                case OperationFinalStateVia.OriginalUri:
                    return _requestUri;
            }

            if (resourceLocation is not null)
            {
                return resourceLocation;
            }

            if (string.Equals(_requestMethod, "PUT", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(_requestMethod, "PATCH", StringComparison.OrdinalIgnoreCase))
            {
                return _requestUri;
            }

            return _lastKnownLocation;
        }

        private void UpdateLastKnownLocation(PipelineResponse response)
        {
            if (TryGetHeader(response, "Location", out string? value))
            {
                _lastKnownLocation = ResolveUri(_requestUri, value!);
            }
        }

        private void UpdatePollingUri(PipelineResponse response)
        {
            string headerName = _headerSource switch
            {
                HeaderSource.OperationLocation => "Operation-Location",
                HeaderSource.AzureAsyncOperation => "Azure-AsyncOperation",
                HeaderSource.Location => "Location",
                _ => string.Empty,
            };

            if (headerName.Length > 0 && TryGetHeader(response, headerName, out string? value))
            {
                _pollingUri = ResolveUri(_requestUri, value!);
            }
        }

        private PipelineResponse GetResponse(
            Uri uri,
            RequestOptions? options)
        {
            using PipelineMessage message = CreateGetMessage(uri, options);
            return ProcessMessage(
                _pipeline,
                message,
                options,
                allowNotFound: string.Equals(_requestMethod, "DELETE", StringComparison.OrdinalIgnoreCase));
        }

        private async ValueTask<PipelineResponse> GetResponseAsync(
            Uri uri,
            RequestOptions? options)
        {
            using PipelineMessage message = CreateGetMessage(uri, options);
            return await ProcessMessageAsync(
                _pipeline,
                message,
                options,
                allowNotFound: string.Equals(_requestMethod, "DELETE", StringComparison.OrdinalIgnoreCase))
                .ConfigureAwait(false);
        }

        private PipelineMessage CreateGetMessage(
            Uri uri,
            RequestOptions? options)
        {
            PipelineMessage message = _pipeline.CreateMessage(uri, "GET");
            message.Apply(options);
            message.BufferResponse = true;
            return message;
        }

        private static RequestOptions? CreateRequestOptions(CancellationToken cancellationToken) =>
            cancellationToken.CanBeCanceled
                ? new RequestOptions { CancellationToken = cancellationToken }
                : null;

        private static HeaderSource GetPollingUri(
            Uri requestUri,
            PipelineResponse response,
            out Uri? pollingUri)
        {
            if (TryGetHeader(response, "Operation-Location", out string? value))
            {
                pollingUri = ResolveUri(requestUri, value!);
                return HeaderSource.OperationLocation;
            }

            if (TryGetHeader(response, "Azure-AsyncOperation", out value))
            {
                pollingUri = ResolveUri(requestUri, value!);
                return HeaderSource.AzureAsyncOperation;
            }

            if (TryGetHeader(response, "Location", out value))
            {
                pollingUri = ResolveUri(requestUri, value!);
                return HeaderSource.Location;
            }

            pollingUri = requestUri;
            return HeaderSource.None;
        }

        private OperationState GetOperationState(
            PipelineResponse response,
            HeaderSource headerSource,
            out Uri? resourceLocation)
        {
            resourceLocation = null;
            if (headerSource == HeaderSource.Location)
            {
                return response.Status == 202 ? OperationState.InProgress : GetFinalResponseState(response);
            }

            if (response.Status is < 200 or > 204)
            {
                return OperationState.Failed;
            }

            string propertyName = headerSource == HeaderSource.None ? "provisioningState" : "status";
            if (!TryGetStatus(response, propertyName, out string? status, out string? resourceLocationValue))
            {
                return headerSource == HeaderSource.None
                    ? OperationState.Succeeded
                    : OperationState.Failed;
            }

            if (!string.IsNullOrEmpty(resourceLocationValue))
            {
                resourceLocation = ResolveUri(_requestUri, resourceLocationValue!);
            }

            if (string.Equals(status, "succeeded", StringComparison.OrdinalIgnoreCase))
            {
                return OperationState.Succeeded;
            }

            if (string.Equals(status, "failed", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(status, "canceled", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(status, "cancelled", StringComparison.OrdinalIgnoreCase))
            {
                return OperationState.Failed;
            }

            return OperationState.InProgress;
        }

        private static OperationState GetFinalResponseState(PipelineResponse response) =>
            response.Status is >= 200 and <= 204 ? OperationState.Succeeded : OperationState.Failed;

        private static bool TryGetStatus(
            PipelineResponse response,
            string propertyName,
            out string? status,
            out string? resourceLocation)
        {
            status = null;
            resourceLocation = null;
            if (response.Content.ToMemory().IsEmpty)
            {
                return false;
            }

            try
            {
                using JsonDocument document = JsonDocument.Parse(response.Content);
                JsonElement root = document.RootElement;
                if (propertyName == "provisioningState" &&
                    root.TryGetProperty("properties", out JsonElement properties))
                {
                    root = properties;
                }

                if (root.ValueKind != JsonValueKind.Object ||
                    !root.TryGetProperty(propertyName, out JsonElement statusElement) ||
                    statusElement.ValueKind != JsonValueKind.String)
                {
                    return false;
                }

                status = statusElement.GetString();
                if (document.RootElement.TryGetProperty("resourceLocation", out JsonElement resourceLocationElement) &&
                    resourceLocationElement.ValueKind == JsonValueKind.String)
                {
                    resourceLocation = resourceLocationElement.GetString();
                }
                return status is not null;
            }
            catch (JsonException)
            {
                return false;
            }
        }

        private static bool TryGetHeader(PipelineResponse response, string name, out string? value) =>
            response.Headers.TryGetValue(name, out value) && !string.IsNullOrWhiteSpace(value);

        private static Uri ResolveUri(Uri requestUri, string value)
        {
            Uri uri = new(requestUri, value);
            string? apiVersion = GetQueryParameter(requestUri, "api-version");
            if (apiVersion is null)
            {
                return uri;
            }

            UriBuilder builder = new(uri);
            string query = builder.Query.TrimStart('?');
            string[] parameters = query.Length == 0 ? [] : query.Split('&');
            bool found = false;
            for (int i = 0; i < parameters.Length; i++)
            {
                int separatorIndex = parameters[i].IndexOf('=');
                string name = separatorIndex < 0
                    ? parameters[i]
                    : parameters[i].Substring(0, separatorIndex);
                if (string.Equals(
                    Uri.UnescapeDataString(name),
                    "api-version",
                    StringComparison.OrdinalIgnoreCase))
                {
                    parameters[i] = $"{name}={apiVersion}";
                    found = true;
                    break;
                }
            }

            builder.Query = found
                ? string.Join("&", parameters)
                : query.Length == 0
                    ? $"api-version={apiVersion}"
                    : $"{query}&api-version={apiVersion}";
            return builder.Uri;
        }

        private static string? GetQueryParameter(Uri uri, string parameterName)
        {
            foreach (string parameter in uri.Query.TrimStart('?').Split('&'))
            {
                int separatorIndex = parameter.IndexOf('=');
                string name = separatorIndex < 0
                    ? parameter
                    : parameter.Substring(0, separatorIndex);
                if (string.Equals(
                    Uri.UnescapeDataString(name),
                    parameterName,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return separatorIndex < 0
                        ? string.Empty
                        : parameter.Substring(separatorIndex + 1);
                }
            }

            return null;
        }

        private static TimeSpan GetPollingDelay(PipelineResponse response)
        {
            if (TryGetHeader(response, "Retry-After", out string? value))
            {
                if (int.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out int seconds) &&
                    seconds >= 0)
                {
                    return TimeSpan.FromSeconds(seconds);
                }

                if (DateTimeOffset.TryParse(
                    value,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.AssumeUniversal,
                    out DateTimeOffset retryAfter))
                {
                    TimeSpan delay = retryAfter - DateTimeOffset.UtcNow;
                    return delay > TimeSpan.Zero ? delay : TimeSpan.Zero;
                }
            }

            return DefaultPollingInterval;
        }

        private static void Wait(TimeSpan delay, CancellationToken cancellationToken)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                Thread.Sleep(delay);
                return;
            }

            if (cancellationToken.WaitHandle.WaitOne(delay))
            {
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        private enum HeaderSource
        {
            None,
            OperationLocation,
            AzureAsyncOperation,
            Location,
        }

        private enum OperationState
        {
            InProgress,
            Succeeded,
            Failed,
        }
    }

    private static PipelineResponse ProcessMessage(
        ClientPipeline pipeline,
        PipelineMessage message,
        RequestOptions? options,
        bool allowNotFound = false)
    {
        pipeline.Send(message);
        return ExtractResponse(message, options, allowNotFound);
    }

    private static async ValueTask<PipelineResponse> ProcessMessageAsync(
        ClientPipeline pipeline,
        PipelineMessage message,
        RequestOptions? options,
        bool allowNotFound = false)
    {
        await pipeline.SendAsync(message).ConfigureAwait(false);
        return ExtractResponse(message, options, allowNotFound);
    }

    private static PipelineResponse ExtractResponse(
        PipelineMessage message,
        RequestOptions? options,
        bool allowNotFound)
    {
        PipelineResponse response = message.Response
            ?? throw new InvalidOperationException("The client pipeline did not set a response.");
        if (response.IsError &&
            !(allowNotFound && response.Status == 404) &&
            (options?.ErrorOptions & ClientErrorBehaviors.NoThrow) != ClientErrorBehaviors.NoThrow)
        {
            throw new ClientResultException(response);
        }

        return message.ExtractResponse()!;
    }
}
