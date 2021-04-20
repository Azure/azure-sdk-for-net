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
        private readonly TimeSpan _defaultPollingInterval;

        private readonly IOperation<TResult> _operation;

        private TResult _value;

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
            OperationTypeName = operationTypeName;
            ClientDiagnostics = clientDiagnostics;
            _defaultPollingInterval = defaultPollingInterval ?? TimeSpan.FromSeconds(1);
        }

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

        protected string OperationTypeName { get; }

        protected ClientDiagnostics ClientDiagnostics { get; }

        protected RequestFailedException OperationFailedException { get; set; }

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

            _operation.AddAttributes(scope);
            scope.Start();

            try
            {
                Response response = async
                    ? await _operation.GetResponseAsync(cancellationToken).ConfigureAwait(false)
                    : _operation.GetResponse(cancellationToken);

                RawResponse = response;

                var status = _operation.UpdateState(response);

                if (status == CompletionStatus.Succeeded)
                {
                    Value = _operation.ParseResponse(response);
                    HasCompleted = true;
                }
                else if (status == CompletionStatus.Failed)
                {
                    OperationFailedException = _operation.GetOperationFailedException(response);
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

        public OperationInternal(string operationTypeName,
            ClientDiagnostics clientDiagnostics,
            IOperation<TResult, TResponseType> operation,
            TimeSpan? defaultPollingInterval = null) : base(operationTypeName, clientDiagnostics, defaultPollingInterval)
        {
            _operation = operation;
        }

        protected override async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{OperationTypeName}.UpdateStatus");

            _operation.AddAttributes(scope);
            scope.Start();

            try
            {
                Response<TResponseType> response = async
                    ? await _operation.GetResponseAsync(cancellationToken).ConfigureAwait(false)
                    : _operation.GetResponse(cancellationToken);

                Response rawResponse = response.GetRawResponse();
                RawResponse = rawResponse;

                var status = _operation.UpdateState(response);

                if (status == CompletionStatus.Succeeded)
                {
                    Value = _operation.ParseResponse(response);
                    HasCompleted = true;
                }
                else if (status == CompletionStatus.Failed)
                {
                    OperationFailedException = _operation.GetOperationFailedException(response);
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

        CompletionStatus UpdateState(Response response);

        TResult ParseResponse(Response response);

        RequestFailedException GetOperationFailedException(Response response);

        void AddAttributes(DiagnosticScope scope);
    }

    internal interface IOperation<TResult, TResponseType>
    {
        Task<Response<TResponseType>> GetResponseAsync(CancellationToken cancellationToken);

        Response<TResponseType> GetResponse(CancellationToken cancellationToken);

        CompletionStatus UpdateState(Response<TResponseType> response);

        TResult ParseResponse(Response<TResponseType> response);

        RequestFailedException GetOperationFailedException(Response<TResponseType> response);

        void AddAttributes(DiagnosticScope scope);
    }

    internal enum CompletionStatus
    {
        Pending,
        Succeeded,
        Failed
    }
}
