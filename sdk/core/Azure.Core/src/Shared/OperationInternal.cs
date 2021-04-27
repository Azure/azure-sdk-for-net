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

        private readonly IOperation<TResult> _operation;

        private TResult _value;

        public OperationInternal(ClientDiagnostics clientDiagnostics, IOperation<TResult> operation) : this(clientDiagnostics)
        {
            _operation = operation;
            OperationTypeName = operation.GetType().Name;
        }

        protected OperationInternal(ClientDiagnostics clientDiagnostics)
        {
            ClientDiagnostics = clientDiagnostics;
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
                else if (OperationFailedException != null)
                {
                    throw OperationFailedException;
                }
                else
                {
                    throw new InvalidOperationException("The operation has not completed yet.");
                }
            }
            set
            {
                _value = value;
                HasValue = true;
            }
        }

        public Response RawResponse { get; set; }

        public string OperationTypeName { get; set; }

        public TimeSpan DefaultPollingInterval { get; set; }

        protected ClientDiagnostics ClientDiagnostics { get; }

        protected RequestFailedException OperationFailedException { get; set; }

        public async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken) =>
            await UpdateStatusAsync(async: true, cancellationToken).ConfigureAwait(false);

        public Response UpdateStatus(CancellationToken cancellationToken) =>
            UpdateStatusAsync(async: false, cancellationToken).EnsureCompleted();

        public async ValueTask<Response<TResult>> WaitForCompletionAsync(CancellationToken cancellationToken)
        {
            while (true)
            {
                Response response = await UpdateStatusAsync(cancellationToken).ConfigureAwait(false);

                if (HasCompleted)
                {
                    return Response.FromValue(Value, response);
                }

                var pollingInterval = response.Headers.TryGetValue(RetryAfterHeaderName, out string retryAfterValue)
                    && int.TryParse(retryAfterValue, out int delayInSeconds)
                    ? TimeSpan.FromSeconds(delayInSeconds) : DefaultPollingInterval;

                await Task.Delay(pollingInterval, cancellationToken).ConfigureAwait(false);
            }
        }

        public async ValueTask<Response<TResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            while (true)
            {
                Response response = await UpdateStatusAsync(cancellationToken).ConfigureAwait(false);

                if (HasCompleted)
                {
                    return Response.FromValue(Value, response);
                }

                await Task.Delay(pollingInterval, cancellationToken).ConfigureAwait(false);
            }
        }

        protected virtual async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{OperationTypeName}.UpdateStatus");

            foreach (KeyValuePair<string, string> attribute in ScopeAttributes)
            {
                scope.AddAttribute(attribute.Key, attribute.Value);
            }

            scope.Start();

            try
            {
                Response response = async
                    ? await _operation.GetResponseAsync(cancellationToken).ConfigureAwait(false)
                    : _operation.GetResponse(cancellationToken);

                RawResponse = response;

                var state = _operation.UpdateState(response);

                if (state.Succeeded == true)
                {
                    Value = state.Value;
                    HasCompleted = true;
                }
                else if (state.Succeeded == false)
                {
                    OperationFailedException = state.OperationFailedException;
                    HasCompleted = true;

                    throw OperationFailedException;
                }

                return response;
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
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal class OperationInternal<TResult, TResponseType> : OperationInternal<TResult>
#pragma warning restore SA1402 // File may only contain a single type
    {
        private readonly IOperation<TResult, TResponseType> _operation;

        public OperationInternal(ClientDiagnostics clientDiagnostics, IOperation<TResult, TResponseType> operation) : base(clientDiagnostics)
        {
            _operation = operation;
            OperationTypeName = operation.GetType().Name;
        }

        protected override async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{OperationTypeName}.UpdateStatus");

            foreach (KeyValuePair<string, string> attribute in ScopeAttributes)
            {
                scope.AddAttribute(attribute.Key, attribute.Value);
            }

            scope.Start();

            try
            {
                Response<TResponseType> response = async
                    ? await _operation.GetResponseAsync(cancellationToken).ConfigureAwait(false)
                    : _operation.GetResponse(cancellationToken);

                Response rawResponse = response.GetRawResponse();
                RawResponse = rawResponse;

                var state = _operation.UpdateState(response);

                if (state.Succeeded == true)
                {
                    Value = state.Value;
                    HasCompleted = true;
                }
                else if (state.Succeeded == false)
                {
                    OperationFailedException = state.OperationFailedException;
                    HasCompleted = true;

                    throw OperationFailedException;
                }

                return rawResponse;
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
    }

    internal interface IOperation<TResult>
    {
        Task<Response> GetResponseAsync(CancellationToken cancellationToken);

        Response GetResponse(CancellationToken cancellationToken);

        OperationState<TResult> UpdateState(Response response);
    }

    internal interface IOperation<TResult, TResponseType>
    {
        Task<Response<TResponseType>> GetResponseAsync(CancellationToken cancellationToken);

        Response<TResponseType> GetResponse(CancellationToken cancellationToken);

        OperationState<TResult> UpdateState(Response<TResponseType> response);
    }

    internal struct OperationState<TResult>
    {
        public bool? Succeeded { get; set; }

        public TResult Value { get; set; }

        public RequestFailedException OperationFailedException { get; set; }
    }
}
