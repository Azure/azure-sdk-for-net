// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class OperationInternal<TResult>
    {
        private readonly string _operationTypeName;

        private readonly TimeSpan _defaultPollingInterval;

        private readonly ClientDiagnostics _clientDiagnostics;

        private readonly IOperation<TResult> _operation;

        private TResult _value;

        private RequestFailedException _requestFailedException;

        public OperationInternal(string operationTypeName,
            ClientDiagnostics clientDiagnostics,
            IOperation<TResult> operation,
            TimeSpan? defaultPollingInterval = null) : this(operationTypeName, clientDiagnostics, defaultPollingInterval)
        {
            _operation = operation;
        }

        protected OperationInternal(string operationTypeName,
            ClientDiagnostics clientDiagnostics,
            TimeSpan? defaultPollingInterval)
        {
            _operationTypeName = operationTypeName;
            _clientDiagnostics = clientDiagnostics;
            _defaultPollingInterval = defaultPollingInterval ?? TimeSpan.FromSeconds(1);
        }

        public TResult Value
        {
            get
            {
                if (HasValue)
                {
                    return _value;
                }
                else if (RequestFailedException != null)
                {
                    throw RequestFailedException;
                }
                else
                {
                    throw new InvalidOperationException("The operation has not completed yet.");
                }
            }
            protected set
            {
                _value = value;
                HasValue = true;
                HasCompleted = true;
            }
        }

        public bool HasCompleted { get; private set; }

        public bool HasValue { get; private set; }

        protected Response RawResponse { get; set; }

        protected RequestFailedException RequestFailedException
        {
            get => _requestFailedException;
            set
            {
                _requestFailedException = value;
                HasCompleted = true;
            }
        }

        public Response GetRawResponse() => RawResponse;

        public async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken) =>
            await UpdateStatusAsync(async: true, cancellationToken).ConfigureAwait(false);

        public Response UpdateStatus(CancellationToken cancellationToken) =>
            UpdateStatusAsync(async: false, cancellationToken).EnsureCompleted();

        public async ValueTask<Response<TResult>> WaitForCompletionAsync(CancellationToken cancellationToken) =>
            await WaitForCompletionAsync(_defaultPollingInterval, cancellationToken).ConfigureAwait(false);

        public async ValueTask<Response<TResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
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

        protected virtual async Task UpdateOperationAsync(bool async, CancellationToken cancellationToken)
        {
            Response response = async
                    ? await _operation.GetResponseAsync(cancellationToken).ConfigureAwait(false)
                    : _operation.GetResponse(cancellationToken);

            RawResponse = response;

            var status = _operation.UpdateOperationStatus(response);

            if (status == OperationInternalResponseStatus.Succeeded)
            {
                Value = _operation.ParseResponse(response);
            }
            else if (status == OperationInternalResponseStatus.Failed)
            {
                RequestFailedException = _operation.GetFailure(response);
                throw RequestFailedException;
            }
        }

        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            if (HasCompleted)
            {
                return GetRawResponse();
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{_operationTypeName}.UpdateStatus");
            scope.Start();

            try
            {
                await UpdateOperationAsync(async, cancellationToken).ConfigureAwait(false);
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

            return GetRawResponse();
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal class OperationInternal<TResult, TResponseType> : OperationInternal<TResult>
#pragma warning restore SA1402 // File may only contain a single type
    {
        private readonly IOperation<TResult, TResponseType> _operation;

        public OperationInternal(string operationTypeName,
            ClientDiagnostics clientDiagnostics,
            IOperation<TResult, TResponseType> operation,
            TimeSpan? defaultPollingInterval = null) : base(operationTypeName, clientDiagnostics, defaultPollingInterval)
        {
            _operation = operation;
        }

        protected override async Task UpdateOperationAsync(bool async, CancellationToken cancellationToken)
        {
            Response<TResponseType> response = async
                    ? await _operation.GetResponseAsync(cancellationToken).ConfigureAwait(false)
                    : _operation.GetResponse(cancellationToken);

            RawResponse = response.GetRawResponse();

            var status = _operation.UpdateOperationStatus(response);

            if (status == OperationInternalResponseStatus.Succeeded)
            {
                Value = _operation.ParseResponse(response);
            }
            else if (status == OperationInternalResponseStatus.Failed)
            {
                RequestFailedException = _operation.GetFailure(response);
                throw RequestFailedException;
            }
        }
    }

    internal interface IOperation<TResult>
    {
        internal Task<Response> GetResponseAsync(CancellationToken cancellationToken);

        internal Response GetResponse(CancellationToken cancellationToken);

        internal OperationInternalResponseStatus UpdateOperationStatus(Response response);

        internal TResult ParseResponse(Response response);

        internal RequestFailedException GetFailure(Response response);
    }

    internal interface IOperation<TResult, TResponseType>
    {
        internal Task<Response<TResponseType>> GetResponseAsync(CancellationToken cancellationToken);

        internal Response<TResponseType> GetResponse(CancellationToken cancellationToken);

        internal OperationInternalResponseStatus UpdateOperationStatus(Response<TResponseType> response);

        internal TResult ParseResponse(Response<TResponseType> response);

        internal RequestFailedException GetFailure(Response<TResponseType> response);
    }

    internal enum OperationInternalResponseStatus
    {
        Pending,
        Succeeded,
        Failed
    }
}
