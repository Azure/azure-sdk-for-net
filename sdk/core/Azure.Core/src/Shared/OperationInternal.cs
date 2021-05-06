// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class OperationInternal<TResult>
    {
        private const string RetryAfterHeaderName = "Retry-After";
        private const string RetryAfterMsHeaderName = "retry-after-ms";
        private const string XRetryAfterMsHeaderName = "x-ms-retry-after-ms";

        private readonly IOperation<TResult> _operation;

        private readonly ClientDiagnostics _diagnostics;

        private readonly string _updateStatusScopeName;

        private TResult _value;

        private RequestFailedException _operationFailedException;

        public OperationInternal(ClientDiagnostics clientDiagnostics, IOperation<TResult> operation, string operationTypeName = null)
        {
            operationTypeName ??= operation.GetType().Name;

            _operation = operation;
            _diagnostics = clientDiagnostics;
            _updateStatusScopeName = $"{operationTypeName}.UpdateStatus";
            DefaultPollingInterval = TimeSpan.FromSeconds(1);
            ScopeAttributes = new Dictionary<string, string>();
        }

        public IDictionary<string, string> ScopeAttributes { get; }

        public bool HasValue { get; private set; }

        public bool HasCompleted { get; set; }

        public TResult Value
        {
            get
            {
                if (HasValue)
                {
                    return _value;
                }
                else if (_operationFailedException != null)
                {
                    throw _operationFailedException;
                }
                else
                {
                    throw new InvalidOperationException("The operation has not completed yet.");
                }
            }
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(Value));
                }

                _value = value;
                HasValue = true;
            }
        }

        public Response RawResponse { get; set; }

        public TimeSpan DefaultPollingInterval { get; set; }

        public async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken) =>
            await UpdateStatusAsync(async: true, cancellationToken).ConfigureAwait(false);

        public Response UpdateStatus(CancellationToken cancellationToken) =>
            UpdateStatusAsync(async: false, cancellationToken).EnsureCompleted();

        public async ValueTask<Response<TResult>> WaitForCompletionAsync(CancellationToken cancellationToken) =>
            await WaitForCompletionAsync(DefaultPollingInterval, cancellationToken).ConfigureAwait(false);

        public async ValueTask<Response<TResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            while (true)
            {
                Response response = await UpdateStatusAsync(cancellationToken).ConfigureAwait(false);

                if (HasCompleted)
                {
                    return Response.FromValue(Value, response);
                }

                var serverDelay = GetServerDelay(response);

                var delay = serverDelay > pollingInterval
                    ? serverDelay : pollingInterval;

                await WaitAsync(delay, cancellationToken).ConfigureAwait(false);
            }
        }

        protected virtual async Task WaitAsync(TimeSpan delay, CancellationToken cancellationToken) =>
            await Task.Delay(delay, cancellationToken).ConfigureAwait(false);

        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope(_updateStatusScopeName);

            foreach (KeyValuePair<string, string> attribute in ScopeAttributes)
            {
                scope.AddAttribute(attribute.Key, attribute.Value);
            }

            scope.Start();

            try
            {
                return await UpdateStateAsync(async, cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException e)
            {
                scope.Failed(e);
                throw;
            }
            catch (Exception e)
            {
                var requestFailedException = new RequestFailedException("Unexpected failure.", e);
                scope.Failed(requestFailedException);
                throw requestFailedException;
            }
        }

        private async ValueTask<Response> UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            var state = await _operation.UpdateStateAsync(async, cancellationToken).ConfigureAwait(false);

            RawResponse = state.RawResponse;

            if (state.Succeeded == true)
            {
                Value = state.Value;
                HasCompleted = true;
            }
            else if (state.Succeeded == false)
            {
                _operationFailedException = state.OperationFailedException ?? (async
                    ? await _diagnostics.CreateRequestFailedExceptionAsync(state.RawResponse).ConfigureAwait(false)
                    : _diagnostics.CreateRequestFailedException(state.RawResponse));
                HasCompleted = true;

                throw _operationFailedException;
            }

            return state.RawResponse;
        }

        private static TimeSpan GetServerDelay(Response response)
        {
            if (response.Headers.TryGetValue(RetryAfterMsHeaderName, out string retryAfterValue)
                || response.Headers.TryGetValue(XRetryAfterMsHeaderName, out retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out int serverDelayInMilliseconds))
                {
                    return TimeSpan.FromMilliseconds(serverDelayInMilliseconds);
                }
            }

            if (response.Headers.TryGetValue(RetryAfterHeaderName, out retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out int serverDelayInSeconds))
                {
                    return TimeSpan.FromSeconds(serverDelayInSeconds);
                }
            }

            return TimeSpan.Zero;
        }
    }

    internal interface IOperation<TResult>
    {
        ValueTask<OperationState<TResult>> UpdateStateAsync(bool async, CancellationToken cancellationToken);
    }

    internal readonly struct OperationState<TResult>
    {
        private OperationState(Response rawResponse, bool? succeeded, TResult value, RequestFailedException operationFailedException)
        {
            RawResponse = rawResponse;
            Succeeded = succeeded;
            Value = value;
            OperationFailedException = operationFailedException;
        }

        public Response RawResponse { get; }

        public bool? Succeeded { get; }

        public TResult Value { get; }

        public RequestFailedException OperationFailedException { get; }

        public static OperationState<TResult> Success(Response rawResponse, TResult value) =>
            new OperationState<TResult>(rawResponse, true, value, default);

        public static OperationState<TResult> Failure(Response rawResponse, RequestFailedException operationFailedException = null) =>
            new OperationState<TResult>(rawResponse, false, default, operationFailedException);

        public static OperationState<TResult> Pending(Response rawResponse) =>
            new OperationState<TResult>(rawResponse, default, default, default);
    }
}
